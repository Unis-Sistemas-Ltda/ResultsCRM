<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCEmitenteAssessoriaEtapa.ascx.vb" Inherits="ResultsCRM.WUCEmitenteAssessoriaEtapa" %>
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
            Seq. Etapa:</td>
        <td class="CelulaCampoCadastro">
            <asp:Label ID="LblSeqEtapa" runat="server"></asp:Label>
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
            Data Início:
        </td>
        <td class="CelulaCampoCadastro">
            <uc1:TextBoxData ID="TxtDataInicio" runat="server" Width="90" />
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Data Fim:
        </td>
        <td class="CelulaCampoCadastro">
            <uc1:TextBoxData ID="TxtDataFim" runat="server" Width="90" />
        </td>
    </tr>
    <tr>
        <td style="text-align: right; vertical-align: top; padding-top: 4px;">
            Observação:
        </td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtObservacao" runat="server" CssClass="CampoCadastro" 
                Height="90px" TextMode="MultiLine" Width="300px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td colspan="2" style="text-align: center">
            <br />
            <asp:Button ID="BtnGravar" runat="server" CssClass="Botao" Text="Gravar" />
        &nbsp;
            <asp:Button ID="Button1" runat="server" Text="Voltar" />
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
