<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PageErrorE.aspx.cs" Inherits="WorkflowSolicitudes.Presentacion.PageErrorE" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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

   

 </head>
	
    <title></title>
</head>
<body style="color: #003300; background-color: #33CC33" >
    <form id="form1" runat="server" >
    <div>
            <asp:Label ID="lblError" runat="server" Text="Label"></asp:Label>
    </div>
    </form>
</body>
</html>
