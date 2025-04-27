using SmartVendApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartVendApp.Services
{
    public class MachineDataStore : IDataStore<Machine>
    {
        readonly List<Machine> items;
        public MachineDataStore()
        {
            items = new List<Machine>()
            {
                new Machine
                {
                    NumerMaszyny = "K100",
                    IdtypMaszyny = "Coffee",
                    NumerSeryjny = "Rt15DF552dS",
                    RokProdukcji = new DateTime(2020, 1, 1),
                    Opis = "brak",
                    DataMontazu = new DateTime(2020, 5, 1)
                },
                new Machine
                {
                    NumerMaszyny = "K101",
                    IdtypMaszyny = "Soda",
                    NumerSeryjny = "Rt15DF552dA",
                    RokProdukcji = new DateTime(2020, 12, 12),
                    Opis = "Nowa maszyna",
                    DataMontazu = new DateTime(2021, 7, 15)
                }
            };
        }
        public async Task<bool> AddItemAsync(Machine item)
        {
            items.Add(item);
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Machine item)
        {
            var oldItem = items.Where((Machine arg) => arg.NumerMaszyny == item.NumerMaszyny).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Machine arg) => arg.NumerMaszyny == id).FirstOrDefault();
            items.Remove(oldItem);
            return await Task.FromResult(true);
        }

        public async Task<Machine?> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.NumerMaszyny == id));
        }

        public async Task<IEnumerable<Machine>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items.AsEnumerable());
        }
    }
}