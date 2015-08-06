<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master"  CodeBehind="NuevaSolicitudInterna.aspx.cs" Inherits="WorkflowSolicitudes.Presentacion.NuevaSolicitudInterna" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<link href="../css/alertify.core.css" rel="stylesheet" type="text/css" />
 <link href="../css/alertify.default.css" rel="stylesheet" type="text/css" id="toggleCSS" />
  

<title>Nueva Solicitud</title>
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="container">

<div class ="row-fluid">
<div class ="span4"> <asp:Label ID="LblNuevasolicitud" runat="server" 
                                style="color: #FF0000; font-weight: 700; font-size: large" 
                                Text="Ingreso de Nueva Solicitud"></asp:Label></div>
<div class ="span4"><asp:Image ID="Image1" runat="server" ImageUrl="~/imagenes/logoCiisa.gif" 
                                style="margin-left: 265px; text-align: center;" Width="26px" /></div>
<div class ="span4"></div>
</div>


<div class ="row-fluid">
<div class ="span4"><p class="text-left">Nombre:</p></div>
<div class ="span4"><asp:Label ID="lblNombre" runat="server"> </asp:Label></div>
<div class ="span4"></div>
</div>

<div class ="row-fluid">
<div class ="span4"><p class="text-left">Rol:</p></div>
<div class ="span4"><asp:Label ID="lblCargo" runat="server"></asp:Label></div>
<div class ="span4"></div>
</div>

<div class ="row-fluid">
<div class ="span4"><p class="text-left">Unidad:</p></div>
<div class ="span4"><asp:Label ID="lblUnidad" runat="server"></asp:Label></div>
<div class ="span4"></div>
</div>


<div class ="row-fluid">
<div class ="span4"><p class="text-left">Tipo de Solicitud:</p></div>
<div class ="span4"><asp:DropDownList ID="ddlTipoSolicitud" runat="server" Height="22px" Width="407px" onselectedindexchanged="ddlTipoSolicitud_SelectedIndexChanged"></asp:DropDownList></div>
<div class ="span4"></div>
</div>

<div class ="row-fluid">
<div class ="span12"><p class="text-left">Solicitud:</p></div>
</div>

<div class ="row-fluid">
<div class ="span12">
    <asp:TextBox ID="txtpeticion" runat="server" Height="84px" MaxLength="500" 
        TextMode="MultiLine" Width="400px"></asp:TextBox>
    </div>
</div>

<div class ="row-fluid">
<div class ="span2"><asp:Label ID="Label3" runat="server" style="font-weight: 700" 
                        Text="Seleccionar Archivo"></asp:Label></div>
<div class ="span2"><asp:FileUpload ID="ImagenFile" runat="server" Height="22px"/></div>
<div class ="span2"></div>
<div class ="span6"><asp:Button ID="btnSubir" runat="server" onclick="btnSubir_Click" 
                            Text="Subir" /></div>
</div>

<div class ="row-fluid">
<div class ="span12"></div>
</div>


<div class ="row-fluid">

<div class ="span2"><asp:Button ID="BtnEnviar" runat="server" onclick="BtnEnviar_Click" 
                            Text="Enviar" /></div>
<div class ="span2"><asp:Button ID="BtnLimpiar" runat="server" CausesValidation="False" 
                            onclick="BtnLimpiar_Click" Text="Limpiar" /></div>

<div class ="span8"></div>


</div>

<div class ="row-fluid">
<div class ="span12"> <asp:Label ID="LblMensaje" runat="server" 
                            style="font-weight: 700; color: #FF0000"></asp:Label></div>
</div>

<div class ="row-fluid">
<div class ="span12"> <asp:Label ID="lblError0" runat="server" style="font-weight: 700"></asp:Label></div>
</div>

<div class ="row-fluid">
<div class ="span12">
    <asp:GridView ID="grvAdjunto" runat="server" AllowPaging="True" 
                            AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" 
                            BorderStyle="Solid" BorderWidth="1px" CellPadding="3" 
                            DataKeyNames="intIdArchivo" ForeColor="Black" GridLines="Vertical" 
                            onpageindexchanging="grvAdjunto_PageIndexChanging" 
                            onrowcancelingedit="grvAdjunto_RowCancelingEdit" 
                            onrowdeleting="grvAdjunto_RowDeleting" onrowediting="grvAdjunto_RowEditing" 
                            onrowupdating="grvAdjunto_RowUpdating" 
                            
        onselectedindexchanged="grvAdjunto_SelectedIndexChanged" PageSize="3" 
                            style="text-align: center" Width="457px" 
        Font-Bold="False">

                            <emptydatarowstyle backcolor="#B2E389" forecolor="Red"/>
                            <AlternatingRowStyle BackColor="#CCCCCC" />
                            <Columns>
                                <asp:ButtonField ButtonType="Image" CommandName="Select" HeaderText="Ver Pdf" 
                                    ImageUrl="~/imagenes/lupa.gif" ShowHeader="True" Text="Ver" />
                                <asp:CommandField ButtonType="Image" DeleteImageUrl="~/imagenes/eliminar.gif" 
                                    DeleteText="Eliminar " HeaderText="Eliminar Adjunto" ShowDeleteButton="True" />
                                <asp:TemplateField HeaderText="Nonbres Archivos Adjuntos">
                                    <ItemTemplate>
                                        <asp:Label ID="NombreArchivo" runat="server" 
                                            Text='<%#Bind("strNombreArchivo") %>' />
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

</div>

  
   
</asp:Content>