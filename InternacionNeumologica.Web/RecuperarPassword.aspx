<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RecuperarPassword.aspx.cs" Inherits="InternacionNeumologica.Web.RecuperarPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row justify-content-center mt-5">

        <div class="col-md-5">

            <div class="card shadow">

                <div class="card-header">
                    <h3 class="mb-0">
                        Recuperar contraseña
                    </h3>
                </div>

                <div class="card-body">

                    <p class="text-muted">
                        Ingrese el email asociado a su usuario.
                    </p>

                    <div class="mb-3">

                        <label class="form-label">
                            Email
                        </label>

                        <asp:TextBox
                            ID="txtEmail"
                            runat="server"
                            CssClass="form-control"
                            TextMode="Email">
                        </asp:TextBox>

                    </div>

                    <div class="d-flex gap-2">

                        <asp:Button
                            ID="btnEnviar"
                            runat="server"
                            Text="Enviar"
                            CssClass="btn btn-primary"
                            OnClick="btnEnviar_Click" />

                        <asp:Button
                            ID="btnVolver"
                            runat="server"
                            Text="Volver"
                            CssClass="btn btn-secondary"
                            PostBackUrl="~/Login.aspx" />

                    </div>

                    <asp:Label
                        ID="lblMensaje"
                        runat="server"
                        CssClass="mt-3 d-block">
                    </asp:Label>

                </div>

            </div>

        </div>

    </div>

</asp:Content>
