<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFRelAtividade.aspx.vb" Inherits="ResultsCRM.WFRelAtividade" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="WebDataWindow" Namespace="Sybase.DataWindow.Web" TagPrefix="dw" %>
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
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True"></asp:ScriptManager>
    <div class="TituloRelatorio">Relatório de Atividades</div>
    <table style="width:100%;" class="TextoCadastro">
        <tr>
            <td colspan="2" style="text-align: left">
                <asp:Label ID="lblErro" runat="server" CssClass="Erro"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: left">
                Informe abaixo os filtros desejados e clique em Visualizar.</td>
        </tr>
        <tr>
            <td style="text-align: right">
                <asp:Label ID="Label1" runat="server" Text="Período:"></asp:Label>
            </td>
            <td class="CelulaCampoCadastro">
                <uc1:TextBoxData ID="TxtData1" runat="server" />
            &nbsp;<uc1:TextBoxData ID="TxtData2" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; text-align: right">
                Conteúdo:</td>
            <td style="text-align: left">
                <asp:ListBox ID="LbxTipo" runat="server" CssClass="CampoCadastro" 
                    SelectionMode="Multiple" Width="200px">
                    <asp:ListItem Selected="True" Value="0">Tudo</asp:ListItem>
                    <asp:ListItem Value="1">Ações/Follow-ups</asp:ListItem>
                    <asp:ListItem Value="2">Tarefas</asp:ListItem>
                    <asp:ListItem Value="3">Visitações</asp:ListItem>
                </asp:ListBox>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; text-align: right">
                Canal de Vendas:</td>
            <td style="text-align: left">
                <asp:ListBox ID="LbxCanalVenda" runat="server" CssClass="CampoCadastro" 
                    Rows="6" SelectionMode="Multiple" Width="200px"></asp:ListBox>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; text-align: right">
                Usuário:</td>
            <td style="text-align: left">
                <asp:ListBox ID="LbxUsuario" runat="server" CssClass="CampoCadastro" Rows="6" 
                    SelectionMode="Multiple" Width="200px"></asp:ListBox>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; text-align: right">
                Carteira:</td>
            <td style="text-align: left">
                <asp:ListBox ID="LbxCarteira" runat="server" CssClass="CampoCadastro" Rows="6" 
                    SelectionMode="Multiple" Width="200px"></asp:ListBox>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="text-align: left">
                <asp:Button ID="BtnOk" runat="server" CssClass="Botao" Text="Visualizar" 
                    TabIndex="1" />
            &nbsp;</td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                &nbsp;</td>
        </tr>
        </table>
    <%--este é o html para pesquisa de itens--%>    <%--botões padrão que ficam ocultos, são necessários, não remover--%>
    <div class="popup_Buttons" style="display: none">
        <input id="ButtonEditDone" value="Done" type="button" />
        <input id="ButtonEditCancel" value="Cancel" type="button" />
    </div>
    <%--frame onde é mostrado o popup--%>
    <div id="DivEditWindow" style="display: none;" class="popupConfirmation">
        <iframe id="IframeEdit" frameborder="0" width="370" height="350" scrolling="no">
        </iframe>
    </div>
    </form>
</body>
</html>
