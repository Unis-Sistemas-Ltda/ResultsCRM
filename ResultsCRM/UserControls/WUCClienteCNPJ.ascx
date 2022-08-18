<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCClienteCNPJ.ascx.vb" Inherits="ResultsCRM.WUCClienteCNPJ" %>
<%@ Register src="../OutrosControles/TextBoxCNPJCPF.ascx" tagname="TextBoxCNPJCPF" tagprefix="uc2" %>
<link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
<table class="TextoCadastro_BGBranco" 
    style="width:100%; border-collapse: collapse;">
    <tr>
        <td class="TituloCadastro" colspan="2">
            Cadastro de 
            <asp:Label ID="LblCNPJCPF2" runat="server" Text="CNPJ"></asp:Label>
            &nbsp;e Endereço</td>
    </tr>
    <tr>
        <td class="Erro" colspan="2">
            <asp:Label ID="LblErro" runat="server" CssClass="Erro" Font-Size="7pt" 
                BackColor="#FFFFE8" Width="100%"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right; font-size: 7pt;">
            <asp:Label ID="LblCNPJCPF1" runat="server" Text="CNPJ"></asp:Label>
            :</td>
        <td style="font-size: 7pt">
            <uc2:TextBoxCNPJCPF ID="TxtCNPJ" runat="server" />
            <asp:Label ID="LblCNPJNovo" runat="server" Visible="False"></asp:Label>
            &nbsp;&nbsp;<asp:CheckBox ID="ChkPreferencial" runat="server" Text="P:" 
                Height="17px" TextAlign="Left" ToolTip="Preferencial" />
        &nbsp;<asp:CheckBox ID="ChkCobranca" runat="server" Text="| C:" 
                TextAlign="Left" Height="17px" ToolTip="Cobrança" />
&nbsp;<asp:CheckBox ID="ChkAtivo" runat="server" Text="| A:" TextAlign="Left" 
                Height="17px" ToolTip="Ativo" Checked="True" />
        </td>
    </tr>
    <tr>
        <td style="text-align: right; font-size: 7pt;">
            Situação:</td>
        <td>
            <asp:DropDownList ID="DdlSituacao" runat="server" CssClass="CampoCadastro" 
                Width="150px">
                <asp:ListItem Value="1">Potencial</asp:ListItem>
                <asp:ListItem Value="4">Em Ativação</asp:ListItem>
                <asp:ListItem Selected="True" Value="2">Ativo</asp:ListItem>
                <asp:ListItem Value="5">Ativo Pend. Documental</asp:ListItem>
                <asp:ListItem Value="3">Inativo</asp:ListItem>
                <asp:ListItem Value="6">Encerrou as Atividades</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="text-align: right; font-size: 7pt;">
            <asp:Label ID="LblRazaoSocial" runat="server" Text="Razão Social"></asp:Label>
            :</td>
        <td>
            <asp:TextBox ID="TxtNome" runat="server" CssClass="CampoCadastro" Width="295px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right; font-size: 7pt;">
            <asp:Label ID="LblFantasia" runat="server" Text="Fantasia"></asp:Label>
            :</td>
        <td>
            <asp:TextBox ID="TxtNomeAbreviado" runat="server" CssClass="CampoCadastro" 
                Width="295px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right; font-size: 7pt;">
            Logradouro:</td>
        <td style="font-size: 7pt">
            <asp:TextBox ID="TxtLogradouro" runat="server" CssClass="CampoCadastro" 
                Width="188px"></asp:TextBox>
            <asp:Label ID="Label4" runat="server" Height="16px" Text="Nº:" 
                style="text-align:right" Width="32px"></asp:Label>
            <asp:TextBox ID="TxtNumero" runat="server" CssClass="CampoCadastro" 
                Width="62px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right; font-size: 7pt;">
            <asp:Label ID="Label5" runat="server" Height="16px" Text="Bairro:"></asp:Label>
            </td>
        <td style="font-size: 7pt">
            <asp:TextBox ID="TxtBairro" runat="server" CssClass="CampoCadastro" 
                Width="188px"></asp:TextBox>
            <asp:Label ID="Label2" runat="server" Height="16px" style="text-align: right" 
                Text="CEP:" Width="32px"></asp:Label>
            <asp:TextBox ID="TxtCEP" runat="server" CssClass="CampoCadastro" Width="62px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right; font-size: 7pt;">
            País:</td>
        <td style="font-size: 7pt">
            <asp:DropDownList ID="DdlPais" runat="server" AutoPostBack="True" 
                CssClass="CampoCadastro" Width="195px">
            </asp:DropDownList>
            <asp:Label ID="Label3" runat="server" Height="16px" Text="UF:" Width="32px" 
                style="text-align:right"></asp:Label>
            <asp:DropDownList ID="DdlEstado" runat="server" AutoPostBack="True" 
                CssClass="CampoCadastro" Width="67px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="text-align: right; font-size: 7pt;">
            Cidade:</td>
        <td>
            <asp:DropDownList ID="DdlCidade" runat="server" CssClass="CampoCadastro" 
                Width="300px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="text-align: right; font-size: 7pt;">
            Fones:</td>
        <td style="font-size: 7pt">
            <asp:TextBox ID="TxtFone1" runat="server" CssClass="CampoCadastro" 
                Width="80px"></asp:TextBox>
&nbsp;<asp:TextBox ID="TxtFone2" runat="server" CssClass="CampoCadastro" Width="80px"></asp:TextBox>
            <asp:Label ID="Label8" runat="server" Height="16px" Text="Fax:" Width="32px" 
                style="text-align:right"></asp:Label>
            <asp:TextBox ID="TxtFax" runat="server" CssClass="CampoCadastro" Width="80px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right; font-size: 7pt;">
            <asp:Label ID="Label7" runat="server" Height="16px" Text="Insc. Est.:" 
                ToolTip="Inscrição Estadual"></asp:Label>
            </td>
        <td style="font-size: 7pt">
            <asp:TextBox ID="TxtIE" runat="server" CssClass="CampoCadastro" Width="100px" 
                ToolTip="Inscrição Estadual"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label1" runat="server" Height="16px" Text="Insc. Mun.:" 
                ToolTip="Inscrição Municipal"></asp:Label>
            <asp:TextBox ID="TxtIM" runat="server" CssClass="CampoCadastro" Width="105px" 
                ToolTip="Inscrição Municipal"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right; font-size: 7pt;">
            <asp:Label ID="Label6" runat="server" Height="16px" Text="E-mail geral:"></asp:Label>
            </td>
        <td>
            <asp:TextBox ID="TxtEmail" runat="server" CssClass="CampoCadastro" 
                Width="295px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right; font-size: 7pt;">
            <asp:Label ID="Label9" runat="server" Height="16px" Text="E-mail NF-e:"></asp:Label>
            </td>
        <td>
            <asp:TextBox ID="TxtEmailNFe" runat="server" CssClass="CampoCadastro" 
                Width="295px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right; font-size: 7pt;">
            <asp:Label ID="Label10" runat="server" Height="16px" Text="E-mail boleto:"></asp:Label>
            </td>
        <td>
            <asp:TextBox ID="TxtEmailBoleto" runat="server" CssClass="CampoCadastro" 
                Width="295px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            &nbsp;</td>
        <td>
            <asp:Button ID="BtnGravar" runat="server" CssClass="Botao" Text="Salvar" />
        &nbsp;&nbsp;
            <asp:Button ID="BtnVoltar" runat="server" CssClass="Botao" Text="Voltar" />
        &nbsp;&nbsp;
            <asp:Button ID="BtnContinuar" runat="server" CssClass="Botao" Text="Continuar" 
                Visible="False" />
        </td>
    </tr>
</table>
