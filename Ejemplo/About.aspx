<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="Ejemplo.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %>.</h2>
        <h3>Your application description page.</h3>
        <h1>ACA TIENEN QUE VERSE LOS EJERCICIOS!!</h1>
        <asp:GridView runat="server" ID="dgvExercises" AutoGenerateColumns="false" DataKeyNames="IdExercise" Visible="true">
            <Columns>
                <asp:BoundField DataField="IdExercise" HeaderText="ID EJERCICIO" Visible="true" />
                <asp:BoundField DataField="Name" HeaderText="NOMBRE EJERCICIO" Visible="true" />
            </Columns>
        </asp:GridView>
        <p>Use this area to provide additional information.</p>
    </main>
</asp:Content>
