<%@ Page Title="" Language="C#" MasterPageFile="~/MPUsuarios.master" AutoEventWireup="true" CodeFile="ABMJuegos.aspx.cs" Inherits="ABMJuegos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">

    .auto-style2 {
        width: 81%;
        height: 427px;
    }
    .auto-style3 {
        font-size: large;
    }
    .auto-style5 {
        width: 253px;
    }
    .auto-style4 {
        width: 205px;
    }
    .auto-style1 {
        width: 387px;
    }
    .auto-style6 {
        width: 278px;
    }
    .auto-style7 {
        text-align: center;
    }
    .auto-style8 {
        font-size: large;
        width: 356px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="auto-style2">
    <tr>
        <td class="auto-style3" colspan="3"><strong>ABM de Juegos</strong></td>
        <td class="auto-style3">&nbsp;</td>
        <td class="auto-style8">&nbsp;</td>
        <td class="auto-style3">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style5" style="border: 2px inset #FF00FF; margin: 0px; background-color: #66FFFF;">&nbsp;</td>
        <td class="auto-style4" style="border: 2px inset #FF00FF; margin: 0px; background-color: #66FFFF;">&nbsp;</td>
        <td class="auto-style6" style="border: 2px inset #FF00FF; margin: 0px; background-color: #66FFFF;">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style7" style="border: 2px inset #FF00FF; margin: 0px; background-color: #66FFFF;" colspan="3">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style5" style="border: 2px inset #FF00FF; margin: 0px; background-color: #66FFFF;">Codigo:</td>
        <td class="auto-style4" style="border: 2px inset #FF00FF; margin: 0px; background-color: #66FFFF;">
            <asp:TextBox ID="txtCodigo" runat="server"></asp:TextBox>
        </td>
        <td class="auto-style6" style="border: 2px inset #FF00FF; margin: 0px; background-color: #66FFFF;">
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
        </td>
    </tr>
    <tr>
        <td class="auto-style5" style="border: 2px inset #FF00FF; margin: 0px; background-color: #66FFFF;">Dificultad:</td>
        <td class="auto-style4" style="border: 2px inset #FF00FF; margin: 0px; background-color: #66FFFF;">
            <asp:TextBox ID="txtDificultad" runat="server"></asp:TextBox>
        </td>
        <td class="auto-style6" style="border: 2px inset #FF00FF; margin: 0px; background-color: #66FFFF;">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style5" style="border: 2px inset #FF00FF; margin: 0px; background-color: #66FFFF;">Fecha Creado:</td>
        <td class="auto-style4" style="border: 2px inset #FF00FF; margin: 0px; background-color: #66FFFF;">
            <asp:TextBox ID="txtFecha" runat="server" TextMode="DateTime"></asp:TextBox>
        </td>
        <td class="auto-style6" style="border: 2px inset #FF00FF; margin: 0px; background-color: #66FFFF;">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style5" style="border: 2px inset #FF00FF; margin: 0px; background-color: #66FFFF;">Usuario creador:</td>
        <td class="auto-style4" style="border: 2px inset #FF00FF; margin: 0px; background-color: #66FFFF;">
            <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
        </td>
        <td class="auto-style6" style="border: 2px inset #FF00FF; margin: 0px; background-color: #66FFFF;">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style5" style="border: 2px inset #FF00FF; margin: 0px; background-color: #66FFFF;">&nbsp;</td>
        <td class="auto-style4" style="border: 2px inset #FF00FF; margin: 0px; background-color: #66FFFF;">&nbsp;</td>
        <td class="auto-style6" style="border: 2px inset #FF00FF; margin: 0px; background-color: #66FFFF;">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style5" style="border: 2px inset #FF00FF; margin: 0px; background-color: #66FFFF;">
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
        </td>
        <td class="auto-style4" style="border: 2px inset #FF00FF; margin: 0px; background-color: #66FFFF;">
            <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" />
        </td>
        <td class="auto-style6" style="border: 2px inset #FF00FF; margin: 0px; background-color: #66FFFF;">
            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
        </td>
    </tr>
    <tr>
        <td class="auto-style5" style="border: 2px inset #FF00FF; margin: 0px; background-color: #66FFFF;">&nbsp;</td>
        <td class="auto-style4" style="border: 2px inset #FF00FF; margin: 0px; background-color: #66FFFF;">
            <asp:Label ID="lblError" runat="server"></asp:Label>
        </td>
        <td class="auto-style6" style="border: 2px inset #FF00FF; margin: 0px; background-color: #66FFFF;">
            <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" OnClick="btnLimpiar_Click" />
        </td>
    </tr>
</table>
</asp:Content>

