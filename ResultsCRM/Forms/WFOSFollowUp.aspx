<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFOSFollowUp.aspx.vb" Inherits="ResultsCRM.WFOSFollowUp" %>

<%@ Register src="../UserControls/WUCAtendimentoPedidoSolicitacao.ascx" tagname="WUCAtendimentoPedidoSolicitacao" tagprefix="uc2" %>

<%@ Register src="../UserControls/WUCFollowUP.ascx" tagname="WUCFollowUP" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="TextoCadastro_BGBranco" 
        style="border-style: none">
    
        <table style="width:100%;">
            <tr>
                <td>
                    <uc1:WUCFollowUP ID="WUCFollowUP1" runat="server" />
                </td>
            </tr>
            </table>
    
    </div>
    </form>
</body>
</html>
