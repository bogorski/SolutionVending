using SmartVendApp.Controllers.Abstract;
using SmartVendApp.ServiceReference;
using SmartVendApp.Services;

namespace SmartVendApp.Controllers.Warsztaty
{
    public class WarsztatyController : AListController<WarsztatyForView>
    {
        public WarsztatyModalController ModalController { get; }

        public WarsztatyController(WarsztatyDataStore dataStore, WarsztatyModalController modalController)
            : base(dataStore)
        {
            ModalController = modalController;
        }

        protected override bool IsNewItem(WarsztatyForView item)
        {
            return item.Idwarsztatu == 0;
        }
    }
}