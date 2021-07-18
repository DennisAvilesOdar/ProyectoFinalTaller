<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Registrar.aspx.cs" Inherits="ColegioMocupe.app.Usuario.Registrar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var MAIN_SERVICES = "<%=Page.ResolveUrl("~/services/servicios.asmx")%>";
    </script>
    <script src="../../Scripts/jquery-3.4.1.js"></script>
    <script src="../../app/Usuario/Registrar.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="card">
                <div class="card-header card-header-danger">
                    <h4 class="card-title">Registrar Usuario</h4>
                    <p class="category">Llenar los campos del nuevo usuario</p>
                </div>
                <div class="card-body">
                    <div class="form-group">
                        <label for="txtDni">Perfiles</label>
                        <asp:DropDownList ID="cbPerfil" runat="server" CssClass="form-control selectpicker"></asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label for="txtDni">Dni</label>
                        <input id="txtDni" class="form-control" />
                    </div>
                    <div class="form-group">
                        <label for="txtNombre">Nombre</label>
                        <input id="txtNombre" class="form-control" />
                    </div>
                    <div class="form-group">
                        <label for="txtApellidos">Apellidos</label>
                        <input id="txtApellidos" class="form-control" />
                    </div>
                    <div class="form-group">
                        <label for="txtCorreo">Correo Electronico</label>
                        <input id="txtCorreo" type="email" class="form-control" />
                    </div>
                    <div class="form-group">
                        <label for="txtDomicilio">Domicilio</label>
                        <input id="txtDomicilio" type="text" class="form-control" />
                    </div>
                    <div class="form-group">
                        <label for="txtCelular">Celular</label>
                        <input id="txtCelular" type="number" class="form-control" />
                    </div>
                    <div class="form-group">
                        <label for="txtClave">Contraseña</label>
                        <input id="txtClave" type="password" class="form-control" />
                    </div>
                    <button id="btnRegistrar" class="btn btn-danger">Registrar</button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
