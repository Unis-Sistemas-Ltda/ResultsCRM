<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFEmail.aspx.vb" Inherits="ResultsCRM.WFEmail" ValidateRequest="false" %>

<%@ Register src="../UserControls/WUCEmail.ascx" tagname="WUCEmail" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body style="padding:0px; border:0px; margin: 0px">
    <form id="form1" runat="server">
    <div>
        <uc1:WUCEmail ID="WUCEmail1" runat="server" />
    </div>
    </form>
</body>
</html>