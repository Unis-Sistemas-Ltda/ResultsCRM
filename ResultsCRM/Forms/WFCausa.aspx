﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFCausa.aspx.vb" Inherits="ResultsCRM.WFCausa" %>

<%@ Register src="../UserControls/WUCCausa.ascx" tagname="WUCCausa" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <uc1:WUCCausa ID="WUCCausa1" runat="server" />
    
    </div>
    </form>
</body>
</html>
