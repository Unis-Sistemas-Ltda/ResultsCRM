<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFCampanhaDetalhes.aspx.vb" Inherits="ResultsCRM.WFCampanhaDetalhes" %>

<%@ Register src="../UserControls/WUCFrame.ascx" tagname="WUCFrame" tagprefix="uc2" %>

<%@ Register src="../UserControls/WUCNegociacaoTotais.ascx" tagname="WUCNegociacaoTotais" tagprefix="uc1" %>

<%@ Register src="../UserControls/WUCCampanhaResumo.ascx" tagname="WUCCampanhaResumo" tagprefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
</head>
<body style="padding: 0px; width: 100%; text-align: left; top: 0px; height: 455px; min-height: 100%; margin: 0px; clip: rect(auto auto auto auto)">
    <form id="form1" runat="server" style="height:100%">
    
       <table style="width: 100%; border-collapse: collapse;">
            <tr>
                <td class="TituloMovimento">
    
                    Detalhe da Campanha</td>
            </tr>
            <tr>
                <td style="padding: 0px; margin: 0px; border-style: solid none solid none; border-width: 1px; border-color: #CCCCCC; width: 100%; ">
    
        <asp:Menu ID="MnuTabs" runat="server" Orientation="Horizontal" Font-Names="Verdana" 
                Font-Size="8pt" Font-Underline="False" RenderingMode="List">
            <StaticHoverStyle Font-Names="Verdana" BackColor="#DFEFFF"/>
            <StaticSelectedStyle Font-Names="Verdana" BackColor="#DFEFFF" 
                Font-Bold="False" Font-Italic="False" Font-Underline="False"/>
            <StaticMenuItemStyle ForeColor="#333333" BorderStyle="None" 
                HorizontalPadding="5px" VerticalPadding="5px" />
            <Items>
                <asp:MenuItem Selected="True" Text="&nbsp;Campanha&nbsp;" 
                    Value="WFCampanhaCabecalho.aspx"></asp:MenuItem>
                <asp:MenuItem Text="&nbsp;Contatos&nbsp;" Value="WGCampanhaContato.aspx"></asp:MenuItem>
                <asp:MenuItem Text="&nbsp;Voltar&nbsp;" 
                    Value="Voltar" NavigateUrl="~/Forms/WGTefGrupo.aspx">
                </asp:MenuItem>
            </Items>
        </asp:Menu>
    
                </td>
            </tr>
            <tr>
                <td style="border-style: solid none none none; border-width: 1px; border-color: #CCCCCC; width: 100%;">
    
                    <uc3:WUCCampanhaResumo ID="WUCCampanhaResumo1" runat="server" 
                        Visible="False" />
    
                </td>
            </tr>
            <tr>
                <td style="width: 50%; height: 440px">
                    <uc2:WUCFrame ID="FrameDetalhe" runat="server" /></td>
            </tr>
            </table>
    </form>
</body>

</html>
