$(function () {

});

$("#frmLogin").submit(function (e) {

    e.preventDefault();

    var dni = $("#txtDni").val();
    var clave = $("#txtClave").val();

    $.ajax({
        type: 'GET',
        url: `/Home/IniciarSesion?dni=${dni}&clave=${clave}`,
        contentType: "application/json chartset: utf-8",
        dataType: "json",
        success: function (data) {
            if (data["data"] != 0) {
                window.location = `../Principal/Index`;
            } else {
                alert("No estar registrado");
            }
        }
    });
});