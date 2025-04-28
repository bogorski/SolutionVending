using SmartVendApp.ServiceReference;

namespace SmartVendApp.Services.Abstract
{
    public abstract class ADataStore
    {
        protected VendingService vendingService;

        public ADataStore()
        {
            vendingService = new VendingService("https://localhost:7198", new System.Net.Http.HttpClient());
        }
    }
}