<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFTEFCabecalho.aspx.vb" Inherits="ResultsCRM.WFTEFCabecalho" %>
<%@ Register src="../UserControls/WUCTEF.ascx" tagname="WUCTEF" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <uc1:WUCTEF ID="WUCTEF1" runat="server" />
    
    </div>
    </form>
</body>
</html>
