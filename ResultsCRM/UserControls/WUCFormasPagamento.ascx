<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCFormasPagamento.ascx.vb" Inherits="ResultsCRM.WUCFormasPagamento" %>
<link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
<div class="TituloCadastro">Detalhes do Cadastro Forma de Pagamento</div>
<table class="TextoCadastro" style="width:100%;">
   <tr>
        <td class="Erro" colspan="2">
            <asp:Label ID="lblErro" runat="server" CssClass="Erro"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label1" runat="server" Text="Código:"></asp:Label>
        </td>
        <td class="CelulaCampoCadastro">
            <asp:Label ID="LblCodigo" runat="server" Font-Bold="True"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            Descrição:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtDescricao" runat="server" CssClass="CampoCadastro" 
                Width="300px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            Tipo:</td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="DdlTipo" runat="server" CssClass="CampoCadastro" 
                Width="200px">
                <asp:ListItem Value="1">Boleto</asp:ListItem>
                <asp:ListItem Value="2">DOC Outro CNPJ</asp:ListItem>
                <asp:ListItem Value="3">Crédito em conta corrente</asp:ListItem>
                <asp:ListItem Value="4">Cheque Administrativo</asp:ListItem>
                <asp:ListItem Value="5">Ordem de pagamento</asp:ListItem>
                <asp:ListItem Value="6">TED Outro CNPJ</asp:ListItem>
                <asp:ListItem Value="7">Cartão de Crédito</asp:ListItem>
                <asp:ListItem Value="8">Cartão de Débito</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
            Evento Baixa:</td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="DdlEventoBaixa" runat="server" CssClass="CampoCadastro" 
                Width="200px">
                <asp:ListItem Value="1">No envio ao Banco</asp:ListItem>
                <asp:ListItem Value="2">Na confirmação do recebimento</asp:ListItem>
                <asp:ListItem Value="3">Na confirmação do pagamento</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td class="CelulaCampoCadastro">
            <asp:CheckBox ID="ChkRecibo" runat="server" CssClass="CampoCadastro" 
                Text="Imprimir Recibo no Romaneio" />
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td class="CelulaCampoCadastro">
            <asp:Button ID="BtnGravar" runat="server" CssClass="Botao" Text="Gravar" />
        &nbsp;
            <asp:Button ID="BtnVoltar" runat="server" CssClass="Botao" Text="Voltar" />
        </td>
    </tr>
</table>
