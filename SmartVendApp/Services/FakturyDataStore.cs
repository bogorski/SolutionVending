using SmartVendApp.Helpers;
using SmartVendApp.ServiceReference;
using SmartVendApp.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartVendApp.Services
{
    public class FakturyDataStore : AListDataStore<FakturyForView>
    {
        private readonly VendingService _vendingService;

        public FakturyDataStore(VendingService vendingService)
        {
            _vendingService = vendingService;
        }

        protected override async Task<bool> PerformAddItemToService(FakturyForView item)
        {
            return await _vendingService.FakturiesPOSTAsync(item).HandleRequest();
        }
        protected override async Task<bool> PerformUpdateAsync(FakturyForView item)
        {
            return await _vendingService.FakturiesPUTAsync(item.Idfaktury, item).HandleRequest();
        }
        protected override async Task<bool> PerformDeleteItemFromService(FakturyForView item)
        {
            return await _vendingService.FakturiesDELETEAsync(item.Idfaktury).HandleRequest();
        }
        protected override async Task<IEnumerable<FakturyForView>> FetchAllItemsAsync()
        {
            return await _vendingService.FakturiesAllAsync();
        }
        protected override int GetItemId(FakturyForView item)
        {
            return item.Idfaktury;
        }
    }
}
