using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mutagen.Bethesda;
using Mutagen.Bethesda.Environments;
using Mutagen.Bethesda.Plugins.Records;
using Mutagen.Bethesda.Skyrim;
using Noggog;
using Xunit;

namespace Spriggan.Converters.Skyrim.Tests;

public class RoundTripTests
{
    private readonly JsonSerializerOptions _soptions;

    public RoundTripTests(IEnumerable<JsonConverter> converters)
    {
        var soptions = new JsonSerializerOptions();
        soptions.Converters.AddRange(converters);
        soptions.WriteIndented = true;
        soptions.Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
        _soptions = soptions;

    }
    
    [Theory]
    [MemberData(nameof(RecordTypes))]
    public void AllRecordTypes(Type mainType, Type getterType)
    {
        using var env = GameEnvironment.Typical.Skyrim(SkyrimRelease.SkyrimSE);

        var enumFunction = typeof(RoundTripTests).GetMethod("GetRecords").MakeGenericMethod(getterType);
        var records = (IEnumerable<object>)enumFunction.Invoke(this, new object?[]{env});

        foreach (var record in records)
        {
            var stream = new MemoryStream();
            JsonSerializer.Serialize(stream, record, _soptions);
            var str = Encoding.UTF8.GetString(stream.ToArray());
        }
    }

    public IEnumerable<object> GetRecords<T>(IGameEnvironmentState<ISkyrimMod, ISkyrimModGetter> env)
    where T : class, IMajorRecordGetter
    {
        return env.LoadOrder.PriorityOrder.WinningOverrides<T>();
    }

    public static IEnumerable<object[]> RecordTypes =>
        GeneratedConvertersExtensions.SupportedRecords.Select(t => new object[] {
        t.Main, t.Getter
    });
}