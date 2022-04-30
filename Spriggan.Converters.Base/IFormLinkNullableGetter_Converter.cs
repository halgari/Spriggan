namespace Spriggan.Converters.Base;

using System.Text.Json;
using System.Text.Json.Serialization;
using Mutagen.Bethesda.Plugins;
using Mutagen.Bethesda.Plugins.Records;

public class IFormLinkNullableGetter_Converter<T> : JsonConverter<IFormLinkNullableGetter<T>>
    where T : class, IMajorRecordGetter
{
    public override IFormLinkNullableGetter<T>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, IFormLinkNullableGetter<T> value, JsonSerializerOptions options)
    {
        if (value.IsNull)
            writer.WriteNullValue();
        else 
            writer.WriteStringValue($"{value.FormKey.ModKey.FileName}:{value.FormKey.ID.ToString("x8")}");
    }
}