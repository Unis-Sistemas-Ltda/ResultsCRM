<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFTipoPontoAtendimento.aspx.vb" Inherits="ResultsCRM.WFTipoPontoAtendimento" %>

<%@ Register src="../UserControls/WUCCarteira.ascx" tagname="WUCCarteira" tagprefix="uc1" %>

<%@ Register src="../UserControls/WUCTipoPontoAtendimento.ascx" tagname="WUCTipoPontoAtendimento" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc2:WUCTipoPontoAtendimento ID="WUCTipoPontoAtendimento1" runat="server" />
    </div>
    </form>
</body>
</html>
