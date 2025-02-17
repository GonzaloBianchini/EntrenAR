<%@ Page Title="" Language="C#" MasterPageFile="~/AllMaster.Master" AutoEventWireup="true" CodeBehind="ViewTrainer.aspx.cs" Inherits="ViewModel.ViewTrainer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container text-center">
        <div class="row justify-content-md-center">
            <div class="container mt-4">
                <h4 class="mb-3"><i class="bi bi-clock"></i>Gestión de Trainers</h4>

                <div class="card p-3">
                    <div class="d-flex justify-content-between">
                        <h5><i class="bi bi-person"></i>Información Personal</h5>
                        <%--<div>
                            <button class="btn btn-secondary">Editar</button>
                            <button class="btn btn-danger">Gestionar</button>
                        </div>--%>
                    </div>
                    <div class="row mt-3">
                        <div class="col-md-12 text-center">
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
                            <p>
                                <strong>User:</strong>
                                <asp:Label Text="text" ID="lblUser" runat="server" />
                            </p>
                        </div>
                        <%--<div class="col-md-6">
                            <p>
                                <strong>Domicilio:</strong>
                                <asp:Label Text="text" ID="lblAddress" runat="server" />
                            </p>
                            <p>
                                <strong>Localidad:</strong>
                                <asp:Label Text="text" ID="lblCity" runat="server" />
                            </p>
                            <p>
                                <strong>Provincia:</strong>
                                <asp:Label Text="text" ID="lblProvince" runat="server" />
                            </p>
                            <p>
                                <strong>Email:</strong>
                                <asp:Label Text="text" ID="lblEmail" runat="server" />
                            </p>
                            <p>
                                <strong>Teléfono:</strong>
                                <asp:Label Text="text" ID="lblPhone" runat="server" />
                            </p>
                            <p>
                                <strong>Estado:</strong>
                                <asp:Label Text="text" ID="lblStatusPartner" runat="server" />
                            </p>
                        </div>--%>
                    </div>
                </div>

                <div class="card p-3 mt-4">
                    <h5><i class="bi bi-list"></i>Partners Adjudicad@s</h5>
                    <%--ESTA ETIQUETA JUEGA CUANDO NO HAY PARTNERS--%>
                    <asp:Label ID="lblNoPartners" Text="NO HAY PARTNERS ADJUDICAD@S" runat="server" />
                    <asp:GridView runat="server" ID="dgvPartners" AutoGenerateColumns="false" DataKeyNames="idPartner" class="table mt-2">
                        <Columns>
                            <asp:BoundField DataField="IdPartner" HeaderText="ID PARTNER" />
                            <asp:BoundField DataField="firstName" HeaderText="NOMBRE" />
                            <asp:BoundField DataField="lastName" HeaderText="APELLIDO" />
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
                            <%--ACA VAN LOS DATOS DE PARTNER QUE SOLICITA TRAINER...
                            ACA VAN LOS DATOS DE PARTNER QUE SOLICITA TRAINER...
                            ACA VAN LOS DATOS DE PARTNER QUE SOLICITA TRAINER...--%>
                            <%--<asp:BoundField DataField="firstName" HeaderText="NOMBRE" />
                            <asp:BoundField DataField="lastName" HeaderText="APELLIDO" />
                            <asp:BoundField DataField="userName" HeaderText="USUARIO" />--%>
                            <asp:TemplateField HeaderText="Accion">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnAceptar" runat="server" CommandName="Aceptar" OnCommand="btnAceptar_Command" CommandArgument='<%# Eval("idRequest") %>' CssClass="btn btn-sm btn-warning">Aceptar</asp:LinkButton>
                                    <asp:LinkButton ID="btnRechazar" runat="server" CommandName="Rechazar" OnCommand="btnRechazar_Command" CommandArgument='<%# Eval("idRequest") %>' CssClass="btn btn-sm btn-warning">Rechazar</asp:LinkButton>
                                    <%--<asp:LinkButton ID="btnManageTrainings" runat="server" CommandName="Gestionar" OnCommand="btnManageTrainings_Command" CommandArgument='<%# Eval("idPartner") %>' CssClass="btn btn-sm btn-warning">Gestionar</asp:LinkButton>--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
