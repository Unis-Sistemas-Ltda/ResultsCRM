<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFEmailVisualizacao.aspx.vb" Inherits="ResultsCRM.WFEmailVisualizacao" %>

<%@ Register src="../UserControls/WUCEmailVisualizacao.ascx" tagname="WUCEmailVisualizacao" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="padding:0px; border:0px; margin: 0px">
    <form id="form1" runat="server">
    <div>
        <uc1:WUCEmailVisualizacao ID="WUCEmailVisualizacao1" runat="server" />
    </div>
    </form>
</body>
</html>