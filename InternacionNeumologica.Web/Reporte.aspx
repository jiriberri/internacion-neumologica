<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="Reporte.aspx.cs"
    Inherits="InternacionNeumologica.Web.Reporte" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        .dashboard-card {
            background: #1f2937;
            border: none;
            border-radius: 15px;
            box-shadow: 0 2px 8px rgba(0,0,0,.25);
        }

            .dashboard-card:hover {
                transform: translateY(-2px);
                transition: .2s;
            }

        .kpi {
            font-size: 2.4rem;
            font-weight: bold;
            color: white;
        }

        .kpi-label {
            color: #cbd5e1;
            font-size: .95rem;
        }

        .grafico {
            height: 260px;
            border-radius: 12px;
            background: #111827;
            border: 1px dashed #475569;
            display: flex;
            align-items: center;
            justify-content: center;
            color: #94a3b8;
            font-size: 1.1rem;
        }

        @media print {

            /* Oculta todos los botones */
            .btn {
                display: none !important;
            }

            /* Oculta los links */
            a {
                display: none !important;
            }

            /* Fondo blanco para imprimir */
            body {
                background: white !important;
            }

            /* Las cards no llevan sombra en papel */
            .dashboard-card {
                background: white !important;
                color: black !important;
                box-shadow: none !important;
                border: 1px solid #ccc !important;
            }

            /* Todo el texto en negro */
            .text-white,
            .text-light,
            .text-secondary {
                color: black !important;
            }

            /* Evita que una card se corte entre dos hojas */
            .card {
                page-break-inside: avoid;
            }

            /* La tabla ocupa todo el ancho */
            table {
                width: 100% !important;
            }
        }
    </style>

</asp:Content>

<asp:Content ID="Content2"
    ContentPlaceHolderID="ContentPlaceHolder1"
    runat="server">


    <div class="container-fluid mt-4">

        <!-- ========================================================= -->
        <!-- ENCABEZADO DEL DASHBOARD                                 -->
        <!-- ========================================================= -->


        <div class="d-flex justify-content-between align-items-start mb-4">

            <div>

                <a href="Estadisticas.aspx"
                    class="btn btn-outline-light btn-sm mb-3">← Modificar criterios

                </a>

                <h2 class="text-white mb-1">Reporte de Internaciones

                </h2>

                <small class="text-secondary">Reporte generado el <%= DateTime.Now.ToString("dd/MM/yyyy HH:mm") %>

                </small>

            </div>

            <div class="d-flex gap-2">

                <button
                    type="button"
                    class="btn btn-outline-light"
                    onclick="window.open('ReporteImpresion.aspx','_blank');">
                    <!--Abre reporteimpresion -->
                    🖨️ Imprimir

                </button>

                <asp:Button
                    ID="btnExportar"
                    runat="server"
                    Text="📥 Exportar"
                    CssClass="btn btn-primary"
                    OnClick="BtnExportar_Click" />

                <button class="btn btn-success">
                    📤 Compartir
                </button>

            </div>

        </div>



        <!-- ========================================================= -->
        <!-- FILTROS APLICADOS                                        -->
        <!-- ========================================================= -->



        <div class="card dashboard-card mb-4">

            <div class="card-body">

                <h5 class="text-white mb-3">Filtros aplicados
                </h5>

                <div class="row g-3">

                    <div class="col-md-4">
                        <strong class="text-white">📅 Período</strong><br />
                        <asp:Label ID="lblPeriodo" runat="server" CssClass="text-light" />
                    </div>

                    <div class="col-md-4">
                        <strong class="text-white">🫁 Diagnóstico</strong><br />
                        <asp:Label ID="lblDiagnostico" runat="server" CssClass="text-light" />
                    </div>

                    <div class="col-md-4">
                        <strong class="text-white">💨 Soporte respiratorio</strong><br />
                        <asp:Label ID="lblSoporte" runat="server" CssClass="text-light" />
                    </div>

                    <div class="col-md-4">
                        <strong class="text-white">❤️ Insuficiencia respiratoria</strong><br />
                        <asp:Label ID="lblInsuficiencia" runat="server" CssClass="text-light" />
                    </div>

                    <div class="col-md-4">
                        <strong class="text-white">🏥 Destino de egreso</strong><br />
                        <asp:Label ID="lblDestino" runat="server" CssClass="text-light" />
                    </div>

                </div>

            </div>

        </div>

    </div>



    <!-- ========================================================= -->
    <!-- COMORBILIDADES SELECCIONADAS                              -->
    <!-- ========================================================= -->

    <div class="card dashboard-card mb-4">

        <div class="card-body">

            <h5 class="text-white mb-3">Comorbilidades seleccionadas
            </h5>

            <asp:Label
                ID="lblComorbilidades"
                runat="server"
                CssClass="text-light" />

        </div>

    </div>



    <!-- =================================================================================== -->
    <!-- TABLA RESUMEN   //el panel lo envuelve paraf que el paginado no recargue y vaya arriba                                          -->
    <!-- =================================================================================== -->
    <asp:UpdatePanel ID="upDetalle" runat="server">
        <ContentTemplate>
            <div class="card dashboard-card mt-4">

                <div class="card-body">

                    <h4 class="text-white mb-3">Resultado de la consulta

                    </h4>


                    <asp:GridView
                        ID="gvDetalle"
                        runat="server"
                        AutoGenerateColumns="false"
                        AllowPaging="true"
                        PageSize="5"
                        OnPageIndexChanging="gvDetalle_PageIndexChanging"
                        CssClass="table table-dark table-striped table-hover align-middle"
                        GridLines="None"
                        Width="100%"
                        EmptyDataText="No se encontraron registros para los criterios seleccionados.">

                        <Columns>

                            <asp:BoundField
                                DataField="Internacion"
                                HeaderText="N° Internación" />

                            <asp:BoundField
                                DataField="DNI"
                                HeaderText="DNI" />

                            <asp:BoundField
                                DataField="Paciente"
                                HeaderText="Paciente" />

                            <asp:BoundField
                                DataField="Edad"
                                HeaderText="Edad" />

                            <asp:BoundField
                                DataField="Ingreso"
                                HeaderText="Ingreso"
                                DataFormatString="{0:dd/MM/yyyy}" />

                            <asp:BoundField
                                DataField="Egreso"
                                HeaderText="Egreso"
                                DataFormatString="{0:dd/MM/yyyy}" />

                            <asp:BoundField
                                DataField="Estadia"
                                HeaderText="Estadía (días)" />

                            <asp:BoundField
                                DataField="Soporte"
                                HeaderText="Soporte respiratorio" />

                            <asp:BoundField
                                DataField="Insuficiencia"
                                HeaderText="Insuficiencia respiratoria" />

                            <asp:BoundField
                                DataField="Destino"
                                HeaderText="Destino de egreso" />

                        </Columns>

                    </asp:GridView>



                </div>

            </div>
        </ContentTemplate>

    </asp:UpdatePanel>



</asp:Content>




