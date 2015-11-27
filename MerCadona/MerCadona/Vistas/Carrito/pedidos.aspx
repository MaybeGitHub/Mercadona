<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterCompraOnLine.Master" AutoEventWireup="true" CodeBehind="pedidos.aspx.cs" Inherits="MerCadona.Vistas.Carrito.pedidos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="centro" runat="server">
    <asp:Label runat="server" ID="label_Categoria" Font-Bold="true" Font-Size="XX-Large" Text="Pedidos" Width="100%"></asp:Label>
    <asp:Label runat="server" ID="label_CantidadCategoria" Font-Bold="true" Font-Size="X-Large" Text="X pedidos encontados" Width="100%"></asp:Label>
    <asp:Table runat="server" ID="tabla_Pedidos" Width="95%" HorizontalAlign="Center">
        <asp:TableRow HorizontalAlign="Center">
            <asp:TableCell BorderColor="DarkOrange" BorderWidth="1px" BackColor="#FFCC00">
                Nº pedido
            </asp:TableCell>
            <asp:TableCell BorderColor="DarkOrange" BorderWidth="1px" BackColor="#FFCC00">
                Direccion de entrega
            </asp:TableCell>            
            <asp:TableCell BorderColor="DarkOrange" BorderWidth="1px" BackColor="#FFCC00">
                Telefono
            </asp:TableCell>
            <asp:TableCell BorderColor="DarkOrange" BorderWidth="1px" BackColor="#FFCC00">
                Estado
            </asp:TableCell>
            <asp:TableCell BorderColor="DarkOrange" BorderWidth="1px" BackColor="#FFCC00" Width="70px">
                Consultar
            </asp:TableCell>
            <asp:TableCell BorderColor="DarkOrange" BorderWidth="1px" BackColor="#FFCC00" Width="70px">
                Imprimir
            </asp:TableCell>
            <asp:TableCell BorderColor="DarkOrange" BorderWidth="1px" BackColor="#FFCC00" Width="70px">
                Descargar
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
