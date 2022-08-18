<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFRelVisitacaoRel.aspx.vb" Inherits="ResultsCRM.WFRelVisitacaoRel" %>
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
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
        TypeName="ResultsCRM.DataSetTableAdapters.visitacaoTableAdapter">
        <SelectParameters>
            <asp:QueryStringParameter Name="empresa" QueryStringField="emid" Type="Int32" />
            <asp:QueryStringParameter Name="estabelecimento" QueryStringField="esid" 
                Type="Int32" />
            <asp:QueryStringParameter Name="seq_visita" QueryStringField="svid" 
                Type="Int64" />
            <asp:QueryStringParameter Name="seq_visita1" QueryStringField="svid" 
                Type="Int64" />
            <asp:QueryStringParameter Name="cod_emitente" QueryStringField="clid" 
                Type="Int64" />
            <asp:QueryStringParameter Name="cod_emitente1" QueryStringField="clid" 
                Type="Int64" />
            <asp:QueryStringParameter Name="nome" QueryStringField="ncid" Type="String" />
            <asp:QueryStringParameter Name="nome1" QueryStringField="ncid" Type="String" />
            <asp:QueryStringParameter Name="data_visita" QueryStringField="diid" 
                Type="DateTime" />
            <asp:QueryStringParameter Name="data_visita1" QueryStringField="dfid" 
                Type="DateTime" />
            <asp:QueryStringParameter Name="data_visita2" QueryStringField="diid" 
                Type="DateTime" />
            <asp:QueryStringParameter Name="data_visita3" QueryStringField="dfid" 
                Type="DateTime" />
            <asp:QueryStringParameter Name="situacao" QueryStringField="siid" 
                Type="Int16" />
            <asp:QueryStringParameter Name="situacao1" QueryStringField="siid" 
                Type="Int16" />
            <asp:QueryStringParameter Name="cod_representante" QueryStringField="reid" 
                Type="Int64" />
            <asp:QueryStringParameter Name="cod_representante1" QueryStringField="reid" 
                Type="Int64" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:Button ID="Button1" runat="server" Text="Voltar" />
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
        Font-Size="8pt" InteractiveDeviceInfos="(Collection)" 
        WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="22cm" 
        Height="500px">
        <LocalReport ReportPath="reports\RelVisitacao.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
    </form>
</body>
</html>
