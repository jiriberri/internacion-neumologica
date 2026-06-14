<%@ page title="" language="C#" masterpagefile="~/Site.Master" autoeventwireup="true" codebehind="Estadisticas.aspx.cs" inherits="InternacionNeumologica.Web.Estadisticas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        .card-filtro {
            background: #f3f6fa;
            border: none;
            border-radius: 12px;
            box-shadow: 0 .125rem .25rem rgba(0,0,0,.08);
        }

        .titulo-card {
            font-size: 1rem;
            font-weight: 600;
            color: #34495e;
            margin-bottom: 15px;
        }
    </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-4">

        <div class="mb-4">

            <h2 class="text-white mb-1">Análisis Histórico de Internaciones
            </h2>

            <p class="text-secondary">
                Generación de reportes sobre el registro histórico de pacientes.
            </p>

        </div>

        <div class="alert alert-warning shadow-sm">

            <strong>Importante:</strong>

            Seleccione únicamente los criterios que desea aplicar.
        Los campos vacíos o con la opción <strong>"Todos"</strong>
            incluirán la totalidad de los registros.

        </div>

        <div class="row g-3">

            <!-- PERIODO -->

            <div class="col-lg-4">

                <div class="card card-filtro h-100">

                    <div class="card-body">

                        <div class="titulo-card">
                            Período

                        </div>

                        <label>Desde</label>

                        <asp:TextBox
                            ID="txtFechaDesde"
                            runat="server"
                            TextMode="Date"
                            CssClass="form-control mb-2" />

                        <label>Hasta</label>

                        <asp:TextBox
                            ID="txtFechaHasta"
                            runat="server"
                            TextMode="Date"
                            CssClass="form-control" />

                    </div>

                </div>

            </div>

            <!-- EDAD -->

            <div class="col-lg-4">

                <div class="card card-filtro h-100">

                    <div class="card-body">

                        <div class="titulo-card">
                            Edad

                        </div>

                        <label>Desde</label>

                        <asp:TextBox
                            ID="txtEdadMinima"
                            runat="server"
                            TextMode="Number"
                            CssClass="form-control mb-2" />

                        <label>Hasta</label>

                        <asp:TextBox
                            ID="txtEdadMaxima"
                            runat="server"
                            TextMode="Number"
                            CssClass="form-control" />

                        <small class="text-muted">Vacío = todas las edades

                        </small>

                    </div>

                </div>

            </div>

            <!-- SEXO -->

            <div class="col-lg-4">

                <div class="card card-filtro h-100">

                    <div class="card-body">

                        <div class="titulo-card">
                            Sexo

                        </div>

                        <asp:DropDownList
                            ID="ddlSexo"
                            runat="server"
                            CssClass="form-select">

                            <asp:ListItem Text="Todos" />
                            <asp:ListItem Text="Masculino" />
                            <asp:ListItem Text="Femenino" />

                        </asp:DropDownList>

                    </div>

                </div>

            </div>

            <div class="row g-4">

                <!-- BLOQUE 1 - Diagnóstico de ingreso -->


                <div class="col-12">

                    <div class="card card-filtro">

                        <div class="card-body">

                            <div class="titulo-card">
                                Diagnóstico de ingreso
                            </div>

                            <div class="row">

                                <div class="col-md-6 mb-3">
                                    <label>Infecciones</label>
                                    <asp:DropDownList ID="ddlInfecciones" runat="server" CssClass="form-select" />
                                </div>

                                <div class="col-md-6 mb-3">
                                    <label>Vasculares</label>
                                    <asp:DropDownList ID="ddlVasculares" runat="server" CssClass="form-select" />
                                </div>

                                <div class="col-md-6 mb-3">
                                    <label>Obstructivas</label>
                                    <asp:DropDownList ID="ddlObstructivas" runat="server" CssClass="form-select" />
                                </div>

                                <div class="col-md-6 mb-3">
                                    <label>Oncológicas</label>
                                    <asp:DropDownList ID="ddlOncologicas" runat="server" CssClass="form-select" />
                                </div>

                                <div class="col-md-6 mb-3">
                                    <label>Intersticiales</label>
                                    <asp:DropDownList ID="ddlIntersticiales" runat="server" CssClass="form-select" />
                                </div>

                                <div class="col-md-6 mb-3">
                                    <label>Otros</label>
                                    <asp:DropDownList ID="ddlOtros" runat="server" CssClass="form-select" />
                                </div>

                                <div class="col-md-6 mb-3">
                                    <label>Pleura</label>
                                    <asp:DropDownList ID="ddlPleura" runat="server" CssClass="form-select" />
                                </div>

                            </div>

                        </div>

                    </div>

                </div>
                <!-- BLOQUE 2 - Comorbilidades (estructura solamente) -->


                <div class="col-12">

                    <div class="card card-filtro">

                        <div class="card-body">

                            <div class="titulo-card">
                                Comorbilidades
                            </div>

                            <!-- Aquí irán los filtros de comorbilidades -->

                        </div>

                    </div>

                </div>
                <!-- BLOQUE 3 - Evolución de la internación -->

                <div class="col-12">

                    <div class="card card-filtro">

                        <div class="card-body">

                            <div class="titulo-card">
                                Evolución de la internación
                            </div>

                            <div class="row">

                                <div class="col-md-4">
                                    <label>Insuficiencia respiratoria</label>
                                    <asp:DropDownList
                                        ID="ddlInsuficiencia"
                                        runat="server"
                                        CssClass="form-select" />
                                </div>

                                <div class="col-md-4">
                                    <label>Soporte respiratorio</label>
                                    <asp:DropDownList
                                        ID="ddlSoporte"
                                        runat="server"
                                        CssClass="form-select" />
                                </div>

                                <div class="col-md-4">
                                    <label>Destino de egreso</label>
                                    <asp:DropDownList
                                        ID="ddlDestino"
                                        runat="server"
                                        CssClass="form-select" />
                                </div>

                            </div>

                        </div>

                    </div>

                </div>
                <!-- BLOQUE 4 - Botón -->

                <div class="text-center mt-5 mb-5">

                    <asp:Button
                        ID="btnGenerarReporte"
                        runat="server"
                        Text="Generar análisis"
                        OnClick="btnGenerarReporte_Click"
                        CssClass="btn btn-primary btn-lg px-5" />

                </div>
</asp:Content>









