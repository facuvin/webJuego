<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 13px;
        }
        .auto-style2 {
            width: 420px;
        }
        .auto-style3 {
            height: 13px;
            width: 420px;
        }
        .auto-style4 {
            width: 432px;
        }
        .auto-style5 {
            height: 13px;
            width: 432px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <table style="width:100%;">
            <tr>
                <td class="auto-style2">
                    <asp:LinkButton ID="lnkLogueo" runat="server" PostBackUrl="~/Logueo.aspx">Logueo de Usuarios Administradores</asp:LinkButton>
                </td>
                <td class="auto-style4">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:LinkButton ID="lnkJugar" runat="server" PostBackUrl="~/Jugar.aspx">Jugar</asp:LinkButton>
                </td>
                <td class="auto-style4">Filtro por nombre de jugador:</td>
                <td>Filtro por dificultad:</td>
            </tr>
            <tr>
                <td class="auto-style3">
                    &nbsp;</td>
                <td class="auto-style5">
                    <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                    <asp:Button ID="btnFiltroNombre" runat="server" OnClick="btnFiltroNombre_Click" Text="Filtrar" />
                </td>
                <td class="auto-style1">
                    <asp:DropDownList ID="ddlDificultad" runat="server">
                        <asp:ListItem Value="FACIL">FACIL</asp:ListItem>
                        <asp:ListItem Value="MEDIO">MEDIO</asp:ListItem>
                        <asp:ListItem Value="DIFICIL">DIFICIL</asp:ListItem>
                    </asp:DropDownList>
                    <asp:Button ID="btnFiltroDificultad" runat="server" OnClick="btnFiltroDificultad_Click" Text="Filtrar" />
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style4">
                    <asp:GridView ID="gvJugadas" runat="server" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="FechaYHora" HeaderText="Fecha" />
                            <asp:BoundField DataField="NomJugador" HeaderText="Jugador" />
                            <asp:BoundField DataField="Puntaje" HeaderText="Puntaje" />
                            <asp:BoundField DataField="Juego.Dificultad" HeaderText="Dificultad" />
                        </Columns>
                    </asp:GridView>
                </td>
                <td>
                    <asp:Button ID="btnOrdenar" runat="server" OnClick="btnOrdenar_Click" Text="Ordenar Lista" />
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style4">
                    <asp:Label ID="lblError" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Button ID="btnLimpiar" runat="server" OnClick="btnLimpiar_Click" Text="Limpiar Filtros" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
