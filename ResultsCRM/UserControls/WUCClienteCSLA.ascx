<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCClienteCSLA.ascx.vb" Inherits="ResultsCRM.WUClienteCSLA" %>
<link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
<div class="TituloCadastro">Detalhe de SLA</div>
<table style="width:100%;" class="TextoCadastro_BGBranco">
    <tr>
        <td class="Erro" colspan="2">
            <asp:Label ID="LblErro" runat="server"></asp:Label>
            <asp:TextBox ID="TxtPrazoChegada" runat="server" CssClass="CampoCadastro" style="text-align: center"
                Width="80px" Visible="False"></asp:TextBox>
            <asp:TextBox ID="TxtPrazoEncerramento" runat="server" CssClass="CampoCadastro" style="text-align: center"
                Width="80px" Visible="False"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            SLA:</td>
        <td class="CelulaCampoCadastro" style="font-weight: bold">
            <asp:DropDownList ID="DDLSLA" runat="server" CssClass="CampoCadastro" 
                Width="250px" AutoPostBack="True">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Quantidade chamados/dia:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtQtdChamadosDia" runat="server" CssClass="CampoCadastro" style="text-align: center"
                Width="80px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td colspan="2" align="center">
            <asp:Button ID="BtnGravar" runat="server" Text="Gravar" CssClass="Botao" />
        &nbsp;</td>
    </tr>
</table>
