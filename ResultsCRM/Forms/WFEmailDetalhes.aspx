<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFEmailDetalhes.aspx.vb" Inherits="ResultsCRM.WFEmailDetalhes" %>

<%@ Register src="../UserControls/WUCFrame.ascx" tagname="WUCFrame" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
    </head>
<body id="body1" runat="server" style="padding: 0px; width: 100%; text-align: left; top: 0px; min-height: 100%; margin: 0px; clip: rect(auto auto auto auto)">
    <form id="form1" runat="server">
    
       <table style="width: 100%; border-collapse: collapse;">
            <tr>
                <td class="Titulo2">
                    Detalhes do E-mail</td>
            </tr>
            <tr>
                <td>
                <asp:Menu ID="MnuTabs" runat="server" Orientation="Horizontal" Font-Names="Verdana" 
                Font-Size="8pt" Font-Underline="False" RenderingMode="List">
            <StaticHoverStyle Font-Names="Verdana" BackColor="#DFEFFF"/>
            <StaticSelectedStyle Font-Names="Verdana" BackColor="#DFEFFF" 
                Font-Bold="False" Font-Italic="False" Font-Underline="False"/>
            <StaticMenuItemStyle ForeColor="#333333" BorderStyle="None" 
                HorizontalPadding="15px" VerticalPadding="5px" />
                    <DynamicMenuItemStyle BackColor="White" ForeColor="#333333" 
                        HorizontalPadding="15px" VerticalPadding="7px" />
            <DynamicHoverStyle Font-Names="Verdana" BackColor="#DFEFFF"/>
            <DynamicSelectedStyle Font-Names="Verdana" BackColor="#DFEFFF" 
                Font-Bold="False" Font-Italic="False" Font-Underline="False"/>
            <DynamicMenuItemStyle ForeColor="#333333" BorderStyle="None" 
                HorizontalPadding="15px" VerticalPadding="5px" />
                    <DynamicMenuItemStyle BackColor="White" ForeColor="#333333" 
                        HorizontalPadding="15px" VerticalPadding="7px" />
            <Items>
                <asp:MenuItem Text="Mensagem"                        Value="1" Selected="True"></asp:MenuItem>
                <asp:MenuItem Text="Chamado"                      
                    Value="2"></asp:MenuItem>
                <asp:MenuItem Selectable="False" Text="Ações" Value="Ações">
                    <asp:MenuItem Text="Responder" Value="3.1"></asp:MenuItem>
                    <asp:MenuItem Text="Encaminhar" Value="3.2"></asp:MenuItem>
                    <asp:MenuItem Text="Arquivar" Value="3.3"></asp:MenuItem>
                    <asp:MenuItem Text="Mover para Entrada" Value="3.4"></asp:MenuItem>
                    <asp:MenuItem Text="Enviar para Lixeira" Value="3.5"></asp:MenuItem>
                    <asp:MenuItem Text="Restaurar" Value="3.6"></asp:MenuItem>
                    <asp:MenuItem Text="Marcar como lida" Value="3.7"></asp:MenuItem>
                    <asp:MenuItem Text="Marcar como não lida" Value="3.8"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="Marcadores" Value="5"></asp:MenuItem>
                <asp:MenuItem Text="Histórico" Value="4"></asp:MenuItem>
                <asp:MenuItem Text="Voltar" Value="0"></asp:MenuItem>
            </Items>
        </asp:Menu>
                    <asp:Button ID="BtnVoltar" runat="server" BorderStyle="None" BorderWidth="0px" 
                        Height="1px" Text="Voltar" Width="1px" />
                </td>
            </tr>
            <tr>
                <td style="border-style: none; padding: 0px; margin: 0px; height: calc(100vh - 55px)"
                    id="tddetalheemail" runat="server">
                    <uc2:WUCFrame ID="FrameEmail" runat="server" /></td>
            </tr>
            </table>
    </form>
</body>
</html>
