<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="matricula.aspx.cs" Inherits="ColegioMocupe.View.Estudio.matricula" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-12">
                <div class="card">
                    <div class="card-header card-header-danger">
                        <h4 class="card-title">Matricula</h4>
                        <p class="category">Opciones de Matricula</p>
                    </div>
                    <div class="card-body">
                        <div class="row">
                            <div class="col-6">
                                <div class="form-group row">
                                    <label for="txtPlan" class="col-sm-2 col-form-label">Ped Aca</label>
                                    <div class="col-sm-8">
                                        <input type="text" class="form-control" id="txtPlan">
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label for="txtPlan" class="col-sm-2 col-form-label">Grado</label>
                                    <div class="col-sm-8">
                                        <input type="text" class="form-control" id="txtPlan">
                                    </div>
                                </div>
                            </div>
                            <div class="col-6">
                                <div class="form-group row">
                                    <label for="txtPlan" class="col-sm-2 col-form-label">Alumno</label>
                                    <div class="col-sm-8">
                                        <asp:DropDownList ID="cbAlumno" CssClass="form-control" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label for="txtPlan" class="col-sm-2 col-form-label">Apod</label>
                                    <div class="col-sm-8">
                                        <asp:DropDownList ID="cbApoderado" CssClass="form-control" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="text-center">
                            <button id="btnGrabar" type="button" onclick="grabar()" class="col-auto btn btn-danger">Grabar</button>
                        </div>
                        <div class="table-responsive">
                            <table id="tblRegistro" class="table">
                                <thead>
                                    <tr>
                                        <th data-field="ID_PLAN_ESTUDIO" data-halign="center" data-align="center">Codigo Matricula</th>
                                        <th data-field="PE_NOMBRE" data-halign="center" data-align="center">Periodo Academico</th>
                                        <th data-field="ID_PLAN_ESTUDIO" data-halign="center" data-align="center">Alumno</th>
                                        <th data-field="PE_NOMBRE" data-halign="center" data-align="center">Grado</th>
                                        <th data-field="ID_PLAN_ESTUDIO" data-halign="center" data-align="center">Apoderado</th>
                                        <th data-field="PE_NOMBRE" data-halign="center" data-align="center">Estado</th>
                                        <th data-field="PE_NOMBRE" data-halign="center" data-align="center">Fecha</th>
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
