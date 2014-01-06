 @*<link href="~/Assets/css/demo.css" rel="stylesheet" />
    <link href="~/Assets/css/index.css" rel="stylesheet" />
    <script src="~/Scripts/jquery-ui-1.8.24.js"></script>
    <script src="~/Assets/js/jquery.color.js"></script>
    <script src="~/Assets/js/demo.js"></script>
    <script src="~/Assets/js/jquery.gmap3.js"></script>
    <script src="~/Assets/js/index.js"></script>

    <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBA2YoFViLEevsBGTVGJ4Hhm63wfHP1hWA&sensor=true"></script>*@
    @* <script type="text/javascript">
        var geocoder;
var map;
function success(position) {

    var mapcanvas = document.createElement('div');
    mapcanvas.id = 'map-canvas';
    mapcanvas.style.height = '400px';
    mapcanvas.style.width = '560px';

    document.querySelector('article').appendChild(mapcanvas);

    var latlng = new google.maps.LatLng(position.coords.latitude, position.coords.longitude);
    var myOptions = {
        zoom: 15,
        center: latlng,
        mapTypeControl: false,
        navigationControlOptions: { style: google.maps.NavigationControlStyle.SMALL },
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    geocoder = new google.maps.Geocoder();
    map = new google.maps.Map(document.getElementById("map-canvas"), myOptions);

    var marker = new google.maps.Marker({
        position: latlng,
        map: map,
        title: "You are here! (at least within a " + position.coords.accuracy + " meter radius)"
    });
}
function codeAddress() {
    var address = document.getElementById("address").value;
    geocoder.geocode({ 'address': address }, function (results, status) {
        if (status == google.maps.GeocoderStatus.OK) {
            map.setCenter(results[0].geometry.location);
            var marker = new google.maps.Marker({
                map: map,
                position: results[0].geometry.location
            });
        } else {
            alert("Geocode was not successful for the following reason: " + status);
        }
    });
}
function error(msg) {
    var s = document.querySelector('#demo');
    s.innerHTML = typeof msg == 'string' ? msg : "failed";
    s.className = 'fail';

    // console.log(arguments);
}

if (navigator.geolocation) {
    navigator.geolocation.getCurrentPosition(success, error);
} else {
    error('not supported');
}

$(function () {
    $('.findAddress').bind('click', function () {
        codeAddress();
    });
});
</script>*@