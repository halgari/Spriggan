using System.Text.Json;
using System.Text.Json.Serialization;
using Mutagen.Bethesda.Strings;

namespace Spriggan.Converters.Base;

public class ITranslatedStringGetter_Converter : JsonConverter<ITranslatedStringGetter>
{
    public override ITranslatedStringGetter? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, ITranslatedStringGetter value, JsonSerializerOptions options)
    {
        if (value == null || value.NumLanguages == 0 || !value.Any())
        {
            writer.WriteNullValue();
            return;
        }
        writer.WriteStartObject();
        foreach (var par in value)
        {
            writer.WriteString(par.Key.ToString(), par.Value);
        }
        writer.WriteEndObject();
        
        TranslatedString
    }
}