<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BuscarPaciente.aspx.cs" Inherits="InternacionNeumologica.Web.BuscarPaciente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container mt-4">

        <asp:Panel ID="pnlMensaje" runat="server" CssClass="alert alert-success alert-dismissible fade show shadow-sm" Visible="false" role="alert">
            <strong>¡El paciente fue registrado con éxito en el sistema!</strong>
            <button type="button" class="btn-close" data-bs-dismiss="alert"></button>
        </asp:Panel>

        <div class="card shadow">

            <div class="card-header d-flex justify-content-between align-items-center bg-light">
                <h3 class="mb-0 text-dark">Búsqueda y Selección de Pacientes</h3>
                <asp:Button
                    ID="btnNuevoPaciente"
                    runat="server"
                    Text="+ Registrar Nuevo Paciente"
                    CssClass="btn btn-primary"
                    OnClick="btnNuevoPaciente_Click" />
            </div>

            <div class="card-body">

                <div class="alert alert-info d-flex align-items-center shadow-sm mb-4" role="alert">
                    <div>
                        <strong>Instrucciones:</strong>
                        Use el filtro para localizar al paciente. Al hacer clic en el botón verde
                        <span class="badge bg-success">Seleccionar</span>
                        dentro de la lista, el sistema lo redirigirá automáticamente para iniciar el registro de una
                        <strong>nueva internación</strong> para ese paciente específico.
                    </div>
                </div>

                <div class="row g-3 align-items-end mb-4">
                    <div class="col-md-9">
                        <label class="form-label fw-bold text-secondary">Filtrar por Apellido o DNI</label>
                        <asp:TextBox
                            ID="txtBusqueda"
                            runat="server"
                            CssClass="form-control"
                            Placeholder="Ej: Perez o 30123456..." />
                    </div>
                    <div class="col-md-3">
                        <asp:Button
                            ID="btnBuscar"
                            runat="server"
                            Text="Filtrar Lista"
                            CssClass="btn btn-secondary w-100"
                            OnClick="btnBuscar_Click" />
                    </div>
                </div>

                <hr />

                <div class="table-responsive mt-3">
                    <asp:GridView
                        ID="dgvPacientes"
                        runat="server"
                        AutoGenerateColumns="false"
                        CssClass="table table-striped table-hover align-middle mb-0"
                        EmptyDataText="No se encontraron pacientes que coincidan con la búsqueda.">
                        <Columns>
                            <asp:BoundField DataField="Dni" HeaderText="DNI" ItemStyle-Width="15%" />
                            <asp:BoundField DataField="Apellido" HeaderText="Apellido" ItemStyle-Width="20%" />
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" ItemStyle-Width="20%" />
                            <asp:BoundField DataField="Telefono" HeaderText="Teléfono" ItemStyle-Width="15%" />
                            <asp:BoundField DataField="Domicilio" HeaderText="Domicilio" />

                            <asp:TemplateField HeaderText="Acción" ItemStyle-Width="15%" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:Button
                                        ID="btnSeleccionarPaciente"
                                        runat="server"
                                        Text="Seleccionar"
                                        CssClass="btn btn-sm btn-success fw-semibold"
                                        CommandArgument='<%# Eval("IdPaciente") %>'
                                        OnClick="btnSeleccionarPaciente_Click" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
