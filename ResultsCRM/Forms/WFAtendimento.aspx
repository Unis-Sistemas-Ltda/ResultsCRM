<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFAtendimento.aspx.vb" Inherits="ResultsCRM.WFAtendimento" %>

<%@ Register src="../UserControls/WUCFrame.ascx" tagname="WUCFrame" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
//        function resizeIframeAtendimento() {
//            i = parent.document.getElementById('FrameSuperior');
//            j = parent.document.getElementById('tdframesuperior');
//            iHeight = window.innerHeight;
//            iWidth = window.innerWidth;

//            if (i != null) {
//                i.style.height = (iHeight - 50) + "px";
//                i.style.width = (iWidth - 20) + "px"
//            }

//            if (j != null) {
//                j.style.height = (iHeight - 47) + "px";
//                j.style.width = (iWidth - 17) + "px";
//            }
//        }
    </script>
    </head>
<body id="bodyAtendimento" runat="server" style="padding: 0px; width: 100%; text-align: left; top: 0px; min-height: 100%; margin: 0px; clip: rect(auto auto auto auto)">
    <form id="form1" runat="server" style="width:100%">
    
       <table style="width: 100%; height: 100vh">
            <tr>
                <td class="TituloMovimento">
                    Detalhe do Atendimento</td>
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
                <asp:MenuItem Text="Chamado"                        Value="WFAtendimentoCabecalho.aspx" Selected="True"></asp:MenuItem>
                <asp:MenuItem Text="Follow-ups"                      
                    Value="WGAtendimentoFollowUp.aspx"></asp:MenuItem>
                <asp:MenuItem Text="E-mails"                         
                    Value="WFAtendimentoEmailDetalhes.aspx"></asp:MenuItem>
                <asp:MenuItem Text="Histórico"                      Value="WGAtendimentoHistorico.aspx"></asp:MenuItem>
                <asp:MenuItem Text="Ordens de Serviço"               
                    Value="WGAtendimentoPedido.aspx"></asp:MenuItem>
                <asp:MenuItem Text="Negociações" Value="WGAtendimentoNegociacao.aspx">
                </asp:MenuItem>
                <asp:MenuItem Text="Solicitações de Desenvolvimento" 
                    Value="WGAtendimentoSolicitacao.aspx"></asp:MenuItem>
                <asp:MenuItem Text="Ponto de Atendimento"           Value="WFAtendimentoConsultaHistoricoPA.aspx"></asp:MenuItem>
                <asp:MenuItem Text="FMEA"                       
                    Value="WGAtendimentoProblema.aspx"></asp:MenuItem>
                <asp:MenuItem Text="Horas" Value="WGAtendimentoHoras.aspx"></asp:MenuItem>
                <asp:MenuItem Text="Voltar"                         Value="#"></asp:MenuItem>
            </Items>
        </asp:Menu>
                </td>
            </tr>
            <tr style="width: 100%;">
                <td id="tdframesuperior" style="width: 100%; height: calc(100vh - 65px);">
                    <uc2:WUCFrame ID="FrameSuperior" runat="server" /></td>
            </tr>
            </table>
    </form>
</body>
</html>
