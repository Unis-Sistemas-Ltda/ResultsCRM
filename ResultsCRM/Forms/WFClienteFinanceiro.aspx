<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFClienteFinanceiro.aspx.vb" Inherits="ResultsCRM.WFClienteFinanceiro" %>

<%@ Register src="../UserControls/WUCClienteFinanceiro.ascx" tagname="WUCClienteFinanceiro" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
    <link href="../ResultsCRMAjax.css" rel="stylesheet" type="text/css" />
     <script language="javascript" type="text/javascript">
        function getbacktostepone() {
            window.location = "WFClienteFinanceiro.aspx?embeeded=True";
        }
        function onSuccess() {
            window.parent.document.forms[0].submit();
            window.parent.document.getElementById('ButtonEditDone').click();
        }
        function onError() {
            getbacktostepone();
        }
        function cancel() {
            window.parent.document.getElementById('ButtonEditCancel').click();
        }
    </script>    
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <uc1:WUCClienteFinanceiro ID="WUCClienteFinanceiro1" runat="server" />
    
    </div>
    </form>
</body>
</html>
