// See https://aka.ms/new-console-template for more information


using System.Data.SqlTypes;
using System.Text.Json;
using Mutagen.Bethesda;
using Mutagen.Bethesda.Plugins;
using Mutagen.Bethesda.Plugins.Records;
using Mutagen.Bethesda.Plugins.RecordTypeMapping;
using Mutagen.Bethesda.Skyrim;
using Noggog;
using Spriggan.ConverterGenerators;
using Spriggan.TupleGen;


var cfile = new CFile(GameRelease.SkyrimSE);

List<string> generatedConverters = new List<string>();

string MakeCommonName(string n)
{
    return n.TrimEnd("Getter")[1..];
}

var formLinkGetters = new HashSet<Type>();
var nullableFormLinkGetters = new HashSet<Type>();
var allTypes = VisitorGenerator.GetAllTypes(typeof(ISkyrimMajorRecord).Assembly).OrderBy(t => t.Main.Name);

var propLimit = 40;

// Writers
foreach (var t in allTypes.Where(a => a.Getter.InheritsFrom(typeof(IMajorRecordGetter))).Where(a => a.Main.Name == "Armor"))
{
    var props = VisitorGenerator.Members(t.Getter).ToArray().OrderBy(t => t.Name);
    var mProps = VisitorGenerator.Members(t.Main)
        .Where(p => p.Name != "FormKey" && p.Name != "TitleString")
        .ToArray().OrderBy(t => t.Name);
    
    var attributes = t.Main.GetCustomAttributes(typeof(AssociatedRecordTypesAttribute), true);


    generatedConverters.Add($"{t.Getter.Name}_Converter");

    cfile.Code($"public class {t.Getter.Name}_Converter : JsonConverter<{t.Getter.Name}>");
    cfile.Code("{");
    cfile.Code($"public override {t.Getter.Name} Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)");
    cfile.Code("{");
    cfile.Code("throw new NotImplementedException();");
    cfile.Code("}");
    cfile.Code($"public override void Write(Utf8JsonWriter writer, {t.Getter.Name} value, JsonSerializerOptions options)");
    cfile.Code("{");
    cfile.Code("writer.WriteStartObject();");

    cfile.EmitTypeHeader(t.Getter, t.Main.Name);
    
    
    foreach (var p in props.Where(p => p.Name != "FormKey" && p.Name != "FormVersion").Take(propLimit))
    {
        cfile.Code("");
        cfile.Code($"// {p.Name}");
        cfile.Code($"writer.WritePropertyName(\"{p.Name}\");");
        cfile.EmitWriter(p.PropertyType, $"value.{p.Name}");

    }
    
    cfile.Code("writer.WriteEndObject();");

    cfile.Code("}");
    cfile.Code("}");
    
    
    generatedConverters.Add($"{t.Main.Name}_Converter");
    cfile.Code($"public class {t.Main.Name}_Converter : JsonConverter<{t.Main.FullName}>");
    cfile.Code("{");
    cfile.Code($"private {t.Getter.Name}_Converter _getterConverter;");
    cfile.Code($"public {t.Main.Name}_Converter()");
    cfile.Code("{");
    cfile.Code($"_getterConverter = new {t.Getter.Name}_Converter();");
    cfile.Code("}");
    
    cfile.Code($"public override void Write(Utf8JsonWriter writer, {t.Main.FullName} value, JsonSerializerOptions options)");
    cfile.Code("{");
    cfile.Code($"_getterConverter.Write(writer, ({t.Getter.Name})value, options);");
    cfile.Code("}");
    
    cfile.Code($"public override {t.Main.FullName} Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)");
    cfile.Code("{");
    cfile.Code("if (reader.TokenType != JsonTokenType.StartObject)");
    cfile.Code("    throw new JsonException();");
    cfile.Code("reader.Read();");
    cfile.EmitCtor("retval", t.Main, true);
    cfile.Code("while (true)");
    cfile.Code("{");
    cfile.Code("reader.Read();");
    cfile.Code("if (reader.TokenType == JsonTokenType.EndObject)");
    cfile.Code("{");
    cfile.Code("reader.Read();");
    cfile.Code("break;");
    cfile.Code("}");
    
    cfile.Code("var prop = reader.GetString();");
    cfile.Code("reader.Read();");
    cfile.Code("switch (prop)");
    cfile.Code("{");

    foreach (var p in mProps.Where(p => p.Name != "FormKey").Take(propLimit))
    {
        cfile.Code($"case \"{p.Name}\":");
        using var _ = cfile.WithIndent();
        cfile.EmitReader(p.PropertyType, $"retval.{p.Name}");
        cfile.Code("break;");
    }
    cfile.Code("default:");
    cfile.Code("    reader.Skip();");
    cfile.Code("    break;");
    
    cfile.Code("}");
    
    cfile.Code("}");
    cfile.Code("return retval;");
    cfile.Code("}");
    cfile.Code("}");
    

}

cfile.Code("public static class GeneratedConvertersExtensions");
cfile.Code("{");
cfile.Code("public static IServiceCollection UseConverters(this IServiceCollection services)");
cfile.Code("{");
foreach (var converter in generatedConverters)
{
    cfile.Code($"services.AddSingleton<JsonConverter, {converter}>();");
}

foreach (var getter in formLinkGetters)
{
    cfile.Code($"services.AddSingleton<JsonConverter, IFormLinkGetter_Converter<{getter.Name}>>();");
}

foreach (var getter in nullableFormLinkGetters)
{
    cfile.Code($"services.AddSingleton<JsonConverter, IFormLinkNullableGetter_Converter<{getter.Name}>>();");
}
cfile.Code("return services;");
cfile.Code("}");
cfile.Code("}");

cfile.Write("../Spriggan.Converters.Skyrim/Generated.cs");
