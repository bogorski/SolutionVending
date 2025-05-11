using SmartVendApp.Controllers.Abstract;
using SmartVendApp.ServiceReference;
using SmartVendApp.Services;

namespace SmartVendApp.Controllers.Warsztaty
{
    public class WarsztatyModalController : AModalController<WarsztatyForView>
    {
        public WarsztatyModalController(IDataStore<WarsztatyForView> dataStore)
            : base(dataStore)
        {
            Title = "Warsztat";
        }

        public override int GetItemId(WarsztatyForView item)
        {
            return item.Idwarsztatu;
        }

        public override string GetDisplayName(WarsztatyForView item)
        {
            if (item == null) return "";
            return item.Nazwa;
        }

        public override string GetDisplayDetails(WarsztatyForView item)
        {
            if (item == null) return "";
            return $"{item.Nazwa}, {item.Ulica}";
        }
    }
}