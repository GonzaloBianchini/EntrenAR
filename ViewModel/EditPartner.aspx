<%@ Page Title="" Language="C#" MasterPageFile="~/AllMaster.Master" AutoEventWireup="true" CodeBehind="EditPartner.aspx.cs" Inherits="ViewModel.EditPartner" %>

<%@ Register Src="~/Toast.ascx" TagPrefix="uc" TagName="Toast" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" />
    <asp:UpdatePanel runat="server">
        <ContentTemplate>

            <%--TOAST--%>
            <uc:Toast ID="ucToast" runat="server" />


            <%--LABEL INVISIBLE PARA GUARDAR LE USERNAME VIEJ@...--%>
            <asp:Label ID="lblTxtOldUserName" Text="" Visible="false" runat="server" />
            <%--LABEL INVISIBLE PARA GUARDAR EL DNI VIEJO...--%>
            <asp:Label ID="lblTxtOldDni" Text="" Visible="false" runat="server" />
            <%--LABEL INVISIBLE PARA GUARDAR EL EMAIL VIEJO...--%>
            <asp:Label ID="lblTxtOldEmail" Text="" Visible="false" runat="server" />

            <div class="container my-2">
                <h2 class="mb-4">Editar Partner</h2>
                <%--id Partner--%>
                <div class="row mb-3">
                    <div class="col-md-3">
                        <asp:Label Text="Id Partner" ID="lblIdPartner" runat="server" class="form-label" />
                        <asp:TextBox ID="txtIdPartner" ReadOnly="true" class="form-control" runat="server" />
                    </div>
                </div>
                <!-- Usuario-->
                <div class="row mb-3">
                    <div class="col-md-6">
                        <asp:Label Text="User" ID="lblUser" runat="server" class="form-label" />
                        <asp:TextBox runat="server" ID="txtUserName" class="form-control" placeholder="Nombre Usuari@" />
                        <small class="text-muted">* Nombre de usuario: Al menos una letra. De 6 a 12 caracteres. No Mayusculas. No caracteres especiales.</small>
                        <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ControlToValidate="txtUserName" ErrorMessage="El nombre de usuario es requerido..." ForeColor="Red" Display="Dynamic" />
                        <asp:RegularExpressionValidator ID="revUserName" ValidationExpression="^(?=.*[a-z])[a-z0-9_]{6,20}$" ErrorMessage="Nombre de usuario invalido..." ControlToValidate="txtUserName" ForeColor="Red" Display="Dynamic" runat="server" />
                        <asp:CustomValidator ID="cvUserName" OnServerValidate="cvUserName_ServerValidate" ErrorMessage="Nombre de usuario ya utilizado..." ControlToValidate="txtUserName" ForeColor="Red" Display="Dynamic" runat="server" />
                    </div>
                    <!-- Contraseña -->
                    <div class="col-md-6">
                        <asp:Label Text="Password" ID="lblPassword" runat="server" class="form-label" />
                        <asp:TextBox ID="txtPassWord" TextMode="Password" class="form-control" placeholder="Password" runat="server" />
                        <small class="text-muted">* La contraseña debe contener al menos una mayúscula, una minúscula y un número.</small>
                        <asp:RequiredFieldValidator ID="rfvPassword" ErrorMessage="La contraseña es requerida" ControlToValidate="txtPassWord" ForeColor="Red" Display="Dynamic" runat="server" />
                        <asp:RegularExpressionValidator ID="revPassword" ValidationExpression="^(?=.*[A-Z])(?=.*[a-z])(?=.*\d).+$" ErrorMessage="Contraseña invalida..." ControlToValidate="txtPassword" ForeColor="Red" Display="Dynamic" runat="server" />
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

                <!-- DNI, Fecha de Nacimiento,  Género-->
                <div class="row mb-3">
                    <div class="col-md-6">
                        <asp:Label Text="DNI" ID="lblDni" runat="server" class="form-label" />
                        <asp:TextBox runat="server" ID="txtDni" class="form-control" placeholder="DNI del cliente (sin espacios ni puntos)" />
                        <asp:RequiredFieldValidator ID="rfvDni" ErrorMessage="El DNI es requerido..." ControlToValidate="txtDni" ForeColor="Red" Display="Dynamic" runat="server" />
                        <asp:RegularExpressionValidator ID="revDni" ValidationExpression="^\d{7,8}$" ErrorMessage="DNI invalido..." ControlToValidate="txtDni" ForeColor="Red" Display="Dynamic" runat="server" />
                        <asp:CustomValidator ID="cvDni" OnServerValidate="cvDni_ServerValidate" ErrorMessage="El DNI pertenece a otr@ Partner..." ControlToValidate="txtDni" ForeColor="Red" Display="Dynamic" runat="server" />
                    </div>
                    <div class="col-md-3">
                        <asp:Label Text="Fecha de nacimiento" ID="lblBirthDate" runat="server" class="form-label" />
                        <asp:TextBox runat="server" ID="txtBirthDate" TextMode="Date" class="form-control" placeholder="Fecha de nacimiento" />
                        <asp:RequiredFieldValidator ID="rfvBirthDate" ErrorMessage="Fecha de nacimiento requerida..." ControlToValidate="txtBirthDate" ForeColor="Red" Display="Dynamic" runat="server" />
                    </div>
                    <div class="col-md-3">
                        <div class="row">
                            <asp:Label Text="Genero" ID="lblGender" runat="server" class="form-label" />
                        </div>
                        <div class="row">
                            <asp:DropDownList ID="ddlGender" class="btn btn-outline-dark dropdown-toggle" runat="server">
                                <asp:ListItem Text="Femenino" />
                                <asp:ListItem Text="Masculino" />
                                <asp:ListItem Text="No informado" />
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>

                <!-- Teléfono, Nacionalidad & Email -->
                <div class="row mb-3">
                    <div class="col-md-3">
                        <asp:Label Text="Teléfono" ID="lblPhone" runat="server" class="form-label" />
                        <asp:TextBox runat="server" ID="txtPhone" class="form-control" placeholder="Teléfono" />
                        <asp:RequiredFieldValidator ID="rfvPhone" ErrorMessage="Telefono requerido..." ControlToValidate="txtPhone" ForeColor="Red" Display="Dynamic" runat="server" />
                        <asp:RegularExpressionValidator ID="revPhone" ValidationExpression="^\+?\d{1,3}[-.\s]?\(?\d{2,4}\)?[-.\s]?\d{3,4}[-.\s]?\d{3,4}$" ErrorMessage="Telefono invalido..." ControlToValidate="txtPhone" ForeColor="Red" Display="Dynamic" runat="server" />
                    </div>
                    <div class="col-md-3">
                        <asp:Label Text="Nacionalidad" ID="lblCountry" runat="server" class="form-label" />
                        <asp:TextBox runat="server" ID="txtCountry" class="form-control" placeholder="Nacionalidad" />
                        <asp:RequiredFieldValidator ID="rfvCountry" ErrorMessage="Pais requerido..." ControlToValidate="txtCountry" ForeColor="Red" Display="Dynamic" runat="server" />
                        <asp:RegularExpressionValidator ID="revCountry" ValidationExpression="^[A-ZÁÉÍÓÚÑ][a-záéíóúñ]+(?:[\s-][A-ZÁÉÍÓÚÑa-záéíóúñ]+)*$" ErrorMessage="Pais invalido..." ControlToValidate="txtCountry" ForeColor="Red" Display="Dynamic" runat="server" />
                    </div>
                    <div class="col-md-6">
                        <asp:Label Text="Email" ID="lblEmail" runat="server" class="form-label" />
                        <asp:TextBox runat="server" ID="txtEmail" class="form-control" placeholder="Email" />
                        <asp:RequiredFieldValidator ID="rfvEmail" ErrorMessage="Email requerido..." ControlToValidate="txtEmail" ForeColor="Red" Display="Dynamic" runat="server" />
                        <asp:RegularExpressionValidator ID="revEmail" ValidationExpression="^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$" ErrorMessage="Email invalido..." ControlToValidate="txtEmail" ForeColor="Red" Display="Dynamic" runat="server" />
                        <asp:CustomValidator ID="cvEmail" OnServerValidate="cvEmail_ServerValidate" ErrorMessage="El Email pertenece a otr@ Partner..." ControlToValidate="txtEmail" ForeColor="Red" Display="Dynamic" runat="server" />
                    </div>
                </div>

                <!-- Calle, Número y Piso/Depto -->
                <div class="row mb-3">
                    <div class="col-md-6">
                        <asp:Label Text="Calle" ID="lblStreetName" runat="server" class="form-label" />
                        <asp:TextBox runat="server" ID="txtStreetName" class="form-control" placeholder="Calle" />
                        <asp:RequiredFieldValidator ID="rfvStreetName" ErrorMessage="Calle requerida..." ControlToValidate="txtStreetName" ForeColor="Red" Display="Dynamic" runat="server" />
                        <asp:RegularExpressionValidator ID="revStreetName" ValidationExpression="^[a-zA-ZÀ-ÿ0-9\s.,'°-]{3,50}$" ErrorMessage="Calle invalida..." ControlToValidate="txtStreetName" ForeColor="Red" Display="Dynamic" runat="server" />
                    </div>
                    <div class="col-md-3">
                        <asp:Label Text="Numero" ID="lblStreetNumber" runat="server" class="form-label" />
                        <asp:TextBox runat="server" ID="txtStreetNumber" class="form-control" placeholder="Numero" />
                        <asp:RequiredFieldValidator ID="rfvStreetNumber" ErrorMessage="Numero requerido..." ControlToValidate="txtStreetNumber" ForeColor="Red" Display="Dynamic" runat="server" />
                        <asp:RegularExpressionValidator ID="revStreetNumber" ValidationExpression="^\d{1,5}[a-zA-Z]?$" ErrorMessage="Numero invalido..." ControlToValidate="txtStreetNumber" ForeColor="Red" Display="Dynamic" runat="server" />
                    </div>
                    <div class="col-md-3">
                        <asp:Label Text="Piso/Depto" ID="lblFlat" runat="server" class="form-label" />
                        <asp:TextBox runat="server" ID="txtFlat" class="form-control" placeholder="Piso/Depto" />
                        <asp:RegularExpressionValidator ID="revFlat" ValidationExpression="^([a-zA-Z0-9\s\-]{1,10})?$" ErrorMessage="Piso/Dpto invalido..." ControlToValidate="txtFlat" ForeColor="Red" Display="Dynamic" runat="server" />
                    </div>
                </div>

                <!-- Observaciones, Localidad y Provincia-->
                <div class="row mb-3">
                    <div class="col-md-6">
                        <asp:Label Text="Observaciones" ID="lblDetails" runat="server" class="form-label" />
                        <asp:TextBox runat="server" ID="txtDetails" class="form-control" placeholder="Observaciones" />
                        <asp:RegularExpressionValidator ID="revDetails" ValidationExpression="^([\wÀ-ÿ0-9\s.,'°\-]{0,50})?$" ErrorMessage="Observacion invalida..." ControlToValidate="txtDetails" ForeColor="Red" Display="Dynamic" runat="server" />
                    </div>
                    <div class="col-md-3">
                        <asp:Label Text="Localidad/Barrio" ID="lblCity" class="form-label" runat="server" />
                        <asp:TextBox runat="server" ID="txtCity" class="form-control" placeholder="Localidad/Barrio" />
                        <asp:RequiredFieldValidator ID="rfvCity" ErrorMessage="Localidad requerida..." ControlToValidate="txtCity" ForeColor="Red" Display="Dynamic" runat="server" />
                        <asp:RegularExpressionValidator ID="revCity" ValidationExpression="^[a-zA-ZáéíóúÁÉÍÓÚñÑ0-9\s]{1,50}$" ErrorMessage="Localidad invalida..." ControlToValidate="txtCity" ForeColor="Red" Display="Dynamic" runat="server" />
                    </div>
                    <div class="col-md-3">
                        <div class="row">
                            <asp:Label Text="Provincia" ID="lblProvince" runat="server" class="form-label" />
                        </div>
                        <div class="row">
                            <asp:DropDownList ID="ddlProvince" DataValueField="idProvince" DataTextField="name" class="btn btn-outline-dark dropdown-toggle" AutoPostBack="false" runat="server">
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>

                <!-- Botón -->
                <div class="text-end">
                    <asp:Button Text="Actualizar" ID="btnEditPartner" OnClick="btnEditPartner_Click" class="btn btn-lg fw-bold btn-outline-warning" runat="server" />
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
