<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UsuarioFormulario.aspx.cs" Inherits="InternacionNeumologica.Web.UsuarioFormulario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-4">

    <div class="card shadow">

        <div class="card-header">
                 <h3> <!-- esto es un control ASP:NET que me permite modificar el titulo de la pagina
                     desde c# dependiendo si es un nuevo usuario o una edicion de un usuario existente -->
                    <asp:Label
                        ID="lblTitulo"
                        runat="server"
                        Text="Nuevo Usuario">
                    </asp:Label>
                </h3>
        </div>

        <div class="card-body">

            <div class="mb-3">
                <label class="form-label">
                    Usuario
                </label>

                <asp:TextBox
                    ID="txtUsuario"
                    runat="server"
                    CssClass="form-control" />
            </div>

            <div class="mb-3">
                <label class="form-label">
                    Contraseña
                </label>

                <asp:TextBox
                    ID="txtPassword"
                    runat="server"
                    TextMode="Password"
                    CssClass="form-control" />
            </div>

            <div class="form-check mb-3">

                <asp:CheckBox
                    ID="chkAdmin"
                    runat="server"
                    CssClass="form-check-input" />

                <label class="form-check-label">
                    Administrador
                </label>

            </div>

            <asp:Button
                ID="btnGuardar"
                runat="server"
                Text="Guardar"
                CssClass="btn btn-success"
                OnClick="btnGuardar_Click" />

            <asp:Button
                ID="btnCancelar"
                runat="server"
                Text="Cancelar"
                CssClass="btn btn-secondary"
                OnClick="btnCancelar_Click" />

        </div>

    </div>

</div>



</asp:Content>
