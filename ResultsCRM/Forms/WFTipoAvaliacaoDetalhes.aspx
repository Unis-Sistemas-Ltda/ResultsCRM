<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFTipoAvaliacaoDetalhes.aspx.vb" Inherits="ResultsCRM.WFTipoAvaliacaoDetalhes" %>

<%@ Register Src="../UserControls/WUCFrame.ascx" TagName="WUCFrame" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head2" runat="server">
    <title>Untitled Page</title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
</head>
<body id="bodyAtendimento" runat="server" style="padding: 0px; width: 100%; text-align: left;
    top: 0px; min-height: 100%; margin: 0px; clip: rect(auto auto auto auto)">
    <form id="form2" runat="server" style="width: 100%">
    <table style="width: 100%; height: 100vh">
        <tr>
            <td class="TituloMovimento">
                Detalhe do Tipo de Avaliação
            </td>
        </tr>
        <tr>
            <td>
                <asp:Menu ID="MnuTabs" runat="server" Orientation="Horizontal" Font-Names="Verdana"
                    Font-Size="8pt" Font-Underline="False" RenderingMode="List">
                    <StaticHoverStyle Font-Names="Verdana" BackColor="#DFEFFF" />
                    <StaticSelectedStyle Font-Names="Verdana" BackColor="#DFEFFF" Font-Bold="False" Font-Italic="False"
                        Font-Underline="False" />
                    <StaticMenuItemStyle ForeColor="#333333" BorderStyle="None" HorizontalPadding="5px"
                        VerticalPadding="5px" />
                    <Items>
                        <asp:MenuItem Text="Tipo Avaliação" Value="WFTipoAvaliacao.aspx" 
                            Selected="True">
                        </asp:MenuItem>
                        <asp:MenuItem Text="Itens Avaliados" Value="WGItemAvaliado.aspx"></asp:MenuItem>
                        <asp:MenuItem Text="Voltar" Value="#"></asp:MenuItem>
                    </Items>
                </asp:Menu>
            </td>
        </tr>
        <tr style="width: 100%;">
            <td id="tdframesuperior" style="width: 100%; height: calc(100vh - 65px);">
                <uc2:WUCFrame ID="FrameSuperior" runat="server" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>