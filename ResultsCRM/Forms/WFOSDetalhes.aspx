<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFOSDetalhes.aspx.vb" Inherits="ResultsCRM.WFOSDetalhes" %>

<%@ Register src="../UserControls/WUCFrame.ascx" tagname="WUCFrame" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body style="padding: 0px; width: 100%; text-align: left; top: 0px; height: 455px; min-height: 100%; margin: 0px; clip: rect(auto auto auto auto)">
    <form id="form1" runat="server" style="height:100%">
    
       <table style="width: 100%; border-collapse: collapse;">
            <tr>
                <td style="border: thin ridge #CCCCCC; width: 100%; ">
    
        <asp:Menu ID="MnuTabs" runat="server" Orientation="Horizontal" Font-Names="Verdana" 
                Font-Size="7pt" Font-Underline="False" RenderingMode="List">
            <StaticHoverStyle BackColor="#E1E1E1"/>
            <StaticSelectedStyle BackColor="#E1E1E1" 
                Font-Bold="False" Font-Italic="False" Font-Underline="True"/>
            <StaticMenuItemStyle ForeColor="#333333" BorderStyle="None" 
                HorizontalPadding="4px" VerticalPadding="3px" />
            <Items>
                <asp:MenuItem Text="Serv. Realizados" 
                    Value="WGOSItem.aspx" Selected="True"></asp:MenuItem>
                <asp:MenuItem Text="Técnicos" 
                    Value="WGOSAgenteTecnico.aspx?tt=1"></asp:MenuItem>
<asp:MenuItem Text="Serv. Solicitados" Value="WGOSSolicitacao.aspx"></asp:MenuItem>
<asp:MenuItem Text="Causas" Value="WGOSCausa.aspx"></asp:MenuItem>
                <asp:MenuItem Text="Materiais" 
                    Value="WFOSMaterialDetalhes.aspx">
                </asp:MenuItem>
                <asp:MenuItem Text="Imagens" Value="WGOSImagem.aspx">
                </asp:MenuItem>
                <asp:MenuItem Text="Follow-Up" Value="WGOSFollowUP.aspx"></asp:MenuItem>
                <asp:MenuItem Text="Despesas Acessórias" Value="WGOSDespesa.aspx">
                </asp:MenuItem>
                <asp:MenuItem Text="Nota Fiscal" Value="WGOSNF.aspx"></asp:MenuItem>
            </Items>
        </asp:Menu>
    
                </td>
            </tr>
            <tr>
                <td style="padding: 0px; margin: 0px; border: thin ridge #CCCCCC; width: 50%; height: 455px">
                    <uc2:WUCFrame ID="FrameDetalhe" runat="server" /></td>
            </tr>
            </table>
    </form>
</body>
</html>
