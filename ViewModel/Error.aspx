<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="ViewModel.Error" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>EntrenAr</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.min.css" />
    <link href="\content\MyStyles.css" rel="stylesheet" />
    <style>
        .error-container {
            text-align: center;
            margin-top: 10%;
        }

        .error-image {
            max-width: 400px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container error-container">
            <h1 class="text-danger fw-bold">¡Ups! Algo salió mal</h1>
            <p class="lead text-muted">Ocurrió un error inesperado en la aplicación. Por favor, inténtelo nuevamente más tarde.</p>

            <img src="~/Images/error404.jpg" class="error-image img-fluid my-3" runat="server" />

            <div class="container">
                <asp:Label ID="lblErrorMessage" CssClass="mb-3 h3" Text="" runat="server" />
            </div>
            <div>
                <asp:Button ID="btnVolver" runat="server" Text="Volver al inicio" CssClass="btn btn-lg fw-bold btn-warning mt-3" OnClick="btnVolver_Click" />
            </div>
        </div>
    </form>
</body>
</html>
