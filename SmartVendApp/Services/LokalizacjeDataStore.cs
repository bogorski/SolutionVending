using SmartVendApp.Helpers;
using SmartVendApp.ServiceReference;
using SmartVendApp.Services.Abstract;

namespace SmartVendApp.Services
{
    public class LokalizacjeDataStore : AListDataStore<LokalizacjeForView>
    {
        private readonly VendingService _vendingService;

        public LokalizacjeDataStore(VendingService vendingService)
        {
            _vendingService = vendingService;
        }

        protected override async Task<bool> PerformAddItemToService(LokalizacjeForView item)
        {
            return await _vendingService.LokalizacjesPOSTAsync(item).HandleRequest();
        }
        protected override async Task<bool> PerformUpdateAsync(LokalizacjeForView item)
        {
            return await _vendingService.LokalizacjesPUTAsync(item.Idlokalizacji, item).HandleRequest();
        }
        protected override async Task<bool> PerformDeleteItemFromService(LokalizacjeForView item)
        {
            return await _vendingService.LokalizacjesDELETEAsync(item.Idlokalizacji).HandleRequest();
        }
        protected override async Task<IEnumerable<LokalizacjeForView>> FetchAllItemsAsync()
        {
            return await _vendingService.LokalizacjesAllAsync();
        }
        protected override int GetItemId(LokalizacjeForView item)
        {
            return item.Idlokalizacji;
        }
    }
}
