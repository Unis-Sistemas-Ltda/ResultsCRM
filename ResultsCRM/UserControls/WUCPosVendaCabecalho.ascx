<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCPosVendaCabecalho.ascx.vb" Inherits="ResultsCRM.WUCPosVendaCabecalho" %>
<link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />

<script type="text/javascript" language="javascript">
    function carregaParent() {
        var btn = parent.document.getElementById('BtnCarrega');
        btn.click();
    }
</script>

<table class="TextoCadastro" style="width: 100%;">
    <tr>
        <td class="TituloMovimento" colspan="2">
            Dados do Cliente</td>
    </tr>
    <tr>
        <td class="Erro" colspan="2" style="background-color: #F4F2D7">
            <asp:Label ID="LblErro" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td style="text-align: left">
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            Código:</td>
        <td style="text-align: left">
            <asp:Label ID="LblCodigo" runat="server" Font-Bold="True" Text="0" Width="50px"></asp:Label>
            <asp:Label ID="LblCNPJLbl" runat="server" Text="CNPJ"></asp:Label>
            :<asp:Label ID="LblCNPJ" runat="server" Font-Bold="True" Text="0"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            Nome:</td>
        <td style="text-align: left">
            <asp:Label ID="LblNome" runat="server" Font-Bold="True"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            Fantasia:</td>
        <td style="text-align: left">
            <asp:Label ID="LblNomeFantasia" runat="server" Font-Bold="True"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="LblEmitentePFLbl" runat="server" Text="PF:"></asp:Label>
        </td>
        <td style="text-align: left">
            <asp:LinkButton ID="BtnEmitentePF" runat="server"></asp:LinkButton>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td style="text-align: left">
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            Endereço:</td>
        <td style="text-align: left">
            <asp:Label ID="LblLogradouro" runat="server" Font-Bold="True"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            Bairro:</td>
        <td style="text-align: left">
            &nbsp;<asp:Label ID="LblBairro" runat="server" Font-Bold="True"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            CEP:</td>
        <td style="text-align: left">
            <asp:Label ID="LblCEP" runat="server" Font-Bold="True"></asp:Label>
            &nbsp;&nbsp;
        </td>
    </tr>
    <tr>
        <td>
            Cidade/UF:</td>
        <td style="text-align: left">
            <asp:Label ID="LblCidade" runat="server" Font-Bold="True"></asp:Label>
&nbsp;/
            <asp:Label ID="LblUF" runat="server" Font-Bold="True"></asp:Label>
&nbsp;-
            <asp:Label ID="LblPais" runat="server" Font-Bold="True"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td style="text-align: left">
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            Telefone(s):</td>
        <td style="text-align: left">
            <asp:Label ID="LblTelefones" runat="server" Font-Bold="True"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            Fax:</td>
        <td style="text-align: left">
            <asp:Label ID="LblFax" runat="server" Font-Bold="True"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            E-mail:</td>
        <td style="text-align: left">
            <asp:Label ID="LblEmail" runat="server" Font-Bold="True"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            Contato Preferencial:</td>
        <td style="text-align: left">
            <asp:Label ID="LblContatoPreferencial" runat="server" Font-Bold="True"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            Senha:</td>
        <td style="text-align: left">
            <asp:Label ID="LblSenha" runat="server" Font-Bold="True"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td style="text-align: left">
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            Situação:</td>
        <td style="text-align: left">
            <asp:Label ID="LblSituacao" runat="server" Font-Bold="True"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            Preferencial:</td>
        <td style="text-align: left">
            <asp:Label ID="LblPreferencial" runat="server" Font-Bold="True"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            Associado:</td>
        <td style="text-align: left">
            <asp:Label ID="LblAssociado" runat="server" Font-Bold="True"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td style="text-align: left">
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            Data Cadastro:</td>
        <td style="text-align: left">
            <asp:Label ID="LblDataCadastro" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            Data Alteração:</td>
        <td style="text-align: left">
            <asp:Label ID="LblDataAlteracao" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            Data Recadastramento:</td>
        <td style="text-align: left">
            <asp:Label ID="LblDataRecadastro" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            Data Reativação:</td>
        <td style="text-align: left">
            <asp:Label ID="LblDataReativacao" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            Pend. Documentação:</td>
        <td style="text-align: left">
            <asp:Label ID="LblDataPendDoc" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td style="text-align: left">
            <asp:Label ID="LblInadimplente" runat="server" CssClass="Erro"></asp:Label>
        </td>
    </tr>
    </table>

