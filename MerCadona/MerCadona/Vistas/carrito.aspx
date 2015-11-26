<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterCompraOnLine.Master" AutoEventWireup="true" CodeBehind="carrito.aspx.cs" Inherits="MerCadona.Vistas.carrito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="centro" runat="server">
    <asp:Label runat="server" ID="label_Categoria" Font-Bold="true" Font-Size="XX-Large" Text="CATEGORIA" Width="100%"></asp:Label>
    <asp:Label runat="server" ID="label_CantidadCategoria" Font-Bold="true" Font-Size="X-Large" Text="X productos encontados" Width="100%"></asp:Label>
    <asp:Table runat="server" ID="tabla_Productos" Width="95%" HorizontalAlign="Center">
        <asp:TableRow>
            <asp:TableCell Width="50%" BorderColor="DarkOrange" BorderWidth="1px" BackColor="#FFCC00">
                Descripcion
            </asp:TableCell>
            <asp:TableCell Width="20%" BorderColor="DarkOrange" BorderWidth="1px" BackColor="#FFCC00" HorizontalAlign="Center">
                EUROS
            </asp:TableCell>
            <asp:TableCell Width="15%" BorderColor="DarkOrange" BorderWidth="1px" BackColor="#FFCC00" HorizontalAlign="Center">
                Cantidad
            </asp:TableCell>
            <asp:TableCell Width="15%" BorderColor="DarkOrange" BorderWidth="1px" BackColor="#FFCC00" HorizontalAlign="Center">
                Incluir
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <asp:TextBox runat="server" ID="info" TextMode="MultiLine" Width="100%" Rows="10"></asp:TextBox>
</asp:Content>
