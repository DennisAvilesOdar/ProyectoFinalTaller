const opcionesModal = {
    backdrop: 'static',
    keyboard: false,
    show: true
};

$(function () {
    ListarMenus();
    nestable();
    EditarEnModal();
});

function EditarEnModal() {
    $("#btnActualizar").on('click',function (e) {
        e.preventDefault();
        var id = $("#txtIdModal").val();
        var nombre = $("#txtNombreModal").val();
        var url = $("#txtUrlModal").val();
        var icono = $("#txtIconoModal").val();

        var filtro = JSON.stringify({
            id: id,
            nombre: nombre,
            url: url,
            icono: icono
        });

        $.ajax({
            type: "POST",
            url: `${MAIN_SERVICES}/ActualizarMenuId`,
            contentType: "application/json; charset: utf-8",
            dataType: "json",
            data: filtro,
            success: function () {
                window.location.href = PAGINA;
            }
        });
    });
}


function nestable() {
    $("#nestable").nestable().on("change", function (e) {
        e.preventDefault();
        const menu = JSON.stringify($("#nestable").nestable("serialize"));
        $.ajax({
            type: "POST",
            url: `${MAIN_SERVICES}/ordenarListarMenu`,
            dataType: "json",
            contentType: "application/json; charset: utf-8",
            data: JSON.stringify({ json: menu }),
            success: function () {

            }
        });
    });
    $("#nestable").nestable("expandAll");
}

function ListarMenus() {
    $.ajax({
        type: "POST",
        url: `${MAIN_SERVICES}/ListarMenu`,
        contentType: "application/json; charset: utf-8",
        dataType: "json",
        success: function (data) {
            var datosJSON = JSON.parse(data["d"]);
            var html = '';
            $.each(datosJSON, function (index, value) {
                html += itemMenu(value);
            });
            $("#item-menu").html(html);
        }
    });
}

function itemMenu(submenu) {
    var html = "";
    if (submenu["listaHijos"] == undefined) {
        html += '<li class="dd-item dd3-item" data-id="' + submenu["id"] + '" >';
        html += '<div class="dd-handle dd3-handle"></div>';
        html += '<div class="dd3-content font-weight-bold">';
        html += `<a href="javascript:editarModal(${submenu["id"]});">${submenu["nombre"]} | Url -> ${submenu["url"]} Icono -> <i style="font-size:20px;" class="fas ${submenu["icono"]}"></i></a>`;
        html += `<a href="javascript:eliminarModal(${submenu["id"]});" class="eliminar-menu tooltipsC" title = "Eliminar este menú" > <i class="text-danger fas fa-trash"></i></a>`;
        html += '</div></li>';
    } else {
        html += '<li class="dd-item dd3-item" data-id="' + submenu["id"] + '" >';
        html += '<div class="dd-handle dd3-handle"></div>';
        html += '<div class="dd3-content font-weight-bold">';
        html += `<a href="javascript:editarModal(${submenu["id"]});">${submenu["nombre"]} | Url -> ${submenu["url"]} Icono -> <i style="font-size:20px;" class="fas ${submenu["icono"]}"></i></a>`;
        html += `<a href="javascript:eliminarModal(${submenu["id"]});" class="eliminar-menu tooltipsC" title = "Eliminar este menú" > <i class="text-danger fas fa-trash"></i></a >`;
        html += '</div>';
        html += '<ol class="dd-list">';
        $.each(submenu["listaHijos"], function (index, value) {
            html += '<li class="dd-item dd3-item" data-id="' + value["id"] + '" >';
            html += '<div class="dd-handle dd3-handle"></div>';
            html += '<div class="dd3-content font-weight-bold">';
            html += `<a href="javascript:editarModal(${value["id"]});">${value["nombre"]} | Url -> ${value["url"]} Icono -> <i style="font-size:20px;" class="fas ${value["icono"]}"></i></a>`;
            html += `<a href="javascript:eliminarModal(${value["id"]});" class="eliminar-menu tooltipsC" title="Eliminar este menú"> <i class="text-danger fas fa-trash"></i></a >`;
            html += '</div></li>';
        });
        html += '';
        html += '</ol>';
        html += '</li>';
    }
    return html;
}

function editarModal(id) {
    $("#ModalEditar").modal(opcionesModal);
    $.ajax({
        type: "POST",
        url: `${MAIN_SERVICES}/BuscarMenuId`,
        contentType: "application/json; charset: utf-8",
        dataType: "json",
        data: JSON.stringify({id: id}),
        success: function (data) {
            var datosJSON = JSON.parse(data["d"]);
            $("#txtIdModal").val(datosJSON["id"]);
            $("#txtNombreModal").val(datosJSON["nombre"]);
            $("#txtUrlModal").val(datosJSON["url"]);
            $("#txtIconoModal").val(datosJSON["icono"]);
        }
    });
}

function eliminarModal(id) {
    Swal.fire({
        title: 'Eliminar Menu',
        text: "Deseas elminiar el menu?",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Ok'
    }).then((result) => {
        if (result['value']) {
            $.ajax({
                type: "POST",
                url: `${MAIN_SERVICES}/EliminarMenu`,
                contentType: "application/json; charset: utf-8",
                dataType: "json",
                data: JSON.stringify({id: id}),
                success: function () {

                }, complete: function () {
                    Swal.fire(
                        'Borrado',
                        'El menu se a borrado con exito',
                        'success'
                    )
                    ListarMenus();
                }
            });
        }
    });
}