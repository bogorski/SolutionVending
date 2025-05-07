using Microsoft.Extensions.Logging;

using SmartVendApp.Services;
using SmartVendApp.Models;
using SmartVendApp.Controllers;
using SmartVendApp.ServiceReference;
using SmartVendApp.Controllers.Dostawcy;

namespace SmartVendApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });
            builder.Services.AddMauiBlazorWebView();
            //builder.Services.AddSingleton<IDataStore<Machine, string>, MachineDataStore>();
            builder.Services.AddSingleton<DostawcyDataStore>();
            builder.Services.AddSingleton<IDataStore<DostawcyForView>, DostawcyDataStore>();

            builder.Services.AddSingleton<DostawcyModalController>();
            builder.Services.AddSingleton<DostawcyController>();

            builder.Services.AddSingleton<VendingService>();
            builder.Services.AddScoped(sp => new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7198") // ← Podaj prawidłowy adres API
            });

            builder.Services.AddScoped(sp =>
            {
                var httpClient = sp.GetRequiredService<HttpClient>(); // Pobranie HttpClient z DI
                var baseUrl = "https://localhost:7198";  // Adres URL API
                return new VendingService(baseUrl, httpClient);
            });
            builder.Services.AddAutoMapper(cfg =>
            {
                cfg.CreateMap<DostawcyForView, DostawcyForView>();
            });
#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();  
#endif

            return builder.Build();
        }
    }
}
