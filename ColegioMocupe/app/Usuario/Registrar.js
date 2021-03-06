$(function () {
    $("#btnRegistrar").click(function (e) {
        e.preventDefault();
        var perfil = $("#ContentPlaceHolder1_cbPerfil").val();
        var dni = $("#txtDni").val();
        var nombre = $("#txtNombre").val();
        var apellido = $("#txtApellidos").val();
        var correo = $("#txtCorreo").val();
        var domicilio = $("#txtDomicilio").val();
        var celular = $("#txtCelular").val();
        var clave = $("#txtClave").val();

        $.ajax({
            type: "POST",
            url: `${MAIN_SERVICES}/RegistrarUsuarioSistema`,
            contentType: "application/json; charset: utf-8",
            dataType: "json",
            data: JSON.stringify({
                perfil: perfil,
                dni: dni,
                nombre: nombre,
                apellido: apellido,
                correo: correo,
                domicilio: domicilio,
                celular: celular,
                clave: clave
            }),
            success: function (data) {
                console.log(data);
            }
        });
    }); 
});