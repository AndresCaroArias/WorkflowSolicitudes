<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WorkflowSolicitudes.Presentacion.loginWorkFlow" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server" >
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

<body style="color: #003300; background-color: #33CC33">


<form id="form1"  runat="server">


<div class="container">

<div class ="row-fluid">
<div class ="span3"></div>
<div class ="span3"></div>
<div class ="span3"><h3 class="text-center"> Bienvenido Login Workflow Solicitudes</h3></div>
<div class ="span3"></div>

</div>

<div class ="row-fluid">
<div class ="span12">&nbsp;</div>
</div>

</div>



<div class ="row-fluid">
<div class ="span3"></div>
<div class ="span3"></div>
<div class ="span3"><p class="text-left">Rut Usuario:</p><asp:TextBox ID="TxtUsuario" runat="server" 
        class="col-sm-2 control-label" xLength="10" placeholder="Rut Usuario" 
        Width="152px" /></div>
<div class ="span3"><asp:Label ID="LblUsuario" runat="server" class="col-sm-2 control-label" Text=""></asp:Label></div>
</div>

<div class ="row-fluid">
<div class ="span3"></div>
<div class ="span3"></div>
<div class ="span3"><p class="text-left">Password :</p><asp:TextBox ID="TxtPassword" runat="server" class="col-sm-2 control-label" MaxLength="10" placeholder="Password" TextMode="Password" height="22px" Width="152px"/></div>
<div class ="span3"><asp:Label ID="LblPassword" runat="server" class="col-sm-2 control-label" Text="" CssClass="style11"></asp:Label></div>
</div>



<div class ="row-fluid">
<div class ="span12">&nbsp;</div>
</div>

<div class ="row-fluid">
<div class ="span3"></div>
<div class ="span3"></div>
<div class ="span3"><asp:ImageButton ID="IBtnLogin" runat="server" class="left-block" ImageUrl="~/imagenes/login.gif" onclick="ValidaUsuario" />&nbsp &nbsp<asp:LinkButton ID="lnkRecordarContraseña" runat="server" onclick="lnkRecordarContraseña_Click" PostBackUrl="~/Presentacion/RecordarContraseña.aspx"  style="color: #000099; font-weight: 700">¿Olvido su contraseña?</asp:LinkButton></div>
<div class ="span3"><asp:Label ID="LblError" runat="server" ForeColor="Red" /></div>
</div>

</div> 

<script src="../js/jquery-1.9.1.js" type="text/javascript"></script>
<script src="../js/alertify.min.js" type="text/javascript"></script>
      	

	<script>
	    function reset() {
	        $("#toggleCSS").attr("href", "../css/alertify.default.css");
	        alertify.set({
	            labels: {
	                ok: "OK",
	                cancel: "Cancel"
	            },
	            delay: 5000,
	            buttonReverse: false,
	            buttonFocus: "ok"
	        });
	    }

	    // ==============================
	    // Standard Dialogs
	    $("#alert").on('click', function () {
	        reset();
	        alertify.alert("This is an alert dialog");
	        return false;
	    });

	    $("#confirm").on('click', function () {
	        reset();
	        alertify.confirm("This is a confirm dialog", function (e) {
	            if (e) {
	                alertify.success("You've clicked OK");
	            } else {
	                alertify.error("You've clicked Cancel");
	            }
	        });
	        return false;
	    });

	    $("#prompt").on('click', function () {
	        reset();
	        alertify.prompt("This is a prompt dialog", function (e, str) {
	            if (e) {
	                alertify.success("You've clicked OK and typed: " + str);
	            } else {
	                alertify.error("You've clicked Cancel");
	            }
	        }, "Default Value");
	        return false;
	    });

	    // ==============================
	    // Ajax
	    $("#ajax").on("click", function () {
	        reset();
	        alertify.confirm("Confirm?", function (e) {
	            if (e) {
	                alertify.alert("Successful AJAX after OK");
	            } else {
	                alertify.alert("Successful AJAX after Cancel");
	            }
	        });
	    });

	    // ==============================
	    // Standard Dialogs
	    $("#notification").on('click', function () {
	        reset();
	        alertify.log("Standard log message");
	        return false;
	    });

	    $("#success").on('click', function () {
	        reset();
	        alertify.success("Success log message");
	        return false;
	    });

	    $("#error").on('click', function () {
	        reset();
	        alertify.error("Error log message");
	        return false;
	    });

	    // ==============================
	    // Custom Properties
	    $("#delay").on('click', function () {
	        reset();
	        alertify.set({ delay: 10000 });
	        alertify.log("Hiding in 10 seconds");
	        return false;
	    });

	    $("#forever").on('click', function () {
	        reset();
	        alertify.log("Will stay until clicked", "", 0);
	        return false;
	    });

	    $("#labels").on('click', function () {
	        reset();
	        alertify.set({ labels: { ok: "Accept", cancel: "Deny"} });
	        alertify.confirm("Confirm dialog with custom button labels", function (e) {
	            if (e) {
	                alertify.success("You've clicked OK");
	            } else {
	                alertify.error("You've clicked Cancel");
	            }
	        });
	        return false;
	    });

	    $("#focus").on('click', function () {
	        reset();
	        alertify.set({ buttonFocus: "cancel" });
	        alertify.confirm("Confirm dialog with cancel button focused", function (e) {
	            if (e) {
	                alertify.success("You've clicked OK");
	            } else {
	                alertify.error("You've clicked Cancel");
	            }
	        });
	        return false;
	    });

	    $("#order").on('click', function () {
	        reset();
	        alertify.set({ buttonReverse: true });
	        alertify.confirm("Confirm dialog with reversed button order", function (e) {
	            if (e) {
	                alertify.success("You've clicked OK");
	            } else {
	                alertify.error("You've clicked Cancel");
	            }
	        });
	        return false;
	    });

	    // ==============================
	    // Custom Log
	    $("#custom").on('click', function () {
	        reset();
	        alertify.custom = alertify.extend("custom");
	        alertify.custom("I'm a custom log message");
	        return false;
	    });

	    // ==============================
	    // Custom Themes
	    $("#bootstrap").on('click', function () {
	        reset();
	        $("#toggleCSS").attr("href", "../css/alertify.bootstrap.css");
	        alertify.prompt("Prompt dialog with bootstrap theme", function (e) {
	            if (e) {
	                alertify.success("You've clicked OK");
	            } else {
	                alertify.error("You've clicked Cancel");
	            }
	        }, "Default Value");
	        return false;
	    });
    </script>  

</div> 
</form>
 
</body>
</html>
