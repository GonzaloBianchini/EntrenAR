<%@ Page Title="" Language="C#" MasterPageFile="~/AllMaster.Master" AutoEventWireup="true" CodeBehind="ViewTrainers.aspx.cs" Inherits="ViewModel.ViewTrainers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView runat="server" ID="dgvTrainersList" AutoGenerateColumns="false" DataKeyNames="idTrainer" class="table table-striped table-bordered table-hover mt-3">
        <Columns>
            <asp:BoundField DataField="idTrainer" HeaderText="ID TRAINER" />
            <asp:BoundField DataField="firstName" HeaderText="NOMBRE" />
            <asp:BoundField DataField="lastName" HeaderText="APELLIDO" />
            <asp:CommandField HeaderText="ACCION" ShowEditButton="true" EditText="Editar" ShowDeleteButton="true" DeleteText="Borrar" ControlStyle-CssClass="btn btn-sm btn-primary" />
        </Columns>
    </asp:GridView>
</asp:Content>
