<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MantPrivilegios.aspx.cs" Inherits="WorkflowSolicitudes.Formulario_web21" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

<link href="../css/alertify.core.css" rel="stylesheet" type="text/css" />
 <link href="../css/alertify.default.css" rel="stylesheet" type="text/css" id="toggleCSS" />


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div class="container">

<div class ="row-fluid">
<div class ="span12"><h3 class="text-center">Mantenedor Privilegios</h3></div>
</div>

<div class ="row-fluid">
<div class ="span12"><asp:Label ID="lblAcceso" runat="server"></asp:Label></div>
</div>

<div class ="row-fluid">
<div class ="span4"><p class="text-left">Descripción:</p></div>
<div class ="span4"><asp:TextBox ID="txtDescripcionPrivilegios" runat="server" height="22px" Width="485px" 
                        MaxLength="50"></asp:TextBox></div>
<div class ="span4"></div>
</div>

<div class ="row-fluid">
<div class ="span4"><p class="text-left">Nombre:</p></div>
<div class ="span4"><asp:TextBox ID="TxtNombre" runat="server" Width="485px" 
                        MaxLength="50"></asp:TextBox></div>
<div class ="span4"></div>
</div>

<div class ="row-fluid">
<div class ="span4"><asp:Label ID="lblEstado" runat="server" style="font-weight: 700" 
                        Text="Estado"></asp:Label></div>
<div class ="span4"><asp:CheckBox ID="chkEstado" runat="server" Text="Esta Activo...??" /></div>
<div class ="span4"><asp:Label ID="lblMensaje" runat="server" style="font-weight: 700; color: #FF0000"></asp:Label></div>
</div>

<div class ="row-fluid">
<div class ="span12"><asp:ImageButton ID="btnGuardar" runat="server" ImageUrl="~/imagenes/boton.guardar.gif" onclick="btnGuardar_Click" /></div>
</div>

<div class ="row-fluid">
<div class ="span12">
    <asp:GridView 
       ID="grvPrivilegios" 
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
       onpageindexchanging="grvPrivilegios_PageIndexChanging" 
       onrowcancelingedit="grvPrivilegios_RowCancelingEdit" 
       onrowdeleting="grvPrivilegios_RowDeleting" 
       onrowediting="grvPrivilegios_RowEditing" 
       onrowupdating="grvPrivilegios_RowUpdating" 
       DataKeyNames="intCodPrivilegios,strDescPrivilegios,strNomPrivilegios,strEstadoPrivilegios"
       onselectedindexchanged="grvPrivilegios_SelectedIndexChanged"
       emptydatatext="No existen datos para la consulta realizada" 
        Font-Bold="False">

            <emptydatarowstyle backcolor="#B2E389" forecolor="Red"/>

       <AlternatingRowStyle BackColor="#CCCCCC" />
       <Columns>
            <asp:CommandField ButtonType="Image" SelectImageUrl="~/imagenes/editar.gif" 
                ShowSelectButton="True" ShowCancelButton="False" />

            <asp:TemplateField HeaderText="Codigo" Visible="False">

            <ItemTemplate>
            <asp:Label ID="lblCodPrivilegios" runat="server" Text='<%#Bind("intCodPrivilegios") %>'/>
            </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Descripcion">
                        
            <ItemTemplate>
            <asp:Label ID="lblDescPrivilegios" runat="server" Text='<%#Bind("strDescPrivilegios") %>'/>
            </ItemTemplate>
                        
            <EditItemTemplate>
            <asp:TextBox ID="txtEditDescPrivilegios" runat="server" Text='<%#Bind("strDescPrivilegios") %>'/>
            </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Nombre">
                        
            <ItemTemplate>
            <asp:Label ID="lblNomPrivilegios" runat="server" Text='<%#Bind("strNomPrivilegios") %>'/>
            </ItemTemplate>
                        
            <EditItemTemplate>
            <asp:TextBox ID="txtEditNomPrivilegios" runat="server" Text='<%#Bind("strNomPrivilegios") %>'/>
            </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Estado">
                        
                <EditItemTemplate>
               
                    <asp:CheckBox ID="chkEditEstadoPrvilegio" runat="server" EnableViewState="False" Text='<%# Bind("strEstadoPrivilegios") %>' />
               
                </EditItemTemplate>

              
                <ItemTemplate>
                <asp:Label ID="lblEstadoPrivilegios" runat="server" Text='<%# Bind("strEstadoPrivilegios") %>'></asp:Label>
                </ItemTemplate>

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
