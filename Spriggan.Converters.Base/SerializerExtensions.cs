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


        return FormKey.Factory($"{split[2]}:{split[0]}");
    }

    public static string MajorRecordInternalFormKeyString(IMajorRecordInternal r)
    {
        return $"{r.FormKey}:{r.Type.Name}";
    }

    public static (FormKey FormKey, string Type) MajorRecordInternalFormKeyParse(string r)
    {
        var s = r.Split(":");
        return (FormKey.Factory($"{s[2]}:{s[0]}"), s[3]);
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
            //cReader.Read();
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
            $"{rec.FormKey.ModKey.FileName}:{rec.FormVersion}:{rec.FormKey.ID.ToString("x6")}:{rec.Type.Name}");

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
    
    public static void WriteP3UInt8(this Utf8JsonWriter writer, P3UInt8 value, JsonSerializerOptions options)
    {
        writer.WriteStartArray();
        writer.WriteNumberValue(value.X);
        writer.WriteNumberValue(value.Y);
        writer.WriteNumberValue(value.Z);
        writer.WriteEndArray();
    }

    public static P3UInt8 ReadP3UInt8(ref Utf8JsonReader reader, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartArray)
            throw new JsonException();

        var ret = new P3UInt8();
        reader.Read();
        ret.X = reader.GetByte();
        reader.Read();
        ret.Y = reader.GetByte();
        reader.Read();
        ret.Z = reader.GetByte();
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
    
    public static void WriteP2Int16(this Utf8JsonWriter writer, P2Int16 value, JsonSerializerOptions options)
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
    
    public static P2Int16 ReadP2Int16(ref Utf8JsonReader reader, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartArray)
            throw new JsonException();

        var ret = new P2Int16();
        reader.Read();
        ret.X = reader.GetInt16();
        reader.Read();
        ret.Y = reader.GetInt16();
        reader.Read();
        
        if (reader.TokenType != JsonTokenType.EndArray)
            throw new JsonException();
        return ret;

    }

    public static void ReadOnlyArray2dWriter<T>(this Utf8JsonWriter writer, IReadOnlyArray2d<T> itms, Action<T> fn)
    {
        writer.WriteStartObject();
        for (var y = 0; y < itms.Height; y++)
        {
            for (var x = 0; x < itms.Width; x++)
            {
                writer.WritePropertyName($"{x}:{y}");
                fn(itms[x, y]);
            }
        }
        writer.WriteEndObject();
    }

    public delegate T ReaderAction<T>(ref Utf8JsonReader item);

    public static Array2d<T> Array2dReader<T>(ref Utf8JsonReader reader, ReaderAction<T> fn)
    {
        var storage = new Dictionary<(int, int), T>();
        if (reader.TokenType != JsonTokenType.StartArray)
            throw new JsonException();

        while (true)
        {
            if (reader.TokenType == JsonTokenType.EndArray)
                break;
            reader.Read();
            var idx = reader.GetString()!.Split(":");
            reader.Read();
            var value = fn.Invoke(ref reader);
            storage.Add((int.Parse(idx[0]), int.Parse(idx[1])), value);
        }

        var ret = new Array2d<T>(storage.Max(x => x.Key.Item1), storage.Max(x => x.Key.Item2));
        foreach (var itm in storage) 
            ret[itm.Key.Item1, itm.Key.Item2] = itm.Value;
        return ret;
    }
}