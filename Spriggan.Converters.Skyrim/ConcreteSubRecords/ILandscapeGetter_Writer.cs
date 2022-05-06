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

internal static class ILandscapeGetter_Writer
{
    public static void WriteInner(Utf8JsonWriter writer, Mutagen.Bethesda.Skyrim.ILandscapeGetter? value, JsonSerializerOptions options)
    {
        if (value != null)
        {
            writer.WriteStartObject();
            
            // Flags
            writer.WritePropertyName("Flags");
            if (value.Flags == null)
                writer.WriteNullValue();
            else
            {
                writer.WriteFlags(value.Flags.Value);
            }
            
            // VertexNormals
            writer.WritePropertyName("VertexNormals");
            writer.ReadOnlyArray2dWriter(value.VertexNormals, itm =>
            {
                Noggog.P3UInt8 itm1 = default;
                writer.WriteP3UInt8(itm1, options);
            }
            );
            
            // VertexHeightMap
            writer.WritePropertyName("VertexHeightMap");
            if (value.VertexHeightMap != null)
            {
                writer.WriteStartObject();
                
                // Offset
                writer.WritePropertyName("Offset");
                writer.WriteNumberValue(value.VertexHeightMap.Offset);
                
                // HeightMap
                writer.WritePropertyName("HeightMap");
                writer.ReadOnlyArray2dWriter(value.VertexHeightMap.HeightMap, itm =>
                {
                    Byte itm2 = default;
                    writer.WriteNumberValue(itm2);
                }
                );
                
                // Unknown
                writer.WritePropertyName("Unknown");
                writer.WriteP3UInt8(value.VertexHeightMap.Unknown, options);
                writer.WriteEndObject();
            }
            else
            {
                writer.WriteNullValue();
            }
            
            // VertexColors
            writer.WritePropertyName("VertexColors");
            writer.ReadOnlyArray2dWriter(value.VertexColors, itm =>
            {
                Noggog.P3UInt8 itm3 = default;
                writer.WriteP3UInt8(itm3, options);
            }
            );
            
            // Layers
            writer.WritePropertyName("Layers");
            if (value.Layers != null)
            {
                writer.WriteStartArray();
                foreach(var itm4 in value.Layers)
                {
                    IBaseLayerGetter_Writer.WriteOuter(writer, itm4, options);
                }
                writer.WriteEndArray();
            }
            else
            {
                writer.WriteNullValue();
            }
            
            // Textures
            writer.WritePropertyName("Textures");
            if (value.Textures != null)
            {
                writer.WriteStartArray();
                foreach(var itm5 in value.Textures)
                {
                    writer.WriteStringValue(itm5.FormKey.ToString());
                }
                writer.WriteEndArray();
            }
            else
            {
                writer.WriteNullValue();
            }
            
            // FormVersion
            writer.WritePropertyName("FormVersion");
            writer.WriteNumberValue((uint)value.FormVersion);
            
            // Version2
            writer.WritePropertyName("Version2");
            writer.WriteNumberValue((uint)value.Version2);
            
            // IsCompressed
            writer.WritePropertyName("IsCompressed");
            writer.WriteBooleanValue(value.IsCompressed);
            
            // IsDeleted
            writer.WritePropertyName("IsDeleted");
            writer.WriteBooleanValue(value.IsDeleted);
            
            // MajorRecordFlagsRaw
            writer.WritePropertyName("MajorRecordFlagsRaw");
            writer.WriteNumberValue(value.MajorRecordFlagsRaw);
            
            // VersionControl
            writer.WritePropertyName("VersionControl");
            writer.WriteNumberValue(value.VersionControl);
            
            // EditorID
            writer.WritePropertyName("EditorID");
            writer.WriteStringValue(value.EditorID);
            writer.WriteEndObject();
        }
        else
        {
            writer.WriteNullValue();
        }
    }
}