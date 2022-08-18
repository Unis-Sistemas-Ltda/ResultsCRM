<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFLogin.aspx.vb" Inherits="ResultsCRM.WFLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Acesso Restrito</title>
    <link href="ResultsCRM.css" rel="stylesheet" type="text/css" />
    </head>
<body style="padding: 0; margin: 0">
    <form id="form1" runat="server">

    <table style="padding: 0px; margin: 0px; width: 100%; border-collapse: collapse;" 
        class="TextoCadastro_BGBranco">
        <tr>
            <td colspan="2" align="center" style="background-color: #FFFFFF">
                <br />
                <img alt="" src="Imagens/ImgAcesso.png" style="width: 726px; height: 438px" /><img 
                    alt="" src="Imagens/unis.jpg" 
                    style="width: 126px; height: 109px; position: absolute; top: 320px; right: 32%;" /></td>
        </tr>
        <tr>
            <td colspan="2" align="center" 
                
                
                style="background-image: url('Imagens/listelo.png'); background-repeat: repeat-x">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;</td>
        </tr>
        <tr class="Titulo2">
            <td colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 40%;">
                &nbsp;</td>
            <td class="Titulo2" style="text-align: left">
                <b>ACESSO RESTRITO</b></td>
        </tr>
        <tr>
            <td style="text-align: right" colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: right; font-size: 8pt;">
                Usuário:</td>
            <td class="CampoCadastro">
                <asp:TextBox ID="TxtUsuario" runat="server" Width="115px" 
                    CssClass="CampoCadastro" Font-Size="9pt" ForeColor="Black"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style7" style="text-align: right; font-size: 8pt;">
                Senha:</td>
            <td class="CampoCadastro">
                <asp:TextBox ID="TxtSenha" runat="server" TextMode="Password" 
                    Width="115px" CssClass="CampoCadastro" Font-Size="9pt" ForeColor="Black"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style9">
                </td>
            <td class="Erro">
                <asp:Label ID="LblErro" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style7">
                &nbsp;</td>
            <td class="CampoCadastro">
                <asp:Button ID="BtnConectar" runat="server" Text="Conectar" CssClass="Botao" 
                    Font-Size="8pt" />
            </td>
        </tr>
        <tr>
            <td class="style7">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style7">
                &nbsp;</td>
            <td style="font-size: 8pt">
                Sua senha protege você e sua empresa contra acessos indevidos aos seus 
                dados.<br />
                Mantenha-a em sigilo!</td>
        </tr>
    </table>

    </form>
    </body>
</html>
