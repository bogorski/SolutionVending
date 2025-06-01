namespace SmartVendApp.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddItemAsync(T item);
        Task<bool> UpdateItemAsync(T item);
        Task<bool> DeleteItemAsync(T item);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
    }
}
