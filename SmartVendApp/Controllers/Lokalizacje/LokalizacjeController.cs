using SmartVendApp.Controllers.Abstract;
using SmartVendApp.ServiceReference;
using SmartVendApp.Services;

namespace SmartVendApp.Controllers.Lokalizacje
{
    public class LokalizacjeController : AListController<LokalizacjeForView>
    {
        public LokalizacjeModalController ModalController { get; }

        public LokalizacjeController(LokalizacjeDataStore dataStore, LokalizacjeModalController modalController)
            : base(dataStore)
        {
            ModalController = modalController;
        }

        protected override bool IsNewItem(LokalizacjeForView item)
        {
            return item.Idlokalizacji == 0;
        }
    }
}
