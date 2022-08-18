<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCAtendimentoPedidoCabecalho.ascx.vb" Inherits="ResultsCRM.WUCAtendimentoPedidoCabecalho" %>
<%@ Register src="../OutrosControles/TextBoxData.ascx" tagname="TextBoxData" tagprefix="uc1" %>
<%@ Register src="../OutrosControles/TextBoxHora.ascx" tagname="TextBoxHora" tagprefix="uc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit"%>
<link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
<link href="../ResultsCRMAjax.css" rel="stylesheet" type="text/css" />
<script language="javascript" src="../ResultsCRM.js" type="text/javascript"></script>
<body>
<asp:ScriptManager ID="ScriptManager1" runat="server" 
        EnableScriptGlobalization="True">
        </asp:ScriptManager>
<table class="TextoCadastro_BGBranco" 
    style="width:100%; border-collapse: collapse; empty-cells: hide;">
    <tr>
        <td colspan="6">
            <asp:Button ID="BtnVoltar" runat="server" CssClass="Botao" Text="Voltar" 
                meta:resourcekey="BtnVoltarResource1" />
            <asp:Label ID="LblCodIndicador" runat="server" Visible="False" 
                meta:resourcekey="LblCodIndicadorResource1"></asp:Label>
            <asp:Label ID="LblDataEmissao" runat="server" Visible="False" 
                meta:resourcekey="LblDataEmissaoResource1"></asp:Label>
            <asp:Label ID="LblEmpresa" runat="server" Visible="False" 
                meta:resourcekey="LblEmpresaResource1"></asp:Label>
            <asp:Label ID="LblEstabelecimento" runat="server" Visible="False" 
                meta:resourcekey="LblEstabelecimentoResource1"></asp:Label>
            <asp:Label ID="LblCodAtendimento" runat="server" Visible="False" 
                meta:resourcekey="LblCodAtendimentoResource1"></asp:Label>
            <asp:Label ID="LblAcao" runat="server" Visible="False" 
                meta:resourcekey="LblAcaoResource1"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="Erro" colspan="6">
            <asp:Label ID="LblErro" runat="server" meta:resourcekey="LblErroResource1"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right" colspan="2">
            Nº OS:</td>
        <td>
            <asp:TextBox ID="TxtCodPedidoVenda" runat="server" CssClass="CampoCadastro" 
                MaxLength="9" Width="57px" meta:resourcekey="TxtCodPedidoVendaResource1"></asp:TextBox>
        &nbsp;&nbsp;
            <asp:Label ID="Label1" runat="server" Height="16px" Text="Chamado:" 
                meta:resourcekey="Label1Resource1"></asp:Label>
            <asp:TextBox ID="TxtNrChamado" runat="server" CssClass="CampoCadastro" style="text-align:center"
                Enabled="False" Width="57px" AutoPostBack="True" 
                meta:resourcekey="TxtNrChamadoResource1"></asp:TextBox>
            <asp:LinkButton ID="BtnAlterarChamado" runat="server" Height="17px" 
                Visible="False" meta:resourcekey="BtnAlterarChamadoResource1">Alterar</asp:LinkButton>
        &nbsp;
            <asp:Label ID="Label5" runat="server" Height="16px" Text="SAG:" 
                meta:resourcekey="Label5Resource1"></asp:Label>
            <asp:TextBox ID="TxtSag" runat="server" CssClass="CampoCadastro" 
                style="text-align:center" Width="70px" meta:resourcekey="TxtSagResource1"></asp:TextBox>
        </td>
        <td style="text-align: right">
            <asp:Label ID="LblLabelChamadoCliente" runat="server" Height="17px" Text="&nbsp;Chamado Cliente:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TxtOSCliente" runat="server" CssClass="CampoCadastro" 
                Width="75px" Height="18px"></asp:TextBox>
            <asp:Label ID="Label7" runat="server" Height="17px" Text="&nbsp;&nbsp;Status Chamado:" 
                meta:resourcekey="Label7Resource1"></asp:Label>
            <asp:Label ID="LblStatusChamado" runat="server" Height="17px" 
                meta:resourcekey="LblStatusChamadoResource1"></asp:Label>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td style="text-align: right" colspan="2">
            <asp:Label ID="Label8" runat="server" Height="17px" Text="Motivo:" 
                meta:resourcekey="Label8Resource1"></asp:Label>
            </td>
        <td>
            <asp:TextBox ID="TxtMotivoStatus" runat="server" CssClass="CampoCadastro" 
                Width="250px" meta:resourcekey="TxtMotivoStatusResource1"></asp:TextBox>
        </td>
        <td style="text-align: right; line-height: 20px; vertical-align: top;">
            Status OS:</td>
        <td colspan="1">
            <asp:DropDownList ID="DdlStatus" runat="server" CssClass="CampoCadastro" 
                Width="80px" AutoPostBack="True" meta:resourcekey="DdlStatusResource1">
                <asp:ListItem Selected="True" Value="1" meta:resourcekey="ListItemResource1">Aberta</asp:ListItem>
                <asp:ListItem Value="2" meta:resourcekey="ListItemResource2">Encerrada</asp:ListItem>
                <asp:ListItem Value="3" meta:resourcekey="ListItemResource3">Cancelada</asp:ListItem>
            </asp:DropDownList>
            &nbsp;&nbsp;<asp:Label ID="Label4" runat="server" Height="16px" 
                Text="Recebimento:" meta:resourcekey="Label4Resource1"></asp:Label>
            <asp:DropDownList ID="DdlStatusRecebimento" runat="server" 
                CssClass="CampoCadastro" Width="100px" 
                meta:resourcekey="DdlStatusRecebimentoResource1">
                <asp:ListItem Selected="True" Value="1" meta:resourcekey="ListItemResource4">OS Pendente</asp:ListItem>
                <asp:ListItem Value="2" meta:resourcekey="ListItemResource5">OS Recebida</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td style="text-align: right" colspan="2">
            <asp:Label ID="LblTomador" runat="server" Text="Tomador:" 
                meta:resourcekey="LblTomadorResource1"></asp:Label>
            </td>
        <td>
            <asp:Label ID="LblNomeEmitente" runat="server" 
                meta:resourcekey="LblNomeEmitenteResource1"></asp:Label>
            (<asp:Label ID="LblCodEmitente" runat="server" 
                meta:resourcekey="LblCodEmitenteResource1"></asp:Label>
            )</td>
        <td style="text-align: right; line-height: 20px; vertical-align: top;">
            Status Técnico:</td>
        <td>
            <asp:DropDownList ID="DdlStatusTecnico" runat="server" CssClass="CampoCadastro" 
                Width="120px" Enabled="False" meta:resourcekey="DdlStatusTecnicoResource1">
                <asp:ListItem Selected="True" Value="1" meta:resourcekey="ListItemResource6">Aberta</asp:ListItem>
                <asp:ListItem Value="2" meta:resourcekey="ListItemResource7">Em atendimento</asp:ListItem>
                <asp:ListItem Value="3" meta:resourcekey="ListItemResource8">Finalizada</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td style="text-align: right; line-height: 20px; vertical-align: top;" 
            colspan="2">
            <asp:Label ID="LblCNPJFaturamento" runat="server" 
                Text="CNPJ Faturamento:"></asp:Label>
            <asp:Label ID="LblCNPJCobranca" runat="server" 
                Text="&lt;br&gt;CNPJ Cobrança:"></asp:Label>
            <asp:Label ID="LblCNPJEntrega" runat="server" 
                Text="&lt;br&gt;CNPJ Entrega:"></asp:Label>
            <asp:Label ID="LblTipoFreteLbl" runat="server" 
                Text="&lt;br&gt;Tipo de Frete:"></asp:Label>
        </td>
        <td style="line-height: 20px; vertical-align: top;">
            <asp:DropDownList ID="DdlCNPJFaturamento" runat="server" CssClass="CampoCadastro" 
                Width="255px" Height="20px">
            </asp:DropDownList>
            <asp:Label ID="LblCNPJCobrancaQuebra" runat="server" Text="&lt;br&gt;"></asp:Label>
            <asp:DropDownList ID="DdlCNPJCobranca" runat="server" CssClass="CampoCadastro" 
                Width="255px" Height="20px">
            </asp:DropDownList>
            <asp:Label ID="LblCNPJEntregaQuebra" runat="server" Text="&lt;br&gt;"></asp:Label>
            <asp:DropDownList ID="DdlCNPJEntrega" runat="server" CssClass="CampoCadastro" 
                Width="255px" Height="20px">
            </asp:DropDownList>
            <asp:Label ID="LblTipoFreteQuebra" runat="server" Text="&lt;br&gt;"></asp:Label>
            <asp:DropDownList ID="DdlTipoFrete" runat="server" CssClass="CampoCadastro" 
                Width="255px" Height="20px">
                <asp:ListItem Value="1">CIF - Por conta do emitente</asp:ListItem>
                <asp:ListItem Value="2">FOB - Por conta do destinatário</asp:ListItem>
                <asp:ListItem Value="3">CIF - Por conta do emitente cobrado na nota</asp:ListItem>
            </asp:DropDownList>
            </td>
        <td style="text-align: right; line-height: 20px; vertical-align: top;">
            <asp:Label ID="LblNaturOper" runat="server" 
                Text="Natureza de Operação:"></asp:Label>
            <asp:Label ID="LblFormaPagamento" runat="server" 
                Text="&lt;br&gt;Forma de Pagamento:"></asp:Label>
            <asp:Label ID="LblCondicaoPagamento" runat="server" 
                Text="&lt;br&gt;Condição de Pagamento:"></asp:Label>
            <asp:Label ID="LblCanalVenda" runat="server" Text="&lt;br&gt;Canal de Vendas:"></asp:Label>
        </td>
        <td colspan="2" style="line-height: 20px; vertical-align: top;">
            <asp:DropDownList ID="DdlNaturOper" runat="server" CssClass="CampoCadastro" 
                Width="255px" Height="20px">
            </asp:DropDownList>
            <asp:Label ID="LblFormaPagamentoQuebra" runat="server" Text="&lt;br&gt;"></asp:Label>
            <asp:DropDownList ID="DdlFormaPagamento" runat="server" CssClass="CampoCadastro" 
                Width="255px" Height="20px">
            </asp:DropDownList>
            <asp:Label ID="LblCondicaoPagamentoQuebra" runat="server" Text="&lt;br&gt;"></asp:Label>
            <asp:DropDownList ID="DdlCondicaoPagamento" runat="server" CssClass="CampoCadastro" 
                Width="255px" Height="20px">
            </asp:DropDownList>
            <asp:Label ID="LblCanalVendaQuebra" runat="server" Text="&lt;br&gt;"></asp:Label>
            <asp:DropDownList ID="DdlCanalVenda" runat="server" CssClass="CampoCadastro" 
                Width="255px" Height="20px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="text-align: right; vertical-align: top;" colspan="2">
            <asp:Label ID="LblObsFiscais" runat="server" Text="Observações Fiscais:" 
                meta:resourceKey="LblMtvNvOSResource1"></asp:Label>
        </td>
        <td style="vertical-align: top">
            <asp:TextBox ID="TxtObservacao" runat="server" CssClass="CampoCadastro" 
                Width="250px" meta:resourcekey="TxtObservacaoResource1" Height="75px" 
                TextMode="MultiLine"></asp:TextBox>
        </td>
        <td style="text-align: right; line-height: 20px; vertical-align: top;">
            <asp:Label ID="LblObsNaoFiscais" runat="server" Text="Observações Não Fiscais:" 
                meta:resourceKey="LblMtvNvOSResource1"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TxtObservacaoNaoFiscal" runat="server" CssClass="CampoCadastro" 
                Width="250px" meta:resourcekey="TxtObservacaoResource1" Height="75px" 
                TextMode="MultiLine"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td style="text-align: right" colspan="2">
            <asp:Label ID="LblPtAtendimento" runat="server" Text="Ponto de Atendimento:" 
                meta:resourcekey="LblPtAtendimentoResource1"></asp:Label>
        </td>
        <td>
            <asp:Label ID="LblPontoAtendimento" runat="server" 
                meta:resourcekey="LblPontoAtendimentoResource1"></asp:Label>
        </td>
        <td style="text-align: right; line-height: 20px; vertical-align: top;">
            <asp:Label ID="LblTransportadora" runat="server" 
                Text="Transportadora:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TxtCodTransportadora" runat="server" CssClass="TextoCadastro" 
                Width="50px" MaxLength="6" AutoPostBack="True" Height="18px"></asp:TextBox>
            &nbsp;<asp:ImageButton ID="BtnFiltrarTransportadora" runat="server" 
                ImageUrl="~/Imagens/search.png" ToolTip="Pesquisar" 
                onclientclick="ShowEditModal('../Pesquisas/WFPTransportadora.aspx?textbox=TxtCliente&amp;varmp=SCodClientePesquisado&amp;varma=SAlterouCodCliente','EditModalPopupClientes','IframeEdit');" 
                Height="15px" Width="16px" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender2" BackgroundCssClass="ModalPopupBG"
        runat="server" CancelControlID="ButtonEditCancel" OkControlID="ButtonEditDone" 
        TargetControlID="BtnFiltrarTransportadora" PopupControlID="DivEditWindow" 
        OnCancelScript="EditCancelScript('IframeEdit');" OnOkScript="EditOkayScript('IframeEdit');"
        BehaviorID="EditModalPopupClientes">
    </ajaxToolkit:ModalPopupExtender>
    &nbsp;<asp:Label ID="LblNomeTransportadora" runat="server" Font-Bold="False"></asp:Label>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td style="border-width: 1px; border-color: #CCCCCC; text-align: right; border-bottom-style: solid;" 
            colspan="2">
            <asp:Label ID="LblMtvNvOS" runat="server" Text="Motivo para Nova OS:" 
                meta:resourcekey="LblMtvNvOSResource1"></asp:Label>
        </td>
        <td style="border-width: 1px; border-color: #CCCCCC; border-bottom-style: solid;">
            <asp:TextBox ID="TxtAux1" runat="server" CssClass="CampoCadastro" 
                Width="250px" meta:resourcekey="TxtAux1Resource1"></asp:TextBox>
        </td>
        <td style="border-width: 1px; border-color: #CCCCCC; border-bottom-style: solid; text-align: right;">
            Contrato:</td>
        <td style="border-width: 1px; border-color: #CCCCCC; border-bottom-style: solid;" 
            colspan="2">
            <asp:CheckBox ID="CbxContrato" runat="server" />
        </td>
    </tr>
    <tr>
        <td style="border-width: 1px; border-color: #CCCCCC; text-align: right; border-bottom-style: solid;" 
            colspan="2">
            Início Trab. Técnico:</td>
        <td style="border-width: 1px; border-color: #CCCCCC; border-bottom-style: solid;" 
            colspan="4">
            <asp:TextBox ID="TxtDataInicioTrabalhoTecnico" runat="server" 
                CssClass="CampoCadastro" Width="65px" Enabled="False"></asp:TextBox> <ajaxToolkit:CalendarExtender ID="TxtDataRecontatoI_CalendarExtender" runat="server" 
                        TargetControlID="TxtDataInicioTrabalhoTecnico" FirstDayOfWeek="Sunday"
                        Format="dd/MM/yyyy" TodaysDateFormat="d MMMM yyyy"></ajaxToolkit:CalendarExtender>
            <ajaxToolkit:MaskedEditExtender ID="TxtDataInicioTrabalhoTecnico_MaskedEditExtender" runat="server" 
                BehaviorID="TxtDataInicioTrabalhoTecnico_MaskedEditExtender" Century="2000" 
                CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                CultureThousandsPlaceholder="" CultureTimePlaceholder="" Mask="99/99/9999" 
                MaskType="Date" TargetControlID="TxtDataInicioTrabalhoTecnico" 
                UserDateFormat="DayMonthYear" />
            <asp:TextBox ID="TxtHoraInicioTrabalhoTecnico" runat="server" CssClass="CampoCadastro" 
                style="margin-bottom: 0px" Width="40px" Enabled="False"></asp:TextBox>
            <ajaxToolkit:MaskedEditExtender ID="TxtHoraInicioTrabalhoTecnico_MaskedEditExtender" 
                TargetControlID="TxtHoraInicioTrabalhoTecnico" AcceptAMPM="False" 
                ErrorTooltipEnabled="True" Mask="99:99" MaskType="Time" runat="server" />
        </td>
    </tr>
    <tr>
        <td style="border-width: 1px; border-color: #CCCCCC; text-align: center; border-bottom-style: solid; border-right-style: solid;">
            <asp:Label ID="LblGrupoAgendamento" runat="server" Text="Agendamento"></asp:Label>
        </td>
        <td style="border-width: 1px; border-color: #CCCCCC; text-align: right; border-bottom-style: solid;">
            <asp:Label ID="LblAgendamentoChegada" runat="server" Text="Chegada:" 
                meta:resourcekey="Label10Resource1"></asp:Label>
        </td>
        <td style="border-width: 1px; border-color: #CCCCCC; border-bottom-style: solid;" 
            colspan="4">
            <asp:TextBox ID="TxtDataChegadaPrevista" runat="server" CssClass="CampoCadastro" 
                MaxLength="10" Width="65px" 
                meta:resourcekey="TxtDataChegadaPrevistaResource1"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" 
                        TargetControlID="TxtDataChegadaPrevista" FirstDayOfWeek="Sunday"
                        Format="dd/MM/yyyy" TodaysDateFormat="d MMMM yyyy"></ajaxToolkit:CalendarExtender>
            <ajaxToolkit:MaskedEditExtender ID="TxtDataChegadaPrevista_MaskedEditExtender" 
                runat="server" BehaviorID="TxtDataChegadaPrevista_MaskedEditExtender" 
                Century="2000" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                CultureThousandsPlaceholder="" CultureTimePlaceholder="" Mask="99/99/9999" 
                MaskType="Date" TargetControlID="TxtDataChegadaPrevista" 
                UserDateFormat="DayMonthYear" />
            <asp:TextBox ID="TxtHoraChegadaPrevista" runat="server" CssClass="CampoCadastro" 
                Width="40px" meta:resourcekey="TxtHoraChegadaPrevistaResource1"></asp:TextBox>
            <ajaxToolkit:MaskedEditExtender ID="TxtHoraChegadaPrevista_MaskedEditExtender" 
                TargetControlID="TxtHoraChegadaPrevista" 
                ErrorTooltipEnabled="True" Mask="99:99" MaskType="Time" runat="server" 
                BehaviorID="ctl00_TxtHoraChegadaPrevista_MaskedEditExtender" Century="2000" 
                CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                CultureThousandsPlaceholder="" CultureTimePlaceholder="" />
            <asp:Label ID="LblAgendamentoEncerramento" runat="server" Height="17px" Text="&nbsp;Encerramento:" 
                meta:resourcekey="Label3Resource1"></asp:Label>
            <asp:TextBox ID="TxtDataEntrega" runat="server" CssClass="CampoCadastro" 
                MaxLength="10" Width="65px" meta:resourcekey="TxtDataEntregaResource1"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" 
                        TargetControlID="TxtDataEntrega" FirstDayOfWeek="Sunday"
                        Format="dd/MM/yyyy" TodaysDateFormat="d MMMM yyyy"></ajaxToolkit:CalendarExtender>
            <ajaxToolkit:MaskedEditExtender ID="TxtDataEntrega_MaskedEditExtender" 
                runat="server" BehaviorID="TxtDataEntrega_MaskedEditExtender" Century="2000" 
                CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                CultureThousandsPlaceholder="" CultureTimePlaceholder="" Mask="99/99/9999" 
                MaskType="Date" TargetControlID="TxtDataEntrega" 
                UserDateFormat="DayMonthYear" />
            <asp:TextBox ID="TxtHoraEntrega" runat="server" CssClass="CampoCadastro" 
                Width="40px" meta:resourcekey="TxtHoraEntregaResource1"></asp:TextBox>
            <ajaxToolkit:MaskedEditExtender ID="TxtHoraEntrega_MaskedEditExtender" 
                TargetControlID="TxtHoraEntrega" ErrorTooltipEnabled="True" 
                Mask="99:99" MaskType="Time" runat="server" 
                BehaviorID="ctl00_TxtHoraEntrega_MaskedEditExtender" Century="2000" 
                CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                CultureThousandsPlaceholder="" CultureTimePlaceholder="" />
        </td>
    </tr>
    <tr>
        <td style="border-width: 1px; border-color: #CCCCCC; text-align: center; border-bottom-style: solid; border-right-style: solid;">
            <asp:Label ID="LblGrupoTecnico" runat="server" Text="Técnico"></asp:Label>
        </td>
        <td style="border-width: 1px; border-color: #CCCCCC; text-align: right; border-bottom-style: solid;">
            <asp:Label ID="LblTecnicoChegada" runat="server" Text="Chegada:" 
                meta:resourcekey="Label11Resource1"></asp:Label>
        </td>
        <td style="border-width: 1px; border-color: #CCCCCC; border-bottom-style: solid;" 
            colspan="4">
            <asp:TextBox ID="TxtDataInicioExecucao" runat="server" CssClass="CampoCadastro" 
                MaxLength="10" Width="65px" 
                meta:resourcekey="TxtDataInicioExecucaoResource1"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" 
                        TargetControlID="TxtDataInicioExecucao" FirstDayOfWeek="Sunday"
                        Format="dd/MM/yyyy" TodaysDateFormat="d MMMM yyyy"></ajaxToolkit:CalendarExtender>
            <ajaxToolkit:MaskedEditExtender ID="TxtDataInicioExecucao_MaskedEditExtender" 
                runat="server" BehaviorID="TxtDataInicioExecucao_MaskedEditExtender" 
                Century="2000" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                CultureThousandsPlaceholder="" CultureTimePlaceholder="" Mask="99/99/9999" 
                MaskType="Date" TargetControlID="TxtDataInicioExecucao" 
                UserDateFormat="DayMonthYear" />
            <asp:TextBox ID="TxtHoraInicioExecucao" runat="server" CssClass="CampoCadastro" 
                Width="40px" 
                meta:resourcekey="TxtHoraInicioExecucaoResource1"></asp:TextBox>
            <ajaxToolkit:MaskedEditExtender ID="TxtHoraInicioExecucao_MaskedEditExtender" 
                TargetControlID="TxtHoraInicioExecucao" 
                ErrorTooltipEnabled="True" Mask="99:99" MaskType="Time" runat="server" 
                BehaviorID="ctl00_TxtHoraInicioExecucao_MaskedEditExtender" Century="2000" 
                CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                CultureThousandsPlaceholder="" CultureTimePlaceholder="" />
            <asp:Label ID="LblTecnicoEncerramento" runat="server" Height="17px" Text="&nbsp;Encerramento:" 
                meta:resourcekey="Label3Resource1"></asp:Label>
            <asp:TextBox ID="TxtDataTerminoExecucao" runat="server" CssClass="CampoCadastro" 
                MaxLength="10" Width="65px" 
                meta:resourcekey="TxtDataTerminoExecucaoResource1"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" 
                        TargetControlID="TxtDataTerminoExecucao" FirstDayOfWeek="Sunday"
                        Format="dd/MM/yyyy" TodaysDateFormat="d MMMM yyyy"></ajaxToolkit:CalendarExtender>
            <ajaxToolkit:MaskedEditExtender ID="TxtDataTerminoExecucao_MaskedEditExtender" 
                runat="server" BehaviorID="TxtDataTerminoExecucao_MaskedEditExtender" 
                Century="2000" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                CultureThousandsPlaceholder="" CultureTimePlaceholder="" Mask="99/99/9999" 
                MaskType="Date" TargetControlID="TxtDataTerminoExecucao" />
            <asp:TextBox ID="TxtHoraTerminoExecucao" runat="server" CssClass="CampoCadastro" 
                Width="40px" 
                meta:resourcekey="TxtHoraTerminoExecucaoResource1"></asp:TextBox>
            <ajaxToolkit:MaskedEditExtender ID="TxtHoraTerminoExecucao_MaskedEditExtender" 
                TargetControlID="TxtHoraTerminoExecucao" 
                ErrorTooltipEnabled="True" Mask="99:99" MaskType="Time" runat="server" 
                BehaviorID="ctl00_TxtHoraTerminoExecucao_MaskedEditExtender" Century="2000" 
                CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                CultureThousandsPlaceholder="" CultureTimePlaceholder="" />
            <asp:ImageButton ID="BtnCopiarInfoTecnico" runat="server" 
                ImageUrl="~/Imagens/copiar.png" Height="16px" 
                onclientclick="return confirm('Copiar dados informados pelo técnico para o campo Execução e encerrar a OS?')" 
                ToolTip="Copiar dados informados pelo técnico para o campo Execução" 
                Visible="False" meta:resourcekey="BtnCopiarInfoTecnicoResource1" />
        </td>
    </tr>
    <tr>
        <td style="border-width: 1px; border-color: #CCCCCC; text-align: center; border-bottom-style: solid; border-right-style: solid;">
            <asp:Label ID="LblGrupoExecucao" runat="server" Text="Execução"></asp:Label>
        </td>
        <td style="border-width: 1px; border-color: #CCCCCC; text-align: right; border-bottom-style: solid;">
            <asp:Label ID="LblExecucaoChegada" runat="server" Text="Chegada:" 
                meta:resourcekey="Label12Resource1"></asp:Label>
        </td>
        <td style="border-width: 1px; border-color: #CCCCCC; border-bottom-style: solid;" 
            colspan="4">
            <asp:TextBox ID="TxtDataChegada" runat="server" CssClass="CampoCadastro" 
                MaxLength="10" Width="65px" meta:resourcekey="TxtDataChegadaResource1"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender5" runat="server" 
                        TargetControlID="TxtDataChegada" FirstDayOfWeek="Sunday"
                        Format="dd/MM/yyyy" TodaysDateFormat="d MMMM yyyy"></ajaxToolkit:CalendarExtender>
            <ajaxToolkit:MaskedEditExtender ID="TxtDataChegada_MaskedEditExtender" 
                runat="server" BehaviorID="TxtDataChegada_MaskedEditExtender" Century="2000" 
                CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                CultureThousandsPlaceholder="" CultureTimePlaceholder="" Mask="99/99/9999" 
                MaskType="Date" TargetControlID="TxtDataChegada" 
                UserDateFormat="DayMonthYear" />
            <asp:TextBox ID="TxtHoraChegada" runat="server" CssClass="CampoCadastro" 
                Width="40px" meta:resourcekey="TxtHoraChegadaResource1"></asp:TextBox>
            <ajaxToolkit:MaskedEditExtender ID="TxtHoraChegada_MaskedEditExtender" 
                TargetControlID="TxtHoraChegada" ErrorTooltipEnabled="True" 
                Mask="99:99" MaskType="Time" runat="server" 
                BehaviorID="ctl00_TxtHoraChegada_MaskedEditExtender" Century="2000" 
                CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                CultureThousandsPlaceholder="" CultureTimePlaceholder="" />
            <asp:Label ID="LblExecucaoEncerramento" runat="server" Height="17px" Text="&nbsp;Encerramento:" 
                meta:resourcekey="Label3Resource1"></asp:Label>
            <asp:TextBox ID="TxtDataEncerramento" runat="server" CssClass="CampoCadastro" 
                MaxLength="10" Width="65px" 
                meta:resourcekey="TxtDataEncerramentoResource1"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender6" runat="server" 
                        TargetControlID="TxtDataEncerramento" FirstDayOfWeek="Sunday"
                        Format="dd/MM/yyyy" TodaysDateFormat="d MMMM yyyy"></ajaxToolkit:CalendarExtender>
            <ajaxToolkit:MaskedEditExtender ID="TxtDataEncerramento_MaskedEditExtender" 
                runat="server" BehaviorID="TxtDataEncerramento_MaskedEditExtender" 
                Century="2000" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                CultureThousandsPlaceholder="" CultureTimePlaceholder="" Mask="99/99/9999" 
                MaskType="Date" TargetControlID="TxtDataEncerramento" 
                UserDateFormat="DayMonthYear" />
            <asp:TextBox ID="TxtHoraEncerramento" runat="server" CssClass="CampoCadastro" 
                Width="40px" meta:resourcekey="TxtHoraEncerramentoResource1"></asp:TextBox>
            <ajaxToolkit:MaskedEditExtender ID="TxtHoraEncerramento_MaskedEditExtender" 
                TargetControlID="TxtHoraEncerramento" 
                ErrorTooltipEnabled="True" Mask="99:99" MaskType="Time" runat="server" 
                BehaviorID="ctl00_TxtHoraEncerramento_MaskedEditExtender" Century="2000" 
                CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                CultureThousandsPlaceholder="" CultureTimePlaceholder="" />
        </td>
    </tr>
    <tr>
        <td colspan="2" style="vertical-align: top">
            <asp:CheckBox ID="CbxImprimirMatricial" runat="server" 
                Text="Imprimir OS Matricial:" TextAlign="Left" 
                meta:resourcekey="CbxImprimirMatricialResource1" />
        </td>
        <td colspan="4" id="tdBarraFerramentas" runat="server">
            <asp:Button ID="BtnGravar" runat="server" CssClass="Botao" 
                Text="Incluir Ordem de Serviço" meta:resourcekey="BtnGravarResource1" />
        &nbsp;
            <asp:Button ID="BtnImprimirOS" runat="server" CssClass="Botao" 
                Text="Imprimir OS" Visible="False" 
                meta:resourcekey="BtnImprimirOSResource1" />
            <asp:Label ID="LblConfirmacao" runat="server" 
                Height="19px" 
                Visible="False"></asp:Label>
            <asp:Label ID="LblNumeroSerialEquipamentoNaoInformado" runat="server" 
                Height="19px" 
                Text="&lt;b style=&quot;color:Maroon&quot;&gt;ATENÇÃO:&lt;/b&gt; Número serial não foi informado no equipamento.&lt;br&gt;Deseja encerrar mesmo assim?&nbsp;" 
                Visible="False"></asp:Label>
            <asp:Label ID="LblDesejaEncerrarOS" runat="server" Height="19px" 
                
                Text="&lt;b style=&quot;color:Maroon&quot;&gt;ATENÇÃO:&lt;/b&gt; Deseja encerrar a O.S.?&nbsp;" 
                Visible="False" meta:resourcekey="LblDesejaEncerrarOSResource1"></asp:Label>
            <asp:Button ID="BtnEncerraOS" runat="server" CssClass="Botao" Text="Sim" 
                Visible="False" Width="55px" Height="21px" 
                meta:resourcekey="BtnEncerraOSResource1" />
            &nbsp;&nbsp;<asp:Button ID="BtnNaoEncerraOS" runat="server" CssClass="Botao" Text="Não" 
                Visible="False" Width="55px" Height="21px" 
                meta:resourcekey="BtnNaoEncerraOSResource1" />
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
        <iframe id="IframeEdit" frameborder="0" width="370" height="350" scrolling="no">
        </iframe>
    </div>
</body>

