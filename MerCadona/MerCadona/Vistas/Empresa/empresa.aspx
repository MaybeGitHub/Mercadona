<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterEmpresa.Master" AutoEventWireup="true" CodeBehind="empresa.aspx.cs" Inherits="MerCadona.Vistas.empresa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentPanel_body" runat="server">

    <div id="content">
        <div id="main_content">
            <div class="cont clearfix">
                <h2 class="tituloh1">¿Qué es Mercadona?</h2>
                <p>
                    Mercadona es una compañía de supermercados, de capital 100% español y familiar, que tiene por objetivo satisfacer las necesidades en alimentación, higiene personal y cuidado del hogar y mascotas de sus clientes. Su presidente ejecutivo es Juan Roig.</p>
                <p>
                    La compañía está presente en 49 provincias de 17 Comunidades Autónomas con un total de 1.559 supermercados de barrio (27/11/2015) que, con una media de 1.500 metros cuadrados de sala de ventas, representan una cuota de mercado sobre la superficie total de alimentación en España del 14,4% y contribuyen al dinamismo del entorno comercial en el que están ubicadas.</p>
                <p>
                    Para realizar su actividad diaria y satisfacer a los 4,9 millones de hogares que realizan diariamente su compra en Mercadona, actualmente la compañía cuenta con una plantilla de 74.000 trabajadores, todos con empleo estable y de calidad, que desarrollan su carrera profesional en la empresa.</p>
                <asp:Panel runat="server" class="fotomenu" HorizontalAlign="Center" >
                    <img alt="Varias imágenes de Mercadona: de una tienda, de “Jefes”, nombre con que Mercadona denomina a sus clientes, de “El Trabajador” y de “El Proveedor”" height="118" src="https://www.mercadona.es/corp/images/content/tienda_jefe_trabajador_producto2014.jpg" title="Varias imágenes de Mercadona: de una tienda, de “Jefes”, nombre con que Mercadona denomina a sus clientes, de “El Trabajador” y de “El Proveedor”" width="590" />
                </asp:Panel>
            </div>
        </div>
    </div>

</asp:Content>
