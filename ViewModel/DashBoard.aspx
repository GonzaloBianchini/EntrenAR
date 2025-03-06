<%@ Page Title="" Language="C#" MasterPageFile="~/AllMaster.Master" AutoEventWireup="true" CodeBehind="DashBoard.aspx.cs" Inherits="ViewModel.DashBoard" %>

<%@ Register Src="~/Toast.ascx" TagPrefix="uc" TagName="toast" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%--TOAST--%>
    <uc:toast ID="ucToast" runat="server" />

    <asp:Panel ID="AdminPanel" runat="server" Visible="false">
        <h1>ADMIN PANEL</h1>
        <div class="container">
            <h2 class="text-center">EntrenAr</h2>
            <h3 class="text-center">Métricas</h3>

            <div class="row">
                <div class="col-md-3">
                    <div class="card text-white bg-primary mb-3">
                        <div class="card-header">Total Partners</div>
                        <div class="card-body">
                            <h3 class="card-title">
                                <asp:Label ID="lblTotalPartners" runat="server" Text="0"></asp:Label></h3>
                        </div>
                    </div>
                </div>

                <div class="col-md-3">
                    <div class="card text-white bg-success mb-3">
                        <div class="card-header">Partners Asignados(Assigned)</div>
                        <div class="card-body">
                            <h3 class="card-title">
                                <asp:Label ID="lblPartnersAssigned" runat="server" Text=""></asp:Label></h3>
                        </div>
                    </div>
                </div>

                <div class="col-md-3">
                    <div class="card text-white bg-warning mb-3">
                        <div class="card-header">Partners Disponibles(Availables)</div>
                        <div class="card-body">
                            <h3 class="card-title">
                                <asp:Label ID="lblPartnersAvailable" runat="server" Text=""></asp:Label></h3>
                        </div>
                    </div>
                </div>

                <div class="col-md-3">
                    <div class="card text-white bg-danger mb-3">
                        <div class="card-header">Partners en Revisión(Pending)</div>
                        <div class="card-body">
                            <h3 class="card-title">
                                <asp:Label ID="lblPartnersPending" runat="server" Text=""></asp:Label></h3>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row">

                <div class="col-md-3">
                    <div class="card text-white bg-primary mb-3">
                        <div class="card-header">Total Trainers</div>
                        <div class="card-body">
                            <h3 class="card-title">
                                <asp:Label ID="lblTrainers" runat="server" Text=""></asp:Label></h3>
                        </div>
                    </div>
                </div>

                <div class="col-md-3">
                    <div class="card text-white bg-secondary mb-3">
                        <div class="card-header">Partners Género Mujer</div>
                        <div class="card-body">
                            <h3 class="card-title">
                                <asp:Label ID="lblPartnersFemale" runat="server" Text=""></asp:Label></h3>
                        </div>
                    </div>
                </div>

                <div class="col-md-3">
                    <div class="card text-white bg-secondary mb-3">
                        <div class="card-header">Partners Género Hombre</div>
                        <div class="card-body">
                            <h3 class="card-title">
                                <asp:Label ID="lblPartnersMale" runat="server" Text=""></asp:Label></h3>
                        </div>
                    </div>
                </div>

                <div class="col-md-3">
                    <div class="card text-white bg-secondary mb-3">
                        <div class="card-header">Partners Género No Informado</div>
                        <div class="card-body">
                            <h3 class="card-title">
                                <asp:Label ID="lblPartnersNotInformed" runat="server" Text=""></asp:Label></h3>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row justify-content-md-center">
                <!-- Grafico de entrenamientos por tipo -->
                <div class="col-md-4">
                    <canvas id="chartTrainings"></canvas>
                </div>
                <!-- Grafico de partners por provincia -->
                <div class="col-md-4">
                    <canvas id="chartPartners"></canvas>
                </div>
            </div>
        </div>

        <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
        <script>
            function loadChartTraining(datos) {
                var ctx = document.getElementById("chartTrainings").getContext("2d");
                new Chart(ctx, {
                    type: "pie",
                    data: {
                        labels: datos.labels,
                        datasets: [{
                            data: datos.values,
                            backgroundColor: datos.colors
                        }]
                    }
                });
            }

            function loadChartPartners(datos) {
                var ctx = document.getElementById("chartPartners").getContext("2d");
                new Chart(ctx, {
                    type: "pie",
                    data: {
                        labels: datos.labels,
                        datasets: [{
                            data: datos.values,
                            backgroundColor: datos.colors
                        }]
                    }
                });
            }
        </script>


    </asp:Panel>
    <asp:Panel ID="TrainerPanel" runat="server" Visible="false">
        <h1>TRAINER PANEL</h1>
    </asp:Panel>
    <asp:Panel ID="PartnerPanel" runat="server" Visible="false">
        <h1>PARTNER PANEL</h1>
    </asp:Panel>
</asp:Content>
