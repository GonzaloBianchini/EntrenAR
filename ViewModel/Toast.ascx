<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Toast.ascx.cs" Inherits="ViewModel.Toast" %>

<style>
    /* Aumentar el tamaño del Toast */
    .toast {
        min-width: 350px;
        font-size: 1.2rem;
    }

    /* Barra de progreso dentro del Toast */
    .toast-progress {
        height: 4px;
        width: 100%;
        background-color: #28a745;
        animation: progressBar 4s linear forwards;
    }

    @keyframes progressBar {
        from {
            width: 100%;
        }

        to {
            width: 0%;
        }
    }
</style>


<%--TOAST--%>
<div class="toast-container position-fixed bottom-0 end-0 p-3">
    <div id="liveToast" class="toast align-items-center text-bg-light border-0 shadow-lg" role="alert" aria-live="assertive" aria-atomic="true" data-bs-delay="4000">

        <!-- Encabezado con icono y barra de progreso -->
        <div class="toast-header">
            <span id="toastIcon" class="bi bi-check-circle-fill text-success fs-4 me-2"></span>
            <strong class="me-auto" id="toastTitle">Éxito</strong>
            <small id="toastTime">Ahora</small>
            <button type="button" class="btn-close" data-bs-dismiss="toast" aria-label="Close"></button>
        </div>

        <!-- Barra de progreso -->
        <div class="toast-progress"></div>

        <!-- Cuerpo del Toast -->
        <div class="toast-body" id="toastMessage">
            ¡Cambios guardados!
        </div>
    </div>
</div>

<!-- Bootstrap JS -->
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js"></script>


<!-- Script necesario para mostrar el Toast con personalización -->
<script>
    function showToast(title, message, iconClass, textColor) {
        document.getElementById("toastTitle").innerText = title;
        document.getElementById("toastMessage").innerText = message;
        document.getElementById("toastTime").innerText = "";  /*"Hace un momento";*/

        // Cambiar icono dinámicamente
        let toastIcon = document.getElementById("toastIcon");
        toastIcon.className = `bi ${iconClass} ${textColor} fs-4 me-2`;

        // Mostrar el Toast
        let toastElement = document.getElementById("liveToast");
        let toastInstance = new bootstrap.Toast(toastElement);
        toastInstance.show();
    }
</script>
