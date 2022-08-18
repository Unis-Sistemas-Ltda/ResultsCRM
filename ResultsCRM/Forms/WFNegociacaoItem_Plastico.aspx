<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFNegociacaoItem_Plastico.aspx.vb" Inherits="ResultsCRM.WFNegociacaoItem_Plastico" %>

<%@ Register src="../UserControls/WUCNegociacaoItem_Plastico.ascx" tagname="WUCNegociacaoItem_Plastico" tagprefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"!>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body topmargin="0" marginwidth="0" leftmargin="0" rightmargin="0" bottommargin="0" marginheight="0">
    <form id="form1" runat="server">
    <div>
    
        <uc1:WUCNegociacaoItem_Plastico ID="WUCNegociacaoItem_Plastico1" 
            runat="server" />
        
    </div>
    </form>
</body>
</html>
