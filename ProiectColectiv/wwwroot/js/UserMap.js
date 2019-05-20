var map;
var marker = [];
var infowindow = [];
var contentString = [];
function initMap() {
    map = new google.maps.Map(document.getElementById('map'), {
        center: { lat: 46.770920, lng: 23.589920 },
        zoom: 13
    });
    google.maps.InfoWindow.prototype.isOpen = function () {
        var map = this.getMap();
        return (map !== null && typeof map !== "undefined");
    }

    $.get("/UserMap/GetAllLocation",
        function (data, status) {

            for (var i = 0; i < data.length; i++) {

                marker[i] = new google.maps.Marker({
                    position: { lat: data[i].latitudine, lng: data[i].longitudine },
                    map: map
                });
                infowindow[i] = new google.maps.InfoWindow({});
                if (data[i].isClosed == true) {
                    infowindow[i].setContent(contentClosed(data[i]));
                }
                else {
                    infowindow[i].setContent(contentNormal(data[i]));
                }
                  
                
                var mdl = marker[i];
                google.maps.event.addListener(marker[i],
                    'click',
                    (function (mdl, i) {
                        return function () {
                            infowindow[i].open(map, marker[i]);
                            for (var j = 0; j < infowindow.length; j++) {
                                if (j != i) {
                                    if (data[i].isClosed == true) {
                                        infowindow[i].setContent(contentClosed(data[i]));
                                    }
                                    else {
                                        infowindow[i].setContent(contentNormal(data[i]));
                                    }
                                    infowindow[j].close();
                                }

                            }
                        }
                    })(marker[i], i));
            }
        });
}
function Booking() {
    $("form").submit(function (event) {
        var date = $(this).serializeArray();
        if (date[0].value == "")
            alert("Numar inmatriculare invalid");

        else if (date[1].value == "")
            alert("Numar de telefon invalid");
        else if (date[2].value == "")
            alert("Data invalida");
        else if (date.length == 3)
            alert("Va rog alegeti tipul de loc dorit");
        else {
            alert("Rezervare facuta cu succes");
            this.reset();
        }      
        event.preventDefault();
    });
}

function contentBooking() {
    var index;
    $.get("/UserMap/GetAllLocation",
        function (data, status) {
            for (var i = 0; i < infowindow.length; i++) {
                if (infowindow[i].isOpen()) {
                    index = i;
                }
            }
            var contentString = '<div id="content">' +
                '<div id="siteNotice">' +
                '</div>' +
                '<h2 id="firstHeading" class="firstHeading">' +
                data[index].name +
                '</h2>' +
                '<div id="bodyContent">' +
                '<p><b> Numar locuri Fast Charging: </b>' +
                data[index].nrFastChargingSpots +
                '<p><b> Numar locuri care nu-s Fast Charging: </b>' +
                data[index].nrNormalChargingSpots +
                '<form><div><label> Nr. Inmatriculare</label><br>' + '<input type="text" name="nrmas"></div><br>' +
                '<div><label> Nr. Telefon</label><br>' + '<input type="text" name="nrtel"></div><br>' +
                '<div><label> Data si ora</label><br>' + '<input type="datetime-local" name="date"></div><br>' +
                '<div><label> Tip de loc</label><br>' + '<input type="radio" name="tip" value="normal"> Normal  ' + '<input type="radio" name="tip" value="fast"> Fast-Charging </div><br>'+
                '<div><input type="submit" id="' + data.id + '" value="Submit" class="btn btn-outline-success" onClick="Booking()"></div></form>';

            infowindow[index].setContent(contentString);
        });
}
function contentClosed(data) {
    var contentString = [];
                 contentString = '<div id="content">' +
                        '<div id="siteNotice">' +
                        '</div>' +
                        '<h1 id="firstHeading" class="firstHeading">' +
                        data.name +
                        '</h1>' +
                        '<div id="bodyContent">' +
                '<p><h6>Ne cerem scuze, dar parcarea</h6></p>' + '<p><h6>  este momentan inchisa.</h6></p>';
            return contentString;
}
function contentNormal(data) {
    var contentString = [];
                    contentString = '<div id="content">' +
                        '<div id="siteNotice">' +
                        '</div>' +
                        '<h2 id="firstHeading" class="firstHeading">' +
                        data.name +
                        '</h2>' +
                        '<div id="bodyContent">' +
                        '<p><b> Numar locuri Fast Charging: </b>' +
                        data.nrFastChargingSpots +
                        '<p><b> Numar locuri care nu-s Fast Charging: </b>' +
                        data.nrNormalChargingSpots +
                        '<div><input type="submit" id="' + data.id + '" value="Rezerva" class="btn btn-outline-success" onClick="contentBooking()"></div>';
            
            return contentString;    
}