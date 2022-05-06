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

internal static class AlphaLayer_Writer
{
    public static void WriteInner(Utf8JsonWriter writer, Mutagen.Bethesda.Skyrim.IAlphaLayerGetter? value, JsonSerializerOptions options)
    {
        if (value != null)
        {
            
            // AlphaLayerData
            writer.WritePropertyName("AlphaLayerData");
            if (value.AlphaLayerData == null)
                writer.WriteNullValue();
            else
            {
                writer.WriteBase64StringValue(value.AlphaLayerData.Value);
            }
            
            // Header
            writer.WritePropertyName("Header");
            if (value.Header != null)
            {
                writer.WriteStartObject();
                
                // Texture
                writer.WritePropertyName("Texture");
                writer.WriteStringValue(value.Header.Texture.FormKey.ToString());
                
                // Quadrant
                writer.WritePropertyName("Quadrant");
                writer.WriteEnum(value.Header.Quadrant);
                
                // Unused
                writer.WritePropertyName("Unused");
                writer.WriteNumberValue(value.Header.Unused);
                
                // LayerNumber
                writer.WritePropertyName("LayerNumber");
                writer.WriteNumberValue((uint)value.Header.LayerNumber);
                writer.WriteEndObject();
            }
            else
            {
                writer.WriteNullValue();
            }
        }
        else
        {
            writer.WriteNullValue();
        }
    }
}
