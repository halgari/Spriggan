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

internal static class WorldspaceNavmeshParent_Writer
{
    public static void WriteInner(Utf8JsonWriter writer, Mutagen.Bethesda.Skyrim.IWorldspaceNavmeshParentGetter? value, JsonSerializerOptions options)
    {
        if (value != null)
        {
            
            // Parent
            writer.WritePropertyName("Parent");
            writer.WriteStringValue(value.Parent.FormKey.ToString());
            
            // Coordinates
            writer.WritePropertyName("Coordinates");
            writer.WriteP2Int16(value.Coordinates, options);
        }
        else
        {
            writer.WriteNullValue();
        }
    }
}
