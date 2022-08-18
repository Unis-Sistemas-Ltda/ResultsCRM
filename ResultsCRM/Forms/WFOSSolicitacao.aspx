<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFOSSolicitacao.aspx.vb" Inherits="ResultsCRM.WFOSSolicitacao" %>
<%@ Register src="../UserControls/WUCAtendimentoPedidoSolicitacao.ascx" tagname="WUCAtendimentoPedidoSolicitacao" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <uc2:WUCAtendimentoPedidoSolicitacao ID="WUCAtendimentoPedidoSolicitacao1" 
            runat="server" />
    
    </div>
    </form>
</body>
</html>
