<%@ Page Title="" Language="C#" MasterPageFile="~/AllMaster.Master" AutoEventWireup="true" CodeBehind="ViewTrainings.aspx.cs" Inherits="ViewModel.ViewTrainings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" />
    <asp:UpdatePanel ID="udpTrainings" runat="server">
        <ContentTemplate>

            <div class="container text-center">
                <div class="row justify-content-md-center">
                    <h4 class="mb-3"><i class="bi bi-list"></i>Planes de Entrenamiento</h4>

                    <%--ETIQUETA INVISIBLE PARA GUARDAR EL ID PARTNER--%>
                    <asp:Label ID="lblIdPartner" Text="text" Visible="false" runat="server" />

                    <div class="col-md-6 mt-8 p-2 border rounded shadow-sm">
                        <!-- Lista de Trainers -->
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
                    </div>

                    <!-- Tabla de Planes de Entrenamiento -->
                    <%--<div class="card p-3 mt-4">
                            <h5><i class="bi bi-bar-chart"></i>Planes y Rutinas</h5>
                            <asp:GridView runat="server" ID="gvTrainingPlans" AutoGenerateColumns="false" DataKeyNames="IdPlan" CssClass="table mt-2">
                                <Columns>
                                    <asp:BoundField DataField="PlanName" HeaderText="Plan" />
                                    <asp:BoundField DataField="RoutineName" HeaderText="Rutina" />
                                    <asp:TemplateField HeaderText="Ejercicios">
                                        <ItemTemplate>
                                            <asp:Button runat="server" Text="VER" CssClass="btn btn-info" CommandName="ViewExercises" CommandArgument='<%# Eval("IdRoutine") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>--%>

                    <!-- Modal para mostrar ejercicios -->
                    <%--<div class="modal fade" id="exerciseModal" tabindex="-1" aria-labelledby="exerciseModalLabel" aria-hidden="true">
                            <div class="modal-dialog">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <h5 class="modal-title" id="exerciseModalLabel">Ejercicios de la Rutina</h5>
                                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                                    </div>
                                    <div class="modal-body">
                                        <asp:GridView runat="server" ID="gvExercises" AutoGenerateColumns="false" CssClass="table">
                                            <Columns>
                                                <asp:BoundField DataField="ExerciseName" HeaderText="Ejercicio" />
                                                <asp:BoundField DataField="Reps" HeaderText="Repeticiones" />
                                                <asp:BoundField DataField="Sets" HeaderText="Series" />
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>--%>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
