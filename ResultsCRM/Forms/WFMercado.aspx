<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFMercado.aspx.vb" Inherits="ResultsCRM.WFMercado" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Register src="../UserControls/WUCMercado.ascx" tagname="WUCMercado" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <uc1:WUCMercado ID="WUCMercado1" runat="server" />
    
    </div>
    </form>
</body>
</html>
