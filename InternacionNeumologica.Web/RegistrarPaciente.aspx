<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistrarPaciente.aspx.cs" Inherits="InternacionNeumologica.Web.RegistrarPaciente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-4">

        <div class="card shadow">

            <div class="card-header">
                <h3>Registrar Nuevo Paciente</h3>
            </div>

            <div class="card-body">

                <div class="row gy-3 mb-3">

                    <div class="col-md-6">
                        <label class="form-label">
                            DNI
                        </label>
                        <asp:TextBox
                            ID="txtDni"
                            runat="server"
                            TextMode="Number"
                            CssClass="form-control" />
                    </div>

                    <div class="col-md-6">
                        <label class="form-label">
                            Nombre
                        </label>
                        <asp:TextBox
                            ID="txtNombre"
                            runat="server"
                            CssClass="form-control" />
                    </div>

                    <div class="col-md-6">
                        <label class="form-label">
                            Apellido
                        </label>
                        <asp:TextBox
                            ID="txtApellido"
                            runat="server"
                            CssClass="form-control" />
                    </div>

                    <div class="col-md-6 ">
                        <label class="form-label">
                            Domicilio
                        </label>
                        <asp:TextBox
                            ID="txtDomicilio"
                            runat="server"
                            CssClass="form-control" />
                    </div>

                    <div class="col-md-6 ">
                        <label class="form-label">
                            Teléfono
                        </label>
                        <asp:TextBox
                            ID="txtTel"
                            runat="server"
                            CssClass="form-control" />
                    </div>

                    <div class="col-md-6">
                        <label class="form-label">
                            Fecha de nacimiento
                        </label>
                        <asp:TextBox
                            ID="txtDate"
                            runat="server"
                            TextMode="Date"
                            CssClass="form-control" />
                    </div>

                    <div class="col-md-6">
                        <label class="form-label">Historial de Tabaquismo</label>
                        <asp:DropDownList
                            ID="ddlTabaquismo"
                            runat="server"
                            CssClass="form-select"
                            AutoPostBack="true"
                            OnSelectedIndexChanged="ddlTabaquismo_SelectedIndexChanged">
                            <asp:ListItem Text="Seleccione una opción..." Value="0" />
                            <asp:ListItem Text="Nunca fumó" Value="1" />
                            <asp:ListItem Text="Exfumador" Value="2" />
                            <asp:ListItem Text="Fumador activo" Value="3" />
                        </asp:DropDownList>
                    </div>

                    <div class="col-md-6" id="divPaquetesAnio" runat="server" visible="false">
                        <label class="form-label">Paquetes / Año</label>
                        <asp:TextBox
                            ID="txtPaquetesAnio"
                            runat="server"
                            TextMode="Number"
                            CssClass="form-control"
                            placeholder="Ej: 20" />
                    </div>

                </div>

                <hr />

                <div class="d-flex justify-content-end gap-2">
                    <asp:Button
                        ID="btnCancelar"
                        runat="server"
                        Text="Cancelar"
                        CssClass="btn btn-secondary"
                        OnClick="btnCancelar_Click" />

                    <asp:Button
                        ID="btnGuardar"
                        runat="server"
                        Text="Guardar Paciente"
                        CssClass="btn btn-primary"
                        OnClick="btnGuardar_Click" />
                </div>

            </div>
        </div>
    </div>

</asp:Content>
