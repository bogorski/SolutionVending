using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace RestAPIVend.Helpers
{
    public class HideInternalModelsDocumentFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            swaggerDoc.Components.Schemas.Remove("DostawaTowary");
            swaggerDoc.Components.Schemas.Remove("Dostawcy");
            swaggerDoc.Components.Schemas.Remove("Faktury");
            swaggerDoc.Components.Schemas.Remove("LokalizacjaMaszyny");
            swaggerDoc.Components.Schemas.Remove("Lokalizacje");
            swaggerDoc.Components.Schemas.Remove("MagazynTowary");
            swaggerDoc.Components.Schemas.Remove("Magazyny");
            swaggerDoc.Components.Schemas.Remove("MaszynaTowary");
            swaggerDoc.Components.Schemas.Remove("MaszynaTrasa");
            swaggerDoc.Components.Schemas.Remove("Maszyny");
            swaggerDoc.Components.Schemas.Remove("Pojazdy");
            swaggerDoc.Components.Schemas.Remove("Pracownicy");
            swaggerDoc.Components.Schemas.Remove("PracownikTowary");
            swaggerDoc.Components.Schemas.Remove("StanowiskaPracy");
            swaggerDoc.Components.Schemas.Remove("Towary");
            swaggerDoc.Components.Schemas.Remove("Transakcje");
            swaggerDoc.Components.Schemas.Remove("Trasy");
            swaggerDoc.Components.Schemas.Remove("TypyMaszyn");
            swaggerDoc.Components.Schemas.Remove("Warsztaty");
            swaggerDoc.Components.Schemas.Remove("Wizyty");
            swaggerDoc.Components.Schemas.Remove("Zamowienia");
            swaggerDoc.Components.Schemas.Remove("ZamowieniaZewnetrzne");
            swaggerDoc.Components.Schemas.Remove("ZamowienieTowary");
        }
    }
}
