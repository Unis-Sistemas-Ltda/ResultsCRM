<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCModelo.ascx.vb" Inherits="ResultsCRM.WUCModelo" %>
<link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
<table class="TextoCadastro" style="width:100%;">
    <tr>
        <td class="TituloCadastro" colspan="2">
            Detalhes do Modelo de Proposta</td>
    </tr>
    <tr>
        <td class="Erro" colspan="2">
            <asp:Label ID="LblErro" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="width: 100px">
            Código:</td>
        <td class="CelulaCampoCadastro">
            <asp:Label ID="LblCodModelo" runat="server" Font-Bold="True"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            Descrição:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtDescricao" runat="server" CssClass="CampoCadastro" 
                Width="400px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            Cabeçalho:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtCabecalho" runat="server" CssClass="CampoCadastro" 
                Height="115px" Width="400px" TextMode="MultiLine"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            Rodapé:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtRodape" runat="server" CssClass="CampoCadastro" 
                Height="115px" Width="400px" TextMode="MultiLine"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td colspan="2" style="text-align: center">
            <asp:Button ID="BtnGravar" runat="server" CssClass="Botao" Text="Salvar" />
        &nbsp;
            <asp:Button ID="BtnVoltar" runat="server" CssClass="Botao" Text="Voltar" />
        </td>
    </tr>
    <tr>
        <td style="text-align: left">
            </td>
        <td style="text-align: left">
            Dica: Você pode colocar tags para colocar textos em negrito, itálico ou 
            sublinhado na impressão da proposta.<br />
            [b] e [/b] são as tags para identificar início e final de texto em negrito, 
            respectivamente.<br />
            [i] e [/i] identificam início e final de texto em itálico, respectivamente.<br />
            [u] e [/u] identificam início e final de texto sublinhado, respectivamente.<br />
            Exemplos:<br />
            quero
            [b]este texto em negrito.[/b] - na impressão da proposta será exibido dessa 
            maneira: quero <b>este texto em negrito.</b><br />
            quero
            [i]este texto em itálico.[/i] - na impressão da proposta será mostrado dessa 
            maneira: quero <i>este texto em itálico.</i><br />
            quero
            [u]este texto sublinhado.[/u] - na impressão da proposta será apresentado dessa 
            maneira: quero <u>este texto sublinhado.</u></td>
    </tr>
    </table>
