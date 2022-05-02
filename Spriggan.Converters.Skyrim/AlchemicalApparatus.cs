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

public class IAlchemicalApparatusGetter_Converter : JsonConverter<IAlchemicalApparatusGetter>
{
  public override IAlchemicalApparatusGetter Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    throw new NotImplementedException();
  }
  public override void Write(Utf8JsonWriter writer, IAlchemicalApparatusGetter value, JsonSerializerOptions options)
  {
    writer.WriteStartObject();
    writer.WriteFormKeyHeader(value, options);
    
    // DATADataTypeState
    writer.WritePropertyName("DATADataTypeState");
    writer.WriteFlags(value.DATADataTypeState);
    
    // Description
    writer.WritePropertyName("Description");
    writer.WriteTranslatedString(value.Description, options);
    
    // Destructible
    writer.WritePropertyName("Destructible");
    if (value.Destructible != null)
    {
      writer.WriteStartObject();
      
      // Data
      writer.WritePropertyName("Data");
      if (value.Destructible.Data != null)
      {
        writer.WriteStartObject();
        
        // Health
        writer.WritePropertyName("Health");
        writer.WriteNumberValue((long)value.Destructible.Data.Health);
        
        // DESTCount
        writer.WritePropertyName("DESTCount");
        writer.WriteNumberValue((long)value.Destructible.Data.DESTCount);
        
        // VATSTargetable
        writer.WritePropertyName("VATSTargetable");
        writer.WriteBooleanValue(value.Destructible.Data.VATSTargetable);
        
        // Unknown
        writer.WritePropertyName("Unknown");
        writer.WriteNumberValue((long)value.Destructible.Data.Unknown);
        writer.WriteEndObject();
      }
      else
      {
        writer.WriteNullValue();
      }
      
      // Stages
      writer.WritePropertyName("Stages");
      if (value.Destructible.Stages != null)
      {
        writer.WriteStartArray();
        foreach(var itm1 in value.Destructible.Stages)
        {
          if (itm1 != null)
          {
            writer.WriteStartObject();
            
            // Data
            writer.WritePropertyName("Data");
            if (itm1.Data != null)
            {
              writer.WriteStartObject();
              
              // HealthPercent
              writer.WritePropertyName("HealthPercent");
              writer.WriteNumberValue((long)itm1.Data.HealthPercent);
              
              // Index
              writer.WritePropertyName("Index");
              writer.WriteNumberValue((long)itm1.Data.Index);
              
              // ModelDamageStage
              writer.WritePropertyName("ModelDamageStage");
              writer.WriteNumberValue((long)itm1.Data.ModelDamageStage);
              
              // Flags
              writer.WritePropertyName("Flags");
              writer.WriteEnum(itm1.Data.Flags);
              
              // SelfDamagePerSecond
              writer.WritePropertyName("SelfDamagePerSecond");
              writer.WriteNumberValue((long)itm1.Data.SelfDamagePerSecond);
              
              // Explosion
              writer.WritePropertyName("Explosion");
              writer.WriteStringValue(itm1.Data.Explosion.FormKey.ToString());
              
              // Debris
              writer.WritePropertyName("Debris");
              writer.WriteStringValue(itm1.Data.Debris.FormKey.ToString());
              
              // DebrisCount
              writer.WritePropertyName("DebrisCount");
              writer.WriteNumberValue((long)itm1.Data.DebrisCount);
              writer.WriteEndObject();
            }
            else
            {
              writer.WriteNullValue();
            }
            
            // Model
            writer.WritePropertyName("Model");
            if (itm1.Model != null)
            {
              writer.WriteStartObject();
              
              // AlternateTextures
              writer.WritePropertyName("AlternateTextures");
              if (itm1.Model.AlternateTextures != null)
              {
                writer.WriteStartArray();
                foreach(var itm2 in itm1.Model.AlternateTextures)
                {
                  if (itm2 != null)
                  {
                    writer.WriteStartObject();
                    
                    // Name
                    writer.WritePropertyName("Name");
                    writer.WriteStringValue(itm2.Name);
                    
                    // NewTexture
                    writer.WritePropertyName("NewTexture");
                    writer.WriteStringValue(itm2.NewTexture.FormKey.ToString());
                    
                    // Index
                    writer.WritePropertyName("Index");
                    writer.WriteNumberValue((long)itm2.Index);
                    writer.WriteEndObject();
                  }
                  else
                  {
                    writer.WriteNullValue();
                  }
                }
                writer.WriteEndArray();
              }
              else
              {
                writer.WriteNullValue();
              }
              
              // File
              writer.WritePropertyName("File");
              writer.WriteStringValue(itm1.Model.File);
              
              // Data
              writer.WritePropertyName("Data");
              if (itm1.Model.Data == null)
                writer.WriteNullValue();
              else
              {
                writer.WriteBase64StringValue(itm1.Model.Data.Value);
              }
              writer.WriteEndObject();
            }
            else
            {
              writer.WriteNullValue();
            }
            writer.WriteEndObject();
          }
          else
          {
            writer.WriteNullValue();
          }
        }
        writer.WriteEndArray();
      }
      else
      {
        writer.WriteNullValue();
      }
      writer.WriteEndObject();
    }
    else
    {
      writer.WriteNullValue();
    }
    
    // EditorID
    writer.WritePropertyName("EditorID");
    writer.WriteStringValue(value.EditorID);
    
    // Icons
    writer.WritePropertyName("Icons");
    if (value.Icons != null)
    {
      writer.WriteStartObject();
      
      // LargeIconFilename
      writer.WritePropertyName("LargeIconFilename");
      writer.WriteStringValue(value.Icons.LargeIconFilename);
      
      // SmallIconFilename
      writer.WritePropertyName("SmallIconFilename");
      writer.WriteStringValue(value.Icons.SmallIconFilename);
      writer.WriteEndObject();
    }
    else
    {
      writer.WriteNullValue();
    }
    
    // IsCompressed
    writer.WritePropertyName("IsCompressed");
    writer.WriteBooleanValue(value.IsCompressed);
    
    // IsDeleted
    writer.WritePropertyName("IsDeleted");
    writer.WriteBooleanValue(value.IsDeleted);
    
    // MajorRecordFlagsRaw
    writer.WritePropertyName("MajorRecordFlagsRaw");
    writer.WriteNumberValue((long)value.MajorRecordFlagsRaw);
    
    // Model
    writer.WritePropertyName("Model");
    if (value.Model != null)
    {
      writer.WriteStartObject();
      
      // AlternateTextures
      writer.WritePropertyName("AlternateTextures");
      if (value.Model.AlternateTextures != null)
      {
        writer.WriteStartArray();
        foreach(var itm3 in value.Model.AlternateTextures)
        {
          if (itm3 != null)
          {
            writer.WriteStartObject();
            
            // Name
            writer.WritePropertyName("Name");
            writer.WriteStringValue(itm3.Name);
            
            // NewTexture
            writer.WritePropertyName("NewTexture");
            writer.WriteStringValue(itm3.NewTexture.FormKey.ToString());
            
            // Index
            writer.WritePropertyName("Index");
            writer.WriteNumberValue((long)itm3.Index);
            writer.WriteEndObject();
          }
          else
          {
            writer.WriteNullValue();
          }
        }
        writer.WriteEndArray();
      }
      else
      {
        writer.WriteNullValue();
      }
      
      // File
      writer.WritePropertyName("File");
      writer.WriteStringValue(value.Model.File);
      
      // Data
      writer.WritePropertyName("Data");
      if (value.Model.Data == null)
        writer.WriteNullValue();
      else
      {
        writer.WriteBase64StringValue(value.Model.Data.Value);
      }
      writer.WriteEndObject();
    }
    else
    {
      writer.WriteNullValue();
    }
    
    // Name
    writer.WritePropertyName("Name");
    writer.WriteTranslatedString(value.Name, options);
    
    // ObjectBounds
    writer.WritePropertyName("ObjectBounds");
    if (value.ObjectBounds != null)
    {
      writer.WriteStartObject();
      
      // First
      writer.WritePropertyName("First");
      writer.WriteP3Int16(value.ObjectBounds.First, options);
      
      // Second
      writer.WritePropertyName("Second");
      writer.WriteP3Int16(value.ObjectBounds.Second, options);
      writer.WriteEndObject();
    }
    else
    {
      writer.WriteNullValue();
    }
    
    // PickUpSound
    writer.WritePropertyName("PickUpSound");
    if (value.PickUpSound.IsNull)
      writer.WriteNullValue();
    else
      writer.WriteStringValue(value.PickUpSound.FormKey.ToString());
    
    // PutDownSound
    writer.WritePropertyName("PutDownSound");
    if (value.PutDownSound.IsNull)
      writer.WriteNullValue();
    else
      writer.WriteStringValue(value.PutDownSound.FormKey.ToString());
    
    // Quality
    writer.WritePropertyName("Quality");
    if (value.Quality == null)
      writer.WriteNullValue();
    else
    {
      writer.WriteEnum(value.Quality.Value);
    }
    
    // Value
    writer.WritePropertyName("Value");
    writer.WriteNumberValue((long)value.Value);
    
    // Version2
    writer.WritePropertyName("Version2");
    writer.WriteNumberValue((uint)value.Version2);
    
    // VersionControl
    writer.WritePropertyName("VersionControl");
    writer.WriteNumberValue((long)value.VersionControl);
    
    // VirtualMachineAdapter
    writer.WritePropertyName("VirtualMachineAdapter");
    if (value.VirtualMachineAdapter != null)
    {
      writer.WriteStartObject();
      
      // Version
      writer.WritePropertyName("Version");
      writer.WriteNumberValue((long)value.VirtualMachineAdapter.Version);
      
      // ObjectFormat
      writer.WritePropertyName("ObjectFormat");
      writer.WriteNumberValue((uint)value.VirtualMachineAdapter.ObjectFormat);
      
      // Scripts
      writer.WritePropertyName("Scripts");
      if (value.VirtualMachineAdapter.Scripts != null)
      {
        writer.WriteStartArray();
        foreach(var itm4 in value.VirtualMachineAdapter.Scripts)
        {
          if (itm4 != null)
          {
            writer.WriteStartObject();
            
            // Name
            writer.WritePropertyName("Name");
            writer.WriteStringValue(itm4.Name);
            
            // Flags
            writer.WritePropertyName("Flags");
            writer.WriteEnum(itm4.Flags);
            
            // Properties
            writer.WritePropertyName("Properties");
            if (itm4.Properties != null)
            {
              writer.WriteStartArray();
              foreach(var itm5 in itm4.Properties)
              {
                if (itm5 != null)
                {
                  writer.WriteStartObject();
                  
                  // Name
                  writer.WritePropertyName("Name");
                  writer.WriteStringValue(itm5.Name);
                  
                  // Flags
                  writer.WritePropertyName("Flags");
                  writer.WriteEnum(itm5.Flags);
                  writer.WriteEndObject();
                }
                else
                {
                  writer.WriteNullValue();
                }
              }
              writer.WriteEndArray();
            }
            else
            {
              writer.WriteNullValue();
            }
            writer.WriteEndObject();
          }
          else
          {
            writer.WriteNullValue();
          }
        }
        writer.WriteEndArray();
      }
      else
      {
        writer.WriteNullValue();
      }
      writer.WriteEndObject();
    }
    else
    {
      writer.WriteNullValue();
    }
    
    // Weight
    writer.WritePropertyName("Weight");
    writer.WriteNumberValue((long)value.Weight);
    writer.WriteEndObject();
  }
}
public class AlchemicalApparatus_Converter : JsonConverter<Mutagen.Bethesda.Skyrim.AlchemicalApparatus>
{
  private IAlchemicalApparatusGetter_Converter _getterConverter;
  public AlchemicalApparatus_Converter()
  {
    _getterConverter = new IAlchemicalApparatusGetter_Converter();
  }
  public override void Write(Utf8JsonWriter writer, Mutagen.Bethesda.Skyrim.AlchemicalApparatus value, JsonSerializerOptions options)
  {
    _getterConverter.Write(writer, (IAlchemicalApparatusGetter)value, options);
  }
  public override Mutagen.Bethesda.Skyrim.AlchemicalApparatus Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    if (reader.TokenType != JsonTokenType.StartObject)
        throw new JsonException();
    reader.Read();
    var retval = new Mutagen.Bethesda.Skyrim.AlchemicalApparatus(SerializerExtensions.ReadFormKeyHeader(ref reader, options), SkyrimRelease.SkyrimSE);
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
        case "DATADataTypeState":
          retval.DATADataTypeState = SerializerExtensions.ReadFlags<Mutagen.Bethesda.Skyrim.AlchemicalApparatus.DATADataType>(ref reader, options);
          break;
        case "Description":
          retval.Description ??= new TranslatedString(Language.English);
          SerializerExtensions.ReadTranslatedString(ref reader, retval.Description, options);
          break;
        case "Destructible":
          retval.Destructible = new Mutagen.Bethesda.Skyrim.Destructible();
          if (reader.TokenType != JsonTokenType.Null)
          {
            if (reader.TokenType != JsonTokenType.StartObject)
              throw new JsonException();
            while (true)
            {
              reader.Read();
              if (reader.TokenType == JsonTokenType.EndObject)
                break;
              var prop6 = reader.GetString();
              reader.Read();
              switch(prop6)
              {
                case "Data":
                  retval.Destructible.Data = new Mutagen.Bethesda.Skyrim.DestructableData();
                  if (reader.TokenType != JsonTokenType.Null)
                  {
                    if (reader.TokenType != JsonTokenType.StartObject)
                      throw new JsonException();
                    while (true)
                    {
                      reader.Read();
                      if (reader.TokenType == JsonTokenType.EndObject)
                        break;
                      var prop7 = reader.GetString();
                      reader.Read();
                      switch(prop7)
                      {
                        case "Health":
                          retval.Destructible.Data.Health = reader.GetInt32();
                          break;
                        case "DESTCount":
                          retval.Destructible.Data.DESTCount = reader.GetByte();
                          break;
                        case "VATSTargetable":
                          retval.Destructible.Data.VATSTargetable = reader.GetBoolean();
                          break;
                        case "Unknown":
                          retval.Destructible.Data.Unknown = reader.GetInt16();
                          break;
                      }
                    }
                  }
                  else
                  {
                    reader.Skip();
                  }
                  break;
                case "Stages":
                  if (reader.TokenType != JsonTokenType.Null)
                  {
                    if (reader.TokenType != JsonTokenType.StartArray)
                      throw new JsonException();
                    while (true)
                    {
                      reader.Read();
                      if (reader.TokenType == JsonTokenType.EndArray)
                        break;
                      var itm8 = new Mutagen.Bethesda.Skyrim.DestructionStage();
                      if (reader.TokenType != JsonTokenType.Null)
                      {
                        if (reader.TokenType != JsonTokenType.StartObject)
                          throw new JsonException();
                        while (true)
                        {
                          reader.Read();
                          if (reader.TokenType == JsonTokenType.EndObject)
                            break;
                          var prop9 = reader.GetString();
                          reader.Read();
                          switch(prop9)
                          {
                            case "Data":
                              itm8.Data = new Mutagen.Bethesda.Skyrim.DestructionStageData();
                              if (reader.TokenType != JsonTokenType.Null)
                              {
                                if (reader.TokenType != JsonTokenType.StartObject)
                                  throw new JsonException();
                                while (true)
                                {
                                  reader.Read();
                                  if (reader.TokenType == JsonTokenType.EndObject)
                                    break;
                                  var prop10 = reader.GetString();
                                  reader.Read();
                                  switch(prop10)
                                  {
                                    case "HealthPercent":
                                      itm8.Data.HealthPercent = reader.GetByte();
                                      break;
                                    case "Index":
                                      itm8.Data.Index = reader.GetByte();
                                      break;
                                    case "ModelDamageStage":
                                      itm8.Data.ModelDamageStage = reader.GetByte();
                                      break;
                                    case "Flags":
                                      itm8.Data.Flags = SerializerExtensions.ReadEnum<Mutagen.Bethesda.Skyrim.DestructionStageData.Flag>(ref reader, options);
                                      break;
                                    case "SelfDamagePerSecond":
                                      itm8.Data.SelfDamagePerSecond = reader.GetInt32();
                                      break;
                                    case "Explosion":
                                      itm8.Data.Explosion.SetTo(SerializerExtensions.ReadFormKeyValue(ref reader, options));
                                      break;
                                    case "Debris":
                                      itm8.Data.Debris.SetTo(SerializerExtensions.ReadFormKeyValue(ref reader, options));
                                      break;
                                    case "DebrisCount":
                                      itm8.Data.DebrisCount = reader.GetInt32();
                                      break;
                                  }
                                }
                              }
                              else
                              {
                                reader.Skip();
                              }
                              break;
                            case "Model":
                              itm8.Model = new Mutagen.Bethesda.Skyrim.Model();
                              if (reader.TokenType != JsonTokenType.Null)
                              {
                                if (reader.TokenType != JsonTokenType.StartObject)
                                  throw new JsonException();
                                while (true)
                                {
                                  reader.Read();
                                  if (reader.TokenType == JsonTokenType.EndObject)
                                    break;
                                  var prop11 = reader.GetString();
                                  reader.Read();
                                  switch(prop11)
                                  {
                                    case "AlternateTextures":
                                      if (reader.TokenType != JsonTokenType.Null)
                                      {
                                        itm8.Model.AlternateTextures ??= new();
                                        if (reader.TokenType != JsonTokenType.StartArray)
                                          throw new JsonException();
                                        while (true)
                                        {
                                          reader.Read();
                                          if (reader.TokenType == JsonTokenType.EndArray)
                                            break;
                                          var itm12 = new Mutagen.Bethesda.Skyrim.AlternateTexture();
                                          if (reader.TokenType != JsonTokenType.Null)
                                          {
                                            if (reader.TokenType != JsonTokenType.StartObject)
                                              throw new JsonException();
                                            while (true)
                                            {
                                              reader.Read();
                                              if (reader.TokenType == JsonTokenType.EndObject)
                                                break;
                                              var prop13 = reader.GetString();
                                              reader.Read();
                                              switch(prop13)
                                              {
                                                case "Name":
                                                  itm12.Name = reader.GetString();
                                                  break;
                                                case "NewTexture":
                                                  itm12.NewTexture.SetTo(SerializerExtensions.ReadFormKeyValue(ref reader, options));
                                                  break;
                                                case "Index":
                                                  itm12.Index = reader.GetInt32();
                                                  break;
                                              }
                                            }
                                          }
                                          else
                                          {
                                            reader.Skip();
                                          }
                                          itm8.Model.AlternateTextures.Add(itm12);
                                        }
                                      }
                                      break;
                                    case "File":
                                      itm8.Model.File = reader.GetString();
                                      break;
                                    case "Data":
                                      if (reader.TokenType != JsonTokenType.Null) {
                                        itm8.Model.Data = reader.GetBytesFromBase64();
                                      }
                                      break;
                                  }
                                }
                              }
                              else
                              {
                                reader.Skip();
                              }
                              break;
                          }
                        }
                      }
                      else
                      {
                        reader.Skip();
                      }
                      retval.Destructible.Stages.Add(itm8);
                    }
                  }
                  break;
              }
            }
          }
          else
          {
            reader.Skip();
          }
          break;
        case "EditorID":
          retval.EditorID = reader.GetString();
          break;
        case "FormVersion":
          retval.FormVersion = reader.GetUInt16();
          break;
        case "Icons":
          retval.Icons = new Mutagen.Bethesda.Skyrim.Icons();
          if (reader.TokenType != JsonTokenType.Null)
          {
            if (reader.TokenType != JsonTokenType.StartObject)
              throw new JsonException();
            while (true)
            {
              reader.Read();
              if (reader.TokenType == JsonTokenType.EndObject)
                break;
              var prop14 = reader.GetString();
              reader.Read();
              switch(prop14)
              {
                case "LargeIconFilename":
                  retval.Icons.LargeIconFilename = reader.GetString();
                  break;
                case "SmallIconFilename":
                  retval.Icons.SmallIconFilename = reader.GetString();
                  break;
              }
            }
          }
          else
          {
            reader.Skip();
          }
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
        case "Model":
          retval.Model = new Mutagen.Bethesda.Skyrim.Model();
          if (reader.TokenType != JsonTokenType.Null)
          {
            if (reader.TokenType != JsonTokenType.StartObject)
              throw new JsonException();
            while (true)
            {
              reader.Read();
              if (reader.TokenType == JsonTokenType.EndObject)
                break;
              var prop15 = reader.GetString();
              reader.Read();
              switch(prop15)
              {
                case "AlternateTextures":
                  if (reader.TokenType != JsonTokenType.Null)
                  {
                    retval.Model.AlternateTextures ??= new();
                    if (reader.TokenType != JsonTokenType.StartArray)
                      throw new JsonException();
                    while (true)
                    {
                      reader.Read();
                      if (reader.TokenType == JsonTokenType.EndArray)
                        break;
                      var itm16 = new Mutagen.Bethesda.Skyrim.AlternateTexture();
                      if (reader.TokenType != JsonTokenType.Null)
                      {
                        if (reader.TokenType != JsonTokenType.StartObject)
                          throw new JsonException();
                        while (true)
                        {
                          reader.Read();
                          if (reader.TokenType == JsonTokenType.EndObject)
                            break;
                          var prop17 = reader.GetString();
                          reader.Read();
                          switch(prop17)
                          {
                            case "Name":
                              itm16.Name = reader.GetString();
                              break;
                            case "NewTexture":
                              itm16.NewTexture.SetTo(SerializerExtensions.ReadFormKeyValue(ref reader, options));
                              break;
                            case "Index":
                              itm16.Index = reader.GetInt32();
                              break;
                          }
                        }
                      }
                      else
                      {
                        reader.Skip();
                      }
                      retval.Model.AlternateTextures.Add(itm16);
                    }
                  }
                  break;
                case "File":
                  retval.Model.File = reader.GetString();
                  break;
                case "Data":
                  if (reader.TokenType != JsonTokenType.Null) {
                    retval.Model.Data = reader.GetBytesFromBase64();
                  }
                  break;
              }
            }
          }
          else
          {
            reader.Skip();
          }
          break;
        case "Name":
          retval.Name ??= new TranslatedString(Language.English);
          SerializerExtensions.ReadTranslatedString(ref reader, retval.Name, options);
          break;
        case "ObjectBounds":
          retval.ObjectBounds = new Mutagen.Bethesda.Skyrim.ObjectBounds();
          if (reader.TokenType != JsonTokenType.Null)
          {
            if (reader.TokenType != JsonTokenType.StartObject)
              throw new JsonException();
            while (true)
            {
              reader.Read();
              if (reader.TokenType == JsonTokenType.EndObject)
                break;
              var prop18 = reader.GetString();
              reader.Read();
              switch(prop18)
              {
                case "First":
                  retval.ObjectBounds.First = SerializerExtensions.ReadP3Int16(ref reader, options);
                  break;
                case "Second":
                  retval.ObjectBounds.Second = SerializerExtensions.ReadP3Int16(ref reader, options);
                  break;
              }
            }
          }
          else
          {
            reader.Skip();
          }
          break;
        case "PickUpSound":
          if (reader.TokenType != JsonTokenType.Null)
            retval.PickUpSound.SetTo(SerializerExtensions.ReadFormKeyValue(ref reader, options));
          break;
        case "PutDownSound":
          if (reader.TokenType != JsonTokenType.Null)
            retval.PutDownSound.SetTo(SerializerExtensions.ReadFormKeyValue(ref reader, options));
          break;
        case "Quality":
          if (reader.TokenType != JsonTokenType.Null) {
            retval.Quality = SerializerExtensions.ReadEnum<Mutagen.Bethesda.Skyrim.QualityLevel>(ref reader, options);
          }
          break;
        case "SkyrimMajorRecordFlags":
          retval.SkyrimMajorRecordFlags = SerializerExtensions.ReadFlags<Mutagen.Bethesda.Skyrim.SkyrimMajorRecord.SkyrimMajorRecordFlag>(ref reader, options);
          break;
        case "Value":
          retval.Value = reader.GetUInt32();
          break;
        case "Version2":
          retval.Version2 = reader.GetUInt16();
          break;
        case "VersionControl":
          retval.VersionControl = reader.GetUInt32();
          break;
        case "VirtualMachineAdapter":
          retval.VirtualMachineAdapter = new Mutagen.Bethesda.Skyrim.VirtualMachineAdapter();
          if (reader.TokenType != JsonTokenType.Null)
          {
            if (reader.TokenType != JsonTokenType.StartObject)
              throw new JsonException();
            while (true)
            {
              reader.Read();
              if (reader.TokenType == JsonTokenType.EndObject)
                break;
              var prop19 = reader.GetString();
              reader.Read();
              switch(prop19)
              {
                case "Version":
                  retval.VirtualMachineAdapter.Version = reader.GetInt16();
                  break;
                case "ObjectFormat":
                  retval.VirtualMachineAdapter.ObjectFormat = reader.GetUInt16();
                  break;
                case "Scripts":
                  if (reader.TokenType != JsonTokenType.Null)
                  {
                    if (reader.TokenType != JsonTokenType.StartArray)
                      throw new JsonException();
                    while (true)
                    {
                      reader.Read();
                      if (reader.TokenType == JsonTokenType.EndArray)
                        break;
                      var itm20 = new Mutagen.Bethesda.Skyrim.ScriptEntry();
                      if (reader.TokenType != JsonTokenType.Null)
                      {
                        if (reader.TokenType != JsonTokenType.StartObject)
                          throw new JsonException();
                        while (true)
                        {
                          reader.Read();
                          if (reader.TokenType == JsonTokenType.EndObject)
                            break;
                          var prop21 = reader.GetString();
                          reader.Read();
                          switch(prop21)
                          {
                            case "Name":
                              itm20.Name = reader.GetString();
                              break;
                            case "Flags":
                              itm20.Flags = SerializerExtensions.ReadEnum<Mutagen.Bethesda.Skyrim.ScriptEntry.Flag>(ref reader, options);
                              break;
                            case "Properties":
                              if (reader.TokenType != JsonTokenType.Null)
                              {
                                if (reader.TokenType != JsonTokenType.StartArray)
                                  throw new JsonException();
                                while (true)
                                {
                                  reader.Read();
                                  if (reader.TokenType == JsonTokenType.EndArray)
                                    break;
                                  var itm22 = new Mutagen.Bethesda.Skyrim.ScriptProperty();
                                  if (reader.TokenType != JsonTokenType.Null)
                                  {
                                    if (reader.TokenType != JsonTokenType.StartObject)
                                      throw new JsonException();
                                    while (true)
                                    {
                                      reader.Read();
                                      if (reader.TokenType == JsonTokenType.EndObject)
                                        break;
                                      var prop23 = reader.GetString();
                                      reader.Read();
                                      switch(prop23)
                                      {
                                        case "Name":
                                          itm22.Name = reader.GetString();
                                          break;
                                        case "Flags":
                                          itm22.Flags = SerializerExtensions.ReadEnum<Mutagen.Bethesda.Skyrim.ScriptProperty.Flag>(ref reader, options);
                                          break;
                                      }
                                    }
                                  }
                                  else
                                  {
                                    reader.Skip();
                                  }
                                  itm20.Properties.Add(itm22);
                                }
                              }
                              break;
                          }
                        }
                      }
                      else
                      {
                        reader.Skip();
                      }
                      retval.VirtualMachineAdapter.Scripts.Add(itm20);
                    }
                  }
                  break;
              }
            }
          }
          else
          {
            reader.Skip();
          }
          break;
        case "Weight":
          retval.Weight = reader.GetSingle();
          break;
        default:
            reader.Skip();
            break;
      }
    }
    return retval;
  }
}
