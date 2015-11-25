<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterEmpresa.Master" AutoEventWireup="true" CodeBehind="atencion.aspx.cs" Inherits="MerCadona.Vistas.atencion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentPanel_body" runat="server">
    <asp:Table runat="server" HorizontalAlign="Center" CellPadding="5" BorderColor="DarkGreen" BorderWidth="1px">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" Text="ATENCIÓN AL CLIENTE" ForeColor="DarkGreen" Font-Bold="true"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan="2">
                <asp:Label runat="server" Text="Información, sugerencias, reclamaciones,... llámenos y resolveremos todas sus dudas."></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow HorizontalAlign="Center">
            <asp:TableCell ColumnSpan="2">
                <asp:Label runat="server" Text="900 500 103" Font-Size="X-Large" Font-Bold="true"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan="2">
                <asp:Label runat="server" Text="Además, si lo desea, puede hacerlo a través del siguiente formulario"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" Text="Asunto" style="margin-left:20px"></asp:Label>
                <asp:Label runat="server" Text="*" ForeColor="DarkRed"></asp:Label>
            </asp:TableCell>
            <asp:TableCell HorizontalAlign="Right">
                <asp:CustomValidator OnServerValidate="cv_Asunto_ServerValidate" ID="cv_Asunto" runat="server" ForeColor="DarkRed" Font-Size="Small" ErrorMessage="Hay que selecionar una opcion" style="margin-right:10px"></asp:CustomValidator>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Center">                
                <asp:RadioButton runat="server" ID="radio_Felicitacion" GroupName="asunto" Text="Felicitacion"/>               
            </asp:TableCell>
            <asp:TableCell>
                <asp:RadioButton runat="server" ID="radio_Informacion" GroupName="asunto" Text="Solicitud de informacion"/> 
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Center">
                <asp:RadioButton runat="server" ID="radio_Sugerencia" GroupName="asunto" Text="Sugerencia"/> 
            </asp:TableCell>
            <asp:TableCell>
                <asp:RadioButton runat="server" ID="radio_Reclamacion" GroupName="asunto" Text="Reclamacion"/> 
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" Text="Escribe aqui tu mensaje" style="margin-left:20px"></asp:Label>
                <asp:Label runat="server" Text="*" ForeColor="DarkRed"></asp:Label>
            </asp:TableCell>
            <asp:TableCell HorizontalAlign="Right">
                <asp:RequiredFieldValidator ID="fv_Mensaje" runat="server" ForeColor="DarkRed" Font-Size="Small" ErrorMessage="Este campo no puede estar vacio" ControlToValidate="textarea_Mensaje" style="margin-right:10px"></asp:RequiredFieldValidator>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Center" ColumnSpan="2">
                <asp:TextBox runat="server" ID="textarea_Mensaje" Width="95%" TextMode="MultiLine" Rows="8" Columns ="50" MaxLength="140"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" Text="Datos Personales" style="margin-left:20px"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow HorizontalAlign="Right">
            <asp:TableCell>                
                Nombre <asp:TextBox runat="server" ID="text_Nombre" Width="40%"/>
            </asp:TableCell><asp:TableCell>
                DNI <asp:TextBox runat="server" ID="text_Dni" Width="40%" style="margin-right:50px"/>
            </asp:TableCell></asp:TableRow><asp:TableRow HorizontalAlign="Right">
            <asp:TableCell>                
                Apellido1 <asp:TextBox runat="server" ID="text_Apellido1" Width="40%"/>
            </asp:TableCell><asp:TableCell>
                Apellido2 <asp:TextBox runat="server" ID="text_Apellido2" Width="40%" style="margin-right:50px"/>
            </asp:TableCell></asp:TableRow><asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" Text="Direccion de contacto" style="margin-left:20px"></asp:Label>
            </asp:TableCell></asp:TableRow><asp:TableRow HorizontalAlign="Right">
            <asp:TableCell>                
                Provincia <asp:TextBox runat="server" ID="text_Provincia" Width="40%"/>
            </asp:TableCell><asp:TableCell>
                Localidad <asp:TextBox runat="server" ID="text_Localidad" Width="40%" style="margin-right:50px"/>
            </asp:TableCell></asp:TableRow><asp:TableRow HorizontalAlign="Right">
            <asp:TableCell>                
                Codigo Postal <asp:TextBox runat="server" ID="text_Cp" Width="40%"/>
            </asp:TableCell><asp:TableCell>
                Tipo Via <asp:TextBox runat="server" ID="text_TipoVia" Width="40%" style="margin-right:50px"/>
            </asp:TableCell></asp:TableRow><asp:TableRow HorizontalAlign="Right">
            <asp:TableCell>                
                Nombre Via <asp:TextBox runat="server" ID="text_NombreVia" Width="40%"/>
            </asp:TableCell><asp:TableCell>
                Nº/Km <asp:TextBox runat="server" ID="text_Numero" Width="40%" style="margin-right:50px"/>
            </asp:TableCell></asp:TableRow><asp:TableRow>
            <asp:TableCell ColumnSpan="2">
                <asp:Label runat="server" Text="Datos de contacto (Si desea respuesta ha de rellenar al menos uno de los dos campos):" style="margin-left:20px"></asp:Label>
            </asp:TableCell></asp:TableRow><asp:TableRow HorizontalAlign="Right">
            <asp:TableCell>                
                Telefono <asp:TextBox runat="server" ID="text_Telefono" Width="40%"/>
            </asp:TableCell><asp:TableCell>
                Email <asp:TextBox runat="server" ID="text_Email" Width="50%" style="margin-right:50px"/>
            </asp:TableCell></asp:TableRow><asp:TableRow>
            <asp:TableCell ColumnSpan="2">
                <asp:CheckBox runat="server" ID="check_Edad" Text="Soy mayor de 14 años y he leído y acepto la Política de Confidencialidad y Protección de Datos" />
            </asp:TableCell></asp:TableRow><asp:TableRow>
            <asp:TableCell ColumnSpan="2">
                <asp:CheckBox runat="server" ID="check_Autorizacion" Text="Autorizo a que mis datos se utilicen para informarme de productos y servicios, incluido por vía electrónica" />
            </asp:TableCell></asp:TableRow><asp:TableRow>
            <asp:TableCell ColumnSpan="2">
                <asp:CheckBox runat="server" ID="check_Firma" Text="Firmar digitalmente" />
            </asp:TableCell></asp:TableRow><asp:TableRow>
            <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
                <asp:Button runat="server" ID="button_Consulta" Text="Enviar Consulta" OnClick="button_Consulta_Click" />
            </asp:TableCell></asp:TableRow><asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" Text="*" ForeColor="DarkRed"></asp:Label> Campo Obligatorio
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <asp:TextBox runat="server" ID="info" TextMode="MultiLine" Width="100%" Height="50%"></asp:TextBox>
</asp:Content>