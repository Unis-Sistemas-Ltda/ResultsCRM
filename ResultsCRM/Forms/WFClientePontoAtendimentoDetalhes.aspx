﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFClientePontoAtendimentoDetalhes.aspx.vb" Inherits="ResultsCRM.WFClientePontoAtendimentoDetalhes" %>

<%@ Register src="../UserControls/WUCFrame.ascx" tagname="WUCFrame" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
</head>
<body style="padding: 0px; width: 100%; text-align: left; top: 0px; height: 400px; min-height: 100%; margin: 0px; clip: rect(auto auto auto auto)">
    <form id="form1" runat="server">
    <table style="width: 100%;">
            <tr>
                <td style="border: thin ridge #CCCCCC; width: 100%; ">
    
        <asp:Menu ID="MnuTabs" runat="server" Orientation="Horizontal" Font-Names="Verdana" 
                Font-Size="0.8em" Font-Underline="False" BackColor="#F7F6F3" 
                        DynamicHorizontalOffset="2" ForeColor="#7C6F57" StaticSubMenuIndent="10px">
            <DynamicHoverStyle BackColor="#7C6F57" ForeColor="White" />
            <DynamicMenuStyle BackColor="#F7F6F3" />
            <DynamicSelectedStyle BackColor="#5D7B9D" />
            <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
            <StaticHoverStyle Font-Names="Verdana" Font-Size="9pt" BackColor="#E1E1E1"/>
            <StaticSelectedStyle Font-Names="Verdana" Font-Size="9pt" BackColor="#5D7B9D" 
                Font-Bold="True" Font-Italic="False" Font-Underline="True"/>
            <StaticMenuItemStyle ForeColor="#333333" BorderStyle="None" 
                HorizontalPadding="5px" VerticalPadding="2px" />
            <Items>
                <asp:MenuItem Text="Cadastro&nbsp;" 
                    Value="WFClientePontoAtendimento.aspx?embeeded=False&amp;vcodemi=SCodEmitente&amp;vcodemp=SCodClientePesquisado&amp;valtecc=SAlterouCodCliente&amp;vrecdc=SRecarregaDdlContatos&amp;ccodcon=SCodContatoNegociacao&amp;ptat=SNumeroPontoAtendimento&amp;vcodemin=SCodEmitente"></asp:MenuItem>
                <asp:MenuItem Text=" Histórico&nbsp;" 
                    
                    Value="WFConsultaHistoricoPontoAtendimento.aspx">
                </asp:MenuItem>
                <asp:MenuItem Text="&nbsp;Equipamentos&nbsp;" Value="WGClienteEquipamento.aspx">
                </asp:MenuItem>
            </Items>
        </asp:Menu>
    
                </td>
                <td>
    
                    <asp:Button ID="BtnVoltar" cssclass="Botao" runat="server" Text="Voltar" />
    
                </td>
            </tr>
            <tr>
                <td style="border: thin ridge #CCCCCC; width: 45%; height: 422px" colspan="2">
                    <uc2:WUCFrame ID="FrameDetalhe" runat="server" /></td>
            </tr>
            </table>
    </form>
</body>
</html>
