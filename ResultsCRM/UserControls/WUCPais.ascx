<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCPais.ascx.vb" Inherits="ResultsCRM.WUCPais" %>
<link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
<div class="TituloCadastro">Detalhe do Cadastro de País</div>
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
            Sigla:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtSigla" runat="server" CssClass="CampoCadastro" Width="50px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            País:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtPais" runat="server" CssClass="CampoCadastro" 
                Width="300px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td colspan="2" align="center">
            <asp:Button ID="BtnGravar" runat="server" Text="Gravar" CssClass="Botao" />
        &nbsp;
            <asp:Button ID="BtnVoltar" runat="server" CssClass="Botao" Text="Voltar" />
        </td>
    </tr>
</table>