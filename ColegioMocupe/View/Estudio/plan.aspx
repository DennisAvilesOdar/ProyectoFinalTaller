<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="plan.aspx.cs" Inherits="ColegioMocupe.View.Estudio.plan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var MAIN_SERVICES = "<%=Page.ResolveUrl("~/services/servicios.asmx")%>";
    </script>
    <script src="../../Scripts/jquery-3.4.1.js"></script>
    <script src="../../Content/material/js/core/jquery.min.js"></script>
    <script src="../../Content/material/js/core/popper.min.js"></script>
    <script src="../../Content/material/js/core/bootstrap-material-design.min.js"></script>
    <script src="../../Content/material/js/plugins/sweetalert2.js"></script>
    <script src="../../Scripts/bootstrap-table.min.js"></script>
    <script src="../../app/Estudio/plan.js"></script>
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
                            <label for="txtPlan" class="col-sm-2 col-form-label">Nombre del Plan de Estudio</label>
                            <div class="col-sm-8">
                                <input type="text" class="form-control" id="txtPlan">
                            </div>
                            <div class="text-center">
                                <button id="btnGrabar" type="button" onclick="grabar()" class="col-auto btn btn-danger">Grabar</button>
                            </div>
                        </div>
                        <div class="table-responsive">
                            <table id="tblRegistro" class="table">
                                <thead>
                                    <tr>
                                        <th data-field="ID_PLAN_ESTUDIO" data-halign="center" data-align="center">Cod de Plan de est</th>
                                        <th data-field="PE_NOMBRE" data-halign="center" data-align="center">Nombre del plan de estudio</th>
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
                        <h5 class="modal-title" id="tituloModal">Editar Plan de Estudio</h5>
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
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                        <button id="btnActualizar" type="button" class="btn btn-danger">Actualizar</button>
                    </div>
                </div>
            </div>
        </form>
    </div>
</asp:Content>
