using SmartVendApp.Controllers.Abstract;
using SmartVendApp.ServiceReference;
using SmartVendApp.Services;

namespace SmartVendApp.Controllers.Dostawcy
{
    public class DostawcyModalController : AModalController<DostawcyForView>
    {
        private readonly IDataStore<DostawcyForView, int> _dataStore;

        public event Action OnSaved;

        public DostawcyModalController(IDataStore<DostawcyForView, int> dataStore)
        {
            _dataStore = dataStore;
            Title = "Dostawca";
        }

        public override async Task<bool> SaveAsync()
        {
            try
            {
                bool result;

                if (IsNew)
                {
                    result = await _dataStore.AddItemAsync(CurrentItem);
                }
                else
                {
                    result = await _dataStore.UpdateItemAsync(CurrentItem);
                }

                if (result)
                {
                    OnSaved?.Invoke();
                    CloseModal();
                    return true;
                }
            }
            catch (Exception ex)
            {
                // Obsługa błędów
            }

            return false;
        }

        //protected override DostawcyForView CloneItem(DostawcyForView item)
        //{
        //    return new DostawcyForView
        //    {
        //        Iddostawcy = item.Iddostawcy,
        //        Nazwa = item.Nazwa,
        //        Miasto = item.Miasto
        //        // Pozostałe właściwości
        //    };
        //}
    }
}