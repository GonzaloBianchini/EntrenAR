<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ViewModel.Login" %>

<%--<%@ Register Src="~/LabelControl.ascx" TagPrefix="uc" TagName="MiControl" %>--%>
<%@ Register Src="~/Toast.ascx" TagPrefix="uc" TagName="Toast" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>EntrenAr</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.min.css" />
    <link href="\content\MyStyles.css" rel="stylesheet" />


    <%--<style>
        /* Aumentar el tamaño del Toast */
        .toast {
            min-width: 350px;
            font-size: 1.5rem;
        }

        /* Barra de progreso dentro del Toast */
        .toast-progress {
            height: 4px;
            width: 100%;
            background-color: #28a745;
            animation: progressBar 4s linear forwards;
        }

        @keyframes progressBar {
            from {
                width: 100%;
            }

            to {
                width: 0%;
            }
        }
    </style>--%>



</head>
<body>
    <form id="form1" runat="server">
        <!-- Barra de división superior -->
        <nav class="navbar navbar-expand-lg navbar-light bg-light">
            <div class="container">
                <a class="navbar-brand fw-bold" href="#">ENTREN<span class="text-warning">AR</span></a>
                <div class="d-flex">
                    <asp:Button runat="server" ID="btnRegistrarme" Text="Registrarme" OnClick="btnRegistrarme_Click" CssClass="btn btn-lg fw-bold btn-outline-warning" />
                    <%--<asp:Button runat="server" ID="btnLogin" Text="LOGIN" OnClick="btnLogin_Click" CssClass="btn btn-lg fw-bold btn-outline-warning" />--%>
                </div>
            </div>
        </nav>

        <asp:Label Text="PRUEBA MENSAAAAJEEE" ID="lblMessage" Visible="false" runat="server" />

        <!-- Cuadro Login-->
        <div class="d-flex justify-content-center align-items-center vh-100 bg-light">
            <div class="card p-4 shadow" style="width: 25rem;">
                <h4 class="text-center mb-3">Inicio de sesión</h4>
                <div class="mb-3">
                    <label for="txtUsername" class="form-label">Usuario</label>
                    <div class="input-group">
                        <span class="input-group-text"><i class="bi bi-person fs-5"></i></span>
                        <asp:TextBox runat="server" ID="txtUserName" placeholder="Usuario" class="form-control" />
                    </div>
                    <asp:RequiredFieldValidator ErrorMessage="Ingrese el nombre de usuario..." ControlToValidate="txtUserName" Display="Dynamic" ForeColor="Red" runat="server" />
                    <asp:CustomValidator ID="cvUserName" ErrorMessage="El nombre de usuario no existe..." ControlToValidate="txtUserName" OnServerValidate="cvUserName_ServerValidate" Display="Dynamic" ForeColor="Red" runat="server" />
                </div>
                <div class="mb-3">
                    <label for="txtUserPassword" class="form-label">Contraseña</label>
                    <div class="input-group">
                        <span class="input-group-text"><i class="bi bi-lock"></i></span>
                        <asp:TextBox runat="server" ID="txtUserPassword" type="password" placeholder="Password" class="form-control" />
                    </div>
                    <asp:RequiredFieldValidator ErrorMessage="Ingrese la contraseña..." ControlToValidate="txtUserPassword" Display="Dynamic" ForeColor="Red" runat="server" />
                    <asp:CustomValidator ID="cvUserPassword" ErrorMessage="Contraseña incorrecta..." ControlToValidate="txtUserPassword" OnServerValidate="cvUserPassword_ServerValidate" Display="Dynamic" ForeColor="Red" runat="server" />
                </div>
                <div class="d-grid">
                    <asp:Button runat="server" Text="Ingresar" ID="btnIngresar" OnClick="btnIngresar_Click" CssClass="btn btn-lg fw-bold btn-outline-warning" />
                </div>
            </div>
        </div>

        
        <%--TOAST!--%>
        <uc:Toast  ID="ucToast" runat="server" />

        <%--<button runat="server" onserverclick="btnCambiarMensaje_Click">Cambiar Mensaje</button>--%>
        <%--<asp:Button ID="btnControlUC" Text="CHANGE!" OnClick="btnControlUC_Click" CssClass="btn-primary" runat="server" />--%>


        <%--TOAST--%>

        <!-- Botón para activar el Toast -->
        <%--<button type="button" class="btn btn-primary" id="liveToastBtn">Mostrar Notificación</button>--%>

        <!-- Contenedor del Toast -->
        <%--<div class="toast-container position-fixed bottom-0 end-0 p-3">
            <div id="liveToast" class="toast align-items-center text-bg-light border-0 shadow-lg" role="alert" aria-live="assertive" aria-atomic="true" data-bs-delay="4000">

                <!-- Encabezado con icono y barra de progreso -->
                <div class="toast-header">
                    <span class="bi bi-check-circle-fill text-success fs-4 me-2"></span>
                    <strong class="me-auto" id="toastTitle">Éxito</strong>
                    <small id="toastTime">Ahora</small>
                    <button type="button" class="btn-close" data-bs-dismiss="toast" aria-label="Close"></button>
                </div>

                <!-- Barra de progreso -->
                <div class="toast-progress"></div>

                <!-- Cuerpo del Toast -->
                <div class="toast-body" id="toastMessage">
                    ¡Cambios guardados!
           
                </div>
            </div>
        </div>
        <%--TOAST--%>--%>



        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>


        <!-- Script para mostrar el Toast con personalización -->
        <%--<script>
            document.addEventListener("DOMContentLoaded", function () {
                const toastTrigger = document.getElementById("liveToastBtn");
                const toastLiveExample = document.getElementById("liveToast");
                const toastTitle = document.getElementById("toastTitle");
                const toastMessage = document.getElementById("toastMessage");
                const toastTime = document.getElementById("toastTime");

                if (toastTrigger) {
                    const toastBootstrap = new bootstrap.Toast(toastLiveExample);

                    toastTrigger.addEventListener("click", function () {
                        // Personalizar el título y el mensaje antes de mostrarlo
                        toastTitle.innerText = "Operación Exitosa";
                        toastMessage.innerText = "Tu información se ha guardado correctamente.";
                        toastTime.innerText = "";  /*"Hace un momento";*/

                        // Mostrar el Toast
                        toastBootstrap.show();
                    });
                }
            });
        </script>--%>

    </form>
</body>
</html>
