using SmartVendApp.Controllers.Abstract;
using SmartVendApp.ServiceReference;
using SmartVendApp.Services;

namespace SmartVendApp.Controllers.Faktury
{
    public class FakturyModalController : AModalController<FakturyForView>
    {
        public FakturyModalController(IDataStore<FakturyForView> dataStore)
            : base(dataStore)
        {
            Title = "Faktura";
        }

        public override int GetItemId(FakturyForView item)
        {
            return item.Idfaktury;
        }

        public override string GetDisplayName(FakturyForView item)
        {
            if (item == null) return "";
            return item.NazwaSprzedawcy;
        }

        public override string GetDisplayDetails(FakturyForView item)
        {
            if (item == null) return "";
            return $"{item.Ulica}, {item.Miasto}";
        }
    }
}