namespace SmartVendApp.Services.Abstract
{
    public abstract class AListDataStore<T> : IDataStore<T>
    {
        protected List<T> items;
        public AListDataStore()
        {
        }
        public virtual async Task Refresh()
        {
            try
            {
                var result = await FetchAllItemsAsync();
                items = result?.ToList() ?? new List<T>();
            }
            catch (Exception ex)
            {
                items = new List<T>();
                Console.WriteLine($"Błąd odświeżenia: {ex.Message}");
            }
        }
        public virtual async Task<bool> DeleteItemFromService(T item)
        {
            try
            {
                var result = await PerformDeleteItemFromService(item);
                if (result) await Refresh();
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd usuwania: {ex.Message}");
                return false;
            }
        }
        public virtual async Task<bool> UpdateItemInService(T item)
        {
            try
            {
                var result = await PerformUpdateAsync(item);
                if (result) await Refresh();
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd aktualizacji: {ex.Message}");
                return false;
            }
        }
        protected abstract int GetItemId(T item);
        protected abstract Task<bool> PerformUpdateAsync(T item);
        protected abstract Task<bool> PerformAddItemToService(T item);
        protected abstract Task<bool> PerformDeleteItemFromService(T item);
        protected abstract Task<IEnumerable<T>> FetchAllItemsAsync();
        public virtual async Task<bool> AddItemToService(T item)
        {
            try
            {
                var result = await PerformAddItemToService(item);
                if (result) await Refresh();
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd dodawania: {ex.Message}");
                return false;
            }
        }
        public virtual async Task<T> FindAsync(int id)
        {
            await Refresh();

            if (items == null || !items.Any())
            {
                System.Diagnostics.Debug.Print($"Kolekcja jest null lub pusta.");
                return default;
            }

            return items.FirstOrDefault(item => GetItemId(item) == id);
        }
        public virtual async Task<T> FindAsync(T item)
        {
            await Refresh();

            if (items == null || !items.Any())
            {
                System.Diagnostics.Debug.Print($"Kolekcja jest null lub pusta.");
                return default;
            }

            return items.FirstOrDefault(x => GetItemId(x) == GetItemId(item));
        }


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

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = await FindAsync(id);
            if (oldItem == null) return false;

            await DeleteItemFromService(oldItem);
            await Refresh();
            return await Task.FromResult(true);
        }

        public async Task<T> GetItemAsync(int id) => await Task.FromResult(await FindAsync(id));

        public async Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false)
        {
            await Refresh();
            return await Task.FromResult(items);
        }
    }
}