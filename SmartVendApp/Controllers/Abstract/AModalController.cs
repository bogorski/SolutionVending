using SmartVendApp.Services;

namespace SmartVendApp.Controllers.Abstract
{
    public abstract class AModalController<T> where T : new()
    {
        protected readonly IDataStore<T, int> _dataStore;
        public bool ShowModal { get; set; }
        public T CurrentItem { get; set; } = new T();
        public bool IsNew { get; set; }
        public string Title { get; protected set; } = string.Empty;
        protected AModalController(IDataStore<T, int> dataStore)
        {
            _dataStore = dataStore;
        }
        public virtual async Task<bool> SaveAsync()
        {
            try
            {
                var result = IsNew
                    ? await _dataStore.AddItemAsync(CurrentItem)
                    : await _dataStore.UpdateItemAsync(CurrentItem);

                if (result)
                {
                    CloseModal();
                }
                else
                {
                    System.Diagnostics.Debug.Print("Operacja zapisu nie powiodła się");
                }

                return result;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print($"Błąd podczas zapisu: {ex.Message}");
                return false;
            }
        }

        public void ShowAddModal()
        {
            CurrentItem = new T();
            IsNew = true;
            ShowModal = true;
        }

        public void ShowEditModal(T item)
        {
            CurrentItem = item;
            IsNew = false;
            ShowModal = true;
        }

        public void CloseModal() => ShowModal = false;
    }
}