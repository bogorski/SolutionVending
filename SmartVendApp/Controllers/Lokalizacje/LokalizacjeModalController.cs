using SmartVendApp.Controllers.Abstract;
using SmartVendApp.ServiceReference;
using SmartVendApp.Services;

namespace SmartVendApp.Controllers.Lokalizacje
{
    public class LokalizacjeModalController : AModalController<LokalizacjeForView>
    {
        private readonly GeocodingService _geocoding;
        public LokalizacjeModalController(IDataStore<LokalizacjeForView> dataStore, GeocodingService geocoding)
            : base(dataStore)
        {
            _geocoding = geocoding;
            Title = "Lokalizacja";
        }

        public override int GetItemId(LokalizacjeForView item)
        {
            return item.Idlokalizacji;
        }

        public override string GetDisplayName(LokalizacjeForView item)
        {
            if (item == null) return "";
            return item.NazwaKlienta;
        }

        public override string GetDisplayDetails(LokalizacjeForView item)
        {
            if (item == null) return "";
            return $"{item.Ulica}, {item.Miasto}";
        }
        public virtual async Task<bool> SaveAsync()
        {
            System.Diagnostics.Debug.Print("SaveAsync");

            try
            {
                var addressParts = new List<string>
                {
                    CurrentItem.Ulica,
                    CurrentItem.KodPocztowy,
                    CurrentItem.Miasto,
                    CurrentItem.Kraj
                };

                string address = string.Join(", ", addressParts.Where(part => !string.IsNullOrWhiteSpace(part)));
                System.Diagnostics.Debug.WriteLine($"Adres do geolokalizacji: {address}");

                try
                {
                    var (lat, lng) = await _geocoding.GetCoordinatesFromAddressAsync(address);
                    CurrentItem.Latitude = lat;
                    CurrentItem.Longitude = lng;
                }
                catch (Exception geoEx)
                {
                    System.Diagnostics.Debug.Print($"Błąd geokodowania: {geoEx.Message}");
                }

                var result = IsNew
                    ? await _dataStore.AddItemAsync(CurrentItem)
                    : await _dataStore.UpdateItemAsync(CurrentItem);

                if (result)
                {
                    CloseModal();
                }
                else
                {
                    System.Diagnostics.Debug.Print("Operacja zapisu nie powiodła się");
                }

                return result;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print($"Błąd podczas zapisu: {ex.Message}");
                return false;
            }
        }
    }
}

