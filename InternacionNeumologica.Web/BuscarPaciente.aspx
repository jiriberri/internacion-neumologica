<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BuscarPaciente.aspx.cs" Inherits="InternacionNeumologica.Web.BuscarPaciente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-4">

    <div class="card shadow">

        <div class="card-header">
            <h3>Buscar Paciente</h3>
        </div>

        <div class="card-body">

            <div class="row mb-3">

                <div class="col-md-3">

                    <label class="form-label">
                        Buscar por
                    </label>

                    <asp:DropDownList
                        ID="ddlBusqueda"
                        runat="server"
                        CssClass="form-select">

                        <asp:ListItem Text="DNI" Value="DNI"></asp:ListItem>
                        <asp:ListItem Text="Apellido" Value="Apellido"></asp:ListItem>

                    </asp:DropDownList>

                </div>

                <div class="col-md-6">

                    <label class="form-label">
                        Valor
                    </label>

                    <asp:TextBox
                        ID="txtBusqueda"
                        runat="server"
                        CssClass="form-control">
                    </asp:TextBox>

                </div>

                <div class="col-md-3 d-flex align-items-end">

                    <asp:Button
                        ID="btnBuscar"
                        runat="server"
                        Text="Buscar"
                        CssClass="btn btn-primary w-100"
                        OnClick="btnBuscar_Click" />

                </div>

            </div>

            <hr />

            <asp:Label
                ID="lblResultado"
                runat="server"
                CssClass="fw-bold">
            </asp:Label>

            <br />
            <br />

            <asp:Button
                ID="btnNuevaInternacion"
                runat="server"
                Text="Nueva Internación"
                CssClass="btn btn-success"
                Visible="false" />

            <asp:Button
                ID="btnNuevoPaciente"
                runat="server"
                Text="Registrar Paciente"
                CssClass="btn btn-warning"
                Visible="false"
                OnClick="btnNuevoPaciente_Click"/>

        </div>

    </div>

</div>
</asp:Content>
