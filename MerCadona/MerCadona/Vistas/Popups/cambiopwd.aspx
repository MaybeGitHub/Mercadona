<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cambiopwd.aspx.cs" Inherits="MerCadona.Vistas.cambiopwd" %>

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
                    <asp:TableCell Width="40%" HorizontalAlign="Right">                        
                        <asp:Label runat="server" Text="Email / Usuario de acceso: " ForeColor="DarkGreen" Font-Bold="true" Font-Size="Larger" style="margin-left:20px"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox runat="server" ID="text_Email" Width="80%" Enabled="false" ReadOnly="true"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell Width="40%" HorizontalAlign="Right">                        
                        <asp:Label runat="server" Text="Nueva Contraseña: " ForeColor="DarkGreen" Font-Bold="true" Font-Size="Larger" style="margin-left:20px"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox runat="server" ID="text_contraseña" Width="80%"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell Width="40%" HorizontalAlign="Right">                        
                        <asp:Label runat="server" Text="Repita Contraseña: " ForeColor="DarkGreen" Font-Bold="true" Font-Size="Larger" style="margin-left:20px"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox runat="server" ID="text_contraseña2" Width="80%"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell HorizontalAlign="Right" ColumnSpan="2">
                        <asp:Label runat="server" ID="label_Error" Visible="false" ForeColor="DarkRed" Font-Size="Smaller" Text="No pueden estar los campos vacios" style="margin-right:20px"></asp:Label>
                        <asp:CompareValidator ID="CompareValidator1" ControlToValidate="text_contraseña" ControlToCompare="text_contraseña2" runat="server" ErrorMessage="Las contraseñas tienen que coincidir" ForeColor="DarkRed" Font-Size="Smaller" style="margin-right:20px"></asp:CompareValidator>
                        <asp:Button runat="server" ID="button_Enviar" Text="ACEPTAR" ForeColor="DarkGreen" BackColor="White" BorderColor="DarkGreen" BorderWidth="1px" OnClick="button_Enviar_Click"/>
                        <asp:Button runat="server" ID="buton_Cerrar" Text="CERRAR" ForeColor="DarkGreen" BackColor="White" BorderColor="DarkGreen" BorderWidth="1px" style="margin-left:5px" PostBackUrl="~/Vistas/Principales/index.aspx"/>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </asp:Panel>
    </form>
</body>
</html>
