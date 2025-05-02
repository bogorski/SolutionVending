using SmartVendApp.ServiceReference;
using SmartVendApp.Services.Abstract;
using SmartVendApp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SmartVendApp.Services
{
    public class DostawcyDataStore : AListDataStore<DostawcyForView, int>
    {
        private readonly VendingService _vendingService;
        public List<DostawcyForView> _items = new List<DostawcyForView>();

        public DostawcyDataStore(VendingService vendingService)
        {
            _vendingService = vendingService;
        }

        private async Task InitializeAsync()
        {
            try
            {
                await Refresh();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd inicjalizacji dostawców: {ex.Message}");
            }
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
            => _items.FirstOrDefault(d => d.Iddostawcy == item.Iddostawcy);

        public override DostawcyForView Find(int id)
            => _items.FirstOrDefault(d => d.Iddostawcy == id);

        public override async Task Refresh()
        {
            _items = (List<DostawcyForView>)(await _vendingService.DostawciesAllAsync() ?? new List<DostawcyForView>());
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
