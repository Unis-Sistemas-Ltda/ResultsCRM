<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCFunilVenda.ascx.vb" Inherits="ResultsCRM.WUCFunilVenda" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
<link href="../ResultsCRMAjax.css" rel="stylesheet" type="text/css" />

<script type="text/javascript" language="javascript" src="../ResultsCRM.js"></script>

<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

<div class="TituloCadastro">Funil de Vendas</div>
<table style="width:100%;" class="TextoCadastro">
    <tr>
        <td class="Erro" colspan="2">
            <asp:Label ID="LblErro" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            Código:</td>
        <td class="CelulaCampoCadastro">
            <asp:Label ID="LblCodigo" runat="server" Font-Bold="True"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            Descrição:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtDescricao" runat="server" CssClass="CampoCadastro" 
                Width="300px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            Etapa Final Sucesso:</td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="DdlEtapaFinalSucesso" runat="server" 
                CssClass="CampoCadastro" Width="307px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
            Etapa Final Insucesso:</td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="DdlEtapaFinalInsucesso" runat="server" 
                CssClass="CampoCadastro" Width="307px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
            Ocultar Equipamento:</td>
        <td class="CelulaCampoCadastro">
            <asp:CheckBox ID="CbxOcultarEquipamento" runat="server" />
        </td>
    </tr>
    <tr>
        <td colspan="2" align="center">
            &nbsp;</td>
    </tr>
    <tr>
        <td colspan="2" align="center">
            <asp:Button ID="BtnGravar" runat="server" Text="Gravar" CssClass="Botao" />
        &nbsp;
            <asp:Button ID="BtnVoltar" runat="server" CssClass="Botao" Text="Voltar" />
        </td>
    </tr>
</table>
<p>
            <asp:TextBox ID="TxtCorBotao" runat="server" BorderStyle="None" 
        ForeColor="White" BackColor="White" BorderColor="White"></asp:TextBox>
        </p>

<%--este é o html para pesquisa de cores--%><%--botões padrão que ficam ocultos, são necessários, não remover--%>
    <div class="popup_Buttons" style="display: none">
        <input id="ButtonEditDone" value="Done" type="button" />
        <input id="ButtonEditCancel" value="Cancel" type="button" />
    </div>
<%--frame onde é mostrado o popup--%>
    <div id="DivEditWindow" style="display: none;" class="popupConfirmation">
        <iframe id="IframeEdit" frameborder="0" width="247" height="212" scrolling="no">
        </iframe>
    </div>