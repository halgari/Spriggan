// THIS FILE IS AUTOGENERATED DO NOT EDIT BY HAND
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Drawing;
using Mutagen.Bethesda.Skyrim;
using Spriggan.Converters.Base;
using Mutagen.Bethesda;
using Mutagen.Bethesda.Strings;
using Microsoft.Extensions.DependencyInjection;
using Mutagen.Bethesda.Plugins.Records;
using System.Globalization;
using Mutagen.Bethesda.Plugins;
using Noggog;

internal static class IATopicReferenceGetter_Writer
{
    public static void WriteOuter(Utf8JsonWriter writer, Mutagen.Bethesda.Skyrim.IATopicReferenceGetter? value, JsonSerializerOptions options)
    {
        if (value == null)
        {
            writer.WriteStartObject();
            switch (value)
            {
                case Mutagen.Bethesda.Skyrim.ITopicReferenceGetter itm1:
                    writer.WriteString("$type", "TopicReference");
                    TopicReference_Writer.WriteInner(writer, itm1, options);
                    break;
                case Mutagen.Bethesda.Skyrim.ITopicReferenceSubtypeGetter itm2:
                    writer.WriteString("$type", "TopicReferenceSubtype");
                    TopicReferenceSubtype_Writer.WriteInner(writer, itm2, options);
                    break;
            }
            writer.WriteEndObject();
        }
        else
        {
            writer.WriteNullValue();
        }
    }
}
