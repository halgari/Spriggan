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

internal static class PlacedBarrier_Writer
{
    public static void WriteInner(Utf8JsonWriter writer, Mutagen.Bethesda.Skyrim.IPlacedBarrierGetter? value, JsonSerializerOptions options)
    {
        if (value != null)
        {
            
            // Projectile
            writer.WritePropertyName("Projectile");
            writer.WriteStringValue(value.Projectile.FormKey.ToString());
            
            // VirtualMachineAdapter
            writer.WritePropertyName("VirtualMachineAdapter");
            if (value.VirtualMachineAdapter != null)
            {
                writer.WriteStartObject();
                
                // Version
                writer.WritePropertyName("Version");
                writer.WriteNumberValue(value.VirtualMachineAdapter.Version);
                
                // ObjectFormat
                writer.WritePropertyName("ObjectFormat");
                writer.WriteNumberValue((uint)value.VirtualMachineAdapter.ObjectFormat);
                
                // Scripts
                writer.WritePropertyName("Scripts");
                if (value.VirtualMachineAdapter.Scripts != null)
                {
                    writer.WriteStartArray();
                    foreach(var itm1 in value.VirtualMachineAdapter.Scripts)
                    {
                        if (itm1 != null)
                        {
                            writer.WriteStartObject();
                            
                            // Name
                            writer.WritePropertyName("Name");
                            writer.WriteStringValue(itm1.Name);
                            
                            // Flags
                            writer.WritePropertyName("Flags");
                            writer.WriteEnum(itm1.Flags);
                            
                            // Properties
                            writer.WritePropertyName("Properties");
                            if (itm1.Properties != null)
                            {
                                writer.WriteStartArray();
                                foreach(var itm2 in itm1.Properties)
                                {
                                    IScriptPropertyGetter_Writer.WriteOuter(writer, itm2, options);
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
            
            // EncounterZone
            writer.WritePropertyName("EncounterZone");
            if (value.EncounterZone.IsNull)
                writer.WriteNullValue();
            else
                writer.WriteStringValue(value.EncounterZone.FormKey.ToString());
            
            // Ownership
            writer.WritePropertyName("Ownership");
            if (value.Ownership != null)
            {
                writer.WriteStartObject();
                
                // Owner
                writer.WritePropertyName("Owner");
                if (value.Ownership.Owner.IsNull)
                    writer.WriteNullValue();
                else
                    writer.WriteStringValue(value.Ownership.Owner.FormKey.ToString());
                
                // FactionRank
                writer.WritePropertyName("FactionRank");
                if (value.Ownership.FactionRank == null)
                    writer.WriteNullValue();
                else
                {
                    writer.WriteNumberValue(value.Ownership.FactionRank.Value);
                }
                writer.WriteEndObject();
            }
            else
            {
                writer.WriteNullValue();
            }
            
            // HeadTrackingWeight
            writer.WritePropertyName("HeadTrackingWeight");
            if (value.HeadTrackingWeight == null)
                writer.WriteNullValue();
            else
            {
                writer.WriteNumberValue(value.HeadTrackingWeight.Value);
            }
            
            // FavorCost
            writer.WritePropertyName("FavorCost");
            if (value.FavorCost == null)
                writer.WriteNullValue();
            else
            {
                writer.WriteNumberValue(value.FavorCost.Value);
            }
            
            // Reflections
            writer.WritePropertyName("Reflections");
            if (value.Reflections != null)
            {
                writer.WriteStartArray();
                foreach(var itm3 in value.Reflections)
                {
                    if (itm3 != null)
                    {
                        writer.WriteStartObject();
                        
                        // Versioning
                        writer.WritePropertyName("Versioning");
                        writer.WriteFlags(itm3.Versioning);
                        
                        // Water
                        writer.WritePropertyName("Water");
                        writer.WriteStringValue(itm3.Water.FormKey.ToString());
                        
                        // Type
                        writer.WritePropertyName("Type");
                        writer.WriteFlags(itm3.Type);
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
            
            // LinkedReferences
            writer.WritePropertyName("LinkedReferences");
            if (value.LinkedReferences != null)
            {
                writer.WriteStartArray();
                foreach(var itm4 in value.LinkedReferences)
                {
                    if (itm4 != null)
                    {
                        writer.WriteStartObject();
                        
                        // Versioning
                        writer.WritePropertyName("Versioning");
                        writer.WriteFlags(itm4.Versioning);
                        
                        // KeywordOrReference
                        writer.WritePropertyName("KeywordOrReference");
                        writer.WriteStringValue(itm4.KeywordOrReference.FormKey.ToString());
                        
                        // Reference
                        writer.WritePropertyName("Reference");
                        writer.WriteStringValue(itm4.Reference.FormKey.ToString());
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
            
            // ActivateParents
            writer.WritePropertyName("ActivateParents");
            if (value.ActivateParents != null)
            {
                writer.WriteStartObject();
                
                // Flags
                writer.WritePropertyName("Flags");
                writer.WriteFlags(value.ActivateParents.Flags);
                
                // Parents
                writer.WritePropertyName("Parents");
                if (value.ActivateParents.Parents != null)
                {
                    writer.WriteStartArray();
                    foreach(var itm5 in value.ActivateParents.Parents)
                    {
                        if (itm5 != null)
                        {
                            writer.WriteStartObject();
                            
                            // Reference
                            writer.WritePropertyName("Reference");
                            writer.WriteStringValue(itm5.Reference.FormKey.ToString());
                            
                            // Delay
                            writer.WritePropertyName("Delay");
                            writer.WriteNumberValue(itm5.Delay);
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
            
            // EnableParent
            writer.WritePropertyName("EnableParent");
            if (value.EnableParent != null)
            {
                writer.WriteStartObject();
                
                // Versioning
                writer.WritePropertyName("Versioning");
                writer.WriteFlags(value.EnableParent.Versioning);
                
                // Reference
                writer.WritePropertyName("Reference");
                writer.WriteStringValue(value.EnableParent.Reference.FormKey.ToString());
                
                // Flags
                writer.WritePropertyName("Flags");
                writer.WriteFlags(value.EnableParent.Flags);
                
                // Unknown
                writer.WritePropertyName("Unknown");
                writer.WriteBase64StringValue(value.EnableParent.Unknown);
                writer.WriteEndObject();
            }
            else
            {
                writer.WriteNullValue();
            }
            
            // Emittance
            writer.WritePropertyName("Emittance");
            if (value.Emittance.IsNull)
                writer.WriteNullValue();
            else
                writer.WriteStringValue(value.Emittance.FormKey.ToString());
            
            // MultiBoundReference
            writer.WritePropertyName("MultiBoundReference");
            if (value.MultiBoundReference.IsNull)
                writer.WriteNullValue();
            else
                writer.WriteStringValue(value.MultiBoundReference.FormKey.ToString());
            
            // IgnoredBySandbox
            writer.WritePropertyName("IgnoredBySandbox");
            if (value.IgnoredBySandbox == null)
                writer.WriteNullValue();
            else
            {
                writer.WriteBase64StringValue(value.IgnoredBySandbox.Value);
            }
            
            // LocationRefTypes
            writer.WritePropertyName("LocationRefTypes");
            if (value.LocationRefTypes != null)
            {
                writer.WriteStartArray();
                foreach(var itm6 in value.LocationRefTypes)
                {
                    writer.WriteStringValue(itm6.FormKey.ToString());
                }
                writer.WriteEndArray();
            }
            else
            {
                writer.WriteNullValue();
            }
            
            // LocationReference
            writer.WritePropertyName("LocationReference");
            if (value.LocationReference.IsNull)
                writer.WriteNullValue();
            else
                writer.WriteStringValue(value.LocationReference.FormKey.ToString());
            
            // DistantLodData
            writer.WritePropertyName("DistantLodData");
            if (value.DistantLodData != null)
            {
                writer.WriteStartArray();
                foreach(var itm7 in value.DistantLodData)
                {
                    writer.WriteNumberValue(itm7);
                }
                writer.WriteEndArray();
            }
            else
            {
                writer.WriteNullValue();
            }
            
            // Scale
            writer.WritePropertyName("Scale");
            if (value.Scale == null)
                writer.WriteNullValue();
            else
            {
                writer.WriteNumberValue(value.Scale.Value);
            }
            
            // Placement
            writer.WritePropertyName("Placement");
            if (value.Placement != null)
            {
                writer.WriteStartObject();
                
                // Position
                writer.WritePropertyName("Position");
                writer.WriteP3Float(value.Placement.Position, options);
                
                // Rotation
                writer.WritePropertyName("Rotation");
                writer.WriteP3Float(value.Placement.Rotation, options);
                writer.WriteEndObject();
            }
            else
            {
                writer.WriteNullValue();
            }
            
            // MajorFlags
            writer.WritePropertyName("MajorFlags");
            writer.WriteFlags(value.MajorFlags);
            
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
        }
        else
        {
            writer.WriteNullValue();
        }
    }
}
