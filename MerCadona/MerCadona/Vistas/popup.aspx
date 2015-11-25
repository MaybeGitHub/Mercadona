<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="popup.aspx.cs" Inherits="MerCadona.Vistas.popup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Panel runat="server" Width="100%" Height="100%">
            <asp:Table runat="server" BorderColor="DarkGreen" BorderWidth="1px" Width="100%" CellPadding="5">
                <asp:TableRow>
                    <asp:TableCell HorizontalAlign="Center" ColumnSpan="2">
                        <asp:Label runat="server" Text="AYUDA CONTRASEÑA" ForeColor="White" BackColor="DarkGreen" Width="100%"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell HorizontalAlign="Center" ColumnSpan="2">
                        <asp:Label runat="server" Text="Introduzca el Nº Identificación (DNI, NIF, CIF, NIE) y e-mail y pulse enviar. Se le enviará un correo electrónico al correo asociado para que pueda generar una nueva contraseña." Width="100%"></asp:Label>                        
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell Width="40%" HorizontalAlign="Right">                        
                        <asp:Label runat="server" Text="Nº Identificacion: " ForeColor="DarkGreen" Font-Bold="true" Font-Size="Larger" style="margin-left:20px"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox runat="server" ID="text_Numero" Width="80%"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
                        <asp:CustomValidator ID="cv_Numero" runat="server" OnServerValidate="cv_Numero_ServerValidate" ErrorMessage="No existe un usuario con este numero" ForeColor="DarkRed" Font-Size="Small"></asp:CustomValidator>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell HorizontalAlign="Right" ColumnSpan="2">
                        <asp:Button runat="server" ID="button_Enviar" Text="ENVIAR" ForeColor="DarkGreen" BackColor="White" BorderColor="DarkGreen" BorderWidth="1px" OnClick="button_Enviar_Click"/>
                        <asp:Button runat="server" ID="buton_Cerrar" Text="CERRAR" ForeColor="DarkGreen" BackColor="White" BorderColor="DarkGreen" BorderWidth="1px" style="margin-left:5px" OnClick="buton_Cerrar_Click"/>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </asp:Panel>
    </form>
</body>
</html>
