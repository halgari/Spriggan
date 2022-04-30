using System.Text.Json.Serialization;
using Microsoft.Extensions.DependencyInjection;

namespace Spriggan.Converters.Base;

public static class ServiceExtensions
{
    public static IServiceCollection UseBaseConverters(this IServiceCollection services)
    {
        services.AddSingleton<JsonConverter, P3Int16_Converter>();
        services.AddSingleton<JsonConverter, ITranslatedStringGetter_Converter>();
        return services;
    }
    
}