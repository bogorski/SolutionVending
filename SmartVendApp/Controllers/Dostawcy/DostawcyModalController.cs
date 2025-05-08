using SmartVendApp.Controllers.Abstract;
using SmartVendApp.ServiceReference;
using SmartVendApp.Services;

namespace SmartVendApp.Controllers.Dostawcy
{
    public class DostawcyModalController : AModalController<DostawcyForView>
    {
        public DostawcyModalController(IDataStore<DostawcyForView> dataStore)
            : base(dataStore)
        {
            Title = "Dostawca";
        }

        public override int GetItemId(DostawcyForView item)
        {
            return item.Iddostawcy;
        }

        public override string GetDisplayName(DostawcyForView item)
        {
            if (item == null) return "";
            return item.Nazwa;
        }

        public override string GetDisplayDetails(DostawcyForView item)
        {
            if (item == null) return "";
            return $"{item.Ulica}, {item.Miasto}";
        }
    }
}