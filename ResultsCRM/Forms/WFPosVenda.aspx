<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFPosVenda.aspx.vb" Inherits="ResultsCRM.WFPosVenda" %>

<%@ Register src="../UserControls/WUCFrame.ascx" tagname="WUCFrame" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
    </head>
<body style="padding: 0px; width: 100%; text-align: left; top: 0px; height: 515px; min-height: 100%; margin: 0px; clip: rect(auto auto auto auto)">
    <form id="form1" runat="server" style="height:100%">
    
       <table style="width: 100%;">
            <tr>
                <td>
        <asp:Button ID="BtnVoltar" runat="server" Text="Voltar" CssClass="Botao" />
                </td>
                <td style="text-align: right">
                    <asp:Button ID="BtnCarrega" runat="server" Text="Carrega" BackColor="White" 
                        BorderStyle="None" CssClass="Botao" ForeColor="White" Width="2px" 
                        Height="2px" />
                </td>
            </tr>
            <tr>
                <td style="border: thin ridge #CCCCCC; width: 100%; height: 100%">
                    <uc2:WUCFrame ID="FrameInferior" runat="server" /></td>
            </tr>
            </table>
    </form>
</body>
</html>
