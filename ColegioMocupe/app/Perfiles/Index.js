const opcionesModal = {
    backdrop: 'static',
    keyboard: false,
    show: true
};

$(function () {
    EditarEnModal();
    listarPerfiles();
});

function EditarEnModal() {
    $("#btnActualizar").on('click', function (e) {
        e.preventDefault();
        var id = $("#txtIdModal").val();
        var nombre = $("#txtNombreModal").val();
        $.ajax({
            type: "POST",
            url: `${MAIN_SERVICES}/ActualizarPerfil`,
            contentType: "application/json; charset: utf-8",
            dataType: "json",
            data: JSON.stringify({ id: id, nombre: nombre }),
            success: function () {
                listarPerfiles();
            }
        });
    });
}

function listarPerfiles() {
    $.ajax({
        type: "POST",
        url: `${MAIN_SERVICES}/ListarPerfiles`,
        contentType: "application/json; charset: utf-8",
        dataType: "json",
        success: function (data) {
            var datoJSON = JSON.parse(data["d"]);
            $("#tblRegistro").bootstrapTable("destroy");
            $("#tblRegistro").bootstrapTable({ data: datoJSON });
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
            $("#txtNombreModal").val(datoJSON["nombre"]);
        }
    });
}

function eliminarPerfil(id) {
    Swal.fire({
        title: 'Eliminar Perfil',
        text: "Deseas elminiar el perfil?",
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
                url: `${MAIN_SERVICES}/EliminarPerfil`,
                contentType: "application/json; charset: utf-8",
                dataType: "json",
                data: JSON.stringify({ id: id }),
                success: function () {

                }, complete: function () {
                    Swal.fire(
                        'Borrado',
                        'El perfil se a borrado con exito',
                        'success'
                    )
                    listarPerfiles();
                }
            });
        }
    });
}