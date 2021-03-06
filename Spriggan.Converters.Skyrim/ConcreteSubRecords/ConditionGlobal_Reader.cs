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

internal static class ConditionGlobal_Reader
{
    public static Mutagen.Bethesda.Skyrim.ConditionGlobal ReadInner(ref Utf8JsonReader reader, JsonSerializerOptions options)
    {
        Mutagen.Bethesda.Skyrim.ConditionGlobal cls = new Mutagen.Bethesda.Skyrim.ConditionGlobal();
        while (true)
        {
            reader.Read();
            if (reader.TokenType == JsonTokenType.EndObject)
                break;
            var prop1 = reader.GetString();
            reader.Read();
            switch(prop1)
            {
                case "Data":
                    cls.Data = ConditionData_Reader.ReadOuter(ref reader, options);
                    break;
                case "ComparisonValue":
                    cls.ComparisonValue.SetTo(SerializerExtensions.ReadFormKeyValue(ref reader, options));
                    break;
            }
        }
        return cls;
    }
}
