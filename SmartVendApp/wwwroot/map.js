window.initLeafletMapMultipleMarkers = (locations) => {
    if (!locations || locations.length === 0)
        return;

    var first = locations[0];
    var map = L.map('map').setView([first.latitude, first.longitude], 13);

    var redIcon = new L.Icon({
        iconUrl: 'https://raw.githubusercontent.com/pointhi/leaflet-color-markers/master/img/marker-icon-red.png',
        shadowUrl: 'https://unpkg.com/leaflet@1.9.3/dist/images/marker-shadow.png',
        iconSize: [25, 41],
        iconAnchor: [12, 41],
        popupAnchor: [1, -34],
        shadowSize: [41, 41]
    });

    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        attribution: '&copy; OpenStreetMap contributors'
    }).addTo(map);

    locations.forEach(loc => {
        L.marker([loc.latitude, loc.longitude], { icon: redIcon })
            .addTo(map)
            .bindPopup(`<strong>${loc.nazwaKlienta}</strong><br/>${loc.ulica} ${loc.miasto}`);
    });
};