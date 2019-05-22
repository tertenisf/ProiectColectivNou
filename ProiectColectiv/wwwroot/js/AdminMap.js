var map;
function initMap() {
    map = new google.maps.Map(document.getElementById('map'), {
        center: { lat: 46.770920, lng: 23.589920 },
        zoom: 13
    });

    $.get("/AdminMap/GetAllLocation",
        function (data, status) {
            var marker = [];
            var contentString = [];
            var infowindow = [];
            for (var i = 0; i < data.length; i++) {

                marker[i] = new google.maps.Marker({
                    position: { lat: data[i].latitudine, lng: data[i].longitudine },
                    map: map
                });
                if (data[i].isClosed) {
                    contentString[i] = '<div id="content">' +
                        '<div id="siteNotice">' +
                        '</div>' +
                        '<h2 id="firstHeading" class="firstHeading">' +
                        data[i].name +
                        '</h2>' +
                        '<div id="bodyContent">' +
                        '<p><b> Numar locuri Fast Charging: </b>' +
                        data[i].nrFastChargingSpots +
                        '<p><b> Numar locuri care nu-s Fast Charging: </b>' +
                        data[i].nrNormalChargingSpots +
                        '<p><b> Castig in aceasta luna: </b>' +
                        data[i].monthlyGain + ' Lei' +
                        '<p><b> Castig in acest an: </b>' +
                        data[i].weeklyGain + ' Lei' +
                    '<div><input type="submit" id="' + data[i].id + '" value="Open" class="btn btn-outline-success" onClick="SetStationStatus(this)"></div>';
                } else {
                    contentString[i] = '<div id="content">' +
                        '<div id="siteNotice">' +
                        '</div>' +
                        '<h2 id="firstHeading" class="firstHeading">' +
                        data[i].name +
                        '</h2>' +
                        '<div id="bodyContent">' +
                        '<p><b> Numar locuri Fast Charging: </b>' +
                        data[i].nrFastChargingSpots +
                        '<p><b> Numar locuri care nu-s Fast Charging: </b>' +
                        data[i].nrNormalChargingSpots +
                        '<p><b> Castig in aceasta luna: </b>' +
                        data[i].monthlyGain + ' Lei' +
                        '<p><b> Castig in acest an: </b>' +
                        data[i].weeklyGain + ' Lei' +
                    '<div><input type="submit" id="' + data[i].id + '" value="Close" class="btn btn-outline-danger" onClick="SetStationStatus(this)"></div>';
                }

                infowindow[i] = new google.maps.InfoWindow({
                    content: contentString[i]
                });
                var mdl = marker[i];
                google.maps.event.addListener(marker[i],
                    'click',
                    (function (mdl, i) {
                        return function () {
                            infowindow[i].open(map, marker[i]);
                            for (var j = 0; j < infowindow.length; j++) {
                                if (j != i) {
                                    infowindow[j].close();
                                }

                            }
                        }
                    })(marker[i], i));
            }
        });

}

function SetStationStatus(button) {
    $.post("/AdminMap/GetAllLocationStatusById?id=" + $(button)[0].id,
        function (data, status) {
            if (status == "success") {
                location.reload();
            }
        });
}
