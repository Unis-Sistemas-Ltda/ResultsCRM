<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCTarefaPadrao.ascx.vb" Inherits="ResultsCRM.WUCTarefaPadrao" %>
<%@ Register src="../OutrosControles/TextBoxInteiro.ascx" tagname="TextBoxInteiro" tagprefix="uc1" %>
<link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
<div class="TituloCadastro">Detalhe do Cadastro Tarefa Padrão</div>
<table style="width:100%;" class="TextoCadastro">
    <tr>
        <td class="Erro" colspan="2">
            <asp:Label ID="LblErro" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            Código:</td>
        <td class="CelulaCampoCadastro">
            <asp:Label ID="LblCodigo" runat="server" Font-Bold="True"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            Descrição Resumida:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtDescricaoResumida" runat="server" CssClass="CampoCadastro" 
                Width="300px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            Dias previsão:</td>
        <td class="CelulaCampoCadastro">
            <uc1:TextBoxInteiro ID="TxtDiasPrevisao" runat="server" MaxLength="2" 
                Width="40" />
        </td>
    </tr>
    <tr>
        <td>
            Prioridade:</td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="DdlPrioridade" runat="server" CssClass="CampoCadastro" 
                Width="100px">
                <asp:ListItem Value="A">Alta</asp:ListItem>
                <asp:ListItem Selected="True" Value="M">Média</asp:ListItem>
                <asp:ListItem Value="B">Baixa</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td valign="top">
            Descrição:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtDescricao" runat="server" CssClass="CampoCadastro" 
                Width="310px" Height="100px" TextMode="MultiLine"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            Responsável:</td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="DdlTipoResponsavel" runat="server" CssClass="CampoCadastro" 
                Width="310px">
                <asp:ListItem Value="1">Agente de Vendas</asp:ListItem>
                <asp:ListItem Value="2">Gestor</asp:ListItem>
                <asp:ListItem Value="3">Vendedor/Representante</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
            Manter informado:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtManterInformado" runat="server" CssClass="CampoCadastro" 
                Width="310px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            Título:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtTitulo" runat="server" CssClass="CampoCadastro" 
                Width="310px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td valign="top">
            Observação:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtObservacao" runat="server" CssClass="CampoCadastro" 
                Height="100px" TextMode="MultiLine" Width="310px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td colspan="2" align=center>
            <asp:Button ID="BtnGravar" runat="server" Text="Gravar" CssClass="Botao" />
        &nbsp;
            <asp:Button ID="BtnVoltar" runat="server" CssClass="Botao" Text="Voltar" />
        </td>
    </tr>
</table>
