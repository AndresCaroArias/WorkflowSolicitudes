<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaDeTareas.aspx.cs" Inherits="WorkflowSolicitudes.Presentacion.ListaDeTareas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

<link href="../css/alertify.core.css" rel="stylesheet" type="text/css" />
<link href="../css/alertify.default.css" rel="stylesheet" type="text/css" id="toggleCSS" />


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div class="container">

<div class ="row-fluid">
<div class ="span12"><h3 class="text-center">Bandeja de tareas pendientes</h3></div>
</div>


<div class ="row-fluid">
<div class ="span12"><asp:Label ID="lblAcceso" runat="server" style="font-size: small"></asp:Label></div>
</div>

<div class ="row-fluid">
<div class ="span12"><asp:Label ID="lblMensaje" runat="server"></asp:Label>
        <br />
        <asp:GridView ID="GrvListaTareas" runat="server" AllowPaging="True" 
            AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" 
            BorderStyle="Solid" BorderWidth="1px" CellPadding="3" 
            DataKeyNames="IntFolioSolicitud,IntSecuencia" ForeColor="Black" 
            GridLines="Vertical" 
            onselectedindexchanged="GrvListaTareas_SelectedIndexChanged" 
            onpageindexchanging="GrvListaTareas_PageIndexChanging" 
            onrowdatabound="GrvListaTareas_RowDataBound"
            emptydatatext="No existen datos para la consulta realizada" 
        Font-Bold="False">

            <emptydatarowstyle backcolor="#B2E389" forecolor="Red"/>

            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
                <asp:CommandField ButtonType="Image" HeaderText="Seleccionar" 
                    SelectImageUrl="~/imagenes/editar.gif" ShowHeader="True" 
                    ShowSelectButton="True" />
                <asp:BoundField DataField="IntFolioSolicitud" HeaderText="Folio" 
                    SortExpression="IntFolioSolicitud" />
                <asp:BoundField DataField="StrDesSolicitud" HeaderText="Tipo Solicitud" 
                    SortExpression="StrDesSolicitud" />
                <asp:BoundField DataField="DtmFechaSolicitud" HeaderText="Fecha Solicitud" 
                    SortExpression="DtmFechaSolicitud" />
                <asp:BoundField DataField="IntSecuencia" HeaderText="Secuencia" 
                    SortExpression="IntSecuencia" />
                <asp:BoundField DataField="StrDesActividad" HeaderText="Actividad" 
                    SortExpression="StrDesActividad" />
                <asp:BoundField DataField="DtmFechaVencimiento" HeaderText="Fecha Vencimiento" 
                    SortExpression="DtmFechaVencimiento" />
                <asp:BoundField DataField="IntDiasAtraso" HeaderText="Dias Atraso" 
                    SortExpression="IntDiasAtraso" />
                <asp:BoundField DataField="StrDescEstado" HeaderText="Estado" 
                    SortExpression="StrDescEstado" />
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView></div>
</div>

</div>
   
</asp:Content>
