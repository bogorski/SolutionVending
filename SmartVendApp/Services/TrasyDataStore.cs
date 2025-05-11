using SmartVendApp.ServiceReference;
using SmartVendApp.Services.Abstract;
using SmartVendApp.Helpers;

namespace SmartVendApp.Services
{
    public class TrasyDataStore : AListDataStore<TrasyForView>
    {
        private readonly VendingService _vendingService;

        public TrasyDataStore(VendingService vendingService)
        {
            _vendingService = vendingService;
        }

        protected override async Task<bool> PerformAddItemToService(TrasyForView item)
        {
            return await _vendingService.TrasiesPOSTAsync(item).HandleRequest();
        }
        protected override async Task<bool> PerformUpdateAsync(TrasyForView item)
        {
            return await _vendingService.TrasiesPUTAsync(item.Idtrasy, item).HandleRequest();
        }
        protected override async Task<bool> PerformDeleteItemFromService(TrasyForView item)
        {
            return await _vendingService.TrasiesDELETEAsync(item.Idtrasy).HandleRequest();
        }
        protected override async Task<IEnumerable<TrasyForView>> FetchAllItemsAsync()
        {
            return await _vendingService.TrasiesAllAsync();
        }
        protected override int GetItemId(TrasyForView item)
        {
            return item.Idtrasy;
        }
    }
}
