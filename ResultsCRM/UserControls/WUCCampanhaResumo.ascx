<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCCampanhaResumo.ascx.vb" Inherits="ResultsCRM.WUCCampanhaResumo" %>
<link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
<body class="TextoCadastro_BGBranco" style="border-style: 0; padding: 0px; margin: 0px;">
<table style="padding: 0px; margin: 0px; width:100%; border-collapse: collapse; font-size: 7pt; background-color: #FEFFF2;">
    <tr>
        <td 
            
            style="text-align: right; width: 110px;">
            Cód. Campanha:</td>
        <td 
            
            style="font-size: 7pt; width: 70px;">
            <asp:Label ID="LblCodCampanha" runat="server" Text="0"></asp:Label>
        </td>
        <td style="text-align: right; width: 70px;">
            Descrição:</td>
        <td>
            <asp:Label ID="LblDescricaoCampanha" runat="server"></asp:Label>
        </td>
    </tr>
    </table>
</body>