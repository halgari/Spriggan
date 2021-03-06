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

public class IAssociationTypeGetter_Converter : JsonConverter<IAssociationTypeGetter>
{
    public override bool CanConvert(Type t)
    {
        return t.InheritsFrom(typeof(Mutagen.Bethesda.Skyrim.IAssociationTypeGetter)) && !t.InheritsFrom(typeof(Mutagen.Bethesda.Skyrim.AssociationType));
    }
    public override IAssociationTypeGetter Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }
    public override void Write(Utf8JsonWriter writer, IAssociationTypeGetter value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();
        writer.WriteFormKeyHeader(value, options);
        
        // EditorID
        writer.WritePropertyName("EditorID");
        writer.WriteStringValue(value.EditorID);
        
        // Flags
        writer.WritePropertyName("Flags");
        writer.WriteFlags(value.Flags);
        
        // IsCompressed
        writer.WritePropertyName("IsCompressed");
        writer.WriteBooleanValue(value.IsCompressed);
        
        // IsDeleted
        writer.WritePropertyName("IsDeleted");
        writer.WriteBooleanValue(value.IsDeleted);
        
        // MajorRecordFlagsRaw
        writer.WritePropertyName("MajorRecordFlagsRaw");
        writer.WriteNumberValue(value.MajorRecordFlagsRaw);
        
        // ParentTitle
        writer.WritePropertyName("ParentTitle");
        if (value.ParentTitle == null)
        {
            writer.WriteNullValue();
        }
        else
        {
            writer.WriteStartObject();
            writer.WritePropertyName("Male");
            writer.WriteStringValue(value.ParentTitle.Male);
            writer.WritePropertyName("Female");
            writer.WriteStringValue(value.ParentTitle.Female);
            writer.WriteEndObject();
        }
        
        // Title
        writer.WritePropertyName("Title");
        if (value.Title == null)
        {
            writer.WriteNullValue();
        }
        else
        {
            writer.WriteStartObject();
            writer.WritePropertyName("Male");
            writer.WriteStringValue(value.Title.Male);
            writer.WritePropertyName("Female");
            writer.WriteStringValue(value.Title.Female);
            writer.WriteEndObject();
        }
        
        // Version2
        writer.WritePropertyName("Version2");
        writer.WriteNumberValue((uint)value.Version2);
        
        // VersionControl
        writer.WritePropertyName("VersionControl");
        writer.WriteNumberValue(value.VersionControl);
        writer.WriteEndObject();
    }
}
public class AssociationType_Converter : JsonConverter<Mutagen.Bethesda.Skyrim.AssociationType>
{
    private IAssociationTypeGetter_Converter _getterConverter;
    public AssociationType_Converter()
    {
        _getterConverter = new IAssociationTypeGetter_Converter();
    }
    public override bool CanConvert(Type t)
    {
        return t.InheritsFrom(typeof(Mutagen.Bethesda.Skyrim.AssociationType));
    }
    public override void Write(Utf8JsonWriter writer, Mutagen.Bethesda.Skyrim.AssociationType value, JsonSerializerOptions options)
    {
        _getterConverter.Write(writer, (IAssociationTypeGetter)value, options);
    }
    public override Mutagen.Bethesda.Skyrim.AssociationType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartObject)
            throw new JsonException();
        reader.Read();
        Mutagen.Bethesda.Skyrim.AssociationType retval = new Mutagen.Bethesda.Skyrim.AssociationType(SerializerExtensions.ReadFormKeyHeader(ref reader, options), SkyrimRelease.SkyrimSE);
        while (true)
        {
            reader.Read();
            if (reader.TokenType == JsonTokenType.EndObject)
            {
                reader.Read();
                break;
            }
            var prop = reader.GetString();
            reader.Read();
            switch (prop)
            {
                case "EditorID":
                    retval.EditorID = reader.GetString();
                    break;
                case "Flags":
                    retval.Flags = SerializerExtensions.ReadFlags<Mutagen.Bethesda.Skyrim.AssociationType.Flag>(ref reader, options);
                    break;
                case "FormVersion":
                    retval.FormVersion = reader.GetUInt16();
                    break;
                case "IsCompressed":
                    retval.IsCompressed = reader.GetBoolean();
                    break;
                case "IsDeleted":
                    retval.IsDeleted = reader.GetBoolean();
                    break;
                case "MajorRecordFlagsRaw":
                    retval.MajorRecordFlagsRaw = reader.GetInt32();
                    break;
                case "ParentTitle":
                    if (reader.TokenType != JsonTokenType.Null)
                    {
                        if (reader.TokenType != JsonTokenType.StartObject)
                            throw new JsonException();
                        retval.ParentTitle = new GenderedItem<System.String>(default, default);
                        while(true)
                        {
                            reader.Read();
                            if (reader.TokenType == JsonTokenType.EndObject)
                            {
                                break;
                            }
                            var prop1 = reader.GetString();
                            reader.Read();
                            switch(prop1)
                            {
                                case "Male":
                                    retval.ParentTitle.Male = reader.GetString();
                                    break;
                                case "Female":
                                    retval.ParentTitle.Female = reader.GetString();
                                    break;
                            }
                        }
                    }
                    else
                    {
                        reader.Skip();
                    }
                    break;
                case "SkyrimMajorRecordFlags":
                    retval.SkyrimMajorRecordFlags = SerializerExtensions.ReadFlags<Mutagen.Bethesda.Skyrim.SkyrimMajorRecord.SkyrimMajorRecordFlag>(ref reader, options);
                    break;
                case "Title":
                    if (reader.TokenType != JsonTokenType.Null)
                    {
                        if (reader.TokenType != JsonTokenType.StartObject)
                            throw new JsonException();
                        retval.Title = new GenderedItem<System.String>(default, default);
                        while(true)
                        {
                            reader.Read();
                            if (reader.TokenType == JsonTokenType.EndObject)
                            {
                                break;
                            }
                            var prop2 = reader.GetString();
                            reader.Read();
                            switch(prop2)
                            {
                                case "Male":
                                    retval.Title.Male = reader.GetString();
                                    break;
                                case "Female":
                                    retval.Title.Female = reader.GetString();
                                    break;
                            }
                        }
                    }
                    else
                    {
                        reader.Skip();
                    }
                    break;
                case "Version2":
                    retval.Version2 = reader.GetUInt16();
                    break;
                case "VersionControl":
                    retval.VersionControl = reader.GetUInt32();
                    break;
                default:
                    reader.Skip();
                    break;
            }
        }
        return retval;
    }
}
