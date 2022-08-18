<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCClientePontoAtendimento.ascx.vb" Inherits="ResultsCRM.WUCClientePontoAtendimento" %>
<%@ Register src="../OutrosControles/TextBoxCNPJCPF.ascx" tagname="TextBoxCNPJCPF" tagprefix="uc2" %>
<%@ Register src="../OutrosControles/TextBoxCNPJ.ascx" tagname="TextBoxCNPJ" tagprefix="uc1" %>
<link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
<body style="margin:0px">
<table class="TextoCadastro_BGBranco" 
        style="width:100%; border-collapse: collapse;">
    <tr>
        <td class="TituloCadastro" colspan="2">
            Cadastro de 
            Ponto de Atendimento</td>
    </tr>
    <tr>
        <td class="Erro" colspan="2">
            <asp:Label ID="LblErro" runat="server" CssClass="Erro"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Nº Ponto Atend:</td>
        <td>
            <asp:TextBox ID="TxtNrPontoAtendimento" runat="server" CssClass="CampoCadastro" 
                Width="122px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:CheckBox ID="ChkPreferencial" runat="server" Text="P:" 
                Height="17px" TextAlign="Left" ToolTip="Preferencial" />
        &nbsp;
            <asp:CheckBox ID="ChkAtivo" runat="server" Text="| A:" TextAlign="Left" 
                Height="17px" ToolTip="Ativo" Checked="True" />
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Descrição:</td>
        <td>
            <asp:TextBox ID="TxtDescricao" runat="server" CssClass="CampoCadastro" 
                Width="250px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            <asp:Label ID="Label8" runat="server" Height="16px" Text="Tipo:" 
                ToolTip="Tipo do Ponto de Atendimento"></asp:Label>
            </td>
        <td>
            <asp:DropDownList ID="DdlTipoPontoAtendimento" runat="server" 
                CssClass="CampoCadastro" Width="120px">
            </asp:DropDownList>
            <asp:Label ID="Label9" runat="server" Height="16px" Text="&nbsp;Uniorg:"></asp:Label>
            <asp:TextBox ID="TxtNrUniorg" runat="server" 
                CssClass="CampoCadastro" Width="83px" 
                ToolTip="Nº Uniorg"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Logradouro:</td>
        <td>
            <asp:TextBox ID="TxtLogradouro" runat="server" CssClass="CampoCadastro" 
                Width="165px"></asp:TextBox>
        &nbsp;<asp:Label ID="Label4" runat="server" Height="16px" Text="Nº:"></asp:Label>
            <asp:TextBox ID="TxtNumero" runat="server" CssClass="CampoCadastro" 
                Width="50px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            País:</td>
        <td>
            <asp:DropDownList ID="DdlPais" runat="server" AutoPostBack="True" 
                CssClass="CampoCadastro" Width="150px">
            </asp:DropDownList>
        &nbsp;<asp:Label ID="Label3" runat="server" Height="16px" Text="Estado:"></asp:Label>
            <asp:DropDownList ID="DdlEstado" runat="server" AutoPostBack="True" 
                CssClass="CampoCadastro" Width="50px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Cidade:</td>
        <td>
            <asp:DropDownList ID="DdlCidade" runat="server" CssClass="CampoCadastro" 
                Width="250px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            <asp:Label ID="Label2" runat="server" Height="16px" Text="CEP:"></asp:Label>
            </td>
        <td>
            <asp:TextBox ID="TxtCEP" runat="server" CssClass="CampoCadastro" Width="79px"></asp:TextBox>
        &nbsp;<asp:Label ID="Label5" runat="server" Height="16px" Text="Bairro:"></asp:Label>
            <asp:TextBox ID="TxtBairro" runat="server" CssClass="CampoCadastro" 
                Width="122px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Fones:</td>
        <td>
            <asp:TextBox ID="TxtFone1" runat="server" CssClass="CampoCadastro" 
                Width="118px"></asp:TextBox>
&nbsp;<asp:TextBox ID="TxtFone2" runat="server" CssClass="CampoCadastro" Width="119px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Fax:</td>
        <td>
            <asp:TextBox ID="TxtFax" runat="server" CssClass="CampoCadastro" Width="80px"></asp:TextBox>
        &nbsp;<asp:Label ID="Label6" runat="server" Height="16px" Text="E-mail:"></asp:Label>
            <asp:TextBox ID="TxtEmail" runat="server" CssClass="CampoCadastro" 
                Width="118px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            CNPJ:</td>
        <td>
            <uc1:TextBoxCNPJ ID="TxtCNPJ" runat="server" />
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Observação:</td>
        <td>
            <asp:TextBox ID="TxtObservacao" runat="server" CssClass="CampoCadastro" 
                Width="250px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Horário de Func.:</td>
        <td>
            <asp:TextBox ID="TxtHorarioFuncionamentoInicio" runat="server" 
                CssClass="CampoCadastro" Width="45px" MaxLength="5"></asp:TextBox>
            <asp:Label ID="Label10" runat="server" Height="16px" Text="&nbsp;às&nbsp;"></asp:Label>
            <asp:TextBox ID="TxtHorarioFuncionamentoFim" runat="server" 
                CssClass="CampoCadastro" Width="45px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            &nbsp;</td>
        <td>
            <asp:CheckBox ID="CbxExigeIntegracao" runat="server" 
                Text="Exige integração/treinamento" />
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
    <asp:Button ID="btnOkay" runat="server" CssClass="Botao" 
                                OnClick="btnOkay_Click" Text="Done" Visible="False" />
        </td>
        <td>
            <asp:Button ID="BtnGravar" runat="server" CssClass="Botao" Text="Salvar" />
        &nbsp;&nbsp;
            <asp:Button ID="BtnVoltar" runat="server" CssClass="Botao" Text="Voltar" />
        </td>
    </tr>
</table>
</body>