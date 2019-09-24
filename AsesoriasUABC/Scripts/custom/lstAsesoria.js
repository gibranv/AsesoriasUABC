$(document).ready(function () {
    
    $("#Materia option:selected").val();
    $("#id_asesor").val($("#Asesor option:selected").val());
    $("#id_materia").val($("#Materia option:selected").val());
    $("#id_Tema").val($("#Tema option:selected").val());
    
    console.log($("#id_Tema").val());
});