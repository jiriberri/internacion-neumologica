<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Antecedentes.aspx.cs" Inherits="InternacionNeumologica.Web.Antecedentes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


<div class="text-white text-center mb-3">
    <h1>Antecedentes</h1>
</div> 

<div class="row justify-content-center mt-10">
    <div class="col-md-6">
        
        <div class="card bg-light text-black shadow p-4 rounded-4 mb-3">
            
           
            <div class="mb-4 text-primary-emphasis fw-semibold fs-5">Antecedentes respiratorios:</div> 

            
            <div class="row">
                
               
                <div class="col-md-6">
                    <div class="form-check mb-3">
                        <input class="form-check-input" type="checkbox" id="cbEpoc">
                        <label class="form-check-label ms-2" for="cbEpoc">EPOC</label>
                    </div>
                    <div class="form-check mb-3">
                        <input class="form-check-input" type="checkbox" id="cbAsma">
                        <label class="form-check-label ms-2" for="cbAsma">Asma</label>
                    </div>
                    <div class="form-check mb-3">
                        <input class="form-check-input" type="checkbox" id="cbBronquiectasias">
                        <label class="form-check-label ms-2" for="cbTabaquismo">Bronquiectasias</label>
                    </div>
                    <div class="form-check mb-3">
                        <input class="form-check-input" type="checkbox" id="cbEpd">
                        <label class="form-check-label ms-2" for="cbEpd">EPD</label>
                    </div>
                </div>

                
                <div class="col-md-6">
                    <div class="form-check mb-3">
                        <input class="form-check-input" type="checkbox" id="cbTuberprev">
                        <label class="form-check-label ms-2" for="cbTuberprev">Tuberculosis Previa</label>
                    </div>
                    <div class="form-check mb-3">
                        <input class="form-check-input" type="checkbox" id="cbCancerdepulmon">
                        <label class="form-check-label ms-2" for="cbCancerdepulmon">Cáncer de Pulmon</label>
                    </div>
                    <div class="form-check mb-3">
                        <input class="form-check-input" type="checkbox" id="cbVniDomicilia">
                        <label class="form-check-label ms-2" for="cbVniDomicilia">VNI domiciliaria</label>
                    </div>
                    <div class="form-check mb-3">
                        <input class="form-check-input" type="checkbox" id="cbOxigenoDomi">
                        <label class="form-check-label ms-2" for="cbOxigenoDomi">Oxígeno Domiciliario</label> 
                    </div>
                </div>

            </div> 
            </div>

        <div class="card bg-light text-black shadow p-4 rounded-3 mb-4">
            
             <div class="mb-4 text-primary-emphasis fw-semibold fs-5">Secuelas pulmonares:</div> 
            <div class="row">

                 <div class="col-md-6">
                     <div class="form-check mb-3">
                    <input class="form-check-input" type="checkbox" id="cbSecPosinfec">
                    <label class="form-check-label ms-2" for="cbSecPosinfec">Secuela postinfecciosas</label>
                         </div>
                     <div class="form-check mb-3">
                     <input class="form-check-input" type="checkbox" id="cbSecPosTrauma">
                     <label class="form-check-label ms-2" for="cbSecPosTrauma">Secuela postraumática</label>
                         </div>
                        </div>
                    
                
           
                <div class="col-md-6">
      <div class="form-check mb-3">
   <input class="form-check-input" type="checkbox" id="cbSecasdsa">
   <label class="form-check-label ms-2" for="cbSecPosinfec">Secuela post-TBC</label>
        </div>
    <div class="form-check mb-3">
    <input class="form-check-input" type="checkbox" id="cbSecPasdas">
    <label class="form-check-label ms-2" for="cbOtraResPulmonar">Otra resección pulmonar</label>
        </div>
       </div>
        </div>
        </div>
        
        
        <div class="card bg-light text-black shadow p-4 rounded-3 mb-4">
            
                  <div class="mb-4 text-primary-emphasis fw-semibold fs-5">Cirugía torácica previa:</div> 
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
        
        <div class="card bg-light text-black shadow p-4 rounded-3 mb-4">
         <div class="mb-4 text-primary-emphasis fw-semibold fs-5">Tabaquismo:</div> 
<div class="row">

     <div class="col-md-6">
         <div class="form-check mb-3">
        <input class="form-check-input" type="radio" name="TipodeFumadores" id="cbNuncafumo">
        <label class="form-check-label ms-2" for="radioNuncafumo">Nunca fumó</label>
             </div>
        
         <div class="form-check mb-3">
         <input class="form-check-input" type="radio" name="TipodeFumadores" id="radioExfumador">
         <label class="form-check-label ms-2" for="radioExfumador">Exfumador</label>
             </div>
            <div class="d-flex align-items-center gap-3 mb-3">
             
<input class="form-check-input" type="radio" name="TipodeFumadores" id="RadioFumadoractivo">
<label class="form-check-label" for="RadioFumadoractivo">Fumador Activo</label> 
 
 <label for="txtPaquetesAnio" class="form-label text-danger-emphasis ms-3">Paquetes/año:</label>
 <asp:TextBox runat="server" Id="txtPaquetesAnio" CssClass="form-control" Style="width:100px;"/> 
        
    </div>
    
         </div>
        </div>
</div>
  
        <div class="card bg-light text-black shadow p-4 rounded-3 mb-4">
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

             <div class="card bg-light text-black shadow p-4 rounded-3 mb-4">
           <div class="mb-4 text-success-emphasis fw-semibold fs-5">Evolución respitoria:</div> 
              
                 <div class="mb-3">
     
       <label for="txtInsufRes" class="form-label">¿Tuvo insuficiencia respiratoria?</label>
       <asp:DropDownList ID="ddlInsRespiratoria" runat="server" CssClass="form-select" Style="max-width: 300px;">
     <asp:ListItem Text="Seleccione una opción." Value="" />
 </asp:DropDownList>  
</div>

       <div class="mb-3">
       <label for="txtInsufRes" class="form-label">¿Requirió soporte?</label>
       <asp:DropDownList ID="ddlSoporte" runat="server" CssClass="form-select" Style="max-width: 300px;">
     <asp:ListItem Text="Seleccione una opción." Value="" />
 </asp:DropDownList>  
</div>
                 <div class="d-flex justify-content-between align-items-center mt-4 mb-5">
   
    <asp:Button ID="btnAtras" runat="server" Text="Atrás" OnClick="btnAtras_Click" CssClass="btn btn-outline-secondary px-4 fw-semibold" CausesValidation="false"/>
    
    
    <asp:Button ID="btnSiguiente" runat="server" Text="Siguiente" OnClick="btnSiguiente_Click"  CssClass="btn btn-success px-4 fw-semibold" />
</div>
        </div>
   
        
    
    
    
    
    
    
    </div>
    </div>
</asp:Content>
