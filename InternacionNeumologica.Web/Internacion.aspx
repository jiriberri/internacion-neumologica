<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Internacion.aspx.cs" Inherits="InternacionNeumologica.Web.Internacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="text-white text-center  mb-4">

<h1>Datos generales de la internación</h1>

</div> 


 <div class="row justify-content-center mt-5">

     <div class="col-md-5">

         <div class="card bg-white text-black shadow h-100">



        <div class="mb-3">
        <label for="txtFechaIngreso" class="form-label text-primary-emphasis">Fecha ingreso:</label>
        <asp:TextBox runat="server" Id="txtFechaIngreso" TextMode="Date" CssClass="form-control"/> 
        
    
    </div>
   
    
    
           <div class="mb-4">
            
              <label for="txtEgreso" class="form-label text-primary-emphasis">Fecha egreso:</label>
             <asp:TextBox runat="server" Id="txtFechadeEgreso" TextMode="Date" CssClass="form-control"/> 
           
       </div>
     


      
           <div class="mb-3">
             
              <label for="txtOrigen" class="form-label text-primary-emphasis">Origen:</label>
              <asp:DropDownList ID="ddlOrigen" runat="server" CssClass="form-select">
            <asp:ListItem Text="Seleccione una opción." Value="" />
        </asp:DropDownList>
         
       </div>
     



        
           <div class="mb-3">
             
              <label for="txtDestinoEgreso" class="form-label text-primary-emphasis">Destino al egreso:</label>
              <asp:DropDownList ID="ddlDestinoEgreso" runat="server" CssClass="form-select">
            <asp:ListItem Text="Seleccione una opción." Value="" />
        </asp:DropDownList>
          
       </div>
   

             
           <div class="mb-3">
            
              <label for="txtMotivoInternacion" class="form-label text-primary-emphasis">Motivo Principal de Internación:</label>
              <asp:DropDownList ID="ddlMotivoInter" runat="server" CssClass="form-select">
            <asp:ListItem Text="Seleccione una opción." Value="" />
        </asp:DropDownList>
          
       </div> 

                  <div class="mb-3">
     
      <label for="txtOrigen" class="form-label text-primary-emphasis">Infecciones:</label>
      <asp:DropDownList ID="ddlInfrecciones" runat="server" CssClass="form-select">
    <asp:ListItem Text="Seleccione una opción." Value="" />
</asp:DropDownList>
   </div>

                            <div class="mb-3">
      
       <label for="txtOrigen" class="form-label text-primary-emphasis">Obstrucciones:</label>
       <asp:DropDownList ID="ddlObtrucciones" runat="server" CssClass="form-select">
     <asp:ListItem Text="Seleccione una opción." Value="" />
 </asp:DropDownList>
</div>

</div>
</div> 
 




     <div class="col-md-5">

         <div class="card bg-white text-black shadow h-100">

    
      
           <div class="mb-3">
             
              <label for="txtOrigen" class="form-label text-primary-emphasis">Intersticiales:</label>
              <asp:DropDownList ID="ddlIntersticiales" runat="server" CssClass="form-select">
            <asp:ListItem Text="Seleccione una opción." Value="" />
        </asp:DropDownList>
         
       </div>
     



        
           <div class="mb-3">
             
              <label for="txtDestinoEgreso" class="form-label text-primary-emphasis">Pleura:</label>
              <asp:DropDownList ID="ddlPleura" runat="server" CssClass="form-select">
            <asp:ListItem Text="Seleccione una opción." Value=""/>
        </asp:DropDownList>
          
       </div>
   

             
           <div class="mb-3">
            
              <label for="txtMotivoInternacion" class="form-label text-primary-emphasis">Vascualares:</label>
              <asp:DropDownList ID="ddlVasculares" runat="server" CssClass="form-select">
            <asp:ListItem Text="Seleccione una opción." Value="" />
        </asp:DropDownList>
           
       </div>


    <div class="mb-3">
     
       <label for="txtMotivoInternacion" class="form-label text-primary-emphasis">Oncológicas:</label>
       <asp:DropDownList ID="ddlOncologicas" runat="server" CssClass="form-select">
     <asp:ListItem Text="Seleccione una opción." Value="" />
 </asp:DropDownList>
    
</div>

     <div class="mb-3">
     
       <label for="txtMotivoInternacion" class="form-label text-primary-emphasis">Otros:</label>
       <asp:DropDownList ID="ddlOtros" runat="server" CssClass="form-select">
     <asp:ListItem Text="Seleccione una opción." Value="" />
 </asp:DropDownList>  
</div>

<div class="mt-auto pt-3 d-flex justify-content-between">
    
    <asp:Button Text="Atras" ID="btnInactivar" CssClass="btn btn-danger" runat="server" />
    <asp:Button Text="Prueba" ID="Prueba" CssClass="btn btn-warning" runat="server" />
    <asp:Button Text="Siguiente" ID="btnSiguiente" CssClass="btn btn-success" runat="server"/>    
     </div> 
    </div>

</div>
</div> 
















</asp:Content>
