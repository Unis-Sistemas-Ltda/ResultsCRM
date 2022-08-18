<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUAprovFinancOSCabecalho.ascx.vb" Inherits="ResultsCRM.WUAprovFinancOSCabecalho" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register src="../OutrosControles/TextBoxData.ascx" tagname="TextBoxData" tagprefix="uc1" %>
<%@ Register src="../OutrosControles/TextBoxHora.ascx" tagname="TextBoxHora" tagprefix="uc2" %>

<link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
<link href="../ResultsCRMAjax.css" rel="stylesheet" type="text/css" />

<script type="text/javascript" language="javascript" src="../ResultsCRM.js"></script>

<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    
<table class="TextoCadastro_BGBranco" style="width:100%;">
    <tr>
        <td colspan="3">
            <img alt="Ordem de Serviço" src="../Imagens/OSAtendimento.png" 
                style="width: 420px; height: 18px" /><asp:Label ID="LblCodCanalVenda" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="LblCodIndicador" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="LblCodFormaPagamento" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="LblCodCondPagto" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="LblDataEmissao" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="LblCodNaturOper" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="LblTipoFrete" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="LblCodTransportador" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="LblEmpresa" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="LblEstabelecimento" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="LblCodAtendimento" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="LblAcao" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="LblCodEmitente" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="LblNomeEmitente" runat="server" Visible="False"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="Erro" colspan="3">
            <asp:Label ID="LblErro" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right" colspan="2">
            Nº OS:</td>
        <td>
            <asp:TextBox ID="TxtCodPedidoVenda" runat="server" CssClass="CampoCadastro" 
                MaxLength="9" Width="60px"></asp:TextBox>
        &nbsp;&nbsp;
            <asp:Label ID="Label1" runat="server" Height="16px" Text="Chamado:"></asp:Label>
            <asp:TextBox ID="TxtNrChamado" runat="server" CssClass="CampoCadastro" style="text-align:center"
                Enabled="False" Width="60px"></asp:TextBox>
            <asp:LinkButton ID="BtnAlterarChamado" runat="server" Height="17px" 
                Visible="False">Alterar</asp:LinkButton>
        &nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label7" runat="server" Height="16px" Text="SAG:"></asp:Label>
            <asp:TextBox ID="TxtSag" runat="server" CssClass="CampoCadastro" 
                style="text-align:center" Width="80px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right" colspan="2">
            Status:</td>
        <td>
            <asp:DropDownList ID="DdlStatus" runat="server" CssClass="CampoCadastro" 
                Width="80px">
                <asp:ListItem Selected="True" Value="1">Aberta</asp:ListItem>
                <asp:ListItem Value="2">Encerrada</asp:ListItem>
            </asp:DropDownList>
            &nbsp;&nbsp;<asp:Label ID="Label4" runat="server" Height="16px" Text="Recebimento:"></asp:Label>
            <asp:DropDownList ID="DdlStatusRecebimento" runat="server" 
                CssClass="CampoCadastro" Width="100px">
                <asp:ListItem Selected="True" Value="1">OS Pendente</asp:ListItem>
                <asp:ListItem Value="2">OS Recebida</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="text-align: right" colspan="2">
            Status Aprov. Financ:</td>
        <td>
            <asp:DropDownList ID="DdlStatusAprovFinancOS" runat="server" 
                CssClass="CampoCadastro" Width="80px">
                <asp:ListItem Selected="True" Value="N">Pendente</asp:ListItem>
                <asp:ListItem Value="S">Aprovada</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="text-align: right" colspan="2">
            <asp:Label ID="Label5" runat="server" Height="17px" Text="Cliente:"></asp:Label>
            </td>
        <td>
            <asp:TextBox ID="TxtCliente" runat="server" CssClass="CampoCadastro" 
                Width="50px" MaxLength="6" AutoPostBack="True" Height="18px"></asp:TextBox>
            <asp:ImageButton ID="BtnFiltrarCliente" runat="server" 
                ImageUrl="~/Imagens/search.png" ToolTip="Pesquisar" 
                onclientclick="ShowEditModal('../Pesquisas/WFPClienteCNPJ.aspx?textbox=TxtCliente&amp;varmp=SCodClientePesquisado&amp;varmpc=SCNPJClientePesquisado&amp;varma=SAlterouCodCliente','EditModalPopupClientes','IframeEdit');" 
                Height="15px" Width="16px" />
            &nbsp;&nbsp;
            <asp:Label ID="Label3" runat="server" Height="17px" Text="CNPJ:"></asp:Label>
            <asp:DropDownList ID="DdlCNPJ" runat="server" CssClass="CampoCadastro" 
                Width="255px" AutoPostBack="True"/>
        </td>
    </tr>
    <tr>
        <td style="text-align: right" colspan="2">
            Nome:</td>
        <td>
            <asp:Label ID="LblNomeCliente" runat="server" Font-Bold="True" Width="240px"></asp:Label>
        &nbsp;&nbsp;
            Telefone:<asp:Label ID="LblTelefone" runat="server" Font-Bold="True" 
                Width="145px"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right" colspan="2">
            Ponto Atendimento:</td>
        <td>
            <asp:Label ID="LblPontoAtendimento" runat="server" Font-Bold="True" 
                Width="440px"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right" colspan="2">
            Tipo de Cobrança:</td>
        <td>
            <asp:DropDownList ID="DdlTipoCobrancaOS" runat="server" CssClass="CampoCadastro" 
                Width="250px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="border-width: 1px; border-color: #999999; text-align: right; border-bottom-style: solid;" 
            colspan="2">
            Observação:</td>
        <td style="border-width: 1px; border-color: #999999; border-bottom-style: solid;">
            <asp:TextBox ID="TxtObservacao" runat="server" CssClass="CampoCadastro" 
                Width="250px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="border-width: 1px; border-color: #999999; text-align: center; border-bottom-style: solid; border-right-style: solid;">
            Agendamento</td>
        <td style="border-width: 1px; border-color: #999999; text-align: right; border-bottom-style: solid;">
            Chegada:</td>
        <td style="border-width: 1px; border-color: #999999; border-bottom-style: solid;">
            <asp:TextBox ID="TxtDataChegadaPrevista" runat="server" CssClass="CampoCadastro" 
                MaxLength="10" Width="75px" AutoPostBack="True"></asp:TextBox>
            <uc2:TextBoxHora ID="TxtHoraChegadaPrevista" runat="server" Width="50" />
            &nbsp;
            <asp:Label ID="Label6" runat="server" Height="17px" Text="Encerramento:"></asp:Label>
            <asp:TextBox ID="TxtDataEntrega" runat="server" CssClass="CampoCadastro" 
                MaxLength="10" Width="75px"></asp:TextBox>
            <uc2:TextBoxHora ID="TxtHoraEntrega" runat="server" Width="50" />
        </td>
    </tr>
    <tr>
        <td style="border-width: 1px; border-color: #999999; text-align: center; border-bottom-style: solid; border-right-style: solid;">
            Execução</td>
        <td style="border-width: 1px; border-color: #999999; text-align: right; border-bottom-style: solid;">
            Chegada:</td>
        <td style="border-width: 1px; border-color: #999999; border-bottom-style: solid;">
            <asp:TextBox ID="TxtDataChegada" runat="server" CssClass="CampoCadastro" 
                MaxLength="10" Width="75px" AutoPostBack="True"></asp:TextBox>
            <uc2:TextBoxHora ID="TxtHoraChegada" runat="server" Width="50" />
        &nbsp;
            <asp:Label ID="Label2" runat="server" Height="17px" Text="Encerramento:"></asp:Label>
            <asp:TextBox ID="TxtDataEncerramento" runat="server" CssClass="CampoCadastro" 
                MaxLength="10" Width="75px" AutoPostBack="True"></asp:TextBox>
            <uc2:TextBoxHora ID="TxtHoraEncerramento" runat="server" Width="50" />
        </td>
    </tr>
    <tr>
        <td style="text-align: right" colspan="2">
            &nbsp;</td>
        <td>
            <asp:CheckBox ID="CbxImprimirMatricial" runat="server" 
                Text="Imprimir OS Matricial" />
        </td>
    </tr>
    <tr>
        <td style="text-align: right" colspan="2">
            &nbsp;</td>
        <td>
            <asp:Button ID="BtnGravar" runat="server" CssClass="Botao" 
                Text="Incluir Ordem de Serviço" />
        &nbsp;
            <asp:Button ID="BtnVoltar" runat="server" CssClass="Botao" Text="Voltar" />
        &nbsp;
            <asp:Button ID="BtnImprimirOS" runat="server" CssClass="Botao" 
                Text="Imprimir OS" Visible="False" />
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
        <iframe id="IframeEdit" frameborder="0" width="370" height="410" scrolling="no">
        </iframe>
    </div>