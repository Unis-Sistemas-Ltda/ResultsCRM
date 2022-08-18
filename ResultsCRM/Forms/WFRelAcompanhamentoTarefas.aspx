<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFRelAcompanhamentoTarefas.aspx.vb" Inherits="ResultsCRM.WFRelAcompanhamentoTarefas" %>

<%@ Register src="../OutrosControles/TextBoxData.ascx" tagname="TextBoxData" tagprefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register assembly="WebDataWindow" namespace="Sybase.DataWindow.Web" tagprefix="dw" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
    <link href="../ResultsCRMAjax.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="../ResultsCRM.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="TituloRelatorio">
        Relatório de Acompanhamento de Tarefas</div>
    <table style="width:100%;" class="TextoCadastro">
        <tr>
            <td colspan="3" style="text-align: left">
                <asp:Label ID="lblErro" runat="server" CssClass="Erro"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Responsável:"></asp:Label>
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
                <asp:Label ID="Label4" runat="server" Text="Cliente:"></asp:Label>
            </td>
            <td class="CelulaCampoCadastro">
                <asp:TextBox ID="TxtCodEmitente" runat="server" AutoPostBack="True" 
                    CssClass="CampoCadastro" Width="60px"></asp:TextBox>
&nbsp;<asp:ImageButton ID="BtnFiltrarCliente" runat="server" 
                ImageUrl="~/Imagens/search.png" ToolTip="Pesquisar" 
                onclientclick="ShowEditModal('../Pesquisas/WFPCliente.aspx?textbox=TxtCodEmitente&amp;varmp=SCodClientePesquisado&amp;varma=SAlterouCodCliente','EditModalPopupAlterarContato','IframeEdit');" 
                Height="16px" Width="16px" />&nbsp;<asp:Label ID="LblNomeCliente" runat="server" Height="16px"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Status Tarefa:"></asp:Label>
            </td>
            <td class="CelulaCampoCadastro">
                <asp:RadioButtonList ID="RblTipo" runat="server" CssClass="CampoCadastro" 
                    RepeatColumns="2">
                    <asp:ListItem Selected="True" Value="P">Pendentes</asp:ListItem>
                    <asp:ListItem Value="T">Todas</asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="text-align: left">
                <asp:Button ID="BtnOk" runat="server" CssClass="Botao" Text="Visualizar" />
            &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        </table>
        <cc1:ModalPopupExtender ID="ModalPopupExtender4" BackgroundCssClass="ModalPopupBG"
        runat="server" CancelControlID="ButtonEditCancel" OkControlID="ButtonEditDone" 
        TargetControlID="BtnFiltrarCliente" PopupControlID="DivEditWindow" 
        OnCancelScript="EditCancelScript('IframeEdit');" OnOkScript="EditOkayScript('IframeEdit');"
        BehaviorID="EditModalPopupAlterarContato">
    </cc1:ModalPopupExtender>
<%--botões padrão que ficam ocultos, são necessários, não remover--%>
    <div class="popup_Buttons" style="display: none">
        <input id="ButtonEditDone" value="Done" type="button" />
        <input id="ButtonEditCancel" value="Cancel" type="button" />
    </div>
<%--frame onde é mostrado o popup--%>
    <div id="DivEditWindow" style="display: none;" class="popupConfirmation">
        <iframe id="IframeEdit" frameborder="0" width="370" height="410" scrolling="no">
        </iframe>
    </div>
</form>
</body>
</html>
