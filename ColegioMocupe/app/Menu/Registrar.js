$(function () {
    
});

function RegistrarMenu() {
    var nombre = $("#txtNombre").val();
    var url = $("#txtUrl").val();
    var icono = $("#txtIcono").val();

    $.ajax({
        type: "POST",
        url: `${MAIN_SERVICES}/RegistrarMenu`,
        contentType: "application/json; charset: utf-8",
        dataType: "json",
        data: JSON.stringify({
            nombre: nombre,
            url: url,
            icono: icono
        }),
        success: function () {
            
        }
    });
}