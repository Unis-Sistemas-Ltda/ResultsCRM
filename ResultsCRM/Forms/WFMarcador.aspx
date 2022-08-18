<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFMarcador.aspx.vb" Inherits="ResultsCRM.WFMarcador" %>

<%@ Register src="../UserControls/WUCMarcador.ascx" tagname="WUCMarcador" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <script language="javascript" type="text/javascript">
        function getbacktostepone() {
            window.location = "WFMarcador.aspx?embeeded=True";
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
    
        <uc1:WUCMarcador ID="WUCMarcador1" runat="server" />
    
    </div>
    </form>
</body>
</html>
