using SmartVendApp.Controllers.Abstract;
using SmartVendApp.ServiceReference;
using SmartVendApp.Services;

namespace SmartVendApp.Controllers.Pojazdy
{
    public class PojazdyController : AListController<PojazdyForView>
    {
        public PojazdyModalController ModalController { get; }

        public PojazdyController(PojazdyDataStore dataStore, PojazdyModalController modalController)
            : base(dataStore)
        {
            ModalController = modalController;
        }

        protected override bool IsNewItem(PojazdyForView item)
        {
            return item.Idpojazdu == 0;
        }
    }
}