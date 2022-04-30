using System.Text.Json;

namespace Spriggan.Converters.Base;

public static class ListExtensions
{
    public static void Write<T>(Utf8JsonWriter writer, IReadOnlyList<T>? value, JsonSerializerOptions options)
    {
        writer.WriteStartArray();
        foreach (var i in value!)
        {
            JsonSerializer.Serialize(writer, i, options);
        }
        writer.WriteEndArray();
    }
}