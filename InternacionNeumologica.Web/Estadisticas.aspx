

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Estadisticas.aspx.cs" Inherits="InternacionNeumologica.Web.Estadisticas" %>

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

        <h2 class="text-white mb-1">
            Análisis Histórico de Internaciones
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

                    <small class="text-muted">

                        Vacío = todas las edades

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

        <!-- DIAGNOSTICO -->

        <div class="col-lg-4">

            <div class="card card-filtro h-100">

                <div class="card-body">

                    <div class="titulo-card">

                        Diagnóstico de base

                    </div>

                    <asp:DropDownList
                        ID="ddlDiagnostico"
                        runat="server"
                        CssClass="form-select">

                        <asp:ListItem Text="Todos" />

                    </asp:DropDownList>

                </div>

            </div>

        </div>

        <!-- INSUFICIENCIA -->

        <div class="col-lg-4">

            <div class="card card-filtro h-100">

                <div class="card-body">

                    <div class="titulo-card">

                        Tipo de insuficiencia

                    </div>

                    <asp:DropDownList
                        ID="ddlInsuficiencia"
                        runat="server"
                        CssClass="form-select">

                        <asp:ListItem Text="Todas" />

                    </asp:DropDownList>

                </div>

            </div>

        </div>

        <!-- COMORBILIDAD -->

        <div class="col-lg-4">

            <div class="card card-filtro h-100">

                <div class="card-body">

                    <div class="titulo-card">

                        Comorbilidad

                    </div>

                    <asp:DropDownList
                        ID="ddlComorbilidad"
                        runat="server"
                        CssClass="form-select">

                        <asp:ListItem Text="Todas" />

                    </asp:DropDownList>

                </div>

            </div>

        </div>

        <!-- SOPORTE -->

        <div class="col-lg-6">

            <div class="card card-filtro h-100">

                <div class="card-body">

                    <div class="titulo-card">

                        Soporte respiratorio

                    </div>

                    <asp:DropDownList
                        ID="ddlSoporte"
                        runat="server"
                        CssClass="form-select">

                        <asp:ListItem Text="Todos" />

                    </asp:DropDownList>

                </div>

            </div>

        </div>

        <!-- DESTINO -->

        <div class="col-lg-6">

            <div class="card card-filtro h-100">

                <div class="card-body">

                    <div class="titulo-card">

                        Destino de egreso

                    </div>

                    <asp:DropDownList
                        ID="ddlDestino"
                        runat="server"
                        CssClass="form-select">

                        <asp:ListItem Text="Todos" />

                    </asp:DropDownList>

                </div>

            </div>

        </div>

    </div>

    <div class="text-center mt-4 mb-5">

        <asp:Button
            ID="btnGenerarReporte"
            runat="server"
            Text="Generar análisis"
            OnClick="btnGenerarReporte_Click" 
            CssClass="btn btn-primary btn-lg px-5" />


    </div>

</div>

</asp:Content>




