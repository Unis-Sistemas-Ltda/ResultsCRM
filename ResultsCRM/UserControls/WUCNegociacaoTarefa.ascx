<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCNegociacaoTarefa.ascx.vb" Inherits="ResultsCRM.WUCNegociacaoTarefa" %>
<%@ Register src="../OutrosControles/TextBoxNumerico.ascx" tagname="TextBoxNumerico" tagprefix="uc1" %>
<%@ Register src="../OutrosControles/TextBoxData.ascx" tagname="TextBoxData" tagprefix="uc2" %>

<link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
<asp:ScriptManager ID="ScriptManager1" runat="server" 
                EnableScriptGlobalization="True"></asp:ScriptManager>
<table class="TextoCadastro_BGBranco" 
    style="width:100%; empty-cells: hide; border-collapse: collapse;">
    <tr>
        <td colspan="2" align="left" class="SubTituloMovimento">
            Tarefa<br />
        </td>
    </tr>
    <tr>
        <td class="Erro" colspan="2">
            <asp:Label ID="LblErro" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="width: 140px; text-align: right;">
            Seq. Tarefa:</td>
        <td class="CelulaCampoCadastro">
            <asp:Label ID="LblSeqTarefa" runat="server" Font-Bold="False"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right;">
            Tarefa padrão:</td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="DdlTarefaPadrao" runat="server" CssClass="CampoCadastro" 
                Width="310px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
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
        <td style="text-align: right;">
            Responsável:</td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="DdlResponsavel" runat="server" CssClass="CampoCadastro" 
                Width="310px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Manter Informado:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtManterInformado" runat="server" CssClass="CampoCadastro" 
                Width="310px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Data Cadastro:</td>
        <td class="CelulaCampoCadastro">
            <uc2:TextBoxData ID="TxtDataCadastro" runat="server" Width="100" />
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Previsão Finalização:</td>
        <td class="CelulaCampoCadastro">
            <uc2:TextBoxData ID="TxtPrevisaoFinalizacao" runat="server" Width="100" />
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Situação:</td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="DdlSituacao" runat="server" CssClass="CampoCadastro" 
                Width="210px">
                <asp:ListItem Value="1">Aguardando retorno do cliente</asp:ListItem>
                <asp:ListItem Value="2">Aguardar</asp:ListItem>
                <asp:ListItem Value="3">Cancelada</asp:ListItem>
                <asp:ListItem Value="4">Concluída</asp:ListItem>
                <asp:ListItem Value="5">Em Andamento</asp:ListItem>
                <asp:ListItem Value="6">Não Iniciada</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Data Conclusão:</td>
        <td class="CelulaCampoCadastro">
            <uc2:TextBoxData ID="TxtDataConclusao" runat="server" Width="100" />
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Título:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtTitulo" runat="server" CssClass="CampoCadastro" 
                Width="310px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right; vertical-align: top">
            Observação:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtObservacao" runat="server" CssClass="CampoCadastro" 
                Height="100px" TextMode="MultiLine" Width="310px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right; vertical-align: top">
            Observação Interna:</td>
        <td class="CelulaCampoCadastro">
            <asp:TextBox ID="TxtObservacaoInterna" runat="server" CssClass="CampoCadastro" 
                Height="100px" TextMode="MultiLine" Width="310px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td colspan="1" style="text-align: left">
            &nbsp;</td>
        <td style="text-align: left">
            <asp:Button ID="BtnGravar" runat="server" CssClass="Botao" Text="Gravar" />
        &nbsp;<asp:Button ID="Button1" runat="server" CssClass="Botao" Text="Voltar" />
        </td>
    </tr>
</table>
