using SmartVendApp.Models;
using SmartVendApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartVendApp.Controllers
{
    public class DostawcyController
    {
        private readonly IDataStore<Dostawcy, int> _machineStore;
        private List<Dostawcy> _machines;

        public DostawcyController(IDataStore<Dostawcy, int> machineStore)
        {
            _machineStore = machineStore;
            _machines = new List<Dostawcy>();

        }
        public async Task LoadMachineAsync()
        {
            try
            {
                var items = await _machineStore.GetItemsAsync(true);
                _machines = new List<Dostawcy>(items);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading clients: {ex.Message}");
            }
        }
        public List<Dostawcy> GetMachines() => _machines;
    }
}
