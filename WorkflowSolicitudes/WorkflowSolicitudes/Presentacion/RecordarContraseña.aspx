<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecordarContraseña.aspx.cs" Inherits="WorkflowSolicitudes.Presentacion.RecordarContraseña" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="~/css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="~/css/custom.css" rel="stylesheet" type="text/css" />
    <link href="~/css/Well.css" rel="stylesheet" type="text/css" />
    <link href="~/css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    
    <img id="bg" src="../imagenes/LogoFondoVerde.jpg"  alt="background" /> 
    
    <style type="text/css">


#bg{
    position:fixed;
    top:0;
    left:0;
    z-index:-1;
}

h1   {color:white}



</style>

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
<body style="color: #003300; background-color: #33CC33">

 <div class="form-group">
<form id="form1"  runat="server">


<div class="container">

<div class ="row-fluid">
<div class ="span3"></div>
<div class ="span3"></div>
<div class ="span3"><h3 class="text-center">Recuperar Contraseña</h3></div>
<div class ="span3"></div>

</div>

<div class ="row-fluid">
<div class ="span12"></div>
</div>

<div class ="row-fluid">
<div class ="span12">&nbsp;</div>
</div>

<div class ="row-fluid">
<div class ="span3"></div>
<div class ="span3"></div>
<div class ="span3"><p class="text-left">Insertar Rut:</p><asp:TextBox ID="txtRutUsuario" runat="server" Height="22px" Width="195px" placeholder="Rut Usuario"></asp:TextBox></div>
<div class ="span3"></div>


</div>
<div class ="row-fluid">
<div class ="span12"></div>
</div>
<div class ="row-fluid">
<div class ="span3"></div>
<div class ="span3"></div>
<div class ="span3"><asp:Button ID="btnRestituir" runat="server" Text="Restituir Contraseña" Width="281px" 
                    onclick="btnRestituir_Click" /><asp:LinkButton ID="lnkRegresar" runat="server" 
                    PostBackUrl="~/Presentacion/Login.aspx">Regresar</asp:LinkButton></div>
<div class ="span3"> <asp:Label ID="LblMensaje" runat="server" 
                style="font-weight: 700; color: #FF0000"></asp:Label></div>
</div>

</div>







  
    </div>
    </form>

    <script> 

window.onload = function() {



	function bgadj(){
		
		
		var element = document.getElementById("bg");
		
		var ratio =  element.width / element.height;	
		
		if ((window.innerWidth / window.innerHeight) < ratio){
		
			element.style.width = 'auto';
			element.style.height = '100%';
			
			<!-- si la imagen es mas ancha que la ventana la centro -->
			if (element.width > window.innerWidth){
			
				var ajuste = (window.innerWidth - element.width)/2;
				
				element.style.left = ajuste+'px';
			
			}
		
		}
		else{	
		
			element.style.width = '100%';
			element.style.height = 'auto';
			element.style.left = '0';

		}
		
	}
<!-- llamo a la función bgadj() por primera vez al terminar de cargar la página -->
	bgadj();
	<!-- vuelvo a llamar a la función  bgadj() al redimensionar la ventana -->
	window.onresize = function() { 
		bgadj();

	}

}

</script> 
</body>
</html>
