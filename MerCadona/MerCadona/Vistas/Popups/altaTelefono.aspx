<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="altaTelefono.aspx.cs" Inherits="MerCadona.Vistas.altaTelefono" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:Panel runat="server" Width="100%" Height="100%">
        <asp:Table runat="server" Width="100%" Height="100%" BorderColor="DarkGreen" BorderWidth="1px">
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center" ColumnSpan="2">
                    <asp:Label runat="server" Text="FICHA DE ALTA DE TELEFONO" ForeColor="White" BackColor="DarkGreen" Width="100%"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow HorizontalAlign="Center">
                <asp:TableCell ColumnSpan="2">
                    <asp:Label runat="server" Text="Telefono"></asp:Label>                    
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow HorizontalAlign="Center">
                <asp:TableCell ColumnSpan="2">
                    <asp:TextBox runat="server" Width="70%" ID="text_Telefono"></asp:TextBox>                    
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow HorizontalAlign="Center">
                <asp:TableCell ColumnSpan="2">
                    <asp:CheckBox runat="server" ID="check_Telefono" Text="¿Es telefono habitual?"></asp:CheckBox>                    
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell Width="50%" HorizontalAlign="Center">
                    <asp:Button runat="server" ID="button_Aceptar" Text="ACEPTAR" ForeColor="DarkGreen" BackColor="White" BorderColor="DarkGreen" BorderWidth="1px" OnClick="button_Aceptar_Click"/>
                </asp:TableCell>
                <asp:TableCell Width="50%" HorizontalAlign="Center">
                    <asp:Button runat="server" ID="button_Cancelar" Text="CANCELAR" ForeColor="DarkGreen" BackColor="White" BorderColor="DarkGreen" BorderWidth="1px" OnClick="button_Cancelar_Click"/>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </asp:Panel>
    </form>
</body>
</html>
