<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCAdesaoTEFFollowUp.ascx.vb" Inherits="ResultsCRM.WUCAdesaoTEFFollowUp" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register src="../OutrosControles/TextBoxData.ascx" tagname="TextBoxData" tagprefix="uc1" %>
<%@ Register src="../OutrosControles/TextBoxHora.ascx" tagname="TextBoxHora" tagprefix="uc2" %>

<link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
<link href="../ResultsCRMAjax.css" rel="stylesheet" type="text/css" />

<script type="text/javascript" language="javascript" src="../ResultsCRM.js"></script>

<body>

<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<table class="TextoCadastro_BGBranco" 
        style="width:100%; border-collapse: collapse;">
    <tr>
        <td class="Erro" colspan="2">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="Erro" colspan="2">
            <asp:Label ID="LblErro" runat="server" CssClass="Erro"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            <asp:Label ID="Label7" runat="server" Text="Seq.:"></asp:Label>
        </td>
        <td>
            <asp:Label ID="LblSeq" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Usuário:</td>
        <td>
            <asp:Label ID="LblNomeUsuario" runat="server"></asp:Label>
            (<asp:Label ID="LblCodUsuario" runat="server"></asp:Label>
            )</td>
    </tr>
    <tr>
        <td style="vertical-align: top; text-align: right;">
            <asp:Label ID="Label6" runat="server" Text="Comentário:"></asp:Label>
            <br />
            <br />
        </td>
        <td>
            <asp:TextBox ID="TxtDescricao" runat="server" CssClass="CampoCadastro" 
                Height="100px" Width="350px" TextMode="MultiLine" Font-Size="8pt"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="vertical-align: top; text-align: right;">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td style="vertical-align: top">
            &nbsp;</td>
        <td>
            <asp:Button ID="BtnGravar" runat="server" CssClass="Botao" Text="Salvar" />
        &nbsp;
            <asp:Button ID="BtnVoltar" runat="server" CssClass="Botao" Text="Voltar" />
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
        <iframe id="IframeEdit" frameborder="0" width="370" height="400" scrolling="no">
        </iframe>
    </div>
</body>

