using System.Net.Http;
using System.Text.Json;

public class GeocodingService
{
    private readonly HttpClient _http;

    public GeocodingService(HttpClient httpClient)
    {
        _http = httpClient;
        _http.DefaultRequestHeaders.UserAgent.ParseAdd("SmartVendApp");
    }

    public async Task<(double Latitude, double Longitude)> GetCoordinatesFromAddressAsync(string address)
    {
        var url = $"https://nominatim.openstreetmap.org/search?format=json&q={Uri.EscapeDataString(address)}";
        var response = await _http.GetStringAsync(url);

        var results = JsonSerializer.Deserialize<List<NominatimResult>>(response);

        if (results == null || results.Count == 0)
            throw new Exception("Brak wyników geokodowania");

        var result = results[0];
        return (
            double.Parse(result.lat, System.Globalization.CultureInfo.InvariantCulture),
            double.Parse(result.lon, System.Globalization.CultureInfo.InvariantCulture)
        );
    }

    private class NominatimResult
    {
        public string lat { get; set; }
        public string lon { get; set; }
    }
}