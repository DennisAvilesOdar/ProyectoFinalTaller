$(function () {

});

function registrarPerfil() {
    $.ajax({
        type: "POST",
        url: `${MAIN_SERVICES}/RegistrarPerfil`,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify({ perfil: $("#txtPerfil").val() }),
        success: function (data) {
            console.log(data);
        }
    });
}