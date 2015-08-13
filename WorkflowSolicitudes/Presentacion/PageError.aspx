<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PageError.aspx.cs" Inherits="WorkflowSolicitudes.Presentacion.PageError" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="~/css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="~/css/custom.css" rel="stylesheet" type="text/css" />
   <link href="~/css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />

   <link href="../css/alertify.core.css" rel="stylesheet" type="text/css" />
 <link href="../css/alertify.default.css" rel="stylesheet" type="text/css" id="toggleCSS" />
    
 <img id="bg" src="../imagenes/LogoFondoVerde.jpg"  alt="background" /> 

 <meta name="viewport" content="width=device-width">

 <style>
		.alertify-log-custom {
			background: blue;
		}
	</style>
    
 <style type="text/css">
    .well{
background-color: rgb(7, 125, 28);
}

#bg{
    position:fixed;
    top:0;
    left:0;
    z-index:-1;
}

h1   {color:white}



</style>

<div class="container">
<div class ="row-fluid">

<div class ="span12">

<div class ="well">
<h1 class="text-center" >Workflow Solicitudes V.2.0</h1>
</div>
</div>
</div>

<asp:Label ID="lblError" runat="server"></asp:Label>
</asp:Content>
