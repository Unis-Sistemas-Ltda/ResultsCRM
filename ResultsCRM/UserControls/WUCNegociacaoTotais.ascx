<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCNegociacaoTotais.ascx.vb" Inherits="ResultsCRM.WUCNegociacaoTotais" %>
<link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
<body class="TextoCadastro_BGBranco" style="border-style: none; padding: 0px; margin: 0px;">
<table style="border-width: 1px; border-color: #CCCCCC; border-style: solid none none none; padding: 0px; margin: 0px; width:100%; border-collapse: collapse; background-color: #F4F4F4;">
    <tr>
        <td 
            
            style="text-align: left; font-size: 8pt; font-weight: bold;">
            TOTAIS</td>
        <td 
            
            style="text-align: right; ">
            &nbsp;ICMS: R$</td>
        <td>
            <asp:Label ID="LblTotalICMS" runat="server" Font-Bold="True" Text="0,00" 
                Font-Size="8pt"></asp:Label>
        </td>
        <td 
            
            style="text-align: left; font-size: 8pt; font-weight: bold;">
            &nbsp;</td>
        <td 
            
            style="text-align: right; ">
            ICMS ST: R$</td>
        <td 
            
            style="text-align: left; font-size: 8pt; font-weight: bold;">
            <asp:Label ID="LblTotalICMSST" runat="server" Font-Bold="True" Text="0,00" 
                Font-Size="8pt"></asp:Label>
        </td>
        <td 
            
            style="text-align: right; ">
            Total IPI: R$</td>
        <td 
            
            style="text-align: left; font-size: 8pt; font-weight: bold;">
            &nbsp;<asp:Label ID="LblTotalIPI" runat="server" Font-Bold="True" Text="0,00" 
                Font-Size="8pt"></asp:Label>
        </td>
        <td 
            
            style="text-align: right; ">
            &nbsp;Desconto: R$</td>
        <td 
            
            style="text-align: left; font-size: 8pt; font-weight: bold;">
            <asp:Label ID="LblTotalDesconto" runat="server" Font-Bold="True" Text="0,00" 
                Font-Size="8pt"></asp:Label>
        </td>
        <td 
            
            style="text-align: right; ">
            Total Mercadoria: R$</td>
        <td 
            
            style="text-align: left; font-size: 8pt; font-weight: bold;">
            <asp:Label ID="LblTotalMercadoria" runat="server" Font-Bold="True" Text="0,00" 
                Font-Size="8pt"></asp:Label>
        </td>
        <td 
            
            style="text-align: right; ">
            Total Geral: R$</td>
        <td 
            
            style="text-align: left; font-size: 8pt; font-weight: bold;">
            <asp:Label ID="LblTotalGeral" runat="server" Font-Bold="True" Font-Size="8pt" 
                Text="0,00"></asp:Label>
        </td>
    </tr>
    </table>
</body>