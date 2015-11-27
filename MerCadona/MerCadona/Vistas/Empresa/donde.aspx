<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterEmpresa.Master" AutoEventWireup="true" CodeBehind="donde.aspx.cs" Inherits="MerCadona.Vistas.donde" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentPanel_body" runat="server">
    <asp:Label runat="server" Text="¿DÓNDE ESTAMOS?" Font-Bold="true" ForeColor="DarkGreen"></asp:Label>
    <asp:Panel runat="server" Width="100%" style="margin-top:30px">
        <asp:Table runat="server" ID="tabla_Inicial" Width="800px" HorizontalAlign="Center" BorderColor="DarkGreen" BorderWidth="1px">
            <asp:TableRow>
                <asp:TableCell ForeColor="White" BackColor="DarkGreen" HorizontalAlign="Center">
                    Situacion Geografica
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    Haga clic sobre el nombre de la provincia de la cual desea obtener información acerca de sus supermercados
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    Provincias 
                    <asp:DropDownList runat="server" ID="list_Provincias" Width="200px" style="margin-left:20px; text-align:center"></asp:DropDownList>
                    <asp:Button runat="server" Text="Buscar" style="margin-left:20px" BorderColor="DarkGreen" ForeColor="DarkGreen" BackColor="White" BorderWidth="1px"/>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>

        <asp:Table runat="server" ID="tabla_Filtrado" Width="800px" HorizontalAlign="Center" BorderColor="DarkGreen" BorderWidth="1px" Visible="false" CellSpacing="0">
            <asp:TableRow>
                <asp:TableCell ForeColor="White" BackColor="DarkGreen" HorizontalAlign="Center" ColumnSpan="2">
                    Ajuste su busqueda
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    Provincia
                    <br /><asp:DropDownList runat="server" ID="list_Provincia" Width="200px" style="text-align:center"></asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Center">
                    Localidad
                    <br /><asp:DropDownList runat="server" ID="list_Localidad" Width="200px" style="text-align:center"></asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center" ColumnSpan="2">
                    Horario comercial
                    <br /><asp:DropDownList runat="server" ID="list_Horarios" Width="200px" style="text-align:center"></asp:DropDownList>
                </asp:TableCell>                
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center" ColumnSpan="2">                                 
                    <asp:Button runat="server" ID="button_Filtrar" Text="Filtrar" ForeColor="DarkGreen" BackColor="White" BorderColor="DarkGreen" BorderWidth="1px"/>               
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>

        <asp:Table runat="server" ID="tabla_Filtrado2" Width="800px" HorizontalAlign="Center" BorderColor="DarkGreen" BorderWidth="1px" Visible="false" style="margin-top:20px" BackColor="LightGreen">
            <asp:TableRow>                
                <asp:TableCell ForeColor="White" BackColor="DarkGreen" HorizontalAlign="Center" ColumnSpan="5">
                    <asp:Label runat="server" ID="label_Provincia" Text="Provincia seleccionada"></asp:Label>
                </asp:TableCell>            
            </asp:TableRow>
            <asp:TableRow ForeColor="White" BackColor="ForestGreen" HorizontalAlign="Center">
                <asp:TableCell Width="300px">
                    DIRECCION
                </asp:TableCell>
                <asp:TableCell Width="70px">
                    CODIGO POSTAL
                </asp:TableCell>
                <asp:TableCell Width="100px">
                    TELEFONO
                </asp:TableCell>
                <asp:TableCell Width="150px">
                    HORARIO COMERCIAL
                </asp:TableCell>
                <asp:TableCell Width="80px">
                    PARKING
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </asp:Panel>        
</asp:Content>
