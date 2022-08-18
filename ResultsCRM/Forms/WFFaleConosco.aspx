<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFFaleConosco.aspx.vb" Inherits="ResultsCRM.WFFaleConosco" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Contato</title>
    <script language="javascript" src="../ResultsCRM.js" type="text/javascript"></script>
    <style type="text/css">

.CampoCadastro
{
    font-size: 7pt;
    height: 18px;
    font-family: verdana;
    color: #666666;
    text-align: left;
}
body
{
    height: 100%
}
    </style>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <table style="width:100%;">
            <tr>
                <td style="width: 100px">
                    <img alt="" src="../Imagens/logo_cliente.jpg" 
                        style="width: 60px; height: 60px" /></td>
                <td style="text-align: right">
                    &nbsp;</td>
                <td style="text-align: right; width: 100px;">
                    <img alt="Unis Sistemas" src="../Imagens/unis.jpg" 
                        style="width: 60px; height: 57px" /></td>
            </tr>
        </table>
        <div class="TituloMovimento">
            Formulário de Contato
        </div>
        <table style="width:100%;" class="TextoCadastro_BGBranco">
            <tr>
                <td class="Erro" colspan="2" 
                    style="border: 1px solid #FFFF66; color: #0000FF; background-color: #FFFFCC; text-align: center">
                    <asp:Label ID="LblErro" runat="server"></asp:Label>
                    <asp:Label ID="LblCodCanalVendaPadrao" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="LblCodEtapaPadrao" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="LblCodFontePadrao" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="LblCodAcaoPadrao" runat="server" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    *Nome:</td>
                <td>
                    <asp:TextBox ID="TxtNome" runat="server" CssClass="CampoCadastro" Width="350px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    *Telefone:</td>
                <td>
                    <asp:TextBox ID="TxtFone1" runat="server" CssClass="CampoCadastro" Width="100px"></asp:TextBox>
                    &nbsp;
                    <asp:Label ID="LblInstrufone0" runat="server" Height="17px">Telefone 2:</asp:Label>
                    <asp:TextBox ID="TxtFone2" runat="server" CssClass="CampoCadastro" Width="100px"></asp:TextBox>
                &nbsp;<asp:Label ID="LblInstrufone" runat="server" ForeColor="#6699FF" 
                        Height="17px">Ex: (48)9999-9999</asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    *E-mail:</td>
                <td>
                    <asp:TextBox ID="TxtEmail" runat="server" CssClass="CampoCadastro" 
                        Width="260px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    CNPJ/CPF:</td>
                <td>
                    <asp:TextBox ID="TxtCNPJ" runat="server" CssClass="CampoCadastro" Width="125px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    Logradouro:</td>
                <td>
                    <asp:TextBox ID="TxtLogradouro" runat="server" CssClass="CampoCadastro" 
                        Width="260px"></asp:TextBox>
                    <asp:Label ID="Label1" runat="server" Height="16px" Text="Nº:"></asp:Label>
                    <asp:TextBox ID="TxtNumero" runat="server" CssClass="CampoCadastro" 
                        Width="65px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    Bairro:</td>
                <td>
                    <asp:TextBox ID="TxtBairro" runat="server" CssClass="CampoCadastro" 
                        Width="260px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    Estado:</td>
                <td>
                    <asp:DropDownList ID="DdlEstado" runat="server" CssClass="CampoCadastro" 
                        Width="260px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    Cidade:</td>
                <td>
                    <asp:DropDownList ID="DdlCidade" runat="server" CssClass="CampoCadastro" 
                        Width="260px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; vertical-align: top">
                    Mensagem:</td>
                <td>
                    <asp:TextBox ID="TxtMensagem" runat="server" CssClass="CampoCadastro" 
                        Height="150px" TextMode="MultiLine" Width="350px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; vertical-align: top">
                    &nbsp;</td>
                <td>
                    <asp:Button ID="BtnEnviar" runat="server" CssClass="Botao" Text="Enviar" 
                        Width="90px" />
&nbsp;
                    <asp:Button ID="BtnLimparCampos" runat="server" CssClass="Botao" 
                        Text="Limpar Campos" Width="95px" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
