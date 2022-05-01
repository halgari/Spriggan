// See https://aka.ms/new-console-template for more information

using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using DynamicData;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Mutagen.Bethesda;
using Mutagen.Bethesda.Environments;
using Mutagen.Bethesda.Plugins;
using Mutagen.Bethesda.Skyrim;
using Spriggan.Converters.Base;
using Spriggan.TupleGen;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((c, s) =>
    {
        s.UseConverters();
        s.UseBaseConverters();
    })
    .Build();

var services = host.Services;
var converters = services.GetRequiredService<IEnumerable<JsonConverter>>();
var soptions = new JsonSerializerOptions();
soptions.Converters.AddRange(converters);
soptions.WriteIndented = true;
soptions.Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping;

using var env = GameEnvironment.Typical.Skyrim(SkyrimRelease.SkyrimSE);
foreach (var armor in env.LoadOrder.PriorityOrder.Armor().WinningOverrides())
{
    
    Console.WriteLine($"{armor.FormKey} - {armor.EditorID ?? ""}");
    var stream = new MemoryStream();
    JsonSerializer.Serialize(stream, armor, soptions);
    var str = Encoding.UTF8.GetString(stream.ToArray());
    //File.WriteAllText($@"c:\tmp\armor\{(armor.FormKey.ID.ToString("x8"))}.json", str);

    stream.Position = 0;
    var value = JsonSerializer.Deserialize<Armor>(stream, soptions);

}