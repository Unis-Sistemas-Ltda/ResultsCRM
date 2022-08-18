<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFClientePontoAtendimento.aspx.vb" Inherits="ResultsCRM.WFClientePontoAtendimento" %>

<%@ Register src="../UserControls/WUCClientePontoAtendimento.ascx" tagname="WUCClientePontoAtendimento" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <script language="javascript" type="text/javascript">
        function getbacktostepone() {
            window.location = "WFClientePontoAtendimento.aspx?embeeded=True";
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
    <style type="text/css">
        
.TextoCadastro
{
    font-size: 7pt;
    text-align: right;
    font-family: verdana;
}
.Titulo
{
    font-size: 9pt;
    font-weight:bold;
    font-family: verdana;
    text-align: center;
}
.Erro
{
    font-size: 7pt;
    text-align: left;
    color: #CC0000;
    font-family: verdana;
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
}
.Botao
{
    font-size: 7pt;
    font-weight: bold;
    text-align: center;
    background-color: #3366CC;
    color: #FFFFFF;
    font-family: verdana;
}
    </style>
</head>
<body style="margin:0px">
    <form id="form1" runat="server">
    <div>
    
        <uc2:WUCClientePontoAtendimento ID="WUCClientePontoAtendimento1" 
            runat="server" />
    
    </div>
    </form>
</body>
</html>
