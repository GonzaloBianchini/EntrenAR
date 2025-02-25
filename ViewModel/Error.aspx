<%@ Page Title="" Language="C#" MasterPageFile="~/AllMaster.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="ViewModel.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .error-container {
            text-align: center;
            margin-top: 10%;
        }
        .error-image {
            max-width: 400px;
        }
    </style>
    
    <div class="container error-container">
        <h1 class="text-danger fw-bold">¡Ups! Algo salió mal</h1>
        <p class="lead text-muted">Ocurrió un error inesperado en la aplicación. Por favor, inténtelo nuevamente más tarde.</p>

        <img src="~/Images/error404.jpg" class="error-image img-fluid my-3" runat="server" />

        <div>
            <asp:Button ID="btnVolver" runat="server" Text="Volver al inicio" CssClass="btn btn-primary mt-3" OnClick="btnVolver_Click" />
        </div>
    </div>

</asp:Content>
