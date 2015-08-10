<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MantRol.aspx.cs" Inherits="WorkflowSolicitudes.Formulario_web2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

 <link href="../css/alertify.core.css" rel="stylesheet" type="text/css" />
 <link href="../css/alertify.default.css" rel="stylesheet" type="text/css" id="toggleCSS" />



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


<div class="container">
<div class ="row-fluid">
<div class ="span12"><h3 class="text-center">Mantenedor de Roles</h3></div>
</div>

<div class ="row-fluid">
<div class ="span12"><asp:Label ID="lblAcceso" runat="server"></asp:Label></div>
</div>

<div class ="row-fluid">
<div class ="span4"><p class="text-left">Descripción de Rol:</p></div>
<div class ="span4"><asp:TextBox ID="txtDescripcionRol" runat="server" height="22px" Width="485px" MaxLength="50"></asp:TextBox></div>
<div class ="span4"></div>
</div>


<div class ="row-fluid">
<div class ="span4"><asp:Label ID="lblEstadoRol" runat="server" style="font-weight: 700" 
                        Text="Estado"></asp:Label></div>
<div class ="span4"><asp:CheckBox ID="chkEstadoRol" runat="server" Text="Esta Activo...??" /></div>
<div class ="span4"><asp:Label ID="lblMensaje" runat="server" style="font-weight: 700; color: #FF0000"></asp:Label></div>
</div>
<div class ="row-fluid">
<div class ="span12"></div>
</div>

<div class ="row-fluid">
<div class ="span12"><asp:ImageButton ID="btnInsertarRol" runat="server" ImageUrl="~/imagenes/boton.guardar.gif" onclick="btnInsertar_Click" /></div>
</div>

<div class ="row-fluid">
<div class ="span12"></div>
</div>

<div class ="row-fluid">
<div class ="span12"><asp:GridView 
        ID="grvRol" 
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
        onpageindexchanging="grvRol_PageIndexChanging" 
        onrowcancelingedit="grvRol_RowCancelingEdit"
        onrowdeleting="grvRol_RowDeleting" 
        onrowediting="grvRol_RowEditing"
        onrowupdating="grvRol_RowUpdating" 
        DataKeyNames="intCodRol,strDescripcion, strEstadorol" 
        onselectedindexchanged="grvRol_SelectedIndexChanged" 
        PageSize="5"
        emptydatatext="No existen datos para la consulta realizada" 
        Font-Bold="False">

            <emptydatarowstyle backcolor="#B2E389" forecolor="Red"/>
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
               
                
                 <asp:CommandField ButtonType="Image" SelectImageUrl="~/imagenes/editar.gif" 
                ShowSelectButton="True" ShowCancelButton="False" />


            <asp:TemplateField HeaderText="Codigo" Visible="False">

            <ItemTemplate>
            <asp:Label ID="lblCodRol" runat="server" Text='<%#Bind("intCodRol") %>'/>
            </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Descripcion">
                        
            <ItemTemplate>
            <asp:Label ID="lblDescripcionRol" runat="server" Text='<%#Bind("strDescripcion") %>'/>
            </ItemTemplate>
                        
            <EditItemTemplate>
            <asp:TextBox ID="txtEditDescripcionRol" runat="server" Text='<%#Bind("strDescripcion") %>'/>
            </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Estado">
                        
            <ItemTemplate>
                 <asp:Label ID="lblDEstado" runat="server" Text='<%#Bind("strEstadorol") %>'/>
            </ItemTemplate>

                        
            <EditItemTemplate>
            <asp:TextBox ID="txtEditEstadoRol" runat="server" Text='<%#Bind("strEstadorol") %>'/>
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
   
    
    </asp:Content>
