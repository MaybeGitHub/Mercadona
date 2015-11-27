<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="formalizar.aspx.cs" Inherits="MerCadona.Vistas.formalizar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">    
        <asp:Table runat="server" Width="100%" BorderColor="DarkGreen" BorderWidth="1px">
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
                    <asp:Label runat="server" Text="FORMALIZAR COMPRA" ForeColor="White" BackColor="DarkGreen" Width="100%"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2">
                    <asp:CheckBox runat="server" ID="check_Acuerdo" /> Al formalizar la compra DECLARO estar conforme con las <asp:LinkButton runat="server" Text="Condiciones Generales y con la politica de muchas cosas politicas"></asp:LinkButton> con los datos que figuran en el Ticket de Compra.
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <asp:Panel runat="server" Width="100%" Height="100%">
            <asp:Table runat="server" Width="40%" style="float:left" CellSpacing="0" ID="tabla_Cesta" BorderColor="DarkGreen" BorderWidth="1px">
                <asp:TableRow>
                    <asp:TableCell ForeColor="White" BackColor="DarkGreen" ColumnSpan="3">
                        DATOS TICKET
                    </asp:TableCell>                        
                </asp:TableRow>
                <asp:TableRow><asp:TableCell BackColor="#003300" ColumnSpan="3"></asp:TableCell></asp:TableRow>   
                <asp:TableRow  ForeColor="White" BackColor="DarkGreen">
                    <asp:TableCell Width="60%">
                        Descripcion
                    </asp:TableCell>
                    <asp:TableCell Width="30%" HorizontalAlign="Center">
                        Cantidad
                    </asp:TableCell>
                    <asp:TableCell Width="10%" HorizontalAlign="Center">
                        Euros
                    </asp:TableCell>
                </asp:TableRow>                 
            </asp:Table>        
            <asp:Table runat="server" Width="59%"  CellSpacing="0" ID="tabla_Cliente" BorderColor="DarkGreen" BorderWidth="1px" style="float:right" >
                <asp:TableRow>
                    <asp:TableCell ForeColor="White" BackColor="DarkGreen" ColumnSpan="2">
                        DATOS CLIENTE
                    </asp:TableCell>                        
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Table runat="server" ID="tabla_RowCliente"></asp:Table>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell ForeColor="White" BackColor="DarkGreen" ColumnSpan="2">
                        FORMA DE PAGO
                    </asp:TableCell>                        
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Table runat="server" ID="tabla_RowPago"></asp:Table>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell ForeColor="White" BackColor="DarkGreen" ColumnSpan="2">
                        DATOS DE ENTREGA
                    </asp:TableCell>                        
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Table runat="server" ID="tabla_RowEntrega"></asp:Table>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="row_pedido">
                    <asp:TableCell ForeColor="White" BackColor="DarkGreen" ColumnSpan="2">
                        DATOS DEL PEDIDO
                    </asp:TableCell>                        
                </asp:TableRow>
                <asp:TableRow ID="row_imagen">
                    <asp:TableCell HorizontalAlign="Center">
                        <asp:Image runat="server" ImageUrl="~/imagenes/imagenes_CompraOnline/TramosEntregaCompra.png" Width="700px"/>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
    </asp:Panel>           
    <asp:Panel runat="server" HorizontalAlign="Right" style="padding-top:10px; clear:both">
         <asp:Button runat="server" ID="button_Volver" Text="VOLVER A LA TIENDA" ForeColor="DarkGreen" BackColor="White" BorderColor="DarkGreen" OnClick="button_Volver_Click"/>
         <asp:Button runat="server" ID="button_Finalizar" Text="ENVIAR PEDIDO" ForeColor="DarkGreen" BackColor="White" BorderColor="DarkGreen" style="margin-left:10px"/>
    </asp:Panel>            
    </form>
</body>
</html>
