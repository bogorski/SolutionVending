using SmartVendApp.Controllers.Abstract;
using SmartVendApp.ServiceReference;
using SmartVendApp.Services;

namespace SmartVendApp.Controllers.Towary
{
    public class TowaryModalController : AModalController<TowaryForView>
    {
        public TowaryModalController(IDataStore<TowaryForView> dataStore)
            : base(dataStore)
        {
            Title = "Towar";
        }

        public override int GetItemId(TowaryForView item)
        {
            return item.Idtowaru;
        }

        public override string GetDisplayName(TowaryForView item)
        {
            if (item == null) return "";
            return item.Nazwa;
        }

        public override string GetDisplayDetails(TowaryForView item)
        {
            if (item == null) return "";
            return $"{item.Nazwa}, {item.KodKreskowy}";
        }
    }
}