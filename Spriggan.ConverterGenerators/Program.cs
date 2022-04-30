// See https://aka.ms/new-console-template for more information


using System.Data.SqlTypes;
using System.Text.Json;
using Mutagen.Bethesda.Plugins;
using Mutagen.Bethesda.Plugins.Records;
using Mutagen.Bethesda.Plugins.RecordTypeMapping;
using Mutagen.Bethesda.Skyrim;
using Noggog;
using Spriggan.ConverterGenerators;
using Spriggan.TupleGen;


var cfile = new CFile();

List<string> generatedConverters = new List<string>();

string MakeCommonName(string n)
{
    return n.TrimEnd("Getter")[1..];
}

var formLinkGetters = new HashSet<Type>();
var nullableFormLinkGetters = new HashSet<Type>();
var allTypes = VisitorGenerator.GetAllTypes(typeof(ISkyrimMajorRecord).Assembly).OrderBy(t => t.Main.Name);

foreach (var t in allTypes)
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
    
    cfile.Code("writer.WriteString(\"$type\", \"" + t.Main.Name + "\");");
    
    foreach (var p in props)
    {
        if (p.PropertyType.InheritsFrom(typeof(IReadOnlyList<>)))
        {
            var itemType = p.PropertyType.GetGenericArguments()[0];
            if (itemType.InheritsFrom(typeof(IFormLinkGetter<>)))
            {
                formLinkGetters.Add(itemType.GetGenericArguments()[0]);
            }
            
            cfile.Code($"if (value.{p.Name} != default)");
            cfile.Code("{");
            cfile.Code("writer.WritePropertyName(\"" + p.Name + "\");");
            cfile.Code("writer.WriteStartArray();");
            cfile.Code($"foreach (var itm in value.{p.Name})");
            cfile.Code("{");
            cfile.Code($"JsonSerializer.Serialize(writer, itm, options);");
            cfile.Code("}");
            cfile.Code("writer.WriteEndArray();");
            cfile.Code("}");
            cfile.Code("else");
            cfile.Code("{");
            cfile.Code("writer.WriteNull(\"" + p.Name + "\");");
            cfile.Code("}");
        }
        else if (p.PropertyType.InheritsFrom(typeof(INullable)))
        {
            cfile.Code($"if (value.{p.Name} != default)");
            cfile.Code("{");
            cfile.Code("writer.WritePropertyName(\"" + p.Name + "\");");
            cfile.Code($"JsonSerializer.Serialize(writer, value.{p.Name}, options);");            
            cfile.Code("}");
            cfile.Code("else");
            cfile.Code("{");
            cfile.Code("writer.WriteNull(\"" + p.Name + "\");");
            cfile.Code("}");
            
        }
        else if (p.PropertyType.InheritsFrom(typeof(IFormLinkNullableGetter<>)))
        {
            nullableFormLinkGetters.Add(p.PropertyType.GetGenericArguments()[0]);
            cfile.Code("writer.WritePropertyName(\"" + p.Name + "\");");
            cfile.Code($"JsonSerializer.Serialize(writer, value.{p.Name}, options);");
        }
        else
        {
            cfile.Code("writer.WritePropertyName(\"" + p.Name + "\");");
            cfile.Code($"JsonSerializer.Serialize(writer, value.{p.Name}, options);");
        }
    }
    cfile.Code("writer.WriteEndObject();");

    cfile.Code("}");
    cfile.Code("}");
    
    
    cfile.Code($"public class {t.Main.Name}_Converter : JsonConverter<{t.Main.FullName}>");
    cfile.Code("{");
    cfile.Code($"private {t.Getter.Name}_Converter _getterConverter;");
    cfile.Code($"public {t.Main.Name}_Converter({t.Getter.Name}_Converter getterConverter)");
    cfile.Code("{");
    cfile.Code("_getterConverter = getterConverter;");
    cfile.Code("}");
    
    cfile.Code($"public override void Write(Utf8JsonWriter writer, {t.Main.FullName} value, JsonSerializerOptions options)");
    cfile.Code("{");
    cfile.Code($"_getterConverter.Write(writer, ({t.Getter.Name})value, options);");
    cfile.Code("}");
    
    cfile.Code($"public override {t.Main.FullName} Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)");
    cfile.Code("{");
    cfile.Code("if (reader.TokenType != JsonTokenType.StartObject)");
    cfile.Code("    throw new JsonException();");
    cfile.Code($"var retval = new {t.Main.FullName}();");
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

    foreach (var p in mProps)
    {
        cfile.Code($"case \"{p.Name}\":");
        var ptype = p.PropertyType;
        
        if (ptype.InheritsFrom(typeof(IFormLink<>)))
        {
            var gname = ptype.GetGenericArguments()[0];
            cfile.Code($"    ConverterHelpers.ReadFormLink<{gname.Name}>(retval.{p.Name}, ref reader);");
            cfile.Code("    break;");
        }
        else if (ptype.InheritsFrom(typeof(IFormLinkNullable<>)))
        {
            var gname = ptype.GetGenericArguments()[0];
            cfile.Code($"    ConverterHelpers.ReadFormLinkNullable<{gname.Name}>(retval.{p.Name}, ref reader);");
            cfile.Code("    break;");
        }

        else if (ptype.InheritsFrom(typeof(ExtendedList<>)) && !ptype.GetGenericArguments()[0].InheritsFrom(typeof(IFormLinkGetter<>)))
        {
            var gname = ptype.GetGenericArguments()[0];
            if (gname.IsPrimitive)
            {
                cfile.Code(
                    $"    ConverterHelpers.ReadExtendedList<{gname.Name}>(retval.{p.Name}, ref reader, options);");
                cfile.Code("    break;");
            }
            else if (gname.Name.EndsWith("Getter"))
            {

                var elist = allTypes.FirstOrDefault(l => l.Main == gname || l.Getter == gname);


                cfile.Code(
                    $"    ConverterHelpers.ReadExtendedList<{elist.Getter}, {elist.Main}>(retval.{p.Name}, ref reader, options);");
                cfile.Code("    break;");
            }
            else
            {
                cfile.Code(
                    $"    ConverterHelpers.ReadExtendedList<{gname.Name}>(retval.{p.Name}, ref reader, options);");
                cfile.Code("    break;");
            }
        }
        else if (ptype.InheritsFrom(typeof(ExtendedList<>)) &&
                 ptype.GetGenericArguments()[0].InheritsFrom(typeof(IFormLinkGetter<>)))
        {
            var gtype = ptype.GetGenericArguments()[0].GetGenericArguments()[0];
            cfile.Code(
                $"    ConverterHelpers.ReadFormLinkList<{gtype.Name}>(retval.{p.Name}, ref reader);");
            cfile.Code("    break;");
        }
        else
        {
            var tname = p.PropertyType.FullName!.Replace("+", ".");

            if (ptype.InheritsFrom(typeof(Nullable<>)))
            {
                tname = p.PropertyType.GetGenericArguments()[0].Name + "?";
            }
            
            if (tname.Contains('`'))
            {
                cfile.Code("    break;");
                continue;
            }
            
            cfile.Code(
                $"    retval.{p.Name} = JsonSerializer.Deserialize<{tname}>(ref reader, options);");
            cfile.Code($"    break;");
        }
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
