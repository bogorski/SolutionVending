using SmartVendApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartVendApp.Controllers
{
    public class MachineController
    {
        private List<Machine> _machines;

        public MachineController()
        {
            _machines = new List<Machine>
            {
                new Machine
                {
                    NumerMaszyny = "K100",
                    IdtypMaszyny = "Coffee",
                    NumerSeryjny = "Rt15DF552dS",
                    RokProdukcji = new DateTime(2020, 1, 1),  // Przykład wartości - rok produkcji
                    Opis = "brak",
                    DataMontazu = new DateTime(2020, 5, 1)  // Przykład daty montażu
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
        public void AddMachine(Machine newMachine)
        {
            _machines.Add(newMachine);
        }
        public List<Machine> GetMachines()
        {
            return _machines;
        }
        public void UpdateMachine(Machine updatedMachine)
        {
            var machine = _machines.FirstOrDefault(m => m.NumerMaszyny == updatedMachine.NumerMaszyny);
            if (machine != null)
            {
                machine.IdtypMaszyny = updatedMachine.IdtypMaszyny;
                machine.NumerSeryjny = updatedMachine.NumerSeryjny;
                machine.RokProdukcji = updatedMachine.RokProdukcji;
                machine.Opis = updatedMachine.Opis;
                machine.DataMontazu = updatedMachine.DataMontazu;
            }
        }
        public void DeleteMachine(string numerMaszyny)
        {
            var machine = _machines.FirstOrDefault(m => m.NumerMaszyny == numerMaszyny);
            if (machine != null)
            {
                _machines.Remove(machine);
            }
        }
       
    }
}
