<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="InternacionNeumologica.Web.Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row justify-content-center mt-5">
        <div class="col-md-8 col-lg-6">
            
            <div class="card bg-dark text-white border-danger border-2 shadow-lg">
                <div class="card-body p-5 text-center">
                    
                    <h2 class="text-danger fw-bold mb-4">⚠️ Ocurrió un Error en el Sistema</h2>
                    
                    <p class="text text-light fs-5 bg-black p-3 rounded font-monospace border border-secondary text-start" style="max-height: 250px; overflow-y: auto;">
                        <asp:Label ID="lblMensajeError" runat="server" />
                    </p>

                    <div class="d-grid gap-2 mt-4">
                        <asp:HyperLink 
                            ID="hlVolver" 
                            runat="server" 
                            NavigateUrl="/Default.aspx" 
                            CssClass="btn btn-outline-danger fw-semibold">
                            Volver al Panel de Inicio
                        </asp:HyperLink>
                    </div>

                </div>
            </div>

        </div>
    </div>
</asp:Content>
