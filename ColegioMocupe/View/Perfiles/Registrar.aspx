<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Registrar.aspx.cs" Inherits="ColegioMocupe.View.Perfiles.Registrar" %>

<asp:Content ID="head" ContentPlaceHolderID="head" runat="server">}
    <script>
        var MAIN_SERVICES = "<%=Page.ResolveUrl("~/services/servicios.asmx")%>";
    </script>
    <script src="../../Scripts/jquery-3.4.1.js"></script>
    <script src="../../app/Perfiles/Registrar.js"></script>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-12">
                <div class="card">
                    <div class="card-header card-header-danger">
                        <h4 class="card-title">Perfiles</h4>
                        <p class="category">Registrar Perfiles</p>
                    </div>
                    <div class="card-body">
                            <div class="form-group">
                            <label for="txtPerfil">Nombre del Perfil</label>
                            <input type="text" class="form-control" id="txtPerfil">
                        </div>
                        <button onclick="registrarPerfil()" type="button" class="btn btn-danger">Registrar</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
