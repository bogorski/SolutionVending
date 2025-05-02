using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartVendApp.Services
{
    public interface IDataStore<T, Tid>
    {
        Task<bool> AddItemAsync(T item);
        Task<bool> UpdateItemAsync(T item);
        Task<bool> DeleteItemAsync(Tid id);
        Task<T> GetItemAsync(Tid id);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
    }
}
