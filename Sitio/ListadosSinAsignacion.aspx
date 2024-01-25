<%@ Page Title="" Language="C#" MasterPageFile="~/MPUsuarios.master" AutoEventWireup="true" CodeFile="ListadosSinAsignacion.aspx.cs" Inherits="ListadosSinAsignacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:DropDownList ID="ddlFiltro" runat="server">
                    <asp:ListItem Value="0">Juegos Nunca Usados</asp:ListItem>
                    <asp:ListItem Value="1">Preguntas Nunca Usadas</asp:ListItem>
                    <asp:ListItem Value="2">Juegos Vacios</asp:ListItem>
                </asp:DropDownList>
                <asp:Button ID="btnListar" runat="server" OnClick="btnListar_Click" Text="Listar" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:GridView ID="gvListado" runat="server">
                </asp:GridView>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Label ID="lblError" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>

