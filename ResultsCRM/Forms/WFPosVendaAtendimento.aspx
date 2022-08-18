<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFPosVendaAtendimento.aspx.vb"
    Inherits="ResultsCRM.WFPosVendaAtendimento" %>

<%@ Register Src="../UserControls/WUCFrame.ascx" TagName="WUCFrame" TagPrefix="uc1" %>
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
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
</head>
<body style="margin: 0px">
    <form id="form1" runat="server">
    <div>
        <table style="width: 100%; border-collapse: collapse;">
            <tr>
                <td>
                    <table class="TextoCadastro_BGBranco" style="width: 100%; border-collapse: collapse;">
                        <tr>
                            <td style="font-size: 8pt">
                                <asp:Menu ID="MnuTabs" runat="server" Orientation="Horizontal" Font-Names="Verdana"
                                    Font-Size="8pt" Font-Underline="False" RenderingMode="List">
                                    <StaticHoverStyle Font-Names="Verdana" BackColor="#DFEFFF" />
                                    <StaticSelectedStyle Font-Names="Verdana" BackColor="#DFEFFF" Font-Bold="False" Font-Italic="False"
                                        Font-Underline="False" />
                                    <StaticMenuItemStyle ForeColor="#333333" BorderStyle="None" HorizontalPadding="5px"
                                        VerticalPadding="5px" />
                                    <Items>
                                        <asp:MenuItem Text="&nbsp;Chamado&nbsp;" 
                                            Value="WFAtendimentoCabecalho_Suporte.aspx" Selected="True">
                                        </asp:MenuItem>
                                        <asp:MenuItem Text="&nbsp;Follow-Up&nbsp;" Value="WGAtendimentoFollowUp.aspx"></asp:MenuItem>
                                        <asp:MenuItem Text="&nbsp;E-mails&nbsp;" Value="WFAtendimentoEmailDetalhes.aspx">
                                        </asp:MenuItem>
                                    </Items>
                                </asp:Menu>
                            </td>
                            <td style="text-align: right">
                                <asp:Button ID="BtnVoltar" runat="server" CssClass="Botao" Text="Voltar" Visible="False" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="border-style: none; width: 100%; height: calc(100vh - 50px)">
                    <uc1:WUCFrame ID="FrameDetalhes" runat="server" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
