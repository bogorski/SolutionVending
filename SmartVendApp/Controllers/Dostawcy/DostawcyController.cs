using SmartVendApp.Controllers.Abstract;
using SmartVendApp.Controllers.Interface;
using SmartVendApp.ServiceReference;
using SmartVendApp.Services;

namespace SmartVendApp.Controllers.Dostawcy
{
    public class DostawcyController : AListController<DostawcyForView, int>
    {
        public DostawcyModalController ModalController { get; }

        public DostawcyController(DostawcyDataStore dataStore, DostawcyModalController modalController)
            : base(dataStore)
        {
            ModalController = modalController;
        }

        protected override bool IsNewItem(DostawcyForView item)
        {
            return item.Iddostawcy == 0;
        } 
    }
}