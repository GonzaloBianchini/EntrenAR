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

                    <asp:Label ID="lblPartnerName" Text="Bienvenid@ " CssClass="mb-3 h3" runat="server" />

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

                        <!-- Entrenamientos -->
                        <asp:Panel ID="pnlTrainings" Visible="false" runat="server">
                            <asp:Label ID="lblTrainings" Text="Entrenamientos" runat="server" />

                            <%--ESTA ETIQUETA JUEGA CUANDO NO HAY TRAININGS--%>
                            <asp:Label ID="lblNoTrainings" Visible="false" Text="NO HAY ENTRENAMIENOS ASIGNADOS" runat="server" />

                            <asp:GridView ID="dgvTrainings" Visible="false" AutoGenerateColumns="false" DataKeyNames="idTraining" class="table table-striped table-bordered mt-3" runat="server">
                                <Columns>
                                    <asp:BoundField DataField="idTraining" HeaderText="ID TRAINING" />
                                    <asp:BoundField DataField="Name" HeaderText="NOMBRE ENTRENAMIENTO" />
                                    <asp:BoundField DataField="Type.Name" HeaderText="TIPO ENTRENAMIENTO" />
                                    <asp:BoundField DataField="StartDate" HeaderText="FECHA INICIO" />
                                    <asp:BoundField DataField="EndDate" HeaderText="FECHA FIN" />
                                    <asp:BoundField DataField="dailyRoutinesList.Count()" HeaderText="CANT RUTINAS" />
                                    <asp:TemplateField HeaderText="Accion">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnViewTraining" OnClick="btnViewTraining_Click" runat="server" CommandName="Ver" CommandArgument='<%# Eval("idTraining") %>' CssClass="btn btn-sm fw-bold btn-outline-warning">Ver</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>

                    </div>

                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
