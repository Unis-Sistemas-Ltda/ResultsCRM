<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCEfeito.ascx.vb" Inherits="ResultsCRM.WUCEfeito" %>
<link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
<div class="TituloCadastro">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    Detalhe do Efeito</div>
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
            <asp:Label ID="LblCodEfeito" runat="server" Font-Bold="True"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Descrição 
            Resumida:</td>
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
        <td style="text-align: right">
            Severidade:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtSeveridade" runat="server" CssClass="CampoCadastro" style="text-align: center"
                MaxLength="2" Width="40px">1</asp:TextBox>
        </td>
    </tr>
    <tr>
        <td colspan="2" style="text-align: center">
            <asp:Button ID="BtnGravar" runat="server" CssClass="Botao" Text="Gravar" />
        &nbsp;
            <asp:Button ID="BtnVoltar" runat="server" CssClass="Botao" Text="Voltar" />
        </td>
    </tr>
</table>
