<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFOS.aspx.vb" Inherits="ResultsCRM.WFOS" %>

<%@ Register src="../UserControls/WUCFrame.ascx" tagname="WUCFrame" tagprefix="uc2" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Ordem de Serviço</title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
    </head>
<body style="padding: 0px; width: 100%; text-align: left; top: 0px; height: 100vh; min-height: 100%; margin: 0px; clip: rect(auto auto auto auto)">
    <form id="form1" runat="server" style="height:100%">
    
       <table style="width: 100%;">
            <tr>
                <td class="TituloMovimento">
    
                    Ordem de Serviço</td>
            </tr>
            <tr>
                <td>
    
        <asp:Menu ID="MnuTabs" runat="server" Orientation="Horizontal" Font-Names="Verdana" 
                Font-Size="8pt" Font-Underline="False" RenderingMode="List">
            <StaticHoverStyle Font-Names="Verdana" BackColor="#DFEFFF"/>
            <StaticSelectedStyle Font-Names="Verdana" BackColor="#DFEFFF" 
                Font-Bold="False" Font-Italic="False" Font-Underline="False"/>
            <StaticMenuItemStyle ForeColor="#333333" BorderStyle="None" 
                HorizontalPadding="5px" VerticalPadding="5px" />
            <Items>
                <asp:MenuItem Text="OS" 
                    Value="WFOSCabecalho.aspx" Selected="True"></asp:MenuItem>
                <asp:MenuItem Text="Serv. Realizados" Value="WGOSItem.aspx"></asp:MenuItem>
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
                <asp:MenuItem NavigateUrl="~/Forms/WGOrdemServico.aspx" Text="Voltar" 
                    Value="Voltar"></asp:MenuItem>
            </Items>
        </asp:Menu>
    
                </td>
            </tr>
            <tr>
                <td style="border: thin ridge #CCCCCC; width: 100%; height: calc(100vh - 65px)">
                    <uc2:WUCFrame ID="FrameSuperior" runat="server" /></td>
            </tr>
            </table>
    </form>
</body>
</html>
