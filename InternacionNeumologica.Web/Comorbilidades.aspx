<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Comorbilidades.aspx.cs" Inherits="InternacionNeumologica.Web.Comorbilidades" %>
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

<div class="text-white mb-3">
    <h1>Comorbilidades</h1>
</div> 

<div class="row g-3 mb-4">

    <div class="col-lg-6">
        <div class="card card-filtro h-100">
            <div class="card-body">
                
                <div class="mb-4 text-primary-emphasis fw-semibold text-center fs-5">Cardiovasculares</div> 
                
                <div class="row">
                    <% foreach (var car in ListaCardioVascular) { %>
    <div class="col-md-6 mb-3"> 
        <div class="form-check">
            <input class="form-check-input" type="checkbox" 
                   name="chkCardiovascular" 
                   value="<%Response.Write(car.Id);%>" 
                   id="chk_resp_<%Response.Write(car.Id);%>" />
            
            <label class="form-check-label" for="chk_resp_<%Response.Write(car.Id);%>">
                <%Response.Write(car.Descripcion);%> 
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
                
                <div class="mb-4 text-primary-emphasis fw-semibold text-center fs-5">Neurológicos / Otros</div> 
                
                           <div class="row">
                    <% foreach (var neu in ListaNeurologico) { %>
    <div class="col-md-6 mb-3"> 
        <div class="form-check">
            <input class="form-check-input" type="checkbox" 
                   name="chkNeurologico" 
                   value="<%Response.Write(neu.Id);%>" 
                   id="chk_resp_<%Response.Write(neu.Id);%>" />
            
            <label class="form-check-label" for="chk_resp_<%Response.Write(neu.Id);%>">
                <%Response.Write(neu.Descripcion);%> 
            </label>
        </div>
    </div>
<% } %>
                </div> 
            </div> 
        </div> 
    </div>

    </div> 
    <div class="row g-3 mb-4">
         <div class="col-lg-6"> 
             <div class="card card-filtro h-100"> 
                  <div class="card-body">
                      <div class="mb-4 text-primary-emphasis fw-semibold text-center fs-5">Metabolicas</div> 
                                                  <div class="row">
                    <% foreach (var met in ListaMetabolica) { %>
    <div class="col-md-6 mb-3"> 
        <div class="form-check">
            <input class="form-check-input" type="checkbox" 
                   name="chkMetabolica" 
                   value="<%Response.Write(met.Id);%>" 
                   id="chk_resp_<%Response.Write(met.Id);%>" />
            
            <label class="form-check-label" for="chk_resp_<%Response.Write(met.Id);%>">
                <%Response.Write(met.Descripcion);%> 
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
                      <div class="mb-4 text-primary-emphasis fw-semibold text-center fs-5">Sueño</div> 
                                                  <div class="row">
                    <% foreach (var sue in ListaSueño) { %>
    <div class="col-md-6 mb-3"> 
        <div class="form-check">
            <input class="form-check-input" type="checkbox" 
                   name="chkSueño" 
                   value="<%Response.Write(sue.Id);%>" 
                   id="chk_resp_<%Response.Write(sue.Id);%>" />
            
            <label class="form-check-label" for="chk_resp_<%Response.Write(sue.Id);%>">
                <%Response.Write(sue.Descripcion);%> 
            </label>
        </div>
    </div>
<% } %>
                </div> 
                      
                  
                  </div>
                  </div>
             </div>    
    </div>



 <div class="row g-3 mb-4">

    <div class="col-lg-6">
        <div class="card card-filtro h-100">
            <div class="card-body">
                
                <div class="mb-4 text-primary-emphasis fw-semibold text-center fs-5">Inmunológicas</div> 
                
                                                                <div class="row">
                    <% foreach (var inm in ListaInmunologica) { %>
    <div class="col-md-6 mb-3"> 
        <div class="form-check">
            <input class="form-check-input" type="checkbox" 
                   name="chkInmunologica" 
                   value="<%Response.Write(inm.Id);%>" 
                   id="chk_resp_<%Response.Write(inm.Id);%>" />
            
            <label class="form-check-label" for="chk_resp_<%Response.Write(inm.Id);%>">
                <%Response.Write(inm.Descripcion);%> 
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
                
                <div class="mb-4 text-primary-emphasis fw-semibold text-center fs-5">Oncológicas</div> 
                
                                                                                <div class="row">
                    <% foreach (var onc in ListaOncologica) { %>
    <div class="col-md-6 mb-3"> 
        <div class="form-check">
            <input class="form-check-input" type="checkbox" 
                   name="chkOncologica" 
                   value="<%Response.Write(onc.Id);%>" 
                   id="chk_resp_<%Response.Write(onc.Id);%>" />
            
            <label class="form-check-label" for="chk_resp_<%Response.Write(onc.Id);%>">
                <%Response.Write(onc.Descripcion);%> 
            </label>
        </div>
    </div>
<% } %>
                </div> <div class="text-center mt-4 mb-5 d-flex justify-content-center gap-3">
    <asp:Button Text="Atras" ID="btnAtras" CssClass="btn btn-outline-secondary px-4 fw-semibold" OnClick="btnAtras_Click" runat="server" CausesValidation="false"/>
    <asp:Button Text="Guardar" ID="btnSiguiente" CssClass="btn btn-success px-4 fw-semibold" OnClick="btnGuardar_Click" runat="server"/>
</div>
                        
                    </div>
                </div>

            </div>
        </div>
   
 
</asp:Content>
