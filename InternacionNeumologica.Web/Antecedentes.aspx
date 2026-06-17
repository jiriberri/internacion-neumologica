<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Antecedentes.aspx.cs" Inherits="InternacionNeumologica.Web.Antecedentes" %>

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
            <h1 class="text-white mb-1">Antecedentes del Paciente</h1>
            <p class="text-secondary">Carga de antecedentes clínicos, factores de riesgo y exposición ambiental.</p>
        </div>

        <div class="row g-3 mb-4">

            <div class="col-lg-6">
                <div class="card card-filtro h-100">
                    <div class="card-body">

                        <div class="mb-3 text-primary-emphasis fw-semibold fs-5">Antecedentes respiratorios:</div>
                        <div class="row">
                            <% foreach (var ant in ListaAntecedentesRespiratorios)
                                               { %>
                            <div class="col-md-6 mb-3">
                                <div class="form-check">
                                    <input class="form-check-input" type="checkbox"
                                        name="chkAntecedentes"
                                        value="<%Response.Write(ant.Id);%>"
                                        id="chk_resp_<%Response.Write(ant.Id);%>" />

                                    <label class="form-check-label" for="chk_resp_<%Response.Write(ant.Id);%>">
                                        <%Response.Write(ant.Descripcion);%>
                                    </label>
                                </div>
                            </div>
                            <% } %>
                        </div>
                        <hr class="border-secondary opacity-25 my-4" />

                        <div class="mb-3 text-primary-emphasis fw-semibold fs-5">Secuelas pulmonares:</div>
                        <div class="row">
                            <% foreach (var sec in ListaSecuela)
                                               { %>
                            <div class="col-md-6 mb-3">
                                <div class="form-check">
                                    <input class="form-check-input" type="checkbox"
                                        name="chkSecuela"
                                        value="<%Response.Write(sec.Id);%>"
                                        id="chk_sec_<%Response.Write(sec.Id); %>" />

                                    <label class="form-check-label" for="chk_resp_<%Response.Write(sec.Id);%>">
                                        <%Response.Write(sec.Descripcion);%>
                                    </label>
                                </div>
                            </div>
                            <% } %>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-lg-6">
                <div class="card card-filtro h-100">
                    <div class="card-body">

                        <div class="mb-3 text-primary-emphasis fw-semibold fs-5">Tabaquismo:</div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-check mb-3">
                                    <input class="form-check-input" type="radio" name="TipodeFumadores" value="1" id="cbNuncafumo">
                                    <label class="form-check-label ms-2" for="cbNuncafumo">Nunca fumó</label>
                                </div>
                                <div class="form-check mb-3">
                                    <input class="form-check-input" type="radio" name="TipodeFumadores" value="2" id="radioExfumador">
                                    <label class="form-check-label ms-2" for="radioExfumador">Exfumador</label>
                                </div>
                                <div class="d-flex align-items-center flex-wrap gap-2 mb-3">
                                    <div class="form-check">
                                        <input class="form-check-input" type="radio" name="TipodeFumadores" value="3" id="RadioFumadoractivo">
                                        <label class="form-check-label ms-2" for="RadioFumadoractivo">Fumador Activo</label>
                                    </div>
                                    <label for="txtPaquetesAnio" class="form-label text-danger-emphasis ms-lg-3 mb-0">Paquetes/año:</label>
                                    <asp:TextBox runat="server" ID="txtPaquetesAnio" CssClass="form-control" Style="width: 90px;" />
                                </div>

                                <asp:Label ID="lblTipoFumador" runat="server" Text="Debes seleccionar el tipo de fumador." CssClass="text-danger d-block mt-1 fw-semibold fs-6" Visible="false"></asp:Label>
                            </div>
                        </div>

                        <hr class="border-secondary opacity-25 my-4" />

                        <div class="mb-3 text-primary-emphasis fw-semibold fs-5">Cirugía torácica previa:</div>
                        <div class="row">
                            <% foreach (var cir in ListaCirugia)
                                               { %>
                            <div class="col-md-6 mb-3">
                                <div class="form-check">
                                    <input class="form-check-input" type="checkbox"
                                        name="chkCirugias"
                                        value="<% Response.Write(cir.Id); %>"
                                        id="chk_cir_<% Response.Write(cir.Id); %>" />

                                    <label class="form-check-label ms-2" for="chk_cir_<% Response.Write(cir.Id); %>">
                                        <% Response.Write(cir.Descripcion); %>
                                    </label>
                                </div>
                            </div>
                            <% } %>
                        </div>

                    </div>
                </div>

            </div>
        </div>
    </div>



    <div class="row g-3">

        <div class="col-lg-6">
            <div class="card card-filtro h-100">
                <div class="card-body">
                    <div class="mb-4 text-primary-emphasis fw-semibold fs-5">Exposición ambiental/Ocupacional:</div>
                    <div class="row">
                        <% foreach (var exp in ListaExpoAmb)
                                           { %>
                        <div class="col-md-6 mb-3">
                            <div class="form-check">
                                <input class="form-check-input" type="checkbox"
                                    name="chkExposiciones"
                                    value="<% Response.Write(exp.Id); %>"
                                    id="chk_exp_<% Response.Write(exp.Id); %>" />

                                <label class="form-check-label ms-2" for="chk_exp_<% Response.Write(exp.Id); %>">
                                    <% Response.Write(exp.Descripcion); %>
                                </label>
                            </div>
                        </div>
                        <% } %>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-lg-6">
            <div class="card card-filtro h-100">
                <div class="card-body d-flex flex-column justify-content-between">
                    <div>
                        <div class="mb-4 text-success-emphasis fw-semibold fs-5">Evolución respiratoria:</div>

                        <div class="mb-3">
                            <label for="ddlInsRespiratoria" class="form-label text-secondary fw-semibold fs-6">¿Tuvo insuficiencia respiratoria?</label>
                            <asp:DropDownList ID="ddlInsRespiratoria" runat="server" CssClass="form-select" Style="max-width: 350px;">
                                <asp:ListItem Text="Seleccione una opción." Value="" />
                            </asp:DropDownList>
                        </div>

                        <div class="mb-3">
                            <label for="ddlSoporte" class="form-label text-secondary fw-semibold fs-6">¿Requirió soporte?</label>
                            <asp:DropDownList ID="ddlSoporte" runat="server" CssClass="form-select" Style="max-width: 350px;">
                                <asp:ListItem Text="Seleccione una opción." Value="" />
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="d-flex justify-content-center gap-3 mt-4">
                        <asp:Button ID="btnAtras" runat="server" Text="Atrás" OnClick="btnAtras_Click" CssClass="btn btn-outline-secondary px-4 fw-semibold" CausesValidation="false" />
                        <asp:Button ID="btnSiguiente" runat="server" Text="Siguiente" OnClick="btnSiguiente_Click" CssClass="btn btn-success px-4 fw-semibold" />
                    </div>

                </div>
            </div>
        </div>

    </div>

</asp:Content>
