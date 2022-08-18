<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFPosVendaFollowUp.aspx.vb" Inherits="ResultsCRM.WFPosVendaFollowUp" ValidateRequest="False" %>

<%@ Register src="../UserControls/WUCAtendimentoFollowUp.ascx" tagname="WUCAtendimentoFollowUp" tagprefix="uc1" %>

<%@ Register src="../UserControls/WUCPosVendaFollowUp.ascx" tagname="WUCPosVendaFollowUp" tagprefix="uc2" %>

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
    
        <uc2:WUCPosVendaFollowUp ID="WUCPosVendaFollowUp1" runat="server" />
    
    </div>
    </form>
</body>
</html>
