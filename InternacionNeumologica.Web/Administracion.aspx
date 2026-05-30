<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Administracion.aspx.cs" Inherits="InternacionNeumologica.Web.Administracion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .nav-tabs .nav-link:not(.active) {
            color: #b6b6b6;
        }
        .nav-tabs .nav-link:not(.active):hover {
            color: #ffffff;
            background-color: #ffffff0e;
            border-color: transparent;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-4">

        <div class="d-flex justify-content-between align-items-center mb-4">
            <h2 class="text-white">Panel de Control - Administrador</h2>
            <span class="badge bg-danger fs-6">Rol: Admin</span>
        </div>

        <ul class="nav nav-tabs mb-4" id="adminTabs" role="tablist">
            <li class="nav-item" role="presentation">
                <button class="nav-link active" id="usuarios-tab" data-bs-toggle="tab" data-bs-target="#usuarios" type="button" role="tab" aria-controls="usuarios" aria-selected="true">
                    Gestión de Usuarios
                </button>
            </li>
            <li class="nav-item" role="presentation">
                <button class="nav-link" id="pacientes-tab" data-bs-toggle="tab" data-bs-target="#pacientes" type="button" role="tab" aria-controls="pacientes" aria-selected="false">
                    Corrección de Pacientes
                </button>
            </li>
        </ul>

        <div class="tab-content" id="adminTabsContent">

            <div class="tab-pane fade show active" id="usuarios" role="tabpanel" aria-labelledby="usuarios-tab">
                <div class="card shadow">
                    <div class="card-header d-flex justify-content-between align-items-center bg-light">
                        <h4 class="mb-0">Lista de Usuarios</h4>
                        <asp:Button ID="btnAgregarUsuario" runat="server" Text="+ Nuevo Usuario" CssClass="btn btn-sm btn-primary" />
                    </div>
                    <div class="card-body">
                        <div class="table-responsive">
                            <asp:GridView ID="dgvUsuarios" runat="server" CssClass="table table-striped table-hover align-middle mb-0">
                                <%-- Muestra el listado de usuarios --%>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
