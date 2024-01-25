<%@ Page Title="" Language="C#" MasterPageFile="~/MPUsuarios.master" AutoEventWireup="true" CodeFile="AltaPreguntas.aspx.cs" Inherits="AltaPreguntas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style2 {
            width: 219px;
        }
        .auto-style3 {
            width: 360px;
        }
        .auto-style4 {
            width: 219px;
            height: 29px;
        }
        .auto-style5 {
            width: 360px;
            height: 29px;
        }
        .auto-style6 {
            height: 29px;
        }
        .auto-style7 {
            width: 148px;
        }
        .auto-style8 {
            height: 29px;
            width: 148px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style7">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style7">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">Codigo (5 caracteres):</td>
            <td class="auto-style3">
                <asp:TextBox ID="txtCodigo" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style7">Texto respuesta:</td>
            <td>
                <asp:TextBox ID="txtTextoRespuesta" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Puntaje (del 1 al 10): </td>
            <td class="auto-style3">
                <asp:TextBox ID="txtPuntaje" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style7">Correcta:</td>
            <td>
                <asp:DropDownList ID="ddlCorrecta" runat="server">
                    <asp:ListItem Value="false">No</asp:ListItem>
                    <asp:ListItem Value="true">Si</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">Categoria:</td>
            <td class="auto-style5">
                <asp:DropDownList ID="ddlCategoria" runat="server">
                </asp:DropDownList>
            </td>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style6">
                <asp:Button ID="btnAltaRespuesta" runat="server" OnClick="btnAltaRespuesta_Click" Text="Agregar Respuesta" />
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Texto:</td>
            <td class="auto-style3">
                <asp:TextBox ID="txtTextoPregunta" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style7">&nbsp;</td>
            <td>
                <asp:ListBox ID="lbRespuestas" runat="server" Height="102px" Width="372px"></asp:ListBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">
                <asp:Button ID="btnAltaPregunta" runat="server" Text="Agregar Pregunta" OnClick="btnAltaPregunta_Click" />
            </td>
            <td class="auto-style7">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style7">
                <asp:Label ID="lblError" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>

