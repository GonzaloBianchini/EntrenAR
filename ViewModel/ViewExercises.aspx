<%@ Page Title="" Language="C#" MasterPageFile="~/AllMaster.Master" AutoEventWireup="true" CodeBehind="ViewExercises.aspx.cs" Inherits="ViewModel.ViewExercises" %>

<%@ Register Src="~/Toast.ascx" TagPrefix="uc" TagName="Toast" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" />
    <asp:UpdatePanel ID="udpExercises" runat="server">
        <ContentTemplate>

            <%--TOAST--%>
            <uc:Toast ID="ucToast" runat="server" />

            <div class="row justify-content-between">
                <div class="col-md-3">
                    <h1>Ejercicios</h1>
                </div>
                <div class="col-md-3">
                    <div class="d-grid gap-2 d-md-flex justify-content-md-end">
                        <asp:Button ID="btnCreateExercise" OnClick="btnCreateExercise_Click" Text="Crear" CssClass="btn btn-lg fw-bold btn-outline-warning" runat="server" />
                    </div>
                </div>
            </div>

            <asp:GridView runat="server" ID="dgvExerciseList" AutoGenerateColumns="false" DataKeyNames="IdExercise" class="table table-striped table-bordered mt-3">
                <Columns>
                    <asp:BoundField DataField="IdExercise" HeaderText="ID EJERCICIO" />
                    <asp:BoundField DataField="Name" HeaderText="NOMBRE EJERCICIO" />
                    <asp:BoundField DataField="Description" HeaderText="DESCRIPCION" />
                    <asp:BoundField DataField="UrlExercise" HeaderText="URL" />
                    <asp:TemplateField HeaderText="Accion">
                        <ItemTemplate>
                            <asp:LinkButton ID="btnViewExercise" OnCommand="btnViewExercise_Command" runat="server" CommandName="Ver" CommandArgument='<%# Eval("idExercise") %>' CssClass="btn btn-sm fw-bold btn-outline-warning">Ver</asp:LinkButton>
                            <asp:LinkButton ID="btnEditExercise" OnCommand="btnEditExercise_Command" runat="server" CommandName="Editar" CommandArgument='<%# Eval("idExercise") %>' CssClass="btn btn-sm fw-bold btn-outline-warning">Editar</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            <!-- Sección de Detalles del Ejercicio -->
            <%--MUESTRO U ESCONDO EL PANEL EN CASO QUE NO SE HAYA SELECCIONADO NINGUN EJERCICIO--%>
            <asp:Panel ID="pnlExerciseDetails" runat="server" CssClass="mt-4 p-4 border rounded shadow-sm bg-light" Visible="false">
                <h3 class="mb-3 text-center">Detalles del Ejercicio</h3>

                <div class="row">
                    <!-- Imagen del Ejercicio -->
                    <div class="col-md-6 text-center">
                        <asp:Image ID="imgExercise" runat="server" CssClass="img-fluid border rounded" Width="100%" />
                    </div>

                    <!-- Información del Ejercicio -->
                    <div class="col-md-4">
                        <h4>
                            <asp:Label ID="lblExerciseName" runat="server" CssClass="fw-bold"></asp:Label>
                        </h4>
                        <p class="text-muted">
                            <asp:Label ID="lblExerciseDescription" runat="server"></asp:Label>
                        </p>

                        <h6 class="fw-bold">URL del Ejercicio:</h6>
                        <asp:HyperLink ID="lnkExerciseUrl" runat="server" CssClass="text-primary" Target="_blank"></asp:HyperLink>
                    </div>
                </div>
            </asp:Panel>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
