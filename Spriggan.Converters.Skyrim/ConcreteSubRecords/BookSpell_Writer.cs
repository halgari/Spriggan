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

internal static class BookSpell_Writer
{
    public static void WriteInner(Utf8JsonWriter writer, Mutagen.Bethesda.Skyrim.IBookSpellGetter? value, JsonSerializerOptions options)
    {
        if (value != null)
        {
            
            // Spell
            writer.WritePropertyName("Spell");
            writer.WriteStringValue(value.Spell.FormKey.ToString());
        }
        else
        {
            writer.WriteNullValue();
        }
    }
}
