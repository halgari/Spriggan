// See https://aka.ms/new-console-template for more information

using Mutagen.Bethesda;
using Mutagen.Bethesda.Plugins.Records;
using Mutagen.Bethesda.Plugins.RecordTypeMapping;
using Mutagen.Bethesda.Skyrim;
using Noggog;
using Noggog.StructuredStrings.CSharp;
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

var majorTypes = allTypes.Where(a => a.Getter.InheritsFrom(typeof(IMajorRecordGetter))).OrderBy(t => t.Main.Name)
    .Take(17);
// Writers
foreach (var t in majorTypes)
{
    Console.WriteLine($"Emitting {t.Main.Name}.cs");
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
        cfile.SB.AppendLine("public override bool CanConvert(Type t)");
        using (cfile.SB.CurlyBrace())
        {
            cfile.SB.AppendLine($"return t.InheritsFrom(typeof({t.Getter.FullName})) && !t.InheritsFrom(typeof({t.Main.FullName}));");
        }
        
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
    using (var c = cfile.SB.Class($"{t.Main.Name}_Converter"))
    {
        c.BaseClass = $"JsonConverter<{t.Main.FullName}>";
    }
    using (cfile.SB.CurlyBrace())
    {
        cfile.SB.AppendLine($"private {t.Getter.Name}_Converter _getterConverter;");
        cfile.SB.AppendLine($"public {t.Main.Name}_Converter()");
        using (cfile.SB.CurlyBrace())
        {
            cfile.SB.AppendLine($"_getterConverter = new {t.Getter.Name}_Converter();");
        }
        
        cfile.SB.AppendLine("public override bool CanConvert(Type t)");
        using (cfile.SB.CurlyBrace())
        {
            cfile.SB.AppendLine($"return t.InheritsFrom(typeof({t.Main.FullName}));");
        }

        cfile.SB.AppendLine(
            $"public override void Write(Utf8JsonWriter writer, {t.Main.FullName} value, JsonSerializerOptions options)");
        using (cfile.SB.CurlyBrace())
        {
            cfile.SB.AppendLine($"_getterConverter.Write(writer, ({t.Getter.Name})value, options);");
        }

        using (var f = cfile.SB.Function($"public override {t.Main.FullName} Read"))
        {
            f.Add("ref Utf8JsonReader reader");
            f.Add("Type typeToConvert");
            f.Add("JsonSerializerOptions options");
        }
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
                        cfile.EmitReader(p.PropertyType, $"retval.{p.Name}", new Context(CFile.IsSettable(p), false, false));
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

// Use a for loop as abstract types could have abstract types
for (var i = 0; i < CFile.AbstractTypes.Count; i++)
{
    var def = CFile.AbstractTypes[i];
    var cfile = new CFile(GameRelease.SkyrimSE);
    Console.WriteLine($"Emitting {def.Item1.Name} - {def.Item2}");
    if (def.Item2 == CFile.AbstractMethod.AbstractWriter)
    {
        cfile.EmitAbstractClassWriter(def.Item1);
        cfile.Write($"../Spriggan.Converters.Skyrim/AbstractSubRecords/{def.Item1.Name}_Writer.cs");
    }
    else if (def.Item2 == CFile.AbstractMethod.ConcreteWriter)
    {
        cfile.EmitConcreteClassWriter(def.Item1);
        cfile.Write($"../Spriggan.Converters.Skyrim/ConcreteSubRecords/{def.Item1.Name}_Writer.cs");
    }
    else if (def.Item2 == CFile.AbstractMethod.AbstractReader)
    {
        cfile.EmitAbstractClassReader(def.Item1);
        cfile.Write($"../Spriggan.Converters.Skyrim/AbstractSubRecords/{def.Item1.Name}_Reader.cs");
    }
    else if (def.Item2 == CFile.AbstractMethod.ConcreteReader)
    {
        cfile.EmitConcreteClassReader(def.Item1);
        cfile.Write($"../Spriggan.Converters.Skyrim/ConcreteSubRecords/{def.Item1.Name}_Reader.cs");
    }
}

{
    var cfile = new CFile(GameRelease.SkyrimSE);
    using (var c = cfile.SB.Class("GeneratedConvertersExtensions"))
    {
        c.Static = true;
    }
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
    
        cfile.SB.AppendLine("public static (Type Main, Type Getter)[] SupportedRecords = new[]");
        using (cfile.SB.CurlyBrace(appendSemiColon:true))
        {
            foreach (var type in majorTypes)
            {
                cfile.SB.AppendLine($"(typeof({type.Main.FullName}), typeof({type.Getter.FullName})),");
            }
        }
    }

    cfile.Write("../Spriggan.Converters.Skyrim/Generated.cs");
}
