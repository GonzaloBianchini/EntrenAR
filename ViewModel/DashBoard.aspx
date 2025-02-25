<%@ Page Title="" Language="C#" MasterPageFile="~/AllMaster.Master" AutoEventWireup="true" CodeBehind="DashBoard.aspx.cs" Inherits="ViewModel.DashBoard" %>

<%@ register src="~/Toast.ascx" tagprefix="uc" tagname="toast" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <%--TOAST--%>
    <uc:Toast  ID="ucToast" runat="server" />

    <asp:Panel id="AdminPanel" runat="server" visible="false">
        <h1>ADMIN PANEL</h1>
    </asp:Panel>
    <asp:Panel id="TrainerPanel" runat="server" visible="false">
        <h1>TRAINER PANEL</h1>
    </asp:Panel>
    <asp:Panel id="PartnerPanel" runat="server" visible="false">
        <h1>PARTNER PANEL</h1>
    </asp:Panel>
</asp:Content>
