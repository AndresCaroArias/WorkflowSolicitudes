<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MantActividades.aspx.cs" Inherits="WorkflowSolicitudes.Formulario_web1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

<link href="../css/alertify.core.css" rel="stylesheet" type="text/css" />
 <link href="../css/alertify.default.css" rel="stylesheet" type="text/css" id="toggleCSS" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div class="container">

<div class ="row-fluid">
<div class ="span12"><h3 class="text-center"> Mantenedor de Actividades</h3></div>
</div>

<div class ="row-fluid">
<div class ="span4"><p class="text-left">Descripción:</p></div>
<div class ="span4"><asp:TextBox ID="txtDescripcion" runat="server" height="22px" Width="509px"></asp:TextBox></div>
<div class ="span4"><asp:Label ID="lblAcceso" runat="server"></asp:Label></div>
</div>

<div class ="row-fluid">
<div class ="span4"><p class="text-left">Duración:</p></div>
<div class ="span4"><asp:TextBox ID="txtDuracion" runat="server" height="22px"></asp:TextBox></div>
<div class ="span4"><asp:ImageButton ID="btnInsertar" runat="server" ImageUrl="~/imagenes/boton.guardar.gif" onclick="btnInsertar_Click" /></div>
</div>

<div class ="row-fluid">
<div class ="span4"><asp:Label ID="lblEstadoActividad" runat="server" style="font-weight: 700" Text="Estado"></asp:Label></div>
<div class ="span4"><asp:CheckBox ID="chkEstadoActividad" runat="server" Text="Esta Activo...??" /></div>
<div class ="span4"><asp:Label ID="lblMensaje" runat="server" style="font-weight: 700; color: #FF0000"></asp:Label></div>
</div>

<div class ="row-fluid">
<div class ="span12">
    <asp:GridView ID="grvActividad" 
            runat="server" 
            AutoGenerateColumns="False" 
            BackColor="White" 
            BorderColor="#999999" 
            BorderStyle="Solid" 
            BorderWidth="1px" 
            CellPadding="3" 
            ForeColor="Black" 
            GridLines="Vertical" 
            onpageindexchanging="grvActividad_PageIndexChanging" 
            onrowdeleting="grvActividad_RowDeleting" 
            onrowediting="grvActividad_RowEditing" 
            onrowupdating="grvActividad_RowUpdating" 
            DataKeyNames="intCodActividad, strDescripActividad, intDuracion,strEstadoActividad" 
            onrowcancelingedit="grvActividad_RowCancelingEdit"
            emptydatatext="No existen datos en la Grilla" 
            Font-Bold="False" 
            AllowPaging="True" 
            onselectedindexchanged="grvActividad_SelectedIndexChanged">
            <emptydatarowstyle backcolor="#B2E389" forecolor="Red"/>

            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>

             <asp:CommandField ButtonType="Image" SelectImageUrl="~/imagenes/editar.gif" 
                ShowSelectButton="True" ShowCancelButton="False" />

               <asp:TemplateField HeaderText="Codigo" Visible="False">

            <ItemTemplate>
            <asp:Label ID="lblCodActividad" runat="server" Text='<%#Bind("intCodActividad") %>'/>
            </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Descripcion">
                        
            <ItemTemplate>
            <asp:Label ID="lblDescripcion" runat="server" Text='<%#Bind("strDescripActividad") %>'/>
            </ItemTemplate>

            
            <EditItemTemplate>
            <asp:TextBox ID="txtEditDescripcion" runat="server" Text='<%#Bind("strDescripActividad") %>'/>
            </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Duracion">

            <ItemTemplate>
            <asp:Label ID="lblDuracion" runat="server" Text='<%#Bind("intDuracion") %>'/>
            </ItemTemplate>

            <EditItemTemplate>
            <asp:TextBox ID="txtEditDuracion" runat="server" Text='<%#Bind("intDuracion") %>'/>
            </EditItemTemplate>


            </asp:TemplateField>

            <asp:TemplateField HeaderText="Estado">
                        
            <ItemTemplate>
            <asp:Label ID="lblDEstado" runat="server" Text='<%#Bind("strEstadoActividad") %>'/>
            </ItemTemplate>

            <EditItemTemplate>
            <asp:TextBox ID="txtEditEstadoRol" runat="server" Text='<%#Bind("strEstadoActividad") %>'/>
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
