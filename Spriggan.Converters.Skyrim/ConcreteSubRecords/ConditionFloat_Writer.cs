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

internal static class ConditionFloat_Writer
{
    public static void WriteInner(Utf8JsonWriter writer, Mutagen.Bethesda.Skyrim.IConditionFloatGetter? value, JsonSerializerOptions options)
    {
        if (value != null)
        {
            
            // ComparisonValue
            writer.WritePropertyName("ComparisonValue");
            writer.WriteNumberValue(value.ComparisonValue);
            
            // Data
            writer.WritePropertyName("Data");
            IConditionDataGetter_Writer.WriteOuter(writer, value.Data, options);
            
            // CompareOperator
            writer.WritePropertyName("CompareOperator");
            writer.WriteEnum(value.CompareOperator);
            
            // Flags
            writer.WritePropertyName("Flags");
            writer.WriteFlags(value.Flags);
            
            // Unknown1
            writer.WritePropertyName("Unknown1");
            writer.WriteBase64StringValue(value.Unknown1);
        }
        else
        {
            writer.WriteNullValue();
        }
    }
}
