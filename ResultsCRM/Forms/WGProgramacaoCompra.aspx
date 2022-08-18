<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGProgramacaoCompra.aspx.vb" Inherits="ResultsCRM.WGProgramacaoCompra" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" 
        EnableScriptGlobalization="True">
            </asp:ScriptManager>
    <table width="100%" style="border-collapse: collapse">
        <tr><td class="TituloConsulta" colspan="5">
            Consulta de Programações de 
            Compra/Produção</td></tr>
        <tr><td colspan="5">Informe abaixo o(s) critério(s) para pesquisa e em seguida 
            clique em Pesquisar.</td></tr>
        <tr><td style="text-align: right">Cód. Item:</td><td>
            <asp:TextBox ID="TxtCodItem" runat="server" CssClass="CampoCadastro" 
                Width="100px"></asp:TextBox>
            </td><td style="text-align: right">Descrição Item:</td><td>
            <asp:TextBox ID="TxtDescricaoItem" runat="server" CssClass="CampoCadastro" 
                Width="250px"></asp:TextBox>
            </td><td></td></tr>
        <tr><td style="text-align: right">Referência:</td><td>
            <asp:TextBox ID="TxtReferencia" runat="server" CssClass="CampoCadastro" 
                Width="100px"></asp:TextBox>
            </td><td style="text-align: right">Data Prevista até:</td><td>
            <asp:TextBox ID="TxtDataPrevistaAte" runat="server" CssClass="CampoCadastro" 
                Width="100px"></asp:TextBox><ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" 
                        TargetControlID="TxtDataPrevistaAte" FirstDayOfWeek="Sunday"
                        Format="dd/MM/yyyy" TodaysDateFormat="d MMMM yyyy"></ajaxToolkit:CalendarExtender>
            <ajaxToolkit:MaskedEditExtender ID="TxtData_MaskedEditExtender" runat="server" 
                            BehaviorID="TxtDataPrevistaAte_MaskedEditExtender" Century="2000" 
                            CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                            CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                            CultureThousandsPlaceholder="" CultureTimePlaceholder="" Mask="99/99/9999" 
                            MaskType="Date" TargetControlID="TxtDataPrevistaAte" UserDateFormat="DayMonthYear" />
            </td><td style="text-align: right">
                <asp:Button ID="Button1" runat="server" Text="Pesquisar" />
            </td></tr>
    </table>
    <div>
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" 
            GridLines="None" Width="100%" AllowPaging="True" AllowSorting="True" 
            EmptyDataText="&lt;br&gt;Não há programações a exibir." PageSize="40">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="cod_item" HeaderText="Código" ReadOnly="True" 
                    SortExpression="cod_item">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="descricao_item" HeaderText="Descrição Item" 
                    ReadOnly="True" SortExpression="descricao_item">
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="descricao_referencia" HeaderText="Referência" 
                    ReadOnly="True" SortExpression="descricao_referencia">
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="tipo" HeaderText="Tipo Doc." ReadOnly="True" 
                    SortExpression="tipo">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="numero_documento" HeaderText="Nº Doc." 
                    ReadOnly="True" SortExpression="numero_documento">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="qtd_solicitada" DataFormatString="{0:F4}" 
                    HeaderText="Qtd. Solicitada" ReadOnly="True" SortExpression="qtd_solicitada">
                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="qtd_saldo" DataFormatString="{0:F4}" 
                    HeaderText="Qtd. Saldo" ReadOnly="True" SortExpression="qtd_saldo">
                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="data_prevista" DataFormatString="{0:dd/MM/yyyy}" 
                    HeaderText="Data Prevista" ReadOnly="True" SortExpression="data_prevista">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerSettings FirstPageText="Primeira" LastPageText="Última" 
                Mode="NumericFirstLast" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>">
            <SelectParameters>
                <asp:ControlParameter ControlID="TxtCodItem" ConvertEmptyStringToNull="False" 
                    DbType="String" Name=":cod_item" PropertyName="Text" />
                <asp:ControlParameter ControlID="TxtDescricaoItem" 
                    ConvertEmptyStringToNull="False" DbType="String" Name=":descricao" 
                    PropertyName="Text" />
                <asp:SessionParameter ConvertEmptyStringToNull="False" DbType="String" 
                    Name=":empresa" SessionField="GlEmpresa" />
                <asp:SessionParameter ConvertEmptyStringToNull="False" DbType="String" 
                    Name=":estabelecimento" SessionField="GlEstabelecimento" />
                <asp:ControlParameter ControlID="TxtReferencia" 
                    ConvertEmptyStringToNull="False" DbType="String" Name=":referencia" 
                    PropertyName="Text" />
                <asp:ControlParameter ControlID="TxtDataPrevistaAte" 
                    ConvertEmptyStringToNull="False" DbType="String" Name=":periodo" 
                    PropertyName="Text" />
                <asp:ControlParameter ControlID="TxtReferencia" 
                    ConvertEmptyStringToNull="False" DbType="String" Name=":cod_item" 
                    PropertyName="Text" />
                <asp:ControlParameter ControlID="TxtDescricaoItem" 
                    ConvertEmptyStringToNull="False" DbType="String" Name=":descricao" 
                    PropertyName="Text" />
                <asp:SessionParameter ConvertEmptyStringToNull="False" DbType="String" 
                    Name=":empresa" SessionField="GlEmpresa" />
                <asp:SessionParameter ConvertEmptyStringToNull="False" DbType="String" 
                    Name=":estabelecimento" SessionField="GlEstabelecimento" />
                <asp:ControlParameter ControlID="TxtReferencia" 
                    ConvertEmptyStringToNull="False" DbType="String" Name=":referencia" 
                    PropertyName="Text" />
                <asp:ControlParameter ControlID="TxtDataPrevistaAte" 
                    ConvertEmptyStringToNull="False" DbType="String" Name=":periodo" 
                    PropertyName="Text" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
