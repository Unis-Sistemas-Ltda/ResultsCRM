<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCSLA.ascx.vb" Inherits="ResultsCRM.WUCSLA" %>
<link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
<div class="TituloCadastro">Detalhe do Cadastro de SLA</div>
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
                Width="200px" MaxLength="50"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            Prazo Chegada:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtPrazoChegada" runat="server" CssClass="CampoCadastro" style="text-align: center"
                Width="80px"></asp:TextBox>
        &nbsp;<asp:Label ID="Label1" runat="server" Height="16px" Text="h."></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            Prazo Encerramento:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtPrazoEncerramento" runat="server" CssClass="CampoCadastro" style="text-align: center"
                Width="80px"></asp:TextBox>
        &nbsp;<asp:Label ID="Label2" runat="server" Height="16px" Text="h."></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            Código Integração:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtCodigoIntegracao" runat="server" CssClass="CampoCadastro" style="text-align: center"
                Width="80px"></asp:TextBox>
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
