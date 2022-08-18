<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFClienteSLA.aspx.vb" Inherits="ResultsCRM.WFClienteSLA" %>

<%@ Register src="../UserControls/WUCClienteCSLA.ascx" tagname="WUCClienteCSLA" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     
    
        <uc1:WUCClienteCSLA ID="WUCClienteCSLA1" runat="server" />
        
    
    </div>
    </form>
</body>
</html>
