using SmartVendApp.ServiceReference;
using SmartVendApp.Services.Abstract;
using SmartVendApp.Helpers;

namespace SmartVendApp.Services
{
    public class DostawcyDataStore : AListDataStore<DostawcyForView>
    {
        private readonly VendingService _vendingService;

        public DostawcyDataStore(VendingService vendingService)
        {
            _vendingService = vendingService;
        }

        protected override async Task<bool> PerformAddItemToService(DostawcyForView item)
        {
            return await _vendingService.DostawciesPOSTAsync(item).HandleRequest();
        }
        protected override async Task<bool> PerformUpdateAsync(DostawcyForView item)
        {
            return await _vendingService.DostawciesPUTAsync(item.Iddostawcy, item).HandleRequest();
        }
        protected override async Task<bool> PerformDeleteItemFromService(DostawcyForView item)
        {
            return await _vendingService.DostawciesDELETEAsync(item.Iddostawcy).HandleRequest();
        }
        protected override async Task<IEnumerable<DostawcyForView>> FetchAllItemsAsync()
        {
            return await _vendingService.DostawciesAllAsync();
        }
        protected override int GetItemId(DostawcyForView item)
        {
            return item.Iddostawcy;
        }
    }
}
