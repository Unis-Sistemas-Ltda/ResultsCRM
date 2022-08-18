<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFPosVendaDetalhes.aspx.vb" Inherits="ResultsCRM.WFPosVendaDetalhes" %>

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
                Font-Size="8pt" Font-Underline="False">
            <StaticHoverStyle Font-Names="Verdana" Font-Size="9pt" BackColor="#E1E1E1"/>
            <StaticSelectedStyle Font-Names="Verdana" Font-Size="9pt" BackColor="#E1E1E1" 
                Font-Bold="True" Font-Italic="False" Font-Underline="True"/>
            <StaticMenuItemStyle ForeColor="#333333" BorderStyle="None" 
                HorizontalPadding="2px" />
            <Items>
                <asp:MenuItem Text="Atendimentos" Value="WGPosVendaChamados.aspx"></asp:MenuItem>
                <asp:MenuItem Text="SINAMM"  Value="WGPosVendaSINAMM.aspx"></asp:MenuItem>
                <asp:MenuItem Text="SPDO" Value="WGPosVendaSAAFE.aspx"></asp:MenuItem>
                <asp:MenuItem Text="Compras"  Value=" WGPosVendaCompras.aspx"></asp:MenuItem>
                <asp:MenuItem Text="Financeiro"  Value="WFPosVendaFinanceiro.aspx"></asp:MenuItem>
                <asp:MenuItem Text="Contatos" Value="WGPosVendaContatos.aspx"></asp:MenuItem>
                <asp:MenuItem Text="Follow-Up"  Value="WGPosVendaFollowUp.aspx"></asp:MenuItem>
                <asp:MenuItem Text="Convênio" Value="WGPosVendaConvenio.aspx"></asp:MenuItem>
                <asp:MenuItem Text="Negociação" Value="WGPosVendaNegociacao.aspx">
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
