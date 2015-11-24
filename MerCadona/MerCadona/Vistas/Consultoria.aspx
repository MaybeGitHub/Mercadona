<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Consultoria.aspx.cs" Inherits="MerCadona.Vistas.Consultoria" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:Panel runat="server" BorderColor="DarkGreen" BorderWidth="1px" style="padding:1px">
        <asp:Table runat="server" BorderColor="DarkGreen" BorderWidth="1px" Width="100%">
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <asp:Label runat="server" Text="Lista de Reclamaciones" BackColor="DarkGreen" ForeColor="White" Width="100%"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow> 
                <asp:TableCell HorizontalAlign="Center">
                    <asp:DropDownList runat="server" ID="list_Reclamaciones" Width="50%"></asp:DropDownList>                    
                    <asp:Button runat="server" ID="button_Consultar" Text="Consulta" style="margin-left:10px" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <br />
        <asp:Table runat="server" BorderColor="DarkGreen" BorderWidth="1px" Width="100%" CellPadding="5">
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <asp:Label runat="server" Text="Datos de la Reclamacion" BackColor="DarkGreen" ForeColor="White" Width="100%"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" Text="Asunto" Font-Size="Larger" Font-Bold="true" ForeColor="DarkGreen"></asp:Label>
                    <asp:Label runat="server" ID="label_Asunto" style="margin-left:20px" Text="asunto"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" Text="Mensaje" Font-Size="Larger" Font-Bold="true" ForeColor="DarkGreen"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>                
                <asp:TableCell HorizontalAlign="Center">
                    <asp:TextBox runat="server" ID="textarea_Mensaje" TextMode="MultiLine" Rows="8" Columns="50" Width="95%" Text="Aqui el mensaje"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" Text="Datos" Font-Size="Larger" Font-Bold="true" ForeColor="DarkGreen"></asp:Label>                   
                    
                    <br /><asp:Label runat="server" Text="> Usuario:" Font-Bold="true" style="margin-left:20px"></asp:Label>
                    
                    <br /><asp:Label runat="server" Text="- Nombre:" Font-Bold="true" style="margin-left:40px"></asp:Label>
                    <asp:Label runat="server" ID="label_Nombre" style="margin-left:10px" Text="nombre"></asp:Label>
                    <br /><asp:Label runat="server" Text="- DNI:" Font-Bold="true" style="margin-left:40px"></asp:Label>
                    <asp:Label runat="server" ID="label_DNI" style="margin-left:10px" Text="DNI"></asp:Label>                    
                    <br /><asp:Label runat="server" Text="- Email:" Font-Bold="true" style="margin-left:40px"></asp:Label>
                    <asp:Label runat="server" ID="label_Email" style="margin-left:10px" Text="email"></asp:Label>
                    <br /><asp:Label runat="server" Text="- Telefono:" Font-Bold="true" style="margin-left:40px"></asp:Label>
                    <asp:Label runat="server" ID="label_Telefono" style="margin-left:10px" Text="telefono"></asp:Label>
                    
                    <br /><asp:Label runat="server" Text="> Direccion:" Font-Bold="true" style="margin-left:20px"></asp:Label>
                    <br /><asp:Label runat="server" Text="- Provincia:" Font-Bold="true" style="margin-left:40px"></asp:Label>
                    <asp:Label runat="server" ID="label_Provincia" style="margin-left:10px" Text="provincia"></asp:Label>
                    <br /><asp:Label runat="server" Text="- Localidad:" Font-Bold="true" style="margin-left:40px"></asp:Label>
                    <asp:Label runat="server" ID="label_Localidad" style="margin-left:10px" Text="localidad"></asp:Label>
                    <br /><asp:Label runat="server" Text="- Codigo Postal:" Font-Bold="true" style="margin-left:40px"></asp:Label>
                    <asp:Label runat="server" ID="label_CP" style="margin-left:10px" Text="cp"></asp:Label>
                    <br /><asp:Label runat="server" Text="- Domicilio:" Font-Bold="true" style="margin-left:40px"></asp:Label>
                    <asp:Label runat="server" ID="label_Domicilio" style="margin-left:10px" Text="domicilio"></asp:Label>
                    
                    <br /><asp:Label runat="server" Text="> Mayor de 14:" Font-Bold="true" style="margin-left:20px"></asp:Label>
                     <asp:Label runat="server" ID="label_Mayor14" style="margin-left:10px" Text="mayor"></asp:Label>
                    <br /><asp:Label runat="server" Text="> Acepta informacion al correo:" Font-Bold="true" style="margin-left:20px"></asp:Label>
                     <asp:Label runat="server" ID="label_Info" style="margin-left:10px" Text="info"></asp:Label>
                    <br /><asp:Label runat="server" Text="> Firma Electronica:" Font-Bold="true" style="margin-left:20px"></asp:Label>       
                     <asp:Label runat="server" ID="label_Firma" style="margin-left:10px" Text="firma"></asp:Label>             
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <asp:Button runat="server" ID="button_Cerrar" Text="Cerrar Consulta" BackColor="DarkGreen" ForeColor="White"/>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </asp:Panel>
    <asp:TextBox runat="server" ID="info" TextMode="MultiLine" Width="100%" Height="100px"></asp:TextBox>
    </form>    
</body>
</html>
