<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCAtendimentoFollowUp.ascx.vb" Inherits="ResultsCRM.WUCAtendimentoFollowUp" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit"%>
<%@ Register src="../OutrosControles/TextBoxData.ascx" tagname="TextBoxData" tagprefix="uc1" %>
<%@ Register src="../OutrosControles/TextBoxHora.ascx" tagname="TextBoxHora" tagprefix="uc2" %>

<link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
<link href="../ResultsCRMAjax.css" rel="stylesheet" type="text/css" />

<script type="text/javascript" language="javascript" src="../ResultsCRM.js"></script>

<body>

<asp:ScriptManager ID="ScriptManager1" runat="server" 
        EnableScriptGlobalization="True"></asp:ScriptManager>

<table class="TextoCadastro_BGBranco" 
        style="width:100%; border-collapse: collapse;">
    <tr>
        <td class="Erro" colspan="2">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="Erro" colspan="2">
            <asp:Label ID="LblErro" runat="server" CssClass="Erro"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            <asp:Label ID="Label7" runat="server" Text="Seq.:"></asp:Label>
        </td>
        <td>
            <asp:Label ID="LblSeq" runat="server"></asp:Label>
            <asp:Label ID="LblCaminhoAnexo1" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="LblCaminhoAnexo2" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="LblCaminhoAnexo3" runat="server" Visible="False"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Usuário:</td>
        <td>
            <asp:Label ID="LblNomeUsuario" runat="server"></asp:Label>
            (<asp:Label ID="LblCodUsuario" runat="server"></asp:Label>
            )</td>
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
        <td>
            <asp:TextBox ID="TxtData" runat="server" CssClass="CampoCadastro" 
                MaxLength="10" Width="68px"></asp:TextBox>
                <cc1:CalendarExtender ID="TxtDataRecontatoI_CalendarExtender" runat="server" 
                        TargetControlID="TxtData" FirstDayOfWeek="Sunday"
                        Format="dd/MM/yyyy" TodaysDateFormat="d MMMM yyyy"></cc1:CalendarExtender>
            <ajaxToolkit:MaskedEditExtender ID="TxtData_MaskedEditExtender" 
                runat="server" BehaviorID="TxtDataChegadaPrevista_MaskedEditExtender" 
                Century="2000" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                CultureThousandsPlaceholder="" CultureTimePlaceholder="" Mask="99/99/9999" 
                MaskType="Date" TargetControlID="TxtData" 
                UserDateFormat="DayMonthYear" />
        &nbsp;<asp:Label ID="Label3" runat="server" Text="Hora:" Height="16px"></asp:Label>
            <asp:TextBox ID="TxtHora" runat="server" CssClass="CampoCadastro" 
                Width="40px"></asp:TextBox>
            <ajaxToolkit:MaskedEditExtender ID="TxtHora_MaskedEditExtender" 
                TargetControlID="TxtHora" AcceptAMPM="False" ErrorTooltipEnabled="True" 
                Mask="99:99" MaskType="Time" runat="server" />
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Tipo:</td>
        <td>
            <asp:DropDownList ID="DdlTipo" runat="server" CssClass="CampoCadastro" 
                Width="140px">
                <asp:ListItem Value="1">Comentário Interno</asp:ListItem>
                <asp:ListItem Value="2">Pergunta</asp:ListItem>
                <asp:ListItem Value="3">Resposta</asp:ListItem>
                <asp:ListItem Value="4">Comentário Cliente</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Envia e-mail:</td>
        <td>
            <asp:RadioButtonList ID="RblEmail" runat="server" CellPadding="0" 
                CellSpacing="1" CssClass="CampoCadastro" RepeatColumns="2" Width="85px">
                <asp:ListItem Value="S">Sim</asp:ListItem>
                <asp:ListItem Selected="True" Value="N">Não</asp:ListItem>
            </asp:RadioButtonList>
&nbsp;<asp:Label ID="LblDataEmail" runat="server"></asp:Label>
            <asp:Label ID="LblHoraEmail" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="vertical-align: top; text-align: right;">
            <asp:Label ID="Label6" runat="server" Text="Comentário:"></asp:Label>
            <br />
            <br />
            <asp:ImageButton ID="BtnPesquisarFollowUp" runat="server" 
                ImageUrl="~/Imagens/search.png" ToolTip="Pesquisar respostas" 
                
                onclientclick="ShowEditModal('../Pesquisas/WFPFollowUp.aspx','EditModalPopupClientes','IframeEdit');" />
            <cc1:ModalPopupExtender ID="ModalPopupExtender1" BackgroundCssClass="ModalPopupBG"
                runat="server" CancelControlID="ButtonEditCancel" OkControlID="ButtonEditDone" 
                TargetControlID="BtnPesquisarFollowUp" PopupControlID="DivEditWindow" 
                OnCancelScript="EditCancelScript('IframeEdit');" OnOkScript="EditOkayScript('IframeEdit');"
                BehaviorID="EditModalPopupClientes">
            </cc1:ModalPopupExtender>
        </td>
        <td>
            <asp:TextBox ID="TxtDescricao" runat="server" CssClass="CampoCadastro" 
                Height="100px" Width="350px" TextMode="MultiLine" Font-Size="8pt"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="vertical-align: top; text-align: right;">
            Anexar um arquivo:</td>
        <td>
            <asp:FileUpload ID="FUAnexo1" runat="server" CssClass="CampoCadastro" 
                Width="320px" />
            <asp:ImageButton ID="BtnExcluirAnexo1" runat="server" 
                ImageUrl="~/Imagens/BtnExcluir.png" style="height: 13px" 
                ToolTip="Excluir Anexo" Visible="False" Width="13px" />
            <asp:HyperLink ID="LblAnexo1" runat="server" Target="_blank">[LblAnexo1]</asp:HyperLink>
            <br />
            <asp:FileUpload ID="FUAnexo2" runat="server" CssClass="CampoCadastro" 
                Width="320px" />
            <asp:ImageButton ID="BtnExcluirAnexo2" runat="server" 
                ImageUrl="~/Imagens/BtnExcluir.png" ToolTip="Excluir Anexo" Visible="False" 
                Width="13px" />
            <asp:HyperLink ID="LblAnexo2" runat="server" Target="_blank">[LblAnexo2]</asp:HyperLink>
            <br />
            <asp:FileUpload ID="FUAnexo3" runat="server" CssClass="CampoCadastro" 
                Width="320px" />
            <asp:ImageButton ID="BtnExcluirAnexo3" runat="server" 
                ImageUrl="~/Imagens/BtnExcluir.png" ToolTip="Excluir Anexo" Visible="False" 
                Width="13px" />
            <asp:HyperLink ID="LblAnexo3" runat="server" Target="_blank">[LblAnexo3]</asp:HyperLink>
        </td>
    </tr>
    <tr>
        <td style="vertical-align: top; text-align: right;">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td style="vertical-align: top">
            &nbsp;</td>
        <td>
            <asp:Button ID="BtnGravar" runat="server" CssClass="Botao" Text="Salvar" />
        &nbsp;
            <asp:Button ID="BtnVoltar" runat="server" CssClass="Botao" Text="Voltar" />
        </td>
    </tr>
</table>
    <%--este é o html para pesquisa de itens--%><%--botões padrão que ficam ocultos, são necessários, não remover--%>
    <div class="popup_Buttons" style="display: none">
        <input id="ButtonEditDone" value="Done" type="button" />
        <input id="ButtonEditCancel" value="Cancel" type="button" />
    </div>
    <%--frame onde é mostrado o popup--%>
    <div id="DivEditWindow" style="display: none;" class="popupConfirmation">
        <iframe id="IframeEdit" frameborder="0" width="370" height="400" scrolling="no">
        </iframe>
    </div>
</body>

