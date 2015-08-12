<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MantFeriados.aspx.cs" Inherits="WorkflowSolicitudes.Formulario_web24" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<link href="../css/alertify.core.css" rel="stylesheet" type="text/css" />
 <link href="../css/alertify.default.css" rel="stylesheet" type="text/css" id="toggleCSS" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div class="container">

<div class ="row-fluid">
<div class ="span12"><h3 class="text-center">Mantenedor de Feriados</h3></div>
</div>

<div class ="row-fluid">
<div class ="span12"><asp:Label ID="lblAcceso" runat="server"></asp:Label></div>
</div>

<div class ="row-fluid">
<div class ="span4"><p class="text-left">Descripció de Feriado:</p></div>
<div class ="span4"><asp:TextBox ID="txtDescripcionFeriados" runat="server" height="22px" Width="485px" 
                        MaxLength="50"></asp:TextBox></div>
<div class ="span4"></div>
</div>

<div class ="row-fluid">
<div class ="span4"><p class="text-left">Fecha:</p></div>
<div class ="span4"><asp:TextBox ID="txtFechasFeriados" runat="server" height="22px" Width="71px" MaxLength="10" 
                        Enabled="False" TextMode="DateTime"></asp:TextBox>
                    &nbsp;<asp:ImageButton ID="imbFeriado" runat="server" Height="24px" ImageUrl="~/imagenes/calendario.gif" Width="28px" 
                    onclick="imbFeriado_Click1" /></div>
<div class ="span4"></div>
</div>

<div class ="row-fluid">
<div class ="span12"> <asp:Label ID="lblMensaje" runat="server" style="font-weight: 700; color: #FF0000"></asp:Label></div>
</div>


<div class ="row-fluid">
<div class ="span12"><asp:ImageButton ID="btnGuardarFeriados" runat="server" ImageUrl="~/imagenes/boton.guardar.gif" onclick="btnGuardar_Click" /></div>
</div>

<div class ="row-fluid">
<div class ="span12"></div>
</div>


<div class ="row-fluid">
<div class ="span6">
    <asp:GridView ID="grvFeriado" 
    runat="server"
    AutoGenerateColumns="False" 
    AllowPaging  = "True"
    BackColor="White" 
    BorderColor="#999999"  
    BorderStyle="Solid" 
    BorderWidth="1px" 
    CellPadding="5" 
    ForeColor="Black"  
    GridLines="Vertical"  
    DataKeyNames="intCodFeriado,strDescFeriado,dtmFechaFeriado" 
	onpageindexchanging="grvFeriado_PageIndexChanging" 
    onrowcancelingedit="grvFeriado_RowCancelingEdit" 
    onrowdeleting="grvFeriado_RowDeleting" 
	onrowediting="grvFeriado_RowEditing" 
    onrowupdating="grvFeriado_RowUpdating" 
    onselectedindexchanged="grvFeriado_SelectedIndexChanged"
    emptydatatext="No existen datos para la consulta realizada" Font-Bold="False">

            <emptydatarowstyle backcolor="#B2E389" forecolor="Red"/>

    <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
                <asp:CommandField ButtonType="Image" SelectImageUrl="~/imagenes/editar.gif" ShowSelectButton="True" ShowCancelButton="False" />
            
                <asp:CommandField ButtonType="Image" DeleteImageUrl="~/imagenes/eliminar.gif" 
                    ShowDeleteButton="True" />


            <asp:TemplateField HeaderText="Codigo" Visible="False">

            <ItemTemplate>
            <asp:Label ID="lblCodFeriado" runat="server" Text='<%#Bind("intCodFeriado") %>'/>
            </ItemTemplate>

            <EditItemTemplate>
            <asp:TextBox ID="txtEditCodFeriado" runat="server" Text='<%#Bind("intCodFeriado") %>'/>
            </EditItemTemplate>

            </asp:TemplateField>

            <asp:TemplateField HeaderText="Descripción">
                        
            <ItemTemplate>
            <asp:Label ID="lblDescFeriado" runat="server" Text='<%#Bind("strDescFeriado") %>'/>
            </ItemTemplate>
                        
            <EditItemTemplate>
            <asp:TextBox ID="txtEditDescFeriado" runat="server" Text='<%#Bind("strDescFeriado") %>'/>
            </EditItemTemplate>
            </asp:TemplateField>

             <asp:TemplateField HeaderText="Fecha">
                        
            <ItemTemplate>
            <asp:Label ID="lblFechaFeriado" runat="server" Text='<%#Bind("dtmFechaFeriado") %>'/>
            </ItemTemplate>
                        
            <EditItemTemplate>
            <asp:TextBox ID="txtEditFechaFeriado" runat="server" Text='<%#Bind("dtmFechaFeriado") %>'/>
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
<div class ="span6"><asp:Calendar ID = "CldFeriado" runat = "server"  
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

</div>

</asp:Content>
