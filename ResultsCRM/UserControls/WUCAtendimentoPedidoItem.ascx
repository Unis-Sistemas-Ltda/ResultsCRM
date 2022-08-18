<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCAtendimentoPedidoItem.ascx.vb" Inherits="ResultsCRM.WUCAtendimentoPedidoItem" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register src="../OutrosControles/TextBoxNumerico.ascx" tagname="TextBoxNumerico" tagprefix="uc1" %>

<link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
<link href="../ResultsCRMAjax.css" rel="stylesheet" type="text/css" />

<script type="text/javascript" language="javascript" src="../ResultsCRM.js"></script>

<asp:ScriptManager ID="ScriptManager1" runat="server" 
    EnableScriptGlobalization="True"></asp:ScriptManager>

<table class="TextoCadastro_BGBranco" 
    style="width:100%; empty-cells: hide; border-collapse: collapse;">
    <tr>
        <td colspan="4">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td colspan="4">
            <asp:Label ID="LblErro" runat="server" CssClass="Erro"></asp:Label>
        </td>
        <td>
            &nbsp;</td>
    </tr> 
    <tr>
        <td style="text-align: right" colspan="2">
            Seq. Item:</td>
        <td colspan="2">
            <asp:Label ID="LblSeqItem" runat="server" Font-Bold="True" Width="200px"></asp:Label>
            <asp:Label ID="LblAcao" runat="server" BackColor="#ECFFEC" Font-Bold="True" style="text-align:center"
                Width="138px" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px"></asp:Label>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td style="text-align: right; " 
            class="CampoCadastro" colspan="2">
            <asp:Label ID="LblEquipamentoLabel" runat="server" Text="Equipamento:"></asp:Label>
        </td>
        <td 
            colspan="2">
            <asp:DropDownList ID="DdlEquipamento" runat="server" CssClass="CampoCadastro" 
                Width="285px" AutoPostBack="True">
            </asp:DropDownList>
        &nbsp;<span><asp:ImageButton ID="BtnIncluirEquipamento" runat="server" 
                AlternateText="Novo Equipamento" Height="16px" ToolTip="Incluir Equipamento" 
                ImageUrl="~/Imagens/BtnIncluir.png" 
                
                
                
                onclientclick="ShowEditModal('../Forms/WFEquipamento.aspx?aid=I','EditModalPopupClientes','IframeEdit');" />
     <cc1:ModalPopupExtender ID="ModalPopupExtender3" BackgroundCssClass="ModalPopupBG"
        runat="server" CancelControlID="ButtonEditCancel" OkControlID="ButtonEditDone" 
        TargetControlID="BtnIncluirEquipamento" PopupControlID="DivEditWindow" 
        OnCancelScript="EditCancelScript('IframeEdit');" OnOkScript="EditOkayScript('IframeEdit');"
        BehaviorID="EditModalPopupIncluirContato">
    </cc1:ModalPopupExtender>
            &nbsp;<asp:ImageButton ID="BtnAlterarEquipamento" runat="server" 
                AlternateText="Alterar equipamento" Height="16px" 
                ToolTip="Alterar informações do Equipamento" 
                ImageUrl="~/Imagens/BtnEditar.png" 
                
                
                
                
                onclientclick="ShowEditModal('../Forms/WFEquipamento.aspx?aid=A','EditModalPopupClientes','IframeEdit');" 
                style="width: 9px" />
     <cc1:ModalPopupExtender ID="ModalPopupExtender4" BackgroundCssClass="ModalPopupBG"
        runat="server" CancelControlID="ButtonEditCancel" OkControlID="ButtonEditDone" 
        TargetControlID="BtnAlterarEquipamento" PopupControlID="DivEditWindow" 
        OnCancelScript="EditCancelScript('IframeEdit');" OnOkScript="EditOkayScript('IframeEdit');"
        BehaviorID="EditModalPopupAlterarContato">
    </cc1:ModalPopupExtender>
            &nbsp;<asp:ImageButton ID="BtnPesquisarEquipamento" runat="server" 
                AlternateText="Pesquisar equipamento" Height="16px" 
                ToolTip="Pesquisar Equipamento" 
                ImageUrl="~/Imagens/search.png" 
                onclientclick="ShowEditModal('../Pesquisas/WFPEquipamento.aspx','EditModalPopupClientes','IframeEdit');" />
     <cc1:ModalPopupExtender ID="BtnPesquisarEquipamento_ModalPopupExtender" BackgroundCssClass="ModalPopupBG"
        runat="server" CancelControlID="ButtonEditCancel" OkControlID="ButtonEditDone" 
        TargetControlID="BtnPesquisarEquipamento" PopupControlID="DivEditWindow" 
        OnCancelScript="EditCancelScript('IframeEdit');" OnOkScript="EditOkayScript('IframeEdit');"
        BehaviorID="EditModalPopupPesquisarEquipamento">
    </cc1:ModalPopupExtender>
            </span>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td style="text-align: right; " 
            class="CampoCadastro" colspan="2">
            <asp:Label ID="LblComponenteLabel" runat="server" Text="Componente:"></asp:Label>
        </td>
        <td 
            colspan="2">
            <asp:DropDownList ID="DdlComponente" runat="server" CssClass="CampoCadastro" 
                Width="337px">
            </asp:DropDownList>
            <asp:DropDownList ID="DdlSolicitacao" runat="server" CssClass="CampoCadastro" 
                Width="337px" Visible="False">
            </asp:DropDownList>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td style="text-align: right; text-align: right; border-right-color: #C0C0C0; width: 140px;" 
            rowspan="8">
            Serviço Realizado&nbsp;</td>
        <td style="border-style: none; vertical-align: middle; text-align: right; width: 145px;">
            &nbsp;</td>
        <td class="CelulaCampoCadastro" 
            
            
            style="border-style: none; vertical-align: top; border-top-color: #999999; border-right-color: #999999;" 
            colspan="2">
            <asp:RadioButtonList ID="RblSelecionarItemContrato" runat="server" 
                AutoPostBack="True" CellSpacing="0" CssClass="CelulaCampoCadastro">
                <asp:ListItem Value="S">Selecionar item de contrato</asp:ListItem>
                <asp:ListItem Selected="True" Value="N">Informar item manualmente</asp:ListItem>
            </asp:RadioButtonList>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td style="vertical-align: middle; text-align: right; ">
            Item:</td>
        <td class="CelulaCampoCadastro" 
            
            
            style="border-width: 1px; border-color: #999999; vertical-align: top; " 
            colspan="2">
            <asp:TextBox ID="TxtCodItem" runat="server" CssClass="CampoCadastro" 
                Width="90px" AutoPostBack="True"></asp:TextBox>
                        <asp:ImageButton ID="BtnFiltrarItem" runat="server" 
                ImageUrl="~/Imagens/search.png" ToolTip="Pesquisar" 
                
                onclientclick="ShowEditModal('../Pesquisas/WFPItemReferencia.aspx?textbox=TxtCodItem','EditModalPopupClientes','IframeEdit');" />
    <cc1:ModalPopupExtender ID="ModalPopupExtender1" BackgroundCssClass="ModalPopupBG"
        runat="server" CancelControlID="ButtonEditCancel" OkControlID="ButtonEditDone" 
        TargetControlID="BtnFiltrarItem" PopupControlID="DivEditWindow" 
        OnCancelScript="EditCancelScript('IframeEdit');" OnOkScript="EditOkayScript('IframeEdit');"
        BehaviorID="EditModalPopupClientes">
    </cc1:ModalPopupExtender>
            <asp:Label ID="LblDescricaoItem" runat="server" Font-Bold="True" 
                Height="17px"></asp:Label>
            <asp:DropDownList ID="DdlItemContrato" runat="server" AutoPostBack="True" 
                CssClass="CampoCadastro" Visible="False" Width="337px">
            </asp:DropDownList>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td style="vertical-align: middle; text-align: right; line-height: 20px;">
            Referência:<asp:Label ID="LblLote" runat="server" 
                Text="&lt;br&gt;Lote:" Visible="False"></asp:Label>
        </td>
        <td class="CelulaCampoCadastro" 
            
            
            style="border-width: 1px; border-color: #999999; vertical-align: top; line-height: 20px;" 
            colspan="2">
            <asp:DropDownList ID="DdlReferencia" runat="server" 
                CssClass="CampoCadastro" Width="337px">
            </asp:DropDownList>
            <asp:Label ID="LblLoteQuebra" runat="server" Text="&lt;br&gt;" 
                Visible="False"></asp:Label>
            <asp:TextBox ID="TxtLote" runat="server" CssClass="CampoCadastro" 
                Visible="False" Width="115px"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td style="vertical-align: middle; text-align: right; border-left-color: #999999; line-height: 20px;">
            <asp:Label ID="LblTipoCobranca" runat="server" Text="Tipo Cobrança:" Visible="False"></asp:Label>
            <asp:Label ID="LblNaturOper" runat="server" Text="&lt;br&gt;Natureza de Operação:" Visible="False"></asp:Label>
        </td>
        <td class="CelulaCampoCadastro" style="border-right-color: #999999; line-height: 20px;" colspan="2">
            <asp:DropDownList ID="DdlTipoCobranca" runat="server" CssClass="CampoCadastro" Width="337px" Visible="False" AutoPostBack="True"></asp:DropDownList>
            <asp:Label ID="LblNaturezaQuebra" runat="server" Text="&lt;br&gt;" Visible="False"></asp:Label>
            <asp:DropDownList ID="DdlNaturOper" runat="server" CssClass="CampoCadastro" Width="337px" Height="20px" Visible="False"></asp:DropDownList>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td style="text-align: right; vertical-align: middle; border-left-width: 1px; border-left-color: #999999;">
            <asp:Label ID="LblDataEntrega" runat="server" Height="17px" 
                Text="&nbsp;&nbsp;Data:&nbsp;" Visible="False"></asp:Label>
        </td>
        <td colspan="2" 
            style="border-right-color: #999999;">
            <asp:TextBox ID="TxtDataEntrega" runat="server" CssClass="CampoCadastro" 
                Width="80px"></asp:TextBox> <cc1:CalendarExtender ID="TxtDataRecontatoI_CalendarExtender" runat="server" 
                        TargetControlID="TxtDataEntrega" FirstDayOfWeek="Sunday"
                        Format="dd/MM/yyyy" TodaysDateFormat="d MMMM yyyy"></cc1:CalendarExtender>
            <cc1:MaskedEditExtender ID="TxtDataEntrega_MaskedEditExtender" runat="server" 
                BehaviorID="TxtDataEntrega_MaskedEditExtender" Century="2000" 
                CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                CultureThousandsPlaceholder="" CultureTimePlaceholder="" Mask="99/99/9999" 
                MaskType="Date" TargetControlID="TxtDataEntrega" 
                UserDateFormat="DayMonthYear" />
            <asp:Label ID="LblInicial" runat="server" Text="&nbsp;Inicial:" Visible="False" 
                Height="17px"></asp:Label>
            <asp:TextBox ID="TxtInicial" runat="server" style="text-align:center"
                CssClass="CampoCadastro" Visible="False" Width="55px"></asp:TextBox>
            <asp:Label ID="LblFinal" runat="server" Height="17px" 
                Text="&nbsp;&nbsp;Final:&nbsp;" Visible="False"></asp:Label>
            <asp:TextBox ID="TxtFinal" runat="server" style="text-align:center"
                CssClass="CampoCadastro" Visible="False" Width="55px"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td style="text-align: right; vertical-align: middle; border-left-width: 1px; border-left-color: #999999;">
            <asp:Label ID="LblLocalOrigem" runat="server" Text="Local Origem:" 
                Visible="False"></asp:Label>
        </td>
        <td colspan="2" 
            style="border-right-color: #999999;">
            <asp:TextBox ID="TxtLocalOrigem" runat="server" CssClass="CampoCadastro" 
                Visible="False" Width="115px"></asp:TextBox>
            <asp:Label ID="LblLocalDestino" runat="server" Height="17px" 
                Text="&nbsp;&nbsp;Local Destino:&nbsp;" Visible="False"></asp:Label>
            <asp:TextBox ID="TxtLocalDestino" runat="server" CssClass="CampoCadastro" 
                Visible="False" Width="115px"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td style="text-align: right; vertical-align: top; border-bottom-color: #999999; border-left-color: #999999;">
            <asp:Label ID="LblDescricao" runat="server" Text="Descrição/Narrativa:"></asp:Label>
        </td>
        <td colspan="2" 
            
            style="border-bottom-color: #999999; border-right-color: #999999;">
            <asp:TextBox ID="TxtNarrativa" runat="server"
                Width="337px" Font-Names="Courier New" Font-Size="8pt" Height="110px" 
                TextMode="MultiLine"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td style="text-align: right; vertical-align: top; border-bottom-width: 1px; border-bottom-color: #999999; border-left-width: 1px; border-left-color: #999999;">
            <asp:Label ID="LblAgenteTecnico" runat="server" Text="Agente Técnico:"></asp:Label>
        </td>
        <td colspan="2" 
            style="border-bottom-color: #999999; border-right-color: #999999;">
                    <asp:DropDownList ID="DdlAgenteTecnico" runat="server" CssClass="CampoCadastro" 
                        Width="337px">
                    </asp:DropDownList>
        </td>
        <td>
                    &nbsp;</td>
    </tr>
    <tr>
        <td style="text-align: right" colspan="2">
            <asp:Label ID="LblQuantidade" runat="server" Text="Quantidade:"></asp:Label>
        </td>
        <td style="width: 235px">
            <asp:TextBox ID="TxtQuantidade" runat="server" AutoPostBack="True" 
                style="text-align:right" CssClass="CampoCadastro" Width="65px"></asp:TextBox>
        &nbsp;
            <asp:Label ID="LblLabelRSUnitario" runat="server" Text="R$ Unitário:" 
                Height="17px"></asp:Label>
            <asp:TextBox ID="TxtPrecoUnitario0" runat="server" style="text-align:right" AutoPostBack="true"
                    Width="70px" CssClass="CampoCadastro"></asp:TextBox>
        </td>
        <td style="width: 140px">
            <asp:Label ID="LblLabelTotalMercadoria" runat="server" Text="Total:R$" 
                Height="17px"></asp:Label>
            <asp:Label ID="LblValorMercadoria" runat="server" Font-Bold="True" style="text-align:right"
                Height="17px" Width="50px">0,00</asp:Label>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td style="text-align: right" colspan="2">
            <asp:Label ID="LblLabelIPI" runat="server" Text="IPI:"></asp:Label>
            </td>
        <td>
            <asp:Label ID="LblContrato" runat="server"></asp:Label>
            <asp:Label ID="LblMoedaIPI" runat="server" Text="R$"></asp:Label>
&nbsp;<asp:Label ID="LblValorIPI" runat="server" Text="0,00"></asp:Label>
&nbsp;<asp:Label ID="LblParenteseEsquerdoIPI" runat="server" Text="("></asp:Label>
            <asp:Label ID="LblAliquotaIPI" runat="server" Text="0,0"></asp:Label>
            <asp:Label ID="LblParenteseDireitoIPI" runat="server" Text="%)"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="LblLabelST" runat="server" Text="S.T.:"></asp:Label>
            &nbsp;<asp:Label ID="LblMoedaST" runat="server" Text="R$"></asp:Label>
&nbsp;<asp:Label ID="LblValorST" runat="server" Text="0,00"></asp:Label>
&nbsp;<asp:Label ID="LblBaseICMSST" runat="server" Text="0,00" Visible="False"></asp:Label>
        </td>
        <td>
            <asp:Label ID="LblLabelTotalGeral" runat="server" Text="Total:R$"></asp:Label>
            <asp:Label ID="LblValorTotal" runat="server" Font-Bold="True" style="text-align:right" Width="50px">0,00</asp:Label>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:Label ID="LblValorICMS" runat="server" Text="0,00" Visible="False"></asp:Label>
            <asp:Label ID="LblAliquotaICMS" runat="server" Text="0,0" Visible="False"></asp:Label>
            </td>
        <td colspan="2">
            <asp:Button ID="BtnGravar0" runat="server" CssClass="Botao" Text="Salvar/Novo" 
                ToolTip="Salva este registro e volta à tela anterior." />
        &nbsp;
            <asp:Button ID="BtnGravar" runat="server" CssClass="Botao" Text="Salvar" 
                ToolTip="Salva este registro e volta à tela anterior." />
        &nbsp;
            <asp:Button ID="BtnVoltar" runat="server" Text="Voltar" Visible="False" />
        </td>
        <td>
            &nbsp;</td>
    </tr>
</table>
<%--este é o html para pesquisa de itens--%><%--botões padrão que ficam ocultos, são necessários, não remover--%>
    <div class="popup_Buttons" style="display: none">
        <input id="ButtonEditDone" value="Done" type="button" />
        <input id="ButtonEditCancel" value="Cancel" type="button" />
    </div>
<%--frame onde é mostrado o popup--%>
    <div id="DivEditWindow" style="display: none;" class="popupConfirmation">
        <iframe id="IframeEdit" frameborder="0" width="480" height="350" scrolling="no">
        </iframe>
    </div>
