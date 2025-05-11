using SmartVendApp.ServiceReference;
using SmartVendApp.Services.Abstract;
using SmartVendApp.Helpers;

namespace SmartVendApp.Services
{
    public class TowaryDataStore : AListDataStore<TowaryForView>
    {
        private readonly VendingService _vendingService;

        public TowaryDataStore(VendingService vendingService)
        {
            _vendingService = vendingService;
        }

        protected override async Task<bool> PerformAddItemToService(TowaryForView item)
        {
            return await _vendingService.TowariesPOSTAsync(item).HandleRequest();
        }
        protected override async Task<bool> PerformUpdateAsync(TowaryForView item)
        {
            return await _vendingService.TowariesPUTAsync(item.Idtowaru, item).HandleRequest();
        }
        protected override async Task<bool> PerformDeleteItemFromService(TowaryForView item)
        {
            return await _vendingService.TowariesDELETEAsync(item.Idtowaru).HandleRequest();
        }
        protected override async Task<IEnumerable<TowaryForView>> FetchAllItemsAsync()
        {
            return await _vendingService.TowariesAllAsync();
        }
        protected override int GetItemId(TowaryForView item)
        {
            return item.Idtowaru;
        }
    }
}
