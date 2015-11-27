<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterEmpresa.Master" AutoEventWireup="true" CodeBehind="ventajas.aspx.cs" Inherits="MerCadona.Vistas.Empresa.ventajas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentPanel_body" runat="server">
    <div class="cont clearfix">
        <h2>Ventajas: Máxima calidad y seguridad alimentaria</h2>
        <p>
            En Mercadona trabajamos para garantizar a nuestros clientes la máxima seguridad, calidad y frescura en todos los productos:
        </p>
        <ul style="list-style: disc outside;margin-left:14px;">
            <li>Los compramos directamente en origen. Sin intermediarios. </li>
            <li>Planificamos nuestra compra, y acortamos el tiempo de almacenaje y transporte, para mantenerlos siempre en su temperatura óptima.</li>
            <li>Todos los productos de Mercadona son sometidos a rigurosos controles de calidad, para garantizar que siempre estén en perfectas condiciones de higiene.</li>
        </ul>
        <asp:Panel runat="server" class="fotomenu" HorizontalAlign="Center">
            <img alt="Mercadona garantiza en todos sus productos la máxima seguridad, calidad y frescura." height="164" src="https://www.mercadona.es/corp/images/content/pan_pescado_fruta_carne14.jpg" title="Mercadona garantiza en todos sus productos la máxima seguridad, calidad y frescura." width="590" />
        </asp:Panel>
    </div>
</asp:Content>
