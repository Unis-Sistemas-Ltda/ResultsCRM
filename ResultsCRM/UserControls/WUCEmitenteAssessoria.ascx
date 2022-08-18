<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCEmitenteAssessoria.ascx.vb"
    Inherits="ResultsCRM.WUCEmitenteAssessoria" %>
<%@ Register Src="../OutrosControles/TextBoxInteiro.ascx" TagName="TextBoxInteiro"
    TagPrefix="uc1" %>
<%@ Register Src="../OutrosControles/TextBoxData.ascx" TagName="TextBoxData" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
<link href="../ResultsCRMAjax.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" language="javascript" src="../ResultsCRM.js"></script>
<table class="TextoCadastro" style="width: 100%;">
    <tr>
        <td class="Erro" colspan="2">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:Label ID="LblErro" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Assessoria:
        </td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="DdlAssessoria" runat="server" CssClass="CampoCadastro" 
                Width="300px" AutoPostBack="True">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Fornecedor:
        </td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtFornecedor" runat="server" CssClass="CampoCadastro" Style="text-align: center"
                Width="43px" MaxLength="6" AutoPostBack="True" Height="18px"></asp:TextBox>
            &nbsp;<asp:ImageButton ID="BtnFiltrarCliente" runat="server" ImageUrl="~/Imagens/search.png"
                ToolTip="Pesquisar" OnClientClick="ShowEditModal('../Pesquisas/WFPFornecedor.aspx?textbox=TxtFornecedor&amp;varmp=SCodFornecedorPesquisado&amp;varma=SAlterouCodFornecedor','EditModalPopupClientes','IframeEdit');"
                Height="16px" Width="16px" />
            <cc1:ModalPopupExtender ID="ModalPopupExtender2" BackgroundCssClass="ModalPopupBG"
                runat="server" CancelControlID="ButtonEditCancel" OkControlID="ButtonEditDone"
                TargetControlID="BtnFiltrarCliente" PopupControlID="DivEditWindow" OnCancelScript="EditCancelScript('IframeEdit');"
                OnOkScript="EditOkayScript('IframeEdit');" BehaviorID="EditModalPopupClientes">
            </cc1:ModalPopupExtender>
            &nbsp;<asp:Label ID="LblNomeFornecedor" runat="server" Font-Bold="False"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Etapa:
        </td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="DdlEtapa" runat="server" CssClass="CampoCadastro" Width="300px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Data Solicitação:
        </td>
        <td class="CelulaCampoCadastro">
            <uc1:TextBoxData ID="TxtDataSolicitacao" runat="server" Width="90" />
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Data Credenciamento:
        </td>
        <td class="CelulaCampoCadastro">
            <uc1:TextBoxData ID="TxtDataCredenciamento" runat="server" Width="90" />
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Data Descredenciamento:
        </td>
        <td class="CelulaCampoCadastro">
            <uc1:TextBoxData ID="TxtDataDescredenciamento" runat="server" Width="90" />
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Login:
        </td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtLogin" runat="server" CssClass="CampoCadastro" Width="90px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Senha:
        </td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtSenha" runat="server" CssClass="CampoCadastro" Width="90px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td colspan="2" style="text-align: center">
            <br />
            <asp:Button ID="BtnGravar" runat="server" CssClass="Botao" Text="Gravar" />
        </td>
    </tr>
</table>
<%--este é o html para pesquisa de emitentes--%><%--este é o html para incluir emitente via negociação--%><%--este é o html para alterar cadastro de emitente via negociação--%><%--este é o html para funcionar o botão de incluir contatos--%><%--este é o html para funcionar o botão de incluir contatos--%><%--botões padrão que ficam ocultos, são necessários, não remover--%>
<div class="popup_Buttons" style="display: none">
    <input id="ButtonEditDone" value="Done" type="button" />
    <input id="ButtonEditCancel" value="Cancel" type="button" />
</div>
<%--frame onde é mostrado o popup--%>
<div id="DivEditWindow" style="display: none;" class="popupConfirmation">
    <iframe id="IframeEdit" frameborder="0" width="420" height="435" scrolling="no">
    </iframe>
</div>
