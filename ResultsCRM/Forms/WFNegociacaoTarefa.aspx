<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFNegociacaoTarefa.aspx.vb" Inherits="ResultsCRM.WFNegociacaoTarefa" %>

<%@ Register src="../UserControls/WUCNegociacaoTotais.ascx" tagname="WUCNegociacaoTotais" tagprefix="uc1" %>
<%@ Register src="../UserControls/WUCNegociacaoTarefa.ascx" tagname="WUCNegociacaoTarefa" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Detalhes da Tarefa</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <uc2:WUCNegociacaoTarefa ID="WUCNegociacaoTarefa1" runat="server" />
    
    </div>
    </form>
</body>
</html>
