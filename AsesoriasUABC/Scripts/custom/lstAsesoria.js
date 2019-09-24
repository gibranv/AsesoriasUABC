$(document).ready(function () {
    $("select.country").change(function () {
        var selectedCountry = $(this).children("option:selected").val();
        
    });
});