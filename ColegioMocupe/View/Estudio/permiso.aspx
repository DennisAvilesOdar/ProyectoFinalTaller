<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="permiso.aspx.cs" Inherits="ColegioMocupe.View.Estudio.permiso" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-12">
                <div class="card">
                    <div class="card-header card-header-danger">
                        <h4 class="card-title">Plan de Estudio</h4>
                        <p class="category">Opciones de Plan de Estudio</p>
                    </div>
                    <div class="card-body">
                        <div class="form-group row">
                            <label for="txtPanel" class="col-sm-2 col-form-label">Nombre seccion</label>
                            <div class="col-sm-10">
                                <input type="text" class="form-control" id="txtPanel">
                            </div>
                        </div>
                        <div class="d-flex justify-content-around mb-5">
                            <button type="button" class="col-auto btn btn-danger">Grabar</button>
                            <button type="button" class="col-auto btn btn-danger">Editar</button>
                            <button type="button" class="col-auto btn btn-danger">Eliminar</button>
                        </div>
                        <div class="table-responsive">
                            <table id="tblRegistro" class="table">
                                <thead>
                                    <tr>
                                        <th data-field="dni" data-halign="center" data-align="center">Cod de Seccion</th>
                                        <th data-field="nombre" data-halign="center" data-align="center">Nombre de seccion</th>
                                    </tr>
                                </thead>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
