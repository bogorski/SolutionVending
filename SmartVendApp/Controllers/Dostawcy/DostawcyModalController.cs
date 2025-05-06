using SmartVendApp.Controllers.Abstract;
using SmartVendApp.ServiceReference;
using SmartVendApp.Services;

namespace SmartVendApp.Controllers.Dostawcy
{
    public class DostawcyModalController : AModalController<DostawcyForView>
    {
        public DostawcyModalController(IDataStore<DostawcyForView, int> dataStore)
            : base(dataStore)
        {
            Title = "Dostawca";
        }
    }
}