using SmartVendApp.Helpers;
using SmartVendApp.ServiceReference;
using SmartVendApp.Services.Abstract;

namespace SmartVendApp.Services
{
    public class MagazynyDataStore : AListDataStore<MagazynyForView>
    {
        private readonly VendingService _vendingService;

        public MagazynyDataStore(VendingService vendingService)
        {
            _vendingService = vendingService;
        }

        protected override async Task<bool> PerformAddItemToService(MagazynyForView item)
        {
            return await _vendingService.MagazyniesPOSTAsync(item).HandleRequest();
        }
        protected override async Task<bool> PerformUpdateAsync(MagazynyForView item)
        {
            return await _vendingService.MagazyniesPUTAsync(item.Idmagazynu, item).HandleRequest();
        }
        protected override async Task<bool> PerformDeleteItemFromService(MagazynyForView item)
        {
            return await _vendingService.MagazyniesDELETEAsync(item.Idmagazynu).HandleRequest();
        }
        protected override async Task<IEnumerable<MagazynyForView>> FetchAllItemsAsync()
        {
            return await _vendingService.MagazyniesAllAsync();
        }
        protected override int GetItemId(MagazynyForView item)
        {
            return item.Idmagazynu;
        }
    }
}
