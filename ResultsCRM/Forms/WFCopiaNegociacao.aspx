<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFCopiaNegociacao.aspx.vb" Inherits="ResultsCRM.WFCopiaNegociacao" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="TituloMovimento">
        Confirmação de Cópia da Negociação</div>
    <div class="TextoCadastro_BGBranco" style="text-align: center; font-size: 9pt;">
        <br />
        <br />
        Caro usuário,<br />
        <br />
        <br />
        Deseja realmente gerar uma nova negociação a partir da negociação nº
        <asp:Label ID="LblNegociacao" runat="server" Font-Bold="True"></asp:Label>
        ?<br />
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" CssClass="Botao" Font-Size="9pt" 
            Text="Não" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="BtnSim" runat="server" CssClass="Botao" Font-Size="9pt" 
            Text="Sim" />
        <br />
        <br />
        <asp:Label ID="LblErro" runat="server" CssClass="Erro"></asp:Label>
        <asp:Label ID="LblClicouNoSim" runat="server" Text="False" Visible="False"></asp:Label>
        <asp:Label ID="LblNovaNeg" runat="server" Visible="False"></asp:Label>
        <br />
    </div>
    </form>
</body>
</html>
