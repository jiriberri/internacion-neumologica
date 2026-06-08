<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Internacion.aspx.cs" Inherits="InternacionNeumologica.Web.Internacion" %>
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
<div class="text-white mb-1">
<h2>Datos generales de la internación</h2>

 <p class="text-secondary">
     Registro de nuevo ingreso y motivos de internación neumológica.
 </p>
</div> 
</div>

 
    <div class="row g-3">
    <div class="col-lg-6">

         <div class="card card-filtro h-100">
            <div class="card-body">
                <div class="titulo-card">Tiempos de Internación</div>

        <div class="mb-3">
        <label for="txtFechaIngreso" class="mb-1">Fecha ingreso</label>
        <asp:TextBox runat="server" Id="txtFechaIngreso" TextMode="Date" CssClass="form-control"/> 
    
    </div>
   
    
    
           <div class="mb-2">
            
              <label for="txtEgreso" class="mb-1">Fecha egreso</label>
             <asp:TextBox runat="server" Id="txtFechadeEgreso" TextMode="Date" CssClass="form-control"/> 
           
       </div>
     
</div>
        </div>
      </div>
           
     

           
        <div class="col-lg-6">

     <div class="card card-filtro h-100">

         <div class="card-body">

             <div class="titulo-card">Destinos</div>
             
             <div class="mb-3">
              <label for="txtOrigen" class="mb-1">Origen</label>
              <asp:DropDownList ID="ddlOrigen" runat="server" CssClass="form-select">
            <asp:ListItem Text="Seleccione una opción." Value="" />
        </asp:DropDownList>
         
                 </div>
       
        
           <div class="mb-2">
             
              <label for="txtDestinoEgreso" class="mb-1">Destino egreso</label>
              <asp:DropDownList ID="ddlDestinoEgreso" runat="server" CssClass="form-select">
            <asp:ListItem Text="Seleccione una opción." Value="" />
        </asp:DropDownList>
     </div>     
       </div>         
       </div>
          
          </div>
           </div>

    
    
    
    
    
    
    <div class="text-center mt-4 mb-3">

<h4 class="text-white">Motivo Principal de Internación</h4>

</div> 
         
     <div class="row g-3">
<div class="col-lg-6">

     <div class="card card-filtro h-100">
        <div class="card-body">

     <div class="mb-3">
     
      <label for="txtInfecciones" class="mb-1">Infecciones</label>
      <asp:DropDownList ID="ddlInfrecciones" runat="server" CssClass="form-select">
    <asp:ListItem Text="Seleccione una opción." Value="" />
</asp:DropDownList>
   </div>

                            <div class="mb-3">
      
       <label for="txtObstrucciones" class="mb-1">Obstrucciones</label>
       <asp:DropDownList ID="ddlObtrucciones" runat="server" CssClass="form-select">
     <asp:ListItem Text="Seleccione una opción." Value="" />
 </asp:DropDownList>
</div>


           <div class="mb-3">
             
              <label for="txtIntersticiales" class="mb-1">Intersticiales</label>
              <asp:DropDownList ID="ddlIntersticiales" runat="server" CssClass="form-select">
            <asp:ListItem Text="Seleccione una opción." Value="" />
        </asp:DropDownList>
         
       </div>
     

        
           <div class="mb-3">
             
              <label for="txtPleura" class="mb-1">Pleura</label>
              <asp:DropDownList ID="ddlPleura" runat="server" CssClass="form-select">
            <asp:ListItem Text="Seleccione una opción." Value=""/>
        </asp:DropDownList>
          
       </div>
   
</div>
</div> 
          
    </div>
         



       <div class="col-lg-6">

<div class="card card-filtro h-100">

    <div class="card-body">

   
             
           <div class="mb-3">
            
              <label for="txtVasculares" class="mb-1">Vasculares</label>
              <asp:DropDownList ID="ddlVasculares" runat="server" CssClass="form-select">
            <asp:ListItem Text="Seleccione una opción." Value="" />
        </asp:DropDownList>
           
       </div>


    <div class="mb-3">
     
       <label for="txtOncologicas" class="mb-1">Oncológicas</label>
       <asp:DropDownList ID="ddlOncologicas" runat="server" CssClass="form-select">
     <asp:ListItem Text="Seleccione una opción." Value="" />
 </asp:DropDownList>
    
</div>

     <div class="mb-3">
     
       <label for="txtOtros" class="mb-1">Otros</label>
       <asp:DropDownList ID="ddlOtros" runat="server" CssClass="form-select">
     <asp:ListItem Text="Seleccione una opción." Value="" />
 </asp:DropDownList>  
</div>

<div class="mt-auto pt-3 d-flex justify-content-around">
    
    <asp:Button Text="Atras" ID="btnAtras" CssClass="btn btn-outline-secondary px-4 fw-semibold" runat="server" OnClick="btnAtras_Click" CausesValidation="false" />
    <asp:Button Text="Siguiente" ID="btnSiguiente" CssClass="btn btn-success px-4 fw-semibold" OnClick="btnSiguiente_Click" runat="server"/>    
   
    </div> 
    </div>
    

</div> 
    </div>
</div>
</div>




</asp:Content>
