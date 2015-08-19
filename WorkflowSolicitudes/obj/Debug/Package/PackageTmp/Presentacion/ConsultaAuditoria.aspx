<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsultaAuditoria.aspx.cs" Inherits="WorkflowSolicitudes.Presentacion.ConsultaAuditoria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
 <link href="../css/alertify.core.css" rel="stylesheet" type="text/css" />
 <link href="../css/alertify.default.css" rel="stylesheet" type="text/css" id="toggleCSS" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


<script type='text/javascript'>
    function ir() {
        window.open("BuscadorPersonas.aspx", null, "height=600,width=500,status=yes,toolbar=no,menubar=no,location=no,titlebar=no, resizable = off");
    } 
        </script>


<div class="container">

<div class ="row-fluid">
<div class ="span12"><h3 class="text-center">Consulta Auditoria de Sistema</h3></div>
</div>

<div class ="row-fluid">
<div class ="span12"><asp:Label ID="lblAcceso" runat="server"></asp:Label></div>
</div>

<div class ="row-fluid">
<div class ="span4"><p class="text-left">Rut Usuario:</p></div>
<div class ="span4"><asp:TextBox ID="txtRutUsuario" runat="server" Height="22px"></asp:TextBox><asp:ImageButton ID="btnBuscarPersona" runat="server" Height="22px" OnClientClick="ir();"
                        ImageUrl="~/imagenes/icono_buscar.gif" /></div>
<div class ="span4"></div>
</div>

<div class ="row-fluid">
<div class ="span4"><p class="text-left">IP:</p></div>
<div class ="span4"><asp:TextBox ID="txtIP" runat="server"></asp:TextBox></div>
<div class ="span4"></div>
</div>

<div class ="row-fluid">
<div class ="span4"><p class="text-left">Dispositivo:</p></div>
<div class ="span4"><asp:DropDownList ID="ddlDispositivo" runat="server" Height="22px">
                    </asp:DropDownList></div>
<div class ="span4"></div>
</div>


<div class ="row-fluid">
<div class ="span2"><p class="text-left">Fecha Desde:</p></div>
<div class ="span2"><asp:TextBox ID="txtFechaDesde" runat="server" Height="22px" Width="90px"></asp:TextBox>
                    <asp:ImageButton ID="ImagenCalendario1" runat="server" Height="30px" 
                        ImageUrl="~/imagenes/calendario.gif" onclick="ImagenCalendario1_Click" 
                        Width="30px" /></div>
<div class ="span2"><asp:Calendar ID="Calendar1" runat="server" BackColor="White" 
                        BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" 
                        DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" 
                        ForeColor="#003399" Height="25px" 
                        onselectionchanged="Calendar1_SelectionChanged" Width="16px">
                        <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                        <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                        <OtherMonthDayStyle ForeColor="#999999" />
                        <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                        <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                        <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" 
                            Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                        <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                        <WeekendDayStyle BackColor="#CCCCFF" />
                    </asp:Calendar></div>
<div class ="span2"><p class="text-left">Fecha Hasta:</p></div>
<div class ="span2"><asp:TextBox ID="txtFechaHasta" runat="server" Height="22px" Width="90px"></asp:TextBox>
                    <asp:ImageButton ID="ImagenCalendario2" runat="server" Height="30px" 
                        ImageUrl="~/imagenes/calendario.gif" onclick="ImagenCalendario2_Click" 
                        Width="30px" /></div>
<div class ="span2"><asp:Calendar ID="Calendar2" runat="server" BackColor="White" 
                        BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" 
                        DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" 
                        ForeColor="#003399" Height="16px" 
                        onselectionchanged="Calendar2_SelectionChanged" Width="25px" 
                        Visible="False">
                        <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                        <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                        <OtherMonthDayStyle ForeColor="#999999" />
                        <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                        <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                        <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" 
                            Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                        <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                        <WeekendDayStyle BackColor="#CCCCFF" />
                    </asp:Calendar></div>
</div>


<div class ="row-fluid">
<div class ="span12"><asp:ImageButton ID="btnBuscar" runat="server" 
                        ImageUrl="~/imagenes/icono_buscar.gif" onclick="btnBuscar_Click" /></div>
</div>

    <div class ="row-fluid">
<div class ="span12">
    <asp:GridView ID="grvConsultaAuditoria" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
            CellPadding="10" ForeColor="Black" GridLines="Vertical" Height="122px" 
            Width="1158px" 
            onselectedindexchanged="grvConsultaAuditoria_SelectedIndexChanged"
            emptydatatext="No existen datos para la consulta realizada" 
        Font-Bold="False" 
        onpageindexchanging="grvConsultaAuditoria_PageIndexChanging1">

            <emptydatarowstyle backcolor="#B2E389" forecolor="Red"/>

            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
            <asp:BoundField HeaderText="Rut" DataField="strRutUsuario" 
                SortExpression="strRutUsuario" />
                <asp:BoundField DataField="dtmFecha" HeaderText="Fecha" />
            <asp:BoundField HeaderText="Nombre" DataField="strNombreUsuario" 
                SortExpression="strNombreUsuario" />
            <asp:BoundField HeaderText="IP" DataField="strIp" SortExpression="strIp" />
            <asp:BoundField HeaderText="Modulo" DataField="strModulo" 
                SortExpression="strModulo" />
            <asp:BoundField HeaderText="Accion" DataField="strAccion" 
                SortExpression="strAccion" />
            <asp:BoundField HeaderText="Observacion" DataField="strObservacion" 
                SortExpression="strObservacion" />
            <asp:BoundField HeaderText="Dispositivo" DataField="strDispositivo" 
                SortExpression="strDispositivo" />
            <asp:BoundField HeaderText="Nombre Maquina" DataField="strNombreMaquina" 
                SortExpression="strNombreMaquina" />
            <asp:BoundField HeaderText="MAC Adresss" DataField="strMacaddress" 
                SortExpression="strMacaddress" />
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

<div class ="row-fluid">
<div class ="span12"></div>
</div>

<div class ="row-fluid">
<div class ="span12"><p class="text-left">Exportar a Excel:</p><asp:ImageButton ID="btnExcel" runat="server" 
                       onclick="btnExcel_Click" ImageUrl="~/imagenes/icon-excel.gif" /></div>
</div>

<div class ="row-fluid">
<div class ="span12">
<asp:Label ID="lblError" runat="server" style="color: #FF0000; font-weight: 700" ></asp:Label></div>
</div>

</div>
   
            
</asp:Content>
