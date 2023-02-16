<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFNegociacaoItem_Farmacos2.aspx.vb" Inherits="ResultsCRM.WFNegociacaoItem_Farmacos2" %>

<%@ Register src="../UserControls/WUCNegociacaoItem.ascx" tagname="WUCNegociacaoItem" tagprefix="uc1" %>

<%@ Register src="../UserControls/WUCNegociacaoItem_Farmacos2.ascx" tagname="WUCNegociacaoItem_Farmacos2" tagprefix="uc2" %>
<%@ Register Src="~/UserControls/WUCNegociacaoItemFormulaInclusao.ascx" TagPrefix="uc1" TagName="WUCNegociacaoItemFormulaInclusao" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"!>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>   
        <uc2:WUCNegociacaoItem_Farmacos2 ID="WUCNegociacaoItem_Farmacos21" 
            runat="server" />        
    </div>   
    </form>
</body>
</html>
