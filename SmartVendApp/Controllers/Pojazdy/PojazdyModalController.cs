using SmartVendApp.Controllers.Abstract;
using SmartVendApp.ServiceReference;
using SmartVendApp.Services;

namespace SmartVendApp.Controllers.Pojazdy
{
    public class PojazdyModalController : AModalController<PojazdyForView>
    {
        private readonly IDataStore<WarsztatyForView> _warsztatyDataStore;

        public List<WarsztatyForView> Warsztaty { get; private set; } = new();
        public PojazdyModalController(IDataStore<PojazdyForView> dataStore, IDataStore<WarsztatyForView> warsztatyDataStore)
            : base(dataStore)
        {
            _warsztatyDataStore = warsztatyDataStore;
            Title = "Pojazd";
        }

        public override int GetItemId(PojazdyForView item)
        {
            return item.Idpojazdu;
        }

        public override string GetDisplayName(PojazdyForView item)
        {
            if (item == null) return "";
            return item.Marka;
        }

        public override string GetDisplayDetails(PojazdyForView item)
        {
            if (item == null) return "";
            return $"{item.NumerRejestracyjny}";
        }
        public async Task LoadWarsztatyAsync()
        {
            Warsztaty = (List<WarsztatyForView>)await _warsztatyDataStore.GetItemsAsync();
        }
        public override void ShowAddModal()
        {
            base.ShowAddModal();
            CurrentItem.DataUbezpieczenia = DateTime.Today;
            CurrentItem.DataPrzegladu = DateTime.Today;
        }
    }
}