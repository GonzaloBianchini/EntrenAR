<%@ Page Title="" Language="C#" MasterPageFile="~/AllMaster.Master" AutoEventWireup="true" CodeBehind="ViewPartners.aspx.cs" Inherits="ViewModel.ViewPartners" %>

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
                    <h1>Partners</h1>
                </div>
                <div class="col-md-3">
                    <div class="d-grid gap-2 d-md-flex justify-content-md-end">
                        <asp:Button ID="btnCreatePartner" OnClick="btnCreatePartner_Click" Text="Crear" CssClass="btn btn-lg fw-bold btn-outline-warning" runat="server" />
                    </div>
                </div>
            </div>

            <div class="container text-center">
                <div class="row justify-content-md-center">
                    <asp:GridView runat="server" ID="dgvPartnersList" AutoGenerateColumns="false" DataKeyNames="idPartner" class="table table-striped table-bordered table-hover mt-3">
                        <Columns>
                            <asp:BoundField DataField="idPartner" HeaderText="ID PARTNER" />
                            <asp:BoundField DataField="firstName" HeaderText="NOMBRE" />
                            <asp:BoundField DataField="lastName" HeaderText="APELLIDO" />
                            <asp:BoundField DataField="email" HeaderText="EMAIL" />
                            <asp:BoundField DataField="status.Name" HeaderText="ESTADO" />
                            <asp:TemplateField HeaderText="Accion">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnViewPartner" runat="server" CommandName="Ver" OnCommand="btnViewPartner_Command" CommandArgument='<%# Eval("idPartner") %>' CssClass="btn btn-md fw-bold btn-outline-warning">Ver</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                    <!-- Sección de Detalles de Partner -->
                    <%--MUESTRO U ESCONDO EL PANEL EN CASO QUE NO SE HAYA SELECCIONADO NINGUN PARTNER--%>
                    <asp:Panel ID="pnlPartnerDetails" runat="server" CssClass="mt-4 p-4 border rounded shadow-sm bg-light" Visible="false">
                        <h3 class="mb-3 text-center">Detalles de Partner</h3>

                        <div class="row">
                            <%--ACA PONGO BLOQUE DE VIEW PARTNER--%>
                            <div class="container text-center">
                                <div class="row justify-content-md-center">
                                    <div class="container mt-4">
                                        <div class="card p-3">
                                            <div class="d-flex justify-content-between">
                                                <h5><i class="bi bi-person"></i>Información Personal</h5>
                                                <div>
                                                    <asp:Button ID="btnEditPartner" OnClick="btnEditPartner_Click" Text="Editar Datos Personales" CssClass="btn btn-md fw-bold btn-outline-warning" Visible="true" runat="server" />
                                                    <asp:Button ID="btnManagePartner" OnClick="btnManagePartner_Click" Text="Gestionar Entrenamientos" CssClass="btn btn-md fw-bold btn-outline-warning" Visible="true" runat="server" />
                                                </div>
                                            </div>
                                            <div class="row mt-3">
                                                <div class="col-md-6">
                                                    <p>
                                                        <strong>ID:</strong>
                                                        <asp:Label Text="text" ID="lblIdPartner" runat="server" />
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
                                                        <strong>DNI:</strong>
                                                        <asp:Label Text="text" ID="lblDni" runat="server" />
                                                    </p>
                                                    <p>
                                                        <strong>Fecha de nacimiento:</strong>
                                                        <asp:Label Text="text" ID="lblBirthDate" runat="server" />
                                                    </p>
                                                    <p>
                                                        <strong>Género:</strong>
                                                        <asp:Label Text="text" ID="lblGender" runat="server" />
                                                    </p>
                                                    <p>
                                                        <strong>Nacionalidad:</strong>
                                                        <asp:Label Text="text" ID="lblCountry" runat="server" />
                                                    </p>
                                                </div>
                                                <div class="col-md-6">
                                                    <p>
                                                        <strong>Nombre Usuari@:</strong>
                                                        <asp:Label Text="text" ID="lblUserName" runat="server" />
                                                    </p>
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
                                                        <%--<span class="badge bg-success">Activo</span>--%>
                                                        <asp:Label Text="text" ID="lblStatusPartner" runat="server" />
                                                    </p>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="card p-3 mt-4">
                                            <h5><i class="bi bi-list"></i>Planes de Entrenamiento</h5>

                                            <%--ESTA ETIQUETA JUEGA CUANDO NO HAY TRAININGS--%>
                                            <asp:Label ID="lblNoTrainings" Text="NO HAY ENTRENAMIENOS ASIGNADOS" runat="server" />

                                            <asp:GridView runat="server" ID="dgvTrainings" AutoGenerateColumns="false" DataKeyNames="idTraining" class="table mt-2">
                                                <Columns>
                                                    <asp:BoundField DataField="IdTraining" HeaderText="ID TRAINING" />
                                                    <asp:BoundField DataField="Name" HeaderText="NOMBRE" />
                                                    <asp:BoundField DataField="Type.Name" HeaderText="TIPO" />
                                                    <%--ACA DEBERIA DE IR EL ESTADO DEL TRAINING, QUIZAS UN TRAINING TYPE: No iniciado,En curso,Finalizado--%>
                                                    <%--<asp:BoundField DataField="userName" HeaderText="USUARIO" />--%>
                                                </Columns>
                                            </asp:GridView>

                                        </div>

                                        <div class="card p-3 mt-4">
                                            <h4><i class="bi bi-person-badge"></i>Trainer</h4>

                                            <%--ESTA ETIQUETA y EL BOTON JUEGAN CUANDO NO HAY TRAINER--%>
                                            <asp:Label ID="lblNoTrainer" Text="NO HAY TRAINER ASIGNAD@" CssClass="h5" runat="server" />

                                            <div class="col-md-12">
                                                <asp:Button ID="btnLetsGoTraining" Visible="true" Text="Solicitar Trainer" CssClass="btn btn-warning fw-bold" OnClick="btnLetsGoTraining_Click" runat="server" />
                                            </div>

                                            <div cssclass="col-md-12">
                                                <asp:Label ID="lblRequestSent" Visible="false" Text="SOLICITUD EN REVISION..." CssClass="h5" runat="server" />
                                            </div>

                                            <asp:GridView runat="server" ID="dgvTrainer" AutoGenerateColumns="false" DataKeyNames="idTrainer" class="table mt-2">
                                                <Columns>
                                                    <asp:BoundField DataField="idTrainer" HeaderText="ID TRAINER" />
                                                    <asp:BoundField DataField="firstName" HeaderText="NOMBRE" />
                                                    <asp:BoundField DataField="lastName" HeaderText="APELLIDO" />
                                                    <asp:BoundField DataField="userName" HeaderText="USUARIO" />
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <%--ACA FIN BLOQUE DE VIEW PARTNER--%>
                        </div>
                    </asp:Panel>
                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
