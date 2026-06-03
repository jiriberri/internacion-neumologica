<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Comorbilidades.aspx.cs" Inherits="InternacionNeumologica.Web.Comorbilidades" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="text-white text-center mb-3">
    <h1>Comorbilidades</h1>
</div> 

    <div class="row justify-content-center mt-10">
    <div class="col-md-5">

           <div class="card bg-light text-black shadow p-3 rounded-4 mb-3">

                <div class="mb-4 text-primary-emphasis fw-semibold text-center fs-5">Cardiovasculares</div> 

<div class="row">
       
    
    <div class="col-md-6">
    <div class="form-check mb-3">
        <input class="form-check-input" type="checkbox" id="cbHarterial">
        <label class="form-check-label ms-2" for="cbHarterial">Hipertensión arterial</label>
    </div>
    <div class="form-check mb-3">
        <input class="form-check-input" type="checkbox" id="cbInsuCardi">
        <label class="form-check-label ms-2" for="cbInsucardi">Insuficiencia cardíaca</label>
    </div>
    <div class="form-check mb-3">
        <input class="form-check-input" type="checkbox" id="cbFibriAuricu">
        <label class="form-check-label ms-2" for="cbFibriAuricu">Fibrilación auricular</label>
    </div>
</div>  

               
                <div class="col-md-6">
                   <div class="form-check mb-3">
    <input class="form-check-input" type="checkbox" id="cbCardioIsquem">
    <label class="form-check-label ms-2" for="cbCardioIsquem">Cardiopatía isquémica</label>
                  </div>
                    <div class="form-check mb-3">
                        <input class="form-check-input" type="checkbox" id="cbHPulmonar">
                        <label class="form-check-label ms-2" for="cbHPulmonar">Hipertensión pulmonar</label>
                    </div>
                    <div class="form-check mb-3">
                        <input class="form-check-input" type="checkbox" id="cbTEPprevio">
                        <label class="form-check-label ms-2" for="cbTEPprevio">TEP previo</label>
                    </div>
                   
                </div>


              </div>
               
           </div>
       
        
    
    
    
    
    
               <div class="card bg-light text-black shadow p-1 rounded-4 mb-3">

                <div class="mb-4 text-primary-emphasis fw-semibold text-center fs-5">Metabólicas</div> 

<div class="row">
    
    
    <div class="col-md-6">
<div class="form-check mb-3">
    <input class="form-check-input" type="checkbox" id="cbDiabetes">
    <label class="form-check-label ms-2" for="cbDiabetes">Diabetes</label>
</div>
    

    
    </div>
     



<div class="col-md-6">
   <div class="form-check mb-3">
       <input class="form-check-input" type="checkbox" id="cbObesidad">
<label class="form-check-label ms-2" for="cbObesidad">Obesidad</label>
   
   </div>
    </div>

</div>
 
               
               
               </div>
    


                       <div class="card bg-light text-black shadow p-1 rounded-4 mb-3">

                <div class="mb-4 text-primary-emphasis fw-semibold text-center fs-5">Sueño</div> 

<div class="row">
    
    
    <div class="col-md-6">
<div class="form-check mb-3">
    <input class="form-check-input" type="checkbox" id="cbACVprevio">
    <label class="form-check-label ms-2" for="cbACVprevio">ACV previo</label>
</div>
    

    
    </div>
     



<div class="col-md-6">
   <div class="form-check mb-3">
       <input class="form-check-input" type="checkbox" id="cbEnferNeuromuscu">
<label class="form-check-label ms-2" for="cbEnferNeuromuscu">Enfermedad neuromuscular</label>
   
   </div>
    </div>

</div>
 
               
               
               </div>




                       <div class="card bg-light text-black shadow p-4 rounded-4 mb-3">

                <div class="mb-4 text-primary-emphasis fw-semibold text-center fs-5">Inmunológicas</div> 

<div class="row">
    
    
    <div class="col-md-4">
<div class="form-check mb-2">
    <input class="form-check-input" type="checkbox" id="cbEnfReumatolog">
    <label class="form-check-label ms-2" for="cbEnfReumatolog">Enfermedad reumatológica</label>
</div>
    </div>
     
        <div class="col-md-4">
<div class="form-check mb-2">
    <input class="form-check-input" type="checkbox" id="cbInmunosupri">
    <label class="form-check-label ms-2" for="cbInmunosupri">Inmunosuprimido</label>
</div>
    </div>


<div class="col-md-4">
   <div class="form-check mb-2">
       <input class="form-check-input" type="checkbox" id="cbHIV">
<label class="form-check-label ms-2" for="cbHIV">HIV</label>
   
   </div>
    </div>

</div>         
               </div>

                               <div class="card bg-light text-black shadow p-4 rounded-4 mb-3">

                <div class="mb-4 text-primary-emphasis fw-semibold text-center fs-5">Oncológicas</div> 

<div class="row">

        <div class="col-md-4">
<div class="form-check mb-2">
    <input class="form-check-input" type="checkbox" id="cbNeoExAc">
    <label class="form-check-label ms-2" for="cbNeoExAc">Neoplasia extrapulmonar activa</label>
</div>
    </div>

    <div class="d-grid gap-2 d-md-flex justify-content-md-end">
        <asp:Button Text="Atras" ID="btnAtras" CssClass="btn btn-outline-secondary px-4 fw-semibold" OnClick="btnAtras_Click" runat="server" CausesValidation="false"/>
        <asp:Button Text="Siguiente" ID="btnSiguiente" CssClass="btn btn-success px-4 fw-semibold" runat="server"/>
        

        </div>

   </div>
    </div>
    
    
   
    
    </div>
    </div> 
    

</asp:Content>
