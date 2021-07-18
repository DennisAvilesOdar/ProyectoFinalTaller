$(function () {
    listar();
});

function listar() {

    $("#tblRegistro").bootstrapTable("destroy");

    var tabla = $("#tblRegistro");

    $.ajax({
        type: "POST",
        url: `${MAIN_SERVICES}/ListarUsuariosSistema`,
        contentType: "application/json; charset: utf-8",
        dataType: "json",
        success: function (data) {
            var dataJSON = JSON.parse(data["d"]);
            console.log(dataJSON);
            tabla.bootstrapTable('destroy');
            tabla.bootstrapTable({
                data: dataJSON
            });
        }
    });
}

function opcionFormato(value, row, index) {
    let btn1 = `<a href="javascript:editarModal(${row.id})" title="Editar Perfil"><i class="fas fa-edit"></i></a>`;
    let btn2 = `<a href="javascript:eliminarPerfil(${row.id});" title="Eliminar perfil"><i class="fas fa-trash"></i></a>`;
    return btn1.concat("&nbsp;&nbsp;", btn2);
}

function editarModal(id) {
    $("#ModalEditar").modal(opcionesModal);
    $.ajax({
        type: "POST",
        url: `${MAIN_SERVICES}/BuscarPerfilId`,
        contentType: "application/json; charset: utf-8",
        dataType: "json",
        data: JSON.stringify({ id: id }),
        success: function (data) {
            var datoJSON = JSON.parse(data["d"]);
            $("#txtIdModal").val(datoJSON["id"]);
            $("#cbPerfilModal").val(datoJSON["id"]);
            $("#txtDniModal").val(datoJSON["nombre"]);
            $("#txtNombreModal").val(datoJSON["nombre"]);
            $("#txtApellidosModal").val(datoJSON["nombre"]);
            $("#txtCorreoModal").val(datoJSON["nombre"]);
            $("#txtDomicilioModal").val(datoJSON["nombre"]);
            $("#txtCelularModal").val(datoJSON["nombre"]);
            $("#txtClaveModal").val(datoJSON["nombre"]);
        }
    });
}

function eliminarPerfil(id) {
    Swal.fire({
        title: 'Eliminar Usuario',
        text: "Deseas elminiar el usuario?",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Ok'
    }).then((result) => {
        console.log(result);
        if (result['value']) {
            $.ajax({
                type: "POST",
                url: `${MAIN_SERVICES}/DeleteUsuario`,
                contentType: "application/json; charset: utf-8",
                dataType: "json",
                data: JSON.stringify({ id: id }),
                success: function () {

                }, complete: function () {
                    Swal.fire(
                        'Borrado',
                        'El usuario se a borrado con exito',
                        'success'
                    )
                    listar();
                }
            });
        }
    });
}