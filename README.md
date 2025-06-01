# SmartVendApp

SmartVendApp to aplikacja stworzona w technologii .NET MAUI, umożliwiająca zarządzanie i wizualizację lokalizacji na mapie. Projekt wykorzystuje komponenty Blazor oraz integrację z JavaScript do obsługi map.

## Funkcje

- Przeglądanie lokalizacji na interaktywnej mapie
- Dodawanie i edycja lokalizacji
- Integracja z plikami JavaScript dla obsługi mapy
- Nowoczesny interfejs oparty o .NET MAUI i Blazor

## Wymagania

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- Visual Studio 2022 z obsługą .NET MAUI

## Instalacja

1. Sklonuj repozytorium:
2. Otwórz rozwiązanie w Visual Studio 2022.
3. Przywróć zależności NuGet.
4. Uruchom projekt jako aplikację MAUI (Android, iOS, Windows lub Mac).

## Struktura projektu

- `Components/Map/Map.razor` – komponent mapy
- `Components/Pages/MapLocalizations.razor` – strona lokalizacji na mapie
- `Components/Pages/Locations.razor` – strona zarządzania lokalizacjami
- `wwwroot/map.js` – skrypt JavaScript do obsługi mapy

## Użycie

Po uruchomieniu aplikacji możesz przeglądać i zarządzać lokalizacjami bezpośrednio z poziomu interfejsu użytkownika.

## API

Aplikacja SmartVendApp komunikuje się z API w celu pobierania i zarządzania danymi lokalizacji.

### Przykładowe endpointy

- `GET /api/locations` – pobiera listę lokalizacji
- `POST /api/locations` – dodaje nową lokalizację
- `PUT /api/locations/{id}` – aktualizuje istniejącą lokalizację
- `DELETE /api/locations/{id}` – usuwa lokalizację

### Użycie w aplikacji

Aplikacja korzysta z wbudowanych mechanizmów .NET MAUI do komunikacji HTTP, np. `HttpClient`, aby pobierać i wysyłać dane do API.

### Konfiguracja

Adres API można skonfigurować w pliku konfiguracyjnym lub bezpośrednio w kodzie aplikacji.


