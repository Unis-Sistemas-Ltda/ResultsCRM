<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFTrocaSenha.aspx.vb" Inherits="ResultsCRM.WFTrocaSenha" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <table style="width:100%;" class="TextoCadastro_BGBranco">
        <tr>
            <td class="TituloCadastro" colspan="2">
                Alteração da Senha de Acesso</td>
        </tr>
        <tr>
            <td colspan="2">
                Informe abaixo a senha atual, a nova senha e confirme a nova senha.<br />
                Ao término clique em <b><i>Alterar Senha</i></b>.</td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="LblErro" runat="server" CssClass="Erro"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                Senha atual:</td>
            <td>
                <asp:TextBox ID="TxtSenhaAtual" runat="server" CssClass="CampoCadastro" 
                    TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                Nova senha:</td>
            <td>
                <asp:TextBox ID="TxtNovaSenha" runat="server" CssClass="CampoCadastro" 
                    TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                Confirme a nova senha:</td>
            <td>
                <asp:TextBox ID="TxtConfirmaNovaSenha" runat="server" CssClass="CampoCadastro" 
                    TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:Button ID="BtnGravar" runat="server" CssClass="Botao" 
                    Text="Alterar Senha" 
                    onclientclick="return confirm('Deseja realmente alterar sua senha?');" />
            </td>
        </tr>
    </table>
    </form>
    
</body>
</html>
