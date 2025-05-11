using SmartVendApp.Controllers.Abstract;
using SmartVendApp.ServiceReference;
using SmartVendApp.Services;

namespace SmartVendApp.Controllers.Magazyny
{
    public class MagazynyModalController : AModalController<MagazynyForView>
    {
        public MagazynyModalController(IDataStore<MagazynyForView> dataStore)
            : base(dataStore)
        {
            Title = "Dostawca";
        }

        public override int GetItemId(MagazynyForView item)
        {
            return item.Idmagazynu;
        }

        public override string GetDisplayName(MagazynyForView item)
        {
            if (item == null) return "";
            return item.Nazwa;
        }

        public override string GetDisplayDetails(MagazynyForView item)
        {
            if (item == null) return "";
            return $"{item.Ulica}, {item.Miasto}";
        }
    }
}