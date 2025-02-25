<%@ Page Title="" Language="C#" MasterPageFile="~/AllMaster.Master" AutoEventWireup="true" CodeBehind="ViewPartners.aspx.cs" Inherits="ViewModel.ViewPartners" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container text-center">
        <div class="row justify-content-md-center">
                <asp:GridView runat="server" ID="dgvPartnersList" AutoGenerateColumns="false" DataKeyNames="idPartner" class="table table-striped table-bordered table-hover mt-3">
                    <Columns>
                        <asp:BoundField DataField="idPartner" HeaderText="ID PARTNER" />
                        <asp:BoundField DataField="firstName" HeaderText="NOMBRE" />
                        <asp:BoundField DataField="lastName" HeaderText="APELLIDO" />
                        <asp:BoundField DataField="email" HeaderText="EMAIL" />
                        <asp:BoundField DataField="status.Name" HeaderText="ESTADO" />
                        <asp:TemplateField HeaderText="Accion">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnViewPartner" runat="server" CommandName="Ver" OnCommand="btnViewPartner_Command" CommandArgument='<%# Eval("idPartner") %>' CssClass="btn btn-sm btn-warning">Ver</asp:LinkButton>
                                <asp:LinkButton ID="btnEditPartner" runat="server" CommandName="Editar" OnCommand="btnEditPartner_Command" CommandArgument='<%# Eval("idPartner") %>' CssClass="btn btn-sm btn-warning">Editar</asp:LinkButton>
                                <asp:LinkButton ID="btnManageTrainings" runat="server" CommandName="Gestionar" OnCommand="btnManageTrainings_Command" CommandArgument='<%# Eval("idPartner") %>' CssClass="btn btn-sm btn-warning">Gestionar</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
        </div>
    </div>
</asp:Content>
