<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCNegociacaoOutrasInformacoes.ascx.vb" Inherits="ResultsCRM.WUCNegociacaoOutrasInformacoes" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<%@ Register src="../OutrosControles/TextBoxData.ascx" tagname="TextBoxData" tagprefix="uc1" %>

<link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
<link href="../ResultsCRMAjax.css" rel="stylesheet" type="text/css" />

<script type="text/javascript" language="javascript" src="../ResultsCRM.js"></script>

<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

<table class="TextoCadastro_BGBranco" 
    style="width:100%; border-collapse: collapse;">
    <tr>
        <td class="SubTituloMovimento" colspan="2">
            Outras Informações<br />
        </td>
    </tr>
    <tr>
        <td class="Erro" colspan="2">
            <asp:Label ID="LblErro" runat="server" CssClass="Erro"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right; width: 160px;">
            Cód.
            Transportadora:</td>
        <td style="text-align: left">
            <asp:TextBox ID="TxtCodTransportadora" runat="server" AutoPostBack="True" 
                CssClass="CampoCadastro" MaxLength="6" Width="50px"></asp:TextBox>
            <asp:ImageButton ID="BtnFiltrarCliente" runat="server" 
                ImageUrl="~/Imagens/search.png" ToolTip="Pesquisar" 
                
                onclientclick="ShowEditModal('../Pesquisas/WFPTransportadora.aspx?textbox=TxtCodTransportadora','EditModalPopupClientes','IframeEdit');" />
                </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Nome da Transportadora:</td>
        <td style="text-align: left">
                <asp:Label ID="LblNomeTransportadora" runat="server" Font-Bold="False"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            <asp:Label ID="LblAuxLabel1" runat="server"></asp:Label>
        </td>
        <td style="text-align: left">
            <uc1:TextBoxData ID="TxtAux1" runat="server" Width="90" />
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            <asp:Label ID="LblAux2Label" runat="server"></asp:Label>
        </td>
        <td style="text-align: left">
            <asp:TextBox ID="TxtAux2" runat="server" CssClass="CampoCadastro" Width="100px"></asp:TextBox>
        </td>
    </tr>
     <tr>
        <td style="text-align: right; vertical-align: top;">
            <asp:Label ID="Label2" runat="server" Text="Definições da Formulação:"></asp:Label>
        </td>
        <td style="text-align: left">
            <asp:DropDownList ID="DdlDefinicoesFormulacao" runat="server"
                CssClass="CampoCadastro" Width="405
                px" Height="16px">
                <asp:ListItem Value="0">-- Selecione --</asp:ListItem>
                <asp:ListItem Value="Fornecida Pela Terceirizadora">Fornecida Pela Terceirizadora</asp:ListItem>
                <asp:ListItem Value="Fornecida Pelo Cliente">Fornecida Pelo Cliente</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
     <tr>
        <td style="text-align: right; vertical-align: top;">
            <asp:Label ID="Label3" runat="server" Text="Definições da Embalagem:"></asp:Label>
        </td>
        <td style="text-align: left">
            <asp:DropDownList ID="DdlDefinicoesEmbalagem" runat="server"
                CssClass="CampoCadastro" Width="405
                px" Height="16px">
                <asp:ListItem Value="0">-- Selecione --</asp:ListItem>
                <asp:ListItem Value="Fornecida Pela Terceirizadora">Fornecida Pela Terceirizadora</asp:ListItem>
                <asp:ListItem Value="Fornecida Pelo Cliente">Fornecida Pelo Cliente</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
     <tr>
        <td style="text-align: right; vertical-align: top;">
            <asp:Label ID="Label4" runat="server" Text="Definições do Rótulos:"></asp:Label>
        </td>
        <td style="text-align: left">
            <asp:DropDownList ID="DdlDefinicoesRotulo" runat="server"
                CssClass="CampoCadastro" Width="405
                px" Height="16px">
                <asp:ListItem Value="0">-- Selecione --</asp:ListItem>
                <asp:ListItem Value="Fornecida Pela Terceirizadora">Fornecida Pela Terceirizadora</asp:ListItem>
                <asp:ListItem Value="Fornecida Pelo Cliente">Fornecida Pelo Cliente</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
     <tr>
        <td style="text-align: right; vertical-align: top;">
            <asp:Label ID="Label5" runat="server" Text="Definições do Prazo Entrega:"></asp:Label>
        </td>
        <td style="text-align: left">
            <asp:DropDownList ID="DdlPrazoEntrega" runat="server"
                CssClass="CampoCadastro" Width="405
                px" Height="16px">
                <asp:ListItem Value="0">-- Selecione --</asp:ListItem>
                <asp:ListItem Value="30 dias úteis (a partir da entrega de embalagens e rótulos)">30 dias úteis (a partir da entrega de embalagens e rótulos)</asp:ListItem>
                <asp:ListItem Value="40 dias úteis (a partir da entrega de embalagens e rótulos)">40 dias úteis (a partir da entrega de embalagens e rótulos)</asp:ListItem>
                <asp:ListItem Value="50 dias úteis (a partir da entrega de embalagens e rótulos)">50 dias úteis (a partir da entrega de embalagens e rótulos)</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
     <tr>
        <td style="text-align: right; vertical-align: top;">
            <asp:Label ID="Label6" runat="server" Text="Detalhes Pagamento:"></asp:Label>
        </td>
        <td style="text-align: left">
            <asp:TextBox ID="TxtDetalhesPagamento" runat="server" CssClass="CampoCadastro" Height="40px" 
                TextMode="MultiLine" Width="400px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            <asp:Label ID="LblAux3Label" runat="server" Height="16px"></asp:Label>
        </td>
        <td style="text-align: left">
            <asp:DropDownList ID="DdlAux3" runat="server" CssClass="CampoCadastro" 
                Width="60px">
                <asp:ListItem Selected="True">
                </asp:ListItem>
                <asp:ListItem Value="S">Sim</asp:ListItem>
                <asp:ListItem Value="N">Não</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="text-align: right; vertical-align: top;">
            <asp:Label ID="Label1" runat="server" Text="Observação:"></asp:Label>
        </td>
        <td style="text-align: left">
            <asp:TextBox ID="TxtObservacao" runat="server" Height="70px" 
                TextMode="MultiLine" Width="400px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right; vertical-align: top;">
            &nbsp;</td>
        <td style="text-align: left">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="border-width: 1px; border-color: #CCCCCC; text-align: right; vertical-align: top; border-top-style: solid;">
            <b>Contrato</b></td>
        <td style="border-width: 1px; border-color: #CCCCCC; text-align: left; vertical-align: top; border-top-style: solid;">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="text-align: right; vertical-align: top;">
            Data de Início:</td>
        <td style="text-align: left">
            <uc1:TextBoxData ID="TxtDataEmissaoContrato" runat="server" Width="90" />
        </td>
    </tr>
    <tr>
        <td style="text-align: right; vertical-align: top;">
            Data de Encerramento:</td>
        <td style="text-align: left">
            <uc1:TextBoxData ID="TxtDataVencimentoContrato" runat="server" Width="90" />
        </td>
    </tr>
    <tr>
        <td style="text-align: right; vertical-align: top;">
            Dia Vencimento (cobrança):</td>
        <td style="text-align: left">
            <asp:TextBox ID="TxtDiaVencimentoContrato" runat="server" MaxLength="2" 
                TextMode="Number" Width="40px" CssClass="CampoCadastro"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="border-color: #CCCCCC; border-width: 1px; text-align: right; vertical-align: top; olor: #CCCCCC; border-top-style: solid;">
            &nbsp;</td>
        <td style="text-align: left; border-width: 1px; border-color: #CCCCCC; text-align: right; vertical-align: top; border-top-style: solid;">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="text-align: right; vertical-align: top;">
            &nbsp;</td>
        <td style="text-align: left">
            <asp:Button ID="BtnGravar" runat="server" Text="Salvar" CssClass="Botao" 
                Height="23px" />
        </td>
    </tr>
    </table>
<%--este é o html para pesquisa de emitentes--%>
    <cc1:ModalPopupExtender ID="ModalPopupExtender1" BackgroundCssClass="ModalPopupBG"
        runat="server" CancelControlID="ButtonEditCancel" OkControlID="ButtonEditDone" 
        TargetControlID="BtnFiltrarCliente" PopupControlID="DivEditWindow" 
        OnCancelScript="EditCancelScript('IframeEdit');" OnOkScript="EditOkayScript('IframeEdit');"
        BehaviorID="EditModalPopupClientes">
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