<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCEtapaNegociacao.ascx.vb" Inherits="ResultsCRM.WUCEtapaNegociacao" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
<link href="../ResultsCRMAjax.css" rel="stylesheet" type="text/css" />

<script type="text/javascript" language="javascript" src="../ResultsCRM.js"></script>

<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

<div class="TituloCadastro">Detalhe da Etapa da Negociação</div>
<table style="width:100%;" class="TextoCadastro">
    <tr>
        <td class="Erro" colspan="2">
            <asp:Label ID="LblErro" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            Código:</td>
        <td class="CelulaCampoCadastro">
            <asp:Label ID="LblCodigo" runat="server" Font-Bold="True"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            Descrição:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtDescricao" runat="server" CssClass="CampoCadastro" 
                Width="300px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            Status:</td>
        <td class="CelulaCampoCadastro">
            <asp:RadioButtonList ID="RblStatus" runat="server" CssClass="CampoCadastro" 
                RepeatColumns="3">
                <asp:ListItem Value="1">Inicial</asp:ListItem>
                <asp:ListItem Value="2">Intermediário</asp:ListItem>
                <asp:ListItem Value="3">Final</asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td>
            Cor:</td>
        <td class="CelulaCampoCadastro">
            <asp:Button ID="BtnCor" runat="server" Text="Alterar cor" 
                onclientclick="ShowEditModal('../Pesquisas/WFPCores.aspx?controle=TxtCorBotao','EditModalPopupCores','IframeEdit');" />
        </td>
    </tr>
    <tr>
        <td>
            Percentual Fechamento:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtPercentualFechamento" runat="server" MaxLength="6" 
                Width="50px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            Permanência Máxima (dias):</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtTempoMaximo" runat="server" MaxLength="4" 
                Width="50px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            Não exigir data previsão:</td>
        <td class="CelulaCampoCadastro">
            <asp:CheckBox ID="CbxNaoExigirDataPrevisao" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            Exigir data de recontato:</td>
        <td class="CelulaCampoCadastro">
            <asp:CheckBox ID="CbxExigirDataRecontato" runat="server" />
        </td>
    </tr>
    <tr>
        <td colspan="2" align="center">
            <asp:Button ID="BtnGravar" runat="server" Text="Gravar" CssClass="Botao" />
        &nbsp;
            <asp:Button ID="BtnVoltar" runat="server" CssClass="Botao" Text="Voltar" />
        </td>
    </tr>
</table>
<p>
            <asp:TextBox ID="TxtCorBotao" runat="server" BorderStyle="None" 
        ForeColor="White" BackColor="White" BorderColor="White"></asp:TextBox>
        </p>

<%--este é o html para pesquisa de cores--%>
    <cc1:ModalPopupExtender ID="ModalPopupExtender2" BackgroundCssClass="ModalPopupBG"
        runat="server" CancelControlID="ButtonEditCancel" OkControlID="ButtonEditDone" 
        TargetControlID="BtnCor" PopupControlID="DivEditWindow" 
        OnCancelScript="EditCancelScript('IframeEdit');" OnOkScript="EditOkayScript('IframeEdit');"
        BehaviorID="EditModalPopupCores">
    </cc1:ModalPopupExtender>
<%--botões padrão que ficam ocultos, são necessários, não remover--%>
    <div class="popup_Buttons" style="display: none">
        <input id="ButtonEditDone" value="Done" type="button" />
        <input id="ButtonEditCancel" value="Cancel" type="button" />
    </div>
<%--frame onde é mostrado o popup--%>
    <div id="DivEditWindow" style="display: none;" class="popupConfirmation">
        <iframe id="IframeEdit" frameborder="0" width="247" height="212" scrolling="no">
        </iframe>
    </div>