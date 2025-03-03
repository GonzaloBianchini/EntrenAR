<%@ Page Title="" Language="C#" MasterPageFile="~/AllMaster.Master" AutoEventWireup="true" CodeBehind="zSuperadoViewTrainer.aspx.cs" Inherits="ViewModel.ViewTrainer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" />
    <asp:UpdatePanel ID="udpTrainer" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <div class="container text-center">
                <div class="row justify-content-md-center">
                    <div class="container mt-4">
                        <h4 class="mb-3"><i class="bi bi-clock"></i>Gestión de Trainers</h4>

                        <div class="card p-3">
                            <div class="d-flex justify-content-between">
                                <h5><i class="bi bi-person"></i>Información Personal</h5>
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
                                    <asp:BoundField DataField="partner.firstName" HeaderText="NOMBRE" />
                                    <asp:BoundField DataField="partner.lastName" HeaderText="APELLIDO" />
                                    <asp:BoundField DataField="creationDate" HeaderText="FECHA DE CREACION" />
                                    <asp:TemplateField HeaderText="Accion">
                                        <ItemTemplate>
                                            <%--<asp:Button ID="btnAceptar" OnClick="btnAceptar_Click"  CssClass="btn btn-sm btn-warning" data-bs-toggle="modal" data-bs-target="#modalRequest" Text="Aceptar" runat="server" />
                                            <asp:Button ID="btnRechazar" OnClick="btnRechazar_Click" CssClass="btn btn-sm btn-warning" data-bs-toggle="modal" data-bs-target="#modalRequest" Text="Rechazar" runat="server" />--%>
                                            <asp:LinkButton ID="btnAceptar" runat="server" CommandName="Aceptar" OnCommand="btnAceptar_Command" CommandArgument='<%# Eval("idRequest") %>' CssClass="btn btn-sm btn-warning" >Aceptar</asp:LinkButton>
                                            <asp:LinkButton ID="btnRechazar" runat="server" CommandName="Rechazar" OnCommand="btnRechazar_Command" CommandArgument='<%# Eval("idRequest") %>' CssClass="btn btn-sm btn-warning" >Rechazar</asp:LinkButton>
                                            <%--<asp:LinkButton ID="btnManageTrainings" runat="server" CommandName="Gestionar" OnCommand="btnManageTrainings_Command" CommandArgument='<%# Eval("idPartner") %>' CssClass="btn btn-sm btn-warning">Gestionar</asp:LinkButton>--%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
