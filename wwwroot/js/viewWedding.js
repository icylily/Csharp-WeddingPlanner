// var geocoder;
// var map;
// // var address = "19999 ne 18 th , sammamish, wa";
// var address =document.getElementById("address").innerHTML;
// console.log("address:", address);

// function initMap() {
//     console.log("Starts:");
//     geocoder = new google.maps.Geocoder();
//     var latlng = new google.maps.LatLng(-34.397, 150.644);
//     var myOptions = {
//         zoom: 8,
//         center: latlng,
//         mapTypeControl: true,
//         mapTypeControlOptions: {
//             style: google.maps.MapTypeControlStyle.DROPDOWN_MENU
//         },
//         navigationControl: true,
//         mapTypeId: google.maps.MapTypeId.ROADMAP
//     };
//     console.log("init map:");
//     map = new google.maps.Map(document.getElementById("map"), myOptions);
//     if (geocoder) {
//         geocoder.geocode({
//             'address': address
//         }, function (results, status) {
//             if (status == google.maps.GeocoderStatus.OK) {
//                 if (status != google.maps.GeocoderStatus.ZERO_RESULTS) {
//                     map.setCenter(results[0].geometry.location);

//                     var infowindow = new google.maps.InfoWindow({
//                         content: '<b>' + address + '</b>',
//                         size: new google.maps.Size(150, 50)
//                     });

//                     var marker = new google.maps.Marker({
//                         position: results[0].geometry.location,
//                         map: map,
//                         title: address
//                     });
//                     google.maps.event.addListener(marker, 'click', function () {
//                         infowindow.open(map, marker);
//                     });

//                 } else {
//                     alert("No results found");
//                 }
//             } else {
//                 alert("Geocode was not successful for the following reason: " + status);
//             }
//         });
//     }
// }

function initMap() {
    var map = new google.maps.Map(document.getElementById('map'), {
        zoom: 8,
        center: { lat: -34.397, lng: 150.644 }
    });
    console.log("init map");
    var geocoder = new google.maps.Geocoder();
    geocodeAddress(geocoder, map);
}

function geocodeAddress(geocoder, resultsMap) {
    var address = document.getElementById('address').innerHTML;
    console.log("address", address)
    geocoder.geocode({ 'address': address }, function(results, status) {
        if (status === 'OK') {
            resultsMap.setCenter(results[0].geometry.location);
            var marker = new google.maps.Marker({
                map: resultsMap,
                position: results[0].geometry.location
            });
        } else {
            alert('Geocode was not successful for the following reason: ' + status);
        }
    });
}