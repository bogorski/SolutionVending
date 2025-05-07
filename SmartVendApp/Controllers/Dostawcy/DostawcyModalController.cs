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
    }
}