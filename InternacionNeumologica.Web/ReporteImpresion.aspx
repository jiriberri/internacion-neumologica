<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="ReporteImpresion.aspx.cs"
    Inherits="InternacionNeumologica.Web.ReporteImpresion" %>

<!DOCTYPE html>

<html>

<head runat="server">

    <title>Reporte de Internaciones</title>

    <style>
        body {
            font-family: Arial;
            margin: 40px;
        }

        h1 {
            text-align: center;
        }

        h3 {
            margin-top: 30px;
            border-bottom: solid 1px gray;
            padding-bottom: 5px;
        }

        table {
            width: 100%;
            border-collapse: collapse;
        }

        th, td {
            border: solid 1px #ccc;
            padding: 6px;
            font-size: 12px;
        }

        th {
            background: #efefef;
        }
    </style>

</head>

<body>

    <form id="form1" runat="server">

        <h1>Servicio de Clínica Neumonológica
        </h1>

        <h2 style="text-align: center">Reporte de Internaciones
        </h2>

        <p>
            Fecha de emisión:

            <%= DateTime.Now.ToString("dd/MM/yyyy HH:mm") %>
        </p>

        <h3>Filtros aplicados
        </h3>

        <asp:Literal
            ID="litFiltros"
            runat="server" />

        <h3>Comorbilidades seleccionadas
        </h3>

        <asp:Literal
            ID="litComorbilidades"
            runat="server" />

        <h3>Resultado de la consulta
        </h3>

        <asp:GridView
            ID="gvDetalle"
            runat="server"
            AutoGenerateColumns="true"
            Width="100%" />

    </form>

</body>

</html>
