namespace SmartVendApp.Controllers.Interface
{
    public interface IModalController<T>
    {
        bool ShowModal { get; set; }
        bool ShowDeleteModal { get; set; }
        T CurrentItem { get; set; }
        bool IsNew { get; set; }
        string Title { get; }
        bool ShowSuccess { get; set; }
        bool ShowError { get; set; }
        List<T> Items { get; set; }
        bool IsLoading { get; set; }

        Task<bool> SaveAsync();
        Task<bool> DeleteAsync();  
        Task ShowAddModal();
        void ShowEditModal(T item);
        void ShowDeleteConfirmationModal(T item);
        void CloseModal();
        void CloseDeleteModal();
        int GetItemId(T item);
        string GetDisplayName(T item);
        string GetDisplayDetails(T item);
    }
}
