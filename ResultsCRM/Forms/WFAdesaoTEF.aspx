<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFAdesaoTEF.aspx.vb" Inherits="ResultsCRM.WFAdesaoTEF" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
    <link href="../ResultsCRMAjax.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="TituloMovimento">Detalhes da Adesão</div>
    <table width="100%" style="border-collapse: collapse"><tr><td class="Erro" colspan="4">
        <asp:Label ID="LblErro" runat="server"></asp:Label>
        </td></tr><tr><td style="text-align: right">Código:</td><td>
            <asp:Label ID="LblCodEmitente" runat="server" Font-Bold="True"></asp:Label>
            </td><td style="text-align: right">CNPJ:</td><td>
            <asp:Label ID="LblCNPJ" runat="server" Font-Bold="True"></asp:Label>
            </td></tr><tr><td style="text-align: right">Razão Social:</td><td colspan="3">
            <asp:Label ID="LblNomeEmitente" runat="server" Font-Bold="True"></asp:Label>
            </td></tr><tr><td style="text-align: right">&nbsp;</td><td>&nbsp;</td>
            <td style="text-align: right">&nbsp;</td><td>&nbsp;</td></tr><tr>
        <td style="border-width: 1px; border-color: #C0C0C0; text-align: right; border-top-style: solid; border-left-style: solid;">
            Adesão</td>
        <td style="border-width: 1px; border-color: #C0C0C0; border-top-style: solid; border-right-style: solid;">
            &nbsp;</td>
            <td style="text-align: right">&nbsp;</td><td>&nbsp;</td></tr><tr>
        <td style="border-width: 1px; border-color: #C0C0C0; text-align: right; border-left-style: solid;">Etapa 1:</td>
        <td style="border-width: 1px; border-color: #C0C0C0; border-right-style: solid;">
        <asp:Label ID="LblEtapa1" runat="server"></asp:Label>
        </td>
            <td style="text-align: right">&nbsp;</td><td>&nbsp;</td></tr><tr>
        <td style="border-width: 1px; border-color: #C0C0C0; text-align: right; border-left-style: solid;">Etapa 2:</td>
        <td style="border-width: 1px; border-color: #C0C0C0; border-right-style: solid;">
        <asp:Label ID="LblEtapa2" runat="server"></asp:Label>
        </td>
            <td style="text-align: right">&nbsp;</td><td>&nbsp;</td></tr><tr>
        <td style="border-width: 1px; border-color: #C0C0C0; text-align: right; border-left-style: solid;">Data Aceite:</td>
        <td style="border-width: 1px; border-color: #C0C0C0; border-right-style: solid;">
            <asp:Label ID="LblDataAceite" runat="server"></asp:Label>
            </td>
            <td style="text-align: right">&nbsp;</td><td>&nbsp;</td></tr><tr>
        <td style="border-width: 1px; border-color: #C0C0C0; text-align: right; border-left-style: solid; border-bottom-style: solid;">Data Validação:</td>
        <td style="border-width: 1px; border-color: #C0C0C0; border-bottom-style: solid; border-right-style: solid;">
            <asp:Label ID="LblDataValidacao" runat="server"></asp:Label>
            </td>
            <td style="text-align: right">&nbsp;</td><td>&nbsp;</td></tr><tr>
        <td style="text-align: right">&nbsp;</td><td>
        &nbsp;</td><td style="text-align: right">&nbsp;</td><td>&nbsp;</td></tr><tr>
        <td style="text-align: right">Nº Negociação:</td><td>
        <asp:TextBox ID="TxtCodNegociacaoCliente" runat="server" AutoPostBack="True" 
            CssClass="CampoCadastro" Width="50px"></asp:TextBox>
        </td><td style="text-align: right">&nbsp;</td><td>&nbsp;</td></tr><tr>
        <td style="text-align: right">Nº Pedido:</td><td>
        <asp:Label ID="LblCodPedidoVenda" runat="server" Font-Bold="True"></asp:Label>
        </td><td style="text-align: right">Data Fechamento:</td><td>
        <asp:Label ID="LblDataEmissaoPedido" runat="server" Font-Bold="True"></asp:Label>
        </td></tr><tr><td style="text-align: right">Nº NF:</td><td>
            <asp:Label ID="LblNF" runat="server" Font-Bold="True"></asp:Label>
            </td><td style="text-align: right">Chamado Instalação:</td><td>
            <asp:TextBox ID="TxtCodChamadoInstalacao" runat="server" 
                CssClass="CampoCadastro" Height="19px" Width="50px"></asp:TextBox>
&nbsp;<asp:Label ID="LblStatusChamadoInstalacao" runat="server" Height="17px"></asp:Label>
            </td></tr><tr><td style="text-align: right">&nbsp;</td><td>&nbsp;</td>
            <td style="text-align: right">&nbsp;</td><td>
            <asp:Button ID="BtnGerarChamado" runat="server" Text="Gerar chamado" />
            </td></tr><tr><td style="text-align: right">Cadastro STONE:</td><td>
            <asp:CheckBox ID="CbxAdquirente" runat="server" />
            </td><td style="text-align: right">&nbsp;</td><td>&nbsp;</td></tr><tr>
        <td style="text-align: right">Cadastro CAPPTA:</td><td>
        <asp:CheckBox ID="CbxParceiro" runat="server" />
        </td><td style="text-align: right">&nbsp;</td><td>
        &nbsp;</td></tr><tr><td style="text-align: right">Equipamento Recebido:</td><td>
            <asp:CheckBox ID="CbxEquipamentoEnviado" runat="server" />
            </td><td style="text-align: right">&nbsp;</td><td>
            &nbsp;</td></tr><tr><td style="text-align: right">&nbsp;</td><td>&nbsp;</td>
            <td style="text-align: right">&nbsp;</td><td>&nbsp;</td></tr><tr>
        <td style="text-align: right">&nbsp;</td><td>
        <asp:Button ID="BtnGravar" runat="server" Text="Salvar alterações" />
&nbsp;
        <asp:Button ID="BtnVoltar" runat="server" Text="Voltar" Width="100px" />
        </td><td colspan="2">&nbsp;</td></tr></table>
    </form>
</body>
</html>

