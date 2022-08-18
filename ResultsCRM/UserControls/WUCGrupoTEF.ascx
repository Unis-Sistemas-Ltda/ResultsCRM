<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCGrupoTEF.ascx.vb" Inherits="ResultsCRM.WUCGrupoTEF" %>
<link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
<div class="TituloCadastro">Grupos TEF</div>
<table class="TextoCadastro" style="width:100%;">
    <tr>
        <td class="Erro" colspan="2">
            <asp:Label ID="LblErro" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Código:</td>
        <td class="CelulaCampoCadastro">
            <asp:Label ID="LblCodAdesao" runat="server" Font-Bold="True"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Nome do Grupo:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtNomeRede" runat="server" CssClass="CampoCadastro" 
                MaxLength="100" Width="300px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Contato Responsável:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtNomeResponsavel" runat="server" CssClass="CampoCadastro" 
                MaxLength="100" Width="300px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Telefone(s) do Responsável:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtTelefoneResponsavel" runat="server" CssClass="CampoCadastro" 
                MaxLength="100" Width="300px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            E-mail do Responsável:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtEmailResponsavel" runat="server" CssClass="CampoCadastro" 
                MaxLength="100" Width="300px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Representante Legal:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtNomeRepresentanteLegal" runat="server" CssClass="CampoCadastro" 
                MaxLength="100" Width="300px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            CPF do Representante Legal:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtCPFRepresentanteLegal" runat="server" CssClass="CampoCadastro" 
                MaxLength="11" Width="110px"></asp:TextBox>
            (informar somente números)</td>
    </tr>
    <tr>
        <td style="text-align: right">
            Data de Nascimento do Repres. Legal:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtDataNascimentoRepresentanteLegal" runat="server" CssClass="CampoCadastro" 
                MaxLength="100" Width="70px"></asp:TextBox>
            (formato dd/mm/aaaa)</td>
    </tr>
    <tr>
        <td style="text-align: right">
            Valor de Custo da Ativação:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtValorCustoAtivacao" runat="server" CssClass="CampoCadastro" 
                MaxLength="100" Width="70px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Valor de Venda da Ativação:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtValorVendaAtivacao" runat="server" CssClass="CampoCadastro" 
                MaxLength="100" Width="70px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Mensalidade:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtValorMensal" runat="server" CssClass="CampoCadastro" 
                MaxLength="100" Width="70px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Autorizadora:</td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="DdlAutorizadora" runat="server" CssClass="CampoCadastro" 
                Width="300px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td class="CelulaCampoCadastro">
            &nbsp;</td>
    </tr>
    <tr>
        <td colspan="2" style="text-align: center">
            <asp:Button ID="BtnGravar" runat="server" CssClass="Botao" Text="Gravar" />
        &nbsp;
            <asp:Button ID="BtnVoltar" runat="server" CssClass="Botao" Text="Voltar" />
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Enviar e-mail(s) campanha" />
        </td>
    </tr>
</table>