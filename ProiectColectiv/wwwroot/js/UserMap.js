var map;
function initMap() {
    map = new google.maps.Map(document.getElementById('map'), {
        center: { lat: 46.770920, lng: 23.589920 },
        zoom: 13
    });

    $.get("/UserMap/GetAllLocation",
        function (data, status) {
            var marker = [];
            var contentString = [];
            var infowindow = [];
            for (var i = 0; i < data.length; i++) {

                marker[i] = new google.maps.Marker({
                    position: { lat: data[i].latitudine, lng: data[i].longitudine },
                    map: map
                });
                if (data[i].isClosed == true) {
                    contentString[i] = '<div id="content">' +
                        '<div id="siteNotice">' +
                        '</div>' +
                        '<h1 id="firstHeading" class="firstHeading">' +
                        data[i].name +
                        '</h1>' +
                        '<div id="bodyContent">' +
                        '<p><h6>Ne cerem scuze, dar parcarea</h6></p>' + '<p><h6>  este momentan inchisa.</h6></p>';
                }
                else {
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
                        '<p><h6>Rezervar un loc de parcare</h6></a>';
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