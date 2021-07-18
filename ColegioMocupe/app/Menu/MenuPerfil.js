var Lista_PM = [];

$(function () {

    GetPerfilMenu();

    listar();

    $(document).on('click', '.menu_rol' ,function (e) {
        var data = {
            idHijoMenu: $(this).data('menuid'),
            idPerfil: $(this).val()
        };

        var url = "";

        if ($(this).is(":checked")) {
            url = "RegistrarMenuPerfil";
        } else {
            url = "EliminarMenuPerfil";
        }

        SetDelMenuPerfil(url, data);
    });
});

function GetPerfilMenu() {
    $.ajax({
        type: "POST",
        url: `${MAIN_SERVICES}/ListarPerfilMenu`,
        contentType: "application/json; charset: utf-8",
        dataType: "json",
        success: function (data) {
            var dataJSON = JSON.parse(data["d"]);
            Lista_PM = (dataJSON || []).map(x => x);
        }
    });
}

function SetDelMenuPerfil(url,data) {
    $.ajax({
        type: "POST",
        url: `${MAIN_SERVICES}/${url}`,
        contentType: "application/json; charset: utf-8",
        dataType: "json",
        data: JSON.stringify(data),
        success: function () {

        }
    });
}

function listar() {

    $("#tblRegistro").bootstrapTable("destroy");

    var tabla = $("#tblRegistro");
    var menus = [];
    var columnas = [];

    columnas.push({
        field: "menuNombre",
        title: "Menu",
        formatter: ""
    });

    $.ajax({
        type: "POST",
        url: `${MAIN_SERVICES}/ListarPerfiles`,
        contentType: "application/json; charset: utf-8",
        dataType: "json",
        success: function (data) {
            var dataJSON = JSON.parse(data["d"]);
            $.each(dataJSON, function (index, value) {
                columnas.push({
                    field: value["id"],
                    title: value["nombre"],
                    align: 'center',
                    formatter: 'opcionFormato'
                });
            });
        },
        complete: function () {
            $.ajax({
                type: "POST",
                url: `${MAIN_SERVICES}/ListarMenu`,
                contentType: "application/json; charset: utf-8",
                dataType: "json",
                success: function (data) {
                    var dataJSON = JSON.parse(data["d"]);
                    $.each(dataJSON, function (index, value) {
                        $.each(value["listaHijos"], function (indexHijo, valueHijo) {
                            menus.push({
                                id: valueHijo["id"],
                                menuNombre: value["nombre"] + " > " + valueHijo["nombre"]
                            });
                        });
                    });
                },
                complete: function () {
                    tabla.bootstrapTable({
                        columns: columnas,
                        data: menus
                    });
                }
            });
        }
    });
}

function opcionFormato(value, row, index, field) {
    var validar = Lista_PM.find(x => x.cod_perfil == field && x.cod_menu == row.id) ? "checked" : "";
    let btn1 = `<input class="menu_rol" type="checkbox" data-menuid="${row.id}" value="${field}" ${validar}>`;
    return btn1
}

