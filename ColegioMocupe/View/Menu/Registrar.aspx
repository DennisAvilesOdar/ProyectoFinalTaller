<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Registrar.aspx.cs" Inherits="ColegioMocupe.View.Menu.Registrar" %>

<asp:Content ID="head" ContentPlaceHolderID="head" runat="server">
    <script>
        var MAIN_SERVICES = "<%=Page.ResolveUrl("~/services/servicios.asmx")%>";
    </script>
    <script src="../../Scripts/jquery-3.4.1.js"></script>
    <script src="../../app/Menu/Registrar.js"></script>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-12">
                <div class="card">
                    <div class="card-header card-header-danger">
                        <h4 class="card-title">Menu</h4>
                        <p class="category">Registrar Menu</p>
                    </div>
                    <div class="card-body">
                            <div class="form-group">
                                <label for="txtNombre">Nombre</label>
                                <input type="text" class="form-control" id="txtNombre">
                            </div>
                            <div class="form-group">
                                <label for="txtUrl">Url</label>
                                <input type="text" class="form-control" id="txtUrl">
                            </div>
                            <div class="form-group">
                                <label for="txtIcono">Icono</label>
                                <input type="text" class="form-control" id="txtIcono">
                            </div>
                            <button id="btnRegistrar" onclick="RegistrarMenu()" type="button" class="btn btn-danger">Registrar</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
