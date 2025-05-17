using SmartVendApp.Controllers.Abstract;
using SmartVendApp.ServiceReference;
using SmartVendApp.Services;

namespace SmartVendApp.Controllers.Pracownicy
{
    public class PracownicyController : AListController<PracownicyForView>
    {
        public PracownicyModalController ModalController { get; }

        public PracownicyController(PracownicyDataStore dataStore, PracownicyModalController modalController)
            : base(dataStore)
        {
            ModalController = modalController;
        }

        protected override bool IsNewItem(PracownicyForView item)
        {
            return item.Idpracownika == 0;
        }
    }
}