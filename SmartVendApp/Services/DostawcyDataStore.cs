using SmartVendApp.ServiceReference;
using SmartVendApp.Services.Abstract;
using SmartVendApp.Helpers;

namespace SmartVendApp.Services
{
    public class DostawcyDataStore : AListDataStore<DostawcyForView, int>
    {
        private readonly VendingService _vendingService;

        public DostawcyDataStore(VendingService vendingService)
        {
            _vendingService = vendingService;
        }

        public override async Task<bool> AddItemToService(DostawcyForView item)
        {
            try
            {
                var result = await _vendingService.DostawciesPOSTAsync(item).HandleRequest();
                if (result) await Refresh();
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd dodawania dostawcy: {ex.Message}");
                return false;
            }
        }

        public override async Task<bool> DeleteItemFromService(DostawcyForView item)
        {
            try
            {
                var result = await _vendingService.DostawciesDELETEAsync(item.Iddostawcy).HandleRequest();
                if (result) await Refresh();
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd usuwania dostawcy: {ex.Message}");
                return false;
            }
        }

        public override DostawcyForView Find(DostawcyForView item)
            => items.FirstOrDefault(d => d.Iddostawcy == item.Iddostawcy);

        public override DostawcyForView Find(int id)
            => items.FirstOrDefault(d => d.Iddostawcy == id);

        public override async Task Refresh()
        {
            try
            {
                var result = await _vendingService.DostawciesAllAsync();
                items = result?.ToList() ?? new List<DostawcyForView>();
            }
            catch (Exception ex)
            {
                items = new List<DostawcyForView>();
                Console.WriteLine($"Błąd odświeżenia: {ex.Message}");
            }
        }
        public override async Task<bool> UpdateItemInService(DostawcyForView item)
        {
            try
            {
                var result = await _vendingService.DostawciesPUTAsync(item.Iddostawcy, item).HandleRequest();
                if (result) await Refresh();
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd aktualizacji dostawcy: {ex.Message}");
                return false;
            }
        }
    }
}
