<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFNegociacaoItemFormula.aspx.vb" Inherits="ResultsCRM.WFNegociacaoItemFormula" %>

<%@ Register Src="../UserControls/WUCNegociacaoItemFormulaInclusao.ascx" TagName="WUCNegociacaoItemFormulaInclusao" TagPrefix="uc1"  %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <uc1:WUCNegociacaoItemFormulaInclusao runat="server" id="WUCNegociacaoItemFormulaInclusao1" />
        </div>
    </form>
</body>
</html>
