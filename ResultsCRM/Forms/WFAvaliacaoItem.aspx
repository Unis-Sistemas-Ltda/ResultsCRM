<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFAvaliacaoItem.aspx.vb" Inherits="ResultsCRM.WFAvaliacaoItem" %>

<%@ Register src="../UserControls/WUCAvaliacaoItem.ascx" tagname="WUCAvaliacaoItem" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <uc1:WUCAvaliacaoItem ID="WUCAvaliacaoItem1" runat="server" />
    
    </div>
    </form>
</body>
</html>
