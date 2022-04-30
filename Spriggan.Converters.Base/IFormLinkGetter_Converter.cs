using System.Text.Json;
using System.Text.Json.Serialization;
using Mutagen.Bethesda.Plugins;
using Mutagen.Bethesda.Plugins.Records;

namespace Spriggan.Converters.Base;

public class IFormLinkGetter_Converter<T> : JsonConverter<IFormLinkGetter<T>>
    where T : class, IMajorRecordGetter
{
    public override IFormLinkGetter<T>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, IFormLinkGetter<T> value, JsonSerializerOptions options)
    {
        writer.WriteStringValue($"{value.FormKey.ModKey.FileName}:{value.FormKey.ID.ToString("x8")}");
    }
}