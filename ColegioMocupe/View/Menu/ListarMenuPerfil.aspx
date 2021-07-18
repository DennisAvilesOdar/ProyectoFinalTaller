<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="ListarMenuPerfil.aspx.cs" Inherits="ColegioMocupe.View.Menu.ListarMenuPerfil" %>

<asp:Content ID="head" ContentPlaceHolderID="head" runat="server">
    <script>
        var MAIN_SERVICES = "<%=Page.ResolveUrl("~/services/servicios.asmx")%>";
    </script>
    <script src="../../Scripts/jquery-3.4.1.js"></script>
    <script src="../../Scripts/bootstrap-table.min.js"></script>
    <script src="../../app/Menu/MenuPerfil.js"></script>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-12">
                <div class="card">
                    <div class="card-header card-header-danger">
                        <h4 class="card-title ">Menu - Perfil</h4>
                        <p class="card-category">Lista de Menus por Perfil</p>
                    </div>
                    <div class="card-body">
                        <div class="table-responsive">
                            <table id="tblRegistro" class="table">
                                <thead>
                                    <tr></tr>
                                </thead>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
