﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// var map;
// var myOptions = {
//     zoom: 8,
//     center: latlng,
//     mapTypeControl: true,
//     mapTypeControlOptions: { style: google.maps.MapTypeControlStyle.DROPDOWN_MENU },
//     navigationControl: true,
//     mapTypeId: google.maps.MapTypeId.ROADMAP
// };
// // function initMap() {
// // map = new google.maps.Map(document.getElementById('map'), myOptions);}
// function initMap() {
//     // The location of Uluru
//     var uluru = { lat: -25.344, lng: 131.036 };
//     // The map, centered at Uluru
//     var map = new google.maps.Map(
//         document.getElementById('map'), { zoom: 4, center: uluru });
//     // The marker, positioned at Uluru
//     var marker = new google.maps.Marker({ position: uluru, map: map });
// }

// var geocoder;
// var map;
// // var address = "19999 ne 18 th , sammamish, wa";
// var address = $("#address").html();
// console.log("address:", address);

// function initMap() {
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
// google.maps.event.addDomListener(window, 'load', initMap);