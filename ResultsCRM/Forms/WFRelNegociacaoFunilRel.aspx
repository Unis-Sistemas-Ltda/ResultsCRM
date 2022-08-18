<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFRelNegociacaoFunilRel.aspx.vb" Inherits="ResultsCRM.WFRelNegociacaoFunilRel" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="WebDataWindow" Namespace="Sybase.DataWindow.Web" TagPrefix="dw" %>
<%@ Register src="../OutrosControles/TextBoxData.ascx" tagname="TextBoxData" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
    <link href="../ResultsCRMAjax.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="../ResultsCRM.js"></script>
    </head>
<body>
    <form id="form1" runat="server">

                        <asp:Button ID="BtnImprimir" runat="server" CssClass="Botao" 
                            onclientclick="self.print(); return false;" Text="Imprimir" />

                        <dw:WebDataWindowControl ID="WDWRelatorio" runat="server" 
                            style="top: 0px; left: -2px">
        </dw:WebDataWindowControl>

    <%--este é o html para pesquisa de itens--%>
    <%--botões padrão que ficam ocultos, são necessários, não remover--%>
    <div class="popup_Buttons" style="display: none">
        <input id="ButtonEditDone" value="Done" type="button" />
        <input id="ButtonEditCancel" value="Cancel" type="button" />
    </div>
    <%--frame onde é mostrado o popup--%>
    <div id="DivEditWindow" style="display: none;" class="popupConfirmation">
        <iframe id="IframeEdit" frameborder="0" width="370" height="350" scrolling="no">
        </iframe>
    </div>
    <asp:Label ID="LblErro" runat="server" CssClass="Erro"></asp:Label>
    </form>
</body>
</html>
