using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartVendApp.Controllers.Interface
{
    public interface IModalController<T> //where T : new()
    {
        // Properties
        bool ShowModal { get; set; }
        bool ShowDeleteModal { get; set; }
        T CurrentItem { get; set; }
        bool IsNew { get; set; }
        string Title { get; }
        bool ShowSuccess { get; set; }
        bool ShowError { get; set; }
        List<T> Items { get; set; }  // Dodane do obsługi listy
        bool IsLoading { get; set; } // Dodane do obsługi stanu ładowania

        // Methods
        Task<bool> SaveAsync();
        Task<bool> DeleteAsync();
        Task LoadItemsAsync();       // Dodane do ładowania danych
        void ShowAddModal();
        void ShowEditModal(T item);
        void ShowDeleteConfirmationModal(T item);
        void CloseModal();
        void CloseDeleteModal();
        int GetItemId(T item);
        string GetDisplayName(T item);
        string GetDisplayDetails(T item);
    }
}
