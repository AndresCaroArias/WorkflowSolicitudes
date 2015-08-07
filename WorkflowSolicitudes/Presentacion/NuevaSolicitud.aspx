<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NuevaSolicitud.aspx.cs" Inherits="WorkflowSolicitudes.Presentacion.NuevaSolicitud" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml"
<head runat="server">
<meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="~/css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="~/css/custom.css" rel="stylesheet" type="text/css" />
    <link href="~/css/colorWell.css" rel="stylesheet" type="text/css" />
    <link href="~/css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="~/css/alertify.core.css" rel="stylesheet" type="text/css" />
    <link href="~/css/alertify.default.css" rel="stylesheet" type="text/css" id="toggleCSS" />
    <title>Elevación de Solicitud Alumnos</title> 

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
    <p>
    </p>
    <form id="form1" runat="server">

 <div class="container">

<div class ="row-fluid">
<div class ="span12"><h3 class="text-center">Nueva Solicitud</h3></div>
</div>

<div class ="row-fluid">
<div class ="span12"><asp:Label ID="LblNuevasolicitud" runat="server" 
                                style="color: #FF0000; font-weight: 700; font-size: large" 
                                Text="Ingreso de Nueva Solicitud"></asp:Label></div>
</div>

<div class ="row-fluid">
<div class ="span3"><asp:Label ID="LblCelularContacto" runat="server" style="font-weight: 700" 
                Text="Celular de Contacto : "></asp:Label></div>
<div class ="span3"><asp:TextBox ID="txtCelularContacto" runat="server"  Height="22px" MaxLength="10" 
                ></asp:TextBox></div>
<div class ="span3"></div>
<div class ="span3"></div>
</div>

<div class ="row-fluid">
<div class ="span3"><asp:Label ID="lnlCorreoElectronico" runat="server" style="font-weight: 700" 
                Text="Correo Electronico : "></asp:Label></div>
<div class ="span3"><asp:TextBox ID="txtCorreo" runat="server"  Height="22px"></asp:TextBox>
            </div>
<div class ="span3"></div>
<div class ="span3"></div>
</div>

<div class ="row-fluid">
<div class ="span3"><asp:Label ID="lblTipoSolicitud" runat="server" style="font-weight: 700" 
                Text="Tipo De Solicitud :"></asp:Label></div>
<div class ="span3"><asp:DropDownList ID="ddlTipoSolicitud" runat="server" 
                Height="22px" Width="380px" AutoPostBack="True" 
                onload="ddlTipoSolicitud_Load" 
                onselectedindexchanged="ddlTipoSolicitud_SelectedIndexChanged" 
                ontextchanged="ddlTipoSolicitud_TextChanged">
            </asp:DropDownList></div>
<div class ="span3"></div>
<div class ="span3"></div>
</div>

<div class ="row-fluid">
<div class ="span12"><asp:Label ID="lblPeticion" runat="server" style="font-weight: 700" 
                Text="Petición        :"></asp:Label></div>
</div>

<div class ="row-fluid">
<div class ="span12"><asp:TextBox ID="Txtpeticion" runat="server"  Height="142px" 
                style="margin-left: 0px" TextMode="MultiLine" Width="378px" 
        MaxLength="500"></asp:TextBox>
            </div>
</div>

<div class ="row-fluid">
<div class ="span12"></div>
</div>

<div class ="row-fluid">
<div class ="span2"><asp:Label ID="Label2" runat="server" Text="Seleccionar Archivo" 
                        style="font-weight: 700"></asp:Label></div>
<div class ="span2"><asp:FileUpload ID="ImagenFile" runat="server" Height="22px"/>
                    </div>
<div class ="span2"></div>
<div class ="span6"><asp:Button ID="btnSubir" runat="server" onclick="btnSubir_Click" 
                        Text="Subir" /></div>
</div>

<div class ="row-fluid">
<div class ="span3"></div>
<div class ="span3"></div>
<div class ="span3"></div>
<div class ="span3"></div>
</div>


<div class ="row-fluid">
<div class ="span12">
    <asp:GridView ID="grvAdjunto" runat="server"  
        AutoGenerateColumns="False" AllowPaging="True"
        BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
        CellPadding="3" ForeColor="Black" GridLines="Vertical"  
        onpageindexchanging="grvAdjunto_PageIndexChanging" 
        onrowcancelingedit="grvAdjunto_RowCancelingEdit"
        onrowdeleting="grvAdjunto_RowDeleting" 
        onrowediting="grvAdjunto_RowEditing"
        onrowupdating="grvAdjunto_RowUpdating" 
        DataKeyNames="intIdArchivo" 
        onselectedindexchanged="grvAdjunto_SelectedIndexChanged" PageSize="3" 
                style="text-align: center" Font-Bold="False">

            <emptydatarowstyle backcolor="#B2E389" forecolor="Red"/>
        <AlternatingRowStyle BackColor="#CCCCCC" />

        <Columns>
               <asp:ButtonField ButtonType="Image" CommandName="Select" 
                   ImageUrl="~/imagenes/lupa.gif" ShowHeader="True" Text="Ver" 
                   HeaderText="Ver Pdf" />
                <asp:CommandField ButtonType="Image" DeleteImageUrl="~/imagenes/eliminar.gif" 
                    ShowDeleteButton="True" HeaderText="Eliminar Adjunto" 
                   DeleteText="Eliminar " />
            

             <asp:TemplateField HeaderText="Nonbres Archivos Adjuntos">

            <ItemTemplate>
            <asp:Label ID="NombreArchivo" runat="server" Text='<%#Bind("strNombreArchivo") %>'/>
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

<div class ="row-fluid">
<div class ="span2">
    <asp:Button ID="BtnEnviar" runat="server" Text="Enviar" 
                onclick="BtnEnviar_Click" Width="78px" /></div>
<div class ="span2">
    <asp:Button ID="BtnLimpiar" runat="server" CausesValidation="False" 
                Text="Limpiar" Width="78px" onclick="BtnLimpiar_Click" /></div>
<div class ="span2"><asp:Label ID="LblMensaje" runat="server" 
                style="font-weight: 700; color: #FF0000"></asp:Label></div>
<div class ="span2"></div>
<div class ="span2"></div>
<div class ="span2"></div>
</div>



<div class ="row-fluid">
<div class ="span12"></div>
</div>

<div class ="row-fluid">
<div class ="span12"><asp:HyperLink ID="HyperLink1" runat="server" 
                NavigateUrl="~/Presentacion/BandejaEntrada.aspx">Volver </asp:HyperLink></div>
</div>

<div class ="row-fluid">
<div class ="span12"><asp:Label ID="lblError" runat="server" style="font-weight: 700"></asp:Label></div>
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
