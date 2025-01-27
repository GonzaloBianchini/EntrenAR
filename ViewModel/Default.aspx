<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ViewModel.Login" %>

<!DOCTYPE html>

<%--<html xmlns="http://www.w3.org/1999/xhtml">--%>
<head runat="server">
    <title>EntrenAr</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.min.css">
    <link href="\content\MyStyles.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <!-- Barra de división superior -->
        <nav class="navbar navbar-expand-lg navbar-light bg-light">
            <div class="container">
                <a class="navbar-brand fw-bold" href="#">ENTREN<span class="text-warning">AR</span></a>
                <div class="d-flex">
                    <asp:Button runat="server" ID="btnRegistrarme" Text="Registrarme" OnClick="btnRegistrarme_Click" class="btn btn-outline-secondary me-2" />
                    <asp:Button runat="server" ID="btnLogin" Text="LOGIN" OnClick="btnLogin_Click" class="btn btn-warning" />
                </div>
            </div>
        </nav>

        <asp:Label Text="PRUEBA MENSAAAAJEEE" id="lblMessage" visible="false" runat="server" />

        <!-- Cuadro Login-->
        <div class="d-flex justify-content-center align-items-center vh-100 bg-light">
            <div class="card p-4 shadow" style="width: 20rem;">
                <h4 class="text-center mb-3">Inicio de sesión</h4>
                <div class="mb-3">
                    <label for="username" class="form-label">Usuario</label>
                    <div class="input-group">
                        <span class="input-group-text d-flex align-items-center"><i class="bi bi-person fs-5"></i></span>
                        <asp:TextBox runat="server" ID="txtUserName" placeholder="Usuario" class="form-control" />
                    </div>
                </div>
                <div class="mb-3">
                    <label for="password" class="form-label">Contraseña</label>
                    <div class="input-group">
                        <span class="input-group-text"><i class="bi bi-lock"></i></span>
                        <asp:TextBox runat="server" ID="txtUserPassword" type="password" placeholder="Password" class="form-control" />
                    </div>
                </div>
                <div class="d-grid">
                    <asp:Button runat="server" Text="Ingresar" ID="btnIngresar" OnClick="btnIngresar_Click" class="btn btn-warning"/>
                </div>
            </div>
        </div>
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
    </form>
</body>

