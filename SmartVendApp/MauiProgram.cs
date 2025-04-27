using Microsoft.Extensions.Logging;

using SmartVendApp.Services;
using SmartVendApp.Models;
using SmartVendApp.Controllers;
using SmartVendApp.ServiceReference;
using Microsoft.Extensions.Configuration;

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
            builder.Services.AddSingleton<IDataStore<Machine>, MachineDataStore>();
            builder.Services.AddSingleton<MachineController>();

            //builder.Services.AddSingleton<HttpClient>(sp =>
            //{
            //    var client = new HttpClient
            //    {
            //        BaseAddress = new Uri("https://localhost:7052") // Adres URL do API
            //    };
            //    return client;
            //});
            //   builder.Services.AddScoped<VendingService>();
            builder.Services.AddScoped(sp => new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7052") // ← Podaj prawidłowy adres API
            });
            //builder.Services.AddSingleton<HttpClient>(s =>
            //{
            //    return new HttpClient { BaseAddress = new Uri("https://localhost:7052") };
            //});
            builder.Services.AddSingleton<VendingService>(sp =>
            {
                var httpClient = sp.GetRequiredService<HttpClient>(); // Pobranie HttpClient z DI
                var baseUrl = "https://localhost:7052";  // Adres URL API
                return new VendingService(baseUrl, httpClient);
            });

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();  
#endif

            return builder.Build();
        }
    }
}
