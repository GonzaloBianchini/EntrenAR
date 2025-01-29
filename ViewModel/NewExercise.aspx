<%@ Page Title="" Language="C#" MasterPageFile="~/AllMaster.Master" AutoEventWireup="true" CodeBehind="NewExercise.aspx.cs" Inherits="ViewModel.NewExercise" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" />
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="container my-5">
                <h2 class="mb-4">Alta de Ejercicio</h2>

                <!-- ID Ejercicio -->
                <div class="row mb-3">
                    <div class="col-md-6">
                        <label for="idEjercicio" class="form-label">ID Ejercicio</label>
                        <asp:TextBox runat="server" TextMode="Number" class="form-control" ID="txtIdExercise" disabled="true" Text="lastID + 1" />
                    </div>
                </div>

                <!-- Nombre Ejercicio -->
                <div class="row mb-3">
                    <div class="col-md-6">
                        <label for="nombre" class="form-label">Nombre</label>
                        <asp:TextBox runat="server" class="form-control" ID="txtExerciceName" />
                    </div>
                </div>

                <!-- Descripción -->
                <div class="row mb-3">
                    <div class="col-md-12">
                        <label for="descripcion" class="form-label">Descripción</label>
                        <asp:TextBox runat="server" TextMode="MultiLine" class="form-control" ID="txtExerciseDescription" />
                    </div>
                </div>

                <!-- URL del Ejercicio -->
                <div class="row mb-3">
                    <div class="col-md-12">
                        <label for="urlEjercicio" class="form-label">URL del Ejercicio</label>
                        <asp:TextBox runat="server" ID="txtUrlExercise" class="form-control" />
                    </div>
                </div>

                <!-- Botón Guardar-->
                <div class="text-end">
                    <asp:Button ID="btnCreateExercise" OnClick="btnCreateExercise_Click" Text="GUARDAR" runat="server" class="btn btn-warning" data-bs-toggle="modal" data-bs-target="#modalGuardarCambios" />
                </div>

            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
