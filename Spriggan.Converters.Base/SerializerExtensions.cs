using System.Text.Json;
using Mutagen.Bethesda.Plugins;
using Mutagen.Bethesda.Plugins.Records;

namespace Spriggan.Converters.Base;

public static class SerializerExtensions
{
    public static void WriteEnum<T>(this Utf8JsonWriter writer, T val)
        where T : Enum
    {
        writer.WriteStringValue(val.ToString());
    }
    
    public static void WriteFlags<T>(this Utf8JsonWriter writer, T val)
        where T : Enum
    {
        var vals = val.ToString();
        if (vals == "0")
            writer.WriteNullValue();
        else 
            writer.WriteStringValue(vals);
    }

    public static FormKey ReadFormKeyHeader(ref Utf8JsonReader reader, JsonSerializerOptions options)
    {
        var cReader = reader;
        if (cReader.GetString() != "FormKey")
            throw new Exception("Major records should start with FormKeys");
        cReader.Read();
        var key = cReader.GetString();
        cReader.Read();
        
        var split = key.Split(":");
        var mt = ModType.Master;
        if (split[0].EndsWith(".esm"))
            mt = ModType.Master;
        else if (split[0].EndsWith(".esp"))
            mt = ModType.Plugin;
        else if (split[0].EndsWith(".esl"))
            mt = ModType.LightMaster;

        return new FormKey(new ModKey(split[0], mt), uint.Parse(split[3]));
    }


    public static FormKey ReadFormKeyValue(ref Utf8JsonReader reader, JsonSerializerOptions options)
    {
        var val = reader.GetString();
        return FormKey.Factory(val);
    }

    public static void WriteFormKeyHeader(this Utf8JsonWriter writer, IMajorRecordGetter rec, JsonSerializerOptions options)
    {
        writer.WriteString("FormKey",
            $"{rec.FormKey.ModKey.Name}:{rec.FormKey.ModKey.Type}:{rec.FormVersion}:{rec.FormKey.ID.ToString("x8")}");

    }

    public static T ReadFlags<T>(ref Utf8JsonReader reader, JsonSerializerOptions options)
        where T : struct, Enum
    {
        if (reader.TokenType == JsonTokenType.Null)
        {
            return Enum.Parse<T>("0");
        }
        return Enum.Parse<T>(reader.GetString()!);
    }

    public static T ReadEnum<T>(ref Utf8JsonReader reader, JsonSerializerOptions options)
        where T : struct, Enum
    {
        return Enum.Parse<T>(reader.GetString()!);
    }
}