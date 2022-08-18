<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCCausa.ascx.vb" Inherits="ResultsCRM.WUCCausa" %>
<%@ Register src="../OutrosControles/TextBoxInteiro.ascx" tagname="TextBoxInteiro" tagprefix="uc1" %>
<link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
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
            <asp:Label ID="LblCodCausa" runat="server" Font-Bold="True"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Descrição Resumida:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtDescricao" runat="server" CssClass="CampoCadastro" 
                MaxLength="100" Width="300px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td valign="top" style="text-align: right">
            Descrição Completa:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtDescricaoCompleta" runat="server" CssClass="CampoCadastro" 
                Width="300px" Height="110px" TextMode="MultiLine"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td colspan="2" style="text-align: center">
            <br />
            <asp:Button ID="BtnGravar" runat="server" CssClass="Botao" Text="Gravar" />
        </td>
    </tr>
</table>
