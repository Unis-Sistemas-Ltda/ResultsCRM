<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFNegociacaoFollowUp.aspx.vb" Inherits="ResultsCRM.WFNegociacaoFollowUp" ValidateRequest="False" %>

<%@ Register src="../UserControls/WUCNegociacaoFollowUp.ascx" tagname="WUCNegociacaoFollowUp" tagprefix="uc1" %>

<%@ Register src="../UserControls/WUCNegociacaoTotais.ascx" tagname="WUCNegociacaoTotais" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <style type="text/css">

.TextoCadastro
{
    font-size: 7pt;
    text-align: right;
    font-family: verdana;
    color: #666666;
    background-color: #EFEFEF;
}
.CelulaCampoCadastro
{
    text-align: left;
}
.CampoCadastro
{
    font-size: 7pt;
    height: 18px;
    font-family: verdana;
    color: #666666;
    text-align: left;
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <uc1:WUCNegociacaoFollowUp ID="WUCNegociacaoFollowUp1" runat="server" />
    
    </div>
    </form>
</body>
</html>
