using SmartVendApp.ServiceReference;
using SmartVendApp.Services.Abstract;
using SmartVendApp.Helpers;

namespace SmartVendApp.Services
{
    public class WarsztatyDataStore : AListDataStore<WarsztatyForView>
    {
        private readonly VendingService _vendingService;

        public WarsztatyDataStore(VendingService vendingService)
        {
            _vendingService = vendingService;
        }

        protected override async Task<bool> PerformAddItemToService(WarsztatyForView item)
        {
            return await _vendingService.WarsztatiesPOSTAsync(item).HandleRequest();
        }
        protected override async Task<bool> PerformUpdateAsync(WarsztatyForView item)
        {
            return await _vendingService.WarsztatiesPUTAsync(item.Idwarsztatu, item).HandleRequest();
        }
        protected override async Task<bool> PerformDeleteItemFromService(WarsztatyForView item)
        {
            return await _vendingService.WarsztatiesDELETEAsync(item.Idwarsztatu).HandleRequest();
        }
        protected override async Task<IEnumerable<WarsztatyForView>> FetchAllItemsAsync()
        {
            return await _vendingService.WarsztatiesAllAsync();
        }
        protected override int GetItemId(WarsztatyForView item)
        {
            return item.Idwarsztatu;
        }
    }
}
