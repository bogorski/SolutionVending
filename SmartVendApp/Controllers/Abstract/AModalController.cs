using Newtonsoft.Json;
using SmartVendApp.Helpers;
using SmartVendApp.Services;

namespace SmartVendApp.Controllers.Abstract
{
    public abstract class AModalController<T> where T : new()
    {
        protected readonly IDataStore<T, int> _dataStore;
        public bool ShowModal { get; set; }
        public bool ShowDeleteModal { get; set; }
        public T CurrentItem { get; set; } = new T();
        public bool IsNew { get; set; }
        public string Title { get; protected set; } = string.Empty;
        public bool ShowSuccess { get; set; }
        public bool ShowError { get; set; }
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

        public void DeleteModal(T item)
        {
            //  CurrentItem = item;  // Ustawia element do usunięcia
            //  ShowDeleteModal = true;  // Ustawia stan modala usuwania na widoczny
            if (item == null)
            {
                System.Diagnostics.Debug.Print("Brak elementu do usunięcia");
                return;
            }

            CurrentItem = item;
            ShowDeleteModal = true;
        }
        public void CloseDeleteModal() => ShowDeleteModal = false;

        public virtual async Task<bool> DeleteAsync()
        {
            try
            {
                if (CurrentItem == null)
                {
                    System.Diagnostics.Debug.Print("Brak elementu do usunięcia");
                    ShowSuccess = false;
                    ShowError = true;
                    return false;
                }

                bool result = await _dataStore.DeleteItemAsync(GetItemId(CurrentItem)).HandleRequest();

                if (result)
                {
                    CloseDeleteModal();
                    ShowSuccess = true;
                    ShowError = false;
                    System.Diagnostics.Debug.Print("Operacja usuwania powiodła się");
                }
                else
                {
                    ShowSuccess = false;
                    ShowError = true;
                    System.Diagnostics.Debug.Print("Operacja usuwania nie powiodła się");
                }

                return result;
            }
            catch (Exception ex)
            {
                ShowSuccess = false;
                ShowError = true;
                System.Diagnostics.Debug.Print($"Błąd podczas usuwania: {ex.Message}");
                return false;
            }
        }
        public abstract int GetItemId(T item);
    }
}