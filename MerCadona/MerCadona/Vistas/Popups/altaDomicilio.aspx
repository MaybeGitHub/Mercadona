<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="altaDomicilio.aspx.cs" Inherits="MerCadona.Vistas.altaDomicilio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
       <asp:Panel runat="server">
            <asp:Table runat="server" Width="100%" BorderColor="DarkGreen" BorderWidth="1px" CellPadding="5">
                <asp:TableRow>
                    <asp:TableCell HorizontalAlign="Center" Width="100%" ColumnSpan="5">
                        <asp:Label runat="server" Text="FICHA DE ALTA DE CLIENTE" BackColor="DarkGreen" ForeColor="White" Width="100%"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow HorizontalAlign="Center">
                    <asp:TableCell>
                        <asp:Label runat="server" Text="Tipo Via"></asp:Label>
                        <asp:Label runat="server" Text="*" ForeColor="DarkRed"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell Width="20%">
                        <asp:Label runat="server" Text="Nombre Via"></asp:Label>
                        <asp:Label runat="server" Text="*" ForeColor="DarkRed"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell Width="20%">
                        <asp:Label runat="server" Text="Nº/Km"></asp:Label>
                        <asp:Label runat="server" Text="*" ForeColor="DarkRed"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell Width="20%">
                        <asp:Label runat="server" Text="Piso"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell Width="20%">
                        <asp:Label runat="server" Text="Puerta"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow HorizontalAlign="Center">
                    <asp:TableCell Width="20%">
                        <asp:DropDownList runat="server" ID="list_TipoVia" Width="150px"></asp:DropDownList>
                    </asp:TableCell>
                    <asp:TableCell Width="20%">
                        <asp:TextBox runat="server" ID="text_NombreVia" Width="60%"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell Width="20%">
                        <asp:TextBox runat="server" ID="text_Numero" Width="60%"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell Width="20%">
                        <asp:TextBox runat="server" ID="text_Piso" Width="60%"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell Width="20%">
                        <asp:TextBox runat="server" ID="text_Puerta" Width="60%"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow HorizontalAlign="Center">
                    <asp:TableCell Width="20%">
                        <asp:Label runat="server" Text="Urbanizacion o Poligono"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell Width="20%">
                        <asp:Label runat="server" Text="Bloque"></asp:Label>
                    </asp:TableCell>   
                    <asp:TableCell Width="20%">
                        <asp:Label runat="server" Text="Escalera"></asp:Label>
                    </asp:TableCell>                  
                </asp:TableRow>
                <asp:TableRow HorizontalAlign="Center">
                    <asp:TableCell Width="30%">
                        <asp:TextBox runat="server" ID="text_Urba" Width="60%"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell Width="30%">
                        <asp:TextBox runat="server" ID="text_Bloque" Width="60%"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell Width="30%">
                        <asp:TextBox runat="server" ID="text_Escalera" Width="60%" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow HorizontalAlign="Center">
                    <asp:TableCell ColumnSpan="5">
                        <asp:Label runat="server" Text="Observaciones (Texto de ayuda para localizar la direccion )"></asp:Label>
                    </asp:TableCell>                    
                </asp:TableRow>
                <asp:TableRow HorizontalAlign="Center">
                    <asp:TableCell ColumnSpan="5">
                        <asp:TextBox runat="server" ID="text_Observaciones" Width="89%"></asp:TextBox>
                    </asp:TableCell>                    
                </asp:TableRow>
                <asp:TableRow HorizontalAlign="Center">
                    <asp:TableCell Width="30%">
                        <asp:Label runat="server" Text="Localidad"></asp:Label>
                        <asp:Label runat="server" Text="*" ForeColor="DarkRed"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell Width="30%" ColumnSpan="4">
                        <asp:Label runat="server" Text="Codigo Postal"></asp:Label>
                        <asp:Label runat="server" Text="*" ForeColor="DarkRed"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow HorizontalAlign="Center">
                    <asp:TableCell Width="30%">
                        <asp:TextBox runat="server" ID="text_Localdidad" Width="250px"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell Width="30%" ColumnSpan="4">
                        <asp:TextBox runat="server" ID="text_CP" Width="20%"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell ColumnSpan="5" HorizontalAlign="Left">
                        <asp:CheckBox runat="server" ID="check_Habitual" style="margin-left:5%"/>
                        <asp:Label runat="server" Text="¿Es la direccion de entrega habitual?"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell HorizontalAlign="Left">
                        <asp:Label runat="server" Text="*" ForeColor="DarkRed" style="margin-left:50px"></asp:Label>
                        <asp:Label runat="server" Text="Campos obligatorios" Font-Size="Smaller" style="margin-left:10px"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell HorizontalAlign="Center">
                        <asp:Label runat="server" ID="label_ErrorVacio" Text="Aun faltan campos importantes vacios" ForeColor="DarkRed" Font-Size="Smaller" style="margin-left:50px" Visible="false"></asp:Label>                        
                    </asp:TableCell>
                    <asp:TableCell ColumnSpan="2" HorizontalAlign="Right">
                        <asp:Button runat="server" ID="button_Aceptar" Text="ACEPTAR" ForeColor="DarkGreen" BackColor="White" BorderColor="DarkGreen" BorderWidth="1px" OnClick="button_Aceptar_Click" />
                        <asp:Button runat="server" Text="CANCELAR" ForeColor="DarkGreen" BackColor="White" BorderColor="DarkGreen" BorderWidth="1px" style="margin-left:10px" OnClick="button_Cancelar_Click"/>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </asp:Panel>
    </form>
</body>
</html>
