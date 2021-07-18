<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registrar.aspx.cs" Inherits="ColegioMocupe.View.Home.Registrar" %>

<!DOCTYPE html>

<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Login</title>
    <link href="../../Content/fontawesome/css/all.css" rel="stylesheet" />
    <link href="../../Content/material/css/material-dashboard.min.css" rel="stylesheet" />
</head>

<body>
    <div class="container">
        <div class="row">
            <div class="card">
                <div class="card-header card-header-danger">
                    <h4 class="card-title">Registrar Usuario</h4>
                    <p class="category">Llenar los campos del nuevo usuario</p>
                </div>
                <div class="card-body">
                    <form runat="server">
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
                    </form>
                </div>
            </div>
        </div>
    </div>
    <script>
        var MAIN_SERVICES = "<%=Page.ResolveUrl("~/services/servicios.asmx")%>";
    </script>
    <script src="../../Scripts/jquery-3.4.1.js"></script>
    <script src="//cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <script src="../../app/Home/Registrar.js"></script>
</body>
</html>