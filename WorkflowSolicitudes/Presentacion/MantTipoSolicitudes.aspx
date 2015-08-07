<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MantTipoSolicitudes.aspx.cs" Inherits="WorkflowSolicitudes.Formulario_web11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

<link href="../css/alertify.core.css" rel="stylesheet" type="text/css" />
<link href="../css/alertify.default.css" rel="stylesheet" type="text/css" id="toggleCSS" />

<script src="../js/jquery.min.js" type="text/javascript"></script>
<script src="../js/jquery-ui.min.js" type="text/javascript"></script>
 <link href="../css/jquery-ui.css" rel="stylesheet" type="text/css" />


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div class="container">

<div class ="row-fluid">
<div class ="span12"><h3 class="text-center"> Mantenedor Tipos de Solicitudes</h3></div>
</div>

<div class ="row-fluid">
<div class ="span12">&nbsp;</div>
</div>

<div class ="row-fluid">
<div class ="span4"><p class="text-left">Descripción:</p></div>
<div class ="span4"> <asp:TextBox ID="txtDescripcionTS" runat="server" MaxLength="50" Height="22px" Width="468px"/>
    <asp:Button ID="BtnNuevo" runat="server" Text="Nuevo" 
        onclick="BtnNuevo_Click" />
    </div>
<div class ="span4"><asp:Label ID="lblMensjeDescripcion" runat="server"></asp:Label>&nbsp;<asp:Label ID="lblAcceso" runat="server"></asp:Label></div>
</div>
<div class ="row-fluid">
<div class ="span12"></div>
</div>

<div class ="row-fluid">
<div class ="span4"><p class="text-left">Cantidad de Solicitudes:</p></div>
<div class ="span4"><asp:TextBox ID="txtCantidadSol" runat="server" MaxLength="2" Height="22px" Width="45px"/></div>
<div class ="span4"></div>
</div>

<div class ="row-fluid">
<div class ="span4"><p class="text-left">Estado:</p></div>
<div class ="span4"><asp:CheckBox ID="ChkEstado" runat="server" Text="¿Es Activo?"/></div>
<div class ="span4"></div>
</div>

<div class ="row-fluid">
<div class ="span4"><p class="text-left">Origen Solicitud:</p></div>
<div class ="span4"><asp:DropDownList ID="ddlOrigenSolicitud" runat="server" Height="22px" 
                    Width="329px">
                    <asp:ListItem Value="0">SELECCIONAR</asp:ListItem>
                    <asp:ListItem Value="E">EXTERNO</asp:ListItem>
                    <asp:ListItem Value="I">INTERNO</asp:ListItem>
                </asp:DropDownList></div>
<div class ="span4"><asp:Label ID="lblMensajeOrigenSol" runat="server" style="color: #FF0000; font-weight: 700"></asp:Label></div>
</div>

<div class ="row-fluid">
<div class ="span4"><p class="text-left">Cantidad de documentos:</p></div>
<div class ="span4"><asp:TextBox ID="txtCantMaxDoc" runat="server" Height="22px" Width="46px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                        ControlToValidate="txtCantMaxDoc" ErrorMessage="Solo ingresar numeros " 
                        ValidationExpression="\d+" style="color: #FF0000; font-weight: 700"> </asp:RegularExpressionValidator></div>
<div class ="span4"><asp:Label ID="lblMensajeCantidadDoc" runat="server" 
                    style="color: #FF0000; font-weight: 700"></asp:Label></div>
</div>

<div class ="row-fluid">
<div class ="span4"><p class="text-left">Fecha Inicio:</p></div>

<div class ="span4"><asp:TextBox ID="txtFechaInicio" runat="server" Height="22px" Enabled="False"/>
                    &nbsp;<asp:ImageButton ID="imbInicio" runat="server" Height="24px" 
                    ImageUrl="~/imagenes/calendario.jpg" Width="28px" 
                    onclick="imbInicio_Click1" />
                    <asp:Label ID="lblFechaInicio" runat="server"></asp:Label></div>

<div class ="span4"><asp:Calendar ID = "CldFechainicio" runat = "server"  
            OnSelectionChanged = "Selection_Change" BackColor="White" BorderColor="#999999" 
            CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" 
            ForeColor="Black" Height="180px" Width="200px" >
             <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
             <NextPrevStyle VerticalAlign="Bottom" />
             <OtherMonthDayStyle ForeColor="#808080" />
             <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
             <SelectorStyle BackColor="#CCCCCC" />
             <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
             <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
             <WeekendDayStyle BackColor="#FFFFCC" />
    </asp:Calendar ></div>

</div>

<div class ="row-fluid">
<div class ="span4"><p class="text-left">Fecha de termino:</p></div>
<div class ="span4"><asp:TextBox ID="txtFechaFin" runat="server" Text='<%#Eval ("dtmFechaTerminoSol","{0: dd/MM/yyyy}") %>' Height="22px" Enabled="False"/>
                <asp:ImageButton ID="imbFin" runat="server" Height="24px" 
                    ImageUrl="~/imagenes/calendario.jpg" Width="30px" 
        onclick="imbFin_Click" />      
           
        <asp:Label ID="lblFechaFin" runat="server"></asp:Label>  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  
           
               
                <asp:ImageButton ID="btnInsertarTS" runat="server" Height="30px" 
                    ImageUrl="~/imagenes/boton.guardar.gif" onclick="btnInsertarTS_Click" 
                    Width="89px" />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblMensaje" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                    <br />
                    <br />
                    <br />
                    <br />
                &nbsp;&nbsp 
                <asp:Label ID="lblEstadoSolicitud" runat="server" Text="Estado de Solicitud">&nbsp;&nbsp</asp:Label></div>
<div class ="span4"> <asp:Calendar ID = "CldFechaFin" runat = "server"  
             OnSelectionChanged = "Calendar1_SelectionChanged" BackColor="White" 
             BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" 
             Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" 
             Width="200px" >
            <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
            <NextPrevStyle VerticalAlign="Bottom" />
            <OtherMonthDayStyle ForeColor="#808080" />
            <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
            <SelectorStyle BackColor="#CCCCCC" />
            <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
            <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
            <WeekendDayStyle BackColor="#FFFFCC" />
    </asp:Calendar >
    <br />
    </div>
</div>

<div class ="row-fluid">
<div class ="span12">
    <asp:GridView AutoGenerateColumns="False" runat="server" 
        ID="grvTipoSolicitud" DataKeyNames="intCodTipoSolicitud,strDescripcionSolicitud,intCantMaxSolicitud,intEstadoSolicitud,intCantMaxDoc,strOrigenSolicitud,dtmFechaTerminoSol,dtmFechaIncioSol" 
            AllowPaging="True"  
            onpageindexchanging="grvgrvTipoSolicitud_PageIndexChanging" onrowcancelingedit="grvTipoSolicitud_RowCancelingEdit" 
            onrowdeleting="grvTipoSolicitud_RowDeleting" 
            onrowediting="grvTipoSolicitud_RowEditing"
            onselectedindexchanged="grvTipoSolicitud_SelectedIndexChanged" 
        BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
        CellPadding="3" ForeColor="Black" GridLines="Vertical" 
        style="text-align: center" Height="90%" Width="90%"
        emptydatatext="No existen datos para la consulta realizada" 
        Font-Bold="False">

            <emptydatarowstyle backcolor="#B2E389" forecolor="Red"/>
            <AlternatingRowStyle BackColor="#CCCCCC" />


            <Columns>
            
                <asp:CommandField ButtonType="Image" SelectImageUrl="~/imagenes/editar.gif" 
                ShowSelectButton="True" ShowCancelButton="False" />
                
            <asp:TemplateField HeaderText="Codigo">
            <ItemTemplate>
            <asp:Label ID="lblCodigoTS" runat="server" Text='<%#Bind("intCodTipoSolicitud") %>'/>
            </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Descripcion">

            <ItemTemplate>
            <asp:Label ID="lblDescripcionTS" runat="server" Text='<%#Bind("strDescripcionSolicitud") %>'/>
            </ItemTemplate>
                        
            <EditItemTemplate>
            <asp:TextBox ID="txtEditDescripcionTS" runat="server" Maxlength="50"  Text='<%#Bind("strDescripcionSolicitud") %>'/>
            </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Estado Solicitud">

            <ItemTemplate>
            <asp:Label ID="lblEstadoSolicitud" runat="server" Text='<%#Bind("intEstadoSolicitud") %>'/>
            </ItemTemplate>
            
            <EditItemTemplate>
            <asp:TextBox ID="txtEditEstadoSolicitud" runat="server" Maxlength="30"  Text='<%#Bind("intEstadoSolicitud") %>'/>
            </EditItemTemplate>
            </asp:TemplateField>                 

            <asp:TemplateField HeaderText="Fecha Inicio">

            <ItemTemplate>
            <asp:Label ID="lblFechaInicioTS" runat="server" 
                    Text='<%# Bind("dtmFechaIncioSol", "{0: dd/MM/yyyy}") %>'/>
            </ItemTemplate>
      
            <EditItemTemplate>
            <asp:TextBox ID="txtEditFechaInicioTS" runat="server" 
                    Text='<%#Eval ("dtmFechaIncioSol","{0: dd/MM/yyyy}") %>' 
                    ontextchanged="txtEditFechaInicioTS_TextChanged" 
                    style="text-align: center" MaxLength="10" />

            <asp:RequiredFieldValidator ID="ValidaIngresoFI" 
              ControlToValidate="txtEditFechaInicioTS" 
              Text="Ingrese Fecha!" 
              Display="Dynamic" 
              Runat="Server" />  
                               
                <br />
            </EditItemTemplate>

            </asp:TemplateField>

            <asp:TemplateField HeaderText="Fecha Termino">

            <ItemTemplate>
            <asp:Label ID="lblFechaTerminoTS" runat="server" Text='<%#Bind("dtmFechaTerminoSol", "{0: dd/MM/yyyy}") %>'/>
            
            </ItemTemplate>
            
            <EditItemTemplate>
            <asp:TextBox ID="txtEditFechaTerminoTS" runat="server" Text='<%#Eval("dtmFechaTerminoSol", "{0: dd/MM/yyyy}") %>' MaxLength="10" />

            <asp:RequiredFieldValidator ID="ValidaIngresoFT" 
              ControlToValidate="txtEditFechaTerminoTS" 
              Text="Ingrese Fecha!" 
              Display="Dynamic" 
              Runat="Server" />  
               <asp:CompareValidator ID="ComparaFechas" 
              ControlToValidate = "txtEditFechaTerminoTS" 
              ControlToCompare = "txtEditFechaInicioTS" 
              Type = "Date" 
              Operator="GreaterThanEqual" 
              Text="La fecha de termino no puede ser menor a la de inicio!" 
              Runat = "Server" /> 
   
            <asp:Label 
            ID="lblError" 
            EnableViewState="False" 
            runat="Server" />  

            </EditItemTemplate>

            </asp:TemplateField>

            <asp:TemplateField HeaderText="Cant. Max. Solicitudes anual">
           
            <ItemTemplate>
            <asp:Label ID="lblCantMaxSolicitud" runat="server" Text='<%#Bind("intCantMaxSolicitud") %>'/>
            </ItemTemplate>   
            <EditItemTemplate>
            <asp:TextBox ID="txtEditCantMaxSolicitud" runat="server" Maxlength="2"  Text='<%#Bind("intCantMaxSolicitud") %>'/>
            </EditItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Origen Solicitud">  
                 
            <ItemTemplate>
            <asp:Label ID="lblOrigenSolicitud" runat="server" Text='<%#Bind("strOrigenSolicitud") %>'/>
            </ItemTemplate>        
            <EditItemTemplate>
            <asp:TextBox ID="txtEditOrigenSolicitud" runat="server" Maxlength="10"  Text='<%#Bind("strOrigenSolicitud") %>'/>
            </EditItemTemplate>     
            
            </asp:TemplateField>
                
             <asp:TemplateField HeaderText="Cant. Max. Doc">

             <ItemTemplate>
            <asp:Label ID="lblCantMaxDoc" runat="server" Text='<%#Bind("intCantMaxDoc") %>'/>
            </ItemTemplate> 
                 
            <EditItemTemplate>
            <asp:TextBox ID="txtEditCantMaxDoc" runat="server" Maxlength="2"  Text='<%#Bind("intCantMaxDoc") %>'/>
            </EditItemTemplate>     
             </asp:TemplateField>
        
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


 <script type="text/javascript">
    
     //===========================================================
	    //

        $(function () {
         $.datepicker.regional['es'] = {
             closeText: 'Cerrar',
             prevText: '<Ant',
             nextText: 'Sig>',
             currentText: 'Hoy',
             monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
             monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun', 'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
             dayNames: ['Domingo', 'Lunes', 'Martes', 'Miércoles', 'Jueves', 'Viernes', 'Sábado'],
             dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mié', 'Juv', 'Vie', 'Sáb'],
             dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'Sá'],
             weekHeader: 'Sm',
             dateFormat: 'dd/mm/yy',
             firstDay: 1,
             isRTL: false,
             showMonthAfterYear: false,
             yearSuffix: ''
         };

	    $.datepicker.setDefaults($.datepicker.regional['es']);


	    $("[id$=txtFechaDesde]").datepicker({
	        showOn: 'button',
	        buttonImageOnly: true,
	        buttonImage: '../imagenes/calendario.jpg',
	        dateFormat: 'dd/mm/yy'

	    });

	    $("[id$=txtFechaHasta]").datepicker({
	        showOn: 'button',
	        buttonImageOnly: true,
	        buttonImage: '../imagenes/calendario.jpg',
	        dateFormat: 'dd/mm/yy'

	    });


         $("[id$=txtCalendario]").datepicker({
	        showOn: 'button',
	        buttonImageOnly: true,
	        buttonImage: '../imagenes/calendario.jpg',
	        dateFormat: 'dd/mm/yy'

	    });
        

    
    
    </script>
</asp:Content>
