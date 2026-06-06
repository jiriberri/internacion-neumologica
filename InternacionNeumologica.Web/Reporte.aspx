
<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="Reporte.aspx.cs"
    Inherits="InternacionNeumologica.Web.Reporte" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>

        .dashboard-card{
            background:#1f2937;
            border:none;
            border-radius:15px;
            box-shadow:0 2px 8px rgba(0,0,0,.25);
        }

        .dashboard-card:hover{
            transform:translateY(-2px);
            transition:.2s;
        }

        .kpi{
            font-size:2.4rem;
            font-weight:bold;
            color:white;
        }

        .kpi-label{
            color:#cbd5e1;
            font-size:.95rem;
        }

        .grafico{
            height:260px;
            border-radius:12px;
            background:#111827;
            border:1px dashed #475569;
            display:flex;
            align-items:center;
            justify-content:center;
            color:#94a3b8;
            font-size:1.1rem;
        }

    </style>

</asp:Content>

<asp:Content ID="Content2"
    ContentPlaceHolderID="ContentPlaceHolder1"
    runat="server">

   
<div class="container-fluid mt-4">

    <!-- ========================================================= -->
D    <!-- ENCABEZADO DEL DASHBOARD                                 -->
    <!-- ========================================================= -->

    <div class="d-flex justify-content-between align-items-start mb-4">

        <div>

            <a href="Estadisticas.aspx"
                class="btn btn-outline-light btn-sm mb-3">

                ← Modificar criterios

            </a>

            <h2 class="text-white mb-1">

                Dashboard de Análisis Clínico

            </h2>

            <small class="text-secondary">

                Reporte generado el 16/09/2026 - 20:15 hs

            </small>

        </div>

        <div class="d-flex gap-2">

            <button class="btn btn-outline-light">

                🖨️ Imprimir

            </button>

            <button class="btn btn-primary">

                📥 Exportar

            </button>

            <button class="btn btn-success">

                📤 Compartir

            </button>

        </div>

    </div>

    <!-- ========================================================= -->
    <!-- FILTROS APLICADOS                                        -->
    <!-- ========================================================= -->

    <div class="mb-4">

        <span class="badge bg-primary p-2 me-2">
            📅 01/01/2025 - 31/12/2025
        </span>

        <span class="badge bg-success p-2 me-2">
            🫁 EPOC
        </span>

        <span class="badge bg-info text-dark p-2 me-2">
            💨 VNI
        </span>

        <span class="badge bg-danger p-2 me-2">
            ❤️ HTA
        </span>

        <span class="badge bg-secondary p-2 me-2">
            👤 Ambos sexos
        </span>

        <span class="badge bg-warning text-dark p-2">
            🎂 Todas las edades
        </span>

    </div>

    <!-- ========================================================= -->
    <!-- TARJETAS KPI                                              -->
    <!-- ========================================================= -->

    <!-- Próximo paso:
         Pacientes
         Internaciones
         Fallecidos
         Estadía promedio -->

    <!-- ========================================================= -->
    <!-- GRÁFICOS PRINCIPALES                                      -->
    <!-- ========================================================= -->

    <!-- Próximo paso:
         Distribución por edad
         Soporte respiratorio -->

    <!-- ========================================================= -->
    <!-- GRÁFICOS SECUNDARIOS                                      -->
    <!-- ========================================================= -->

    <!-- Próximo paso:
         Diagnósticos
         Comorbilidades -->

    <!-- ========================================================= -->
    <!-- TABLA RESUMEN                                             -->
    <!-- ========================================================= -->

    <!-- Próximo paso:
         Tabla estadística -->

    <!-- ========================================================= -->
    <!-- NUEVO ANÁLISIS                                            -->
    <!-- ========================================================= -->

    <!-- Próximo paso:
         Botón para volver a Estadisticas.aspx -->

</div>


</asp:Content>

