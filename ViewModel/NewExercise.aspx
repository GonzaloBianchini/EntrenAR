<%@ Page Title="" Language="C#" MasterPageFile="~/AllMaster.Master" AutoEventWireup="true" CodeBehind="NewExercise.aspx.cs" Inherits="ViewModel.NewExercise" %>

<%@ Register Src="~/Toast.ascx" TagPrefix="uc" TagName="Toast" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" />
    <asp:UpdatePanel runat="server">
        <ContentTemplate>


            <%--TOAST--%>
            <uc:Toast ID="ucToast" runat="server" />

            <h2 class="mb-4">Alta de Ejercicio</h2>

            <div class="row">
                <div class="col-md-4">

                    <!-- ID Ejercicio -->
                    <%--<div class="mb-3">
                            
                        <label for="idEjercicio" class="form-label">ID Ejercicio</label>
                        <asp:TextBox runat="server" TextMode="Number" class="form-control" ID="txtIdExercise" disabled="true" Text="lastID + 1" />
                        
                    </div>--%>

                    <!-- Nombre Ejercicio -->
                    <div class="mb-3">

                        <label for="txtExerciseName" class="form-label">Nombre</label>
                        <asp:TextBox ID="txtExerciceName" runat="server" class="form-control" />
                        <asp:RequiredFieldValidator ErrorMessage="El nombre de ejercicio es requerido..." ControlToValidate="txtExerciceName" Display="Dynamic" ForeColor="Red" runat="server" />
                        <asp:CustomValidator ID="cvExerciseName" OnServerValidate="cvExerciseName_ServerValidate" ErrorMessage="El nombre de ejercicio ya esta utilizado..." ControlToValidate="txtExerciceName" Display="Dynamic" ForeColor="Red" runat="server" />
                    </div>

                    <!-- Descripción -->
                    <div class="mb-3">

                        <label for="txtExerciseDescription" class="form-label">Descripción</label>
                        <asp:TextBox ID="txtExerciseDescription" runat="server" TextMode="MultiLine" class="form-control" />
                        <asp:RequiredFieldValidator ErrorMessage="La descripcion del ejercicio es requerida..." ControlToValidate="txtExerciseDescription" Display="Dynamic" ForeColor="Red" runat="server" />
                    </div>

                    <!-- URL del Ejercicio -->
                    <div class="mb-3">

                        <label for="txtUrlExercise" class="form-label">URL del Ejercicio</label>
                        <asp:TextBox ID="txtUrlExercise" runat="server" class="form-control" />
                        <asp:RegularExpressionValidator ID="revUrlExercise" ErrorMessage="Formato invalido en URL..." ControlToValidate="txtUrlExercise" Display="Dynamic" ForeColor="Red" runat="server" ValidationExpression="^https?:\/\/[\w\-]+(\.[\w\-]+)+(\/.*)?$" />
                    </div>

                    <!-- Botón Guardar-->
                    <div class="text-end">
                        <asp:Button ID="btnCreateExercise" OnClick="btnCreateExercise_Click" Text="GUARDAR" runat="server" class="btn btn-warning" />
                        <%--data-bs-toggle="modal" data-bs-target="#modalGuardarCambios"--%>
                    </div>
                </div>

                <div class="col-md-4">
                    <div class="mb-3">
                        <label class="form-label">Imagen Ejercicio</label>
                        <%--<input type="file" id="txtImagen" runat="server" class="form-control" />--%>

                        <asp:FileUpload ID="txtImagen" CssClass="form-control" onchange="previewImage(this)" runat="server" />

                    </div>
                    <img id="imgPreview" src="~\Images\notfound.jpg" class="mt-3 border rounded" style="max-width: 300px; display: none;" />
                    <%--<asp:Image ID="imageExercise" ImageUrl="~\Images\notfound.jpg" CssClass="img-fluid mb-3" runat="server" />--%>
                </div>


            </div>
        </ContentTemplate>

        <%--BLOQUE PARA QUE EL UPDATEPANEL NO AFECTE BOTON CREARRRR!--%>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnCreateExercise" />
        </Triggers>
        <%--FIN DEL BLOQUE--%>

    </asp:UpdatePanel>

    <%--BLOQUE JS PARA LA PREVISUALIZACION...--%>
    <script>
        function previewImage(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();

                reader.onload = function (e) {
                    var img = document.getElementById('imgPreview');
                    img.src = e.target.result;
                    img.style.display = 'block';
                }

                reader.readAsDataURL(input.files[0]); // Convierte la imagen a base64
            }
        }
</script>
    <%--FIN DEL BLOQUE--%>
</asp:Content>

