<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="InternacionNeumologica.Web.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="text-white mb-4">

        <h1 class="display-6">Sistema de Internación Neumológica
        </h1>

        <p class="small text-secondary">
            Panel principal
        </p>

    </div>

    <div class="row g-4">

        <div class="col-md-4">

            <div class="card bg-black text-white h-100 shadow">

                <div class="card-body p-3 d-flex flex-column">

                    <h3>Pacientes</h3>

                    <p>
                        Búsqueda, registro e historial de pacientes.
                    </p>

                    <asp:Button
                        ID="btnPacientes"
                        runat="server"
                        Text="Ingresar"
                        CssClass="btn btn-primary mt-auto"
                        OnClick="btnPacientes_Click" />

                </div>

            </div>

        </div>

        <div class="col-md-4">

            <div class="card bg-black text-white h-100 shadow">

                <div class="card-body p-3 d-flex flex-column">

                    <h3>Estadísticas y Filtros</h3>

                    <p>
                        Análisis de internaciones y evolución respiratoria.
                    </p>

                    <asp:Button
                        ID="btnEstadisticas"
                        runat="server"
                        Text="Ingresar"
                        CssClass="btn btn-primary mt-auto"
                        OnClick="btnEstadisticas_Click" />

                </div>

            </div>

        </div>

        <div id="pnlAdministracion"
            runat="server"
            class="col-md-4">

            <div class="card bg-black text-white h-100 shadow">

                <div class="card-body p-3 d-flex flex-column">

                    <h3>Administración</h3>

                    <p>
                        Gestión de usuarios y permisos.
                    </p>

                    <asp:Button
                        ID="btnAdmin"
                        runat="server"
                        Text="Ingresar"
                        CssClass="btn btn-primary mt-auto"
                        OnClick="btnAdmin_Click" />

                </div>

            </div>

        </div>

    </div>

    <hr class="text-white my-5" />

    <div class="card bg-black text-white shadow mb-4">

        <div class="card-header border-secondary">
            <h4 class="mb-0">Pacientes Internados</h4>
        </div>

        <div class="card-body">

            <div class="table-responsive">
                <asp:GridView
                    ID="dgvInternacionesActivas"
                    runat="server"
                    CssClass="table table-dark table-striped table-hover align-middle mb-0"
                    EmptyDataText="No se registran pacientes internados en este momento.">
                    
                    <%-- Falta cargar contenido --%>

                </asp:GridView>
            </div>

        </div>

    </div>

</asp:Content>