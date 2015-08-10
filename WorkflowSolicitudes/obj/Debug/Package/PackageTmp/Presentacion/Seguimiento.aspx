<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Seguimiento.aspx.cs" Inherits="WorkflowSolicitudes.Presentacion.Seguimiento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <title></title>

    <style type="text/css">
        .style1
        {
            width: 134px;
        }
    </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1">
    <div>
    
        <asp:Panel ID="Panel1" runat="server" Height="176px" style="margin-left: 10px" 
            Width="853px">
            <table>
                <tr>
                    <td class="style1">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style1">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style1" >
                        Folio :</td>
                    <td>
                        <asp:Label ID="lblFolio" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        Tipo de Solicitud :</td>
                    <td>
                        <asp:Label ID="LblDesctipoSolicitud" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            <br />
            <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
                CellPadding="3" GridLines="Vertical" ForeColor="Black" 
                Height="16px" style="margin-left: 0px" Width="1235px" 
                DataKeyNames="intSecuencia"
                onsorting="GridView1_Sorting" onselectedindexchanged="GridView1_SelectedIndexChanged" 
                emptydatatext="No existen datos para la consulta realizada" 
                Font-Bold="False">

            <emptydatarowstyle backcolor="#B2E389" forecolor="Red"/>
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                    <asp:BoundField DataField="intFolioSolicitudes" HeaderText="Folio" 
                        SortExpression="intFolioSolicitudes" />
                    <asp:BoundField DataField="intEtapa" HeaderText="Etapa" 
                        SortExpression="intEtapa" />
                    <asp:BoundField DataField="intSecuencia" HeaderText="Secuencia" 
                        SortExpression="intSecuencia" />
                    <asp:BoundField DataField="strGlosaActividad" HeaderText="Actividad" 
                        SortExpression="strGlosaActividad" />
                    <asp:BoundField DataField="strDescUnidad" HeaderText="Unidad Responsable" 
                        SortExpression="strDescUnidad" />
                    <asp:BoundField DataField="strnombre" HeaderText="Persona Asignada" 
                        SortExpression="strnombre" />
                    <asp:BoundField DataField="StrGlosaDetalleSolictud" HeaderText="Observación " 
                        SortExpression="StrGlosaDetalleSolictud" />
                    <asp:BoundField DataField="DtmFechaRecep" HeaderText="Fecha Recepción" 
                        SortExpression="DtmFechaRecep" />
                    <asp:BoundField DataField="DtmFechaEjecutaActividad" 
                        HeaderText="Fecha Ejecución Actividad" 
                        SortExpression="DtmFechaEjecutaActividad" />
                    <asp:BoundField DataField="intDiasDeRetraso" HeaderText="Dias de Atraso" 
                        SortExpression="intDiasDeRetraso" />
                    <asp:BoundField DataField="dtmFechaVencSol" HeaderText="Fecha Vencimiento" 
                        SortExpression="dtmFechaVencSol" />
                    <asp:BoundField DataField="DtmFechaResolucion" HeaderText="Fecha Resolución" 
                        SortExpression="DtmFechaResolucion" />
                    <asp:BoundField DataField="strGlosaEstado" HeaderText="Estado" 
                        SortExpression="strGlosaEstado" />
                    <asp:ButtonField ButtonType="Image" CommandName="Select" 
                        HeaderText="Ver Archivos" ImageUrl="~/imagenes/adjuntar.png" ShowHeader="True" 
                        Text="Botón" />
                </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#808080" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>
            <br />
            <br />
            <br />
            <br />
            <asp:HyperLink ID="HyperLink1" runat="server" 
                NavigateUrl="~/Presentacion/ConsultaSolicitudes.aspx">Volver</asp:HyperLink>
        </asp:Panel>
    
    </div>
    </form>

</asp:Content>
