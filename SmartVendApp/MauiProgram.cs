using Microsoft.Extensions.Logging;

using SmartVendApp.Services;
using SmartVendApp.Models;
using SmartVendApp.Controllers;
using SmartVendApp.ServiceReference;
using SmartVendApp.Controllers.Dostawcy;
using SmartVendApp.Controllers.Interface;
using SmartVendApp.Controllers.Faktury;

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

            builder.Services.AddSingleton<DostawcyDataStore>();
            builder.Services.AddSingleton<FakturyDataStore>();

            builder.Services.AddSingleton<IDataStore<DostawcyForView>, DostawcyDataStore>();
            builder.Services.AddSingleton<IDataStore<FakturyForView>, FakturyDataStore>();

            builder.Services.AddSingleton<DostawcyModalController>();
            builder.Services.AddSingleton<DostawcyController>();
            
            builder.Services.AddSingleton<FakturyModalController>();
            builder.Services.AddSingleton<FakturyController>();

            builder.Services.AddSingleton<IModalController<DostawcyForView>, DostawcyModalController>();
            builder.Services.AddScoped<IListController<DostawcyForView>, DostawcyController>(); 
            
            builder.Services.AddSingleton<IModalController<FakturyForView>, FakturyModalController>();
            builder.Services.AddScoped<IListController<FakturyForView>, FakturyController>();

            builder.Services.AddSingleton<VendingService>();
            builder.Services.AddScoped(sp => new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7198")
            });

            builder.Services.AddScoped(sp =>
            {
                var httpClient = sp.GetRequiredService<HttpClient>();
                var baseUrl = "https://localhost:7198";
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
