<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCAtendimentoCabecalho.ascx.vb" Inherits="ResultsCRM.WUCAtendimentoCabecalho" %>
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
        <td colspan="4" class="Erro" style="background-color: #F4F2D7">
            <asp:Label ID="LblErro" runat="server" ForeColor="Red"></asp:Label>
            <asp:Label ID="LblInadimplente" runat="server" 
                Font-Bold="False" ForeColor="Red" Visible="False"></asp:Label>
        </td>
    </tr>
    <tr>
        <td colspan="4" 
            style="background-color: #F4F2D7; color: #FF0000; text-align: center;">
            <asp:Label ID="LblMensagem" runat="server" Font-Bold="False" Font-Size="9pt"></asp:Label>
            <asp:Label ID="LblCodAnalista" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="LblCodStatus" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="LblDesobrigadoSLA" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="LblQtdChamadoDia" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="LblQtdChamadoDiaSLA" runat="server" Visible="False"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="vertical-align: middle; text-align: right;" colspan="2">
            <asp:Label ID="Label7" runat="server" Height="16px" Text="Nº Atendimento:"></asp:Label>
            </td>
        <td class="CelulaCampoCadastro" style="vertical-align: middle" colspan="2">
            <asp:Label ID="LblNrAtendimento" runat="server" Font-Bold="True" Height="16px" 
                Width="45px">0</asp:Label>
&nbsp; <asp:Label ID="Label12" runat="server" Height="16px" 
                Text="Chamado Cliente:"></asp:Label>
            <asp:TextBox ID="TxtOSCliente" runat="server" CssClass="CampoCadastro" 
                Width="75px" Height="18px"></asp:TextBox>
        &nbsp; 
            <asp:Label ID="Label17" runat="server" Height="16px" 
                Text="SAG:"></asp:Label>
            <asp:TextBox ID="TxtSAG" runat="server" CssClass="CampoCadastro" 
                Width="85px" Height="18px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="vertical-align: middle; text-align: right;" colspan="2">
            <asp:Label ID="Label6" runat="server" Height="16px" Text="Abertura:"></asp:Label>
            </td>
        <td class="CelulaCampoCadastro" style="vertical-align: middle" colspan="2">
            <asp:TextBox ID="TxtData" runat="server" CssClass="CampoCadastro" Width="80px"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" 
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
        &nbsp;
            <asp:Label ID="LblChamadoAuxLbl" runat="server" Height="16px" 
                Text="Chamado Original:" Visible="False"></asp:Label>
            <asp:Label ID="LblNrAtendimentoAuxiliar" runat="server" Font-Bold="True" Height="16px" 
                Width="45px" Visible="False">0</asp:Label>
        </td>
    </tr>
    <tr>
        <td colspan="2" style="text-align: right">
            Previsão Chegada:</td>
        <td class="CelulaCampoCadastro" style="vertical-align: middle" colspan="2">
            <asp:Label ID="LblDataChegadaPrevista" runat="server" Font-Bold="False" 
                Font-Italic="False" Width="70px"></asp:Label>
            <asp:Label ID="LblHoraChegadaPrevista" runat="server" 
                Width="40px"></asp:Label>
        &nbsp;
            <asp:Label ID="Label1" runat="server" Text="Chegada:" Width="70px" 
                style="text-align:right"></asp:Label>
            <asp:Label ID="LblDataChegada" runat="server" Font-Bold="False" 
                Font-Italic="False" Width="70px"></asp:Label>
            <asp:Label ID="LblHoraChegada" runat="server" Width="40px"></asp:Label>
        </td>
    </tr>
    <tr>
        <td colspan="2" style="text-align: right">
            Previsão Encerramento:</td>
        <td class="CelulaCampoCadastro" style="vertical-align: middle" colspan="2">
            <asp:Label ID="LblDataEncerramentoPrevisto" runat="server" Font-Bold="False" 
                Font-Italic="False" Width="70px"></asp:Label>
            <asp:Label ID="LblHoraEncerramentoPrevisto" runat="server" Width="40px"></asp:Label>
        &nbsp;
            <asp:Label ID="Label11" runat="server" Text="Encerramento:" Width="70px" 
                style="text-align:right"></asp:Label>
            <asp:Label ID="LblDataEncerramento" runat="server" Font-Bold="False" 
                Font-Italic="False" Width="70px"></asp:Label>
            <asp:Label ID="LblHoraEncerramento" runat="server" Width="40px"></asp:Label>
        </td>
    </tr>
    <tr>
        <td colspan="2" style="text-align: right">
            Tipo:</td>
        <td class="CelulaCampoCadastro" style="vertical-align: middle" colspan="2">
            <asp:DropDownList ID="DdlTipo" runat="server" CssClass="CampoCadastro" 
                Width="145px">
            </asp:DropDownList>
        &nbsp;&nbsp;
            <asp:Label ID="Label16" runat="server" Height="17px" Text="Analista:"></asp:Label>
            <asp:DropDownList ID="DdlAnalista" runat="server" CssClass="CampoCadastro" 
                Width="203px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td colspan="2" style="text-align: right">
            <asp:Label ID="Label13" runat="server" Text="Status:" Height="16px"></asp:Label>
            </td>
        <td class="CelulaCampoCadastro" style="vertical-align: middle" colspan="2">
            <asp:DropDownList ID="DdlStatus" runat="server" CssClass="CampoCadastro" 
                Width="180px" AutoPostBack="True">
            </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label15" runat="server" Text="Motivo:" Height="16px"></asp:Label>
            <asp:TextBox ID="TxtMotivo" runat="server" CssClass="CampoCadastro" 
                Width="165px" MaxLength="100"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td colspan="2" style="text-align: right">
            <asp:Label ID="Label18" runat="server" Height="17px" 
                Text="Início Trabalho Técnico:"></asp:Label>
            </td>
        <td class="CelulaCampoCadastro" style="vertical-align: middle" colspan="2">
            <asp:TextBox ID="TxtDataInicioTrabalhoTecnico" runat="server" 
                CssClass="CampoCadastro" Width="80px" Enabled="False" Height="19px"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" 
                        TargetControlID="TxtData" FirstDayOfWeek="Sunday"
                        Format="dd/MM/yyyy" TodaysDateFormat="d MMMM yyyy"></cc1:CalendarExtender>
            <cc1:MaskedEditExtender ID="TxtDataInicioTrabalhoTecnico_MaskedEditExtender" runat="server" 
                BehaviorID="TxtDataInicioTrabalhoTecnico_MaskedEditExtender" Century="2000" 
                CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                CultureThousandsPlaceholder="" CultureTimePlaceholder="" Mask="99/99/9999" 
                MaskType="Date" TargetControlID="TxtDataInicioTrabalhoTecnico" 
                UserDateFormat="DayMonthYear" />
            <asp:TextBox ID="TxtHoraInicioTrabalhoTecnico" runat="server" CssClass="CampoCadastro" 
                style="margin-bottom: 0px" Width="40px" Enabled="False"></asp:TextBox>
            <cc1:MaskedEditExtender ID="TxtHoraInicioTrabalhoTecnico_MaskedEditExtender" 
                TargetControlID="TxtHoraInicioTrabalhoTecnico" AcceptAMPM="False" 
                ErrorTooltipEnabled="True" Mask="99:99" MaskType="Time" runat="server" />
        </td>
    </tr>
    <tr>
        <td colspan="2" style="text-align: right">
            Assunto:</td>
        <td class="CelulaCampoCadastro" style="vertical-align: middle" colspan="2">
            <asp:TextBox ID="TxtAssunto" runat="server" CssClass="CampoCadastro" 
                MaxLength="60" Width="400px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td rowspan="3" 
            
            style="border-width: 1px; border-color: #C0C0C0; border-right-style: solid; text-align: right;">
            Tomador</td>
        <td style="border-top-style: solid; border-width: 1px; border-color: #C0C0C0; text-align: right;">
            <asp:Label ID="Label5" runat="server" Height="17px" Text="Cliente:"></asp:Label>
            </td>
        <td class="CelulaCampoCadastro" 
            
            style="border-width: 1px; border-color: #C0C0C0; vertical-align: middle; border-top-style: solid; border-right-style: solid;" 
            colspan="2">
            <asp:TextBox ID="TxtCliente" runat="server" CssClass="CampoCadastro" 
                Width="50px" MaxLength="6" AutoPostBack="True" Height="18px"></asp:TextBox>
            &nbsp;<asp:ImageButton ID="BtnFiltrarCliente" runat="server" 
                ImageUrl="~/Imagens/search.png" ToolTip="Pesquisar" 
                onclientclick="ShowEditModal('../Pesquisas/WFPClienteCNPJ.aspx?textbox=TxtCliente&amp;varmp=SCodClientePesquisado&amp;varmpc=SCNPJClientePesquisado&amp;varma=SAlterouCodCliente','EditModalPopupClientes','IframeEdit');" 
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
                Width="255px" AutoPostBack="True"/>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Nome:</td>
        <td class="CelulaCampoCadastro" 
            
            style="border-width: 1px; border-color: #C0C0C0; vertical-align: middle; border-right-style: solid;" 
            colspan="2">
            <asp:Label ID="LblNomeCliente" runat="server" Font-Bold="True" Width="220px"></asp:Label>
            · Telefone:<asp:Label ID="LblTelefone" runat="server" Font-Bold="True" 
                Width="145px"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="border-width: 1px; border-color: #C0C0C0; border-bottom-style: solid; text-align: right">
            <span class="TextoCadastro">Contato:</span></td>
        <td class="CelulaCampoCadastro" 
            
            
            style="border-width: 1px; border-color: #C0C0C0; border-bottom-style: solid; border-right-style: solid;" 
            colspan="2">
            <asp:DropDownList ID="DdlContato" runat="server" CssClass="CampoCadastro" 
                Width="180px" AutoPostBack="True">
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
            &nbsp;&nbsp;&nbsp;
            </span>
            <label id="LblSLA" style="height:17px">SLA:</label>
            <asp:DropDownList ID="DdlSLA" runat="server" CssClass="CampoCadastro" 
                Width="150px" AutoPostBack="True">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td rowspan="6" 
            
            
            style="border-width: 1px; border-color: #C0C0C0; border-right-style: solid; text-align: right;">
            P.A.:</td>
        <td style="border-width: 1px; border-color: #C0C0C0; text-align: right;">
            Cliente:</td>
        <td class="CelulaCampoCadastro" 
            
            
            style="border-width: 1px; border-color: #C0C0C0; border-right-style: solid;" 
            colspan="2">
            <asp:TextBox ID="TxtClienteAtendimento" runat="server" CssClass="CampoCadastro" 
                Width="50px" MaxLength="6" AutoPostBack="True" Height="18px"></asp:TextBox>
            &nbsp;<asp:ImageButton ID="BtnFiltrarClienteAtendimento" runat="server" 
                ImageUrl="~/Imagens/search.png" ToolTip="Pesquisar" 
                onclientclick="ShowEditModal('../Pesquisas/WFPCliente.aspx?textbox=TxtCliente&amp;varmp=SCodClienteAtPesquisado&amp;varma=SAlterouCodClienteAt','EditModalPopupClienteAtendimento','IframeEdit');" 
                Height="15px" Width="16px" />
    <cc1:ModalPopupExtender ID="BtnFiltrarClienteAtendimento_ModalPopupExtender" BackgroundCssClass="ModalPopupBG"
        runat="server" CancelControlID="ButtonEditCancel" OkControlID="ButtonEditDone" 
        TargetControlID="BtnFiltrarClienteAtendimento" PopupControlID="DivEditWindow" 
        OnCancelScript="EditCancelScript('IframeEdit');" OnOkScript="EditOkayScript('IframeEdit');"
        BehaviorID="EditModalPopupClienteAtendimento">
    </cc1:ModalPopupExtender>
            <span class="TextoCadastro">
                &nbsp;<asp:ImageButton ID="BtnIncluirClienteAtendimento" runat="server" ImageUrl="~/Imagens/BtnIncluir.png" 
                    AlternateText="Novo Cliente" Height="16px" ToolTip="Novo cliente" 
                    
                
                
                
                
                onclientclick="ShowEditModal('../Forms/WFClienteEmbeeded.aspx?a=I1&amp;vcodemi=SCodEmitenteAtNegociacao&amp;vcodemp=SCodClienteAtPesquisado&amp;valtecc=SAlterouCodClienteAt&amp;vrecdc=SRecarregaDdlContatosAt&amp;ccodcon=SCodContatoNegociacaoAt&amp;cnpjemi=SCNPJEmitenteAtendimento&amp;vcodemin=SCodEmitenteAtNegociacao','EditModalPopupIncluirCliente','IframeEdit');" />
    <cc1:ModalPopupExtender ID="BtnIncluirClienteAtendimento_ModalPopupExtender" BackgroundCssClass="ModalPopupBG"
        runat="server" CancelControlID="ButtonEditCancel" OkControlID="ButtonEditDone" 
        TargetControlID="BtnIncluirClienteAtendimento" PopupControlID="DivEditWindow" 
        OnCancelScript="EditCancelScript('IframeEdit');" OnOkScript="EditOkayScript('IframeEdit');"
        BehaviorID="EditModalPopupIncluirClienteAtendimento">
    </cc1:ModalPopupExtender>
                &nbsp;<asp:ImageButton ID="BtnAlterarClienteAtendimento" runat="server" ImageUrl="~/Imagens/BtnEditar.png" 
                    AlternateText="Alterar cliente" Height="16px" ToolTip="Alterar informações do cliente" 
                    
                
                
                
                
                
                
                onclientclick="ShowEditModal('../Forms/WFClienteEmbeeded.aspx?a=A1&amp;vcodemi=SCodEmitenteAtNegociacao&amp;vcodemp=SCodClienteAtPesquisado&amp;valtecc=SAlterouCodClienteAt&amp;vrecdc=SRecarregaDdlContatosAt&amp;ccodcon=SCodContatoNegociacaoAt&amp;cnpjemi=SCNPJEmitenteAtendimento&amp;vcodemin=SCodEmitenteAtNegociacao','EditModalPopupIncluirCliente','IframeEdit');" />
    <cc1:ModalPopupExtender ID="BtnAlterarClienteAtendimento_ModalPopupExtender" BackgroundCssClass="ModalPopupBG"
        runat="server" CancelControlID="ButtonEditCancel" OkControlID="ButtonEditDone" 
        TargetControlID="BtnAlterarClienteAtendimento" PopupControlID="DivEditWindow" 
        OnCancelScript="EditCancelScript('IframeEdit');" OnOkScript="EditOkayScript('IframeEdit');"
        BehaviorID="EditModalPopupAlterarClienteAtendimento">
    </cc1:ModalPopupExtender>
                &nbsp;
            </span>
            <asp:Label ID="Label14" runat="server" Height="17px" Text="Nº Ponto Atend.:" 
                style="width: 105px"></asp:Label>
            <asp:TextBox ID="TxtNrPontoAtendimento" runat="server" CssClass="CampoCadastro" 
                Width="100px" MaxLength="25" AutoPostBack="True" Height="18px"></asp:TextBox>
            <asp:ImageButton ID="BtnFiltrarPontoAtendimento" runat="server" 
                ImageUrl="~/Imagens/search.png" ToolTip="Pesquisar" 
                onclientclick="ShowEditModal('../Pesquisas/WFPClienteFantasia.aspx?textbox=TxtCliente&amp;varmp=SCodClienteAtPesquisado&amp;varma=SAlterouNumeroPontoAtendimento&amp;varmpc=SPontoPesquisado','EditModalPopupClientes','IframeEdit');" 
                Height="15px" Width="16px" />
    <cc1:ModalPopupExtender ID="BtnFiltrarPontoAtendimento_ModalPopupExtender" BackgroundCssClass="ModalPopupBG"
        runat="server" CancelControlID="ButtonEditCancel" OkControlID="ButtonEditDone" 
        TargetControlID="BtnFiltrarPontoAtendimento" PopupControlID="DivEditWindow" 
        OnCancelScript="EditCancelScript('IframeEdit');" OnOkScript="EditOkayScript('IframeEdit');"
        BehaviorID="EditModalPopupPontoAtendimento">
    </cc1:ModalPopupExtender>
            <span class="TextoCadastro">
                &nbsp;<asp:ImageButton ID="BtnIncluirPontoAtendimento" runat="server" ImageUrl="~/Imagens/BtnIncluir.png" 
                    AlternateText="Novo Cliente" Height="16px" ToolTip="Novo Ponto de Atendimento" 
                
                onclientclick="ShowEditModal('../Forms/WFPontoAtendimentoEmbeeded.aspx?a=I&amp;vcodemi=SCodEmitenteAtNegociacao&amp;vcodemp=SCodClienteAtPesquisado&amp;valtecc=SAlterouNumeroPontoAtendimento&amp;vrecdc=SRecarregaDdlContatosAt&amp;ccodcon=SCodContatoNegociacaoAt&amp;ptat=SPontoPesquisado&amp;vcodemin=SCodEmitenteAtNegociacao','EditModalPopupIncluirPontoAtendimento','IframeEdit');" />
    <cc1:ModalPopupExtender ID="BtnIncluirPontoAtendimento_ModalPopupExtender" BackgroundCssClass="ModalPopupBG"
        runat="server" CancelControlID="ButtonEditCancel" OkControlID="ButtonEditDone" 
        TargetControlID="BtnIncluirPontoAtendimento" PopupControlID="DivEditWindow" 
        OnCancelScript="EditCancelScript('IframeEdit');" OnOkScript="EditOkayScript('IframeEdit');"
        BehaviorID="EditModalPopupIncluirPontoAtendimento">
    </cc1:ModalPopupExtender>
                &nbsp;<asp:ImageButton ID="BtnAlterarPontoAtendimento" runat="server" ImageUrl="~/Imagens/BtnEditar.png" 
                    AlternateText="Alterar cliente" Height="16px" ToolTip="Alterar informações do ponto de atendimento" 
                
                onclientclick="ShowEditModal('../Forms/WFPontoAtendimentoEmbeeded.aspx?a=A&amp;vcodemi=SCodEmitenteAtNegociacao&amp;vcodemp=SCodClienteAtPesquisado&amp;valtecc=SAlterouNumeroPontoAtendimento&amp;vrecdc=SRecarregaDdlContatosAt&amp;ccodcon=SCodContatoNegociacaoAt&amp;ptat=SPontoPesquisado&amp;vcodemin=SCodEmitenteAtNegociacao','EditModalPopupIncluirPontoAtendimento','IframeEdit');" />
    <cc1:ModalPopupExtender ID="BtnAlterarPontoAtendimento_ModalPopupExtender" BackgroundCssClass="ModalPopupBG"
        runat="server" CancelControlID="ButtonEditCancel" OkControlID="ButtonEditDone" 
        TargetControlID="BtnAlterarPontoAtendimento" PopupControlID="DivEditWindow" 
        OnCancelScript="EditCancelScript('IframeEdit');" OnOkScript="EditOkayScript('IframeEdit');"
        BehaviorID="EditModalPopupAlterarPontoAtendimento">
    </cc1:ModalPopupExtender>
            </span>
        </td>
    </tr>
    <tr>
        <td style="border-width: 1px; border-color: #C0C0C0; text-align: right;">
            Nome:</td>
        <td class="CelulaCampoCadastro">
            <asp:Label ID="LblRazaoSocialPontoAtendimento" runat="server" Font-Bold="True"></asp:Label>
        </td>
        <td class="CelulaCampoCadastro" 
            
            style="border-style: solid; border-width: 1px; border-color: #C0C0C0;" 
            rowspan="2">
            Observação:<br />
            <asp:Label ID="LblObsPontoAtendimento" runat="server" Font-Bold="True"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="border-width: 1px; border-color: #C0C0C0; text-align: right;">
            P.A.:</td>
        <td class="CelulaCampoCadastro">
            <asp:Label ID="LblNomePontoAtendimento" runat="server" Font-Bold="True"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="border-width: 1px; border-color: #C0C0C0; text-align: right;">
            Endereço:</td>
        <td class="CelulaCampoCadastro" 
            
            
            style="border-width: 1px; border-color: #C0C0C0; border-right-style: solid;" 
            colspan="2">
            <asp:Label ID="LblEnderecoAtendimento" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="border-width: 1px; border-color: #C0C0C0; text-align: right;">
            Fone:</td>
        <td class="CelulaCampoCadastro" 
            
            
            style="border-width: 1px; border-color: #C0C0C0; border-right-style: solid;" 
            colspan="2">
            <asp:Label ID="LblTelefoneAtendimento" runat="server" Font-Bold="True"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="border-width: 1px; border-color: #C0C0C0; border-bottom-style: solid; text-align: right;">
            Contato:</td>
        <td class="CelulaCampoCadastro" 
            
            
            style="border-width: 1px; border-color: #C0C0C0; border-bottom-style: solid; border-right-style: solid;" 
            colspan="2">
            <asp:DropDownList ID="DdlContatoAtendimento" runat="server" CssClass="CampoCadastro" 
                Width="225px" AutoPostBack="True">
            </asp:DropDownList>
            <span class="TextoCadastro">
            &nbsp;<asp:ImageButton ID="BtnIncluirContato0" runat="server" 
                AlternateText="Novo Contato" Height="16px" ToolTip="Novo contato" 
                ImageUrl="~/Imagens/BtnIncluir.png" 
                
                
                
                
                onclientclick="ShowEditModal('../Forms/WFContato.aspx?a=I&amp;vrecc=SRecarregaDdlContatosAt&amp;vcodc=SCodContatoNegociacaoAt&amp;vcode=SCodEmitenteAtNegociacao&amp;ptat=SPontoAtendimento','EditModalPopupIncluirContatoAtendimento','IframeEdit');" />
     <cc1:ModalPopupExtender ID="BtnIncluirContato0_ModalPopupExtender" BackgroundCssClass="ModalPopupBG"
        runat="server" CancelControlID="ButtonEditCancel" OkControlID="ButtonEditDone" 
        TargetControlID="BtnIncluirContato0" PopupControlID="DivEditWindow" 
        OnCancelScript="EditCancelScript('IframeEdit');" OnOkScript="EditOkayScript('IframeEdit');"
        BehaviorID="EditModalPopupIncluirContatoAtendimento">
    </cc1:ModalPopupExtender>
            &nbsp;<asp:ImageButton ID="BtnAlterarContato0" runat="server" 
                AlternateText="Alterar contato" Height="16px" 
                ToolTip="Alterar informações do contato" 
                ImageUrl="~/Imagens/BtnEditar.png" 
                
                
                
                
                onclientclick="ShowEditModal('../Forms/WFContato.aspx?a=A&amp;vrecc=SRecarregaDdlContatosAt&amp;vcodc=SCodContatoNegociacaoAt&amp;vcode=SCodEmitenteAtNegociacao&amp;ptat=SPontoAtendimento','EditModalPopupAlterarContatoAtendimento','IframeEdit');" />
     <cc1:ModalPopupExtender ID="BtnAlterarContato0_ModalPopupExtender" BackgroundCssClass="ModalPopupBG"
        runat="server" CancelControlID="ButtonEditCancel" OkControlID="ButtonEditDone" 
        TargetControlID="BtnAlterarContato0" PopupControlID="DivEditWindow" 
        OnCancelScript="EditCancelScript('IframeEdit');" OnOkScript="EditOkayScript('IframeEdit');"
        BehaviorID="EditModalPopupAlterarContatoAtendimento">
    </cc1:ModalPopupExtender>
            &nbsp;
            </span>
            <asp:Label ID="LblEmailAtendimento" runat="server" Height="16px"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right" colspan="2">
            Observação:</td>
        <td class="CelulaCampoCadastro" colspan="2">
            <asp:TextBox ID="TxtObservacao" runat="server" CssClass="CampoCadastro" 
                Width="400px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right" colspan="2">
            Necessita Intervenção Conjunta:</td>
        <td class="CelulaCampoCadastro" colspan="2">
            <asp:CheckBox ID="CbxIntervencaoConjunta" runat="server" Height="22px" />
&nbsp;<asp:Label ID="Label19" runat="server" Height="18px" Text=" Empresa:"></asp:Label>
            <asp:TextBox ID="TxtIntervencaoConjuntaNarrativa" runat="server" 
                CssClass="CampoCadastro" Width="200px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            &nbsp;</td>
        <td class="CelulaCampoCadastro" colspan="2">
            <asp:Button ID="BtnGravar" runat="server" Text="Gravar" CssClass="Botao" />
        &nbsp;&nbsp;
            <asp:Label ID="Label10" runat="server" Text="Chamado incluído por" 
                Height="16px"></asp:Label>
            &nbsp;<asp:Label ID="LblUsuario" runat="server" Height="16px"></asp:Label>
            <asp:Label ID="LblCodUsuario" runat="server" Height="16px" Visible="False"></asp:Label>
        </td>
    </tr>
    </table>
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
