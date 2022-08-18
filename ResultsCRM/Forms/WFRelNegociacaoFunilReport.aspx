<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFRelNegociacaoFunilReport.aspx.vb" Inherits="ResultsCRM.WFRelNegociacaoFunilReport" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

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
        TypeName="ResultsCRM.DSNegociacaoTableAdapters.RelNegociacaoResumidoTableAdapter">
        <SelectParameters>
            <asp:SessionParameter Name="Param1" SessionField="GlEmpresa" Type="String" />
            <asp:QueryStringParameter Name="Param2" QueryStringField="etapai" 
                Type="String" />
            <asp:QueryStringParameter Name="Param3" QueryStringField="etapaf" 
                Type="String" />
            <asp:QueryStringParameter Name="Param4" QueryStringField="data1" 
                ConvertEmptyStringToNull="False" DbType="AnsiString" />
            <asp:QueryStringParameter Name="Param5" QueryStringField="data2" 
                ConvertEmptyStringToNull="False" DbType="AnsiString" />
            <asp:QueryStringParameter Name="Param6" QueryStringField="status" 
                Type="String" />
            <asp:QueryStringParameter Name="Param7" QueryStringField="agente" 
                Type="String" />
            <asp:QueryStringParameter Name="Param8" QueryStringField="representante" 
                Type="String" />
            <asp:QueryStringParameter Name="Param9" QueryStringField="canal" 
                Type="String" />
            <asp:QueryStringParameter Name="Param10" QueryStringField="item" 
                Type="String" ConvertEmptyStringToNull="False" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:Button ID="Button1" runat="server" Text="Voltar" />
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
        Font-Size="8pt" InteractiveDeviceInfos="(Collection)" 
        WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="22cm" 
        Height="500px">
        <LocalReport ReportPath="reports\RelNegociacaoItemResumido.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="DataSet1" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
    </form>
</body>
</html>
