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
                            OnClick="btnAgregarUsuario_Click"/>
                    </div>
                    <div class="card-body">
                        <div class="table-responsive">
                            <asp:GridView
                                ID="dgvUsuarios"
                                runat="server"
                                AutoGenerateColumns="false"
                                CssClass="table table-striped table-hover align-middle mb-0">
                                <%-- Muestra el listado de usuarios --%>
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

                                    <asp:TemplateField HeaderText="Acciones">
                                            <ItemTemplate>

                                                <asp:Button
                                                    ID="btnEditar"
                                                    runat="server"
                                                    Text="Editar"
                                                    CssClass="btn btn-sm btn-warning" 
                                                    CommandArgument='<%# Eval("IdUsuario") %>' 
                                                    OnClick="btnEditar_Click"/>

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
    </div>

</asp:Content>
