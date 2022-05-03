using Microsoft.Extensions.DependencyInjection;

namespace Spriggan.Converters.Skyrim.Tests;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.UseConverters();
    }
}