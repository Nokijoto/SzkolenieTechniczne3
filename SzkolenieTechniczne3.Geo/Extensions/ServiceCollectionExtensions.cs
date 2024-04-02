using System.Runtime.CompilerServices;
using SzkolenieTechniczne3.Geo.Services;
using SzkolenieTechniczne3.Geo.Storage;

namespace SzkolenieTechniczne3.Geo.Extensions
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddGeoServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<CountryService> ();
            serviceCollection.AddTransient<CityService>();
            serviceCollection.AddDbContext<GeoDbContext,GeoDbContext> ();
            return serviceCollection;
        }
    }
}
