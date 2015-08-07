<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetalleSolicitud.aspx.cs" Inherits="WorkflowSolicitudes.Presentacion.DetalleSolicitud" %>


<head runat="server">


<meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="~/css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="~/css/custom.css" rel="stylesheet" type="text/css" />
   <link href="~/css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />

   <link href="../css/alertify.core.css" rel="stylesheet" type="text/css" />
 <link href="../css/alertify.default.css" rel="stylesheet" type="text/css" id="toggleCSS" />
    
 <img id="bg" src="../imagenes/LogoFondoVerde.jpg"  alt="background" /> 

 <meta name="viewport" content="width=device-width">
    <title></title>

    <style>
    body {
        background: #B2E389;
        overflow-x: hidden;
    }
        .table-bordered
        {
            margin-left: 0px;
            font-size: x-small;
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


</head>
<body >

    <form id="form1" runat="server">
   
            <div class="container">

             <div class ="row-fluid">
                    <div class ="span12">
                    </div>
            </div>

            <div class ="row-fluid">
                    <div class ="span12">
                    </div>
            </div>
            <div class ="row-fluid">
                    <div class ="span12">
                    </div>
            </div>
                <div class ="row-fluid">
                    <div class ="span3"></div>
                    <div class ="span3"><p class="text-left">Folio:</p></div>
                    <div class ="span3"><asp:Label ID="lblFolio" runat="server"></asp:Label></div>
                    <div class ="span3"></div>
                </div>

             

                 <div class ="row-fluid">
                    <div class ="span3"></div>
                    <div class ="span3"><p class="text-left">Tipo de Solicitud:</p></div>
                    <div class ="span3"><asp:Label ID="LblDesctipoSolicitud" runat="server"></asp:Label></div>
                    <div class ="span3"></div>
                </div>

                <div class ="row-fluid">
                    <div class ="span12">
                    </div>
                </div>

                <div class ="row-fluid">
                    <div class ="span3"></div>
                    <div class ="span9">

                <asp:GridView ID="GridView1" CssClass="table table-hover table-bordered" 
                runat="server" AutoGenerateColumns="False" 
                BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
                CellPadding="3" GridLines="Vertical" ForeColor="Black" 
                emptydatatext="No existen datos para la consulta realizada" 
                Font-Bold="False" Width="872px" Height="106px">

            <emptydatarowstyle backcolor="#B2E389" forecolor="Red"/>
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                    <asp:BoundField DataField="intFolioSolicitudes" HeaderText="Folio" 
                        SortExpression="intFolioSolicitudes" />
                    <asp:BoundField DataField="intSecuencia" HeaderText="Secuencia" 
                        SortExpression="intSecuencia" />
                    <asp:BoundField DataField="strGlosaActividad" HeaderText="Actividad" 
                        SortExpression="strGlosaActividad" />
                    <asp:BoundField DataField="strDescUnidad" HeaderText="Unidad Responsable" 
                        SortExpression="strDescUnidad" />
                    <asp:BoundField DataField="strnombre" HeaderText="Persona asignada" 
                        SortExpression="strnombre" />
                    <asp:BoundField DataField="dtmFechaVencSol" HeaderText="Fecha Vencimiento" 
                        SortExpression="dtmFechaVencSol" />
                    <asp:BoundField DataField="intDiasDeRetraso" HeaderText="Dias de Atraso" 
                        SortExpression="intDiasDeRetraso" />
                    <asp:BoundField DataField="strGlosaEstado" HeaderText="Estado" 
                        SortExpression="strGlosaEstado" />
                </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#808080" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>
            <br />
            <br />
            <br />
            <br />
            <asp:HyperLink ID="HyperLink1" runat="server" 
                NavigateUrl="~/Presentacion/BandejaEntrada.aspx" ForeColor="Black" >Volver</asp:HyperLink>
              
        
         </div>
                </div>

            
            
            </div>
            
       
    </form>
</body>