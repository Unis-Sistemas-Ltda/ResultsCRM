<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCClienteCSLAEstado.ascx.vb" Inherits="ResultsCRM.WUCClienteCSLAEstado" %>
<link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
<div class="TituloCadastro">Detalhe de SLA por UF</div>
<table style="width:100%;" class="TextoCadastro_BGBranco">
    <tr>
        <td class="Erro" colspan="2">
            <asp:Label ID="LblErro" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            SLA:</td>
        <td class="CelulaCampoCadastro" style="font-weight: bold">
            <asp:Label ID="LblDescricaoSLA" runat="server"></asp:Label>
            (<asp:Label ID="LblCodSLA" runat="server"></asp:Label>
            )</td>
    </tr>
    <tr>
        <td style="text-align: right">
            UF:</td>
        <td class="CelulaCampoCadastro" style="font-weight: bold">
            <asp:DropDownList ID="DdlEstado" runat="server" CssClass="CampoCadastro" 
                Width="250px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Prazo Chegada:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtPrazoChegada" runat="server" CssClass="CampoCadastro" style="text-align: center"
                Width="80px"></asp:TextBox>
        &nbsp;<asp:Label ID="Label1" runat="server" Height="16px" Text="h."></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Prazo Encerramento:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtPrazoEncerramento" runat="server" CssClass="CampoCadastro" style="text-align: center"
                Width="80px"></asp:TextBox>
        &nbsp;<asp:Label ID="Label2" runat="server" Height="16px" Text="h."></asp:Label>
        </td>
    </tr>
    <tr>
        <td colspan="2" align="center">
            <asp:Button ID="BtnGravar" runat="server" Text="Gravar" CssClass="Botao" />
        </td>
    </tr>
</table>
