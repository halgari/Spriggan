using System.Globalization;
using System.Text.Json;
using Mutagen.Bethesda.Plugins;
using Mutagen.Bethesda.Plugins.Records;
using Mutagen.Bethesda.Strings;
using Noggog;

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

        return new FormKey(new ModKey(split[0], mt), uint.Parse(split[3], NumberStyles.HexNumber));
    }

    /// <summary>
    /// Gets the value for the given property as a string, will not advance the reader, so use this
    /// to parse the type of an object before parsing the rest of the object
    /// </summary>
    /// <param name="reader"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    public static string ReadTag(ref Utf8JsonReader reader, string property, JsonSerializerOptions options)
    {
        var cReader = reader;
        while (true)
        {
            cReader.Read();
            if (cReader.TokenType == JsonTokenType.EndObject)
            {
                throw new JsonException($"End of object before property {property} was found");
            }
            var prop = cReader.GetString();
            if (prop == property)
            {
                cReader.Read();
                return cReader.GetString()!;
            }
            else
            {
                cReader.Read();
            }
        }

    }


    public static FormKey ReadFormKeyValue(ref Utf8JsonReader reader, JsonSerializerOptions options)
    {
        var val = reader.GetString();
        return val == null ? FormKey.Null : FormKey.Factory(val);
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

    public static void WriteTranslatedString(this Utf8JsonWriter writer, ITranslatedStringGetter? ts, JsonSerializerOptions options)
    {
        if (ts == null || ts.NumLanguages == 0 || !ts.Any())
        {
            writer.WriteNullValue();
            return;
        }
        
        writer.WriteStartObject();
        foreach (var (l, s) in ts)
        {
            writer.WriteString(l.ToString(), s);
        }
        writer.WriteEndObject();
    }
    
    public static void ReadTranslatedString(ref Utf8JsonReader reader, TranslatedString ts, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Null)
            return;

        while (true)
        {
            reader.Read();
            if (reader.TokenType == JsonTokenType.EndObject)
                return;

            var lang = Enum.Parse<Language>(reader.GetString()!);
            reader.Read();
            var s = reader.GetString();
            ts.Set(lang, s);
        }
    }

    public static void WriteP3Int16(this Utf8JsonWriter writer, P3Int16 value, JsonSerializerOptions options)
    {
        writer.WriteStartArray();
        writer.WriteNumberValue(value.X);
        writer.WriteNumberValue(value.Y);
        writer.WriteNumberValue(value.Z);
        writer.WriteEndArray();
    }

    public static P3Int16 ReadP3Int16(ref Utf8JsonReader reader, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartArray)
            throw new JsonException();

        var ret = new P3Int16();
        reader.Read();
        ret.X = reader.GetInt16();
        reader.Read();
        ret.Y = reader.GetInt16();
        reader.Read();
        ret.Z = reader.GetInt16();
        reader.Read();
        
        if (reader.TokenType != JsonTokenType.EndArray)
            throw new JsonException();
        return ret;

    }
    
    public static void WriteP3Float(this Utf8JsonWriter writer, P3Float value, JsonSerializerOptions options)
    {
        writer.WriteStartArray();
        writer.WriteNumberValue(value.X);
        writer.WriteNumberValue(value.Y);
        writer.WriteNumberValue(value.Z);
        writer.WriteEndArray();
    }

    public static P3Float ReadP3Float(ref Utf8JsonReader reader, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartArray)
            throw new JsonException();

        var ret = new P3Float();
        reader.Read();
        ret.X = reader.GetSingle();
        reader.Read();
        ret.Y = reader.GetSingle();
        reader.Read();
        ret.Z = reader.GetSingle();
        reader.Read();
        
        if (reader.TokenType != JsonTokenType.EndArray)
            throw new JsonException();
        return ret;

    }
    
    public static void WriteP2Int(this Utf8JsonWriter writer, P2Int value, JsonSerializerOptions options)
    {
        writer.WriteStartArray();
        writer.WriteNumberValue(value.X);
        writer.WriteNumberValue(value.Y);
        writer.WriteEndArray();
    }

    public static P2Int ReadP2Int(ref Utf8JsonReader reader, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartArray)
            throw new JsonException();

        var ret = new P2Int();
        reader.Read();
        ret.X = reader.GetInt32();
        reader.Read();
        ret.Y = reader.GetInt32();
        reader.Read();
        
        if (reader.TokenType != JsonTokenType.EndArray)
            throw new JsonException();
        return ret;

    }
}