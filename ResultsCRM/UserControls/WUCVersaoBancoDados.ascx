<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCVersaoBancoDados.ascx.vb" Inherits="ResultsCRM.WUCVersaoBancoDados" %>
<%@ Register src="../OutrosControles/TextBoxInteiro.ascx" tagname="TextBoxInteiro" tagprefix="uc1" %>
<link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
<script language="javascript" src="../ResultsCRM.js" type="text/javascript"></script>
<div class="TituloCadastro">Detalhes da Versão de Banco de Dados</div>
<table class="TextoCadastro" style="width:100%; border-collapse: collapse;">
    <tr>
        <td class="Erro" colspan="2">
            <asp:Label ID="LblErro" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            Banco de Dados:</td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="DdlBancoDados" runat="server" CssClass="CampoCadastro" 
                Width="250px" AutoPostBack="True">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
            Versão:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtVersao" runat="server" CssClass="CampoCadastro" 
                Width="50px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            Descrição:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtDescricao" runat="server" CssClass="CampoCadastro" 
                MaxLength="100" Width="250px">&nbsp;</asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            Vigência (início):</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtInicioVigencia" runat="server" CssClass="CampoCadastro" 
                MaxLength="10" Width="80px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            Vigência (término):</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtTerminoVigencia" runat="server" CssClass="CampoCadastro" 
                MaxLength="10" Width="80px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            Liberada:</td>
        <td class="CelulaCampoCadastro">
            <asp:CheckBox ID="CbxLiberada" runat="server" AutoPostBack="True" />
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
