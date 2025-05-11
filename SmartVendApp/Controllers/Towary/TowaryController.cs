
using SmartVendApp.Controllers.Abstract;
using SmartVendApp.ServiceReference;
using SmartVendApp.Services;

namespace SmartVendApp.Controllers.Towary
{
    public class TowaryController : AListController<TowaryForView>
    {
        public TowaryModalController ModalController { get; }

        public TowaryController(TowaryDataStore dataStore, TowaryModalController modalController)
            : base(dataStore)
        {
            ModalController = modalController;
        }

        protected override bool IsNewItem(TowaryForView item)
        {
            return item.Idtowaru == 0;
        }
    }
}