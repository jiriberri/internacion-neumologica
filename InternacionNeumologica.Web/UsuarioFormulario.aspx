<%@ page title="" language="C#" masterpagefile="~/Site.Master" autoeventwireup="true" codebehind="UsuarioFormulario.aspx.cs" inherits="InternacionNeumologica.Web.UsuarioFormulario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-4">

        <div class="card shadow">

            <div class="card-header">
                <h3>
                    <!-- esto es un control ASP:NET que me permite modificar el titulo de la pagina
                     desde c# dependiendo si es un nuevo usuario o una edicion de un usuario existente -->
                    <asp:Label
                        ID="lblTitulo"
                        runat="server"
                        Text="Nuevo Usuario"></asp:Label>
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
                        CssClass="form-control"
                        autocomplete="off" />
                </div>

                <div class="mb-3">
                    <label class="form-label">
                        Email
                    </label>

                    <asp:TextBox
                        ID="txtEmail"
                        runat="server"
                        CssClass="form-control"
                        TextMode="Email" />
                </div>

                <div class="mb-3">
                    <label class="form-label">
                        Contraseña
                    </label>

                    <asp:TextBox
                        ID="txtPassword"
                        runat="server"
                        TextMode="Password"
                        CssClass="form-control"
                        autocomplete="new-password" />
                </div>

                <div class="mb-3">
                    <label class="form-label">
                        Confirmar contraseña
                    </label>

                    <asp:TextBox
                        ID="txtConfirmarPassword"
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

                <div class="form-check mb-3">

                    <asp:CheckBox
                        ID="chkActivo"
                        runat="server"
                        CssClass="form-check-input" />

                    <label class="form-check-label">
                        Activo
                    </label>
                    </label>

                </div>

                <asp:Label
                    ID="lblError"
                    runat="server"
                    CssClass="text-danger fw-bold d-block mb-3"></asp:Label>

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
