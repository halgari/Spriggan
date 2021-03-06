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

internal static class ScriptObjectProperty_Reader
{
    public static Mutagen.Bethesda.Skyrim.ScriptObjectProperty ReadInner(ref Utf8JsonReader reader, JsonSerializerOptions options)
    {
        Mutagen.Bethesda.Skyrim.ScriptObjectProperty cls = new Mutagen.Bethesda.Skyrim.ScriptObjectProperty();
        while (true)
        {
            reader.Read();
            if (reader.TokenType == JsonTokenType.EndObject)
                break;
            var prop1 = reader.GetString();
            reader.Read();
            switch(prop1)
            {
                case "Object":
                    cls.Object.SetTo(SerializerExtensions.ReadFormKeyValue(ref reader, options));
                    break;
                case "Alias":
                    cls.Alias = reader.GetInt16();
                    break;
                case "Unused":
                    cls.Unused = reader.GetUInt16();
                    break;
            }
        }
        return cls;
    }
}
