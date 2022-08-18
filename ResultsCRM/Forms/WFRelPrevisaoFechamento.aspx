<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFRelPrevisaoFechamento.aspx.vb" Inherits="ResultsCRM.WFRelPrevisaoFechamento" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register src="../OutrosControles/TextBoxData.ascx" tagname="TextBoxData" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
    <link href="../ResultsCRMAjax.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="../ResultsCRM.js"></script>
    </head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" 
        EnableScriptGlobalization="True"></asp:ScriptManager>
    <div class="TituloRelatorio">Relatório de Previsão de Fechamento</div>
    <table style="width:100%;" class="TextoCadastro">
        <tr>
            <td colspan="2" style="text-align: left">
                <asp:Label ID="lblErro" runat="server" CssClass="Erro"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                <asp:Label ID="Label1" runat="server" Text="Previsão de Fechamento:"></asp:Label>
            </td>
            <td class="CelulaCampoCadastro">
                <uc1:TextBoxData ID="TxtData1" runat="server" />
                <asp:Label ID="Label5" runat="server" Text="&nbsp;a" Height="17px"></asp:Label>
            &nbsp;<uc1:TextBoxData ID="TxtData2" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                Vendedor/Representante:</td>
            <td class="CelulaCampoCadastro">
                <asp:DropDownList ID="ddlRepresentante" runat="server" CssClass="CampoCadastro" 
                    Width="300px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                <asp:Label ID="Label3" runat="server" Text="Canal de Vendas:"></asp:Label>
            </td>
            <td class="CelulaCampoCadastro">
                <asp:DropDownList ID="ddlCanalVenda" runat="server" CssClass="CampoCadastro" 
                    Width="300px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                <asp:Label ID="Label2" runat="server" Text="Funil:"></asp:Label>
            </td>
            <td class="CelulaCampoCadastro">
                <asp:DropDownList ID="DdlFunil" runat="server" CssClass="CampoCadastro" 
                Width="300px" AutoPostBack="True">
            </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                Probabilidade de Sucesso:</td>
            <td class="CelulaCampoCadastro">
                <asp:TextBox ID="TxtProbabilidadeSucesso1" runat="server" 
                    CssClass="CampoCadastro" TextMode="Number" Width="50px"></asp:TextBox>
                <asp:Label ID="Label6" runat="server" Text="&nbsp;a&nbsp;" Height="17px"></asp:Label>
                <asp:TextBox ID="TxtProbabilidadeSucesso2" runat="server" 
                    CssClass="CampoCadastro" TextMode="Number" Width="50px"></asp:TextBox>
                <asp:Label ID="Label4" runat="server" Text="&nbsp;%" Height="17px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: right" valign="top">
                Status:</td>
            <td class="CelulaCampoCadastro">
                <asp:ListBox ID="DdlStatus" runat="server" CssClass="CampoCadastro" Rows="6" 
                    SelectionMode="Multiple" Width="300px"></asp:ListBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                País:</td>
            <td style="text-align: left">
            <asp:DropDownList ID="DdlPais" runat="server" AutoPostBack="True" 
                CssClass="CampoCadastro" Width="300px">
            </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                Estado:</td>
            <td style="text-align: left">
            <asp:DropDownList ID="DdlEstado" runat="server" AutoPostBack="True" 
                CssClass="CampoCadastro" Width="300px">
            </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                Cidade:</td>
            <td style="text-align: left">
            <asp:DropDownList ID="DdlCidade" runat="server" CssClass="CampoCadastro" 
                Width="300px">
            </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="text-align: left">
                <asp:Button ID="BtnOk" runat="server" CssClass="Botao" Text="Visualizar" 
                    TabIndex="1" />
            </td>
        </tr>
        </table>
    </form>
</body>
</html>
