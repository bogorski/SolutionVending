using SmartVendApp.Services;
using SmartVendApp.Controllers.Abstract;
using SmartVendApp.ServiceReference;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace SmartVendApp.Controllers.Dostawcy
{
    public class DostawcyController : AListController<DostawcyForView, int>
    {
        public DostawcyModalController ModalController { get; }

        public DostawcyController(DostawcyDataStore dataStore, DostawcyModalController modalController)
            : base(dataStore)
        {
            ModalController = modalController;
            ModalController.OnSaved += async () => await LoadDataAsync();
        }

        public override async Task LoadDataAsync()
        {
            try
            {
                IsLoading = true;
                var items = await _dataStore.GetItemsAsync(true);
                Items = new ObservableCollection<DostawcyForView>(items);
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Błąd ładowania: {ex.Message}";
            }
            finally
            {
                IsLoading = false;
            }
        }

        public override async Task<bool> SaveItemAsync(DostawcyForView item)
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

        public override async Task<bool> DeleteItemAsync(int id)
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
    }
}