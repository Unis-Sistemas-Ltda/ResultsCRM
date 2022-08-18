<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCSolicitacaoMaterial.ascx.vb" Inherits="ResultsCRM.WUCSolicitacaoMaterial" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register src="../OutrosControles/TextBoxNumerico.ascx" tagname="TextBoxNumerico" tagprefix="uc1" %>

<%@ Register src="../OutrosControles/TextBoxData.ascx" tagname="TextBoxData" tagprefix="uc2" %>

<%@ Register src="../OutrosControles/TextBoxHora.ascx" tagname="TextBoxHora" tagprefix="uc3" %>

<link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
<link href="../ResultsCRMAjax.css" rel="stylesheet" type="text/css" />

<script type="text/javascript" language="javascript" src="../ResultsCRM.js"></script>

<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

<table class="TextoCadastro_BGBranco" style="width:100%;">
    <tr>
        <td colspan="2" style="font-weight: bold">
            MATERIAIS SOLICITADOS</td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:Label ID="LblErro" runat="server" CssClass="Erro"></asp:Label>
        </td>
    </tr> 
    <tr>
        <td style="text-align: right">
            Cód. Solicitação:</td>
        <td>
            <asp:Label ID="LblCodSolicitacao" runat="server" Font-Bold="True" Width="200px"></asp:Label>
            <asp:Label ID="LblAcao" runat="server" BackColor="#ECFFEC" Font-Bold="True" style="text-align:center"
                Width="138px" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right; " 
            class="CampoCadastro">
            Estabelecimento:</td>
        <td>
            <asp:DropDownList ID="DdlEstabelecimento" runat="server" CssClass="CampoCadastro" 
                Width="337px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="text-align: right; " 
            class="CampoCadastro">
            Solicitante:</td>
        <td>
            <asp:DropDownList ID="DdlSolicitante" runat="server" CssClass="CampoCadastro" 
                Width="337px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="text-align: right; " 
            class="CampoCadastro">
            Agente Técnico:</td>
        <td>
            <asp:DropDownList ID="DdlAgenteTecnico" runat="server" CssClass="CampoCadastro" 
                Width="337px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="text-align: right; ">
            Item:</td>
        <td class="CelulaCampoCadastro">
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
        <td style="text-align: right">
            Quantidade:</td>
        <td>
            <asp:TextBox ID="TxtQuantidade" runat="server" 
                style="text-align:right" CssClass="CampoCadastro" Width="70px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Data Solicitação:</td>
        <td>
            <uc2:TextBoxData ID="TxtDataSolicitacao" runat="server" />
            <asp:Label ID="Label9" runat="server" Height="16px" Text="&nbsp;Hora:"></asp:Label>
            <uc3:TextBoxHora ID="TxtHoraSolicitacao" runat="server" MostrarSegundos="False" 
                Width="60" />
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            <asp:Label ID="Label7" runat="server" Height="16px" Text="&nbsp;Data Entrega:"></asp:Label>
            </td>
        <td>
            <uc2:TextBoxData ID="TxtDataEntrega" runat="server" />
            <asp:Label ID="Label10" runat="server" Height="16px" Text="&nbsp;Hora:"></asp:Label>
            <uc3:TextBoxHora ID="TxtHoraEntrega" runat="server" MostrarSegundos="False" 
                Width="60" />
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Prioridade:</td>
        <td>
            <asp:DropDownList ID="DdlPrioridade" runat="server" CssClass="CampoCadastro" 
                Width="70px">
                <asp:ListItem Value="1">Normal</asp:ListItem>
                <asp:ListItem Value="2">Urgente</asp:ListItem>
            </asp:DropDownList>
            <asp:Label ID="Label8" runat="server" Height="16px" 
                Text="&nbsp;Forma de Entrega:"></asp:Label>
            <asp:DropDownList ID="DdlFormaEntrega" runat="server" CssClass="CampoCadastro" 
                Width="110px">
                <asp:ListItem Value="1">Retirada</asp:ListItem>
                <asp:ListItem Value="2">Transportadora</asp:ListItem>
                <asp:ListItem Value="3">SEDEX</asp:ListItem>
                <asp:ListItem Value="4">SEDEX 10</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            <asp:Button ID="BtnGravar" runat="server" CssClass="Botao" Text="Salvar" 
                ToolTip="Salva este registro e volta à tela anterior." />
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
        <iframe id="IframeEdit" frameborder="0" width="370" height="350" scrolling="no">
        </iframe>
    </div>
