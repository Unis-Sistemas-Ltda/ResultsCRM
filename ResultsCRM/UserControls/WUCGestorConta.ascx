<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCGestorConta.ascx.vb" Inherits="ResultsCRM.WUCGestorConta" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
<link href="../ResultsCRMAjax.css" rel="stylesheet" type="text/css" />

<script type="text/javascript" language="javascript" src="../ResultsCRM.js"></script>

<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<div class="TituloCadastro">Detalhe do Cadastro Gestor de Conta</div>
<table class="TextoCadastro" style="width:100%;">
    <tr>
        <td class="Erro" colspan="2">
            <asp:Label ID="LblErro" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            Código:</td>
        <td class="CelulaCampoCadastro">
            <asp:Label ID="LblCodGestor" runat="server" Font-Bold="True"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            Usuário:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtCodUsuario" runat="server" CssClass="CampoCadastro" 
                MaxLength="6" Width="80px" AutoPostBack="True"></asp:TextBox>
            <asp:ImageButton ID="BtnPesquisar" runat="server" ImageUrl="~/Imagens/search.png" 
                onclientclick="ShowEditModal('../Pesquisas/WFPUsuario.aspx?textBox=TxtCodUsuario','EditModalPopupUsuarios','IframeEdit');" 
                ToolTip="Pesquisar"/>
            <asp:Label ID="LblNomeUsuario" runat="server" Height="17px"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            E-mail:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtEmail" runat="server" CssClass="CampoCadastro" 
                MaxLength="100" Width="300px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td colspan="2" style="text-align: center">
            <asp:Button ID="BtnGravar" runat="server" CssClass="Botao" Text="Gravar" />
        &nbsp;
            <asp:Button ID="BtnVoltar" runat="server" CssClass="Botao" Text="Voltar" />
        </td>
    </tr>
</table>

<%--este é o html para pesquisa de cores--%>
    <cc1:ModalPopupExtender ID="ModalPopupExtender2" BackgroundCssClass="ModalPopupBG"
        runat="server" CancelControlID="ButtonEditCancel" OkControlID="ButtonEditDone" 
        TargetControlID="BtnPesquisar" PopupControlID="DivEditWindow" 
        OnCancelScript="EditCancelScript('IframeEdit');" OnOkScript="EditOkayScript('IframeEdit');"
        BehaviorID="EditModalPopupUsuarios">
    </cc1:ModalPopupExtender>
    <%--botões padrão que ficam ocultos, são necessários, não remover--%>
    <div class="popup_Buttons" style="display: none">
        <input id="ButtonEditDone" value="Done" type="button" />
        <input id="ButtonEditCancel" value="Cancel" type="button" />
    </div>
    <%--frame onde é mostrado o popup--%>
    <div id="DivEditWindow" style="display: none;" class="popupConfirmation">
        <iframe id="IframeEdit" frameborder="0" width="370" height="350" scrolling="no">
        </iframe>
    </div>