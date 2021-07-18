<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="ColegioMocupe.View.Usuario.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var MAIN_SERVICES = "<%=Page.ResolveUrl("~/services/servicios.asmx")%>";
    </script>
    <script src="../../Scripts/jquery-3.4.1.js"></script>
    <script src="../../Scripts/bootstrap-table.min.js"></script>
    <script src="../../Content/material/js/plugins/sweetalert2.js"></script>
    <script src="../../app/Usuario/Index.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-12">
                <div class="card">
                    <div class="card-header card-header-danger">
                        <h4 class="card-title ">Usuarios</h4>
                        <p class="card-category">Listar Usuarios registrados</p>
                    </div>
                    <div class="card-body">
                        <div class="table-responsive">
                            <table id="tblRegistro" class="table">
                                <thead>
                                    <tr>
                                        <th data-field="dni" data-halign="center" data-align="center">Dni</th>
                                        <th data-field="nombre" data-halign="center" data-align="center">Nombre Completo</th>
                                        <th data-field="correo" data-halign="center" data-align="center">Correo</th>
                                        <th data-field="domicilio" data-halign="center" data-align="center">Domicilio</th>
                                        <th data-field="celular" data-halign="center" data-align="center">Celular</th>
                                        <th data-formatter="opcionFormato" data-halign="center" data-align="center">Opciones</th>
                                    </tr>
                                </thead>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="ModalEditar" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <form id="frmMenuModal">
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
                            <label for="txtDniModal">Perfiles</label>
                            <asp:DropDownList ID="cbPerfilModal" runat="server" CssClass="form-control selectpicker"></asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label for="txtDni">Dni</label>
                            <input id="txtDniModal" class="form-control" />
                        </div>
                        <div class="form-group">
                            <label for="txtNombre">Nombre</label>
                            <input id="txtNombreModal" class="form-control" />
                        </div>
                        <div class="form-group">
                            <label for="txtApellidos">Apellidos</label>
                            <input id="txtApellidosModal" class="form-control" />
                        </div>
                        <div class="form-group">
                            <label for="txtCorreo">Correo Electronico</label>
                            <input id="txtCorreoModal" type="email" class="form-control" />
                        </div>
                        <div class="form-group">
                            <label for="txtDomicilio">Domicilio</label>
                            <input id="txtDomicilioModal" type="text" class="form-control" />
                        </div>
                        <div class="form-group">
                            <label for="txtCelular">Celular</label>
                            <input id="txtCelularModal" type="number" class="form-control" />
                        </div>
                        <div class="form-group">
                            <label for="txtClave">Contraseña</label>
                            <input id="txtClaveModal" type="password" class="form-control" />
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                        <button id="btnActualizar" type="submit" class="btn btn-danger">Actualizar</button>
                    </div>
                </div>
            </div>
        </form>
    </div>
</asp:Content>
