const opcionesModal = {
    backdrop: 'static',
    keyboard: false,
    show: true
};

$(function () {
    EditarEnModal();
    Listar();
});

function Listar() {
    $.ajax({
        type: "POST",
        url: `${MAIN_SERVICES}/ListarGradoEstudio`,
        contentType: "application/json; charset: utf-8",
        dataType: "json",
        success: function (data) {
            var datoJSON = JSON.parse(data["d"]);
            $("#tblRegistro").bootstrapTable("destroy");
            $("#tblRegistro").bootstrapTable({ data: datoJSON });
        }
    });
}

function grabar() {

    var nombre = $("#txtGrado").val();

    if ((nombre == null || nombre == "") && $.isNumeric(nombre)) {
        alert("el campo debe estar lleno y solo numeros para grabar");
        return;
    }

    $.ajax({
        type: "POST",
        url: `${MAIN_SERVICES}/InsertarGradoEstudio`,
        contentType: "application/json; charset: utf-8",
        dataType: "json",
        data: JSON.stringify({
            nombre: nombre
        }),
        success: function (data) {
            Listar();
        }
    });
}

function opcionFormato(value, row, index) {
    let btn1 = `<a href="javascript:editarModal(${row.ID_GRADO_ESTUDIO})" title="Editar Perfil"><i class="fas fa-edit"></i></a>`;
    let btn2 = `<a href="javascript:eliminarModal(${row.ID_GRADO_ESTUDIO});" title="Eliminar perfil"><i class="fas fa-trash"></i></a>`;
    return btn1.concat("&nbsp;&nbsp;", btn2);
}

function editarModal(id) {
    $("#ModalEditar").modal(opcionesModal);
    $.ajax({
        type: "POST",
        url: `${MAIN_SERVICES}/BuscarGradoEstudioId`,
        contentType: "application/json; charset: utf-8",
        dataType: "json",
        data: JSON.stringify({ id: id }),
        success: function (data) {
            var datoJSON = JSON.parse(data["d"]);
            $("#txtIdModal").val(datoJSON["ID_GRADO_ESTUDIO"]);
            $("#txtNombreModal").val(datoJSON["ESP_NOMBRE"]);
        }
    });
}

function EditarEnModal() {
    $("#btnActualizar").on('click', function (e) {
        e.preventDefault();
        var id = $("#txtIdModal").val();
        var nombre = $("#txtNombreModal").val();
        $.ajax({
            type: "POST",
            url: `${MAIN_SERVICES}/ActualizarGradoEstudio`,
            contentType: "application/json; charset: utf-8",
            dataType: "json",
            data: JSON.stringify({ id: id, nombre: nombre }),
            success: function () {
                Listar();
            }
        });
    });
}

function eliminarModal(id) {
    Swal.fire({
        title: 'Eliminar Grado de Estudio',
        text: "Deseas elminiar el Grado de Estudio?",
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
                url: `${MAIN_SERVICES}/DeleteGradoEstudio`,
                contentType: "application/json; charset: utf-8",
                dataType: "json",
                data: JSON.stringify({ id: id }),
                success: function () {

                }, complete: function () {
                    Swal.fire(
                        'Borrado',
                        'El Grado de estudio se a borrado con exito',
                        'success'
                    )
                    Listar();
                }
            });
        }
    });
}