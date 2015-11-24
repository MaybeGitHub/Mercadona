<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="controlListadoEmpresas.ascx.cs" Inherits="MerCadona.__Controles_Usuario__.controlListadoEmpresas" %>
<asp:Table runat="server" Width="100%" HorizontalAlign="Left">
    <asp:TableRow>
        <asp:TableCell>
            <asp:Label runat="server" ID="label_Direccion"></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:Label runat="server" ID="label_CP"></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:Label runat="server" ID="label_Telefono"></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:Label runat="server" ID="label_Horario"></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:Label runat="server" ID="label_Parking"></asp:Label>
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>