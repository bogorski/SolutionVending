using SmartVendApp.Models;
using SmartVendApp.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartVendApp.Controllers
{
    public class MachineController
    {
        private readonly IDataStore<Machine> _machineStore;
        private List<Machine> _machines;

        public MachineController(IDataStore<Machine> machineStore)
        {
            _machineStore = machineStore;
            _machines = new List<Machine>();

        }
        public async Task LoadMachineAsync()
        {
            try
            {
                var items = await _machineStore.GetItemsAsync(true);
                _machines = new List<Machine>(items);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading clients: {ex.Message}");
            }
        }
        public List<Machine> GetMachines() => _machines;
    }
}
