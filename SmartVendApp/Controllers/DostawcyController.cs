using SmartVendApp.Services;
using SmartVendApp.Controllers.Abstract;
using SmartVendApp.ServiceReference;

namespace SmartVendApp.Controllers
{
    public class DostawcyController : AItemController<DostawcyForView, int>
    {
        private readonly IDataStore<DostawcyForView, int> _dataStore;

        public DostawcyController(IDataStore<DostawcyForView, int> dataStore)
        {
            _dataStore = dataStore;
        }

        protected override async Task LoadDataAsync()
        {
            IsLoading = true;
            try
            {
                var items = await _dataStore.GetItemsAsync(true);
                Items = new List<DostawcyForView>(items);
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Błąd ładowania danych: {ex.Message}";
            }
            finally
            {
                IsLoading = false;
            }
        }

        protected override async Task<bool> SaveItemAsync(DostawcyForView item)
        {
            try
            {
                bool result = item.Iddostawcy == 0
                    ? await _dataStore.AddItemAsync(item)
                    : await _dataStore.UpdateItemAsync(item);

                if (result) await LoadDataAsync();
                return result;
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Błąd zapisu: {ex.Message}";
                return false;
            }
        }

        protected override async Task<bool> DeleteItemAsync(int id)
        {
            try
            {
                bool result = await _dataStore.DeleteItemAsync(id);
                if (result) await LoadDataAsync();
                return result;
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Błąd usuwania: {ex.Message}";
                return false;
            }
        }

        // Dodatkowa metoda specyficzna dla kontrolera
        public List<DostawcyForView> PobierzDostawcow() => Items;
    }
}
