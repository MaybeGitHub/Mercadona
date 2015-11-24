<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="loginEmpleados.aspx.cs" Inherits="MerCadona.Vistas.loginEmpleados" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Panel runat="server" ID="panel_Body">
            <asp:Panel runat="server" HorizontalAlign="Center">
                <asp:Image runat="server" ImageUrl="~/imagenes/imagenes_Inicio/index_Cabecera.JPG"></asp:Image>
            </asp:Panel>
            <br />            
            <asp:Table runat="server" Width="20%" Height="25%" BorderColor="DarkGreen" BorderWidth="1px" HorizontalAlign="Center">
                <asp:TableRow HorizontalAlign="Center" ForeColor="White" BackColor="DarkGreen">
                    <asp:TableCell ColumnSpan="2">
                        <asp:Label runat="server" Text="Zona Empleados"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell HorizontalAlign="Right" Width="30%">
                        <asp:Label runat="server" Text="Nombre"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell HorizontalAlign="Left" Width="70%">
                        <asp:TextBox runat="server" ID="text_Nombre"></asp:TextBox>
                    </asp:TableCell>                    
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell HorizontalAlign="Right" Width="30%">
                        <asp:Label runat="server" Text="NIF"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell HorizontalAlign="Left" Width="70%">
                        <asp:TextBox runat="server" ID="text_NIF"></asp:TextBox>
                    </asp:TableCell> 
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell HorizontalAlign="Left">
                        <asp:Button runat="server" ID="button_Salir" Text="Volver" PostBackUrl="~/Vistas/index.aspx" style="margin-left:20px"/>
                    </asp:TableCell>
                    <asp:TableCell HorizontalAlign="Right">
                        <asp:Button runat="server" ID="button_Entrar" Text="Entrar" PostBackUrl="~/Vistas/consultoria.aspx" style="margin-right:20px"/>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </asp:Panel>
    </form>
</body>
</html>
