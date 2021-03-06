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

internal static class IPlacedGetter_Writer
{
    public static void WriteOuter(Utf8JsonWriter writer, Mutagen.Bethesda.Skyrim.IPlacedGetter? value, JsonSerializerOptions options)
    {
        if (value != null)
        {
            writer.WriteStartObject();
            switch (value)
            {
                case Mutagen.Bethesda.Skyrim.IPlacedNpcGetter itm1:
                    writer.WriteString("$type", "PlacedNpc");
                    PlacedNpc_Writer.WriteInner(writer, itm1, options);
                    break;
                case Mutagen.Bethesda.Skyrim.IPlacedObjectGetter itm2:
                    writer.WriteString("$type", "PlacedObject");
                    PlacedObject_Writer.WriteInner(writer, itm2, options);
                    break;
                case Mutagen.Bethesda.Skyrim.IPlacedArrowGetter itm3:
                    writer.WriteString("$type", "PlacedArrow");
                    PlacedArrow_Writer.WriteInner(writer, itm3, options);
                    break;
                case Mutagen.Bethesda.Skyrim.IPlacedBeamGetter itm4:
                    writer.WriteString("$type", "PlacedBeam");
                    PlacedBeam_Writer.WriteInner(writer, itm4, options);
                    break;
                case Mutagen.Bethesda.Skyrim.IPlacedFlameGetter itm5:
                    writer.WriteString("$type", "PlacedFlame");
                    PlacedFlame_Writer.WriteInner(writer, itm5, options);
                    break;
                case Mutagen.Bethesda.Skyrim.IPlacedConeGetter itm6:
                    writer.WriteString("$type", "PlacedCone");
                    PlacedCone_Writer.WriteInner(writer, itm6, options);
                    break;
                case Mutagen.Bethesda.Skyrim.IPlacedBarrierGetter itm7:
                    writer.WriteString("$type", "PlacedBarrier");
                    PlacedBarrier_Writer.WriteInner(writer, itm7, options);
                    break;
                case Mutagen.Bethesda.Skyrim.IPlacedTrapGetter itm8:
                    writer.WriteString("$type", "PlacedTrap");
                    PlacedTrap_Writer.WriteInner(writer, itm8, options);
                    break;
                case Mutagen.Bethesda.Skyrim.IPlacedHazardGetter itm9:
                    writer.WriteString("$type", "PlacedHazard");
                    PlacedHazard_Writer.WriteInner(writer, itm9, options);
                    break;
                case Mutagen.Bethesda.Skyrim.IPlacedMissileGetter itm10:
                    writer.WriteString("$type", "PlacedMissile");
                    PlacedMissile_Writer.WriteInner(writer, itm10, options);
                    break;
            }
            writer.WriteEndObject();
        }
        else
        {
            writer.WriteNullValue();
        }
    }
}
