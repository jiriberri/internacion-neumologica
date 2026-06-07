<%@ Page Title=""
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="Reporte.aspx.cs"
    Inherits="InternacionNeumologica.Web.Reporte" %>

<asp:Content ID="Content1"
    ContentPlaceHolderID="head"
    runat="server">
</asp:Content>

<asp:Content ID="Content2"
    ContentPlaceHolderID="ContentPlaceHolder1"
    runat="server">

   
<div class="container-fluid mt-4">

    <!-- ========================================================= -->
    <!-- ENCABEZADO DEL DASHBOARD                                  -->
    <!-- ========================================================= -->

    <div class="d-flex justify-content-between align-items-start mb-4">

        <div>

            <a href="Estadisticas.aspx"
                class="btn btn-outline-light btn-sm mb-3">

                ← Modificar criterios

            </a>

            <h2 class="text-white mb-1">

                Reporte Estadístico
Análisis Clínico de Internaciones Respiratorias

            </h2>

            <small class="text-secondary">

                Reporte generado el 22/09/2026 - 21:15 hs

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
    <!-- FILTROS APLICADOS                                         -->
    <!-- ========================================================= -->

    <div class="mb-4">

        <span class="badge bg-primary p-2 me-2">
            📅 2025
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

</div>


</asp:Content>
