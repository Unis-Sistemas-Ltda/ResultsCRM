<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFFunilVenda.aspx.vb" Inherits="ResultsCRM.WFFunilVenda" %>

<%@ Register src="../UserControls/WUCFunilVenda.ascx" tagname="WUCFunilVenda" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <uc1:WUCFunilVenda ID="WUCFunilVenda1" runat="server" />
    
    </div>
    </form>
</body>
</html>
