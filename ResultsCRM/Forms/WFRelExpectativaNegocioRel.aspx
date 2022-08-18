<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFRelExpectativaNegocioRel.aspx.vb" Inherits="ResultsCRM.WFRelExpectativaNegocioRel" %>

<%@ Register assembly="WebDataWindow" namespace="Sybase.DataWindow.Web" tagprefix="dw" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
                        <asp:Button ID="BtnImprimir" runat="server" CssClass="Botao" 
                            onclientclick="self.print(); return false;" Text="Imprimir" />
                        <dw:WebDataWindowControl ID="WDWRelatorio" runat="server" 
                    style="top: 0px; left: -1px">
        </dw:WebDataWindowControl>
    <asp:Label ID="LblErro" runat="server" CssClass="Erro"></asp:Label>
    </form>
</body>
</html>
