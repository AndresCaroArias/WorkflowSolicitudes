<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsultaSolicitudes.aspx.cs" Inherits="WorkflowSolicitudes.Presentacion.ConsultaSolicitudes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
  
 <link href="../css/alertify.core.css" rel="stylesheet" type="text/css" />
 <link href="../css/alertify.default.css" rel="stylesheet" type="text/css" id="toggleCSS" />

   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


<div class="container">

<div class ="row-fluid">
<div class ="span12"><h3 class="text-center">Consulta de Solicitudes Externas</h3></div>
</div>

<div class ="row-fluid">
<div class ="span12"></div>
</div>

<div class ="row-fluid">
<div class ="span12"><asp:Label ID="lblAcceso" runat="server"></asp:Label></div>
</div>

<div class ="row-fluid">
<div class ="span3"><p class="text-left">Folio:</p></div>
<div class ="span3"><asp:TextBox ID="TxtFolio" runat="server" Height="22px" Width="84px"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                        ControlToValidate="TxtFolio" ErrorMessage="Solo ingresar numeros " 
                        ValidationExpression="\d+"></asp:RegularExpressionValidator></div>
<div class ="span3"><p class="text-left">Tipo de Solicitud:</p></div>
<div class ="span3"><asp:DropDownList 
                        ID="ddlTipoSolicitud" runat="server" Height="22px" Width="200px">
                    </asp:DropDownList></div>
</div>


<div class ="row-fluid">
<div class ="span3"><p class="text-left">Estado:</p></div>
<div class ="span3"><asp:DropDownList 
                        ID="ddlEstado" runat="server" Height="22px" Width="200px">
                    </asp:DropDownList></div>
<div class ="span3"><p class="text-left">Rut:</p></div>
<div class ="span3"><asp:TextBox ID="TxtRut" runat="server" Height="22px" Width="84px"></asp:TextBox></div>
</div>

<div class ="row-fluid">
<div class ="span3"><p class="text-left">Carrera:</p></div>
<div class ="span3"><asp:DropDownList ID="ddlCarrera" runat="server" Height="22px"  Width="200px">
                    </asp:DropDownList></div>
<div class ="span3"><p class="text-left">Jornada:</p></div>
<div class ="span3"><asp:DropDownList ID="ddlJornada" runat="server" 
                        style="text-align: center" Height="22px" Width="173px">
                        <asp:ListItem Value="0">Todos</asp:ListItem>
                        <asp:ListItem Value="D">Diurna</asp:ListItem>
                        <asp:ListItem Value="v">Vespertino</asp:ListItem>
                    </asp:DropDownList></div>
</div>

<div class ="row-fluid">
<div class ="span2"><p class="text-left">Fecha Solicitud Desde:</p></div>
<div class ="span2"> <asp:TextBox ID="TxtFechaSolicitud" runat="server" Height="22px" Width="100px" 
                        Enabled="False"></asp:TextBox>
                    <asp:ImageButton ID="ImagenCalendario1" runat="server" 
                        onclick="ImagenCalendario1_Click" Height="25px" 
                        ImageUrl="~/imagenes/calendario.gif" Width="30px" /></div>
<div class ="span2"> <asp:Calendar ID="Calendario1" runat="server" BackColor="White" 
                        BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" 
                        DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" 
                        ForeColor="#003399" Height="16px" Width="16px" 
                        onselectionchanged="Calendario1_SelectionChanged">
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
<div class ="span2"><p class="text-left">Fecha Solicitud Hasta:</p></div>
<div class ="span2"><asp:TextBox ID="TxtFechaSolicitudHasta" runat="server" Height="22px" 
                        Width="100px" Enabled="False" ></asp:TextBox>
                    <asp:ImageButton ID="ImagenCalendario2" runat="server" 
                        onclick="ImagenCalendario2_Click" Height="25px" 
                        ImageUrl="~/imagenes/calendario.gif" Width="30px" />
       </div>
<div class ="span2"><asp:Calendar ID="Calendario2" runat="server" BackColor="White" 
                        BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" 
                        DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" 
                        ForeColor="#003399" Height="16px" Width="16px" 
                        onselectionchanged="Calendario2_SelectionChanged">
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
<div class ="span2"><p class="text-left">Fecha Resolución Desde:</p></div>
<div class ="span2"><asp:TextBox ID="TxtFechaResolucion" runat="server" Height="22px" Width="97px" Enabled="False"></asp:TextBox>
                    <asp:ImageButton ID="ImagenCalendario3" runat="server" 
                        onclick="ImagenCalendario3_Click" Height="25px" 
                        ImageUrl="~/imagenes/calendario.gif" Width="30px" /></div>
<div class ="span2"><asp:Calendar ID="Calendario3" runat="server" BackColor="White" 
                        BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" 
                        DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" 
                        ForeColor="#003399" Height="38px" Width="16px" 
                        onselectionchanged="Calendario3_SelectionChanged">
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
<div class ="span2"><p class="text-left">Fecha Resolución Hasta:</p></div>
<div class ="span2"> <asp:TextBox ID="TxtFechaResolucionHasta" runat="server" Height="22px" Width="97px" Enabled="False" ></asp:TextBox>
                    <asp:ImageButton ID="ImagenCalendario4" runat="server" 
                        onclick="ImagenCalendario4_Click" Height="25px" 
                        ImageUrl="~/imagenes/calendario.gif" Width="30px" /></div>
<div class ="span2"><asp:Calendar ID="Calendario4" runat="server" BackColor="White" 
                        BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" 
                        DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" 
                        ForeColor="#003399" Height="38px" Width="16px" 
                        onselectionchanged="Calendario4_SelectionChanged">
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
<div class ="span2"><p class="text-left">Origen:</p></div>
<div class ="span2"><asp:DropDownList ID="ddlOrigen" runat="server" Height="22px" 
                        Width="173px">
                        <asp:ListItem Value="0">Todos</asp:ListItem>
                        <asp:ListItem Value="E">Externas</asp:ListItem>
                        <asp:ListItem Value="I">Internas</asp:ListItem>
                    </asp:DropDownList></div>
<div class ="span2"> <asp:ImageButton ID="BtnBuscar" runat="server" Height="41px" 
                        ImageUrl="~/imagenes/icono_buscar.gif" onclick="enviar" Width="41px" 
                        style="text-align: left" /></div>
<div class ="span2"><asp:Label ID="lblMensaje" runat="server" 
                        style="font-weight: 700; color: #FF0000"></asp:Label></div>
<div class ="span2"></div>
<div class ="span2"></div>
</div>
<div class ="row-fluid">
<div class ="span12"></div>
</div>


<div class ="row-fluid">
<div class ="span12"> 
    <asp:GridView ID="grvConsultaSolicitud"
         runat="server" BackColor="White" 
                        BorderColor="#999999"
                        BorderStyle="Solid" 
                        BorderWidth="1px" 
                        CellPadding="3" 
                        GridLines="Vertical" 
                        HorizontalAlign="Center" 
                        AutoGenerateColumns="False"
                         DataKeyNames="intFolioSolicitud"

                        AllowPaging="True" AllowSorting="True" 
                        onpageIndexChanging="grvConsultaSolicitud_PageIndexChanging"
                       
                         
                        ForeColor="Black" style="font-size: xx-small" onsorting="grvConsultaSolicitud_Sorting" 
                        onselectedindexchanged="grvConsultaSolicitud_SelectedIndexChanged" 
                        Width="929px" onrowupdating="grvConsultaSolicitud_RowUpdating" 
                        onrowdeleting="grvConsultaSolicitud_RowDeleting"
                        emptydatatext="No existen datos para la consulta realizada" 
        Font-Bold="False">

                        <emptydatarowstyle backcolor="#B2E389" forecolor="Red"/>
                        <AlternatingRowStyle BackColor="#CCCCCC" />
                       
                       
                        <Columns>
                        <asp:CommandField ButtonType="Image" 
                        HeaderText="Seleccionar" 
                        SelectImageUrl="~/imagenes/lupa.gif" 
                        ShowHeader="True" 
                        ShowSelectButton="True" />

                <asp:BoundField DataField="IntFolioSolicitud" HeaderText="Folio" 
                    SortExpression="IntFolioSolicitud" />
                    

                <asp:BoundField DataField="strDescSolicitud" HeaderText="Tipo Solicitud" 
                    SortExpression="strDescSolicitud" />
                <asp:BoundField DataField="dtmFechaSolicitud" HeaderText="Fecha Solicitud" 
                    SortExpression="dtmFechaSolicitud" DataFormatString="{0:d}" />
                <asp:BoundField DataField="strCod_Cli" HeaderText="Rut " 
                    SortExpression="strCod_Cli" />
                <asp:BoundField DataField="strNombre" HeaderText="Nombre" 
                    SortExpression="strNombre" />
                <asp:BoundField DataField="strPaterno" HeaderText="Apellido Paterno" 
                    SortExpression="strPaterno" />
                <asp:BoundField DataField="strMaterno" HeaderText="Apeliido Materno" 
                    SortExpression="strMaterno" />
                <asp:BoundField DataField="strNombre_Largo" HeaderText="Carrera" 
                    SortExpression="strNombre_Largo" />
                <asp:BoundField DataField="dtmFechaResolucion" HeaderText="Fecha Resolucion" 
                    SortExpression="dtmFechaResolucion" />
                <asp:BoundField DataField="strGlosaSolucion" HeaderText="Observacion" 
                    SortExpression="strGlosaSolucion" />
                <asp:BoundField DataField="strObsSolucion" HeaderText="Obs. Resolucion" 
                    SortExpression="strObsSolucion" />
                <asp:BoundField DataField="strDescEstado" HeaderText="Estados" 
                    SortExpression="strDescEstado" />
                <asp:BoundField DataField="strJornada" HeaderText="Jornada" 
                    SortExpression="strJornada" />

                            <asp:ButtonField ButtonType="Image" CommandName="Delete" HeaderText="Ver PDF" 
                                ImageUrl="~/imagenes/pdf.gif" ShowHeader="True" />
                    

                            <asp:ButtonField ButtonType="Image" CommandName="Update" 
                                HeaderText="Ver Adjuntos" ImageUrl="~/imagenes/adjuntar.png" 
                                ShowHeader="True" />
                    

            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="center" />
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
<div class ="span12">Exportar a Excel<asp:ImageButton ID="BtnExcel" runat="server" 
                        ImageUrl="~/imagenes/icon-excel.gif" onclick="BtnExcel_Click" /></div>
</div>

</div>
     
               

</asp:Content>
