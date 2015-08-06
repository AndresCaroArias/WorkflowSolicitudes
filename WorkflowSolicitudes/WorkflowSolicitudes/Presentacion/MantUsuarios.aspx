<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MantUsuarios.aspx.cs" Inherits="WorkflowSolicitudes.Formulario_web23" %>
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
<div class ="span12"><h3 class="text-center">Mantenedor de Usuarios</h3></div>
</div>

<div class ="row-fluid">
<div class ="span12"><asp:Label ID="lblAcceso" runat="server"></asp:Label>&nbsp;</div>
</div>



<div class ="row-fluid">
<div class ="span3"><p class="text-left">Rut</p></div>
<div class ="span3"><asp:TextBox ID="txtRut" runat="server" Width="169px" MaxLength="50" Height="22px"></asp:TextBox>
    <asp:ImageButton ID="ImageButton2" runat="server"  OnClientClick="ir();" 
                        onclick="botonPrueba_Click" ImageUrl="~/imagenes/lupa.gif"/>
    <asp:ImageButton ID="ImageButton1" runat="server" 
                        ImageUrl="~/imagenes/guardar.gif" onclick="ImageButton1_Click" 
                        style="width: 16px" /></div>
<div class ="span3"><p class="text-left">Email:</p></div>
<div class ="span3"><asp:TextBox ID="txtEmail" runat="server" Width="169px" MaxLength="50" Height="22px"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RglValidaEmailUsuario" runat="server" 
                ControlToValidate="txtEmail" ErrorMessage="Email Invalido!!" 
                style="font-weight: 700; color: #FF0000" 
                ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"></asp:RegularExpressionValidator></div>
</div>




<div class ="row-fluid">
<div class ="span3"><p class="text-left">Nombre:</p></div>
<div class ="span3"><asp:TextBox ID="txtNombre" runat="server" Width="169px" MaxLength="50" Height="22px"></asp:TextBox></div>
<div class ="span3"><p class="text-left">&nbsp;</p></div>
<div class ="span3"> 
    </div>
</div>

<div class ="row-fluid">
<div class ="span3"><p class="text-left">Apellido:</p></div>
<div class ="span3"> <asp:TextBox ID="txtApellido" runat="server" Height="22px" Width="169px" MaxLength="50"></asp:TextBox></div>
<div class ="span3"><p class="text-left">Rol:</p></div>
<div class ="span3"><asp:DropDownList ID="ddlRol" runat="server" Height="22px" Width="169px"></asp:DropDownList></div>
</div>

<div class ="row-fluid">
<div class ="span3"><p class="text-left">Unidades :</p></div>
<div class ="span3"><asp:DropDownList ID="ddlUnidad" runat="server" Height="22px" Width="169px"></asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </div>
<div class ="span3"><p class="text-left">Depende de :</p></div>
<div class ="span3"><asp:DropDownList ID="ddlUsuario" runat="server" Height="22px" Width="169px"></asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </div>
</div>

<div class ="row-fluid">
<div class ="span3"><p class="text-left">Telefono:</p></div>
<div class ="span3"><asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox></div>
<div class ="span3"><asp:CheckBox ID="chkEstado" runat="server" Text="Esta Activo...??" /></div>
<div class ="span3">
    <br />
    </div>
</div>

<div class ="row-fluid">
<div class ="span12">
    <asp:GridView ID="grvUsuarios" runat="server"  
        AutoGenerateColumns="False" AllowPaging="True"
        BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
        CellPadding="5" ForeColor="Black" GridLines="Vertical"  
        onpageindexchanging="grvUsuarios_PageIndexChanging" 
        onrowcancelingedit="grvUsuarios_RowCancelingEdit"
        onrowdeleting="grvUsuarios_RowDeleting" 
        onrowediting="grvUsuarios_RowEditing"
        onrowupdating="grvUsuarios_RowUpdating" 
        DataKeyNames="strRutUsuario,strNombre,strApellido,strTelefono,strEmailUsuario,strPassword,intCodRol,intCodUnidad,strDepende" 
        onselectedindexchanged="grvUsuarios_SelectedIndexChanged" 
        onrowcommand="grvUsuarios_RowCommand"
        emptydatatext="No existen datos para la consulta realizada" 
        Font-Bold="False">

            <emptydatarowstyle backcolor="#B2E389" forecolor="Red"/>

        <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
                <asp:CommandField ButtonType="Image" SelectImageUrl="~/imagenes/editar.gif" 
                ShowSelectButton="True" ShowCancelButton="False" />

                <asp:CommandField ButtonType="Image" DeleteImageUrl="~/imagenes/eliminar.gif" 
                    ShowDeleteButton="True" Visible="False" />
                    

<%-- <asp:TemplateField HeaderText="Editar">
<ItemTemplate>
<asp:ImageButton ID="btnEditar"  runat="server" ImageUrl="~/imagenes/editar.gif"  Text="Editar"   OnCommand="EditarFilaSeleccionada" />
</ItemTemplate> 
</asp:TemplateField>--%>
          
            
           
            <asp:TemplateField HeaderText="Rut Usuario">

            <ItemTemplate>
            <asp:Label ID="lblRutUsuario" runat="server" Text='<%#Bind("strRutUsuario") %>'/>
            </ItemTemplate>

            <EditItemTemplate>
            <asp:TextBox ID="txtEditRutUsuario" runat="server" Text='<%#Bind("strRutUsuario") %>'/>
            </EditItemTemplate>

            </asp:TemplateField>

            <asp:TemplateField HeaderText="Rol" Visible="False">
                        
            <ItemTemplate>
            <asp:Label ID="lblCodRol" runat="server" Text='<%#Bind("intCodRol") %>'/>
            </ItemTemplate>
                        
            <EditItemTemplate>
            <asp:TextBox ID="txtEditCodRol" runat="server" Text='<%#Bind("intCodRol") %>'/>
            </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Rol">
            <ItemTemplate>
            <asp:Label ID="lblDescRol" runat="server" Text='<%#Bind("strDescripcion") %>'/>
            </ItemTemplate>
                        
            <EditItemTemplate>
            <asp:TextBox ID="txtEditDescRol" runat="server" Text='<%#Bind("strDescripcion") %>'/>
            </EditItemTemplate>
            </asp:TemplateField>




            <asp:TemplateField HeaderText="Password" Visible="False">
                        
            <ItemTemplate>
            <asp:Label ID="lblPassword" runat="server" Text='<%#Bind("strPassword") %>'/>
            </ItemTemplate>
                        
            <EditItemTemplate>
            <asp:TextBox ID="txtEditPassword" runat="server" Text='<%#Bind("strPassword") %>'/>
            </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Nombre">
                        
            <ItemTemplate>
            <asp:Label ID="lblNombre" runat="server" Text='<%#Bind("strNombre") %>'/>
            </ItemTemplate>
                        
            <EditItemTemplate>
            <asp:TextBox ID="txtEditNombre" runat="server" Text='<%#Bind("strNombre") %>'/>
            </EditItemTemplate>

            </asp:TemplateField>

            <asp:TemplateField HeaderText="Apellido">
                        
            <ItemTemplate>
            <asp:Label ID="lblApellido" runat="server" Text='<%#Bind("strApellido") %>'/>
            </ItemTemplate>
                        
            <EditItemTemplate>
            <asp:TextBox ID="txtEditApellido" runat="server" Text='<%#Bind("strApellido") %>'/>
            </EditItemTemplate>

            </asp:TemplateField>

            <asp:TemplateField HeaderText="Email">
                        
            <ItemTemplate>
            <asp:Label ID="lblEmailUsuario" runat="server" Text='<%#Bind("strEmailUsuario") %>'/>
            </ItemTemplate>
                        
            <EditItemTemplate>
            <asp:TextBox ID="txtEditEmailUsuario" runat="server" Text='<%#Bind("strEmailUsuario") %>'/>
            </EditItemTemplate>
            </asp:TemplateField>


            <asp:TemplateField HeaderText="Unidad" Visible="False">
            <ItemTemplate>
            <asp:Label ID="lblUnidad" runat="server" Text='<%#Bind("intCodUnidad") %>'/>
            </ItemTemplate>
                        
            <EditItemTemplate>
            <asp:TextBox ID="txtEditUnidad" runat="server" Text='<%#Bind("intCodUnidad") %>'/>
            </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Unidad">
            <ItemTemplate>
            <asp:Label ID="lblDesUnidad" runat="server" Text='<%#Bind("strDescUnidad") %>'/>
            </ItemTemplate>
                        
            <EditItemTemplate>
            <asp:TextBox ID="txtEditDesUnidad" runat="server" Text='<%#Bind("strDescUnidad") %>'/>
            </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Teléfono">
            <ItemTemplate>
            <asp:Label ID="lblTelefono" runat="server" Text='<%#Bind("strTelefono") %>'/>
            </ItemTemplate>
                        
            <EditItemTemplate>
            <asp:TextBox ID="txtEditTelefono" runat="server" Text='<%#Bind("strTelefono") %>'/>
            </EditItemTemplate>
            </asp:TemplateField>




             <asp:TemplateField HeaderText="Estado">
                        
            <ItemTemplate>
            <asp:Label ID="lblEstadoUsuario" runat="server" Text='<%#Bind("strEstadoUsuario") %>'/>
            </ItemTemplate>
                        
            <EditItemTemplate>
             <asp:CheckBox ID="chkEditEstadoUsuario" runat="server" EnableViewState="False" Text='<%# Bind("strEstadoUsuario") %>' />
            </EditItemTemplate>

            </asp:TemplateField>

            
           
                <asp:BoundField DataField="strNombreDepende" HeaderText="Depende" 
                    SortExpression="strNombreDepende" />

            
           
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="false" ForeColor="White" />
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

<div class ="span12"> <asp:ImageButton ID="btnGrabarUsuario" runat="server" ImageUrl="~/imagenes/boton.guardar.gif" onclick="btnGrabarUsuario_Click" /> &nbsp;
    <asp:ImageButton ID="BtnNuevoUsuario" runat="server" Height="23px" 
        ImageUrl="~/imagenes/nuevousuario.jpg" onclick="BtnNuevoUsuario_Click" 
        Width="24px" />
    </div>

    <div class ="span12"> </div>
</div>

<div class ="row-fluid">

<div class ="span12"> 
   
    </div>

    <div class ="span12"> </div>
</div>

</div>
   
    </div>
</asp:Content>
