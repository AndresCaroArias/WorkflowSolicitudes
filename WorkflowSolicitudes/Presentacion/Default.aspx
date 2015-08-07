<%@ Page Title="Página principal" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="WorkflowSolicitudes._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
   <img id="bg" src="../imagenes/LogoFondoVerde.jpg"  alt="background" /> 
    
    <style type="text/css">


#bg{
    position:fixed;
    top:0;
    left:0;
    z-index:-1;
}





</style>

</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">


<div class="container">

<div class ="row-fluid">

<div class ="row-fluid">
<div class ="span3"></div>
<div class ="span3"></div>
<div class ="span6"><h1 class="text-center"> Workflow Solicitudes</h1></div>

</div>
<div class ="row-fluid">
<div class ="span12"></div>
</div>
<div class ="row-fluid">
<div class ="span12"></div>
</div>

<div class ="row-fluid">
<div class ="span3"></div>
<div class ="span3"></div>
<div class ="span3"><h4 class="text-left">Bienvenido Sr(a):</h4></div>
<div class ="span3"></div>
</div>



<div class ="row-fluid">
<div class ="span3"></div>
<div class ="span3"></div>
<div class ="span6"><h2 class="text-left"><asp:Label ID="lblNombre" runat="server" CssClass="style1"></asp:Label>
&nbsp;<asp:Label ID="lblApellido" runat="server" CssClass="style1"></asp:Label>&nbsp;&nbsp;&nbsp; </h2></div>



</div>

<div class ="row-fluid">
<div class ="span3"></div>
<div class ="span3"></div>
<div class ="span6"><h4 class="text-left"><asp:Label ID="lblUnidad" runat="server" CssClass="style1"></asp:Label>
&nbsp;</h4></div>
</div>


</div>


</div>

    <h1>
                            
        
    </h1>

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

    
</asp:Content>
