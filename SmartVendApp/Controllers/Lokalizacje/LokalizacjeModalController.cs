using SmartVendApp.Controllers.Abstract;
using SmartVendApp.ServiceReference;
using SmartVendApp.Services;

namespace SmartVendApp.Controllers.Lokalizacje
{
    public class LokalizacjeModalController : AModalController<LokalizacjeForView>
    {
        public LokalizacjeModalController(IDataStore<LokalizacjeForView> dataStore)
            : base(dataStore)
        {
            Title = "Lokalizacja";
        }

        public override int GetItemId(LokalizacjeForView item)
        {
            return item.Idlokalizacji;
        }

        public override string GetDisplayName(LokalizacjeForView item)
        {
            if (item == null) return "";
            return item.NazwaKlienta;
        }

        public override string GetDisplayDetails(LokalizacjeForView item)
        {
            if (item == null) return "";
            return $"{item.Ulica}, {item.Miasto}";
        }
    }
}

