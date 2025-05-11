using SmartVendApp.Controllers.Abstract;
using SmartVendApp.ServiceReference;
using SmartVendApp.Services;

namespace SmartVendApp.Controllers.Magazyny
{
    public class MagazynyController : AListController<MagazynyForView>
    {
        public MagazynyModalController ModalController { get; }

        public MagazynyController(MagazynyDataStore dataStore, MagazynyModalController modalController)
            : base(dataStore)
        {
            ModalController = modalController;
        }

        protected override bool IsNewItem(MagazynyForView item)
        {
            return item.Idmagazynu == 0;
        }
    }
}