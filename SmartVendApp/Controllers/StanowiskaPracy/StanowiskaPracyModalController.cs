using SmartVendApp.Controllers.Abstract;
using SmartVendApp.ServiceReference;
using SmartVendApp.Services;

namespace SmartVendApp.Controllers.StanowiskaPracy
{
    public class StanowiskaPracyModalController : AModalController<StanowiskaPracyForView>
    {
        public StanowiskaPracyModalController(IDataStore<StanowiskaPracyForView> dataStore)
            : base(dataStore)
        {
            Title = "Dostawca";
        }

        public override int GetItemId(StanowiskaPracyForView item)
        {
            return item.IdstanowiskaPracy;
        }

        public override string GetDisplayName(StanowiskaPracyForView item)
        {
            if (item == null) return "";
            return item.NazwaStanowiska;
        }

        public override string GetDisplayDetails(StanowiskaPracyForView item)
        {
            if (item == null) return "";
            return $"{item.Dzial}";
        }
    }
}