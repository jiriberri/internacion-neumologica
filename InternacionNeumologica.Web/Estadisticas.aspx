<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Estadisticas.aspx.cs" Inherits="InternacionNeumologica.Web.Estadisticas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">

        <div class="d-flex justify-content-between align-items-center mb-4">
            <h2 class="text-white">Estadísticas y filtros</h2>
        </div>

        <div class="row g-3">
            <div class="col-md-4">
                <div class="card card-counter bg-success text-white shadow border-0">
                    <div class="card-body p-4">
                        <h6 class="text-uppercase opacity-75">Pacientes Registrados</h6>
                        <%-- Numero de prueba --%>
                        <h2 class="display-5 fw-bold my-2">124</h2>
                        <p class="mb-0 fs-7">Historial total en la base de datos.</p>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="card card-counter bg-warning text-dark shadow border-0">
                    <div class="card-body p-4">
                        <h6 class="text-uppercase opacity-75 fw-bold">Internados Actuales</h6>
                        <%-- Numero de prueba --%>
                        <h2 class="display-5 fw-bold my-2">18</h2>
                        <p class="mb-0 fs-7 fw-medium">Pacientes ocupando camas actualmente.</p>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="card card-counter bg-danger text-dark shadow border-0">
                    <div class="card-body p-4">
                        <h6 class="text-uppercase opacity-75 fw-bold">Fallecidos</h6>
                        <%-- Numero de prueba --%>
                        <h2 class="display-5 fw-bold my-2">0</h2>
                        <p class="mb-0 fs-7 fw-medium">Pacientes fallecidos en internacion.</p>
                    </div>
                </div>
            </div>
        </div>

        <hr class="text-white my-4" />

        <div class="card shadow mb-4">
            <div class="card-header">
                <h5 class="mb-0">Filtrar Pacientes</h5>
            </div>
            <div class="card-body">

                <div class="row g-3 align-items-end">
                    <div class="col-md-4">
                        <label class="form-label">Estado del Paciente</label>
                        <asp:DropDownList ID="ddlFiltroEstado" runat="server" CssClass="form-select">
                            <asp:ListItem Text="Todos" Value="Todos" />
                            <asp:ListItem Text="Internados Actualmente" Value="1" />
                            <asp:ListItem Text="No Internados (De Alta)" Value="0" />
                        </asp:DropDownList>
                    </div>

                    <div class="col-md-4">
                        <label class="form-label">Buscar por Apellido / DNI</label>
                        <asp:TextBox
                            ID="txtFiltroBusqueda"
                            runat="server"
                            CssClass="form-control"
                            Placeholder="Ej: Pérez o 35123..." />
                    </div>

                    <div class="col-md-4 d-flex align-items-end">
                        <asp:Button
                            ID="btnFiltrar"
                            runat="server"
                            Text="Filtrar"
                            OnClick="btnFiltrar_Click"
                            CssClass="btn btn-primary w-100" />
                    </div>
                </div>

                <div class="table-responsive mt-4">
                    <asp:GridView ID="dgvPacientesFiltrados" runat="server" AutoGenerateColumns="false"
                        CssClass="table table-striped table-hover align-middle mb-0"
                        EmptyDataText="No se encontraron pacientes que coincidan con los filtros aplicados.">
                    <Columns>
        <asp:BoundField HeaderText="DNI" DataField="Dni" />
        <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
        <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
        <asp:BoundField HeaderText="Fecha Nacimiento" DataField="FechaNacimiento" DataFormatString="{0:dd/MM/yyyy}" />
        <asp:BoundField HeaderText="Domicilio" DataField="Domicilio" />
        <asp:BoundField HeaderText="Teléfono" DataField="Telefono" />
    </Columns>
                    </asp:GridView>
                </div>

            </div>
        </div>

    </div>
</asp:Content>
