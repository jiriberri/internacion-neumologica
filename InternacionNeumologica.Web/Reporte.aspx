
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
<!-- INDICADORES PRINCIPALES (KPIs) Es una clase CSS                           -->
<!-- ========================================================= -->

<div class="row g-3 mb-4">

    <div class="col-md-3">

        <div class="card dashboard-card h-100">

            <div class="card-body text-center">

                <div style="font-size:2rem;">
                    👥
                </div>

                <div class="kpi">
                    84
                </div>

                <div class="kpi-label">
                    Pacientes
                </div>

            </div>

        </div>

    </div>

    <div class="col-md-3">

        <div class="card dashboard-card h-100">

            <div class="card-body text-center">

                <div style="font-size:2rem;">
                    🏥
                </div>

                <div class="kpi">
                    102
                </div>

                <div class="kpi-label">
                    Internaciones
                </div>

            </div>

        </div>

    </div>

    <div class="col-md-3">

        <div class="card dashboard-card h-100">

            <div class="card-body text-center">

                <div style="font-size:2rem;">
                    ❤️
                </div>

                <div class="kpi">
                    7
                </div>

                <div class="kpi-label">
                    Fallecidos
                </div>

            </div>

        </div>

    </div>

    <div class="col-md-3">

        <div class="card dashboard-card h-100">

            <div class="card-body text-center">

                <div style="font-size:2rem;">
                    📅
                </div>

                <div class="kpi">
                    11,3
                </div>

                <div class="kpi-label">
                    Estadía promedio (días)
                </div>

            </div>

        </div>

    </div>

</div>


   
<!-- ========================================================= -->
<!-- GRÁFICOS PRINCIPALES                                      -->
<!-- ========================================================= -->

<div class="row g-3 mb-4">

    <div class="col-md-6">

        <div class="card dashboard-card">

            <div class="card-body">

                <h5 class="text-white mb-3">

                    Distribución por edad

                </h5>

                <div class="grafico">

                    Gráfico disponible próximamente

                </div>

            </div>

        </div>

    </div>

    <div class="col-md-6">

        <div class="card dashboard-card">

            <div class="card-body">

                <h5 class="text-white mb-3">

                    Soporte respiratorio

                </h5>

                <div class="grafico">

                    Gráfico disponible próximamente

                </div>

            </div>

        </div>

    </div>

</div>



 
<!-- ========================================================= -->
<!-- GRÁFICOS SECUNDARIOS                                      -->
<!-- ========================================================= -->

<div class="row g-3 mb-4">

    <div class="col-md-6">

        <div class="card dashboard-card">

            <div class="card-body">

                <h5 class="text-white mb-3">

                    Grupo diagnóstico

                </h5>

                <div class="grafico">

                    Área reservada para visualización

                </div>

            </div>

        </div>

    </div>

    <div class="col-md-6">

        <div class="card dashboard-card">

            <div class="card-body">

                <h5 class="text-white mb-3">

                    Comorbilidades

                </h5>

                <div class="grafico">

                    Área reservada para visualización

                </div>

            </div>

        </div>

    </div>

</div>



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

