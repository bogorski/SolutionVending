using SmartVendApp.Helpers;
using SmartVendApp.ServiceReference;
using SmartVendApp.Services.Abstract;

namespace SmartVendApp.Services
{
    public class MagazynTowaryDataStore : AListDataStore<MagazynTowaryForView>
    {
        private readonly VendingService _vendingService;

        public MagazynTowaryDataStore(VendingService vendingService)
        {
            _vendingService = vendingService;
        }

        protected override async Task<bool> PerformAddItemToService(MagazynTowaryForView item)
        {
            return await _vendingService.MagazynTowariesPOSTAsync(item).HandleRequest();
        }
        protected override async Task<bool> PerformUpdateAsync(MagazynTowaryForView item)
        {
            return await _vendingService.MagazynTowariesPUTAsync(item.Idmagazynu, item.Idtowaru, item).HandleRequest();
        }
        protected override async Task<bool> PerformDeleteItemFromService(MagazynTowaryForView item)
        {
            return await _vendingService.MagazynTowariesDELETEAsync(item.Idmagazynu, item.Idtowaru).HandleRequest();
        }
        protected override async Task<IEnumerable<MagazynTowaryForView>> FetchAllItemsAsync()
        {
            return await _vendingService.MagazynTowariesAllAsync();
        }
        protected override int GetItemId(MagazynTowaryForView item)
        {
            throw new NotImplementedException();
        }
    }
}
