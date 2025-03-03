<%@ Page Title="" Language="C#" MasterPageFile="~/AllMaster.Master" AutoEventWireup="true" CodeBehind="ViewTrainers.aspx.cs" Inherits="ViewModel.ViewTrainers" %>

<%@ Register Src="~/Toast.ascx" TagPrefix="uc" TagName="Toast" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" />
    <asp:UpdatePanel ID="udpPartners" runat="server">
        <ContentTemplate>

            <%--TOAST--%>
            <uc:Toast ID="ucToast" runat="server" />

            <div class="row justify-content-between">
                <div class="col-md-3">
                    <h1>Trainers</h1>
                </div>
                <div class="col-md-3">
                    <div class="d-grid gap-2 d-md-flex justify-content-md-end">
                        <asp:Button ID="btnCreateTrainer" OnClick="btnCreateTrainer_Click" Text="Crear" CssClass="btn btn-lg fw-bold btn-outline-warning" runat="server" />
                    </div>
                </div>
            </div>

            <%--LISTA TRAINERS--%>
            <div class="container text-center">
                <div class="row justify-content-md-center">
                    <asp:GridView runat="server" ID="dgvTrainersList" AutoGenerateColumns="false" DataKeyNames="idTrainer" class="table table-striped table-bordered table-hover mt-3">
                        <Columns>
                            <asp:BoundField DataField="idTrainer" HeaderText="ID TRAINER" />
                            <asp:BoundField DataField="firstName" HeaderText="NOMBRE" />
                            <asp:BoundField DataField="lastName" HeaderText="APELLIDO" />
                            <asp:BoundField DataField="userName" HeaderText="Usuari@" />
                            <asp:TemplateField HeaderText="Accion">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnViewTrainer" OnCommand="btnViewTrainer_Command" runat="server" CommandName="Ver" CommandArgument='<%# Eval("idTrainer") %>' CssClass="btn btn-md fw-bold btn-outline-warning">Ver</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                    <!-- Sección de Detalles de Trainer -->
                    <%--MUESTRO U ESCONDO EL PANEL EN CASO QUE NO SE HAYA SELECCIONADO NINGUN TRAINER--%>
                    <asp:Panel ID="pnlTrainerDetails" runat="server" CssClass="mt-4 p-4 border rounded shadow-sm bg-light" Visible="false">
                        <h3 class="mb-3 text-center">Detalles de Trainer</h3>

                        <div class="row">
                            <%--ACA PONGO BLOQUE DE VIEW TRAINER PERSONAL INFORMATION--%>
                            <div class="container text-center">
                                <div class="row justify-content-md-center">
                                    <div class="container mt-4">
                                        <div class="card p-3">
                                            <div class="d-flex justify-content-between">
                                                <h5><i class="bi bi-person"></i>Información Personal</h5>
                                                <div>
                                                    <asp:Button ID="btnEditTrainer" OnClick="btnEditTrainer_Click" Text="Editar Datos Personales" CssClass="btn btn-md fw-bold btn-outline-warning" Visible="true" runat="server" />
                                                    <%--<asp:Button ID="btnManageTrainer" OnClick="btnManageTrainer_Click" Text="Gestionar Entrenamientos" CssClass="btn btn-md fw-bold btn-outline-warning" Visible="true" runat="server" />--%>
                                                </div>
                                            </div>
                                            <div class="row mt-3">
                                                <div class="col-md-6">
                                                    <p>
                                                        <strong>ID:</strong>
                                                        <asp:Label Text="text" ID="lblIdTrainer" runat="server" />
                                                    </p>
                                                    <p>
                                                        <strong>Nombre:</strong>
                                                        <asp:Label Text="text" ID="lblFirstName" runat="server" />
                                                    </p>
                                                    <p>
                                                        <strong>Apellido:</strong>
                                                        <asp:Label Text="text" ID="lblLastName" runat="server" />
                                                    </p>
                                                </div>
                                                <div class="col-md-6">
                                                    <p>
                                                        <strong>Nombre Usuari@:</strong>
                                                        <asp:Label Text="text" ID="lblUserName" runat="server" />
                                                    </p>
                                                    <p>
                                                        <strong>Email:</strong>
                                                        <asp:Label Text="text" ID="lblEmail" runat="server" />
                                                    </p>
                                                    <p>
                                                        <strong>Teléfono:</strong>
                                                        <asp:Label Text="text" ID="lblPhone" runat="server" />
                                                    </p>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="card p-3 mt-4">
                                            <h4><i class="bi bi-person-badge"></i>Trainer</h4>

                                            <%--ESTA ETIQUETA JUEGA CUANDO NO HAY PARTNERS--%>
                                            <asp:Label ID="lblNoPartners" Text="NO HAY PARTNERS ASIGNAD@S" CssClass="h5" runat="server" />

                                            <asp:GridView runat="server" ID="dgvPartners" AutoGenerateColumns="false" DataKeyNames="idPartner" class="table mt-2">
                                                <Columns>
                                                    <asp:BoundField DataField="idPartner" HeaderText="ID PARTNER" />
                                                    <asp:BoundField DataField="firstName" HeaderText="NOMBRE" />
                                                    <asp:BoundField DataField="lastName" HeaderText="APELLIDO" />
                                                    <asp:BoundField DataField="userName" HeaderText="USUARI@" />
                                                </Columns>
                                            </asp:GridView>
                                        </div>

                                        <div class="card p-3 mt-4">
                                            <h5><i class="bi bi-person-badge"></i>Solicitudes Pendientes</h5>
                                            <%--ESTA ETIQUETA JUEGA CUANDO NO HAY SOLICITUDES--%>
                                            <asp:Label ID="lblNoRequests" Text="NO HAY SOLICITUDES PENDIENTES" runat="server" />
                                            <asp:GridView runat="server" ID="dgvRequests" AutoGenerateColumns="false" DataKeyNames="idRequest" class="table mt-2">
                                                <Columns>
                                                    <asp:BoundField DataField="idRequest" HeaderText="ID SOLICITUD" />
                                                    <asp:BoundField DataField="partner.firstName" HeaderText="NOMBRE" />
                                                    <asp:BoundField DataField="partner.lastName" HeaderText="APELLIDO" />
                                                    <asp:BoundField DataField="creationDate" HeaderText="FECHA DE CREACION" />
                                                    <asp:TemplateField HeaderText="Accion">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnAceptar" runat="server" CommandName="Aceptar" OnCommand="btnAceptar_Command" CommandArgument='<%# Eval("idRequest") %>' CssClass="btn btn-sm btn-warning">Aceptar</asp:LinkButton>
                                                            <asp:LinkButton ID="btnRechazar" runat="server" CommandName="Rechazar" OnCommand="btnRechazar_Command" CommandArgument='<%# Eval("idRequest") %>' CssClass="btn btn-sm btn-warning">Rechazar</asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>

                                    </div>
                                </div>
                            </div>
                            <%--ACA FIN BLOQUE DE VIEW TRAINER--%>
                        </div>
                    </asp:Panel>
                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
