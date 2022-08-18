<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFListagemChamadosFiltro.aspx.vb"
    Inherits="ResultsCRM.WFListagemChamadosFiltro" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register src="../OutrosControles/TextBoxData.ascx" tagname="TextBoxData" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
    <link href="../ResultsCRMAjax.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="../ResultsCRM.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True"></asp:ScriptManager>
    <div class="TituloRelatorio">Listagem de Chamados</div>
    <table style="width:100%;" class="TextoCadastro">
        <tr>
            <td colspan="2" style="text-align: left">
                <asp:Label ID="lblErro" runat="server" CssClass="Erro"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                Abertura:</td>
            <td class="CelulaCampoCadastro">
                <uc1:TextBoxData ID="TxtDataAbertura1" runat="server" />
                <asp:Label ID="Label1" runat="server" Height="18px" Text="a:"></asp:Label>
            &nbsp;<uc1:TextBoxData ID="TxtDataAbertura2" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                Encerramento:</td>
            <td class="CelulaCampoCadastro">
                <uc1:TextBoxData ID="TxtDataEncerramento1" runat="server" />
                <asp:Label ID="Label2" runat="server" Height="18px" Text="a:"></asp:Label>
            &nbsp;<uc1:TextBoxData ID="TxtDataEncerramento2" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                Tipo de Chamado:</td>
            <td class="CelulaCampoCadastro">
                <asp:DropDownList ID="DdlTipoChamado" runat="server" CssClass="CampoCadastro" 
                    Width="300px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                Tipo de Cobrança:</td>
            <td class="CelulaCampoCadastro">
                <asp:DropDownList ID="DdlTipoCobranca" runat="server" CssClass="CampoCadastro" 
                    Width="300px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                Cliente:</td>
            <td style="text-align: left">
            <asp:TextBox ID="TxtCliente" runat="server" CssClass="CampoCadastro" style="text-align:center"
                Width="50px" MaxLength="6" AutoPostBack="True" Height="18px"></asp:TextBox>
            &nbsp;<asp:ImageButton ID="BtnFiltrarCliente" runat="server" 
                ImageUrl="~/Imagens/search.png" ToolTip="Pesquisar" 
                onclientclick="ShowEditModal('../Pesquisas/WFPCliente.aspx?textbox=TxtCliente&amp;varmp=SCodClientePesquisado&amp;varma=SAlterouCodCliente','EditModalPopupClientes','IframeEdit');" 
                Height="16px" Width="16px" />
    <cc1:ModalPopupExtender ID="ModalPopupExtender2" BackgroundCssClass="ModalPopupBG"
        runat="server" CancelControlID="ButtonEditCancel" OkControlID="ButtonEditDone" 
        TargetControlID="BtnFiltrarCliente" PopupControlID="DivEditWindow" 
        OnCancelScript="EditCancelScript('IframeEdit');" OnOkScript="EditOkayScript('IframeEdit');"
        BehaviorID="EditModalPopupClientes">
    </cc1:ModalPopupExtender>
            <asp:Label ID="LblNomeCliente" runat="server" Font-Bold="False" Height="18px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                Equipamento:</td>
            <td style="text-align: left">
                <asp:DropDownList ID="DdlEquipamento" runat="server" CssClass="CampoCadastro" 
                    Width="300px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                Modelo:</td>
            <td style="text-align: left">
                <asp:DropDownList ID="DdlModelo" runat="server" AutoPostBack="True" 
                    CssClass="CampoCadastro" Width="300px">
                    <asp:ListItem Value="1">Resumido</asp:ListItem>
                    <asp:ListItem Value="2">Detalhado</asp:ListItem>
                </asp:DropDownList>
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
        </table>
    <%--este é o html para pesquisa de itens--%>    <%--botões padrão que ficam ocultos, são necessários, não remover--%>
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
