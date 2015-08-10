<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BuscadorPersonas.aspx.cs" Inherits="WorkflowSolicitudes.Presentacion.BuscadorPersonas" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

<meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="~/css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="~/css/custom.css" rel="stylesheet" type="text/css" />
    <link href="~/css/colorWell.css" rel="stylesheet" type="text/css" />
    <link href="~/css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />

    <title></title>

    <style>
body {
    background: #B2E389;
}

textbox
{
    background: #FBFFDA;
    
    }
</style>
  
</head>
<body>
<form id="form1" runat="server"> 

 <div class="container">

<div class ="row-fluid">
<div class ="span12"><h3 class="text-center">Buscador de Personas</h3></div>
</div>

<div class ="row-fluid">
<div class ="span4"><p class="text-left">Nombre:</p></div>
<div class ="span4"><asp:TextBox ID="txtNombreUsuario" runat="server" Height="22px"></asp:TextBox>
                    
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:ImageButton ID="ImageButton3" runat="server" 
                        ImageUrl="~/imagenes/lupa.gif" onclick="ImageButton3_Click" /></div>
<div class ="span4"><asp:TextBox ID="txtRecibe" runat="server" Height="22px"></asp:TextBox></div>
</div>

<div class ="row-fluid">
<div class ="span12"></div>
</div>


<div class ="row-fluid">
<div class ="span12">
    <asp:GridView ID="grvBuscaPersonas" runat="server"  
        AutoGenerateColumns="False" AllowPaging="True"
        BackColor="White" BorderColor="#999999" 
		BorderStyle="Solid" BorderWidth="1px" 
        CellPadding="5" ForeColor="Black" 
		GridLines="Vertical"  
        onpageindexchanging="grvBuscaPersonas_PageIndexChanging" 
        onrowcancelingedit="grvBuscaPersonas_RowCancelingEdit"
        onrowdeleting="grvBuscaPersonas_RowDeleting" 
        onrowediting="grvBuscaPersonas_RowEditing"
        onrowupdating="grvBuscaPersonas_RowUpdating" 
        DataKeyNames="strRutUsuario" 
        onselectedindexchanged="grvBuscaPersonas_SelectedIndexChanged" 
            onselectedindexchanging="grvBuscaPersonas_SelectedIndexChanging" 
            onrowcommand="grvBuscaPersonas_RowCommand"
            emptydatatext="No existen datos para la consulta realizada" 
        Font-Bold="False">

            <emptydatarowstyle backcolor="#B2E389" forecolor="Red"/>
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
                
            <asp:TemplateField HeaderText="Rut Usuario">

            <ItemTemplate>
            <asp:Label ID="lblRutUsuario" runat="server" Text='<%#Bind("strRutUsuario") %>'/>
            </ItemTemplate>
            
            </asp:TemplateField>
                        

            

            <asp:TemplateField HeaderText="Nombre">
                        
            <ItemTemplate>
            <asp:Label ID="lblNombre" runat="server" Text='<%#Bind("strNombre") %>'/>
            </ItemTemplate>                   
            
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Apellido">
                        
            <ItemTemplate>
            <asp:Label ID="lblApellido" runat="server" Text='<%#Bind("strApellido") %>'/>
            </ItemTemplate>                        
            
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Email">
                        
            <ItemTemplate>
            <asp:Label ID="lblEmailUsuario" runat="server" Text='<%#Bind("strEmailUsuario") %>'/>
            </ItemTemplate>
                        
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Rol">
                        
            <ItemTemplate>
            <asp:Label ID="lblCodRol" runat="server" Text='<%#Bind("intCodRol") %>'/>
            </ItemTemplate>                        
           
            </asp:TemplateField>                   
            
           
            <asp:CommandField SelectImageUrl="~/imagenes/editar.gif" 
                ShowSelectButton="True" />

                   
            
           
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
    </asp:GridView>   </div>
</div>

</div>

</form>
</body>
</html>
