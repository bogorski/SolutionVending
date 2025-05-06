namespace SmartVendApp.Services.Abstract
{
    public abstract class AListDataStore<T, Tid> : IDataStore<T, Tid>
    {
        public List<T> items;
        public AListDataStore()
        {
        }
        public abstract Task Refresh();
        public abstract Task<bool> DeleteItemFromService(T item);
        public abstract Task<bool> UpdateItemInService(T item);
        public abstract Task<bool> AddItemToService(T item);
        public abstract Task<T> FindAsync(T item);
        public abstract Task<T> FindAsync(Tid id);

        public async Task<bool> AddItemAsync(T item)
        {
            await AddItemToService(item);
            await Refresh();
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(T item)
        {
            await UpdateItemInService(item);
            await Refresh();
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(Tid id)
        {
            var oldItem = await FindAsync(id);
            if (oldItem == null) return false;

            await DeleteItemFromService(oldItem);
            await Refresh();
            return await Task.FromResult(true);
        }

        public async Task<T> GetItemAsync(Tid id) => await Task.FromResult(await FindAsync(id));

        public async Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false)
        {
            await Refresh();
            return await Task.FromResult(items);
        }
    }
}