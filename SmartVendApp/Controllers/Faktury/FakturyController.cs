using SmartVendApp.Controllers.Abstract;
using SmartVendApp.ServiceReference;
using SmartVendApp.Services;

namespace SmartVendApp.Controllers.Faktury
{
    public class FakturyController : AListController<FakturyForView>
    {
        public FakturyModalController ModalController { get; }

        public FakturyController(FakturyDataStore dataStore, FakturyModalController modalController)
            : base(dataStore)
        {
            ModalController = modalController;
        }

        protected override bool IsNewItem(FakturyForView item)
        {
            return item.Idfaktury == 0;
        } 
    }
}