<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCSistema.ascx.vb" Inherits="ResultsCRM.WUCSistema" %>
<%@ Register src="../OutrosControles/TextBoxInteiro.ascx" tagname="TextBoxInteiro" tagprefix="uc1" %>
<link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
<div class="TituloCadastro">Sistemas</div>
<table class="TextoCadastro" style="width:100%;">
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
                MaxLength="100" Width="300px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td colspan="2" style="text-align: center">
            &nbsp;</td>
    </tr>
    <tr>
        <td colspan="2" 
            style="text-align: left; font-weight: bold; visibility: hidden;">
            Escolha o(s) banco(s) de dados</td>
    </tr>
    <tr>
        <td colspan="2" style="text-align: left">
            <asp:CheckBoxList ID="CbxBancoDados" runat="server" CellPadding="5" 
                DataSourceID="SqlDataSource1" DataTextField="descricao" 
                DataValueField="cod_banco_dados" RepeatColumns="4" Visible="False">
            </asp:CheckBoxList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select 1 cod_banco_dados, '' descricao from dummy /*select cod_banco_dados, descricao
from banco_dados
order by descricao*/"></asp:SqlDataSource>
        </td>
    </tr>
    <tr>
        <td colspan="2" style="text-align: center">
            &nbsp;</td>
    </tr>
    <tr>
        <td colspan="2" style="text-align: center">
            <asp:Button ID="BtnGravar" runat="server" CssClass="Botao" Text="Gravar" />
        &nbsp;
            <asp:Button ID="BtnVoltar" runat="server" CssClass="Botao" Text="Voltar" />
        </td>
    </tr>
</table>
