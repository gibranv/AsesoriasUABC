$(document).ready(function () {
    
    $("#Materia option:selected").val();
    $("#id_asesor").val($("#Asesor option:selected").val());
    $("#id_materia").val($("#Materia option:selected").val());
    $("#id_Tema").val($("#Tema option:selected").val());
    
   
});
//$('#mtr').click(function () {
//    if( $("#matricula").val() != "")
//    {
//        GetAlumno($("#matricula").val);
//    }
//});
//function GetAlumno(matricula) {
//    $.ajaxSetup({ cache: false });
//    $.ajax({
//        url: '@Url.RouteUrl("FindAlumno", "AsesoriasTbs")',
//        data: {
//            'm': matricula
//        },
//        type: 'POST',
//        cache: false,
//        success: function (response) {
//            $("#Nombre").val(response.name);
//            $("#Carrera").val(response.carrera);
//        },
//        error: function (response) {
//        }
//    });
//}