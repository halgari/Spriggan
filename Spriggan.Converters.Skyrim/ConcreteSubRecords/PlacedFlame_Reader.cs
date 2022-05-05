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

internal static class PlacedFlame_Reader
{
    public static Mutagen.Bethesda.Skyrim.PlacedFlame ReadInner(ref Utf8JsonReader reader, FormKey formKey, JsonSerializerOptions options)
    {
        var cls = new Mutagen.Bethesda.Skyrim.PlacedFlame(formKey, SkyrimRelease.SkyrimSE);
        while (true)
        {
            reader.Read();
            if (reader.TokenType == JsonTokenType.EndObject)
                break;
            var prop1 = reader.GetString();
            reader.Read();
            switch(prop1)
            {
                case "Projectile":
                    cls.Projectile.SetTo(SerializerExtensions.ReadFormKeyValue(ref reader, options));
                    break;
            }
        }
        return cls;
    }
}
