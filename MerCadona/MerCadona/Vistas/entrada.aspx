<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="entrada.aspx.cs" Inherits="MerCadona.Vistas.entrada" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:Table runat="server" Width="100%">
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Right" ColumnSpan="3">
                <asp:Label runat="server" Text="Bienvenido a la COMPRA ONLINE"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Left">
                <asp:Image runat="server" ImageUrl="~/imagenes/imagenes_Inicio/logomercavertical.gif" />
            </asp:TableCell>
            <asp:TableCell>

            </asp:TableCell>
            <asp:TableCell HorizontalAlign="Right">                
                <asp:Image runat="server" ImageUrl="~/imagenes/imagenes_Inicio/index_Compra.JPG" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <br />
    <asp:Table runat="server" Width="100%">
        <asp:TableRow>
            <asp:TableCell>
                <asp:LinkButton runat="server" Text="Registrarse como Cliente" ForeColor="Black" PostBackUrl="~/Vistas/altaCliente.aspx"></asp:LinkButton>
            </asp:TableCell>
            <asp:TableCell RowSpan="4">
                <asp:Table runat="server" BackColor="SandyBrown" HorizontalAlign="Right" Width="600px">
                    <asp:TableRow>
                        <asp:TableCell HorizontalAlign="Right" Width="40%">
                             <asp:Label runat="server" Text="E-mail / Usuario de acceso"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell HorizontalAlign="Left">
                             <asp:TextBox runat="server" ID="text_Usuario" Width="90%"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell HorizontalAlign="Right" Width="40%">
                             <asp:Label runat="server" Text="Contraseña"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell HorizontalAlign="Left">
                             <asp:TextBox runat="server" ID="text_Contraseña" Width="50%"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell ColumnSpan="2" HorizontalAlign="Right">
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
                <asp:LinkButton runat="server" Text="Cliente registrado" ForeColor="Black"></asp:LinkButton>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:LinkButton runat="server" Text="Condiciones generales de compra" ForeColor="Black"></asp:LinkButton>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <br />
    <asp:Panel runat="server" HorizontalAlign="Center"><asp:Label runat="server" Text="Usted podrá conocer si damos servicio en su domicilio registrándose como cliente, consultando a través del siguiente formulario de " ForeColor="DarkRed"></asp:Label> 
        <asp:LinkButton runat="server" Text="Atención al Cliente " PostBackUrl="~/Vistas/atencion.aspx" ForeColor="BlueViolet"></asp:LinkButton>
        <asp:Label runat="server" Text=" o llamando al teléfono nº 902.113.177 de Lunes a Sábado de 9:00 h 21:30h" ForeColor="DarkRed"></asp:Label>
    </asp:Panel>
    </form>  
    <script>
        var posicionX = (screen.width / 2) - 400;
        var posicionY = (screen.height / 2) - 250;
        document.getElementById("button_Olvidado").addEventListener("click", function () {
            window.open("cambioContraseña.aspx", "", "width=800px, height=200px, menubar=0, toolbar=0, directories=0, scrollbars=0, resizable=no,left=" + posicionX + ",top=" + posicionY + "");
        })
    </script>  
</body>
</html>
