<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCAprovFinancOSPedidoVendaItem.ascx.vb" Inherits="ResultsCRM.WUCAprovFinancOSPedidoVendaItem" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register src="../OutrosControles/TextBoxNumerico.ascx" tagname="TextBoxNumerico" tagprefix="uc1" %>

<link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
<link href="../ResultsCRMAjax.css" rel="stylesheet" type="text/css" />

<script type="text/javascript" language="javascript" src="../ResultsCRM.js"></script>

<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

<table class="TextoCadastro_BGBranco" style="width:100%;">
    <tr>
        <td colspan="4">
            <img alt="Item da Ordem de Serviço" src="../Imagens/OSAtendimento.png" 
                style="width: 420px; height: 18px" /></td>
    </tr>
    <tr>
        <td colspan="4">
            <asp:Label ID="LblErro" runat="server" CssClass="Erro"></asp:Label>
        </td>
    </tr> 
    <tr>
        <td style="text-align: right" colspan="2">
            Seq. Item:</td>
        <td colspan="2">
            <asp:Label ID="LblSeqItem" runat="server" Font-Bold="True" Width="200px"></asp:Label>
            <asp:Label ID="LblAcao" runat="server" BackColor="#ECFFEC" Font-Bold="True" style="text-align:center"
                Width="138px" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right; " 
            class="CampoCadastro" colspan="2">
            Equipamento:</td>
        <td 
            colspan="2">
            <asp:DropDownList ID="DdlEquipamento" runat="server" CssClass="CampoCadastro" 
                Width="313px" AutoPostBack="True">
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
                
                
                
                onclientclick="ShowEditModal('../Forms/WFEquipamento.aspx?aid=A','EditModalPopupClientes','IframeEdit');" />
     <cc1:ModalPopupExtender ID="ModalPopupExtender4" BackgroundCssClass="ModalPopupBG"
        runat="server" CancelControlID="ButtonEditCancel" OkControlID="ButtonEditDone" 
        TargetControlID="BtnAlterarEquipamento" PopupControlID="DivEditWindow" 
        OnCancelScript="EditCancelScript('IframeEdit');" OnOkScript="EditOkayScript('IframeEdit');"
        BehaviorID="EditModalPopupAlterarContato">
    </cc1:ModalPopupExtender>
            </span>
        </td>
    </tr>
    <tr>
        <td style="text-align: right; " 
            class="CampoCadastro" colspan="2">
            Componente:</td>
        <td 
            colspan="2">
            <asp:DropDownList ID="DdlComponente" runat="server" CssClass="CampoCadastro" 
                Width="337px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="text-align: right; border-right-width: 1px; text-align: right; border-right-style: solid; border-right-color: #808080; border-right-width: 1px;" 
            rowspan="2">
            Serviço Realizado</td>
        <td style="border-width: 1px; vertical-align: middle; text-align: right; border-top-style: solid; border-top-color: #999999;">
            Item:</td>
        <td class="CelulaCampoCadastro" 
            
            
            style="border-width: 1px; vertical-align: top; border-top-style: solid; border-top-color: #999999; border-right-style: solid; border-right-color: #999999;" 
            colspan="2">
            <asp:TextBox ID="TxtCodItem" runat="server" CssClass="CampoCadastro" 
                Width="90px" AutoPostBack="True"></asp:TextBox>
                        <asp:ImageButton ID="BtnFiltrarItem" runat="server" 
                ImageUrl="~/Imagens/search.png" ToolTip="Pesquisar" 
                onclientclick="ShowEditModal('../Pesquisas/WFPItem.aspx?textbox=TxtCodItem','EditModalPopupClientes','IframeEdit');" />
    <cc1:ModalPopupExtender ID="ModalPopupExtender1" BackgroundCssClass="ModalPopupBG"
        runat="server" CancelControlID="ButtonEditCancel" OkControlID="ButtonEditDone" 
        TargetControlID="BtnFiltrarItem" PopupControlID="DivEditWindow" 
        OnCancelScript="EditCancelScript('IframeEdit');" OnOkScript="EditOkayScript('IframeEdit');"
        BehaviorID="EditModalPopupClientes">
    </cc1:ModalPopupExtender>
            <asp:Label ID="LblDescricaoItem" runat="server" Font-Bold="True" 
                Height="17px"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="vertical-align: middle; text-align: right; border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #999999;">
            <asp:Label ID="Label1" runat="server" Text="Descrição:"></asp:Label>
        </td>
        <td class="CelulaCampoCadastro" 
            
            
            style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #999999; border-right-style: solid; border-right-width: 1px; border-right-color: #999999;" 
            colspan="2">
            <asp:TextBox ID="TxtNarrativa" runat="server" CssClass="CampoCadastro" 
                Width="337px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right" colspan="2">
            Quantidade:</td>
        <td style="width: 235px">
            <asp:TextBox ID="TxtQuantidade" runat="server" AutoPostBack="True" 
                style="text-align:right" CssClass="CampoCadastro" Width="70px"></asp:TextBox>
        &nbsp;
            <asp:Label ID="Label4" runat="server" Text="R$ Unitário:" Height="17px"></asp:Label>
            <uc1:TextBoxNumerico ID="TxtPrecoUnitario" runat="server" Width="75" 
                QtdCasas="2" AutoPostBack="True" />
        </td>
        <td>
            <asp:Label ID="Label5" runat="server" Text="Total:R$" Height="17px"></asp:Label>
            <asp:Label ID="LblValorMercadoria" runat="server" Font-Bold="True" style="text-align:right"
                Height="17px" Width="50px">0,00</asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right" colspan="2">
            <asp:Label ID="Label2" runat="server" Text="IPI:"></asp:Label>
            </td>
        <td>
            R$
            <asp:Label ID="LblValorIPI" runat="server" Text="0,00"></asp:Label>
&nbsp;(<asp:Label ID="LblAliquotaIPI" runat="server" Text="0,0"></asp:Label>
            %)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label3" runat="server" Text="S.T.:"></asp:Label>
            &nbsp;R$
            <asp:Label ID="LblValorST" runat="server" Text="0,00"></asp:Label>
&nbsp;<asp:Label ID="LblBaseICMSST" runat="server" Text="0,00" Visible="False"></asp:Label>
        </td>
        <td>
            <asp:Label ID="Label6" runat="server" Text="Total:R$"></asp:Label>
            <asp:Label ID="LblValorTotal" runat="server" Font-Bold="True" style="text-align:right" Width="50px">0,00</asp:Label>
        </td>
    </tr>
    <tr>
        <td colspan="2" style="text-align: right">
            Tipo de Cobrança:</td>
        <td colspan="2">
            <asp:DropDownList ID="DdlTipoCobrancaOS" runat="server" CssClass="CampoCadastro" 
                Width="250px" AutoPostBack="True">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:Label ID="LblValorICMS" runat="server" Text="0,00" Visible="False"></asp:Label>
            <asp:Label ID="LblAliquotaICMS" runat="server" Text="0,0" Visible="False"></asp:Label>
            </td>
        <td colspan="2">
            <asp:Button ID="BtnGravar" runat="server" CssClass="Botao" Text="Salvar" 
                ToolTip="Salva este registro e volta à tela anterior." />
        </td>
    </tr>
</table>
<%--este é o html para pesquisa de itens--%>
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
