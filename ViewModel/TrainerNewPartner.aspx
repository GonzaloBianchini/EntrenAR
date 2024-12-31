<%@ Page Title="" Language="C#" MasterPageFile="~/TrainerMaster.Master" AutoEventWireup="true" CodeBehind="TrainerNewPartner.aspx.cs" Inherits="ViewModel.TrainerNewClient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container my-5">
        <h2 class="mb-4">Alta de Partner</h2>
        <!-- Usuario y Contraseña -->
        <div class="row mb-3">
            <div class="col-md-6">
                <label for="usuario" class="form-label">Usuario</label>
                <input type="text" class="form-control" id="usuario" placeholder="admin">
            </div>
            <div class="col-md-6">
                <label for="contrasena" class="form-label">Contraseña</label>
                <input type="password" class="form-control" id="contrasena">
                <small class="text-muted">* La contraseña debe contener al menos una mayúscula, una minúscula y un número.</small>
            </div>
        </div>

        <!-- Nombre y Apellido -->
        <div class="row mb-3">
            <div class="col-md-6">
                <label for="nombre" class="form-label">Nombre</label>
                <input type="text" class="form-control" id="nombre" placeholder="Nombre">
            </div>
            <div class="col-md-6">
                <label for="apellido" class="form-label">Apellido</label>
                <input type="text" class="form-control" id="apellido" placeholder="Apellido">
            </div>
        </div>

        <!-- DNI y CUIL -->
        <div class="row mb-3">
            <div class="col-md-6">
                <label for="dni" class="form-label">DNI</label>
                <input type="text" class="form-control" id="dni" placeholder="DNI del cliente (sin espacios ni puntos)">
            </div>
            <div class="col-md-6">
                <label for="cuil" class="form-label">CUIL</label>
                <input type="text" class="form-control" id="cuil" placeholder="CUIL">
            </div>
        </div>

        <!-- Fecha de Nacimiento, Género y Nacionalidad -->
        <div class="row mb-3">
            <div class="col-md-4">
                <label for="fecha-nacimiento" class="form-label">Fecha de nacimiento</label>
                <input type="date" class="form-control" id="fecha-nacimiento">
            </div>
            <div class="col-md-4">
                <label for="genero" class="form-label">Género</label>
                <select class="form-select" id="genero">
                    <option>No informado</option>
                    <option>Masculino</option>
                    <option>Femenino</option>
                </select>
            </div>
            <div class="col-md-4">
                <label for="nacionalidad" class="form-label">Nacionalidad</label>
                <input type="text" class="form-control" id="nacionalidad" placeholder="Nacionalidad">
            </div>
        </div>

        <!-- Teléfono y Email -->
        <div class="row mb-3">
            <div class="col-md-6">
                <label for="telefono" class="form-label">Teléfono</label>
                <input type="text" class="form-control" id="telefono" placeholder="Teléfono de contacto">
            </div>
            <div class="col-md-6">
                <label for="email" class="form-label">Email</label>
                <input type="email" class="form-control" id="email" placeholder="Email">
            </div>
        </div>

        <!-- Calle y Número -->
        <div class="row mb-3">
            <div class="col-md-6">
                <label for="calle" class="form-label">Calle</label>
                <input type="text" class="form-control" id="calle" placeholder="Calle">
            </div>
            <div class="col-md-6">
                <label for="numero" class="form-label">Número</label>
                <input type="text" class="form-control" id="numero" placeholder="Número">
            </div>
        </div>

        <!-- Piso/Depto y Observaciones -->
        <div class="row mb-3">
            <div class="col-md-6">
                <label for="piso" class="form-label">Piso/Depto</label>
                <input type="text" class="form-control" id="piso" placeholder="Piso/Depto">
            </div>
            <div class="col-md-6">
                <label for="observaciones" class="form-label">Observaciones</label>
                <input type="text" class="form-control" id="observaciones" placeholder="Observaciones del domicilio">
            </div>
        </div>

        <!-- Provincia, Localidad y CP -->
        <div class="row mb-3">
            <div class="col-md-4">
                <label for="provincia" class="form-label">Provincia</label>
                <select class="form-select" id="provincia">
                    <option>Buenos Aires</option>
                    <option>Córdoba</option>
                    <option>Santa Fe</option>
                </select>
            </div>
            <div class="col-md-4">
                <label for="localidad" class="form-label">Localidad</label>
                <input type="text" class="form-control" id="localidad" placeholder="Ingrese Ciudad">
            </div>
            <div class="col-md-4">
                <label for="cp" class="form-label">CP</label>
                <input type="text" class="form-control" id="cp" placeholder="CP">
            </div>
        </div>

        <!-- Botón -->
        <div class="text-end">
            <button type="submit" class="btn btn-warning">Dar de alta</button>
        </div>
    </div>
</asp:Content>


