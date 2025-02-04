<%@ Page Title="" Language="C#" MasterPageFile="~/AllMaster.Master" AutoEventWireup="true" CodeBehind="ViewPartners.aspx.cs" Inherits="ViewModel.ViewPartners" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView runat="server" ID="dgvPartnersList" AutoGenerateColumns="false" DataKeyNames="idPartner" class="table table-striped table-bordered table-hover mt-3">
        <Columns>
            <asp:BoundField DataField="idPartner" HeaderText="ID PARTNER" />
            <asp:BoundField DataField="firstName" HeaderText="NOMBRE" />
            <asp:BoundField DataField="lastName" HeaderText="APELLIDO" />
            <asp:BoundField DataField="email" HeaderText="EMAIL" />
            <asp:BoundField DataField="status.Name" HeaderText="ESTADO" />
            <asp:CommandField HeaderText="ACCION" ShowEditButton="true" EditText="Editar" ShowDeleteButton="true" DeleteText="Borrar" ControlStyle-CssClass="btn btn-sm btn-primary" />
        </Columns>
    </asp:GridView>
</asp:Content>
