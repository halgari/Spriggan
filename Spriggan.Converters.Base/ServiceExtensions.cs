using System.Text.Json.Serialization;
using Microsoft.Extensions.DependencyInjection;

namespace Spriggan.Converters.Base;

public static class ServiceExtensions
{
    public static IServiceCollection UseBaseConverters(this IServiceCollection services)
    {

        return services;
    }
    
}