<%@ Page Title="" Language="C#" MasterPageFile="~/AllMaster.Master" AutoEventWireup="true" CodeBehind="DashBoard.aspx.cs" Inherits="ViewModel.DashBoard" %>

<%@ Register Src="~/Toast.ascx" TagPrefix="uc" TagName="toast" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" />

    <%--TOAST--%>
    <uc:toast ID="ucToast" runat="server" />

    <%--ADMIN PANEL--%>
    <asp:Panel ID="AdminPanel" runat="server" Visible="false">
        <h1>ADMIN PANEL</h1>
        <div class="container">
            <h2 class="text-center">EntrenAr</h2>
            <h3 class="text-center">Métricas</h3>

            <div class="row">
                <div class="col-md-3">
                    <div class="card text-white bg-primary mb-3">
                        <div class="card-header">Total Partners</div>
                        <div class="card-body">
                            <h3 class="card-title">
                                <asp:Label ID="lblTotalPartners" runat="server" Text="0"></asp:Label></h3>
                        </div>
                    </div>
                </div>

                <div class="col-md-3">
                    <div class="card text-white bg-success mb-3">
                        <div class="card-header">Partners Asignados(Assigned)</div>
                        <div class="card-body">
                            <h3 class="card-title">
                                <asp:Label ID="lblPartnersAssigned" runat="server" Text=""></asp:Label></h3>
                        </div>
                    </div>
                </div>

                <div class="col-md-3">
                    <div class="card text-white bg-warning mb-3">
                        <div class="card-header">Partners Disponibles(Availables)</div>
                        <div class="card-body">
                            <h3 class="card-title">
                                <asp:Label ID="lblPartnersAvailable" runat="server" Text=""></asp:Label></h3>
                        </div>
                    </div>
                </div>

                <div class="col-md-3">
                    <div class="card text-white bg-danger mb-3">
                        <div class="card-header">Partners en Revisión(Pending)</div>
                        <div class="card-body">
                            <h3 class="card-title">
                                <asp:Label ID="lblPartnersPending" runat="server" Text=""></asp:Label></h3>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row">

                <div class="col-md-3">
                    <div class="card text-white bg-primary mb-3">
                        <div class="card-header">Total Trainers</div>
                        <div class="card-body">
                            <h3 class="card-title">
                                <asp:Label ID="lblTrainers" runat="server" Text=""></asp:Label></h3>
                        </div>
                    </div>
                </div>

                <div class="col-md-3">
                    <div class="card text-white bg-secondary mb-3">
                        <div class="card-header">Partners Género Mujer</div>
                        <div class="card-body">
                            <h3 class="card-title">
                                <asp:Label ID="lblPartnersFemale" runat="server" Text=""></asp:Label></h3>
                        </div>
                    </div>
                </div>

                <div class="col-md-3">
                    <div class="card text-white bg-secondary mb-3">
                        <div class="card-header">Partners Género Hombre</div>
                        <div class="card-body">
                            <h3 class="card-title">
                                <asp:Label ID="lblPartnersMale" runat="server" Text=""></asp:Label></h3>
                        </div>
                    </div>
                </div>

                <div class="col-md-3">
                    <div class="card text-white bg-secondary mb-3">
                        <div class="card-header">Partners Género No Informado</div>
                        <div class="card-body">
                            <h3 class="card-title">
                                <asp:Label ID="lblPartnersNotInformed" runat="server" Text=""></asp:Label></h3>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row justify-content-md-center">
                <!-- Grafico de entrenamientos por tipo -->
                <div class="col-md-4">
                    <canvas id="chartTrainings"></canvas>
                </div>
                <!-- Grafico de partners por provincia -->
                <div class="col-md-4">
                    <canvas id="chartPartners"></canvas>
                </div>
            </div>
        </div>

        <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
        <script>
            function loadChartTraining(datos) {
                var ctx = document.getElementById("chartTrainings").getContext("2d");
                new Chart(ctx, {
                    type: "pie",
                    data: {
                        labels: datos.labels,
                        datasets: [{
                            data: datos.values,
                            backgroundColor: datos.colors
                        }]
                    }
                });
            }

            function loadChartPartners(datos) {
                var ctx = document.getElementById("chartPartners").getContext("2d");
                new Chart(ctx, {
                    type: "pie",
                    data: {
                        labels: datos.labels,
                        datasets: [{
                            data: datos.values,
                            backgroundColor: datos.colors
                        }]
                    }
                });
            }
        </script>
    </asp:Panel>

    <%--TRAINER PANEL--%>
    <asp:Panel ID="TrainerPanel" runat="server" Visible="false">
        <h1>TRAINER PANEL</h1>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <!-- Sección de Detalles de Trainer -->
                <h3 class="mb-3 text-center">Mis Datos</h3>

                <div class="row">
                    <%--ACA PONGO BLOQUE DE VIEW TRAINER PERSONAL INFORMATION--%>
                    <div class="container text-center">
                        <div class="row justify-content-md-center">
                            <div class="container mt-4">
                                <div class="card p-3">
                                    <div class="d-flex justify-content-between">
                                        <h5><i class="bi bi-person"></i>Información Personal</h5>
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
                                    <h4><i class="bi bi-person-badge"></i>Mis Partners</h4>

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
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>

    <%--PARTNER PANEL--%>
    <asp:Panel ID="PartnerPanel" runat="server" Visible="false">
        <h1>PARTNER PANEL</h1>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="container text-center">
                    <div class="row justify-content-md-center">
                        <h2 class="mb-3"><i class="bi bi-list"></i>Planes de Entrenamiento</h2>

                        <asp:Label ID="lblPartnerName" Text="Mis Entrenamientos" CssClass="mb-3 h3" runat="server" />

                        <div class="col-md-flex mt-8 p-2 border rounded shadow-sm">
                            <!-- Lista de Trainers para enviar solicitud en caso que corresponda -->
                            <asp:Panel ID="pnlSelectTrainers" Visible="true" runat="server">
                                <h5><i class="bi bi-person"></i>Trainers Disponibles</h5>
                                <div class="row justify-content-md-center">
                                    <asp:DropDownList ID="ddlTrainers" runat="server" CssClass="form-select mt-8 p-2 w-25"></asp:DropDownList>
                                    <asp:Button ID="btnSendRequest" OnClick="btnSendRequest_Click" Text="Enviar Solicitud" class="btn btn-warning w-25 p-2" runat="server" />
                                </div>
                            </asp:Panel>
                            <!-- Solicitud enviada -->
                            <asp:Panel ID="pnlRequestSent" Visible="false" runat="server">
                                <asp:Label ID="lblTrainerRequested" Text="Solicitud en revision..." runat="server" />
                            </asp:Panel>
                            <%--********************--%>

                            <!-- Entrenamientos -->
                            <div class="row justify-content-md-center">
                                <asp:Panel ID="pnlTrainings" Visible="false" runat="server">
                                    <asp:Label ID="lblTrainings" Text="Entrenamientos" CssClass="h1" runat="server" />

                                    <%--ESTA ETIQUETA JUEGA CUANDO NO HAY TRAININGS--%>
                                    <asp:Label ID="lblNoTrainings" Visible="false" Text="NO HAY ENTRENAMIENOS ASIGNADOS" runat="server" />

                                    <asp:GridView ID="dgvTrainings" Visible="false" AutoGenerateColumns="false" DataKeyNames="idTraining" class="table table-striped table-bordered mt-3" runat="server">
                                        <Columns>
                                            <asp:BoundField DataField="idTraining" HeaderText="ID TRAINING" />
                                            <asp:BoundField DataField="Name" HeaderText="NOMBRE ENTRENAMIENTO" />
                                            <asp:BoundField DataField="StartDate" HeaderText="FECHA INICIO" />
                                            <asp:BoundField DataField="StartDate" HeaderText="FECHA INICIO" />
                                            <asp:BoundField DataField="EndDate" HeaderText="FECHA FIN" />
                                            <asp:TemplateField HeaderText="Accion">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnViewTraining" OnCommand="btnViewTraining_Command" CommandName="Ver" CommandArgument='<%# Eval("idTraining") %>' CssClass="btn btn-sm fw-bold btn-outline-warning" runat="server">Ver</asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>

                                    <%--RUTINAS--%>
                                    <asp:Panel ID="pnlRoutines" Visible="false" runat="server">
                                        <asp:Label ID="lblRoutines" Text="Rutinas" CssClass="h2" runat="server" />
                                        <asp:GridView ID="dgvRutines" AutoGenerateColumns="false" DataKeyNames="idDailyRoutine" class="table table-striped table-bordered mt-3" runat="server">
                                            <Columns>
                                                <asp:BoundField DataField="idDailyRoutine" HeaderText="ID RUTINA" />
                                                <asp:BoundField DataField="dailyRoutineDate" HeaderText="FECHA RUTINA" />
                                                <asp:TemplateField HeaderText="Accion">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnRoutine" OnCommand="btnRoutine_Command" CommandName="Ver" CommandArgument='<%# Eval("idDailyRoutine") %>' CssClass="btn btn-sm fw-bold btn-outline-warning" runat="server">Ver</asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                        <%--********************--%>

                                        <%--EJERCICIOS--%>
                                        <asp:Panel ID="pnlExercises" runat="server">
                                            <asp:Label ID="lblExercises" Text="EJERCICIOS" CssClass="h3" runat="server" />
                                            <asp:GridView ID="dgvExercises" AutoGenerateColumns="false" DataKeyNames="idExercise" class="table table-striped table-bordered mt-3" runat="server">
                                                <Columns>
                                                    <asp:BoundField DataField="IdExercise" HeaderText="ID EJERCICIO" />
                                                    <asp:BoundField DataField="Name" HeaderText="NOMBRE EJERCICIO" />
                                                    <asp:BoundField DataField="Sets" HeaderText="SERIES" />
                                                    <asp:BoundField DataField="Reps" HeaderText="REPETICIONES" />
                                                    <asp:BoundField DataField="Weight" HeaderText="PESO" />
                                                    <asp:BoundField DataField="RestTime" HeaderText="TIEMPO DESCANSO" />
                                                    <asp:TemplateField HeaderText="REFERENCIA">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="lnkEjercicio" runat="server"
                                                                NavigateUrl='<%# Eval("UrlExercise") %>'
                                                                Text='<%# Eval("UrlExercise") %>'
                                                                Target="_blank">
                                                            </asp:HyperLink>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </asp:Panel>
                                    </asp:Panel>
                                </asp:Panel>
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
</asp:Content>
