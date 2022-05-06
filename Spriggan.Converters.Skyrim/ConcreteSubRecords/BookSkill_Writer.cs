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

internal static class BookSkill_Writer
{
    public static void WriteInner(Utf8JsonWriter writer, Mutagen.Bethesda.Skyrim.IBookSkillGetter? value, JsonSerializerOptions options)
    {
        if (value != null)
        {
            
            // Skill
            writer.WritePropertyName("Skill");
            if (value.Skill == null)
                writer.WriteNullValue();
            else
            {
                writer.WriteEnum(value.Skill.Value);
            }
        }
        else
        {
            writer.WriteNullValue();
        }
    }
}
