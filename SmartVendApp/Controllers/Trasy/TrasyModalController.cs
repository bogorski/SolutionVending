using SmartVendApp.Controllers.Abstract;
using SmartVendApp.ServiceReference;
using SmartVendApp.Services;

namespace SmartVendApp.Controllers.Trasy
{
    public class TrasyModalController : AModalController<TrasyForView>
    {
        public TrasyModalController(IDataStore<TrasyForView> dataStore)
            : base(dataStore)
        {
            Title = "Trasa";
        }

        public override int GetItemId(TrasyForView item)
        {
            return item.Idtrasy;
        }

        public override string GetDisplayName(TrasyForView item)
        {
            if (item == null) return "";
            return item.Nazwa;
        }

        public override string GetDisplayDetails(TrasyForView item)
        {
            if (item == null) return "";
            return $"{item.Nazwa}, {item.Ocena}";
        }
    }
}