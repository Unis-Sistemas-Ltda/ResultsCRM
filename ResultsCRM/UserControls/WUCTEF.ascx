<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCTEF.ascx.vb" Inherits="ResultsCRM.WUCTEF" %>
<link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
<table class="TextoCadastro" style="width:100%;">
    <tr>
        <td class="Erro" colspan="4">
            <asp:Label ID="LblErro" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Código:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtCodEmitente" runat="server" CssClass="CampoCadastro" 
                MaxLength="100" Width="70px"></asp:TextBox>
            <asp:Label ID="Label1" runat="server" Height="17px" Text="&nbsp;&nbsp;Status:"></asp:Label>
            <asp:DropDownList ID="DdlStatus" runat="server" CssClass="CampoCadastro" 
                Width="175px">
            </asp:DropDownList>
        </td>
        <td class="CelulaCampoCadastro" style="text-align: right">
            Gerar chamado de instalação:</td>
        <td class="CelulaCampoCadastro">
            <asp:CheckBox ID="CbxGerarChamadoInstalacao" runat="server" />
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Razão Social:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtRazaoSocial" runat="server" CssClass="CampoCadastro" 
                MaxLength="100" Width="300px"></asp:TextBox>
        </td>
        <td class="CelulaCampoCadastro" style="text-align: right">
            Nº do chamado de instalação:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtCodChamadoInstalacao" runat="server" CssClass="CampoCadastro" 
                MaxLength="100" Width="70px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            CNPJ:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtCNPJ" runat="server" CssClass="CampoCadastro" 
                MaxLength="14" Width="130px"></asp:TextBox>
            (informar somente números)</td>
        <td class="CelulaCampoCadastro" style="text-align: right">
            Quantidade de PDVs:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtQtdPDVs" runat="server" CssClass="CampoCadastro" 
                MaxLength="100" Width="70px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Grupo TEF:</td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="DdlGrupoTEF" runat="server" CssClass="CampoCadastro" 
                Width="300px">
            </asp:DropDownList>
        </td>
        <td class="CelulaCampoCadastro" style="text-align: right">
            Nº Negociação:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtCodNegociacaoCliente" runat="server" CssClass="CampoCadastro" 
                MaxLength="100" Width="70px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Nome Contato Loja:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtNomeContato" runat="server" CssClass="CampoCadastro" 
                MaxLength="100" Width="300px"></asp:TextBox>
        </td>
        <td class="CelulaCampoCadastro" style="text-align: right">
            Banco:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtBanco" runat="server" CssClass="CampoCadastro"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Telefone Contato Loja:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtTelefoneContato" runat="server" CssClass="CampoCadastro" 
                MaxLength="100" Width="300px"></asp:TextBox>
        </td>
        <td class="CelulaCampoCadastro" style="text-align: right">
            Agência:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtAgencia" runat="server" CssClass="CampoCadastro"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            E-mail Contato Loja:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtEmailContato" runat="server" CssClass="CampoCadastro" 
                MaxLength="100" Width="300px"></asp:TextBox>
        </td>
        <td class="CelulaCampoCadastro" style="text-align: right">
            Conta:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtConta" runat="server" CssClass="CampoCadastro"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Nome do fornecedor de software:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtNomeSoftwareHouse" runat="server" CssClass="CampoCadastro" 
                MaxLength="100" Width="300px"></asp:TextBox>
        </td>
        <td class="CelulaCampoCadastro" style="text-align: right">
            &nbsp;</td>
        <td class="CelulaCampoCadastro">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="text-align: right">
            Pessoa de contato no fornecedor de software:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtContatoSoftwareHouse" runat="server" CssClass="CampoCadastro" 
                MaxLength="100" Width="300px"></asp:TextBox>
        </td>
        <td class="CelulaCampoCadastro" style="text-align: right">
            CHECK LIST</td>
        <td class="CelulaCampoCadastro">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="text-align: right">
            Telefone do fornecedor de software:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtTelefoneSoftwareHouse" runat="server" CssClass="CampoCadastro" 
                MaxLength="100" Width="300px"></asp:TextBox>
        </td>
        <td class="CelulaCampoCadastro" style="text-align: right">
            Pinpad enviado para o cliente:</td>
        <td class="CelulaCampoCadastro">
            <asp:CheckBox ID="CbxPinpadEnviado" runat="server" />
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Email do fornecedor de software:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtEmailSoftwareHouse" runat="server" CssClass="CampoCadastro" 
                MaxLength="100" Width="300px"></asp:TextBox>
        </td>
        <td class="CelulaCampoCadastro" style="text-align: right">
            Cliente recebeu pinpad:</td>
        <td class="CelulaCampoCadastro">
            <asp:CheckBox ID="CbxRecebeuPinpad" runat="server" />
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Nome do Aplicativo Comercial:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtNomeAplicativoComercial" runat="server" CssClass="CampoCadastro" 
                MaxLength="100" Width="300px"></asp:TextBox>
        </td>
        <td class="CelulaCampoCadastro" style="text-align: right">
            Pinpad e programas instalados e configurados:</td>
        <td class="CelulaCampoCadastro">
            <asp:CheckBox ID="CbxInstalado" runat="server" />
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Versão do Aplicativo Comercial:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtVersaoAplicativoComercial" runat="server" CssClass="CampoCadastro" 
                MaxLength="100" Width="70px"></asp:TextBox>
        </td>
        <td class="CelulaCampoCadastro" style="text-align: right">
            Ambiente TEF testado e funcionando:</td>
        <td class="CelulaCampoCadastro">
            <asp:CheckBox ID="CbxTestado" runat="server" />
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            &nbsp;</td>
        <td class="CelulaCampoCadastro">
            <asp:Button ID="BtnGravar" runat="server" CssClass="Botao" Text="Gravar" />
        </td>
        <td class="CelulaCampoCadastro" style="text-align: right">
            <asp:Button ID="Button2" runat="server" Text="Gerar negociação" />
        </td>
        <td class="CelulaCampoCadastro">
            <asp:Button ID="Button1" runat="server" Text="Enviar e-mail" />
        </td>
    </tr>
    </table>
