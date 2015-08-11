<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MantRolesPrivilegios.aspx.cs" Inherits="WorkflowSolicitudes.Formulario_web22" %>
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
<div class ="span12"><h3 class="text-center">Mantenedor Mantenedor de Roles Privilegios</h3></div>
</div>

<div class ="row-fluid">
<div class ="span12"><asp:Label ID="lblAcceso" runat="server"></asp:Label></div>
</div>

<div class ="row-fluid">
<div class ="span4"><p class="text-left">Rol:</p></div>
<div class ="span4"><asp:DropDownList ID="ddlRol" runat="server" Height="22px" 
        Width="318px" AutoPostBack="True" 
        onselectedindexchanged="ddlRol_SelectedIndexChanged"></asp:DropDownList></div>
<div class ="span4"></div>
</div>

<div class ="row-fluid">
<div class ="span4"><p class="text-left">Privilegios:</p></div>
<div class ="span4"><asp:DropDownList ID="ddlPrivilegios" runat="server" Height="22px" Width="320px"></asp:DropDownList></div>
<div class ="span4"></div>
</div>

<div class ="row-fluid">
<div class ="span4"><asp:Label ID="lblEstadoRolPriv" runat="server" style="font-weight: 700" 
                        Text="Estado"></asp:Label></div>
<div class ="span4"><asp:CheckBox ID="chkEstadoRolPriv" runat="server" Text="Esta Activo...??" /></div>
<div class ="span4"></div>
</div>

<div class ="row-fluid">
<div class ="span12">
    <asp:GridView 
        ID="grvRolPrivilegios" 
        runat="server"  
        AutoGenerateColumns="False" 
        AllowPaging="True"
        BackColor="White" 
        BorderColor="#999999" 
        BorderStyle="Solid" 
        BorderWidth="1px" 
        CellPadding="5" 
        ForeColor="Black" 
        GridLines="Vertical"  
        onpageindexchanging="grvRolPrivilegios_PageIndexChanging" 
        onrowcancelingedit="grvRolPrivilegios_RowCancelingEdit"
        onrowdeleting="grvRolPrivilegios_RowDeleting" 
        onrowediting="grvRolPrivilegios_RowEditing"
        onrowupdating="grvRolPrivilegios_RowUpdating" 
        DataKeyNames="intCodPrivilegios,intCodRol,strEstadoRolPrivi" 
        onselectedindexchanged="grvRolPrivilegios_SelectedIndexChanged" 
        PageSize="15"
        emptydatatext="No existen datos en la Grilla" Font-Bold="False" 
        Width="941px">

        <emptydatarowstyle backcolor="#B2E389" forecolor="Red"/>
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
        <asp:CommandField ButtonType="Image" SelectImageUrl="~/imagenes/editar.gif" 
                ShowSelectButton="True" ShowCancelButton="False" />
            <asp:ButtonField ButtonType="Image" CommandName="Delete" 
                ImageUrl="~/imagenes/eliminar.gif" ShowHeader="True" Text="Botón" />
            <asp:BoundField DataField="strDescPrivilegios" HeaderText="Rol" 
                SortExpression="strDescPrivilegios" />
            <asp:BoundField DataField="strDescripcion" HeaderText="Privilegio" 
                SortExpression="strDescripcion" />
            <asp:BoundField DataField="strEstadoRolPrivi" HeaderText="Estado" 
                SortExpression="strEstadoRolPrivi" />

                     
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
<div class ="span12"> <asp:Label ID="lblMensaje" runat="server" ForeColor="Red" 
        style="font-weight: 700"></asp:Label></div>
</div>

<div class ="row-fluid">
<div class ="span12"><asp:ImageButton ID="btnInsertar" runat="server" ImageUrl="~/imagenes/boton.guardar.gif" onclick="btnInsertar_Click" /></div>
</div>

</div>  
    
</asp:Content>
