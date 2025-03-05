<%@ Page Title="" Language="C#" MasterPageFile="~/AllMaster.Master" AutoEventWireup="true" CodeBehind="NewTraining.aspx.cs" Inherits="ViewModel.NewTraining" %>

<%@ Register Src="~/Toast.ascx" TagPrefix="uc" TagName="Toast" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" />
    <asp:UpdatePanel runat="server">
        <ContentTemplate>

            <%--TOAST--%>
            <uc:Toast ID="ucToast" runat="server" />

            <div class="container mt-4">
                <div class="mt-5 p-4 border rounded shadow-sm">
                    <h3 class="mb-4">Nuevo Programa de Entrenamiento</h3>
                    <asp:Label ID="lblPartnerName" Text="Partner: " class="mb-4" runat="server" />
                    <%--Esta label es invisible, guardo el idPartner--%>
                    <asp:Label ID="lblIdPartner" Text="null" runat="server" Visible="false" />

                    <%-- ========================== NUEVO ENTRENAMIENTO ========================== --%>
                    <div class="mb-3">
                        <div class="col-md-6">
                            <asp:Label ID="lblTrainingName" Text="Nombre Entrenamiento" class="form-label" runat="server" />
                            <asp:TextBox ID="txtTrainingName" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvTrainingName" ValidationGroup="vgNewTraining" ControlToValidate="txtTrainingName" ErrorMessage="El nombre de entrenamiento es requerido..." ForeColor="Red" Display="Dynamic" runat="server" />
                            <asp:CustomValidator ID="cvTrainingName" ValidationGroup="vgNewTraining" ControlToValidate="txtTrainingName" OnServerValidate="cvTrainingName_ServerValidate" ErrorMessage="El nombre de entrenamiento ya fue utilizado..." ForeColor="Red" Display="Dynamic" runat="server" />
                        </div>
                    </div>

                    <div class="mb-3">
                        <div class="col-md-6">
                            <asp:Label ID="lblTrainingDescription" Text="Descripcion" class="form-label" runat="server" />
                            <asp:TextBox ID="txtTrainingDescription" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </div>

                    <div class="mb-3">
                        <div class="col-md-6">
                            <label for="ddlType" class="form-label">Tipo de Entrenamiento</label>
                            <asp:DropDownList ID="ddlTrainingTypes" DataValueField="Id" DataTextField="Name" class="btn btn-outline-dark dropdown-toggle" AutoPostBack="false" runat="server">
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="mb-3">
                        <div class="col-md-6">
                            <asp:Label ID="lblStartDate" Text="Fecha Inicio" class="form-label" runat="server" />
                            <asp:TextBox ID="txtStartDate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvStartDate" ValidationGroup="vgNewTraining" ControlToValidate="txtStartDate" ErrorMessage="La fecha de inicio es requerida..." ForeColor="Red" Display="Dynamic" runat="server" />
                        </div>
                    </div>

                    <div class="mb-3">
                        <div class="col-md-6">
                            <asp:Label ID="lblEndDate" Text="Fecha Fin" class="form-label" runat="server" />
                            <asp:TextBox ID="txtEndDate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvEndDate" ValidationGroup="vgNewTraining" ControlToValidate="txtEndDate" ErrorMessage="La fecha de fin es requerida..." ForeColor="Red" Display="Dynamic" runat="server" />
                            <asp:CustomValidator ID="cvEndDate" ValidationGroup="vgNewTraining" ControlToValidate="txtEndDate" OnServerValidate="cvEndDate_ServerValidate" ErrorMessage="La fecha fin debe ser posterior a la fecha inicio" ForeColor="Red" Display="Dynamic" runat="server" />
                        </div>
                    </div>

                    <%--BOTON CREAR ENTRENAMIENTO--%>
                    <div class="text-end">
                        <asp:Button ID="btnCreateTraining" ValidationGroup="vgNewTraining" OnClick="btnCreateTraining_Click" Text="AGREGAR ENTRENAMIENTO" runat="server" CssClass="btn btn-lg fw-bold btn-outline-warning" />
                    </div>
                </div>
                <asp:Panel ID="pnlNewDailyRoutine" runat="server">
                    <%-- ========================== NUEVA RUTINA ========================== --%>
                    <div class="mt-5 p-4 border rounded shadow-sm">
                        <h3>Nueva Rutina</h3>
                        <div class="col-md-6">
                            <div class="mb-3">
                                <asp:Label ID="lblTrainings" Text="Seleccionar Entrenamiento" class="form-label" runat="server" />
                                <asp:DropDownList ID="ddlTrainings" DataValueField="idTraining" DataTextField="Name" OnSelectedIndexChanged="ddlTrainings_SelectedIndexChanged" CssClass="form-control" AutoPostBack="true" runat="server">
                                </asp:DropDownList>
                            </div>

                            <div class="mb-3">
                                <div class="col-md-6">
                                    <asp:Label ID="lblStartDateLimit" Text="" class="form-label" runat="server" />
                                </div>
                                <div class="col-md-6">
                                    <asp:Label ID="lblEndDateLimit" Text="" class="form-label" runat="server" />
                                </div>
                                <div class="mb-3">
                                    <small class="text-muted">* A continuacion, seleccione la fecha correspondiente a la rutina, entre fecha inicio y fecha fin .</small>
                                </div>
                            </div>

                            <div class="mb-3">
                                <asp:Label ID="lblDailyRoutineDate" Text="Seleccionar Fecha" class="form-label" runat="server" />
                                <asp:TextBox runat="server" ID="txtDailyRoutineDate" TextMode="Date" class="form-control" />
                                <asp:RequiredFieldValidator ID="rfvDailyRoutineDate" ValidationGroup="vgNewDailyRoutine" ControlToValidate="txtDailyRoutineDate" ErrorMessage="La fecha de rutina es requerida..." ForeColor="Red" Display="Dynamic" runat="server" />
                                <asp:CustomValidator ID="cvDailyRoutineDate" ValidationGroup="vgNewDailyRoutine" ControlToValidate="txtDailyRoutineDate" OnServerValidate="cvDailyRoutineDate_ServerValidate" ErrorMessage="La fecha de rutina debe estar comprendida en los limites del entrenamiento..." ForeColor="Red" Display="Dynamic" runat="server" />
                            </div>
                        </div>
                        <div class="text-end mt-3">
                            <asp:Button ID="btnAddDailyRoutine" ValidationGroup="vgNewDailyRoutine" OnClick="btnAddDailyRoutine_Click" Text="AGREGAR RUTINA" runat="server" CssClass="btn btn-lg fw-bold btn-outline-warning" />
                        </div>
                    </div>
                    <asp:Panel ID="pnlNewExercise" runat="server">
                        <%-- ========================== NUEVO EJERCICIO ========================== --%>
                        <div class="mt-5 p-4 border rounded shadow-sm">
                            <h3>Nuevo Ejercicio</h3>

                            <div class="mb-3">
                                <div class="col-md-6">
                                    <asp:Label ID="lblDailyRoutines" Text="Seleccionar Rutina" class="form-label" runat="server" />
                                    <asp:DropDownList ID="ddlDailyRoutines" DataValueField="idDailyRoutine" DataTextField="dailyRoutineDate" CssClass="form-control" runat="server" AutoPostBack="false">
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="mb-3">
                                <div class="col-md-6">
                                    <asp:Label ID="lblExercise" Text="Seleccionar Ejercicio" class="form-label" runat="server" />
                                    <asp:DropDownList ID="ddlExercises" DataValueField="IdExercise" DataTextField="Name" CssClass="form-control" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-3">
                                    <asp:Label ID="lblSeries" Text="Series" class="form-label" runat="server" />
                                    <asp:DropDownList ID="ddlSeries" CssClass="form-control" runat="server">
                                    </asp:DropDownList>
                                </div>

                                <div class="col-md-3">
                                    <asp:Label ID="lblReps" Text="Repeticiones" class="form-label" runat="server" />
                                    <asp:DropDownList ID="ddlReps" CssClass="form-control" runat="server">
                                    </asp:DropDownList>
                                </div>

                                <div class="col-md-3">
                                    <asp:Label ID="lblWeight" Text="Peso (Kg)" class="form-label" runat="server" />
                                    <asp:TextBox ID="txtWeight" CssClass="form-control" placeholder="Peso (Kg)" runat="server" />
                                    <small class="text-muted">* Solo numeros. Un decimal maximo. Introduzca 0 para ejercicio libre.</small>
                                    <asp:RequiredFieldValidator ID="rfvWeight" ValidationGroup="vgNewExercise" ControlToValidate="txtWeight" ErrorMessage="El peso es requerido..." ForeColor="Red" Display="Dynamic" runat="server" />
                                    <asp:RegularExpressionValidator ID="revWeight" ValidationGroup="vgNewExercise" ValidationExpression="^\d+(\.\d{1})?$" ErrorMessage="Peso invalido..." ControlToValidate="txtWeight" ForeColor="Red" Display="Dynamic" runat="server" />
                                </div>

                                <div class="col-md-3">
                                    <asp:Label ID="lblRestTime" Text="Rest Time (seg)" class="form-label" runat="server" />
                                    <asp:TextBox ID="txtRestTime" CssClass="form-control" placeholder="Rest Time (seg)" runat="server" />
                                    <small class="text-muted">* Solo numeros. Sin decimales. Introduzca 0 para ejercicio sin descanso en SuperSerie.</small>
                                    <asp:RequiredFieldValidator ID="rfvRestTime" ValidationGroup="vgNewExercise" ControlToValidate="txtRestTime" ErrorMessage="El tiempo de descanso es requerido..." ForeColor="Red" Display="Dynamic" runat="server" />
                                    <asp:RegularExpressionValidator ID="revRestTime" ValidationGroup="vgNewExercise" ValidationExpression="^\d{1,3}$" ErrorMessage="Tiempo de descanso invalido..." ControlToValidate="txtRestTime" ForeColor="Red" Display="Dynamic" runat="server" />
                                </div>
                            </div>

                            <div class="text-end mt-3">
                                <asp:Button ID="btnAddExercise" ValidationGroup="vgNewExercise" OnClick="btnAddExercise_Click" Text="AGREGAR EJERCICIO" CssClass="btn btn-lg fw-bold btn-outline-warning" runat="server" />
                            </div>
                        </div>
                    </asp:Panel>
                </asp:Panel>
                <%-- ========================== VISUALIZACIÓN DE RUTINAS ========================== --%>
                <div class="mt-5 p-4 border rounded shadow-sm">
                    <h3>Visualización de Rutinas</h3>

                    <div class="mb-3">
                        <asp:Label ID="lblSelectTrainingView" Text="Seleccionar Programa de Entrenamiento" class="form-label" runat="server" />
                        <asp:DropDownList ID="ddlTrainingPrograms" DataValueField="idTraining" DataTextField="Name" OnSelectedIndexChanged="ddlTrainingPrograms_SelectedIndexChanged" CssClass="form-control" runat="server" AutoPostBack="true">
                        </asp:DropDownList>
                    </div>

                    <div class="mb-3">
                        <asp:Label ID="lblSelectRoutine" Text="Seleccionar Rutina" class="form-label" runat="server" />
                        <asp:DropDownList ID="ddlRoutines" DataValueField="idDailyRoutine" DataTextField="dailyRoutineDate" OnSelectedIndexChanged="ddlRoutines_SelectedIndexChanged" CssClass="form-control" runat="server" AutoPostBack="true">
                        </asp:DropDownList>
                    </div>

                    <div class="mb-3">
                        <asp:Label ID="lblSelectExerciseView" Text="Ejercicios en la Rutina" class="form-label" runat="server" />
                        <asp:GridView ID="gvRoutineExercises" CssClass="table table-striped" runat="server">
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
