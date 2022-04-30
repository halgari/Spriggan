using System.Text.Json;
using System.Text.Json.Serialization;
using Noggog;

namespace Spriggan.Converters.Base;

public class P3Int16_Converter : JsonConverter<P3Int16>
{
    public override P3Int16 Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, P3Int16 value, JsonSerializerOptions options)
    {
        writer.WriteStartArray();
        writer.WriteNumberValue(value.X);
        writer.WriteNumberValue(value.Y);
        writer.WriteNumberValue(value.Z);
        writer.WriteEndArray();
    }
}