<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCContato.ascx.vb" Inherits="ResultsCRM.WUCContato" %>
<%@ Register src="../OutrosControles/TextBoxInteiro.ascx" tagname="TextBoxInteiro" tagprefix="uc1" %>
<%@ Register src="../OutrosControles/TextBoxCPF.ascx" tagname="TextBoxCPF" tagprefix="uc2" %>
<link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
<link href="../ResultsCRMAjax.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript">
        function getbacktostepone() {
            window.location = "WFContato.aspx";
        }
        function onSuccess() {
            window.parent.document.getElementById('ButtonEditDone').click();
            window.parent.document.forms.item(0).submit();
        }
        function onError() {
            getbacktostepone();
        }
        function cancel() {
            window.parent.document.getElementById('ButtonEditCancel').click();
        }
        function OcultarBotaoFechar() {
            window.document.getElementById('btnCancel').style.visibility = "hidden";
        }
        function ExibirBotaoFechar() {
            window.document.getElementById('btnCancel').style.visibility = "visible";
        }
    </script>
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<body class="TextoCadastro_BGBranco" style="text-align: center">
<div class="TituloCadastro">Detalhe do Cadastro Contato</div>
<table class="TextoCadastro_BGBranco" 
        style="width:350px; border-collapse: collapse;">
    <tr>
        <td class="Erro" colspan="5">
            <asp:Label ID="LblErro" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            Código:</td>
        <td class="CelulaCampoCadastro" colspan="4">
            <asp:Label ID="LblCodContato" runat="server" Font-Bold="True"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            Nome:</td>
        <td class="CelulaCampoCadastro" colspan="4">
            <asp:TextBox ID="TxtNome" runat="server" CssClass="CampoCadastro" 
                MaxLength="100" Width="250px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            Título:</td>
        <td class="CelulaCampoCadastro" colspan="4">
            <asp:TextBox ID="TxtTitulo" runat="server" CssClass="CampoCadastro" 
                MaxLength="100" Width="150px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            Preferencial:</td>
        <td class="CelulaCampoCadastro">
            <asp:RadioButtonList ID="RblPreferencial" runat="server" 
                CssClass="CampoCadastro" RepeatColumns="2">
                <asp:ListItem Value="S">Sim</asp:ListItem>
                <asp:ListItem Selected="True" Value="N">Não</asp:ListItem>
            </asp:RadioButtonList>
        </td>
        <td class="CelulaCampoCadastro" style="text-align: right">
            &nbsp;</td>
        <td class="CelulaCampoCadastro" colspan="2">
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label8" runat="server" Height="16px" Text="Tipo:" 
                ToolTip="Tipo do contato"></asp:Label>
            </td>
        <td>
            <asp:DropDownList ID="DdlTipo" runat="server" 
                CssClass="CampoCadastro" Width="200px">
            </asp:DropDownList>         
        </td>
    </tr>
    <tr>
        <td>
            Situação:</td>
        <td class="CelulaCampoCadastro">
            <asp:RadioButtonList ID="RblAtivo" runat="server" CssClass="CampoCadastro" 
                RepeatColumns="2">
                <asp:ListItem Selected="True" Value="S">Ativo</asp:ListItem>
                <asp:ListItem Value="N">Inativo</asp:ListItem>
            </asp:RadioButtonList>
        </td>
        <td class="CelulaCampoCadastro" style="text-align: right">
            &nbsp;</td>
        <td class="CelulaCampoCadastro" colspan="2">
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            CPF:</td>
        <td class="CelulaCampoCadastro" colspan="4">
            <uc2:TextBoxCPF width="100" ID="TxtCPF" runat="server" />
            <asp:Label ID="Label3" runat="server" Height="17px" Text="&nbsp;RG:"></asp:Label>
            <asp:TextBox ID="TxtRG" runat="server" CssClass="CampoCadastro" 
                MaxLength="100" Width="75px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            Matrícula:</td>
        <td class="CelulaCampoCadastro" colspan="4">
            <asp:TextBox ID="TxtMatricula" runat="server" CssClass="CampoCadastro" 
                Width="100px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            Telefones:</td>
        <td class="CelulaCampoCadastro" colspan="4">
            <asp:TextBox ID="TxtTelefone1" runat="server" CssClass="CampoCadastro" 
                MaxLength="100" Width="100px"></asp:TextBox>
        &nbsp;<asp:Label ID="Label1" runat="server" Height="17px" Text="/"></asp:Label>
&nbsp;<asp:TextBox ID="TxtTelefone2" runat="server" CssClass="CampoCadastro" 
                MaxLength="100" Width="100px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            Celulares:</td>
        <td class="CelulaCampoCadastro" colspan="4">
            <asp:TextBox ID="TxtCelular1" runat="server" CssClass="CampoCadastro" 
                MaxLength="100" Width="100px"></asp:TextBox>
        &nbsp;<asp:Label ID="Label2" runat="server" Height="17px" Text="/"></asp:Label>
&nbsp;<asp:TextBox ID="TxtCelular2" runat="server" CssClass="CampoCadastro" 
                MaxLength="100" Width="100px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            WhatsApp:</td>
        <td class="CelulaCampoCadastro" colspan="4">
            <asp:TextBox ID="TxtWhatsApp" runat="server" CssClass="CampoCadastro" 
                MaxLength="100" Width="100px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td >
            E-mail:</td>
        <td class="CelulaCampoCadastro" colspan="4">
            <asp:TextBox ID="TxtEmail" runat="server" CssClass="CampoCadastro" 
                MaxLength="250" Width="250px" 
                ToolTip="Se necessário, informe mais de um e-mail, separando por vírgula."></asp:TextBox>
        </td>
    </tr>
     <tr>
        <td class="CelulaCampoCadastro" style="text-align: right">
            <asp:CheckBox ID="ChkRecebeEmailCobranca" runat="server" Text=" " /></td>
        <td class="CelulaCampoCadastro" colspan="4">
           Recebe E-mail de Cobrança
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            &nbsp;</td>
        <td colspan="3" style="text-align: center">
            <asp:Button ID="BtnGravar" runat="server" CssClass="Botao" Text="Gravar" />
        &nbsp;
            <asp:Button ID="BtnVoltar" runat="server" CssClass="Botao" Text="Voltar" 
                Visible="False" />
        &nbsp;<input id="btnCancel" class="Botao" onclick="cancel();" 
                                style="border-style: none; font-family: verdana; text-decoration: underline; text-align: center;" 
                                type="button" value="Fechar" /></td>
        <td style="text-align: right">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="text-align: right">
            &nbsp;</td>
        <td colspan="3" style="text-align: center">
            &nbsp;</td>
        <td style="text-align: right">
            &nbsp;</td>
    </tr>
</table>
</body>