<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="ColegioMocupe.View.Menu.Index" %>

<asp:Content ID="head" ContentPlaceHolderID="head" runat="server">
    <script>
        var MAIN_SERVICES = "<%=Page.ResolveUrl("~/services/servicios.asmx")%>";
        var PAGINA = "<%=Page.ResolveUrl("~/View/Menu/Index")%>"
    </script>
    <script src="../../Scripts/jquery-3.4.1.js"></script>
    <script src="../../Content/material/js/core/jquery.min.js"></script>
    <script src="../../Content/material/js/core/popper.min.js"></script>
    <script src="../../Content/material/js/core/bootstrap-material-design.min.js"></script>
    <script src="../../Scripts/jquery.nestable.js"></script>
    <script src="../../Content/material/js/plugins/sweetalert2.js"></script>
    <script src="../../app/Menu/Index.js"></script>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-12">
                <div class="card">
                    <div class="card-header card-header-danger">
                        <h4 class="card-title">Menu</h4>
                        <p class="category">Listado de Menus</p>
                    </div>
                    <div class="card-body">
                        <div class="dd" id="nestable">
                            <ol class="dd-list" id="item-menu"></ol>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="ModalEditar" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="tituloModal">Editar Menu</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <input type="hidden" value="" id="txtIdModal" name="txtIdModal" />
                    <div class="form-group">
                        <label for="txtNombreModal">Nombre</label>
                        <input type="text" class="form-control" id="txtNombreModal">
                    </div>
                    <div class="form-group">
                        <label for="txtUrlModal">Url</label>
                        <input type="text" class="form-control" id="txtUrlModal">
                    </div>
                    <div class="form-group">
                        <label for="txtIconoModal">Icono</label>
                        <input type="text" class="form-control" id="txtIconoModal">
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                    <button id="btnActualizar" type="submit" class="btn btn-danger">Actualizar</button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
