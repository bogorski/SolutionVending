using SmartVendApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartVendApp.Services
{
    public class MachineDataStore : IDataStore<Machine, string>
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
            var oldItem = items.FirstOrDefault(i => i.NumerMaszyny == item.NumerMaszyny);

            if (oldItem == null)
            {
                return await Task.FromResult(false);
            }

            oldItem.IdtypMaszyny = item.IdtypMaszyny;
            oldItem.NumerSeryjny = item.NumerSeryjny;
            oldItem.RokProdukcji = item.RokProdukcji;
            oldItem.Opis = item.Opis;
            oldItem.DataMontazu = item.DataMontazu;

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string? id)
        {
            if (id == null)
            {
                return await Task.FromResult(false);
            }

            var oldItem = items.FirstOrDefault(item => item.NumerMaszyny == id);
            if (oldItem == null)
            {
                return await Task.FromResult(false);
            }
            items.Remove(oldItem);
            return await Task.FromResult(true);
        }
        public async Task<Machine?> GetItemAsync(string id)
        {
            if (id == null)
            {
                return await Task.FromResult<Machine?>(null);
            }

            var item = items.FirstOrDefault(s => s.NumerMaszyny == id);
            return await Task.FromResult(item);
        }

        public async Task<IEnumerable<Machine>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items.AsEnumerable());
        }
    }
}