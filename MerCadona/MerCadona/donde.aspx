<%@ Page Title="" Language="C#" MasterPageFile="~/MasterEmpresa.Master" AutoEventWireup="true" CodeBehind="donde.aspx.cs" Inherits="MerCadona.donde" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentPanel_body" runat="server">
    <asp:Label runat="server" Text="¿DÓNDE ESTAMOS?" Font-Bold="true" ForeColor="DarkGreen"></asp:Label>
    <asp:Panel runat="server" HorizontalAlign="Center" Width="100%">
        <asp:Table runat="server" Width="70%" HorizontalAlign="Center" BorderColor="DarkGreen" BorderWidth="1px">
            <asp:TableRow>
                <asp:TableHeaderCell>
                    <asp:Label runat="server" Text="Situacion Geografica" BackColor="DarkGreen" ForeColor="White"></asp:Label>                    
                </asp:TableHeaderCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <p>Haga clic sobre el nombre de la provincia de la cual desea obtener información acerca de sus supermercados.</p>
                    <asp:Label runat="server" Text="Elija Provincia"></asp:Label>
                    <asp:DropDownList ID="list_Provincias" runat="server" Width="50%"></asp:DropDownList>
                    <asp:Button runat="server" ID="button_Aceptar" Text="Aceptar" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </asp:Panel>
</asp:Content>
