<%@ Page Title="" Language="C#" MasterPageFile="~/TrainerMaster.Master" AutoEventWireup="true" CodeBehind="TrainerViewExercises.aspx.cs" Inherits="ViewModel.TrainerViewExercises" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Lista de ejercicios</h1>

    <asp:Label Text="El index es: " id="lblIndex" runat="server" />

    <asp:GridView runat="server" ID="dgvExerciseList" AutoGenerateColumns="false" DataKeyNames="IdExercise" class="table table-striped table-bordered table-dark mt-3">
        <Columns>
            <asp:BoundField DataField="IdExercise" HeaderText="ID EJERCICIO" />
            <asp:BoundField DataField="Name" HeaderText="NOMBRE EJERCICIO" />
            <asp:BoundField DataField="Description" HeaderText="DESCRIPCION" />
            <asp:BoundField DataField="UrlExercise" HeaderText="URL" />
            <asp:CommandField ShowEditButton="true" EditText="Editar" ShowDeleteButton="true" DeleteText="Borrar" ControlStyle-CssClass="btn btn-sm btn-primary" />
        </Columns>
    </asp:GridView>
</asp:Content>
