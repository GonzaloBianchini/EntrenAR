<%@ Page Title="" Language="C#" MasterPageFile="~/AllMaster.Master" AutoEventWireup="true" CodeBehind="ViewTrainers.aspx.cs" Inherits="ViewModel.ViewTrainers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView runat="server" ID="dgvTrainersList" AutoGenerateColumns="false" DataKeyNames="idTrainer" class="table table-striped table-bordered table-hover mt-3">
        <Columns>
            <asp:BoundField DataField="idTrainer" HeaderText="ID TRAINER" />
            <asp:BoundField DataField="firstName" HeaderText="NOMBRE" />
            <asp:BoundField DataField="lastName" HeaderText="APELLIDO" />
            <asp:TemplateField HeaderText="Accion">
                <ItemTemplate>
                    <asp:LinkButton ID="btnViewTrainer" runat="server" CommandName="Ver" OnCommand="btnViewTrainer_Command" CommandArgument='<%# Eval("idTrainer") %>' CssClass="btn btn-sm btn-warning">Ver</asp:LinkButton>
                    <asp:LinkButton ID="btnEditTrainer" runat="server" CommandName="Editar" OnCommand="btnEditTrainer_Command" CommandArgument='<%# Eval("idTrainer") %>' CssClass="btn btn-sm btn-warning">Editar</asp:LinkButton>
                    <%--<asp:LinkButton ID="btnManageTrainings" runat="server" CommandName="Gestionar" OnCommand="btnManageTrainings_Command" CommandArgument='<%# Eval("idPartner") %>' CssClass="btn btn-sm btn-warning">Gestionar</asp:LinkButton>--%>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
