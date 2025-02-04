<%@ Page Title="" Language="C#" MasterPageFile="~/AllMaster.Master" AutoEventWireup="true" CodeBehind="ViewExercises.aspx.cs" Inherits="ViewModel.ViewExercises" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Lista de ejercicios</h1>


    <asp:GridView runat="server" ID="dgvExerciseList" AutoGenerateColumns="false" DataKeyNames="IdExercise" class="table table-striped table-bordered mt-3">
        <Columns>
            <asp:BoundField DataField="IdExercise" HeaderText="ID EJERCICIO" />
            <asp:BoundField DataField="Name" HeaderText="NOMBRE EJERCICIO" />
            <asp:BoundField DataField="Description" HeaderText="DESCRIPCION" />
            <asp:BoundField DataField="UrlExercise" HeaderText="URL" />
            <asp:CommandField ShowEditButton="true" EditText="Editar" ShowDeleteButton="true" DeleteText="Borrar" ControlStyle-CssClass="btn btn-sm btn-primary" />
        </Columns>
    </asp:GridView>
    
</asp:Content>
