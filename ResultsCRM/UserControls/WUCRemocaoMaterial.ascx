<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCRemocaoMaterial.ascx.vb" Inherits="ResultsCRM.WUCRemocaoMaterial" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register src="../OutrosControles/TextBoxNumerico.ascx" tagname="TextBoxNumerico" tagprefix="uc1" %>

<%@ Register src="../OutrosControles/TextBoxData.ascx" tagname="TextBoxData" tagprefix="uc2" %>

<link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
<link href="../ResultsCRMAjax.css" rel="stylesheet" type="text/css" />

<script type="text/javascript" language="javascript" src="../ResultsCRM.js"></script>

<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

<table class="TextoCadastro_BGBranco" style="width:100%;">
    <tr>
        <td colspan="2" style="font-weight: bold">
            REMOÇÃO DE MATERIAL</td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:Label ID="LblErro" runat="server" CssClass="Erro"></asp:Label>
        </td>
    </tr> 
    <tr>
        <td style="text-align: right; " 
            class="CampoCadastro">
            <asp:Label ID="Lbl_1" runat="server" Text="Item:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TxtCodItem" runat="server" CssClass="CampoCadastro" 
                Width="70px" AutoPostBack="True"></asp:TextBox>
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
        <td style="text-align: right; " 
            class="CampoCadastro">
            <asp:Label ID="Lbl_2" runat="server" Text="Lote:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TxtLote" runat="server" CssClass="CampoCadastro" Width="70px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right; " 
            class="CampoCadastro">
            <asp:Label ID="Lbl_3" runat="server" Text="Quantidade:"></asp:Label>
        </td>
        <td>
            <asp:TextBox 
                ID="TxtQuantidade" runat="server" 
                style="text-align:right" CssClass="CampoCadastro" Width="70px" 
                Height="16px"></asp:TextBox>
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
        <td>
            &nbsp;</td>
        <td>
            <asp:Button ID="BtnGravar" runat="server" CssClass="Botao" 
                Text="Incluir" />
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
