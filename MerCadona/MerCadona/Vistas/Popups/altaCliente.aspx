<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="altaCliente.aspx.cs" Inherits="MerCadona.Vistas.altaCliente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Panel runat="server">
            <asp:Table runat="server" Width="100%" BorderColor="DarkGreen" BorderWidth="1px" CellPadding="5" CellSpacing="0">
                <asp:TableRow>
                    <asp:TableCell HorizontalAlign="Center" Width="100%" ColumnSpan="3">
                        <asp:Label runat="server" Text="FICHA DE ALTA DE CLIENTE" BackColor="DarkGreen" ForeColor="White" Width="100%"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow HorizontalAlign="Center">
                    <asp:TableCell Width="30%">
                        <asp:Label runat="server" Text="Nombre"></asp:Label>
                        <asp:Label runat="server" Text="*" ForeColor="DarkRed"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell Width="30%">
                        <asp:Label runat="server" Text="Primer apellido"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell Width="30%">
                        <asp:Label runat="server" Text="Segundo apellido"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow HorizontalAlign="Center">
                    <asp:TableCell Width="30%">
                        <asp:TextBox runat="server" ID="text_Nombre" Width="60%"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell Width="30%">
                        <asp:TextBox runat="server" ID="text_Apellido1" Width="60%"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell Width="30%">
                        <asp:TextBox runat="server" ID="text_Apellido2" Width="60%"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow HorizontalAlign="Center">
                    <asp:TableCell Width="30%">
                        <asp:Label runat="server" Text="Tipo de identificacion"></asp:Label>
                        <asp:Label runat="server" Text="*" ForeColor="DarkRed"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell Width="30%">
                        <asp:Label runat="server" Text="Numero de Identificacion"></asp:Label>
                        <asp:Label runat="server" Text="*" ForeColor="DarkRed"></asp:Label>
                    </asp:TableCell>                    
                </asp:TableRow>
                <asp:TableRow HorizontalAlign="Center">
                    <asp:TableCell Width="30%">
                        <asp:DropDownList Width="150px" runat="server" ID="list_TipoID"></asp:DropDownList>
                    </asp:TableCell>
                    <asp:TableCell Width="30%">
                        <asp:TextBox runat="server" ID="text_NumeroID" Width="60%"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell Width="30%">
                        <asp:CheckBox runat="server" ID="check_Info" Text="Deseo recibir informacion comercial" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow HorizontalAlign="Center">
                    <asp:TableCell Width="30%">
                        <asp:Label runat="server" Text="Email"></asp:Label>
                        <asp:Label runat="server" Text="*" ForeColor="DarkRed"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell Width="30%">
                        <asp:Label runat="server" Text="Confirmacion de Email"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell Width="30%">
                        <asp:Label runat="server" Text="Fecha de Nacimiento"></asp:Label>
                        <asp:Label runat="server" Text="*" ForeColor="DarkRed"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow HorizontalAlign="Center">
                    <asp:TableCell Width="30%">
                        <asp:TextBox runat="server" ID="text_Email" Width="60%"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell Width="30%">
                        <asp:TextBox runat="server" ID="text_Email2" Width="60%"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell Width="30%">
                        <asp:DropDownList runat="server" ID="list_Dia"></asp:DropDownList>
                        <asp:DropDownList runat="server" ID="list_Mes"></asp:DropDownList>
                        <asp:DropDownList runat="server" ID="list_Año"></asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow HorizontalAlign="Center">
                    <asp:TableCell Width="30%">
                        <asp:Label runat="server" Text="Contraseña"></asp:Label>
                        <asp:Label runat="server" Text="*" ForeColor="DarkRed"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell Width="30%">
                        <asp:Label runat="server" Text="Confirmacion de contraseña"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow HorizontalAlign="Center">
                    <asp:TableCell Width="30%">
                        <asp:TextBox runat="server" ID="text_Contraseña" Width="60%"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell Width="30%">
                        <asp:TextBox runat="server" ID="text_Contraseña2" Width="60%"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>                
                <asp:TableRow><asp:TableCell><blockquote></blockquote></asp:TableCell></asp:TableRow>
                <asp:TableRow HorizontalAlign="Center" BackColor="#ffcc66">
                    <asp:TableCell>
                        <asp:Label runat="server" Text="Direcciones"></asp:Label>
                        <asp:Label runat="server" Text="*" ForeColor="DarkRed"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList runat="server" ID="list_Direcciones" Width="60%"></asp:DropDownList>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Button runat="server" ID="button_AltaDireccion" Text="ALTA" ForeColor="DarkGreen" BackColor="White" BorderColor="DarkGreen" BorderWidth="1px" />
                        <asp:Button runat="server" ID="button_ModificarDireccion" Text="MODIFICAR" ForeColor="DarkGreen" BackColor="White" BorderColor="DarkGreen" BorderWidth="1px" style="margin-left:10px"/>
                        <asp:Button runat="server" ID="button_BorrarDireccion" Text="BORRAR" ForeColor="DarkGreen" BackColor="White" BorderColor="DarkGreen" BorderWidth="1px" style="margin-left:10px"/>
                    </asp:TableCell>
                </asp:TableRow>                
                <asp:TableRow HorizontalAlign="Center" BackColor="#ffcc66">
                    <asp:TableCell>
                        <asp:Label runat="server" Text="Telefonos"></asp:Label>
                        <asp:Label runat="server" Text="*" ForeColor="DarkRed"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList runat="server" ID="list_Telefonos" Width="60%"></asp:DropDownList>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Button runat="server" ID="button_AltaTelefono" Text="ALTA" ForeColor="DarkGreen" BackColor="White" BorderColor="DarkGreen" BorderWidth="1px" />
                        <asp:Button runat="server" ID="button_ModificarTelefono" Text="MODIFICAR" ForeColor="DarkGreen" BackColor="White" BorderColor="DarkGreen" BorderWidth="1px" style="margin-left:10px"/>
                        <asp:Button runat="server" ID="button_BorrarTelefono" Text="BORRAR" ForeColor="DarkGreen" BackColor="White" BorderColor="DarkGreen" BorderWidth="1px" style="margin-left:10px"/>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow><asp:TableCell><blockquote></blockquote></asp:TableCell></asp:TableRow>
                <asp:TableRow HorizontalAlign="Center">
                    <asp:TableCell>
                        <asp:Label runat="server" Text="En caso de falta de un producto"></asp:Label>    
                        <asp:Label runat="server" Text="*" ForeColor="DarkRed"></asp:Label>                    
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow HorizontalAlign="Center">
                    <asp:TableCell>
                        <asp:DropDownList runat="server" ID="list_FaltaProducto">
                            <asp:ListItem Text="Sustituir por uno similar"></asp:ListItem>
                            <asp:ListItem Text="No servir"></asp:ListItem>
                        </asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>                       
                    <asp:TableCell ColumnSpan="3" HorizontalAlign="Right">
                        <asp:CheckBox runat="server" ID="check_Legales"/>
                        <asp:Label runat="server" Text="Acepto las "></asp:Label>
                        <asp:LinkButton runat="server" Text=" Condiciones Generales y la política de confidencialidad y protección de datos"></asp:LinkButton>
                        <asp:Label runat="server" Text="*" ForeColor="DarkRed" style="margin-right:20px"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell HorizontalAlign="Left">
                        <asp:Label runat="server" Text="*" ForeColor="DarkRed" style="margin-left:50px"></asp:Label>
                        <asp:Label runat="server" Text="Campos obligatorios" Font-Size="Smaller" style="margin-left:10px"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell HorizontalAlign="Center">
                        <asp:Label runat="server" ID="label_ErrorVacio" Text="Aun faltan campos importantes vacios" ForeColor="DarkRed" Font-Size="Smaller" style="margin-left:50px" Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="label_ErrorMatch" Text="La contraseña o el email no coincide" ForeColor="DarkRed" Font-Size="Smaller" style="margin-left:50px" Visible="false"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell HorizontalAlign="Right">
                        <asp:Button runat="server" ID="button_Enviar" Text="ENVIAR ALTA" ForeColor="DarkGreen" BackColor="White" BorderColor="DarkGreen" BorderWidth="1px" />
                        <asp:Button runat="server" ID="button_Cerrar" Text="CERRAR" ForeColor="DarkGreen" BackColor="White" BorderColor="DarkGreen" BorderWidth="1px" style="margin-left:10px;margin-right:20px"/>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </asp:Panel>
    </form>
    <script>        
        document.getElementById("button_AltaTelefono").addEventListener("click", function () {
            var posicionX = (screen.width / 2) - 250;
            var posicionY = (screen.height / 2) - 250;
            window.open("altaTelefono.aspx", "", "width=500px, height=150px, menubar=0, toolbar=0, directories=0, scrollbars=0, resizable=no,left=" + posicionX + ",top=" + posicionY + "");
        })        
        document.getElementById("button_ModificarTelefono").addEventListener("click", function () {
            var posicionX = (screen.width / 2) - 250;
            var posicionY = (screen.height / 2) - 250;
            var list = document.getElementById("list_Telefonos");
            if (list.options[list.selectedIndex].value != "No se han definido telefonos" )
            window.open("altaTelefono.aspx?telefono=" + list.options[list.selectedIndex].value, "", "width=500px, height=150px, menubar=0, toolbar=0, directories=0, scrollbars=0, resizable=no,left=" + posicionX + ",top=" + posicionY + "");
        })

        document.getElementById("button_AltaDireccion").addEventListener("click", function () {
            var posicionX = (screen.width / 2) - 250;
            var posicionY = (screen.height / 2) - 250;            
            window.open("altaDomicilio.aspx", "", "width=675px, height=410px, menubar=0, toolbar=0, directories=0, scrollbars=0, resizable=no,left=" + posicionX + ",top=" + posicionY + "");
        })
        document.getElementById("button_ModificarDireccion").addEventListener("click", function () {
            var posicionX = (screen.width / 2) - 250;
            var posicionY = (screen.height / 2) - 250;
            var list = document.getElementById("list_Direcciones");
            if (list.options[list.selectedIndex].value != "No se han definido direcciones de entrega")
                window.open("altaDomicilio.aspx?direccion=" + list.options[list.selectedIndex].value, "", "width=500px, height=410px, menubar=0, toolbar=0, directories=0, scrollbars=0, resizable=no,left=" + posicionX + ",top=" + posicionY + "");
        })
    </script>
</body>
</html>
