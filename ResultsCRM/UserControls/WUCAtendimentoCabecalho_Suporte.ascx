<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCAtendimentoCabecalho_Suporte.ascx.vb" Inherits="ResultsCRM.WUCAtendimentoCabecalho_Suporte" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register src="../OutrosControles/TextBoxData.ascx" tagname="TextBoxData" tagprefix="uc1" %>
<%@ Register src="../OutrosControles/TextBoxHora.ascx" tagname="TextBoxHora" tagprefix="uc2" %>
<%@ Register src="../OutrosControles/TextBoxInteiro.ascx" tagname="TextBoxInteiro" tagprefix="uc3" %>

<link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
<link href="../ResultsCRMAjax.css" rel="stylesheet" type="text/css" />

<script type="text/javascript" language="javascript" src="../ResultsCRM.js"></script>

<body style="padding-right: 30px;">

<asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True"></asp:ScriptManager>
<table style="width: 100%" class="TextoCadastro">
    <tr>
        <td colspan="2" class="Erro" style="background-color: #F4F2D7">
            <asp:Label ID="LblErro" runat="server" ForeColor="Red"></asp:Label>
        </td>
    </tr>
    <tr>
        <td colspan="2" class="Erro" style="background-color: #F4F2D7">
            <asp:Label ID="LblInadimplente" runat="server" 
                Font-Bold="False" ForeColor="Red"></asp:Label>
            <asp:Label ID="LblCodAnalista" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="LblCodStatus" runat="server" Visible="False"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="vertical-align: middle; text-align: right;">
            <asp:Label ID="Label7" runat="server" Height="16px" Text="Nº Atendimento:"></asp:Label>
            </td>
        <td class="CelulaCampoCadastro" style="vertical-align: middle">
            <asp:Label ID="LblNrAtendimento" runat="server" Font-Bold="True" 
                Font-Size="8pt" Height="16px" Width="80px"></asp:Label>
            <asp:Label ID="Label12" runat="server" Height="16px" Text="OS Cliente:"></asp:Label>
            <asp:TextBox ID="TxtOSCliente" runat="server" CssClass="CampoCadastro" 
                Width="75px" Height="18px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="vertical-align: middle; text-align: right;">
            <asp:Label ID="Label6" runat="server" Height="16px" Text="Data/Hora:"></asp:Label>
            </td>
        <td class="CelulaCampoCadastro" style="vertical-align: middle">
            <asp:TextBox ID="TxtData" runat="server" CssClass="CampoCadastro" Width="80px"></asp:TextBox><cc1:CalendarExtender ID="CalendarExtender1" runat="server" 
                        TargetControlID="TxtData" FirstDayOfWeek="Sunday"
                        Format="dd/MM/yyyy" TodaysDateFormat="d MMMM yyyy"></cc1:CalendarExtender>
            <cc1:MaskedEditExtender ID="TxtData_MaskedEditExtender" runat="server" 
                BehaviorID="TxtData_MaskedEditExtender" Century="2000" 
                CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                CultureThousandsPlaceholder="" CultureTimePlaceholder="" Mask="99/99/9999" 
                MaskType="Date" TargetControlID="TxtData" UserDateFormat="DayMonthYear" />
            <asp:TextBox ID="TxtHora" runat="server" CssClass="CampoCadastro" 
                style="margin-bottom: 0px" Width="40px"></asp:TextBox>
            <cc1:MaskedEditExtender ID="TxtHora_MaskedEditExtender" TargetControlID="TxtHora" AcceptAMPM="False" ErrorTooltipEnabled="True" Mask="99:99" MaskType="Time" runat="server" />
        </td>
    </tr>
    <tr>
        <td style="vertical-align: middle; text-align: right;">
            <asp:Label ID="Label11" runat="server" Height="16px" Text="Encerramento:"></asp:Label>
            </td>
        <td class="CelulaCampoCadastro" style="vertical-align: middle">
            <asp:Label ID="LblDataEncerramento" runat="server" Font-Bold="False" 
                Font-Italic="False" Height="16px"></asp:Label>
            <asp:Label ID="LblHoraEncerramento" runat="server" Height="16px"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Previsão:</td>
        <td class="CelulaCampoCadastro" style="vertical-align: middle">
            <asp:TextBox ID="TxtDataPrevisaoInicio" runat="server" CssClass="CampoCadastro" 
                Width="80px"></asp:TextBox><cc1:CalendarExtender ID="CalendarExtender2" runat="server" 
                        TargetControlID="TxtDataPrevisaoInicio" FirstDayOfWeek="Sunday"
                        Format="dd/MM/yyyy" TodaysDateFormat="d MMMM yyyy"></cc1:CalendarExtender>
            <cc1:MaskedEditExtender ID="TxtDataPrevisaoInicio_MaskedEditExtender" 
                runat="server" BehaviorID="TxtDataPrevisaoInicio_MaskedEditExtender" 
                Century="2000" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                CultureThousandsPlaceholder="" CultureTimePlaceholder="" Mask="99/99/9999" 
                MaskType="Date" TargetControlID="TxtDataPrevisaoInicio" 
                UserDateFormat="DayMonthYear" />
            <asp:TextBox ID="TxtHoraPrevisaoInicio" runat="server" CssClass="CampoCadastro" 
                Width="40px"></asp:TextBox>
            <cc1:MaskedEditExtender ID="TxtHoraPrevisaoInicio_MaskedEditExtender" TargetControlID="TxtHoraPrevisaoInicio" AcceptAMPM="False" ErrorTooltipEnabled="True" Mask="99:99" MaskType="Time" runat="server" />
            <asp:Label ID="Label8" runat="server" Height="16px" Text="&nbsp;a:&nbsp;"></asp:Label>
            <asp:TextBox ID="TxtDataPrevisaoFim" runat="server" CssClass="CampoCadastro" 
                Width="80px"></asp:TextBox><cc1:CalendarExtender ID="CalendarExtender3" runat="server" 
                        TargetControlID="TxtDataPrevisaoFim" FirstDayOfWeek="Sunday"
                        Format="dd/MM/yyyy" TodaysDateFormat="d MMMM yyyy"></cc1:CalendarExtender>
            <cc1:MaskedEditExtender ID="TxtDataPrevisaoFim_MaskedEditExtender" 
                runat="server" BehaviorID="TxtDataPrevisaoFim_MaskedEditExtender" 
                Century="2000" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                CultureThousandsPlaceholder="" CultureTimePlaceholder="" Mask="99/99/9999" 
                MaskType="Date" TargetControlID="TxtDataPrevisaoFim" 
                UserDateFormat="DayMonthYear" />
            <asp:TextBox ID="TxtHoraPrevisaoFim" runat="server" CssClass="CampoCadastro" 
                Width="40px"></asp:TextBox>
            <cc1:MaskedEditExtender ID="TxtHoraPrevisaoFim_MaskedEditExtender" TargetControlID="TxtHoraPrevisaoFim" AcceptAMPM="False" ErrorTooltipEnabled="True" Mask="99:99" MaskType="Time" runat="server" />
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Tipo:</td>
        <td class="CelulaCampoCadastro" style="vertical-align: middle">
            <asp:DropDownList ID="DdlTipo" runat="server" CssClass="CampoCadastro" 
                Width="150px">
            </asp:DropDownList>
        &nbsp;
            <asp:Label ID="Label13" runat="server" Text="Status:" Height="16px"></asp:Label>
            <asp:DropDownList ID="DdlStatus" runat="server" CssClass="CampoCadastro" 
                Width="155px">
            </asp:DropDownList>
            </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Assunto:</td>
        <td class="CelulaCampoCadastro" style="vertical-align: middle">
            <asp:TextBox ID="TxtAssunto" runat="server" CssClass="CampoCadastro" 
                MaxLength="60" Width="350px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Analista:</td>
        <td class="CelulaCampoCadastro" style="vertical-align: middle">
            <asp:DropDownList ID="DdlAnalista" runat="server" CssClass="CampoCadastro" 
                Width="213px">
            </asp:DropDownList>
        &nbsp;
            <asp:Label ID="Label10" runat="server" Text="Inclusão:" Height="16px" 
                Font-Size="6pt"></asp:Label>
            <asp:Label ID="LblUsuario" runat="server" Height="16px" Font-Size="6pt"></asp:Label>
            <asp:Label ID="LblCodUsuario" runat="server" Height="16px" Visible="False" 
                Width="80px" Font-Size="6pt"></asp:Label>
            </td>
    </tr>
    <tr>
        <td 
            
            
            style="border-width: 1px; border-color: #C0C0C0; border-right-style: solid; text-align: right;">
            <asp:Label ID="Label5" runat="server" Height="17px" Text="Cliente:"></asp:Label>
            </td>
        <td class="CelulaCampoCadastro" 
            
            
            style="border-width: 1px; border-color: #C0C0C0; vertical-align: middle; border-top-style: solid; border-right-style: solid;">
            <asp:TextBox ID="TxtCliente" runat="server" CssClass="CampoCadastro" 
                Width="50px" MaxLength="6" AutoPostBack="True" Height="18px"></asp:TextBox>
            &nbsp;<asp:ImageButton ID="BtnFiltrarCliente" runat="server" 
                ImageUrl="~/Imagens/search.png" ToolTip="Pesquisar" 
                onclientclick="ShowEditModal('../Pesquisas/WFPCliente.aspx?textbox=TxtCliente&amp;varmp=SCodClientePesquisado&amp;varma=SAlterouCodCliente','EditModalPopupClientes','IframeEdit');" 
                Height="15px" Width="16px" />
            <span class="TextoCadastro">
                &nbsp;<asp:ImageButton ID="BtnIncluirCliente" runat="server" ImageUrl="~/Imagens/BtnIncluir.png" 
                    AlternateText="Novo Cliente" Height="16px" ToolTip="Novo cliente" 
                    
                
                
                onclientclick="ShowEditModal('../Forms/WFClienteEmbeeded.aspx?a=I&amp;vcodemi=SCodEmitenteNegociacao&amp;vcodemp=SCodClientePesquisado&amp;valtecc=SAlterouCodCliente&amp;vrecdc=SRecarregaDdlContatos&amp;ccodcon=SCodContatoNegociacao&amp;cnpjemi=SCNPJEmitente&amp;vcodemin=SCodEmitenteNegociacao','EditModalPopupIncluirCliente','IframeEdit');" />
                &nbsp;<asp:ImageButton ID="BtnAlterarCliente" runat="server" ImageUrl="~/Imagens/BtnEditar.png" 
                    AlternateText="Alterar cliente" Height="16px" ToolTip="Alterar informações do cliente" 
                    
                
                
                onclientclick="ShowEditModal('../Forms/WFClienteEmbeeded.aspx?a=A&amp;vcodemi=SCodEmitenteNegociacao&amp;vcodemp=SCodClientePesquisado&amp;valtecc=SAlterouCodCliente&amp;vrecdc=SRecarregaDdlContatos&amp;ccodcon=SCodContatoNegociacao&amp;cnpjemi=SCNPJEmitente&amp;vcodemin=SCodEmitenteNegociacao','EditModalPopupAlterarCliente','IframeEdit');" />
                &nbsp;
            </span>
            <asp:Label ID="Label3" runat="server" Height="17px" Text="CNPJ:"></asp:Label>
            <asp:DropDownList ID="DdlCNPJ" runat="server" CssClass="CampoCadastro" 
                Width="150px" AutoPostBack="True"/>
        </td>
    </tr>
    <tr>
        <td 
            
            
            style="border-width: 1px; border-color: #C0C0C0; border-right-style: solid; text-align: right;">
            Nome:</td>
        <td class="CelulaCampoCadastro" 
            
            
            style="border-width: 1px; border-color: #C0C0C0; vertical-align: middle; border-right-style: solid;">
            <asp:Label ID="LblNomeCliente" runat="server" Font-Bold="True" Width="220px"></asp:Label>
            · Telefone:<asp:Label ID="LblTelefone" runat="server" Font-Bold="True" 
                Width="145px"></asp:Label>
        </td>
    </tr>
    <tr>
        <td 
            
            style="border-width: 1px; border-color: #C0C0C0; border-right-style: solid; text-align: right">
            <span class="TextoCadastro">Contato:</span></td>
        <td class="CelulaCampoCadastro" 
            
            
            
            style="border-width: 1px; border-color: #C0C0C0; border-bottom-style: solid; border-right-style: solid;">
            <asp:DropDownList ID="DdlContato" runat="server" CssClass="CampoCadastro" 
                Width="225px" AutoPostBack="True">
            </asp:DropDownList>
            <span class="TextoCadastro">
            &nbsp;<asp:ImageButton ID="BtnIncluirContato" runat="server" 
                AlternateText="Novo Contato" Height="16px" ToolTip="Novo contato" 
                ImageUrl="~/Imagens/BtnIncluir.png" 
                
                
                
                onclientclick="ShowEditModal('../Forms/WFContato.aspx?a=I&amp;vrecc=SRecarregaDdlContatos&amp;vcodc=SCodContatoNegociacao&amp;vcode=SCodEmitenteNegociacao&amp;ptat=','EditModalPopupIncluirContato','IframeEdit');" />
     <cc1:ModalPopupExtender ID="ModalPopupExtender3" BackgroundCssClass="ModalPopupBG"
        runat="server" CancelControlID="ButtonEditCancel" OkControlID="ButtonEditDone" 
        TargetControlID="BtnIncluirContato" PopupControlID="DivEditWindow" 
        OnCancelScript="EditCancelScript('IframeEdit');" OnOkScript="EditOkayScript('IframeEdit');"
        BehaviorID="EditModalPopupIncluirContato">
    </cc1:ModalPopupExtender>
            &nbsp;<asp:ImageButton ID="BtnAlterarContato" runat="server" 
                AlternateText="Alterar contato" Height="16px" 
                ToolTip="Alterar informações do contato" 
                ImageUrl="~/Imagens/BtnEditar.png" 
                
                
                
                onclientclick="ShowEditModal('../Forms/WFContato.aspx?a=A&amp;vrecc=SRecarregaDdlContatos&amp;vcodc=SCodContatoNegociacao&amp;vcode=SCodEmitenteNegociacao&amp;ptat=','EditModalPopupAlterarContato','IframeEdit');" />
     <cc1:ModalPopupExtender ID="ModalPopupExtender4" BackgroundCssClass="ModalPopupBG"
        runat="server" CancelControlID="ButtonEditCancel" OkControlID="ButtonEditDone" 
        TargetControlID="BtnAlterarContato" PopupControlID="DivEditWindow" 
        OnCancelScript="EditCancelScript('IframeEdit');" OnOkScript="EditOkayScript('IframeEdit');"
        BehaviorID="EditModalPopupAlterarContato">
    </cc1:ModalPopupExtender>
            &nbsp;
            </span>
            <asp:Label ID="LblEmail" runat="server" Height="16px"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Contrato:</td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="DdlContrato" runat="server" CssClass="CampoCadastro" 
                Width="225px" AutoPostBack="True">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Observação:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtObservacao" runat="server" CssClass="CampoCadastro" 
                Width="350px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            <asp:Label ID="LblFollowUPLbl" runat="server" Height="16px" 
                Text="Descreva o problema:"></asp:Label>
            </td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtFollowUP" runat="server" CssClass="CampoCadastro" 
                Width="350px" Height="44px" TextMode="MultiLine" Visible="False" 
                Font-Size="8pt"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td class="CelulaCampoCadastro">
            <asp:Button ID="BtnGravar" runat="server" Text="Gravar" CssClass="Botao" />
            </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
        </td>
    </tr>
    </table>
   <div id="DivConfirmacao" runat="server" 
                
    
    style="position: absolute; top: 20%; left: 14%; width: 360px; text-align: center; z-index: 999; visibility: hidden; padding-top: 40px; padding-bottom: 40px; padding-left: 10px; padding-right: 10px">
            <asp:Label ID="LblMensagemConfirmacao" runat="server"></asp:Label>
            <asp:Button ID="BtnSim" runat="server" BackColor="#339933" Font-Bold="True" 
                ForeColor="White" Text="Sim" Visible="False" Width="45px" />
            &nbsp;
            <asp:Button ID="BtnNao" runat="server" BackColor="#FF3300" Font-Bold="True" 
                ForeColor="White" Text="Não" Visible="False" Width="45px" />
    </div>
    <%--este é o html para pesquisa de emitentes--%>
    <cc1:ModalPopupExtender ID="ModalPopupExtender2" BackgroundCssClass="ModalPopupBG"
        runat="server" CancelControlID="ButtonEditCancel" OkControlID="ButtonEditDone" 
        TargetControlID="BtnFiltrarCliente" PopupControlID="DivEditWindow" 
        OnCancelScript="EditCancelScript('IframeEdit');" OnOkScript="EditOkayScript('IframeEdit');"
        BehaviorID="EditModalPopupClientes">
    </cc1:ModalPopupExtender>
    <%--este é o html para incluir emitente via chamado--%>
    <cc1:ModalPopupExtender ID="ModalPopupExtender1" BackgroundCssClass="ModalPopupBG"
        runat="server" CancelControlID="ButtonEditCancel" OkControlID="ButtonEditDone" 
        TargetControlID="BtnIncluirCliente" PopupControlID="DivEditWindow" 
        OnCancelScript="EditCancelScript('IframeEdit');" OnOkScript="EditOkayScript('IframeEdit');"
        BehaviorID="EditModalPopupIncluirCliente">
    </cc1:ModalPopupExtender>
    <%--este é o html para alterar cadastro de emitente via chamado--%>
    <cc1:ModalPopupExtender ID="ModalPopupExtender5" BackgroundCssClass="ModalPopupBG"
        runat="server" CancelControlID="ButtonEditCancel" OkControlID="ButtonEditDone" 
        TargetControlID="BtnAlterarCliente" PopupControlID="DivEditWindow" 
        OnCancelScript="EditCancelScript('IframeEdit');" OnOkScript="EditOkayScript('IframeEdit');"
        BehaviorID="EditModalPopupAlterarCliente">
    </cc1:ModalPopupExtender>
<%--este é o html para funcionar o botão de incluir contatos--%><%--este é o html para funcionar o botão de incluir contatos--%><%--botões padrão que ficam ocultos, são necessários, não remover--%>
    <div class="popup_Buttons" style="display: none">
        <input id="ButtonEditDone" value="Done" type="button" />
        <input id="ButtonEditCancel" value="Cancel" type="button" />
    </div>
    <%--frame onde é mostrado o popup--%>
    <div id="DivEditWindow" style="display: none;" class="popupConfirmation">
        <iframe id="IframeEdit" frameborder="0" width="370" height="410" scrolling="no">
        </iframe>
    </div>
</body>
