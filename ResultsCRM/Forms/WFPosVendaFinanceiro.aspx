<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFPosVendaFinanceiro.aspx.vb" Inherits="ResultsCRM.WFPosVendaFinanceiro" %>

<%@ Register src="../UserControls/WUCFrame.ascx" tagname="WUCFrame" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

.Botao
{
    background-position: 100% 100%;
    font-size: 7pt;
    font-weight: bold;
    text-align: center;
    color: #666666;
    font-family: verdana;
    background-color: #CCCCCC;
    }
    </style>
</head>
<body style="margin:0px">
    <form id="form1" runat="server">
    <div>
    
        <table style="width: 100%;">
            <tr>
                <td style="border: thin ridge #CCCCCC; ">
    
        <asp:Menu ID="MnuTabs" runat="server" Orientation="Horizontal" Font-Names="Verdana" 
                Font-Size="0.8em" Font-Underline="False" BackColor="#F7F6F3" 
                        DynamicHorizontalOffset="2" ForeColor="#7C6F57" StaticSubMenuIndent="10px">
            <DynamicHoverStyle BackColor="#7C6F57" ForeColor="White" />
            <DynamicMenuStyle BackColor="#F7F6F3" />
            <DynamicSelectedStyle BackColor="#5D7B9D" />
            <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
            <StaticHoverStyle Font-Names="Verdana" Font-Size="9pt" BackColor="#E1E1E1"/>
            <StaticSelectedStyle Font-Names="Verdana" Font-Size="9pt" BackColor="#5D7B9D" 
                Font-Bold="True" Font-Italic="False" Font-Underline="True"/>
            <StaticMenuItemStyle ForeColor="#333333" BorderStyle="None" 
                HorizontalPadding="5px" VerticalPadding="2px" />
            <Items>
                <asp:MenuItem Text="&nbsp;Títulos Em Aberto&nbsp;" 
                    
                    Value="WGPosVendaFinanceiroAbertos.aspx"></asp:MenuItem>
                <asp:MenuItem Text="&nbsp;Títulos Liquidados&nbsp;" 
                    
                    Value="WGPosVendaFinanceiroLiquidados.aspx">
                </asp:MenuItem>
            </Items>
        </asp:Menu>
    
                </td>
            </tr>
            <tr>
                <td style="border: thin ridge #CCCCCC; width: 100%; height: 415px">
                    <uc1:WUCFrame ID="FrameDetalhes" runat="server" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
