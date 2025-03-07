<%@ Page Title="" Language="C#" MasterPageFile="~/AllMaster.Master" AutoEventWireup="true" CodeBehind="ViewTrainings.aspx.cs" Inherits="ViewModel.ViewTrainings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" />
    <asp:UpdatePanel ID="udpTrainings" runat="server">
        <ContentTemplate>

            <div class="container text-center">
                <div class="row justify-content-md-center">
                    <h2 class="mb-3"><i class="bi bi-list"></i>Planes de Entrenamiento</h2>

                    <asp:Label ID="lblPartnerName" Text="Entrenamientos de: " CssClass="mb-3 h3" runat="server" />

                    <%--ETIQUETA INVISIBLE PARA GUARDAR EL ID PARTNER--%>
                    <asp:Label ID="lblIdPartner" Text="text" Visible="false" runat="server" />

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
</asp:Content>
