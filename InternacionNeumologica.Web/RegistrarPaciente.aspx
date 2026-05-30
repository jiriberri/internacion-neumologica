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

                </div>

                <hr />

                <div class="d-flex justify-content-end gap-2">
                    <asp:Button
                        ID="btnCancelar"
                        runat="server"
                        Text="Cancelar"
                        CssClass="btn btn-secondary" />
                    <asp:Button
                        ID="btnGuardar"
                        runat="server"
                        Text="Guardar Paciente"
                        CssClass="btn btn-primary" />
                </div>

            </div>
        </div>
    </div>

</asp:Content>
