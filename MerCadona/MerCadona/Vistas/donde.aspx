<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterEmpresa.Master" AutoEventWireup="true" CodeBehind="donde.aspx.cs" Inherits="MerCadona.Vistas.donde" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentPanel_body" runat="server">
    <asp:Label runat="server" Text="¿DÓNDE ESTAMOS?" Font-Bold="true" ForeColor="DarkGreen"></asp:Label>
    <asp:TextBox runat="server" TextMode="MultiLine" ID="info" Width="100%" Height="30%"></asp:TextBox>    
</asp:Content>
