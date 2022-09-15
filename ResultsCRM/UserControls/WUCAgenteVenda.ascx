<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCAgenteVenda.ascx.vb" Inherits="ResultsCRM.WUCAgenteVenda" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
<link href="../ResultsCRMAjax.css" rel="stylesheet" type="text/css" />

<script type="text/javascript" language="javascript" src="../ResultsCRM.js"></script>

<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

<div class="TituloCadastro">Detalhe do Cadastro Agente de Vendas</div>
<table class="TextoCadastro" style="width:100%;">
   <tr>
        <td class="Erro" colspan="3">
            <asp:Label ID="LblErro" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right; vertical-align: top; line-height: 21px">
            Usuário:<br />
            Tipo:</td>
        <td class="CelulaCampoCadastro" style="vertical-align: top">
            <asp:TextBox ID="TxtCodUsuario" runat="server" CssClass="CampoCadastro" AutoPostBack="True"
                MaxLength="6" Width="90px"></asp:TextBox>
            <asp:ImageButton ID="BtnPesquisar" runat="server" ImageUrl="~/Imagens/search.png" 
                onclientclick="ShowEditModal('../Pesquisas/WFPUsuario.aspx?textBox=TxtCodUsuario','EditModalPopupUsuarios','IframeEdit');" 
                ToolTip="Pesquisar" />
            <asp:Label ID="LblNomeUsuario" runat="server" Height="17px"></asp:Label>
            <br />
            <asp:DropDownList ID="DdlTipoAgente" runat="server" CssClass="CampoCadastro" 
                Width="300px">
            </asp:DropDownList>
        </td>
        <td class="CelulaCampoCadastro" rowspan="2" style="vertical-align: top">
            Funis:<asp:CheckBoxList ID="CbxFunis" runat="server">
            </asp:CheckBoxList>
        </td>
    </tr>
    <tr>
        <td style="text-align: right; vertical-align: top; line-height: 21px">
            Funil de Vendas Padrão:
        </td>
        <td>
             <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlFunil" runat="server" AutoPostBack="True" 
                                ClientIDMode="Static" CssClass="CampoCadastro"  Width="300px">
                            </asp:DropDownList>
                            <br />                           
                        </ContentTemplate>
                    </asp:UpdatePanel>
            </td>
    </tr>
    <tr>
        <td colspan="2" style="text-align: center">
            <asp:Button ID="BtnGravar" runat="server" CssClass="Botao" Text="Gravar" />
        &nbsp;
            <asp:Button ID="BtnVoltar" runat="server" CssClass="Botao" Text="Voltar" />
        </td>
        <td style="text-align: center">
            &nbsp;</td>
    </tr>
</table>

<%--este é o html para pesquisa de usuários--%>
    <cc1:ModalPopupExtender ID="ModalPopupExtender2" BackgroundCssClass="ModalPopupBG"
        runat="server" CancelControlID="ButtonEditCancel" OkControlID="ButtonEditDone" 
        TargetControlID="BtnPesquisar" PopupControlID="DivEditWindow" 
        OnCancelScript="EditCancelScript('IframeEdit');" OnOkScript="EditOkayScript('IframeEdit');"
        BehaviorID="EditModalPopupUsuarios">
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