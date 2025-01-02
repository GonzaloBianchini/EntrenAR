<%@ Page Title="" Language="C#" MasterPageFile="~/TrainerMaster.Master" AutoEventWireup="true" CodeBehind="TrainerNewExercise.aspx.cs" Inherits="ViewModel.TrainerNewExercise" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container my-5">
        <h2 class="mb-4">Alta de Ejercicio</h2>

        <!-- ID Ejercicio -->
        <div class="row mb-3">
            <div class="col-md-6">
                <label for="idEjercicio" class="form-label">ID Ejercicio</label>
                <asp:TextBox runat="server" TextMode="Number" class="form-control" ID="txtIdExercise" disabled="true" Text="lastID + 1" />
                <%-- <input type="number" class="form-control" id="idEjercicio" placeholder="ID generado automáticamente" disabled>--%>
            </div>
        </div>

        <!-- Nombre -->
        <div class="row mb-3">
            <div class="col-md-6">
                <label for="nombre" class="form-label">Nombre</label>
                <asp:TextBox runat="server" class="form-control" ID="txtExerciceName" />
                <%--<input type="text" class="form-control" id="nombre" placeholder="Nombre del ejercicio">--%>
            </div>
        </div>

        <!-- Descripción -->
        <div class="row mb-3">
            <div class="col-md-12">
                <label for="descripcion" class="form-label">Descripción</label>
                <asp:TextBox runat="server" TextMode="MultiLine" class="form-control" ID="txtExerciseDescription" />
                <%--<textarea class="form-control" id="descripcion" rows="4" placeholder="Descripción del ejercicio"></textarea>--%>
            </div>
        </div>

        <!-- URL del Ejercicio -->
        <div class="row mb-3">
            <div class="col-md-12">
                <label for="urlEjercicio" class="form-label">URL del Ejercicio</label>
                <asp:TextBox runat="server" ID="txtUrlExercise" class="form-control"  />
                <%--<input type="text" class="form-control" id="urlEjercicio" placeholder="Ingrese URL asociada al ejercicio">--%>
            </div>
        </div>

        <!-- Botón -->
        <div class="text-end">
            <asp:Button ID="btnCreateExercise" OnClick="btnCreateExercise_Click" Text="GUARDAR" runat="server" class="btn btn-warning"/>
            <%--<button type="submit" class="btn btn-warning">Dar de alta</button>--%>
        </div>
    </div>
</asp:Content>
