using SmartVendApp.Helpers;
using SmartVendApp.ServiceReference;
using SmartVendApp.Services.Abstract;

namespace SmartVendApp.Services
{
    public class PracownicyDataStore : AListDataStore<PracownicyForView>
    {
        private readonly VendingService _vendingService;

        public PracownicyDataStore(VendingService vendingService)
        {
            _vendingService = vendingService;
        }

        protected override async Task<bool> PerformAddItemToService(PracownicyForView item)
        {
            return await _vendingService.PracowniciesPOSTAsync(item).HandleRequest();
        }
        protected override async Task<bool> PerformUpdateAsync(PracownicyForView item)
        {
            return await _vendingService.PracowniciesPUTAsync(item.Idpracownika, item).HandleRequest();
        }
        protected override async Task<bool> PerformDeleteItemFromService(PracownicyForView item)
        {
            return await _vendingService.PracowniciesDELETEAsync(item.Idpracownika).HandleRequest();
        }
        protected override async Task<IEnumerable<PracownicyForView>> FetchAllItemsAsync()
        {
            return await _vendingService.PracowniciesAllAsync();
        }
        protected override int GetItemId(PracownicyForView item)
        {
            return item.Idpracownika;
        }
    }
}
