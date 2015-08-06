<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsultaActividades.aspx.cs" Inherits="WorkflowSolicitudes.ConsultaActividad" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<link href="../css/alertify.core.css" rel="stylesheet" type="text/css" />
 <link href="../css/alertify.default.css" rel="stylesheet" type="text/css" id="toggleCSS" />

    
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


<div class="container">

<div class ="row-fluid">
<div class ="span12"><h3 class="text-center">Consulta Actividades</h3></div>
</div>

<div class ="row-fluid">

<div class ="span4"><p class="text-left">Tipo Solicitud:</p></div>

<div class ="span4"><asp:DropDownList ID="ddlTipoSolicitud" runat="server" Height="22px">
                </asp:DropDownList></div>

<div class ="span4"></div>
</div>

<div class ="row-fluid">

<div class ="span4"><p class="text-left">Tipo Actividad:</p>
</div>

<div class ="span4"><asp:DropDownList ID="ddlTipoActividad" runat="server" Height="22px"></asp:DropDownList>
</div>
<div class ="span4">
</div>
</div>
<div class ="row-fluid">
<div class ="span4"><p class="text-left">Unidades:</p></div>

<div class ="span4"><asp:DropDownList ID="ddlUnidad" runat="server" Width="95px" Height="22px"></asp:DropDownList></div>
<div class ="span4"></div>
</div>


<div class ="row-fluid">
<div class ="span3"><p class="text-left">Estado:</p></div>
<div class ="span3"><asp:DropDownList ID="ddlEstado" runat="server" Width="95px" Height="22px">
                </asp:DropDownList></div>
<div class ="span3"><asp:ImageButton ID="btnBuscar" runat="server" 
                    ImageUrl="~/imagenes/icono_buscar.gif" onclick="btnBuscar_Click" /></div>
<div class ="span3"><asp:Label ID="lblError" runat="server" style="color: #CC0000; background-color: #CCCCCC"></asp:Label></div>
</div>

<div class ="row-fluid">
<div class ="span2"><p class="text-left">Fecha Recep Desde:</p></div>
<div class ="span2"><asp:TextBox ID="txtFechaRecepcionDesde" runat="server" Width="90px" Height="22px"></asp:TextBox>
                <asp:ImageButton ID="ImagenCalendario1" runat="server" Height="16px" 
                    ImageUrl="~/imagenes/calendario.gif" onclick="ImagenCalendario1_Click" 
                    Width="16px" /></div>
<div class ="span2"><asp:Calendar ID="Calendar1" runat="server" BackColor="White" 
                    BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" 
                    DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" 
                    ForeColor="#003399" Height="16px" Width="16px" 
                    onselectionchanged="Calendar1_SelectionChanged">
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
<div class ="span2"><p class="text-left">Hasta:</p></div>
<div class ="span2"> <asp:TextBox ID="txtFechaRecepcionHasta" runat="server" Width="90px" Height="22px"></asp:TextBox>
                <asp:ImageButton ID="ImagenCalendario2" runat="server" Height="16px" 
                    ImageUrl="~/imagenes/calendario.gif" onclick="ImagenCalendario2_Click" 
                    Width="16px" /></div>
<div class ="span2"><asp:Calendar ID="Calendar2" runat="server" BackColor="White" 
                    BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" 
                    DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" 
                    ForeColor="#003399" Height="16px" Width="16px" 
                    onselectionchanged="Calendar2_SelectionChanged">
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
<div class ="span2"><p class="text-left">Fecha Ejec Desde:</p></div>
<div class ="span2"><asp:TextBox ID="txtFechaEjecDesde" runat="server" Width="90px" Height="22px"></asp:TextBox>
                <asp:ImageButton ID="ImagenCalendario3" runat="server" Height="16px" 
                    ImageUrl="~/imagenes/calendario.gif" onclick="ImagenCalendario3_Click" 
                    Width="16px" /><asp:Calendar ID="Calendar3" runat="server" BackColor="White" 
                    BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" 
                    DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" 
                    ForeColor="#003399" Height="16px" Width="16px" 
                    onselectionchanged="Calendar3_SelectionChanged">
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
<div class ="span2"></div>
<div class ="span2"><p class="text-left">Hasta:</p></div>
<div class ="span2"><asp:TextBox ID="txtFechaEjecHasta" runat="server" Width="90px" Height="22px"></asp:TextBox>
                <asp:ImageButton ID="ImagenCalendario4" runat="server" Height="16px" 
                    ImageUrl="~/imagenes/calendario.gif" onclick="ImagenCalendario4_Click" 
                    Width="16px" /><asp:Calendar ID="Calendar4" runat="server" BackColor="White" 
                    BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" 
                    DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" 
                    ForeColor="#003399" Height="16px" Width="16px" 
                    onselectionchanged="Calendar4_SelectionChanged">
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
<div class ="span2"></div>
</div>

<div class ="row-fluid">
<div class ="span2"><p class="text-left">Fecha Resol desde:</p></div>
<div class ="span2"><asp:TextBox ID="txtFechaResolDesde" runat="server" Width="90px" Height="22px"></asp:TextBox>
                <asp:ImageButton ID="ImagenCalendario5" runat="server" Height="16px" 
                    ImageUrl="~/imagenes/calendario.gif" onclick="ImagenCalendario5_Click" 
                    Width="16px" /><asp:Calendar ID="Calendar5" runat="server" BackColor="White" 
                    BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" 
                    DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" 
                    ForeColor="#003399" Height="16px" Width="16px" 
                    onselectionchanged="Calendar5_SelectionChanged">
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
<div class ="span2"></div>
<div class ="span2"><p class="text-left">Hasta:</p></div>
<div class ="span2"><asp:TextBox ID="txtFechaResolHasta" runat="server" Width="90px" Height="22px"></asp:TextBox>
                <asp:ImageButton ID="ImagenCalendario6" runat="server" Height="16px" 
                    ImageUrl="~/imagenes/calendario.gif" onclick="ImagenCalendario6_Click" 
                    Width="16px" /></div>
<div class ="span2"><asp:Calendar ID="Calendar6" runat="server" BackColor="White" 
                    BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" 
                    DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" 
                    ForeColor="#003399" Height="16px" Width="16px" 
                    onselectionchanged="Calendar6_SelectionChanged">
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
<div class ="span12"></div>
</div>

<div class ="row-fluid">
<div class ="span12">
    <asp:GridView ID="grvConsultaActividad" runat="server" 
                    AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" 
                    BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" 
                    GridLines="Vertical" 
                     
                    onselectedindexchanged="grvConsultaActividad_SelectedIndexChanged" 
                    style="font-size: x-small" AllowPaging="True" 
                    onpageindexchanging="grvConsultaActividad_PageIndexChanging"
                    emptydatatext="No existen datos para la consulta realizada" 
        Font-Bold="False">

                    <emptydatarowstyle backcolor="#B2E389" forecolor="Red"/>
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                    <Columns>
                        <asp:BoundField DataField="strDescSolicitud" HeaderText="Solicitud" 
                            SortExpression="strDescSolicitud" />
                        <asp:BoundField DataField="strActividad" HeaderText="Actividad" 
                            SortExpression="strActividad" />
                        <asp:BoundField DataField="strDescUnidad" HeaderText="Unidad" 
                            SortExpression="strDescUnidad" />
                        <asp:BoundField DataField="strNombre" HeaderText="Nombre" 
                            SortExpression="strNombre" />
                        <asp:BoundField DataField="strDetalleSolicitud" HeaderText="Detalle" 
                            SortExpression="strDetalleSolicitud" />
                        <asp:BoundField DataField="strEstado" HeaderText="Estado" 
                            SortExpression="strEstado" />
                        <asp:BoundField DataField="dtmFechaRecepc" HeaderText="Fecha Recep" 
                            SortExpression="dtmFechaRecepc" />
                        <asp:BoundField DataField="dtmFechaEjecActi" HeaderText="Fecha Ejecucion Act" 
                            SortExpression="dtmFechaEjecActi" />
                        <asp:BoundField DataField="dtmFechaResolu" HeaderText="Fecha Resolucion" 
                            SortExpression="dtmFechaResolu" />
                        <asp:BoundField DataField="dtmFechaVencSoli" HeaderText="Fecha Venc Sol" 
                            SortExpression="dtmFechaVencSoli" />
                        <asp:BoundField DataField="intDiasAtraso" HeaderText="Dias Atraso" 
                            SortExpression="intDiasAtraso" />
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="Gray" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#383838" />
                </asp:GridView></div>
</div>

</div>
    


</asp:Content>
