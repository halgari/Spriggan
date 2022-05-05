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

internal static class Condition_Reader
{
    public static Mutagen.Bethesda.Skyrim.Condition ReadOuter(ref Utf8JsonReader reader, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.Null)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
                throw new JsonException();
            var itm1 = SerializerExtensions.ReadTag(ref reader, $"$type", options);
            switch(itm1)
            {
                case "ConditionFloat":
                    return ConditionFloat_Reader.ReadInner(ref reader, options);
                case "ConditionGlobal":
                    return ConditionGlobal_Reader.ReadInner(ref reader, options);
                default:
                    reader.Skip();
                    break;
            }
        }
        else
        {
            reader.Skip();
        }
        return default;
    }
}
