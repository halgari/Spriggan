// See https://aka.ms/new-console-template for more information

using Mutagen.Bethesda;
using Mutagen.Bethesda.Plugins.Records;
using Mutagen.Bethesda.Plugins.RecordTypeMapping;
using Mutagen.Bethesda.Skyrim;
using Noggog;
using Spriggan.ConverterGenerators;
using Spriggan.TupleGen;

List<string> generatedConverters = new List<string>();

string MakeCommonName(string n)
{
    return n.TrimEnd("Getter")[1..];
}

var formLinkGetters = new HashSet<Type>();
var nullableFormLinkGetters = new HashSet<Type>();
var allTypes = VisitorGenerator.GetAllTypes(typeof(ISkyrimMajorRecord).Assembly).OrderBy(t => t.Main.Name);

var propLimit = 1000;

// Writers
foreach (var t in allTypes.Where(a => a.Getter.InheritsFrom(typeof(IMajorRecordGetter))).OrderBy(t => t.Main.Name).Take(3))
{
    var cfile = new CFile(GameRelease.SkyrimSE);
    var props = VisitorGenerator.Members(t.Getter).ToArray().OrderBy(t => t.Name);
    var mProps = VisitorGenerator.Members(t.Main)
        .Where(p => p.Name != "FormKey" && p.Name != "TitleString")
        .ToArray().OrderBy(t => t.Name);
    
    var attributes = t.Main.GetCustomAttributes(typeof(AssociatedRecordTypesAttribute), true);


    generatedConverters.Add($"{t.Getter.Name}_Converter");

    cfile.SB.AppendLine($"public class {t.Getter.Name}_Converter : JsonConverter<{t.Getter.Name}>");
    using (cfile.SB.CurlyBrace())
    {
        cfile.SB.AppendLine(
            $"public override {t.Getter.Name} Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)");
        using (cfile.SB.CurlyBrace())
        {
            cfile.SB.AppendLine("throw new NotImplementedException();");
        }

        cfile.SB.AppendLine(
            $"public override void Write(Utf8JsonWriter writer, {t.Getter.Name} value, JsonSerializerOptions options)");
        using (cfile.SB.CurlyBrace())
        {
            cfile.SB.AppendLine("writer.WriteStartObject();");

            cfile.EmitTypeHeader(t.Getter, t.Main.Name);

            foreach (var p in props.Where(p => p.Name != "FormKey" && p.Name != "FormVersion").Take(propLimit))
            {
                cfile.SB.AppendLine("");
                cfile.SB.AppendLine($"// {p.Name}");
                cfile.SB.AppendLine($"writer.WritePropertyName(\"{p.Name}\");");
                cfile.EmitWriter(p.PropertyType, $"value.{p.Name}", new Context());
            }

            cfile.SB.AppendLine("writer.WriteEndObject();");
        }
    }

    generatedConverters.Add($"{t.Main.Name}_Converter");
    cfile.SB.AppendLine($"public class {t.Main.Name}_Converter : JsonConverter<{t.Main.FullName}>");
    using (cfile.SB.CurlyBrace())
    {
        cfile.SB.AppendLine($"private {t.Getter.Name}_Converter _getterConverter;");
        cfile.SB.AppendLine($"public {t.Main.Name}_Converter()");
        using (cfile.SB.CurlyBrace())
        {
            cfile.SB.AppendLine($"_getterConverter = new {t.Getter.Name}_Converter();");
        }

        cfile.SB.AppendLine(
            $"public override void Write(Utf8JsonWriter writer, {t.Main.FullName} value, JsonSerializerOptions options)");
        using (cfile.SB.CurlyBrace())
        {
            cfile.SB.AppendLine($"_getterConverter.Write(writer, ({t.Getter.Name})value, options);");
        }

        cfile.SB.AppendLine(
            $"public override {t.Main.FullName} Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)");
        using (cfile.SB.CurlyBrace())
        {
            cfile.SB.AppendLine("if (reader.TokenType != JsonTokenType.StartObject)");
            using (cfile.SB.IncreaseDepth())
            {
                cfile.SB.AppendLine("throw new JsonException();");
            }
            cfile.SB.AppendLine("reader.Read();");
            cfile.EmitCtor("retval", t.Main, true);
            cfile.SB.AppendLine("while (true)");
            using (cfile.SB.CurlyBrace())
            {
                cfile.SB.AppendLine("reader.Read();");
                cfile.SB.AppendLine("if (reader.TokenType == JsonTokenType.EndObject)");
                using (cfile.SB.CurlyBrace())
                {
                    cfile.SB.AppendLine("reader.Read();");
                    cfile.SB.AppendLine("break;");
                }

                cfile.SB.AppendLine("var prop = reader.GetString();");
                cfile.SB.AppendLine("reader.Read();");
                cfile.SB.AppendLine("switch (prop)");
                using (cfile.SB.CurlyBrace())
                {
                    foreach (var p in mProps.Where(p => p.Name != "FormKey").Take(propLimit))
                    {
                        cfile.SB.AppendLine($"case \"{p.Name}\":");
                        using var _ = cfile.SB.IncreaseDepth();
                        cfile.EmitReader(p.PropertyType, $"retval.{p.Name}", new Context(CFile.IsSettable(p), false));
                        cfile.SB.AppendLine("break;");
                    }

                    cfile.SB.AppendLine("default:");
                    using (cfile.SB.IncreaseDepth())
                    {
                        cfile.SB.AppendLine("reader.Skip();");
                        cfile.SB.AppendLine("break;");
                    }
                }
            }

            cfile.SB.AppendLine("return retval;");
        }
    }

    cfile.Write($"../Spriggan.Converters.Skyrim/{t.Main.Name}.cs");
}

{
    var cfile = new CFile(GameRelease.SkyrimSE);
    cfile.SB.AppendLine("public static class GeneratedConvertersExtensions");
    using (cfile.SB.CurlyBrace())
    {
        cfile.SB.AppendLine("public static IServiceCollection UseConverters(this IServiceCollection services)");
        using (cfile.SB.CurlyBrace())
        {
            foreach (var converter in generatedConverters)
            {
                cfile.SB.AppendLine($"services.AddSingleton<JsonConverter, {converter}>();");
            }

            foreach (var getter in formLinkGetters)
            {
                cfile.SB.AppendLine(
                    $"services.AddSingleton<JsonConverter, IFormLinkGetter_Converter<{getter.Name}>>();");
            }

            foreach (var getter in nullableFormLinkGetters)
            {
                cfile.SB.AppendLine(
                    $"services.AddSingleton<JsonConverter, IFormLinkNullableGetter_Converter<{getter.Name}>>();");
            }

            cfile.SB.AppendLine("return services;");
        }
    }

    cfile.Write("../Spriggan.Converters.Skyrim/Generated.cs");
}
