using SmartVendApp.Controllers.Abstract;
using SmartVendApp.ServiceReference;
using SmartVendApp.Services;

namespace SmartVendApp.Controllers.Trasy
{
    public class TrasyController : AListController<TrasyForView>
    {
        public TrasyModalController ModalController { get; }

        public TrasyController(TrasyDataStore dataStore, TrasyModalController modalController)
            : base(dataStore)
        {
            ModalController = modalController;
        }

        protected override bool IsNewItem(TrasyForView item)
        {
            return item.Idtrasy == 0;
        }
    }
}