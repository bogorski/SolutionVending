using SmartVendApp.Controllers.Abstract;
using SmartVendApp.ServiceReference;
using SmartVendApp.Services;

namespace SmartVendApp.Controllers.MagazynTowary
{
    public class MagazynTowaryController : AListController<MagazynTowaryForView>
    {
        public MagazynTowaryModalController ModalController { get; }

        public MagazynTowaryController(MagazynTowaryDataStore dataStore, MagazynTowaryModalController modalController)
            : base(dataStore)
        {
            ModalController = modalController;
        }

        protected override bool IsNewItem(MagazynTowaryForView item)
        {
            return item.Idtowaru == 0 && item.Idmagazynu == 0;
        }
    }
}