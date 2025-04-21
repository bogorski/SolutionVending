using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartVendApp.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddItemAsync(T item);
        Task<bool> UpdateItemAsync(T item);
        Task<bool> DeleteItemAsync(string NumerMaszyny);
        Task<T> GetItemAsync(string NumerMaszyny);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
    }
}
