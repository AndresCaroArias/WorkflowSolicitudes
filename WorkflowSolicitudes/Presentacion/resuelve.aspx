<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="resuelve.aspx.cs" Inherits="WorkflowSolicitudes.Presentacion.resuelve" %>

<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

--%>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
 <link href="../css/alertify.core.css" rel="stylesheet" type="text/css" />
 <link href="../css/alertify.default.css" rel="stylesheet" type="text/css" id="toggleCSS" />
    <title></title>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div class="container">

<div class ="row-fluid">
<div class ="span12"><h3 class="text-center"> Resolver Actividad</h3></div>
</div>

<div class ="row-fluid">
<div class ="span3"><asp:Label ID="lblActividad" runat="server" 
                        style="font-size: large; color: #FF0000; font-weight: 700"></asp:Label></div>
<div class ="span3"><asp:HyperLink ID="HypAdjuntos" runat="server" style="font-weight: 700">[HypAdjuntos]</asp:HyperLink></div>
<div class ="span3"></div>
<div class ="span3"></div>
</div>

<div class ="row-fluid">
<div class ="span3"><p class="text-left">Datos del Solicitante:</p></div>
<div class ="span3"></div>
<div class ="span3"></div>
<div class ="span3"></div>
</div>

<div class ="row-fluid">
<div class ="span3"><p class="text-left">Nombre:</p></div>
<div class ="span3"><asp:Label ID="lblNombre" runat="server"></asp:Label></div>
<div class ="span3"><p class="text-left">Celular de contacto:</p></div>
<div class ="span3"><asp:Label ID="lblCelular" runat="server"></asp:Label></div>
</div>

<div class ="row-fluid">
<div class ="span3"><p class="text-left">Rut:</p></div>
<div class ="span3"><asp:Label ID="lblrut" runat="server"></asp:Label></div>
<div class ="span3"><p class="text-left">Correo Electronico:</p></div>
<div class ="span3"><asp:Label ID="lblCorreo" runat="server"></asp:Label></div>
</div>

<div class ="row-fluid">
<div class ="span3"><p class="text-left">Carrera:</p></div>
<div class ="span9"><asp:Label ID="lblCarrera" runat="server"></asp:Label></div>
</div>

<div class ="row-fluid">
<div class ="span12"></div>
</div>

<div class ="row-fluid">
<div class ="span3"><p class="text-left">Detalle Solicitud:</p></div>
<div class ="span3"></div>
<div class ="span3"></div>
<div class ="span3"></div>
</div>

<div class ="row-fluid">
<div class ="span3"><p class="text-left">Folio:</p></div>
<div class ="span3"><asp:Label ID="lblFolio" runat="server"></asp:Label></div>
<div class ="span3"><p class="text-left">Tipo solicitud:</p></div>
<div class ="span3"><asp:Label ID="lbltipoSolicitud" runat="server"></asp:Label></div>
</div>

<div class ="row-fluid">
<div class ="span3"><p class="text-left">Fecha Solicitud:</p></div>
<div class ="span3"><asp:Label ID="lblFechaSolicitud" runat="server"></asp:Label></div>
<div class ="span3"><p class="text-left">Fecha recepción:</p></div>
<div class ="span3"><asp:Label ID="lblFechaRecepcion" runat="server"></asp:Label></div>
</div>

<div class ="row-fluid">
<div class ="span12"><p class="text-left">Petición :</p></div>
</div>

<div class ="row-fluid">
<div class ="span12">
    <asp:TextBox ID="txtPeticion" runat="server" Height="65px" MaxLength="500" 
        ReadOnly="True" TextMode="MultiLine" Width="1021px" 
        style="margin-left: 5px"></asp:TextBox></div>
</div>

<div class ="row-fluid">
<div class ="span12"></div>
</div>

<div class ="row-fluid">
<div class ="span12"><asp:Label ID="lblDetalleResponsable" runat="server" 
        Text="Observaciones de las actividades anteriores:"></asp:Label></div>
</div>

<div class ="row-fluid">
<asp:Panel ID="Panel1" runat="server" Height="140px" 
        style="text-align: left; margin-left: 0px" Width="991px">
<div class ="span12">
    <asp:GridView ID="grvMostrarHistorial"
         runat="server" 
        AutoGenerateColumns="False" 
        BackColor="White" 
        BorderColor="#999999" 
        BorderStyle="Solid" 
        BorderWidth="1px" 
        CellPadding="3" 
        DataKeyNames="intSecuencia"
        ForeColor="Black" 
        GridLines="Vertical" 
        style="text-align: left; margin-left: 0px; margin-right: 24px;" 
        
        onselectedindexchanged="grvMostrarHistorial_SelectedIndexChanged"
        emptydatatext="No existen datos en la Grilla" Font-Bold="False" 
        Width="1038px">

            <emptydatarowstyle backcolor="#B2E389" forecolor="Red"/>
        <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
                <asp:BoundField DataField="intEtapa" HeaderText="Etapa" 
                    SortExpression="intEtapa" />
                <asp:BoundField DataField="strGlosaActividad" HeaderText="Actividad" 
                    SortExpression="strGlosaActividad" />
                <asp:BoundField DataField="strDescUnidad" HeaderText="Unidad responsable" 
                    SortExpression="strDescUnidad" />
                <asp:BoundField DataField="strnombre" HeaderText="Nombre" 
                    SortExpression="strnombre" />
                <asp:BoundField DataField="DtmFechaResolucion" 
            HeaderText="Fecha Resolución" SortExpression="DtmFechaResolucion" />
                <asp:BoundField DataField="StrGlosaDetalleSolictud" 
            HeaderText="Observación" SortExpression="StrGlosaDetalleSolictud" />
                <asp:ButtonField ButtonType="Image" CommandName="Select" 
                    HeaderText="Ver Adjuntos" ImageUrl="~/imagenes/lupa.gif" ShowHeader="True" 
                    Text="Ver" />
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" 
        ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" 
        HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" 
        ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="Gray" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView> </div></asp:Panel>
</div>

<div class ="row-fluid"><asp:Panel ID="Panel2" runat="server">
<div class ="span4"><asp:Label ID="lblAprobar" runat="server" style="font-weight: 700">Usted desea Aprobar(Si) o Rechazar(No) la Actividad?</asp:Label></div>
<div class ="span4"><asp:RadioButton ID="RbtSI" runat="server" GroupName="Resolver" Text="Si" 
                    style="text-align: center" />
                               
                    <asp:RadioButton ID="RbtNO" runat="server" GroupName="Resolver" Text="No" 
                    style="text-align: center" /></div>
<div class ="span4"></div></asp:Panel>
</div>



<div class ="row-fluid">
<div class ="span12"><p class="text-left">Ingrese un comentario

<div class ="row-fluid">
<div class ="span12"><p class="text-left">* Este comentario será visualizado por el 
    Solicitante:</p></div>
</div>

<div class ="row-fluid">
<div class ="span12"> 
    <asp:TextBox ID="txtResolucion" runat="server" Height="90px" 
        TextMode="MultiLine" Width="1028px" 
        style="margin-left: 3px; margin-top: 0px"></asp:TextBox></div>
</div>

<div class ="row-fluid">
<div class ="span12"><p class="text-left">Haga click en el botón Completar para cerrar y finalizar la tarea.</p></div>
</div>

<div class ="row-fluid">
<div class ="span12"><asp:Label ID="Label2" runat="server" style="font-weight: 700" 
        Text="Seleccionar Archivo"></asp:Label></div>
</div>

<div class ="row-fluid">
<div class ="span4"><asp:FileUpload ID="ImagenFile" runat="server" Height="22px"/></div>
<div class ="span4"><asp:Button ID="btnSubir" runat="server" onclick="btnSubir_Click" 
        Text="Subir" /></div>
<div class ="span4"></div>

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
        style="text-align: center" Font-Bold="False">
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

            <asp:TemplateField HeaderText="Secuencia">
                <ItemTemplate>
                    <asp:Label ID="Secuencia" runat="server" Text='<%#Bind("intSecuencia") %>' />
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
<div class ="span12"></div>
</div>


<div class ="row-fluid">
<div class ="span4"><asp:Button ID="BtnCompletar" runat="server" Text="Completar" 
        onclick="BtnCompletar_Click" />    </div>
<div class ="span4"><asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" 
        onclick="BtnCancelar_Click" /></div>
<div class ="span4"><asp:Label ID="lblMensaje" runat="server" 
        style="font-weight: 700; color: #FF0000"></asp:Label></div>
</div>

</div>



    <form id="form1">
    
    
    <br />
    <br />
    
    &nbsp;&nbsp;&nbsp;
    
    <br />
    <br />
   
    <br />
    <br />
    <br />
    
    </form>

</asp:Content>
