using SmartVendApp.Services;
using SmartVendApp.Controllers.Interface;

namespace SmartVendApp.Controllers.Abstract
{
    public abstract class AListController<T> : IListController<T> where T : new()
    {
        protected readonly IDataStore<T> _dataStore;

        public bool IsLoading { get; set; }
        public string ErrorMessage { get; set; }
        public List<T> Items { get; set; } = new();
        protected AListController(IDataStore<T> dataStore)
        {
            _dataStore = dataStore;
        }

        public virtual async Task LoadDataAsync()
        {
            try
            {
                IsLoading = true;
                Items = (List<T>)await _dataStore.GetItemsAsync();
                ErrorMessage = string.Empty;
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Błąd ładowania: {ex.Message}";
                Items = new List<T>();
            }
            finally
            {
                IsLoading = false;
            }
        }
        public virtual async Task<bool> SaveItemAsync(T item)
        {
            try
            {
                bool result = IsNewItem(item)
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
        public virtual async Task<bool> DeleteItemAsync(T item)
        {
            if (item == null)
            {
                ErrorMessage = "Item cannot be null!";
                return false;
            }
            try
            {
                bool result = await _dataStore.DeleteItemAsync(item);
                if (result) await LoadDataAsync();
                return result;
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Błąd usuwania: {ex.Message}";
                System.Diagnostics.Debug.Print($"Błąd usuwania: {ex}");
                return false;
            }
        }
        protected abstract bool IsNewItem(T item);
    }
}