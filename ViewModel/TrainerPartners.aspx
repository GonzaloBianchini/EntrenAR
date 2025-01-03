<%@ Page Title="" Language="C#" MasterPageFile="~/TrainerMaster.Master" AutoEventWireup="true" CodeBehind="TrainerPartners.aspx.cs" Inherits="ViewModel.AdminPanel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Lista de Partners</h1>
    <h3>Lista de Direcciones</h3>
    <asp:GridView runat="server" ID="dgvAddressList" AutoGenerateColumns="false" DataKeyNames="IdAddress" class="table table-striped table-bordered table-dark mt-3">
        <Columns>
            <asp:BoundField DataField="IdAddress" HeaderText="ID Address" />
            <asp:BoundField DataField="StreetName" HeaderText="Calle" />
            <asp:BoundField DataField="StreetNumber" HeaderText="Numero" />
            <asp:BoundField DataField="Flat" HeaderText="Dpto" />
            <asp:BoundField DataField="Details" HeaderText="Observaciones" />
            <asp:BoundField DataField="City" HeaderText="Ciudad" />
            <asp:BoundField DataField="Province" HeaderText="Provincia" />
            <asp:BoundField DataField="Country" HeaderText="Pais" />
            <asp:CommandField ShowEditButton="true" EditText="Editar" ShowDeleteButton="true" DeleteText="Borrar" ControlStyle-CssClass="btn btn-sm btn-primary" />
        </Columns>
    </asp:GridView>
</asp:Content>
