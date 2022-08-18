<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGEmail2.aspx.vb" Inherits="ResultsCRM.WGEmail2" %>

<%@ Register src="../UserControls/WUCFrame.ascx" tagname="WUCFrame" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
</head>
<body id="body1" runat="server" style="padding: 0px; width: 100%; text-align: left; top: 0px; height:100%; min-height: 100%; margin: 0px; clip: rect(auto auto auto auto)">
    <form id="form1" runat="server">
    <table style="width: calc(100% - 5px); height: 100%; border-collapse: collapse;">
        <tr>
            <td class="TituloMovimento" colspan="2">
                E-mails</td>
        </tr>
        <tr>
            <td style="vertical-align: top" width="140">
                <asp:Label ID="LblMenuSelecionado" runat="server" Visible="False"></asp:Label>
                <asp:Menu ID="MnuTabs" runat="server" Font-Names="Verdana" 
                Font-Size="8pt" Font-Underline="False" RenderingMode="List" Width="135px">
                <StaticHoverStyle Font-Names="Verdana" BackColor="#DFEFFF"/>
                <StaticSelectedStyle Font-Names="Verdana" BackColor="#DFEFFF" 
                    Font-Bold="False" Font-Italic="False" Font-Underline="False"/>
                <StaticMenuItemStyle ForeColor="#333333" BorderStyle="None" 
                    HorizontalPadding="5px" VerticalPadding="5px" />
                <Items>
                    <asp:MenuItem Text="Novo E-mail" Value="!"></asp:MenuItem>
                    <asp:MenuItem Text="Entrada" Value="WGEmail3.aspx?t=4&tc=0&cc=0" Selected="True"></asp:MenuItem>
                    <asp:MenuItem Text="Arquivados" Value="WGEmail3.aspx?t=3&tc=0&cc=0"></asp:MenuItem>
                    <asp:MenuItem Text="Rascunhos" Value="WGEmail3.aspx?t=0&tc=0&cc=0"></asp:MenuItem>
                    <asp:MenuItem Text="Saída" Value="WGEmail3.aspx?t=1&tc=0&cc=0"></asp:MenuItem>
                    <asp:MenuItem Text="Enviados" Value="WGEmail3.aspx?t=2&tc=0&cc=0"></asp:MenuItem>
                    <asp:MenuItem Text="Todos os E-mails" Value="WGEmail3.aspx?t=9&tc=0&cc=0"></asp:MenuItem>
                    <asp:MenuItem Text="Lixeira" Value="WGEmail3.aspx?t=6&tc=0&cc=0"></asp:MenuItem>
                    <asp:MenuItem Text="Não Enviados" Value="WGEmail3.aspx?t=5&tc=0&cc=0"></asp:MenuItem>
                    <asp:MenuItem Text="Atualizar" Value="#"></asp:MenuItem>
                </Items>
            </asp:Menu>
                <br />
                <asp:Menu ID="MnuMarcadores" runat="server" Font-Names="Verdana" 
                Font-Size="8pt" Font-Underline="False" RenderingMode="List" Width="135px">
                    <Items>
                        <asp:MenuItem Selected="True" Text="Todos os marcadores" Value="0">
                        </asp:MenuItem>
                    </Items>
                <StaticHoverStyle Font-Names="Verdana" BackColor="#DFEFFF"/>
                <StaticSelectedStyle Font-Names="Verdana" BackColor="#DFEFFF" 
                    Font-Bold="False" Font-Italic="False" Font-Underline="False"/>
                <StaticMenuItemStyle ForeColor="#333333" BorderStyle="None" 
                    HorizontalPadding="5px" VerticalPadding="5px" />
                <DynamicHoverStyle Font-Names="Verdana" BackColor="#DFEFFF"/>
                <DynamicSelectedStyle Font-Names="Verdana" BackColor="#DFEFFF" 
                    Font-Bold="False" Font-Italic="False" Font-Underline="False"/>
                <DynamicMenuItemStyle ForeColor="#333333" BorderStyle="None" BackColor="#FFFFFF"
                    HorizontalPadding="10px" VerticalPadding="5px" />
                </asp:Menu>
            </td>
            <td id="tdframemeio" 
                
                
                style="border-style: none none solid solid; border-width: 1px; border-color: #CCCCCC; padding: 0px; margin: 0px; vertical-align: top; height: calc(100vh - 48px);">
                    <uc2:WUCFrame ID="FrameSuperior" runat="server" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
