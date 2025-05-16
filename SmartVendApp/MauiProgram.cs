using Microsoft.Extensions.Logging;

using SmartVendApp.Services;
using SmartVendApp.Controllers;
using SmartVendApp.ServiceReference;
using SmartVendApp.Controllers.Dostawcy;
using SmartVendApp.Controllers.Interface;
using SmartVendApp.Controllers.Faktury;
using SmartVendApp.Controllers.Lokalizacje;
using SmartVendApp.Controllers.Magazyny;
using SmartVendApp.Controllers.Pojazdy;
using SmartVendApp.Controllers.StanowiskaPracy;
using SmartVendApp.Controllers.Towary;
using SmartVendApp.Controllers.Trasy;
using SmartVendApp.Controllers.Warsztaty;

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
            builder.Services.AddSingleton<LokalizacjeDataStore>();
            

            builder.Services.AddSingleton<IDataStore<DostawcyForView>, DostawcyDataStore>();
            builder.Services.AddSingleton<IDataStore<FakturyForView>, FakturyDataStore>();
            builder.Services.AddSingleton<IDataStore<LokalizacjeForView>, LokalizacjeDataStore>();


            builder.Services.AddSingleton<DostawcyModalController>();
            builder.Services.AddSingleton<DostawcyController>();
            
            builder.Services.AddSingleton<FakturyModalController>();
            builder.Services.AddSingleton<FakturyController>();

            builder.Services.AddSingleton<LokalizacjeModalController>();
            builder.Services.AddSingleton<LokalizacjeController>();

            builder.Services.AddSingleton<IModalController<DostawcyForView>, DostawcyModalController>();
            builder.Services.AddScoped<IListController<DostawcyForView>, DostawcyController>(); 
            
            builder.Services.AddSingleton<IModalController<FakturyForView>, FakturyModalController>();
            builder.Services.AddScoped<IListController<FakturyForView>, FakturyController>();

            builder.Services.AddSingleton<IModalController<LokalizacjeForView>, LokalizacjeModalController>();
            builder.Services.AddScoped<IListController<LokalizacjeForView>, LokalizacjeController>();

            builder.Services.AddSingleton<IDataStore<MagazynyForView>, MagazynyDataStore>();
            builder.Services.AddSingleton<MagazynyDataStore>();
            builder.Services.AddSingleton<MagazynyModalController>();
            builder.Services.AddSingleton<MagazynyController>();
            builder.Services.AddSingleton<IModalController<MagazynyForView>, MagazynyModalController>();
            builder.Services.AddScoped<IListController<MagazynyForView>, MagazynyController>();

            builder.Services.AddSingleton<IDataStore<StanowiskaPracyForView>, StanowiskaPracyDataStore>();
            builder.Services.AddSingleton<StanowiskaPracyDataStore>();
            builder.Services.AddSingleton<StanowiskaPracyModalController>();
            builder.Services.AddSingleton<StanowiskaPracyController>();
            builder.Services.AddSingleton<IModalController<StanowiskaPracyForView>, StanowiskaPracyModalController>();
            builder.Services.AddScoped<IListController<StanowiskaPracyForView>, StanowiskaPracyController>();

            builder.Services.AddSingleton<IDataStore<TowaryForView>, TowaryDataStore>();
            builder.Services.AddSingleton<TowaryDataStore>();
            builder.Services.AddSingleton<TowaryModalController>();
            builder.Services.AddSingleton<TowaryController>();
            builder.Services.AddSingleton<IModalController<TowaryForView>, TowaryModalController>();
            builder.Services.AddScoped<IListController<TowaryForView>, TowaryController>();

            builder.Services.AddSingleton<IDataStore<TrasyForView>, TrasyDataStore>();
            builder.Services.AddSingleton<TrasyDataStore>();
            builder.Services.AddSingleton<TrasyModalController>();
            builder.Services.AddSingleton<TrasyController>();
            builder.Services.AddSingleton<IModalController<TrasyForView>, TrasyModalController>();
            builder.Services.AddScoped<IListController<TrasyForView>, TrasyController>();

            builder.Services.AddSingleton<IDataStore<WarsztatyForView>, WarsztatyDataStore>();
            builder.Services.AddSingleton<WarsztatyDataStore>();
            builder.Services.AddSingleton<WarsztatyModalController>();
            builder.Services.AddSingleton<WarsztatyController>();
            builder.Services.AddSingleton<IModalController<WarsztatyForView>, WarsztatyModalController>();
            builder.Services.AddScoped<IListController<WarsztatyForView>, WarsztatyController>();

            builder.Services.AddSingleton<IDataStore<PojazdyForView>, PojazdyDataStore>();
            builder.Services.AddSingleton<PojazdyDataStore>();
            builder.Services.AddSingleton<PojazdyModalController>();
            builder.Services.AddSingleton<PojazdyController>();
            builder.Services.AddSingleton<IModalController<PojazdyForView>, PojazdyModalController>();
            builder.Services.AddScoped<IListController<PojazdyForView>, PojazdyController>();

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
