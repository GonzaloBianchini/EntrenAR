<!--

<%@ Page Title="" Language="C#" MasterPageFile="~/AllMaster.Master" AutoEventWireup="true" CodeBehind="ViewPartner.aspx.cs" Inherits="ViewModel.ViewPartner" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container text-center">
        <div class="row justify-content-md-center">
            <div class="container mt-4">
                <h4 class="mb-3"><i class="bi bi-clock"></i>Gestión de Partners</h4>

                <div class="card p-3">
                    <div class="d-flex justify-content-between">
                        <h5><i class="bi bi-person"></i>Información Personal</h5>
                        <div>
                            <button class="btn btn-warning">Editar</button>
                            <button class="btn btn-warning">Gestionar</button>
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

                    <div class="col-md-12">
                        <asp:Button ID="btnLetsGoTraining" Text="A ENTRENAR!" class="btn btn-warning" OnClick="btnLetsGoTraining_Click" runat="server" />
                    </div>
                </div>

                <div class="card p-3 mt-4">
                    <h5><i class="bi bi-person-badge"></i>Trainer</h5>
                    <%--ESTA ETIQUETA JUEGA CUANDO NO HAY TRAINER--%>
                    <asp:Label ID="lblNoTrainer" Text="NO HAY TRAINER ASIGNAD@" runat="server" />
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
</asp:Content>

-->