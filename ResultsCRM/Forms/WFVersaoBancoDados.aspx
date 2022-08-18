<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFVersaoBancoDados.aspx.vb" Inherits="ResultsCRM.WFVersaoBancoDados" %>

<%@ Register src="../UserControls/WUCCausa.ascx" tagname="WUCCausa" tagprefix="uc1" %>

<%@ Register src="../UserControls/WUCVersaoBancoDados.ascx" tagname="WUCVersaoBancoDados" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <uc2:WUCVersaoBancoDados ID="WUCVersaoBancoDados1" runat="server" />
    
    </div>
    </form>
</body>
</html>
