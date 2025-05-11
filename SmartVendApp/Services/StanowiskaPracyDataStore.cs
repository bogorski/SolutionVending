using SmartVendApp.ServiceReference;
using SmartVendApp.Services.Abstract;
using SmartVendApp.Helpers;

namespace SmartVendApp.Services
{
    public class StanowiskaPracyDataStore : AListDataStore<StanowiskaPracyForView>
    {
        private readonly VendingService _vendingService;

        public StanowiskaPracyDataStore(VendingService vendingService)
        {
            _vendingService = vendingService;
        }

        protected override async Task<bool> PerformAddItemToService(StanowiskaPracyForView item)
        {
            return await _vendingService.StanowiskaPraciesPOSTAsync(item).HandleRequest();
        }
        protected override async Task<bool> PerformUpdateAsync(StanowiskaPracyForView item)
        {
            return await _vendingService.StanowiskaPraciesPUTAsync(item.IdstanowiskaPracy, item).HandleRequest();
        }
        protected override async Task<bool> PerformDeleteItemFromService(StanowiskaPracyForView item)
        {
            return await _vendingService.StanowiskaPraciesDELETEAsync(item.IdstanowiskaPracy).HandleRequest();
        }
        protected override async Task<IEnumerable<StanowiskaPracyForView>> FetchAllItemsAsync()
        {
            return await _vendingService.StanowiskaPraciesAllAsync();
        }
        protected override int GetItemId(StanowiskaPracyForView item)
        {
            return item.IdstanowiskaPracy;
        }
    }
}
