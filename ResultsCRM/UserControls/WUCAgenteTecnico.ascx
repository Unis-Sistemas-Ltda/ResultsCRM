<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCAgenteTecnico.ascx.vb" Inherits="ResultsCRM.WUCAgenteTecnico" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
<link href="../ResultsCRMAjax.css" rel="stylesheet" type="text/css" />

<script type="text/javascript" language="javascript" src="../ResultsCRM.js"></script>

<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

<div class="TituloCadastro">Detalhe do Cadastro - Agente Técnico</div>
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
            <asp:Label ID="LblCodAgenteTecnico" runat="server" Font-Bold="True"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            Nome:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtNome" runat="server" CssClass="CampoCadastro" Width="300px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            Usuário:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtCodUsuario" runat="server" CssClass="CampoCadastro" AutoPostBack="True"
                MaxLength="6" Width="90px"></asp:TextBox>
            <asp:ImageButton ID="BtnPesquisar" runat="server" ImageUrl="~/Imagens/search.png" 
                onclientclick="ShowEditModal('../Pesquisas/WFPUsuario.aspx?textBox=TxtCodUsuario','EditModalPopupUsuarios','IframeEdit');" 
                ToolTip="Pesquisar" />
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
        <td>
            Telefone:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtTelefone" runat="server" CssClass="CampoCadastro" 
                Width="90px"></asp:TextBox>
&nbsp;<asp:Label ID="LabelN1" runat="server" Height="17px"> Ramal:</asp:Label>
            <asp:TextBox ID="TxtRamal" runat="server" CssClass="CampoCadastro" Width="45px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td colspan="2" style="text-align: center">
            <asp:Button ID="BtnGravar" runat="server" CssClass="Botao" Text="Gravar" />
        &nbsp;
            <asp:Button ID="BtnVoltar" runat="server" CssClass="Botao" Text="Voltar" 
                Height="20px" />
        </td>
    </tr>
</table>

<%--este é o html para pesquisa de usuários--%>
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