<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="ColegioMocupe.index" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Login</title>
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../../Content/fontawesome/css/all.css" rel="stylesheet" />
    <link href="../../Content/Pagina/Login/LoginPagina.css" rel="stylesheet" />
</head>

<body>
    <div class="container h-100">
        <div class="d-flex justify-content-center h-100">
            <div class="user_card">
                <div class="d-flex justify-content-center">
                    <div class="brand_logo_container">
                        <img src="../../Imagen/logoUser.png" class="brand_logo" />
                    </div>
                </div>
                <div class="d-flex justify-content-center form_container">
                    <form runat="server">
                        <div class="input-group mb-3">
                            <div class="input-group-append">
                                <span class="input-group-text"><i class="fas fa-user"></i></span>
                            </div>
                            <asp:TextBox ID="txtDni" runat="server" CssClass="form-control input_user"></asp:TextBox>
                        </div>
                        <div class="input-group mb-2">
                            <div class="input-group-append">
                                <span class="input-group-text"><i class="fas fa-key"></i></span>
                            </div>
                            <asp:TextBox ID="txtClave" TextMode="Password" CssClass="form-control input_user" runat="server"></asp:TextBox>
                        </div>
                        <div class="d-flex justify-content-center mt-3 login_container">
                            <asp:Button ID="btnLogin" runat="server" CssClass="btn login_btn" OnClick="btnLogin_Click" Text="Inicio Sesion" />
                        </div>
                    </form>
                </div>

                <div class="mt-4">
                    <div class="d-flex justify-content-center links" style="color: white">
                        No tienes una cuenta? <a href="Registrar.aspx" class="ml-2" style="color: white">Registrate</a>
                    </div>
                    <div class="d-flex justify-content-center links">
                        <a href="#" style="color: white">Olvidaste la contraseña?</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="../../Scripts/jquery-3.4.1.js"></script>
    <script src="//cdn.jsdelivr.net/npm/sweetalert2@11"></script>
</body>
</html>
