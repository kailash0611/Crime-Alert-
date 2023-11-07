﻿$(document).ready(function () {    if (navigator.geolocation) {        navigator.geolocation.getCurrentPosition(function (position) {            const { latitude, longitude } = position.coords;            const coords = [latitude, longitude];            console.log(`https://www.google.pt/maps/@${latitude},${longitude}`);            const map = L.map('crime-map').setView(coords, 46);            L.tileLayer('https://{s}.tile.openstreetmap.fr/hot/{z}/{x}/{y}.png', {                attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors',            }).addTo(map);            const markers = [];            map.on('click', function (e) {                const marker = L.marker(e.latlng).addTo(map);                markers.push(marker);                const markerCoords = marker.getLatLng();                console.log('Marker Coordinates:latitude', markerCoords.lat, 'Longitude', markerCoords.lng);                console.log(`https://www.google.pt/maps/@${markerCoords.lat},${markerCoords.lng}`);                document.getElementById('crimeloc').value = `https://www.google.pt/maps/@${markerCoords.lat},${markerCoords.lng}`;            });            $('#auth-form').submit(function (e) {                e.preventDefault();            });            $('#crime-report-form').submit(function (e) {                e.preventDefault();                const markerCoordinates = markers.map(marker => marker.getLatLng());                console.log('All Marker Coordinates:', markerCoordinates);                markerCoordinates.forEach(coords => {                    console.log('Latitude:', coords.lat);                    console.log('Longitude:', coords.lng);                });            });            $('#auth-form').submit(function (e) {                e.preventDefault();            });            $('#crime-report-form').submit(function (e) {                e.preventDefault();                const markerCoordinates = markers.map(marker => marker.getLatLng());                console.log('All Marker Coordinates:', markerCoordinates);            });        });    }});