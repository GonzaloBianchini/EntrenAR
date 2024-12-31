<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ViewModel.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ESTE ES LOGIN</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous" />
    <link href="\content\MyStyles.css" rel="stylesheet" />
</head>
<body>
    <div>
        <header class="bg-light py-3">

            <h1 class="h3 mb-0">Athleticon</h1>
            <a class="nav-link" href="Default.aspx"><span>Default</span></a>
            <a class="nav-link" href="TrainerPartners.aspx"><span>TrainerClient</span></a>
            <a class="nav-link" href="TrainerRequests.aspx"><span>TrainerRequests</span></a>
            <a class="nav-link" href="TrainerNewPartner.aspx"><span>TrainerNewClient</span></a>


        </header>

        <div class="hero-section">
            <!-- Sección de Bienvenida -->
            <div class="welcome-section">
                <h1>Bienvenid@ a <span>EntrenAR</span></h1>
                <p>Tu lugar de entrenamiento personalizado</p>
                <img src="https://via.placeholder.com/400x300" alt="Imagen fondo box CF"/>
            </div>

            <!-- Sección de Login -->
            <div class="login-section">
                <h2>User Login</h2>

                <div class="mb-3">
                    <input type="text" class="form-control" placeholder="User" data-icon="&#xf007;" />
                </div>
                <div class="mb-3">
                    <input type="password" class="form-control" placeholder="Password" data-icon="&#xf023;" />
                </div>
                <button type="submit" class="btn btn-danger w-100">LOGIN</button>

                <div class="signup-link">
                    <a href="#">Quiero formar parte!</a>
                </div>
            </div>


            <main class="bg-light py-5">
                <div class="container text-center">
                    <h1 class="display-4 fw-bold">Fitness & Health Training</h1>
                    <p class="lead">Strong is the simplest, most intuitive workout tracking experience. Trusted by over 3 million users worldwide.</p>
                    <a href="#" class="btn btn-warning btn-lg">Get Started</a>
                </div>

                <section class="mt-5">
                    <div class="container">
                        <div class="row text-center">
                            <div class="col-md-4">
                                <h3 class="h4">3.2k</h3>
                                <p class="text-muted">Happy Users</p>
                            </div>
                            <div class="col-md-4">
                                <h3 class="h4">350k</h3>
                                <p class="text-muted">Running Track</p>
                            </div>
                            <div class="col-md-4">
                                <h3 class="h4">100+</h3>
                                <p class="text-muted">Workout Types</p>
                            </div>
                        </div>
                    </div>
                </section>
            </main>

            <footer class="bg-dark text-white py-3">
                <div class="container text-center">
                    <p class="mb-0">&copy; 2024 Athleticon. All rights reserved.</p>
                </div>
            </footer>
        </div>
    </div>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
</body>
</html>
