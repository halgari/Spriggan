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

internal static class FunctionConditionData_Reader
{
    public static Mutagen.Bethesda.Skyrim.FunctionConditionData ReadInner(ref Utf8JsonReader reader, JsonSerializerOptions options)
    {
        Mutagen.Bethesda.Skyrim.FunctionConditionData cls = new Mutagen.Bethesda.Skyrim.FunctionConditionData();
        while (true)
        {
            reader.Read();
            if (reader.TokenType == JsonTokenType.EndObject)
                break;
            var prop1 = reader.GetString();
            reader.Read();
            switch(prop1)
            {
                case "Function":
                    cls.Function = SerializerExtensions.ReadEnum<Mutagen.Bethesda.Skyrim.Condition.Function>(ref reader, options);
                    break;
                case "Unknown2":
                    cls.Unknown2 = reader.GetUInt16();
                    break;
                case "ParameterOneRecord":
                    cls.ParameterOneRecord.SetTo(SerializerExtensions.ReadFormKeyValue(ref reader, options));
                    break;
                case "ParameterOneNumber":
                    cls.ParameterOneNumber = reader.GetInt32();
                    break;
                case "ParameterOneString":
                    cls.ParameterOneString = reader.GetString();
                    break;
                case "ParameterTwoRecord":
                    cls.ParameterTwoRecord.SetTo(SerializerExtensions.ReadFormKeyValue(ref reader, options));
                    break;
                case "ParameterTwoNumber":
                    cls.ParameterTwoNumber = reader.GetInt32();
                    break;
                case "ParameterTwoString":
                    cls.ParameterTwoString = reader.GetString();
                    break;
            }
        }
        return cls;
    }
}
