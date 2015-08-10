<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VerAdjuntos.aspx.cs" Inherits="WorkflowSolicitudes.Presentacion.VerAdjuntos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <title></title>

</asp:Content>
    
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">   

 <div class ="row-fluid">
<div class ="span12"></div>
</div>


<div class ="row-fluid">
<div class ="span12"><asp:GridView ID="grvAdjunto" runat="server"  
        AutoGenerateColumns="False" AllowPaging="True"
        BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
        CellPadding="3" ForeColor="Black" GridLines="Vertical"  
        onpageindexchanging="grvAdjunto_PageIndexChanging" 
        onrowcancelingedit="grvAdjunto_RowCancelingEdit"
        onrowdeleting="grvAdjunto_RowDeleting" 
        onrowediting="grvAdjunto_RowEditing"
        onrowupdating="grvAdjunto_RowUpdating" 
        DataKeyNames="intIdArchivo" 
        onselectedindexchanged="grvAdjunto_SelectedIndexChanged" PageSize="10" 
                style="text-align: center" 
        EmptyDataText="No existen archivos adjuntos" Font-Bold="False" 
        Font-Italic="True">
        <AlternatingRowStyle BackColor="#CCCCCC" />

        <Columns>
               <asp:ButtonField ButtonType="Image" CommandName="Select" 
                   ImageUrl="~/imagenes/lupa.gif" ShowHeader="True" Text="Ver" 
                   HeaderText="Ver Pdf" />
               

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

 

    </asp:Content>