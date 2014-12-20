<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Vendedores.aspx.cs" Inherits="Mes.Testing.Vendedores" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
    <script src="js/jQuery.js"></script>
    <script src="js/Webservices.js"></script>

    <style type="text/css">
        .auto-style1 {
            width: 112px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <p>
            &nbsp;<asp:Button ID="btnSelect" OnClientClick ="getVendedores();return false;" runat="server" Text="Lista" />
            
            <asp:TextBox ID="IdVendedor" ClientIDMode ="static" runat="server"></asp:TextBox>
            <asp:Button ID="Button1" OnClientClick ="getVendedor();return false;" runat="server" Text="Obtener" />

        </p>
        <asp:Panel ID="pLista" ClientIDMode ="static" runat="server">
        </asp:Panel>
        &nbsp;<table style="width: 100%;">
            <tr>
                <td class="auto-style1">OrchardID</td>
                <td>
                    <asp:TextBox ID="OrchardID" ClientIDMode ="static" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">Estado</td>
                <td>
                    <asp:TextBox ID="Estado" ClientIDMode ="static" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">Nombre</td>
                <td>
                    <asp:TextBox ID="Nombre" ClientIDMode ="static" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">Direccion</td>
                <td>
                    <asp:TextBox ID="Direccion" ClientIDMode ="static" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">TipoCuenta</td>
                <td>
                    <asp:TextBox ID="TipoCuenta" ClientIDMode ="static" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Button ID="btnAlta" OnClientClick ="postVendedores();return false;"  runat="server" Text="Alta" />
                    <asp:Button ID="Button3" OnClientClick ="putVendedores();return false;" runat="server" Text="Modificar" />
                </td>
                <td>
                    <asp:Button ID="Button2" runat="server" OnClientClick ="deleteVendedor();return false;"  Text="Eliminar" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>
