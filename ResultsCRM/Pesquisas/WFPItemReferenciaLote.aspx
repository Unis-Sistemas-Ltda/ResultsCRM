<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFPItemReferenciaLote.aspx.vb"   Inherits="ResultsCRM.WFPItemReferenciaLote" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register src="../OutrosControles/TextBoxNumerico.ascx" tagname="TextBoxNumerico" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Pesquisa de Lotes</title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
    <link href="../ResultsCRMAjax.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
        function getbacktostepone() {
            window.location = "WFPItem.aspx";
        }
        function onSuccess() {
//            window.parent.document.forms.item(0).submit();
            //            window.parent.document.getElementById('ButtonEditDone').click();
            window.parent.location = "../Forms/WGNegociacaoItem.aspx";
            window.close()
        }
        function onError() {
            getbacktostepone();
        }
        function cancel() {
            window.parent.document.getElementById('ButtonEditCancel').click();
        }
    </script>
</head>
<body class="TextoCadastro">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:MultiView ID="MultiViewExpanse" runat="server">
        <asp:View ID="ViewInput" runat="server">
            <table class="TextoCadastro" style="width: 470px; height: 340px; font-size: 7pt;
                background-color: #FFFFFF;">
                <tr>
                    <td class="TituloConsulta" colspan="5" style="height: 20px">
                        Selecionar Lotes
                    </td>
                </tr>
                <tr>
                    <td class="Erro" colspan="5">
                        <asp:Label ID="LblErro" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="height: 25px; text-align: right;">
                        <asp:Label ID="LblFornecedor" runat="server" Text="Informe o valor do lote:" Width="196px"
                            Style="margin-top: 0px; margin-bottom: 0px; margin-left: 0px;"></asp:Label>
                    </td>
                    <td style="text-align: right; height: 25px;">
                        <uc1:TextBoxNumerico ID="TxtPrecoUnitario" runat="server" AutoPostBack="False" 
                            QtdCasas="4" Width="75" />
                    </td>
                    <td class="CelulaCampoCadastro" style="text-align: right">
                    </td>
                    <td class="CelulaCampoCadastro" style="text-align: right">
                        &nbsp;
                    </td>
                    <td class="CelulaCampoCadastro" style="text-align: right">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="5" style="vertical-align: top">
                        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333"
                            GridLines="None" CssClass="CampoCadastro" Width="468px" PageSize="7" Font-Size="7pt">
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <Columns>
                                <asp:TemplateField HeaderText="Selecione">                                   
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CheckBox1" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>                                 
                                <asp:BoundField DataField="lote" HeaderText="Lote" SortExpression="lote">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                </asp:BoundField>
                                <asp:BoundField DataField="cod_negociacao" HeaderText="Reservado">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="saldo_final" HeaderText="Saldo" SortExpression="saldo_final">
                                    <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
                                </asp:BoundField>
                            </Columns>
                            <PagerSettings FirstPageText="1&nbsp;" LastPageText="Última" Mode="NumericFirstLast" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" />
                            <EditRowStyle BackColor="#999999" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select saldo_estoque.lote, CONVERT(varchar(10), sum(saldo)) as saldo_final, (select first nci.cod_negociacao_cliente from negociacao_cliente_item nci inner join negociacao_cliente nc on nc.empresa = nci.empresa and nc.estabelecimento = nci.estabelecimento and nc.cod_negociacao_cliente = nci.cod_negociacao_cliente  inner join etapa_negociacao e on e.empresa = nc.empresa and e.cod_etapa = nc.cod_etapa  where nci.cod_item = saldo_estoque.cod_item and nci.referencia = saldo_estoque.referencia and nci.lote = saldo_estoque.lote and e.indicador_sucesso in (1,2)) as cod_negociacao from saldo_estoque where saldo > 0 and saldo_estoque.empresa  =  :empresa  and saldo_estoque.cod_item =  :item  group by saldo_estoque.lote, saldo, saldo_estoque.cod_item, saldo_estoque.referencia order by saldo_estoque.lote">
                            <SelectParameters>
                                <asp:SessionParameter ConvertEmptyStringToNull="False" DbType="String" Name=":empresa"
                                    SessionField="GlEmpresa" />
                                <asp:SessionParameter ConvertEmptyStringToNull="False" DbType="String" Name=":item"
                                    SessionField="ItemLote" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 16px; text-align: left;">
                        &nbsp;
                    </td>
                    <td colspan="1" style="height: 16px">
                        <asp:Button ID="btnOkay" runat="server" CssClass="Botao" OnClick="btnOkay_Click"
                            Text="OK" Visible="True" />
                        <input id="btnCancel" class="Botao" onclick="cancel();" style="border-style: none;
                            font-family: verdana; text-decoration: underline; text-align: center;" type="button"
                            value="Fechar" />
                    </td>
                </tr>
            </table>
        </asp:View>
    </asp:MultiView>
    </form>
</body>
</html>
