<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFNegociacaoMotivoFechamento.aspx.vb" Inherits="ResultsCRM.WFNegociacaoMotivoFechamento" %>

<%@ Register src="../UserControls/WUCNegociacaoMotivoFechamento.ascx" tagname="WUCNegociacaoMotivoFechamento" tagprefix="uc1" %>
<%@ Register src="../UserControls/WUCNegociacaoTotais.ascx" tagname="WUCNegociacaoTotais" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:WUCNegociacaoMotivoFechamento ID="WUCNegociacaoMotivoFechamento1" 
            runat="server" />
    </div>
    </form>
</body>
</html>
