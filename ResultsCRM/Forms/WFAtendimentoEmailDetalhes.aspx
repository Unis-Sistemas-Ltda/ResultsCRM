<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFAtendimentoEmailDetalhes.aspx.vb" Inherits="ResultsCRM.WFAtendimentoEmailDetalhes" %>

<%@ Register src="../UserControls/WUCFrame.ascx" tagname="WUCFrame" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
        function resizeIframeMeio() {
            i = document.getElementById('FrameSuperior');
            j = document.getElementById('tdframemeio');
            iHeight = top.innerHeight;
            iWidth = top.innerWidth;

            if (i != null) {
                i.style.height = iHeight - 135 + "px";
                i.style.width = iWidth - 152 + "px"
            }

            if (j != null) {
                j.style.height = iHeight - 133 + "px";
                j.style.width = iWidth - 149 + "px"
            }
        }
    </script>
</head>
<body runat="server" id="body1" style="padding:0px; margin: 0px; border:0px ">
    <form id="form1" runat="server">
    <table style="width: 100%; height: 100%; border-collapse: collapse;">
        <tr>
            <td style="vertical-align: top" width="130">
    
        <asp:Menu ID="MnuTabs" runat="server" Font-Names="Verdana" 
                Font-Size="8pt" Font-Underline="False" RenderingMode="List" Width="125px">
                <StaticHoverStyle Font-Names="Verdana" BackColor="#DFEFFF"/>
                <StaticSelectedStyle Font-Names="Verdana" BackColor="#DFEFFF" 
                    Font-Bold="False" Font-Italic="False" Font-Underline="False"/>
                <StaticMenuItemStyle ForeColor="#333333" BorderStyle="None" 
                    HorizontalPadding="5px" VerticalPadding="5px" />
            <Items>
                <asp:MenuItem Text="Novo e-mail" 
                    Value="!"></asp:MenuItem>
                <asp:MenuItem Text="Rascunhos" 
                    Value="0" Selected="True"></asp:MenuItem>
                <asp:MenuItem Text="Saída" Value="1"></asp:MenuItem>
                <asp:MenuItem Text="Enviados" Value="2"></asp:MenuItem>
                <asp:MenuItem Text="Não Enviados" Value="5"></asp:MenuItem>
            </Items>
        </asp:Menu>
    
            </td>
            <td id="tdframemeio" 
                
                style="border-style: none; padding: 0px; margin: 0px; vertical-align: top;">
                    <uc2:WUCFrame ID="FrameDetalhe" runat="server" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
