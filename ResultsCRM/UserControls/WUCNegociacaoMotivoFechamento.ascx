<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCNegociacaoMotivoFechamento.ascx.vb" Inherits="ResultsCRM.WUCNegociacaoMotivoFechamento" %>
<%@ Register src="../OutrosControles/TextBoxNumerico.ascx" tagname="TextBoxNumerico" tagprefix="uc1" %>
<%@ Register src="../OutrosControles/TextBoxInteiro.ascx" tagname="TextBoxInteiro" tagprefix="uc2" %>
<link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />

<table class="TextoCadastro_BGBranco" 
    style="width:100%; border-collapse: collapse;">
    <tr>
        <td colspan="2" style="text-align: left" class="SubTituloMovimento">
            Motivo de Fechamento 
            / Perda<br />
            <br />
        </td>
    </tr>
    <tr>
        <td class="Erro" colspan="2">
            <asp:Label ID="LblErro" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td colspan="1" style="text-align: right; width: 150px;">
            Selecione o motivo:</td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="DdlMotivoFechamento" runat="server" CssClass="CampoCadastro" Width="350px"></asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td colspan="1" style="text-align: left">
            <asp:Button ID="Button1" runat="server" CssClass="Botao" Text="Voltar" />
        </td>
        <td style="text-align: left">
            <asp:Button ID="BtnGravar" runat="server" CssClass="Botao" Text="Gravar" />
        </td>
    </tr>
</table>
