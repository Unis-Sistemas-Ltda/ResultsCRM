<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFTipoServicoAtendimento.aspx.vb" Inherits="ResultsCRM.WFTipoServicoAtendimento" %>

<%@ Register src="../UserControls/WUCTipoServicoAtendimento.ascx" tagname="WUCTipoServicoAtendimento" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <uc1:WUCTipoServicoAtendimento ID="WUCTipoServicoAtendimento1" runat="server" />
    
    </div>
    </form>
</body>
</html>
