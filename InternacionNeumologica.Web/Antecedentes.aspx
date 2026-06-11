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
                            <div class="col-md-6">
                                <div class="form-check mb-3">
                        <asp:CheckBox ID="cbEpoc" runat="server" Text="EPOC" CssClass="me-0" />
                    </div>
                                <div class="form-check mb-3">
                        <asp:CheckBox ID="cbAsma" runat="server" Text="Asma" />
                    </div>
                                <div class="form-check mb-3">
                        <asp:CheckBox ID="cbBronquiectasias" runat="server" Text="Bronquiectasias" />
                    </div>
                               <div class="form-check mb-3">
                        <asp:CheckBox ID="cbEpd" runat="server" Text="EPD" />
                    </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-check mb-3">
                        <asp:CheckBox ID="cbTuberprev" runat="server" Text="Tuberculosis Previa" />
                    </div>
                                <div class="form-check mb-3">
                        <asp:CheckBox ID="cbCancerdepulmon" runat="server" Text="Cáncer de Pulmón" />
                    </div>
                                <div class="form-check mb-3">
                        <asp:CheckBox ID="cbVniDomicilia" runat="server" Text="VNI domiciliaria"/>
                    </div>
                                <div class="form-check mb-3">
                        <asp:CheckBox ID="cbOxigenoDomi" runat="server" Text="Oxígeno Domiciliario"/>
                    </div>
                            </div>
                        </div>

                        <hr class="border-secondary opacity-25 my-4" />

                        <div class="mb-3 text-primary-emphasis fw-semibold fs-5">Secuelas pulmonares:</div> 
                        <div class="row">
                            <div class="col-md-6">
                                
                                
                                <div class="form-check mb-3">
                        <asp:CheckBox ID="cbSecPosinfec" runat="server" Text="Secuela postinfecciosas" />
                    </div>
                            
                                <div class="form-check mb-3">
                                     <asp:CheckBox ID="cbSecPosTrauma" runat="server" Text="Secuela postraumática" />
                                  
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-check mb-3">
                                    <input class="form-check-input" type="checkbox" id="cbSecasdsa">
                                    <label class="form-check-label ms-2" for="cbSecasdsa">Secuela post-TBC</label>
                                </div>
                                <div class="form-check mb-3">
                                    <input class="form-check-input" type="checkbox" id="cbSecPasdas">
                                    <label class="form-check-label ms-2" for="cbSecPasdas">Otra resección pulmonar</label>
                                </div>
                            </div>
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
                                    <input class="form-check-input" type="radio" name="TipodeFumadores" id="cbNuncafumo">
                                    <label class="form-check-label ms-2" for="cbNuncafumo">Nunca fumó</label>
                                </div>
                                <div class="form-check mb-3">
                                    <input class="form-check-input" type="radio" name="TipodeFumadores" id="radioExfumador">
                                    <label class="form-check-label ms-2" for="radioExfumador">Exfumador</label>
                                </div>
                                <div class="d-flex align-items-center flex-wrap gap-2 mb-3">
                                    <div class="form-check">
                                        <input class="form-check-input" type="radio" name="TipodeFumadores" id="RadioFumadoractivo">
                                        <label class="form-check-label ms-2" for="RadioFumadoractivo">Fumador Activo</label> 
                                    </div>
                                    <label for="txtPaquetesAnio" class="form-label text-danger-emphasis ms-lg-3 mb-0">Paquetes/año:</label>
                                    <asp:TextBox runat="server" Id="txtPaquetesAnio" CssClass="form-control" Style="width:90px;"/> 
                                </div>
                            </div>
                        </div>

                        <hr class="border-secondary opacity-25 my-4" />

                        <div class="mb-3 text-primary-emphasis fw-semibold fs-5">Cirugía torácica previa:</div> 
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-check mb-3">
                                    <input class="form-check-input" type="checkbox" id="cbLobectomía">
                                    <label class="form-check-label ms-2" for="cbLobectomía">Lobectomía</label>
                                </div>
                                <div class="form-check mb-3">
                                    <input class="form-check-input" type="checkbox" id="cbSegmentectomia">
                                    <label class="form-check-label ms-2" for="cbSegmentectomia">Segmentectomía</label>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-check mb-3">
                                    <input class="form-check-input" type="checkbox" id="cbNeumonectomia">
                                    <label class="form-check-label ms-2" for="cbNeumonectomia">Neumonectomías</label>
                                </div>
                                <div class="form-check mb-3">
                                    <input class="form-check-input" type="checkbox" id="cbOtraresección">
                                    <label class="form-check-label ms-2" for="cbOtraresección">Otra resección pulmonar</label>
                                </div>
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
                            <div class="col-md-6">
                                <div class="form-check mb-3">
                                    <input class="form-check-input" type="checkbox" id="cbHumoleña">
                                    <label class="form-check-label ms-2" for="cbHumoleña">Humo de leña</label>
                                </div>
                                <div class="form-check mb-3">
                                    <input class="form-check-input" type="checkbox" id="cbAves">
                                    <label class="form-check-label ms-2" for="cbAves">Aves</label>
                                </div>
                                <div class="form-check mb-3">
                                    <input class="form-check-input" type="checkbox" id="cbSiliMargra">
                                    <label class="form-check-label ms-2" for="cbSiliMargra">Sílice/Mármol/Granito</label>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-check mb-3">
                                    <input class="form-check-input" type="checkbox" id="cbAsbesto">
                                    <label class="form-check-label ms-2" for="cbAsbesto">Asbesto</label>
                                </div>
                                <div class="form-check mb-3">
                                    <input class="form-check-input" type="checkbox" id="cbOtraExposicion">
                                    <label class="form-check-label ms-2" for="cbOtraExposicion">Otra exposición relevante</label>
                                </div>
                            </div>      
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
                            <asp:Button ID="btnAtras" runat="server" Text="Atrás" OnClick="btnAtras_Click" CssClass="btn btn-outline-secondary px-4 fw-semibold" CausesValidation="false"/>
                            <asp:Button ID="btnSiguiente" runat="server" Text="Siguiente" OnClick="btnSiguiente_Click" CssClass="btn btn-success px-4 fw-semibold" />
                        </div>

                    </div>
                </div> 
            </div>

        </div> </div> 
    
</asp:Content>
