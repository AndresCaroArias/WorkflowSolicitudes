<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BandejaEntrada.aspx.cs" Inherits="WorkflowSolicitudes.Presentacion.BandejaEntrada" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta name="viewport" content="width=device-width, initial-scale=1" />
     <link href="~/css/alertify.core.css" rel="stylesheet" type="text/css" />
    <link href="~/css/alertify.default.css" rel="stylesheet" type="text/css" id="toggleCSS"  />
    <link href="~/css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="~/css/custom.css" rel="stylesheet" type="text/css" />
    <link href="~/css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <img id="bg" src="../imagenes/LogoFondoVerde.jpg"  alt="background" /> 
    
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

<style>

textbox
{
    background: #FBFFDA;
    
    }
</style>



</script> 

    <div class="container">
<div class ="row-fluid">

<div class ="span12">

<div class ="well">
<h1 class="text-center">Sistema de Solicitudes</h1>
</div>
</div>
</div>
</head>
<body style="color: #003300; background-color: #33CC33">

<div class="container">

<div class ="row-fluid">
<div class ="span12"><h3 class="text-center"></h3></div>
</div>

<div class ="row-fluid">
<div class ="span3"></div>
<div class ="span3"></div>
<div class ="span3"><p class="text-left">Nombre:</p></div>
<div class ="span3"><asp:Label ID="lblNombre" runat="server"></asp:Label></div>
</div>

<div class ="row-fluid">
<div class ="span3"></div>
<div class ="span3"></div>
<div class ="span3"><p class="text-left">Carrera:</p></div>
<div class ="span3"><asp:Label ID="lblCarrera" runat="server"></asp:Label></div>
</div>

<div class ="row-fluid">
<div class ="span3"></div>
<div class ="span3"></div>
<div class ="span3"><p class="text-left">Jorada:</p></div>
<div class ="span3"><asp:Label ID="LblJornada" runat="server"></asp:Label></div>
</div>

<div class ="row-fluid">
<div class ="span12"></div>
</div>

<div class ="row-fluid">
<div class ="span3"></div>
<div class ="span3"></div>
<div class ="span3"><asp:HyperLink ID="HypNuevaSolicitud" runat="server" 
            NavigateUrl="~/Presentacion/NuevaSolicitud.aspx">Nueva Solicitud</asp:HyperLink></div>
<div class ="span3"></div>
</div>

<div class ="row-fluid">
<div class ="span3"></div>
<div class ="span3"></div>
<div class ="span3"><asp:Label ID="lblMensaje" runat="server" 
            style="font-weight: 700; color: #FF0000"></asp:Label></div>
<div class ="span3"></div>
</div>

<div class ="row-fluid">
<div class ="span12"></div>
</div>

<div class ="row-fluid">
<div class ="span4"></div>
<div class ="span8"> <form id="form1" runat="server">
<asp:Button runat="server" ID="Button1" ClientIDMode="Static" Style="display: none;" />
    <asp:Button runat="server" ID="Button2" ClientIDMode="Static" Style="display: none;" />


<asp:Button ID="PrchBtn" runat="server" class="PrchBtn" Text="Click Here" 
    OnClientClick="Confirm(); return false;" onclick="PrchBtn_Click" 
        Visible="False" /><asp:Button runat="server" ID="PrchBtnHiddenYes" ClientIDMode="Static" Style="display: none;" />
    <asp:Button runat="server" ID="PrchBtnHiddenNo" ClientIDMode="Static" Style="display: none;" />




<asp:GridView ID="GridView1" 
        runat="server" AutoGenerateColumns="False" 
        BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
        CellPadding="3" ForeColor="Black" GridLines="Vertical" DataKeyNames="intFolio"  
        onselectedindexchanged="GridView1_SelectedIndexChanged" 
            onrowdeleting="GridView1_RowDeleting" AllowPaging="True" 
            onpageindexchanging="GridView1_PageIndexChanging" AllowSorting="True" 
            onsorting="GridView1_Sorting" style="margin-left: 0px; font-size: small;" 
        Font-Bold="False" 
        EmptyDataText="No existen solicitudes para usted" Width="770px">
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
            <asp:CommandField ButtonType="Image" HeaderText="Ver Detalle" 
                SelectImageUrl="~/imagenes/lupa.gif" ShowHeader="True" 
                ShowSelectButton="True" />
            <asp:BoundField DataField="intFolio" HeaderText="Folio" 
                SortExpression="intFolio" />
            <asp:BoundField DataField="strDescripcionSolicitud" 
                HeaderText="Tipo de Solicitud" SortExpression="strDescripcionSolicitud" />
            <asp:BoundField DataField="dtmFechaSolicitud" HeaderText="Fecha Solicitud" 
                SortExpression="dtmFechaSolicitud" />
            <asp:BoundField DataField="strGlosaEstado" HeaderText="Estado" 
                SortExpression="strGlosaEstado" />
            <asp:BoundField DataField="dtmFechaResolucion" HeaderText="Fecha Respuesta" 
                SortExpression="dtmFechaResolucion" NullDisplayText="prueba" />
            <asp:BoundField DataField="strGlosaSolicitud" HeaderText="Comentarios" 
                SortExpression="strGlosaSolicitud" />
          <%--  <asp:CommandField DeleteImageUrl="~/imagenes/eliminar.gif" 
                HeaderText="Anular?" ShowDeleteButton="True" ShowHeader="True"  />--%>
                <asp:TemplateField>
<ItemTemplate>
<asp:LinkButton ID="delete" Runat="server" OnClientClick="Confirm(); return false;" onclick="PrchBtn_Click" CommandName="Delete">Anular
</asp:LinkButton>
</ItemTemplate>
</asp:TemplateField> 
        </Columns>
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="Gray" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />
    </asp:GridView></form></div>
</div>

</div>
<script src="../js/jquery.js" type="text/javascript"></script>
<script src="../js/bootstrap.js" type="text/javascript"></script>
<script src="../js/jquery-1.9.1.js" type="text/javascript"></script>
<script src="../js/alertify.min.js" type="text/javascript"></script>
    

    <script>
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";

            alertify.confirm('Esta seguro que desea eliminar', function (e) {
                if (e) {
                    $('#PrchBtnHiddenYes').click();
                    confirm_value.value = "Yes";

                } else {
                    $('#PrchBtnHiddenNo').click();
                    confirm_value.value = "No";
                }
            });
        }
    </script>    

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
    


</body>
</html>
