<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NuevaContraseña.aspx.cs" Inherits="WorkflowSolicitudes.Formulario_web15" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
 <link href="../css/alertify.core.css" rel="stylesheet" type="text/css" />
 <link href="../css/alertify.default.css" rel="stylesheet" type="text/css" id="toggleCSS" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    

<div class="container">

<div class ="row-fluid">
<div class ="span12"></div>
</div>



<div class ="row-fluid">
<div class ="span3"></div>
<div class ="span3"><p class="text-left">Insertar Nueva Clave:</p></div>
<div class ="span3"><asp:TextBox ID="txtNuevaClave" runat="server" Height="22px" Width="193px" 
                    TextMode="Password"></asp:TextBox>
    </div>
<div class ="span3"></div>
</div>

<div class ="row-fluid">
<div class ="span3"></div>
<div class ="span3"><p class="text-left">Repetir Nueva Clave:</p></div>
<div class ="span3"> <asp:TextBox ID="txtRepetirClave" runat="server" Height="22px" Width="193px" 
                    TextMode="Password"></asp:TextBox>
           </div>
<div class ="span3"></div>
</div>

<div class ="row-fluid">
<div class ="span3"></div>
<div class ="span3"><asp:Button ID="btnCambiarClave" runat="server" Text="Cambiar Contraseña" 
                    Width="281px" onclick="btnCambiarClave_Click" /></div>
<div class ="span3"></div>
<div class ="span3"></div>
</div>

<div class ="row-fluid">
<div class ="span12"><asp:Label ID="LblMensaje" runat="server" 
                style="font-weight: 700; color: #FF0000"></asp:Label></div>
</div>

</div> 
  
</asp:Content>

