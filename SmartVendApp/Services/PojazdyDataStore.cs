using SmartVendApp.Helpers;
using SmartVendApp.ServiceReference;
using SmartVendApp.Services.Abstract;

namespace SmartVendApp.Services
{
    public class PojazdyDataStore : AListDataStore<PojazdyForView>
    {
        private readonly VendingService _vendingService;

        public PojazdyDataStore(VendingService vendingService)
        {
            _vendingService = vendingService;
        }

        protected override async Task<bool> PerformAddItemToService(PojazdyForView item)
        {
            return await _vendingService.PojazdiesPOSTAsync(item).HandleRequest();
        }
        protected override async Task<bool> PerformUpdateAsync(PojazdyForView item)
        {
            return await _vendingService.PojazdiesPUTAsync(item.Idpojazdu, item).HandleRequest();
        }
        protected override async Task<bool> PerformDeleteItemFromService(PojazdyForView item)
        {
            return await _vendingService.PojazdiesDELETEAsync(item.Idpojazdu).HandleRequest();
        }
        protected override async Task<IEnumerable<PojazdyForView>> FetchAllItemsAsync()
        {
            return await _vendingService.PojazdiesAllAsync();
        }
        protected override int GetItemId(PojazdyForView item)
        {
            return item.Idpojazdu;
        }
    }
}
