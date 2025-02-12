<%@ Page Title="" Language="C#" MasterPageFile="~/AllMaster.Master" AutoEventWireup="true" CodeBehind="NewPartner.aspx.cs" Inherits="ViewModel.TrainerNewClient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>--%>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" />
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="container my-5">
                <h2 class="mb-4">Alta de Partner</h2>
                <!-- Usuario y Contraseña -->
                <div class="row mb-3">
                    <div class="col-md-6">
                        <asp:Label Text="User" ID="lblUser" runat="server" class="form-label" />
                        <asp:TextBox runat="server" ID="txtUserName" class="form-control" placeholder="Nombre Usuari@" />
                        <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtUserName" ErrorMessage="El nombre es obligatorio" ForeColor="Red" Display="Dynamic" />
                    </div>
                    <div class="col-md-6">
                        <asp:Label Text="Password" ID="lblPassword" runat="server" class="form-label" />
                        <asp:TextBox runat="server" ID="txtPassWord" class="form-control" placeholder="Password" />
                        <small class="text-muted">* La contraseña debe contener al menos una mayúscula, una minúscula y un número.</small>
                    </div>
                </div>

                <!-- Nombre y Apellido -->
                <div class="row mb-3">
                    <div class="col-md-6">
                        <asp:Label Text="Nombre" ID="lblFirstName" runat="server" class="form-label" />
                        <asp:TextBox runat="server" ID="txtFirstName" class="form-control" placeholder="Nombre" />
                    </div>
                    <div class="col-md-6">
                        <asp:Label Text="Apellido" ID="lblLastName" runat="server" class="form-label" />
                        <asp:TextBox runat="server" ID="txtLastName" class="form-control" placeholder="Apellido" />
                    </div>
                </div>

                <!-- DNI-->
                <div class="row mb-3">
                    <div class="col-md-6">
                        <asp:Label Text="DNI" ID="lblDni" runat="server" class="form-label" />
                        <asp:TextBox runat="server" ID="txtDni" class="form-control" placeholder="DNI del cliente (sin espacios ni puntos)" />
                    </div>
                </div>

                <!-- Fecha de Nacimiento, Género y Nacionalidad -->
                <div class="row mb-3">
                    <div class="col-md-4">
                        <asp:Label Text="Fecha de nacimiento" ID="lblBirthDate" runat="server" class="form-label" />
                        <asp:TextBox runat="server" ID="txtBirthDate" TextMode="Date" class="form-control" placeholder="Fecha de nacimiento" />
                    </div>
                    <div class="col-md-4">
                        <asp:Label Text="Genero" ID="lblGender" runat="server" class="form-label" />
                        <asp:DropDownList ID="ddlGender" class="btn btn-outline-dark dropdown-toggle" runat="server">
                            <asp:ListItem Text="Femenino" />
                            <asp:ListItem Text="Masculino" />
                            <asp:ListItem Text="No informado" />
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-4">
                        <asp:Label Text="Nacionalidad" ID="lblCountry" runat="server" class="form-label" />
                        <asp:TextBox runat="server" ID="txtCountry" class="form-control" placeholder="Nacionalidad" />
                    </div>
                </div>

                <!-- Teléfono y Email -->
                <div class="row mb-3">
                    <div class="col-md-6">
                        <asp:Label Text="Teléfono" ID="lblPhone" runat="server" class="form-label" />
                        <asp:TextBox runat="server" ID="txtPhone" class="form-control" placeholder="Teléfono" />
                    </div>
                    <div class="col-md-6">
                        <asp:Label Text="Email" ID="lblEmail" runat="server" class="form-label" />
                        <asp:TextBox runat="server" ID="txtEmail" class="form-control" placeholder="Email" />
                    </div>
                </div>

                <!-- Calle y Número -->
                <div class="row mb-3">
                    <div class="col-md-6">
                        <asp:Label Text="Calle" ID="lblStreetName" runat="server" class="form-label" />
                        <asp:TextBox runat="server" ID="txtStreetName" class="form-control" placeholder="Calle" />
                    </div>
                    <div class="col-md-6">
                        <asp:Label Text="Numero" ID="lblStreetNumber" runat="server" class="form-label" />
                        <asp:TextBox runat="server" ID="txtStreetNumber" class="form-control" placeholder="Numero" />
                    </div>
                </div>

                <!-- Piso/Depto y Observaciones -->
                <div class="row mb-3">
                    <div class="col-md-6">
                        <asp:Label Text="Piso/Depto" ID="lblFlat" runat="server" class="form-label" />
                        <asp:TextBox runat="server" ID="txtFlat" class="form-control" placeholder="Piso/Depto" />
                    </div>
                    <div class="col-md-6">
                        <asp:Label Text="Observaciones" ID="lblDetails" runat="server" class="form-label" />
                        <asp:TextBox runat="server" ID="txtDetails" class="form-control" placeholder="Observaciones" />
                    </div>
                </div>

                <!-- Provincia, Localidad -->
                <div class="row mb-3">
                    <div class="col-md-4">
                        <asp:Label Text="Provincia" ID="lblProvince" runat="server" class="form-label" />
                        <asp:DropDownList ID="ddlProvince" DataValueField="idProvince" DataTextField="name" class="btn btn-outline-dark dropdown-toggle" autopostback="false" runat="server">
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-4">
                        <asp:Label Text="Localidad/Barrio" ID="lblCity" class="form-label" runat="server" />
                        <asp:TextBox runat="server" ID="txtCity" class="form-control" placeholder="Localidad/Barrio" />
                    </div>
                </div>

                <!-- Botón -->
                <div class="text-end">
                    <asp:Button Text="Dar de alta" ID="btnCreatePartner" OnClick="btnCreatePartner_Click" class="btn btn-warning" data-bs-toggle="modal" data-bs-target="#modalGuardarCambios" runat="server" />
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>


