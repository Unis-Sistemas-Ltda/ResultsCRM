<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFAtendimentoDetalhes.aspx.vb" Inherits="ResultsCRM.WFAtendimentoDetalhes" %>

<%@ Register src="../UserControls/WUCFrame.ascx" tagname="WUCFrame" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body style="padding: 0px; width: 100%; text-align: left; top: 0px; height: 455px; min-height: 100%; margin: 0px; clip: rect(auto auto auto auto)">
    <form id="form1" runat="server" style="height:100%">
    
       <table style="width: 100%;">
            <tr>
                <td style="border: thin ridge #CCCCCC; width: 100%; ">
    
        <asp:Menu ID="MnuTabs" runat="server" Orientation="Horizontal" Font-Names="Verdana" 
                Font-Size="8pt" Font-Underline="False" 
                        DynamicHorizontalOffset="2" ForeColor="#7C6F57" StaticSubMenuIndent="10px">
            <DynamicHoverStyle BackColor="#7C6F57" ForeColor="White" />
            <DynamicMenuStyle BackColor="#F7F6F3" />
            <DynamicSelectedStyle BackColor="#5D7B9D" />
            <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
            <StaticHoverStyle Font-Names="Verdana" Font-Size="8pt" BackColor="#E1E1E1"/>
            <StaticSelectedStyle Font-Names="Verdana" Font-Size="8pt" BackColor="#E9E9E9" 
                Font-Bold="True" Font-Italic="False" Font-Underline="True"/>
            <StaticMenuItemStyle ForeColor="#333333" BorderStyle="None" 
                HorizontalPadding="5px" VerticalPadding="2px" />
            <Items>
                <asp:MenuItem Text="Follow-Up" Value="WGAtendimentoFollowUp.aspx"></asp:MenuItem>
                <asp:MenuItem Text="E-mail" 
                    Value=" WFAtendimentoEmailDetalhes.aspx"></asp:MenuItem>
                <asp:MenuItem Text="Histórico" 
                    Value=" WGAtendimentoHistorico.aspx"></asp:MenuItem>
                <asp:MenuItem Text="OS" Value="WGAtendimentoPedido.aspx"></asp:MenuItem>
                <asp:MenuItem Text="SD" Value="WGAtendimentoSolicitacao.aspx"></asp:MenuItem>
                <asp:MenuItem Text="PA" Value="WFAtendimentoConsultaHistoricoPA.aspx">
                </asp:MenuItem>
            </Items>
        </asp:Menu>
    
                </td>
            </tr>
            <tr>
                <td style="border: thin ridge #CCCCCC; width: 50%; height: 455px">
                    <uc2:WUCFrame ID="FrameDetalhe" runat="server" /></td>
            </tr>
            </table>
    </form>
</body>
</html>
