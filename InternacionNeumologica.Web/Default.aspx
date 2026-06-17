<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="InternacionNeumologica.Web.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="text-white mb-3">

        <h1 class="h2">Registro Clínico de Internaciones Respiratorias
        </h1>

        <p class="small text-secondary">
            Sistema destinado al registro y análisis histórico de internaciones respiratorias.
        </p>

    </div>

    <div class="row g-4">

        <div class="col-md-4">

            <div class="card bg-black text-white h-100 shadow">

                <div class="card-body p-2 d-flex flex-column">

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

                <div class="card-body p-2 d-flex flex-column">

                    <h3>Reportes y Estadísticas</h3>


                    <p>
                        Reportes y análisis histórico de datos clínicos respiratorios.
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

                <div class="card-body p-2 d-flex flex-column">

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

    <hr class="text-white my-3" />

    <div class="card bg-black text-white shadow mb-4">

        <div class="card-header border-secondary">
            <h4 class="mb-0">Resumen del Registro</h4>
        </div>

        <div class="card-body">

            <div class="row g-3 text-center">

                <div class="col-lg-3 col-md-6">
                    <div class="card bg-dark text-white h-100">
                        <div class="card-body d-flex flex-column justify-content-center">

                            <h2 class="fw-bold">
                                <asp:Label
                                    ID="lblPacientes"
                                    runat="server"
                                    Text="0" />
                            </h2>

                            <small>Pacientes registrados</small>

                        </div>
                    </div>
                </div>

                <div class="col-lg-3 col-md-6">
                    <div class="card bg-dark text-white h-100">
                        <div class="card-body d-flex flex-column justify-content-center">

                            <h2 class="fw-bold">
                                <asp:Label
                                    ID="lblInternaciones"
                                    runat="server"
                                    Text="0" />
                            </h2>

                            <small>Internaciones registradas</small>

                        </div>
                    </div>
                </div>

                <div class="col-lg-3 col-md-6">
                    <div class="card bg-dark text-white h-100">
                        <div class="card-body d-flex flex-column justify-content-center">

                            <h2 class="fw-bold">
                                <asp:Label
                                    ID="lblFallecidos"
                                    runat="server"
                                    Text="0" />
                            </h2>

                            <small>Fallecidos</small>

                        </div>
                    </div>
                </div>

                <div class="col-lg-3 col-md-6">
                    <div class="card bg-dark text-white h-100">
                        <div class="card-body d-flex flex-column justify-content-center">

                            <h2 class="fw-bold">
                                <asp:Label
                                    ID="lblEstadia"
                                    runat="server"
                                    Text="0" />
                            </h2>

                            <small>Estadía promedio (días)</small>

                        </div>
                    </div>
                </div>

            </div>
</asp:Content>
