<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="entrada.aspx.cs" Inherits="MerCadona.Vistas.entrada" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="contenedor"  style="width:1280px; height:720px; margin-left:auto; margin-right:auto">
         <asp:Table runat="server" style="margin:0px auto" Width="100%">
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right" ColumnSpan="3">
                    <asp:Label runat="server" Text="Bienvenido a la COMPRA ONLINE"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Left">
                    <asp:ImageButton runat="server" ImageUrl="~/imagenes/imagenes_CompraOnline/imagenes_autentificacion/mercadona_horizontal.gif" PostBackUrl="~/Vistas/Principales/index.aspx" />
                </asp:TableCell>            
                <asp:TableCell HorizontalAlign="Right">                
                    <asp:Image runat="server" ImageUrl="~/imagenes/imagenes_Inicio/compraOnline.png" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <br />
        <asp:Table runat="server" Width="100%" style="margin:50px auto">
            <asp:TableRow>
                <asp:TableCell>
                    <img src="../../imagenes/imagenes_CompraOnline/imagenes_autentificacion/circulo2.gif"/>
                    <asp:LinkButton Font-Size="Larger" Font-Bold="true" runat="server" ID="link_Registro" Text="Registrarse como Cliente" ForeColor="Black"></asp:LinkButton>
                </asp:TableCell>
                <asp:TableCell RowSpan="4">
                    <asp:Table runat="server" BackColor="SandyBrown" HorizontalAlign="Right" Width="450px">
                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Right" Width="40%">
                                 <asp:Label runat="server" Text="NIF"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Left">
                                 <asp:TextBox runat="server" ID="text_NIF" Width="90%"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Right" Width="40%">
                                 <asp:Label runat="server" Text="Contraseña"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Left">
                                 <asp:TextBox runat="server" TextMode="Password" ID="text_Contraseña" Width="50%"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Center">
                                <asp:Label runat="server" ID="label_Error" Text="Datos incorrectos" ForeColor="DarkRed" Font-Size="Small" Visible="false"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Right">
                                <asp:Button runat="server" ID="button_Entrar" BackColor="White" ForeColor="DarkGreen" BorderColor="DarkGreen" BorderWidth="1px" Text="ENTRAR"/>
                            </asp:TableCell>                        
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell ColumnSpan="2" HorizontalAlign="Right">
                                <asp:Button runat="server" ID="button_Olvidado" BackColor="White" ForeColor="DarkGreen" BorderColor="DarkGreen" BorderWidth="1px" Text="¿Has olvidado el usuario o la contraseña?"/>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </asp:TableCell>                
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <img src="../../imagenes/imagenes_CompraOnline/imagenes_autentificacion/circulo3.gif"/>
                    <asp:LinkButton Font-Size="Larger" Font-Bold="true" runat="server" Text="Cliente registrado" ForeColor="Black"></asp:LinkButton>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <img src="../../imagenes/imagenes_CompraOnline/imagenes_autentificacion/circulo4.gif"/>
                    <asp:LinkButton Font-Size="Larger" Font-Bold="true" runat="server" Text="Condiciones generales de compra" ForeColor="Black"></asp:LinkButton>
                </asp:TableCell>
            </asp:TableRow>        
        </asp:Table>
        <br />
        <asp:Panel runat="server" HorizontalAlign="Center" Width="100%" style="margin:0px auto">
            <asp:Label Font-Size="Small" runat="server" Text="Usted podrá conocer si damos servicio en su domicilio registrándose como cliente, consultando a través del siguiente formulario de " ForeColor="DarkRed"></asp:Label> 
            <asp:LinkButton Font-Size="Small" runat="server" Text="Atención al Cliente " PostBackUrl="~/Vistas/Empresa/atencion.aspx" ForeColor="BlueViolet"></asp:LinkButton>
            <asp:Label Font-Size="Small" runat="server" Text=" o llamando al teléfono nº 902.113.177 de Lunes a Sábado de 9:00 h 21:30h" ForeColor="DarkRed"></asp:Label>
            <br /><asp:Button runat="server" PostBackUrl="~/Vistas/Principales/index.aspx" ForeColor="DarkGreen" BackColor="White" BorderColor="DarkGreen" BorderWidth="1px" style="margin-top:20px" Text="Volver a la pagina principal"/>
        </asp:Panel>
    </div>
    </form>  
    <script>
        var width = screen.width;
        var height = screen.height;

        var medio = (height / 2 - Number(document.getElementById("contenedor").style.height.split('px')[0]) / 2);
        var medioString = medio.toString() + "px";

        document.getElementById("contenedor").style.marginTop = medioString;

        var posicionX = (screen.width / 2) - 400;
        var posicionY = (screen.height / 2) - 250;
        document.getElementById("button_Olvidado").addEventListener("click", function () {
            window.open("../Popups/cambioContraseña.aspx", "", "width=800px, height=200px, menubar=0, toolbar=0, directories=0, scrollbars=0, resizable=no,left=" + posicionX + ",top=" + posicionY + "");
        })
    </script>  
</body>
</html>
