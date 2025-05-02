using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using SmartVendApp.Services;


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
        public async Task<bool> AddItemAsync(T item)
        {
            await AddItemToService(item);
            await Refresh();
            return await Task.FromResult(true);
        }
        public abstract T Find(T item);
        public abstract T Find(Tid id);
        public async Task<bool> UpdateItemAsync(T item)
        {
            await UpdateItemInService(item);
            await Refresh();
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(Tid id)
        {
            var oldItem = Find(id);
            await DeleteItemFromService(oldItem);
            await Refresh();
            return await Task.FromResult(true);
        }

        public async Task<T> GetItemAsync(Tid id)
            => await Task.FromResult(Find(id));

        public async Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false)
        {
            await Refresh();
            return await Task.FromResult(items);
        }
    }
}
