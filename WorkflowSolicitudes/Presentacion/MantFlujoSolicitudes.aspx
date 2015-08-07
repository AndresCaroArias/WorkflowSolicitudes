<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MantFlujoSolicitudes.aspx.cs" Inherits="WorkflowSolicitudes.Formulario_web12" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

<link href="../css/alertify.core.css" rel="stylesheet" type="text/css" />
 <link href="../css/alertify.default.css" rel="stylesheet" type="text/css" id="toggleCSS" />


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


<div class="container">

<div class ="row-fluid">
<div class ="span12"><h3 class="text-center">Mantenedor de Flujos de Solicitudes</h3></div>
</div>

<div class ="row-fluid">

<div class ="span4"><asp:Label ID="lblSelSolicitud" runat="server" style="font-weight: 700" Text="Seleccione tipo de solicitud"></asp:Label></div>

<div class ="span4">
<asp:DropDownList ID="ddlTipoSolicitudes" runat="server" Height="22px" Width="397px" onselectedindexchanged="ddlTipoSolicitudes_SelectedIndexChanged"></asp:DropDownList>
</div>
<div class ="span1"></div>

<div class ="span3"><asp:ImageButton ID="BtnNuevo" runat="server" Height="31px" ImageUrl="~/imagenes/agregar.gif" onclick="BtnNuevo_Click" Width="31px" /></div>


</div>



<div class ="row-fluid">
<div class ="span4"><asp:Label ID="lblSecuencia" runat="server" CssClass="bold" Text="Secuencia"></asp:Label></div>
<div class ="span4"><asp:TextBox ID="txtSecuencia" runat="server" Height="22px" Width="21px"></asp:TextBox></div>
<div class ="span4"></div>
</div>

<div class ="row-fluid">
<div class ="span4"><asp:Label ID="lblActividades" runat="server" CssClass="bold" 
                        Text="Actividades"></asp:Label></div>
<div class ="span4"><asp:DropDownList ID="ddlActividades" runat="server" Height="22px" 
                        Width="350px">
                    </asp:DropDownList></div>
<div class ="span4"></div>
</div>

<div class ="row-fluid">
<div class ="span4">Unidad</div>
<div class ="span4">&nbsp;<asp:DropDownList ID="ddlUnidad" runat="server" 
        Height="22px" Width="169px"></asp:DropDownList></div>
<div class ="span4"> </div>
</div>

<div class ="row-fluid">
<div class ="span4"><asp:Label ID="lblAprobador" runat="server" style="font-weight: 700" 
                        Text="Aprobador"></asp:Label></div>
<div class ="span4"><asp:CheckBox ID="chkAprobador" runat="server" 
        Text="Es aprobador...??" /></div>
<div class ="span4"></div>
</div>

<div class ="row-fluid">
<div class ="span4"> <asp:Label ID="lblEsBifurcacion" runat="server" style="font-weight: 700" Text="Es Bifurcacion"></asp:Label></div>
<div class ="span4">
    <asp:CheckBox ID="ChkBifurcacion" runat="server" 
        Text="Es una Bifurcación??" 
        AutoPostBack="True"/>
    </div>
<div class ="span4"> </div>

</div>

<div class ="row-fluid">
<div class ="span1">Si 
    <asp:TextBox ID="txtSecuenciaSi" runat="server" Width="25px"></asp:TextBox>
    </div>
 <div class ="span1">No
    <asp:TextBox ID="txtSecuenciaNo" runat="server" Width="25px"></asp:TextBox>
    </div>


</div>


<div class ="row-fluid">
<div class ="span12">
    <asp:GridView ID="grvModeladorSolicitud" runat="server" 
        AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" 
        BorderStyle="Solid" BorderWidth="1px" CellPadding="6"         
        onpageindexchanging="grvModeladorSolicitud_PageIndexChanging" 
        AllowPaging="True" 

        
        
        
        
        DataKeyNames="intSecuencia,strRutUsuario,strAprobador,intCodUnidad,strSi,strNo" ForeColor="Black" 
        GridLines="Vertical" 
        onselectedindexchanged="grvModeladorSolicitud_SelectedIndexChanged" 
        Width="829px"
        emptydatatext="No existen datos para la consulta realizada" 
        Font-Bold="False" PageSize="5">

            <emptydatarowstyle backcolor="#B2E389" forecolor="Red"/>
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
            <asp:CommandField ButtonType="Image" SelectImageUrl="~/imagenes/editar.gif" 
                ShowSelectButton="True" ShowCancelButton="False" />
            <asp:TemplateField HeaderText="Secuencia">
                <ItemTemplate>
                    <asp:Label ID="lblSecuencia0" runat="server" 
                        Text='<%#Bind("intSecuencia") %>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtEditSecuencia" runat="server" Maxlength="50" 
                        Text='<%#Bind("intSecuencia") %>' />
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Actividad">
                <ItemTemplate>
                    <asp:Label ID="lblActividad" runat="server" 
                        Text='<%#Bind("strDescripcion") %>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtEditActividad" runat="server" Maxlength="50" 
                        Text='<%#Bind("strDescripcion") %>' />
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Codigo Tipo Solicitud" Visible="False">
                <ItemTemplate>
                    <asp:Label ID="lblCodTiposolicitud" runat="server" 
                        Text='<%#Bind("intCodTipoSolicitud") %>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtEditCodTiposolicitud" runat="server" Maxlength="50" 
                        Text='<%#Bind("intCodTipoSolicitud") %>' />
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Codigo Actividad" Visible="False">
                <ItemTemplate>
                    <asp:Label ID="lblCodActividad" runat="server" 
                        Text='<%#Bind("intCodActividad") %>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtEditCodActividad" runat="server" Maxlength="50" 
                        Text='<%#Bind("intCodActividad") %>' />
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="strDescUnidad" HeaderText="Unidad" SortExpression="strDescUnidad" />

            <asp:TemplateField HeaderText="Aprobador">
                <ItemTemplate>
                    <asp:Label ID="lblAprobador0" runat="server" 
                        Text='<%#Bind("strAprobador") %>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtCodEditAprobador" runat="server" Maxlength="50" 
                        Text='<%#Bind("strAprobador") %>' />
                </EditItemTemplate>

                </asp:TemplateField>

            <asp:BoundField DataField="strSi" HeaderText="Secuencia SI" 
                SortExpression="strSi" />
            <asp:BoundField DataField="strNo" HeaderText="Secuencia NO" 
                SortExpression="strNo" />
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
<div class ="span4"><asp:ImageButton ID="BtnGuardar" runat="server" 
        ImageUrl="~/imagenes/boton.guardar.gif" onclick="BtnGuardar_Click" /></div>
<div class ="span4"><asp:ImageButton ID="BtnEliminar" runat="server" 
        ImageUrl="~/imagenes/btn_eliminar.gif" onclick="BtnEliminar_Click" 
        Height="29px" Width="98px" /></div>
<div class ="span4"><asp:Label ID="lblMensaje" runat="server" 
        style="font-weight: 700; color: #FF0000"></asp:Label></div>
</div>

</div>

</asp:Content>
