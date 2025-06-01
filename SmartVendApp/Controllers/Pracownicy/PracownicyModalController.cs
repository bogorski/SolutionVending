using SmartVendApp.Controllers.Abstract;
using SmartVendApp.ServiceReference;
using SmartVendApp.Services;

namespace SmartVendApp.Controllers.Pracownicy
{
    public class PracownicyModalController : AModalController<PracownicyForView>
    {
        private readonly IDataStore<StanowiskaPracyForView> _stanowiskaPracyDataStore;
        private readonly IDataStore<PojazdyForView> _pojazdyDataStore;
        private readonly IDataStore<TrasyForView> _trasyDataStore;

        public List<StanowiskaPracyForView> StanowiskaPracy { get; private set; } = new();
        public List<PojazdyForView> Pojazdy { get; private set; } = new();
        public List<TrasyForView> Trasy { get; private set; } = new();
        public PracownicyModalController(
            IDataStore<PracownicyForView> dataStore, 
            IDataStore<StanowiskaPracyForView> stanowiskaPracyDataStore, 
            IDataStore<PojazdyForView> pojazdyDataStore, 
            IDataStore<TrasyForView> trasyDataStore)
            : base(dataStore)
        {
            _stanowiskaPracyDataStore = stanowiskaPracyDataStore;
            _pojazdyDataStore = pojazdyDataStore;
            _trasyDataStore = trasyDataStore;
            Title = "Pracownicy";
        }

        public override int GetItemId(PracownicyForView item)
        {
            return item.Idpracownika;
        }

        public override string GetDisplayName(PracownicyForView item)
        {
            if (item == null) return "";
            return item.Nazwisko;
        }

        public override string GetDisplayDetails(PracownicyForView item)
        {
            if (item == null) return "";
            return $"{item.Imie}";
        }
        public async Task LoadDataAsync()
        {
            StanowiskaPracy = (List<StanowiskaPracyForView>)await _stanowiskaPracyDataStore.GetItemsAsync();
            Pojazdy = (List<PojazdyForView>)await _pojazdyDataStore.GetItemsAsync();
            Trasy = (List<TrasyForView>)await _trasyDataStore.GetItemsAsync();
        }

        public override async Task ShowAddModal()
        {
            await base.ShowAddModal();
            CurrentItem.DataZatrudnienia = DateTime.Today;
        }
    }
}