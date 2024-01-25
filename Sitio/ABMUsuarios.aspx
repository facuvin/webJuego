﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MPUsuarios.master" AutoEventWireup="true" CodeFile="ABMUsuarios.aspx.cs" Inherits="ABMUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .auto-style1 {
        width: 387px;
    }
    .auto-style2 {
        width: 44%;
    }
    .auto-style3 {
        font-size: large;
    }
    .auto-style4 {
        width: 300px;
    }
    .auto-style5 {
        width: 253px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="auto-style2">
    <tr>
        <td class="auto-style3" colspan="3"><strong>ABM de Usuarios</strong></td>
    </tr>
    <tr>
        <td class="auto-style5">Nombre Usuario:</td>
        <td class="auto-style4">
            <asp:TextBox ID="txtNomUsu" runat="server"></asp:TextBox>
        </td>
        <td class="auto-style1">
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
        </td>
    </tr>
    <tr>
        <td class="auto-style5">Contraseña:</td>
        <td class="auto-style4">
            <asp:TextBox ID="txtPassw" runat="server" TextMode="Password"></asp:TextBox>
        </td>
        <td class="auto-style1">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style5">Nombre Completo:</td>
        <td class="auto-style4">
            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
        </td>
        <td class="auto-style1">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style5">
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
        </td>
        <td class="auto-style4">
            <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" />
        </td>
        <td class="auto-style1">
            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
        </td>
    </tr>
    <tr>
        <td class="auto-style5">&nbsp;</td>
        <td class="auto-style4">
            <asp:Label ID="lblError" runat="server"></asp:Label>
        </td>
        <td class="auto-style1">
            <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" OnClick="btnLimpiar_Click" />
        </td>
    </tr>
</table>
</asp:Content>

