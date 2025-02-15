<%@ Page Title="" Language="C#" MasterPageFile="~/AllMaster.Master" AutoEventWireup="true" CodeBehind="NewTraining.aspx.cs" Inherits="ViewModel.NewTraining" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" />
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="container mt-4">
                <div class="mt-5 p-4 border rounded shadow-sm">
                    <h3 class="mb-4">Nuevo Programa de Entrenamiento</h3>
                    <asp:Label ID="lblPartnerName" Text="Partner: " class="mb-4" runat="server" />
                    <%--Esta label es invisible, guardo el idPartner--%>
                    <asp:Label ID="lblIdPartner" Text="null" runat="server" Visible="false" />

                    <%--<h3 class="mb-4">Partner: NOMBRE APELLIDO </h3>--%>
                    <div class="mb-3">
                        <div class="col-md-6">
                            <asp:Label ID="lblTrainingName" Text="Nombre Entrenamiento" class="form-label" runat="server" />
                            <asp:TextBox ID="txtTrainingName" runat="server" CssClass="form-control"></asp:TextBox>
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
                        </div>
                    </div>

                    <div class="mb-3">
                        <div class="col-md-6">
                            <asp:Label ID="lblEndDate" Text="Fecha Fin" class="form-label" runat="server" />
                            <asp:TextBox ID="txtEndDate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                        </div>
                    </div>

                    <div class="text-end">
                        <asp:Button ID="btnCreateTraining" OnClick="btnCreateTraining_Click" Text="AGREGAR ENTRENAMIENTO" runat="server" class="btn btn-warning" data-bs-toggle="modal" data-bs-target="#modalGestionTraining" />
                    </div>
                </div>
                <%-- ========================== NUEVA RUTINA ========================== --%>
                <div class="mt-5 p-4 border rounded shadow-sm">
                    <h3>Nueva Rutina</h3>

                    <div class="mb-3">
                        <asp:Label ID="lblTrainings" Text="Seleccionar Entrenamiento" class="form-label" runat="server" />
                        <asp:DropDownList ID="ddlTrainings" DataValueField="idTraining" DataTextField="Name" OnSelectedIndexChanged="ddlTrainings_SelectedIndexChanged" CssClass="form-control" AutoPostBack="true" runat="server">
                        </asp:DropDownList>
                    </div>

                    <div class="mb-3">
                        <asp:Label ID="lblDailyRoutineDate" Text="Seleccionar Fecha" class="form-label" runat="server" />
                        <asp:TextBox runat="server" ID="txtDailyRoutineDate" TextMode="Date" class="form-control" />
                    </div>

                    <div class="text-end mt-3">
                        <asp:Button ID="btnAddDailyRoutine" OnClick="btnAddDailyRoutine_Click" Text="AGREGAR RUTINA" runat="server" class="btn btn-warning" data-bs-toggle="modal" data-bs-target="#modalGestionTraining" />
                    </div>
                </div>

                <%-- ========================== NUEVO EJERCICIO ========================== --%>
                <div class="mt-5 p-4 border rounded shadow-sm">
                    <h3>Nuevo Ejercicio</h3>

                    <div class="mb-3">
                        <asp:Label ID="lblDailyRoutines" Text="Seleccionar Rutina" class="form-label" runat="server" />
                        <asp:DropDownList ID="ddlDailyRoutines" DataValueField="idDailyRoutine" DataTextField="dailyRoutineDate" CssClass="form-control" runat="server" AutoPostBack="false">
                        </asp:DropDownList>
                    </div>

                    <div class="mb-3">
                        <asp:Label ID="lblExercise" Text="Seleccionar Ejercicio" class="form-label" runat="server" />
                        <asp:DropDownList ID="ddlExercises" DataValueField="IdExercise" DataTextField="Name" CssClass="form-control" runat="server">
                        </asp:DropDownList>
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
                        </div>

                        <div class="col-md-3">
                            <asp:Label ID="lblRestTime" Text="Rest Time (seg)" class="form-label" runat="server" />
                            <asp:TextBox ID="txtRestTime" CssClass="form-control" placeholder="Rest Time (seg)" runat="server" />
                        </div>
                    </div>

                    <div class="text-end mt-3">
                        <asp:Button ID="btnAddExercise" OnClick="btnAddExercise_Click" Text="AGREGAR EJERCICIO" runat="server" class="btn btn-warning" data-bs-toggle="modal" data-bs-target="#modalGestionTraining" />
                    </div>
                </div>
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
