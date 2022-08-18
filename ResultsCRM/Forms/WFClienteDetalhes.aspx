<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFClienteDetalhes.aspx.vb"
    Inherits="ResultsCRM.WFClienteDetalhes" %>

<%@ Register Src="../UserControls/WUCFrame.ascx" TagName="WUCFrame" TagPrefix="uc2" %>
<%@ Register Src="../UserControls/WUCNegociacaoTotais.ascx" TagName="WUCNegociacaoTotais"
    TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
</head>
<body style="padding: 0px; width: 100%; text-align: left; top: 0px; height: 455px;
    min-height: 100%; margin: 0px; clip: rect(auto auto auto auto)">
    <form id="form1" runat="server" style="height: 100%">
    <table style="width: 100%;">
        <tr>
                <td class="TituloMovimento" id="tdTitulo" runat="server">
                        Detalhes do Cliente</td>
            </tr>
        <tr>
            <td style="border-width: 1px; border-color: #CCCCCC; width: 100%;">
                <asp:Menu ID="MnuTabs" runat="server" Orientation="Horizontal" Font-Names="Verdana"
                    Font-Size="8pt" Font-Underline="False"  DynamicHorizontalOffset="2"
                    ForeColor="#7C6F57" StaticSubMenuIndent="10px">
                    <DynamicHoverStyle BackColor="#7C6F57" ForeColor="White" />
                    <DynamicMenuStyle BackColor="#F7F6F3" />
                    <DynamicSelectedStyle BackColor="#5D7B9D" />
                    <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                    <StaticHoverStyle Font-Names="Verdana" BackColor="#DFEFFF"/>
                    <StaticSelectedStyle Font-Names="Verdana" BackColor="#DFEFFF" 
                            Font-Bold="False" Font-Italic="False" Font-Underline="False"/>
                    <StaticMenuItemStyle ForeColor="#333333" BorderStyle="None" 
                            HorizontalPadding="5px" VerticalPadding="5px" />
                    <Items>
                        <asp:MenuItem Text="Dados Cadastrais" Value="WFClienteDados.aspx" Selected="True"></asp:MenuItem>
                        <asp:MenuItem Text="Atendimentos" Value="WGPosVendaChamados.aspx"></asp:MenuItem>                      
                        <asp:MenuItem Text="Follow-Up" Value="WGPosVendaFollowUp.aspx"></asp:MenuItem>
                        <asp:MenuItem Text="Negociação" Value="WGPosVendaNegociacao.aspx"></asp:MenuItem>                        
                        <asp:MenuItem Text="SLA" Value="WGClienteSLA.aspx"></asp:MenuItem>
                        <asp:MenuItem Text="Ponto Atendimento" Value="WGClientePontoAtendimento.aspx?embeeded=False&amp;vcodemi=SCodEmitente&amp;vcodemp=SCodClientePesquisado&amp;valtecc=SAlterouCodCliente&amp;vrecdc=SRecarregaDdlContatos&amp;ccodcon=SCodContatoNegociacao&amp;ptat=SNumeroPontoAtendimento">
                        </asp:MenuItem>                      
                        <asp:MenuItem Text="Financeiro"  Value="WFPosVendaFinanceiro.aspx"></asp:MenuItem>
                        <asp:MenuItem Text="SINAMM"  Value="WGPosVendaSINAMM.aspx"></asp:MenuItem>
                        <asp:MenuItem Text="SPDO" Value="WGPosVendaSAAFE.aspx"></asp:MenuItem>
                        <asp:MenuItem Text="Compras"  Value=" WGPosVendaCompras.aspx"></asp:MenuItem>              
                        <asp:MenuItem Text="Convênio" Value="WGPosVendaConvenio.aspx"></asp:MenuItem>
                                              
                        <asp:MenuItem Text="Grupo" Value="WGClienteMercado.aspx"></asp:MenuItem>
                        <asp:MenuItem Text="Assessoria" Value="WGClienteAssessoria.aspx"></asp:MenuItem>
                       
                    </Items>
                </asp:Menu>
            </td>
        </tr>
        <tr>
            <td style="border: thin ridge #CCCCCC; width: 50%; height: calc(100vh - 85px) ">
                <uc2:WUCFrame ID="FrameDetalhe" runat="server" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
