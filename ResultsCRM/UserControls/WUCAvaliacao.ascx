<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCAvaliacao.ascx.vb" Inherits="ResultsCRM.WUCAvaliacao" %>

<%@ Register src="../OutrosControles/TextBoxData.ascx" tagname="TextBoxData" tagprefix="uc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
<link href="../ResultsCRMAjax.css" rel="stylesheet" type="text/css" />

<script type="text/javascript" language="javascript" src="../ResultsCRM.js"></script>

<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<table class="TextoCadastro" style="width:100%;">
    <tr>
        <td class="Erro" colspan="2">
            <asp:Label ID="LblErro" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Código:</td>
        <td class="CelulaCampoCadastro">
            <asp:Label ID="LblCodAvaliacao" runat="server" Font-Bold="True"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Data:</td>
        <td class="CelulaCampoCadastro">
            <uc1:TextBoxData ID="TxtDataAvaliacao" runat="server" />
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Tipo Avaliação:</td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="DdlTipoAvaliacao" runat="server" CssClass="CampoCadastro" 
                Width="295px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Cliente:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtCliente" runat="server" CssClass="CampoCadastro" style="text-align:center"
                Width="43px" MaxLength="6" AutoPostBack="True"></asp:TextBox>
            <asp:ImageButton ID="BtnFiltrarCliente" runat="server" 
                ImageUrl="~/Imagens/search.png" ToolTip="Pesquisar" 
                onclientclick="ShowEditModal('../Pesquisas/WFPCliente.aspx?textbox=TxtCliente&amp;varmp=SCodClientePesquisado&amp;varma=SAlterouCodCliente','EditModalPopupClientes','IframeEdit');" 
                Height="16px" Width="16px" />
                <cc1:ModalPopupExtender ID="ModalPopupExtender2" BackgroundCssClass="ModalPopupBG"
        runat="server" CancelControlID="ButtonEditCancel" OkControlID="ButtonEditDone" 
        TargetControlID="BtnFiltrarCliente" PopupControlID="DivEditWindow" 
        OnCancelScript="EditCancelScript('IframeEdit');" OnOkScript="EditOkayScript('IframeEdit');"
        BehaviorID="EditModalPopupClientes">
    </cc1:ModalPopupExtender>
            &nbsp; <asp:Label ID="Label3" runat="server" Text="CNPJ:" 
                Height="17px"></asp:Label>
            <asp:DropDownList ID="DdlCNPJ" runat="server" CssClass="CampoCadastro" 
                Width="170px" AutoPostBack="True"/>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Nome Cliente:</td>
        <td class="CelulaCampoCadastro">
            <asp:Label ID="LblNomeCliente" runat="server" Font-Bold="False"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Avaliador:</td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="DdlAvaliador" runat="server" CssClass="CampoCadastro" 
                Width="295px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td colspan="2" style="text-align: center">
            <asp:Button ID="BtnGravar" runat="server" CssClass="Botao" Text="Gravar" />
        </td>
    </tr>
</table>
<%--este é o html para pesquisa de emitentes--%><%--este é o html para incluir emitente via negociação--%><%--este é o html para alterar cadastro de emitente via negociação--%><%--este é o html para funcionar o botão de incluir contatos--%><%--este é o html para funcionar o botão de incluir contatos--%><%--botões padrão que ficam ocultos, são necessários, não remover--%>
    <div class="popup_Buttons" style="display: none">
        <input id="ButtonEditDone" value="Done" type="button" />
        <input id="ButtonEditCancel" value="Cancel" type="button" />
    </div>
    <%--frame onde é mostrado o popup--%>
    <div id="DivEditWindow" style="display: none;" class="popupConfirmation">
        <iframe id="IframeEdit" frameborder="0" width="420" height="435" scrolling="no">
        </iframe>
    </div>
