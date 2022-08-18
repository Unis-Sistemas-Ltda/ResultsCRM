<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFRelNegociacaoProduto.aspx.vb" Inherits="ResultsCRM.WFRelNegociacaoProduto" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register src="../OutrosControles/TextBoxData.ascx" tagname="TextBoxData" tagprefix="uc1" %>

<%@ Register assembly="WebDataWindow" namespace="Sybase.DataWindow.Web" tagprefix="dw" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
    <link href="../ResultsCRMAjax.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="../ResultsCRM.js"></script>
    </head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True"></asp:ScriptManager>
    <div class="TituloRelatorio">Relatório de Negociação por Item</div>
    <table style="width:100%;" class="TextoCadastro">
        <tr>
            <td colspan="2" style="text-align: left">
                <asp:Label ID="lblErro" runat="server" CssClass="Erro"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Período:"></asp:Label>
            </td>
            <td class="CelulaCampoCadastro">
                <uc1:TextBoxData ID="TxtData1" runat="server" />
            &nbsp;<uc1:TextBoxData ID="TxtData2" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Agente Vendas:"></asp:Label>
            </td>
            <td style="text-align: left">
                <asp:DropDownList ID="ddlAgenteVenda" runat="server" CssClass="CampoCadastro" 
                    Width="300px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Canal de Vendas:"></asp:Label>
            </td>
            <td style="text-align: left">
                <asp:DropDownList ID="ddlCanalVenda" runat="server" CssClass="CampoCadastro" 
                    Width="300px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                Item:</td>
            <td style="text-align: left">
                <asp:TextBox ID="TxtCodItem" runat="server" AutoPostBack="True" 
                    CssClass="CampoCadastro"></asp:TextBox>
                <asp:ImageButton ID="BtnFiltrarItem" runat="server" 
                    ImageUrl="~/Imagens/search.png" 
                    
                    onclientclick="ShowEditModal('../Pesquisas/WFPItem.aspx?textbox=TxtCodItem','EditModalPopupItens','IframeEdit');" 
                    TabIndex="2"/>
                <asp:Label ID="LblDescricaoItem" runat="server" Height="16px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="text-align: left">
                <asp:Button ID="BtnOk" runat="server" CssClass="Botao" Text="Visualizar" 
                    TabIndex="1" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;</td>
        </tr>
        </table>
    <%--este é o html para pesquisa de itens--%>
    <cc1:ModalPopupExtender ID="ModalPopupExtender2" BackgroundCssClass="ModalPopupBG"
        runat="server" CancelControlID="ButtonEditCancel" OkControlID="ButtonEditDone" 
        TargetControlID="BtnFiltrarItem" PopupControlID="DivEditWindow" 
        OnCancelScript="EditCancelScript('IframeEdit');" OnOkScript="EditOkayScript('IframeEdit');"
        BehaviorID="EditModalPopupItens">
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
    </form>
</body>
</html>
