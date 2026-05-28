<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="InternacionNeumologica.Web.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row justify-content-center mt-5">

        <div class="col-md-4">

            <div class="card bg-black text-white shadow">

                <div class="card-body">

                    <h2 class="text-center mb-4">
                        Iniciar Sesión
                    </h2>

                    <div class="mb-3">

                        <label class="form-label">
                            Usuario
                        </label>

                        <asp:TextBox
                            ID="txtUsuario"
                            runat="server"
                            CssClass="form-control">
                        </asp:TextBox>

                    </div>

                    <div class="mb-3">

                        <label class="form-label">
                            Contraseña
                        </label>

                        <asp:TextBox
                            ID="txtPassword"
                            runat="server"
                            TextMode="Password"
                            CssClass="form-control">
                        </asp:TextBox>

                    </div>

                    <div class="d-grid">

                        <asp:Button
                            ID="btnLogin"
                            runat="server"
                            Text="Ingresar"
                            CssClass="btn btn-primary"
                            OnClick="btnLogin_Click" />

                    </div>

                    <asp:Label
                        ID="lblError"
                        runat="server"
                        CssClass="text-danger mt-3 d-block">
                    </asp:Label>

                </div>

            </div>

        </div>

    </div>

</asp:Content>
