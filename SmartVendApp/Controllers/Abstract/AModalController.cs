using Newtonsoft.Json;
using SmartVendApp.Controllers.Interface;
using SmartVendApp.Helpers;
using SmartVendApp.Services;

namespace SmartVendApp.Controllers.Abstract
{
    public abstract class AModalController<T> : IModalController<T> where T : new()
    {
        protected readonly IDataStore<T> _dataStore;
        public bool ShowModal { get; set; }
        public bool ShowDeleteModal { get; set; }
        public T CurrentItem { get; set; } = new T();
        public bool IsNew { get; set; }
        public string Title { get; protected set; } = string.Empty;
        public bool ShowSuccess { get; set; }
        public bool ShowError { get; set; }
        public List<T> Items { get; set; } = new List<T>();
        public bool IsLoading { get; set; }
        public abstract string GetDisplayName(T item);
        public abstract string GetDisplayDetails(T item);
        protected AModalController(IDataStore<T> dataStore)
        {
            _dataStore = dataStore;
        }
        public virtual async Task LoadItemsAsync()
        {
            try
            {
                IsLoading = true;
                Items = (await _dataStore.GetItemsAsync()).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd podczas ładowania danych: {ex.Message}");
                ShowError = true;
            }
            finally
            {
                IsLoading = false;
            }
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

        public virtual async Task<bool> DeleteAsync()
        {
            try
            {
                var itemId = GetItemId(CurrentItem);
                bool result = await _dataStore.DeleteItemAsync(itemId);

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
                System.Diagnostics.Debug.Print($"Błąd podczas usuwania: {ex.Message}");
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

        public void ShowDeleteConfirmationModal(T item)
        {
            CurrentItem = item;
            ShowDeleteModal = true;
        }
        public void CloseModal() => ShowModal = false;
        public void CloseDeleteModal() => ShowDeleteModal = false;

        public abstract int GetItemId(T item);

        
    }
}