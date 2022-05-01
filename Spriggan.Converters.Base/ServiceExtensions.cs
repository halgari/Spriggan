using System.Text.Json.Serialization;
using Microsoft.Extensions.DependencyInjection;

namespace Spriggan.Converters.Base;

public static class ServiceExtensions
{
    public static IServiceCollection UseBaseConverters(this IServiceCollection services)
    {
        services.AddSingleton<JsonConverter, P3Int16_Converter>();
        return services;
    }
    
}