using System.Text.Json;
using Mutagen.Bethesda.Plugins;
using Mutagen.Bethesda.Plugins.Records;
using Noggog;

namespace Spriggan.Converters.Base;


public class ConverterHelpers
{
    public static void ReadFormLink<T>(IFormLink<T> link, ref Utf8JsonReader reader)
        where T : class, IMajorRecordGetter
    {
        var value = reader.GetString();
        var split = value.Split(":");
    }
    public static void ReadFormLinkNullable<T>(IFormLinkNullable<T> link, ref Utf8JsonReader reader)
        where T : class, IMajorRecordGetter
    {
        var value = reader.GetString();
        var split = value.Split(":");
    }

    public static void ReadFormLinkList<T>(ExtendedList<IFormLinkGetter<T>> list, ref Utf8JsonReader reader)
        where T : class, IMajorRecordGetter
    {
        if (reader.TokenType == JsonTokenType.StartArray)
        {
            throw new JsonException();
        }

        while (true)
        {
            reader.Read();
            if (reader.TokenType == JsonTokenType.EndArray)
            {
                reader.Read();
                break;
            }

            var val = reader.GetString();
            //list.Add(val);
        }
    }

    public static void ReadExtendedList<T>(ExtendedList<T> list, ref Utf8JsonReader reader, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.StartArray)
        {
            throw new JsonException();
        }

        while (true)
        {
            reader.Read();
            if (reader.TokenType == JsonTokenType.EndArray)
            {
                reader.Read();
                break;
            }

            var val = JsonSerializer.Deserialize<T>(ref reader, options)!;
            list.Add(val);
        }
    }
    
    public static void ReadExtendedList<TI, TC>(ExtendedList<TI> list, ref Utf8JsonReader reader, JsonSerializerOptions options)
    where TC : TI
    {
        if (reader.TokenType == JsonTokenType.StartArray)
        {
            throw new JsonException();
        }

        while (true)
        {
            reader.Read();
            if (reader.TokenType == JsonTokenType.EndArray)
            {
                reader.Read();
                break;
            }

            var val = JsonSerializer.Deserialize<TC>(ref reader, options)!;
            list.Add(val);
        }
    }
}