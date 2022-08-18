<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCAssessoria.ascx.vb" Inherits="ResultsCRM.WUCAssessoria" %>
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
            <asp:Label ID="LblCodAssessoria" runat="server" Font-Bold="True"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Descrição:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtDescricao" runat="server" CssClass="CampoCadastro" 
                MaxLength="100" Width="300px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td valign="top" style="text-align: right">
            Tipo:</td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="DdlTipoAssessoria" runat="server" 
                CssClass="CampoCadastro" Width="305px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td colspan="2" style="text-align: center">
            <br />
            <asp:Button ID="BtnGravar" runat="server" CssClass="Botao" Text="Gravar" />
        </td>
    </tr>
</table>
