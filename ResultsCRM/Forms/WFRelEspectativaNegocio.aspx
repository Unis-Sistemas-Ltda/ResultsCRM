<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFRelEspectativaNegocio.aspx.vb" Inherits="ResultsCRM.WFRelEspectativaNegocio" %>

<%@ Register src="../OutrosControles/TextBoxData.ascx" tagname="TextBoxData" tagprefix="uc1" %>

<%@ Register assembly="WebDataWindow" namespace="Sybase.DataWindow.Web" tagprefix="dw" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="TituloRelatorio">
        <asp:ScriptManager ID="ScriptManager1" runat="server" 
            EnableScriptGlobalization="True">
        </asp:ScriptManager>
        Relatório de Expectativa de Negócio</div>
    <table style="width:100%;" class="TextoCadastro">
        <tr>
            <td colspan="3" style="text-align: left">
                <asp:Label ID="lblErro" runat="server" CssClass="Erro"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Período:"></asp:Label>
            </td>
            <td style="text-align: left">
                <uc1:TextBoxData ID="TxtData1" runat="server" />
            &nbsp;a
                <uc1:TextBoxData ID="TxtData2" runat="server" />
            </td>
            <td style="text-align: left">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Agente de Vendas:"></asp:Label>
            </td>
            <td class="CelulaCampoCadastro">
                <asp:DropDownList ID="ddlAgente" runat="server" CssClass="CampoCadastro" 
                    Width="300px">
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Canal de Venda:"></asp:Label>
            </td>
            <td class="CelulaCampoCadastro">
                <asp:DropDownList ID="ddlCanal" runat="server" CssClass="CampoCadastro" 
                    Width="300px">
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label5" runat="server" Text="Situação:"></asp:Label>
            </td>
            <td class="CelulaCampoCadastro">
                <asp:DropDownList ID="ddlSituacao" runat="server" CssClass="CampoCadastro" 
                    Width="300px">
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label6" runat="server" Text="Cidade:"></asp:Label>
            </td>
            <td class="CelulaCampoCadastro">
                <asp:TextBox ID="TxtCidade" runat="server" CssClass="CampoCadastro" 
                    Width="300px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Modelo:"></asp:Label>
            </td>
            <td class="CelulaCampoCadastro">
                <asp:RadioButtonList ID="rblModelo" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Selected="True" Value="A">Analítico</asp:ListItem>
                    <asp:ListItem Value="S">Sintético</asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td class="style1" style="text-align: left">
                <asp:Button ID="BtnOk" runat="server" CssClass="Botao" Text="Visualizar" />
            &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        </table>
</form>
</body>
</html>
