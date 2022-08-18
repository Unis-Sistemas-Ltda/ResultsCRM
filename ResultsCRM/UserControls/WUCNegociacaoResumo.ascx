<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCNegociacaoResumo.ascx.vb" Inherits="ResultsCRM.WUCNegociacaoResumo" %>
<link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
<body class="TextoCadastro_BGBranco" style="border-style: 0; padding: 0px; margin: 0px;">
<table style="padding: 0px; margin: 0px; width:100%; border-collapse: collapse; font-size: 7pt; background-color: #FEFFF2;">
    <tr>
        <td 
            
            style="text-align: right; width: 110px;">
            Nº Negociação:</td>
        <td 
            
            style="font-size: 7pt; width: 70px;">
            <asp:Label ID="LblCodNegociacao" runat="server" Text="0"></asp:Label>
        </td>
        <td style="text-align: right; width: 70px;">
            Cliente:</td>
        <td>
            <asp:Label ID="LblCliente" runat="server"></asp:Label>
        </td>
    </tr>
    </table>
</body>