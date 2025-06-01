namespace SmartVendApp.Controllers.Interface
{
    public interface IListController<T>
    {
        bool IsLoading { get; set; }
        string ErrorMessage { get; set; }
        List<T> Items { get; set; }

        Task LoadDataAsync();
        Task<bool> SaveItemAsync(T item);
        Task<bool> DeleteItemAsync(T item);
    }
}