<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="MerCadona.Vistas.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
    </head>
    <body>
        <form runat="server">
            <asp:Panel runat="server" ID="navegador" Width="100%">
                <asp:Table runat="server" HorizontalAlign="Right">
                    <asp:TableRow>
                        <asp:TableCell>
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
                            <asp:Label runat="server" Font-Size="X-Large">|</asp:Label>
                            <asp:LinkButton ID="link_MapaWeb" runat="server">Mapa Web</asp:LinkButton>
                            <asp:Label runat="server" Font-Size="X-Large">|</asp:Label>
                            <asp:LinkButton ID="link_Accesibilidad" runat="server">Accesibilidad</asp:LinkButton>
                            <asp:Label runat="server" Font-Size="X-Large">|</asp:Label>
                            <asp:LinkButton ID="link_Empleado" runat="server" PostBackUrl="~/Vistas/loginEmpleados.aspx" OnClick="link_Empleado_Click">Soy Empleado</asp:LinkButton>                                                                                        
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </asp:Panel>
            <asp:Panel runat="server" HorizontalAlign="Center" ID="contenido" Width="100%">
                <asp:Image runat="server" ImageUrl="~/imagenes/imagenes_Inicio/index_Cabecera.JPG" />
                <br />
                <asp:Table runat="server" ID="opciones" Width="100%">
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:ImageButton runat="server" ID="imgButton_Compra" ImageUrl="~/imagenes/imagenes_Inicio/index_Compra.JPG" />
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:ImageButton runat="server" ID="imgButton_Factura" ImageUrl="~/imagenes/imagenes_Inicio/index_Factura.JPG" />
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:ImageButton runat="server" ID="imgButton_Tarjeta" ImageUrl="~/imagenes/imagenes_Inicio/index_Compra.JPG" />
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:ImageButton runat="server" ID="imgButton_Trabaja" ImageUrl="~/imagenes/imagenes_Inicio/index_trabaja.JPG" />
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:ImageButton runat="server" ID="imgButton_Empresa" ImageUrl="~/imagenes/imagenes_Inicio/index_corp.JPG" PostBackUrl="~/Vistas/menu.aspx"/>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
                <br /><asp:Button runat="server" ID="button_Canal" Text="Canal Mercadona" BorderColor="Green" BorderWidth="3px" style="background-color:orange"/>
                <br /><br /><asp:Label runat="server"> Mercadona, S.A. CIF:A-46-103834 C/ Valencia, nº 5 Tavernes Blanques VALENCIA - C.P.46016</asp:Label> 
            </asp:Panel>
        </form>
    </body>
</html>
