using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Api.Startup))]

namespace Api;

public class Startup : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
    {
        builder.Services.AddSingleton<IProductData, ProductData>();
        // Registrar AcademiaData como un servicio Singleton
        //Esto significa que solo habrá una instancia AcademiaData
        builder.Services.AddSingleton<IAcademiaData, AcademiaData>();

    }
}
