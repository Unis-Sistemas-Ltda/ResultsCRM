<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCAcaoFollowUp.ascx.vb" Inherits="ResultsCRM.WUCAcaoFollowUp" %>
<link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
<style type="text/css">
    </style>
<div class="TituloCadastro">Detalhe do Cadastro da Ação</div>
<table style="width:100%;" class="TextoCadastro">
    <tr>
        <td class="Erro" colspan="2">
            <asp:Label ID="LblErro" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            Código:</td>
        <td class="CampoCadastro">
            <asp:Label ID="LblCodigo" runat="server" Font-Bold="True"></asp:Label>
        </td>
    </tr>
    <tr style="text-align: center">
        <td class="TextoCadastro">
            Ação:</td>
        <td class="CampoCadastro">
            <asp:TextBox ID="TxtDescricao" runat="server" CssClass="CampoCadastro" 
                Width="300px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td class="CelulaCampoCadastro">
            <asp:CheckBox ID="ChkEnviaEmail" runat="server" CssClass="CampoCadastro" 
                Text="Envia e-mail" />
        </td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;
            <asp:Button ID="BtnGravar" runat="server" Text="Gravar" CssClass="Botao" />
        &nbsp;&nbsp;
            </td>
        <td style="text-align: left">
            <asp:Button ID="BtnVoltar" runat="server" CssClass="Botao" Text="Voltar" 
                Height="20px" />
        </td>
    </tr>
</table>
