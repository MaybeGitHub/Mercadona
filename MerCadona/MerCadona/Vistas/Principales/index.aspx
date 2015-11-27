<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="MerCadona.Vistas.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
    </head>
    <body> 
        <form runat="server" id="form">
            <div style="margin:0px auto; text-align:right; width:auto" >            
                <asp:Label runat="server">Seleccione idioma:</asp:Label> 
                <select style="background-color:orange">
                    <option value="castellano">Castellano</option>
                    <option value="valenciano">Valenciá</option>
                    <option value="catalan">Catalá</option>
                    <option value="gallego">Galego</option>
                    <option value="euskera">Euskara</option>
                    <option value="ingles">English</option>
                    <option value="holandes">Deutsch</option>
                </select>
                <asp:Label runat="server" Font-Size="X-Large" style="margin-left:5px">|</asp:Label>
                <asp:LinkButton ID="link_MapaWeb" runat="server" style="margin-left:5px" ForeColor="Black" Font-Underline="false">MAPA WEB</asp:LinkButton>
                <asp:Label runat="server" Font-Size="X-Large" style="margin-left:5px">|</asp:Label>
                <asp:LinkButton ID="link_Accesibilidad" runat="server" style="margin-left:5px" ForeColor="Black" Font-Underline="false">ACCESIBILIDAD</asp:LinkButton>
                <asp:Label runat="server" Font-Size="X-Large" style="margin-left:5px">|</asp:Label>
                <asp:LinkButton ID="link_Empleado" runat="server" PostBackUrl="~/Vistas/Principales/loginEmpleados.aspx" style="margin-left:5px" ForeColor="Black" Font-Underline="false">SOY EMPLEADO</asp:LinkButton>                                                                                        
            </div>   
            <div id="contenido" style="margin:0px auto 0px auto; width:1000px; height:720px; text-align:center">
                <asp:Image runat="server" ImageUrl="~/imagenes/imagenes_Inicio/index_Cabecera.JPG" style="margin-bottom:20px;width:410px;height:179px" />
                <br />
                <asp:Table runat="server" ID="opciones" Width="100%">
                    <asp:TableRow>
                        <asp:TableCell>
                            <input type="image" src="/imagenes/imagenes_Inicio/compraOnline.png" onmouseover="cambioSrc(this)" onmouseout="vuelvoSrc(this)" onclick="ir(this)"/>                           
                        </asp:TableCell>
                        <asp:TableCell>
                            <input type="image" src="/imagenes/imagenes_Inicio/facturaOnline.png" onmouseover="cambioSrc(this)" onmouseout="vuelvoSrc(this)" onclick="ir(this)"/>    
                        </asp:TableCell>
                        <asp:TableCell>
                            <input type="image" src="/imagenes/imagenes_Inicio/tarjetaMercadona.png" onmouseover="cambioSrc(this)" onmouseout="vuelvoSrc(this)" onclick="ir(this)"/>    
                        </asp:TableCell>
                        <asp:TableCell>
                            <input type="image" src="/imagenes/imagenes_Inicio/trabajaConNosotros.png" onmouseover="cambioSrc(this)" onmouseout="vuelvoSrc(this)" onclick="ir(this)"/>    
                        </asp:TableCell>
                        <asp:TableCell>
                            <input type="image" src="/imagenes/imagenes_Inicio/nuestraEmpresa.png" onmouseover="cambioSrc(this)" onmouseout="vuelvoSrc(this)" onclick="ir(this)"/>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
                <br /><asp:Button runat="server" ID="button_Canal" Text="Canal Mercadona" BorderColor="Green" BorderWidth="3px" style="background-color:orange"/>
                <br /><br /><asp:Label runat="server" Text="Mercadona, S.A. CIF:A-46-103834 C/ Valencia, nº 5 Tavernes Blanques VALENCIA - C.P.46016" Font-Size="Small" ForeColor="DarkBlue"></asp:Label> 
            </div>  
        </form> 
        <script>
            function ir(img) {
                if (img.src.contains("compra")) form.action = "http://localhost:2243/Vistas/Principales/entrada.aspx";
                if (img.src.contains("Empresa")) form.action = "http://localhost:2243/Vistas/Empresa/menu.aspx";                
            }

            function cambioSrc(img) {
                var ancho = img.width;
                var alto = img.height;
                img.src = img.src.replace(".png", "Hover.png");
                img.width = ancho;
                img.height = alto;
            }

            function vuelvoSrc(img) {
                var ancho = img.width;
                var alto = img.height;
                img.src = img.src.replace("Hover.png", ".png");
                img.width = ancho;
                img.height = alto;
            }

            var width = screen.width;
            var height = screen.height;

            var medio = (height / 2 - Number(document.getElementById("contenido").style.height.split('px')[0]) / 2);
            var medioString = medio.toString() + "px";  

            document.getElementById("contenido").style.marginTop = medioString;
            if( width < 1280 || height < 1024)
            {
                alert("Esta pagina esta diseñada para verse en pantallas con resolucion 1280 x 720 o higher.  Tu resolucion actual es " + width + " x " + height + ".  Si es posible, porfavor cambie la resolucion.");
            }     
        </script>
    </body>
</html>
