<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCAtendimentoPedidoDespesa.ascx.vb" Inherits="ResultsCRM.WUCAtendimentoPedidoDespesa" %>
<link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />

<table class="TextoCadastro_BGBranco" 
    style="width:100%; border-collapse: collapse;">
    <tr>
        <td class="Erro" colspan="2">
            <asp:Label ID="LblErro" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td colspan="1" style="text-align: right; width: 150px;">
            Tipo:</td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="DdlTipoDespAcess" runat="server" 
                CssClass="CampoCadastro" Width="350px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td colspan="1" style="text-align: right; width: 150px;">
            Valor:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtValor" runat="server" CssClass="CampoCadastro" Width="75px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td colspan="1" style="text-align: left">
            <asp:Button ID="BtnVoltar" runat="server" CssClass="Botao" Text="Voltar" 
                Visible="False" />
        </td>
        <td style="text-align: left">
            <asp:Button ID="BtnGravar" runat="server" CssClass="Botao" Text="Gravar" />
        </td>
    </tr>
</table>
