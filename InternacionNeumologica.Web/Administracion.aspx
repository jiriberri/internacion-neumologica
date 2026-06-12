<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Administracion.aspx.cs" Inherits="InternacionNeumologica.Web.Administracion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .nav-tabs .nav-link:not(.active) {
            color: #b6b6b6;
        }

            .nav-tabs .nav-link:not(.active):hover {
                color: #ffffff;
                background-color: #ffffff0e;
                border-color: transparent;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-4">

        <div class="d-flex justify-content-between align-items-center mb-4">
            <h2 class="text-white">Panel de Control - Administrador</h2>
            <span class="badge bg-danger fs-6">Rol: Admin</span>
        </div>

        <ul class="nav nav-tabs mb-4" id="adminTabs" role="tablist">
            <li class="nav-item" role="presentation">
                <button class="nav-link active" id="usuarios-tab" data-bs-toggle="tab" data-bs-target="#usuarios" type="button" role="tab" aria-controls="usuarios" aria-selected="true">
                    Gestión de Usuarios
                </button>
            </li>
            <li class="nav-item" role="presentation">
                <button class="nav-link" id="pacientes-tab" data-bs-toggle="tab" data-bs-target="#pacientes" type="button" role="tab" aria-controls="pacientes" aria-selected="false">
                    Corrección de Pacientes
                </button>
            </li>
            <li class="nav-item" role="presentation">
                <button class="nav-link" id="catalogos-tab" data-bs-toggle="tab" data-bs-target="#catalogos" type="button" role="tab" aria-controls="catalogos" aria-selected="false">
                    Tablas Maestras
                </button>
            </li>
        </ul>

        <div class="tab-content" id="adminTabsContent">

            <div class="tab-pane fade show active" id="usuarios" role="tabpanel" aria-labelledby="usuarios-tab">
                <div class="card shadow">
                    <div class="card-header d-flex justify-content-between align-items-center bg-light">
                        <h4 class="mb-0">Lista de Usuarios</h4>
                        <asp:Button
                            ID="btnAgregarUsuario"
                            runat="server"
                            Text="+ Nuevo Usuario"
                            CssClass="btn btn-sm btn-primary"
                            OnClick="btnAgregarUsuario_Click" />
                    </div>
                    <div class="card-body">
                        <div class="table-responsive">
                            <asp:GridView
                                ID="dgvUsuarios"
                                runat="server"
                                AutoGenerateColumns="false"
                                CssClass="table table-striped table-hover align-middle mb-0">
                                <Columns>

                                    <asp:BoundField
                                        DataField="IdUsuario"
                                        HeaderText="ID" />

                                    <asp:BoundField
                                        DataField="User"
                                        HeaderText="Usuario" />

                                    <asp:CheckBoxField
                                        DataField="Admin"
                                        HeaderText="Administrador" />

                                    <asp:CheckBoxField
                                        DataField="Activo"
                                        HeaderText="Activo" />

                                    <asp:TemplateField HeaderText="Acciones">
                                        <ItemTemplate>

                                            <asp:Button
                                                ID="btnEditar"
                                                runat="server"
                                                Text="Editar"
                                                CssClass="btn btn-sm btn-warning"
                                                CommandArgument='<%# Eval("IdUsuario") %>'
                                                OnClick="btnEditar_Click" />



                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>

            <div class="tab-pane fade" id="pacientes" role="tabpanel" aria-labelledby="pacientes-tab">
                <div class="card shadow">
                    <div class="card-header">
                        <h4 class="mb-0">Modificar Datos de Paciente</h4>
                    </div>
                    <div class="card-body">

                        <div class="row g-3 align-items-end mb-4">
                            <div class="col-md-8">
                                <label class="form-label">Ingresar DNI del Paciente a corregir</label>
                                <asp:TextBox
                                    ID="txtDniBuscar"
                                    runat="server"
                                    TextMode="Number"
                                    CssClass="form-control"
                                    Placeholder="Ej: 35123456" />
                            </div>
                            <div class="col-md-4">
                                <asp:Button
                                    ID="btnBuscarPacienteAdmin"
                                    runat="server"
                                    Text="Buscar para Editar"
                                    CssClass="btn btn-primary w-100" />
                            </div>
                        </div>

                        <hr />

                        <div class="row g-3">
                            <div class="col-md-6">
                                <label class="form-label">
                                    Nombre
                                </label>
                                <asp:TextBox
                                    ID="txtModNombre"
                                    runat="server"
                                    CssClass="form-control" />
                            </div>

                            <div class="col-md-6">
                                <label class="form-label">
                                    Apellido
                                </label>
                                <asp:TextBox
                                    ID="txtModApellido"
                                    runat="server"
                                    CssClass="form-control" />
                            </div>

                            <div class="col-md-6">
                                <label class="form-label">
                                    DNI
                                </label>
                                <asp:TextBox
                                    ID="txtModDni"
                                    runat="server"
                                    TextMode="Number"
                                    CssClass="form-control" />
                            </div>

                            <div class="col-md-6 ">
                                <label class="form-label">
                                    Domicilio
                                </label>
                                <asp:TextBox
                                    ID="txtModDomicilio"
                                    runat="server"
                                    CssClass="form-control" />
                            </div>

                            <div class="col-md-6 ">
                                <label class="form-label">
                                    Teléfono
                                </label>
                                <asp:TextBox
                                    ID="txtModTel"
                                    runat="server"
                                    CssClass="form-control" />
                            </div>

                            <div class="col-md-6">
                                <label class="form-label">
                                    Fecha de nacimiento
                                </label>
                                <asp:TextBox
                                    ID="txtModDate"
                                    runat="server"
                                    TextMode="Date"
                                    CssClass="form-control" />
                            </div>
                        </div>

                        <div class="d-flex justify-content-end gap-2 mt-4">
                            <asp:Button
                                ID="btnCancelarMod"
                                runat="server"
                                Text="Descartar Cambios"
                                CssClass="btn btn-secondary" />
                            <asp:Button
                                ID="btnGuardarMod"
                                runat="server"
                                Text="Guardar Modificaciones"
                                CssClass="btn btn-success" />
                        </div>

                    </div>
                </div>
            </div>

        </div>

        <div class="tab-pane fade" id="catalogos" role="tabpanel" aria-labelledby="catalogos-tab">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>

                    <asp:HiddenField ID="hfIdEditando" runat="server" />

                    <div class="card shadow">
                        <div class="card-header">
                            <h4 class="mb-0">Gestión de Tablas Maestras</h4>
                        </div>
                        <div class="card-body">

                            <div class="row g-3 align-items-end mb-4">
                                <div class="col-md-6">
                                    <label class="form-label fw-bold">Seleccionar Tabla / Catálogo</label>
                                    <asp:DropDownList
                                        ID="ddlCatalogos"
                                        runat="server"
                                        CssClass="form-select"
                                        AutoPostBack="true"
                                        OnSelectedIndexChanged="ddlCatalogos_SelectedIndexChanged">
                                        <asp:ListItem Text="-- Seleccione una tabla para gestionar --" Value="0" />
                                        <asp:ListItem Text="Antecedentes Respiratorios" Value="ANTECEDENTE_RESPIRATORIO" />
                                        <asp:ListItem Text="Cirugías Torácicas Previas" Value="CIRUGIA" />
                                        <asp:ListItem Text="Comorbilidades: Cardiovasculares" Value="COMORBILIDAD_CARDIOVASCULAR" />
                                        <asp:ListItem Text="Comorbilidades: Inmunológicas" Value="COMORBILIDAD_INMUNOLOGICA" />
                                        <asp:ListItem Text="Comorbilidades: Metabólicas" Value="COMORBILIDAD_METABOLICA" />
                                        <asp:ListItem Text="Comorbilidades: Neurológicas" Value="COMORBILIDAD_NEUROLOGICA" />
                                        <asp:ListItem Text="Comorbilidades: Oncológicas" Value="COMORBILIDAD_ONCOLOGICA" />
                                        <asp:ListItem Text="Comorbilidades: Sueño" Value="COMORBILIDAD_SUEÑO" />
                                        <asp:ListItem Text="Destinos de Egreso" Value="DESTINO_EGRESO" />
                                        <asp:ListItem Text="Diagnósticos: Infecciones" Value="DIAGNOSTICO_INFECCIONES" />
                                        <asp:ListItem Text="Diagnósticos: Intersticiales" Value="DIAGNOSTICO_INTERSTICIALES" />
                                        <asp:ListItem Text="Diagnósticos: Obstructivas" Value="DIAGNOSTICO_OBSTRUCTIVAS" />
                                        <asp:ListItem Text="Diagnósticos: Oncológicas" Value="DIAGNOSTICO_ONCOLOGICAS" />
                                        <asp:ListItem Text="Diagnósticos: Otros Criterios" Value="DIAGNOSTICO_OTROS" />
                                        <asp:ListItem Text="Diagnósticos: Pleura" Value="DIAGNOSTICO_PLEURA" />
                                        <asp:ListItem Text="Diagnósticos: Vasculares" Value="DIAGNOSTICO_VASCULARES" />
                                        <asp:ListItem Text="Exposiciones Ambientales" Value="EXPOSICION_AMBIENTAL" />
                                        <asp:ListItem Text="Insuficiencias Respiratorias" Value="INSUFICIENCIA_RESPIRATORIA" />
                                        <asp:ListItem Text="Orígenes de Internación" Value="ORIGEN_INTERNACION" />
                                        <asp:ListItem Text="Secuelas Pulmonares" Value="SECUELA" />
                                        <asp:ListItem Text="Soportes Respiratorios" Value="SOPORTE_RESPIRATORIO" />
                                        <asp:ListItem Text="Historial de Tabaquismo" Value="TABAQUISMO" />
                                    </asp:DropDownList>
                                </div>

                                <div class="col-md-6 mb-2">
                                    <div class="d-flex align-items-center h-100 ps-md-2 pt-2">
                                        <asp:CheckBox
                                            ID="chkMostrarDeshabilitados"
                                            runat="server"
                                            Text="&nbsp;Ver elementos deshabilitados"
                                            AutoPostBack="true"
                                            OnCheckedChanged="chkMostrarDeshabilitados_CheckedChanged"
                                            CssClass="fw-semibold" />
                                    </div>
                                </div>
                            </div>

                            <asp:PlaceHolder ID="phFormularioCatalogo" runat="server" Visible="false">
                                <hr />

                                <asp:Panel ID="pnlAltaCatalogo" runat="server" DefaultButton="btnAgregarItem" CssClass="row g-3 align-items-end mb-4">
                                    <div class="col-md-8">
                                        <label class="form-label">Nueva Descripción / Ítem</label>
                                        <asp:TextBox ID="txtNuevaDescripcion" runat="server" CssClass="form-control" Placeholder="Ej: Nueva variante o diagnóstico..." />
                                    </div>
                                    <div class="col-md-4">
                                        <asp:Button ID="btnAgregarItem" runat="server" Text="Agregar a la Tabla" CssClass="btn btn-success w-100" OnClick="btnAgregarItem_Click" />
                                    </div>
                                </asp:Panel>

                                <div class="table-responsive">
                                    <asp:GridView
                                        ID="dgvCatalogoGenerico"
                                        runat="server"
                                        AutoGenerateColumns="false"
                                        CssClass="table table-striped table-hover align-middle mb-0"
                                        EmptyDataText="La tabla seleccionada no contiene registros.">
                                        <Columns>
                                            <asp:BoundField DataField="Id" HeaderText="ID Interno" ItemStyle-Width="10%" />
                                            <asp:BoundField DataField="Descripcion" HeaderText="Descripción Registrada" />

                                            <asp:TemplateField HeaderText="Acciones" ItemStyle-Width="25%">
                                                <ItemTemplate>
                                                    <asp:Button
                                                        ID="btnEditarItemTabla"
                                                        runat="server"
                                                        Text="Editar"
                                                        CssClass="btn btn-sm btn-warning"
                                                        CommandArgument='<%# Eval("Id") + "|" + Eval("Descripcion") %>'
                                                        OnClick="btnEditarItemTabla_Click"
                                                        Visible='<%# !chkMostrarDeshabilitados.Checked %>' />

                                                    <asp:Button
                                                        ID="btnEliminarItem"
                                                        runat="server"
                                                        Text="Eliminar"
                                                        CssClass="btn btn-sm btn-danger"
                                                        CommandArgument='<%# Eval("Id") %>'
                                                        OnClick="btnEliminarItem_Click"
                                                        OnClientClick="return confirm('¿Está seguro de que desea deshabilitar este elemento del catálogo?');"
                                                        Visible='<%# !chkMostrarDeshabilitados.Checked %>' />

                                                    <asp:Button
                                                        ID="btnReactivarItem"
                                                        runat="server"
                                                        Text="Reactivar"
                                                        CssClass="btn btn-sm btn-success"
                                                        CommandArgument='<%# Eval("Id") %>'
                                                        OnClick="btnReactivarItem_Click"
                                                        Visible='<%# chkMostrarDeshabilitados.Checked %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </asp:PlaceHolder>

                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

</asp:Content>
