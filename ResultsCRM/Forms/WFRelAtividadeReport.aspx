<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFRelAtividadeReport.aspx.vb" Inherits="ResultsCRM.WFRelAtividadeReport" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
    <link href="../ResultsCRMAjax.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="../ResultsCRM.js"></script>
    </head>
<body>
    <form id="form1" runat="server">

    <%--este é o html para pesquisa de itens--%>    <%--botões padrão que ficam ocultos, são necessários, não remover--%>
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
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
        TypeName="ResultsCRM.DSNegociacaoTableAdapters.RelAtividadeTableAdapter">
        <SelectParameters>
            <asp:SessionParameter Name="Param1" SessionField="GlEmpresa" Type="String" />
            <asp:SessionParameter Name="Param2" SessionField="GlEstabelecimento" Type="String" />
            <asp:QueryStringParameter Name="Param3" QueryStringField="datai" Type="String" ConvertEmptyStringToNull="False"/>
            <asp:QueryStringParameter Name="Param4" QueryStringField="dataf" Type="String" ConvertEmptyStringToNull="False"/>
            <asp:QueryStringParameter Name="Param5" QueryStringField="tipos" Type="String" ConvertEmptyStringToNull="False"/>
            <asp:QueryStringParameter Name="Param6" QueryStringField="canais" Type="String" ConvertEmptyStringToNull="False"/>
            <asp:QueryStringParameter Name="Param7" QueryStringField="usuarios" Type="String" ConvertEmptyStringToNull="False"/>
            <asp:QueryStringParameter Name="Param8" QueryStringField="carteiras" Type="String" ConvertEmptyStringToNull="False"/>
        </SelectParameters>
        
    </asp:ObjectDataSource>
    <asp:Button ID="Button1" runat="server" Text="Voltar" />
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
        Font-Size="8pt" InteractiveDeviceInfos="(Collection)" 
        WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="28cm" 
        Height="500px">
        <LocalReport ReportPath="reports\RelAtividade.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="DSRelAtivid" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
    </form>
</body>
</html>
