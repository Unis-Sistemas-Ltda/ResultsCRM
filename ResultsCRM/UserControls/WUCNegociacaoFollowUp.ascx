<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCNegociacaoFollowUp.ascx.vb" Inherits="ResultsCRM.WUCNegociacaoFollowUp" %>
<%@ Register src="../OutrosControles/TextBoxData.ascx" tagname="TextBoxData" tagprefix="uc1" %>
<%@ Register src="../OutrosControles/TextBoxHora.ascx" tagname="TextBoxHora" tagprefix="uc2" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
<link href="../ResultsCRMAjax.css" rel="stylesheet" type="text/css" />
<div class="SubTituloMovimento">Ação<br />
    <br />
</div>
<table class="TextoCadastro_BGBranco" 
    style="width:100%; border-collapse: collapse;">
    <tr>
        <td class="Erro" colspan="2">
            <asp:ScriptManager ID="ScriptManager1" runat="server" 
                EnableScriptGlobalization="True"></asp:ScriptManager>
        </td>
    </tr>
    <tr>
        <td class="Erro" colspan="2">
            <asp:Label ID="LblErro" runat="server" CssClass="Erro"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right; width: 130px;">
            <asp:Label ID="Label7" runat="server" Text="Seq.:"></asp:Label>
        </td>
        <td class="CelulaCampoCadastro">
            <asp:Label ID="LblSeq" runat="server" Width="70px"></asp:Label>
            <asp:Label ID="Label8" runat="server" Text="Enviar e-mail:"></asp:Label>
            <asp:CheckBox ID="CbxEnviaEmail" runat="server" />
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            <asp:Label ID="Label1" runat="server" Text="Ação:"></asp:Label>
        </td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="DdlAcao" runat="server" CssClass="CampoCadastro" 
                Width="350px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            <asp:Label ID="Label2" runat="server" Text="Data:"></asp:Label>
        </td>
        <td class="CelulaCampoCadastro">
            <uc1:TextBoxData ID="TxtData" runat="server" />
            <asp:Label ID="Label3" runat="server" Text="Hora:" Height="17px"></asp:Label>
            <uc2:TextBoxHora ID="TxtHora" runat="server" />
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            <asp:Label ID="Label4" runat="server" Text="Pessoa Contatada:"></asp:Label>
        </td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="DdlContato" runat="server" CssClass="CampoCadastro" 
                Width="320px" AutoPostBack="True">
            </asp:DropDownList>
            <span class="TextoCadastro">
            &nbsp;<asp:ImageButton ID="BtnIncluirContato" runat="server" 
                AlternateText="Novo Contato" Height="16px" ToolTip="Novo contato" 
                ImageUrl="~/Imagens/BtnIncluir.png" 
                
                
                
                onclientclick="ShowEditModal('../Forms/WFContato.aspx?a=I&amp;vrecc=SRecarregaDdlContatos&amp;vcodc=SCodContatoNegociacao&amp;vcode=SCodEmitenteNegociacao&amp;ptat=','EditModalPopupIncluirContato','IframeEdit');" />
     <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender3" BackgroundCssClass="ModalPopupBG"
        runat="server" CancelControlID="ButtonEditCancel" OkControlID="ButtonEditDone" 
        TargetControlID="BtnIncluirContato" PopupControlID="DivEditWindow" 
        OnCancelScript="EditCancelScript('IframeEdit');" OnOkScript="EditOkayScript('IframeEdit');"
        BehaviorID="EditModalPopupIncluirContato">
    </ajaxToolkit:ModalPopupExtender>
            &nbsp; <asp:ImageButton ID="BtnAlterarContato" runat="server" 
                AlternateText="Alterar contato" Height="16px" 
                ToolTip="Alterar informações do contato" 
                ImageUrl="~/Imagens/BtnEditar.png" 
                
                
                
                onclientclick="ShowEditModal('../Forms/WFContato.aspx?a=A&amp;vrecc=SRecarregaDdlContatos&amp;vcodc=SCodContatoNegociacao&amp;vcode=SCodEmitenteNegociacao&amp;ptat=','EditModalPopupIncluirContato','IframeEdit');" />
     <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender4" BackgroundCssClass="ModalPopupBG"
        runat="server" CancelControlID="ButtonEditCancel" OkControlID="ButtonEditDone" 
        TargetControlID="BtnAlterarContato" PopupControlID="DivEditWindow" 
        OnCancelScript="EditCancelScript('IframeEdit');" OnOkScript="EditOkayScript('IframeEdit');"
        BehaviorID="EditModalPopupAlterarContato">
    </ajaxToolkit:ModalPopupExtender>
            </span>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            E-mail:</td>
        <td class="CelulaCampoCadastro">
            <asp:Label ID="LblEmail" runat="server" Font-Bold="True"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            <asp:Label ID="Label5" runat="server" Text="Assunto:"></asp:Label>
        </td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtAssunto" runat="server" CssClass="CampoCadastro" 
                Width="350px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="vertical-align: top; text-align: right;">
            <asp:Label ID="Label6" runat="server" Text="Comentário:"></asp:Label>
        </td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtDescricao" runat="server" CssClass="CampoCadastro" 
                Height="85px" Width="350px" TextMode="MultiLine"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="vertical-align: top; text-align: right;">
            Data Recontato:</td>
        <td class="CelulaCampoCadastro">
            <uc1:TextBoxData ID="TxtDataRecontato" runat="server" Width="90" />
            <uc2:TextBoxHora ID="TxtHoraRecontato" runat="server" Width="58"/>
        </td>
    </tr>
    <tr>
        <td style="vertical-align: top">
            &nbsp;</td>
        <td class="CelulaCampoCadastro">
            <asp:Button ID="Button1" runat="server" CssClass="Botao" Text="Gravar" />
        &nbsp;<asp:Button ID="Button2" runat="server" CssClass="Botao" Text="Voltar" />
        </td>
    </tr>
</table>
<%--botões padrão que ficam ocultos, são necessários, não remover--%>
    <div class="popup_Buttons" style="display: none">
        <input id="ButtonEditDone" value="Done" type="button" />
        <input id="ButtonEditCancel" value="Cancel" type="button" />
    </div>
<%--frame onde é mostrado o popup--%>
    <div id="DivEditWindow" style="display: none;" class="popupConfirmation">
        <iframe id="IframeEdit" frameborder="0" width="370" height="370" scrolling="no">
        </iframe>
    </div>