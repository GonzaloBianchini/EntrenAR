<%@ Page Title="" Language="C#" MasterPageFile="~/AllMaster.Master" AutoEventWireup="true" CodeBehind="NewTrainer.aspx.cs" Inherits="ViewModel.AdminNewTrainer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" />
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="container my-2">
                <h2 class="mb-4">Alta de Trainer</h2>

                <!-- Usuario -->
                <div class="row mb-3">
                    <div class="col-md-6">
                        <asp:Label Text="User" ID="lblUser" runat="server" class="form-label" />
                        <asp:TextBox runat="server" ID="txtUserName" class="form-control" placeholder="Nombre Usuari@ Trainer" />
                        <small class="text-muted">* Nombre de usuario: Al menos una letra. De 6 a 12 caracteres. No Mayusculas. No caracteres especiales.</small>
                        <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ControlToValidate="txtUserName" ErrorMessage="El nombre de usuario es requerido..." ForeColor="Red" Display="Dynamic" />
                        <asp:RegularExpressionValidator ID="revUserName" ValidationExpression="^(?=.*[a-z])[a-z0-9_]{6,20}$" ErrorMessage="Nombre de usuario invalido..." ControlToValidate="txtUserName" ForeColor="Red" Display="Dynamic" runat="server" />
                        <asp:CustomValidator ID="cvUserName" OnServerValidate="cvUserName_ServerValidate" ErrorMessage="Nombre de usuario ya utilizado..." ControlToValidate="txtUserName" ForeColor="Red" Display="Dynamic" runat="server" />
                    </div>
                    <!-- Contraseña -->
                    <div class="col-md-6">
                        <asp:Label Text="Password" ID="lblPassword" runat="server" class="form-label" />
                        <asp:TextBox runat="server" ID="txtUserPassword" class="form-control" TextMode="Password" placeholder="Password Trainer" />
                        <small class="text-muted">* La contraseña debe contener al menos una mayúscula, una minúscula y un número.</small>
                        <asp:RequiredFieldValidator ID="rfvPassword" ErrorMessage="La contraseña es requerida" ControlToValidate="txtUserPassWord" ForeColor="Red" Display="Dynamic" runat="server" />
                        <asp:RegularExpressionValidator ID="revPassword" ValidationExpression="^(?=.*[A-Z])(?=.*[a-z])(?=.*\d).+$" ErrorMessage="Contraseña invalida..." ControlToValidate="txtUserPassword" ForeColor="Red" Display="Dynamic" runat="server" />
                    </div>
                </div>

                <!-- Nombre y Apellido -->
                <div class="row mb-3">
                    <div class="col-md-6">
                        <asp:Label Text="Nombre" ID="lblFirstName" runat="server" class="form-label" />
                        <asp:TextBox runat="server" ID="txtFirstName" class="form-control" placeholder="Nombre" />
                        <asp:RequiredFieldValidator ID="rfvFirstName" ErrorMessage="El nombre es requerido..." ControlToValidate="txtFirstName" ForeColor="Red" Display="Dynamic" runat="server" />
                        <asp:RegularExpressionValidator ID="revFirstName" ValidationExpression="^[A-ZÁÉÍÓÚÑ][a-záéíóúñ]+(?: [A-ZÁÉÍÓÚÑ][a-záéíóúñ]+)*$" ErrorMessage="Nombre invalido..." ControlToValidate="txtFirstName" ForeColor="Red" Display="Dynamic" runat="server" />
                    </div>
                    <div class="col-md-6">
                        <asp:Label Text="Apellido" ID="lblLastName" runat="server" class="form-label" />
                        <asp:TextBox runat="server" ID="txtLastName" class="form-control" placeholder="Apellido" />
                        <asp:RequiredFieldValidator ID="rfvLastName" ErrorMessage="El apellido es requerido..." ControlToValidate="txtLastName" ForeColor="Red" Display="Dynamic" runat="server" />
                        <asp:RegularExpressionValidator ID="revLastName" ValidationExpression="^[A-ZÁÉÍÓÚÑ][a-záéíóúñ]+(?: [A-ZÁÉÍÓÚÑ][a-záéíóúñ]+)*$" ErrorMessage="Apellido invalido..." ControlToValidate="txtLastName" ForeColor="Red" Display="Dynamic" runat="server" />
                    </div>
                </div>

                <!-- DNI-->
                <div class="row mb-3">
                    <div class="col-md-6">
                        <asp:Label Text="DNI" ID="lblDni" runat="server" class="form-label" />
                        <asp:TextBox runat="server" ID="txtDni" class="form-control" placeholder="DNI del cliente (sin espacios ni puntos)" />
                        <asp:RequiredFieldValidator ID="rfvDni" ErrorMessage="El DNI es requerido..." ControlToValidate="txtDni" ForeColor="Red" Display="Dynamic" runat="server" />
                        <asp:RegularExpressionValidator ID="revDni" ValidationExpression="^\d{7,8}$" ErrorMessage="DNI invalido..." ControlToValidate="txtDni" ForeColor="Red" Display="Dynamic" runat="server" />
                        <asp:CustomValidator ID="cvDni" OnServerValidate="cvDni_ServerValidate" ErrorMessage="El DNI pertenece a otr@ Partner..." ControlToValidate="txtDni" ForeColor="Red" Display="Dynamic" runat="server" />
                    </div>
                </div>

                <!-- Teléfono y Email -->
                <div class="row mb-3">
                    <div class="col-md-6">
                        <asp:Label Text="Teléfono" ID="lblPhone" runat="server" class="form-label" />
                        <asp:TextBox runat="server" ID="txtPhone" class="form-control" placeholder="Teléfono" />
                        <asp:RequiredFieldValidator ID="rfvPhone" ErrorMessage="Telefono requerido..." ControlToValidate="txtPhone" ForeColor="Red" Display="Dynamic" runat="server" />
                        <asp:RegularExpressionValidator ID="revPhone" ValidationExpression="^\+?\d{1,3}[-.\s]?\(?\d{2,4}\)?[-.\s]?\d{3,4}[-.\s]?\d{3,4}$" ErrorMessage="Telefono invalido..." ControlToValidate="txtPhone" ForeColor="Red" Display="Dynamic" runat="server" />
                    </div>
                    <div class="col-md-6">
                        <asp:Label Text="Email" ID="lblEmail" runat="server" class="form-label" />
                        <asp:TextBox runat="server" ID="txtEmail" class="form-control" placeholder="Email" />
                        <asp:RequiredFieldValidator ID="rfvEmail" ErrorMessage="Email requerido..." ControlToValidate="txtEmail" ForeColor="Red" Display="Dynamic" runat="server" />
                        <asp:RegularExpressionValidator ID="revEmail" ValidationExpression="^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$" ErrorMessage="Email invalido..." ControlToValidate="txtEmail" ForeColor="Red" Display="Dynamic" runat="server" />
                        <asp:CustomValidator ID="cvEmail" OnServerValidate="cvEmail_ServerValidate" ErrorMessage="El Email pertenece a otr@ Partner..." ControlToValidate="txtEmail" ForeColor="Red" Display="Dynamic" runat="server" />
                    </div>
                </div>

                <!-- Botón -->
                <div class="text-end">
                    <asp:Button Text="Dar de alta" ID="btnCreateTrainer" OnClick="btnCreateTrainer_Click" CssClass="btn btn-lg fw-bold btn-outline-warning" data-bs-toggle="modal" data-bs-target="#modalGuardarCambios" runat="server" />
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
