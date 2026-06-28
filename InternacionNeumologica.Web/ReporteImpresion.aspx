<%@ page language="C#" autoeventwireup="true"
    codebehind="ReporteImpresion.aspx.cs"
    inherits="InternacionNeumologica.Web.ReporteImpresion" %>

<!DOCTYPE html>
<html>

<head runat="server">

    <title>Vista previa del reporte</title>

    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" />

    <link href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.min.css" rel="stylesheet" />

    <style>
        body {
            background: #e9ecef;
            font-family: Arial, Helvetica, sans-serif;
        }

        .toolbar {
            max-width: 1100px;
            margin: 25px auto 20px;
            display: flex;
            justify-content: space-between;
            align-items: center;
        }

        .paper {
            width: 210mm;
            min-height: 297mm;
            background: white;
            margin: auto;
            padding: 40px;
            box-shadow: 0 0 18px rgba(0,0,0,.25);
        }

        .encabezado {
            display: flex;
            align-items: center;
            gap: 20px;
            border-bottom: 2px solid #c8d1da;
            padding-bottom: 20px;
            margin-bottom: 30px;
        }

        .logoHospital {
            width: 90px;
            height: auto;
        }

        .titulo h1 {
            font-size: 24px;
            margin: 0;
            color: #0d3b66;
        }

        .titulo h2 {
            font-size: 18px;
            margin: 4px 0;
            color: #5b6b7a;
        }

        .titulo h3 {
            font-size: 18px;
            margin-top: 12px;
            font-weight: bold;
            color: #0d3b66;
        }

        .datosGenerales {
            margin-top: 20px;
            margin-bottom: 25px;
        }

        .cardReporte {
            border: 1px solid #d9d9d9;
            border-radius: 6px;
            margin-bottom: 25px;
            overflow: hidden;
        }

            .cardReporte .tituloCard {
                background: #0d6efd;
                color: white;
                padding: 10px 15px;
                font-weight: bold;
                font-size: 16px;
            }

            .cardReporte .contenidoCard {
                padding: 15px;
                overflow-x: auto;
            }

        table {
            width: 100%;
            border-collapse: collapse;
        }

        th {
            background: #0d6efd;
            color: white;
            text-align: center;
            padding: 8px;
            border: 1px solid #cfd8dc;
        }

        td {
            padding: 7px;
            border: 1px solid #dee2e6;
            font-size: 12px;
        }

        tr:nth-child(even) {
            background: #f8f9fa;
        }

        .piePagina {
            margin-top: 40px;
            text-align: center;
            color: gray;
            font-size: 11px;
        }

        @page {
            size: A4 portrait;
            margin: 1cm;
        }

        @media print {

            body {
                background: white !important;
            }

            .toolbar {
                display: none !important;
            }

            .paper {
                width: 210mm;
                background: white;
                margin: auto;
                padding: 20mm;
                box-shadow: 0 0 18px rgba(0,0,0,.25);
            }

            .cardReporte {
                page-break-inside: avoid;
                break-inside: avoid;
            }

            table {
                width: 100%;
                border-collapse: collapse;
            }

            thead {
                display: table-header-group;
            }

            tfoot {
                display: table-footer-group;
            }

            tr {
                page-break-inside: avoid;
            }

            th {
                background: #2c5d87 !important;
                color: white !important;
                -webkit-print-color-adjust: exact;
                print-color-adjust: exact;
            }
        }
    </style>

</head>

<body>

    <form id="form1" runat="server">

        <div class="toolbar">

            <button type="button"
                class="btn btn-primary"
                onclick="window.print();">
                <i class="bi bi-printer-fill"></i>Imprimir

            </button>

            <button type="button"
                class="btn btn-secondary"
                onclick="window.location='Reporte.aspx';">
                ← Volver

            </button>

        </div>

        <div class="paper">

            <div class="encabezado">

                <img src="Imagenes/logo-cetrangolo.png"
                    class="logoHospital"
                    alt="Hospital Cetrángolo" />

                <div class="titulo">

                    <h1>Hospital Especializado de Agudos y Crónicos</h1>

                    <h2>Dr. Antonio A. Cetrángolo</h2>

                    <h2>Servicio de Clínica Neumonológica</h2>

                    <h3>REPORTE DE INTERNACIONES</h3>

                </div>

            </div>

            <div class="datosGenerales">

                <strong>Fecha de emisión:</strong>

                <%= DateTime.Now.ToString("dd/MM/yyyy HH:mm") %>

                <br />
                <br />

                <strong>Internaciones encontradas:</strong>
                <asp:Label
                    ID="lblCantidad"
                    runat="server" />
            </div>
            <div class="row mb-4">

                <div class="col-md-6">

                    <div class="cardReporte">

                        <div class="tituloCard">
                            Filtros aplicados

                        </div>

                        <div class="contenidoCard">

                            <asp:Literal
                                ID="litFiltros"
                                runat="server" />

                        </div>

                    </div>

                </div>

                <div class="col-md-6">

                    <div class="cardReporte">

                        <div class="tituloCard">
                            Comorbilidades seleccionadas

                        </div>

                        <div class="contenidoCard">

                            <asp:Literal
                                ID="litComorbilidades"
                                runat="server" />

                        </div>

                    </div>

                </div>

            </div>

            <div class="cardReporte">

                <div class="tituloCard">
                    Internaciones encontradas

                </div>

                <div class="contenidoCard">

                    <asp:GridView
                        ID="gvDetalle"
                        runat="server"
                        AutoGenerateColumns="False"
                        Width="100%"
                        CssClass="table table-bordered table-hover table-sm">

                        <columns>

                            <asp:BoundField DataField="Internacion"
                                HeaderText="N°"
                                ItemStyle-Width="45px"
                                ItemStyle-HorizontalAlign="Center" />

                            <asp:BoundField DataField="DNI"
                                HeaderText="DNI"
                                ItemStyle-Width="90px" />

                            <asp:BoundField DataField="Paciente"
                                HeaderText="Paciente"
                                ItemStyle-Width="180px" />

                            <asp:BoundField DataField="Edad"
                                HeaderText="Edad"
                                ItemStyle-Width="45px"
                                ItemStyle-HorizontalAlign="Center" />

                            <asp:BoundField DataField="Ingreso"
                                HeaderText="Ingreso"
                                DataFormatString="{0:dd/MM/yyyy}"
                                HtmlEncode="false"
                                ItemStyle-Width="80px"
                                ItemStyle-HorizontalAlign="Center" />

                            <asp:BoundField DataField="Egreso"
                                HeaderText="Egreso"
                                DataFormatString="{0:dd/MM/yyyy}"
                                HtmlEncode="false"
                                ItemStyle-Width="80px"
                                ItemStyle-HorizontalAlign="Center" />

                            <asp:BoundField DataField="Estadia"
                                HeaderText="Días"
                                ItemStyle-Width="45px"
                                ItemStyle-HorizontalAlign="Center" />

                            <asp:BoundField DataField="Soporte"
                                HeaderText="Soporte"
                                ItemStyle-Width="95px" />

                            <asp:BoundField DataField="Insuficiencia"
                                HeaderText="Insuficiencia"
                                ItemStyle-Width="100px" />

                            <asp:BoundField DataField="Destino"
                                HeaderText="Destino"
                                ItemStyle-Width="110px" />

                        </columns>

                    </asp:GridView>

                </div>

            </div>
            <div class="piePagina">

                <hr />

                <strong>Sistema de Gestión de Internaciones Neumonológicas</strong><br />

                Hospital Especializado de Agudos y Crónicos
    <br />

                Dr. Antonio A. Cetrángolo

            </div>

        </div>

    </form>

</body>

</html>
