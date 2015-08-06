<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetalleSolicitud.aspx.cs" Inherits="WorkflowSolicitudes.Presentacion.DetalleSolicitud" %>


<head runat="server">
    <title></title>

    <style>
body {
    background: #B2E389;
}
        .table-bordered
        {
            margin-left: 0px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Panel ID="Panel1" runat="server" Height="174px" style="margin-left: 239px" 
            Width="812px">
            <table>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        Folio
                    </td>
                    <td>
                        <asp:Label ID="lblFolio" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Tipo de Solicitud</td>
                    <td>
                        <asp:Label ID="LblDesctipoSolicitud" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            <br />
            <br />
            <asp:GridView ID="GridView1" CssClass="table table-hover table-bordered" 
                runat="server" AutoGenerateColumns="False" 
                BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
                CellPadding="3" GridLines="Vertical" ForeColor="Black" 
                emptydatatext="No existen datos para la consulta realizada" 
                Font-Bold="False" Width="883px">

            <emptydatarowstyle backcolor="#B2E389" forecolor="Red"/>
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                    <asp:BoundField DataField="intFolioSolicitudes" HeaderText="Folio" 
                        SortExpression="intFolioSolicitudes" />
                    <asp:BoundField DataField="intSecuencia" HeaderText="Secuencia" 
                        SortExpression="intSecuencia" />
                    <asp:BoundField DataField="strGlosaActividad" HeaderText="Actividad" 
                        SortExpression="strGlosaActividad" />
                    <asp:BoundField DataField="strDescUnidad" HeaderText="Unidad Responsable" 
                        SortExpression="strDescUnidad" />
                    <asp:BoundField DataField="strnombre" HeaderText="Persona asignada" 
                        SortExpression="strnombre" />
                    <asp:BoundField DataField="dtmFechaVencSol" HeaderText="Fecha Vencimiento Actividad" 
                        SortExpression="dtmFechaVencSol" />
                    <asp:BoundField DataField="intDiasDeRetraso" HeaderText="Dias de Atraso" 
                        SortExpression="intDiasDeRetraso" />
                    <asp:BoundField DataField="strGlosaEstado" HeaderText="Estado" 
                        SortExpression="strGlosaEstado" />
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
                NavigateUrl="~/Presentacion/BandejaEntrada.aspx">Volver</asp:HyperLink>
        </asp:Panel>
    
    </div>
    </form>
</body>