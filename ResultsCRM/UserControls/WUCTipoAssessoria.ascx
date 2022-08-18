<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCTipoAssessoria.ascx.vb"
    Inherits="ResultsCRM.WUCTipoAssessoria" %>
<%@ Register Src="../OutrosControles/TextBoxInteiro.ascx" TagName="TextBoxInteiro"
    TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
<link href="../ResultsCRMAjax.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" language="javascript" src="../ResultsCRM.js"></script>
<div class="TituloCadastro">
    Detalhe do Cadastro de Tipo de Assessoria</div>
<table class="TextoCadastro" style="width: 100%;">
    <tr>
        <td class="Erro" colspan="2">
            <asp:Label ID="LblErro" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            Código:
        </td>
        <td class="CelulaCampoCadastro">
            <asp:Label ID="LblCodTipoAssessoria" runat="server" Font-Bold="True"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            Descrição:
        </td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtDescricao" runat="server" CssClass="CampoCadastro" MaxLength="100"
                Width="300px"></asp:TextBox>
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