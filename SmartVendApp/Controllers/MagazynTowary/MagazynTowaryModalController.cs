using SmartVendApp.Controllers.Abstract;
using SmartVendApp.ServiceReference;
using SmartVendApp.Services;

namespace SmartVendApp.Controllers.MagazynTowary
{
    public class MagazynTowaryModalController : AModalController<MagazynTowaryForView>
    {
        private readonly IDataStore<MagazynyForView> _magazynyDataStore;
        private readonly IDataStore<TowaryForView> _towaryDataStore;
        public List<MagazynyForView> Magazyny { get; private set; } = new();
        public List<TowaryForView> Towary { get; private set; } = new();
        public MagazynTowaryModalController(
            IDataStore<MagazynTowaryForView> dataStore, 
            IDataStore<MagazynyForView> magazynyDataStore, 
            IDataStore<TowaryForView> towaryDataStore)
            : base(dataStore)
        {
            _magazynyDataStore = magazynyDataStore;
            _towaryDataStore = towaryDataStore;
            Title = "Magazyn towar";
        }

        public override int GetItemId(MagazynTowaryForView item)
        {
            throw new NotImplementedException();
        }

        public override string GetDisplayName(MagazynTowaryForView item)
        {
            if (item == null) return "";
            return item.TowarData + item.MagazynData;
        }

        public override string GetDisplayDetails(MagazynTowaryForView item)
        {
            if (item == null) return "";
            return $"{item.Stan}";
        }
        public async Task LoadDataAsync()
        {
            Magazyny = (List<MagazynyForView>)await _magazynyDataStore.GetItemsAsync();
            Towary = (List<TowaryForView>)await _towaryDataStore.GetItemsAsync();
        }

        public override async Task ShowAddModal()
        {
            base.ShowAddModal();
            CurrentItem.Data = DateTime.Today;
        }

    }
}