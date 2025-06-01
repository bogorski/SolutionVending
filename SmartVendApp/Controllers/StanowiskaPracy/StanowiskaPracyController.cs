using SmartVendApp.Controllers.Abstract;
using SmartVendApp.ServiceReference;
using SmartVendApp.Services;

namespace SmartVendApp.Controllers.StanowiskaPracy
{
    public class StanowiskaPracyController : AListController<StanowiskaPracyForView>
    {
        public StanowiskaPracyModalController ModalController { get; }

        public StanowiskaPracyController(StanowiskaPracyDataStore dataStore, StanowiskaPracyModalController modalController)
            : base(dataStore)
        {
            ModalController = modalController;
        }

        protected override bool IsNewItem(StanowiskaPracyForView item)
        {
            return item.IdstanowiskaPracy == 0;
        }
    }
}