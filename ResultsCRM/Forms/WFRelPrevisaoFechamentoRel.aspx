<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFRelPrevisaoFechamentoRel.aspx.vb" Inherits="ResultsCRM.WFRelPrevisaoFechamentoRel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
    <link href="../ResultsCRMAjax.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="../ResultsCRM.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="TituloRelatorio">Relatório de Previsão de Fechamento</div>
    <table width="100%"><tr><td style="vertical-align: bottom">
        <asp:Button ID="Button1" runat="server" 
            onclientclick="self.print(); return false;" Text="Imprimir" />
&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" Text="Voltar" 
            onclientclick="history.back(); return false;" />
        </td><td style="text-align: right">
            <asp:ImageButton ID="ImageButton1" runat="server" 
                ImageUrl="~/Imagens/BtnExcel.png" />
        </td></tr><tr><td colspan="2" style="vertical-align: bottom">
            <asp:GridView ID="GridView1" runat="server" CellPadding="4" 
                DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" 
                Width="100%" AllowSorting="True" AutoGenerateColumns="False" 
                EmptyDataText="Não há dados a exibir.">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="cod_negociacao_cliente" HeaderText="Nº Negociação" 
                        ReadOnly="True" SortExpression="cod_negociacao_cliente">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Cliente/Conta" SortExpression="nome_emitente">
                        <EditItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("nome_emitente") %>'></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("nome_emitente") %>'></asp:Label>
                            (<asp:Label ID="Label2" runat="server" Text='<%# Eval("cod_emitente") %>'></asp:Label>
                            )
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Vendedor/Representante" 
                        SortExpression="nome_representante">
                        <EditItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("nome_representante") %>'></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("nome_representante") %>'></asp:Label>
                            (<asp:Label ID="Label4" runat="server" Text='<%# Eval("cod_representante") %>'></asp:Label>
                            )
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Etapa" SortExpression="descricao_etapa">
                        <EditItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("descricao_etapa") %>'></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("descricao_etapa") %>'></asp:Label>
                            (<asp:Label ID="Label7" runat="server" Text='<%# Eval("cod_etapa") %>'></asp:Label>
                            )
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Status" SortExpression="descricao_status">
                        <EditItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Eval("descricao_status") %>'></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label6" runat="server" Text='<%# Bind("descricao_status") %>'></asp:Label>
                            (<asp:Label ID="Label8" runat="server" Text='<%# Eval("cod_status") %>'></asp:Label>
                            )
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Itens" SortExpression="itens">
                        <EditItemTemplate>
                            <asp:Label ID="Label5" runat="server" Text='<%# Eval("itens") %>'></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label9" runat="server" Text='<%# Bind("itens") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                        <ItemStyle HorizontalAlign="Justify" VerticalAlign="Top" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="probabilidade_sucesso" 
                        HeaderText="Prob. Sucesso (%)" ReadOnly="True" 
                        SortExpression="probabilidade_sucesso">
                    <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
                    </asp:BoundField>
                    <asp:BoundField DataField="previsao_fechamento" 
                        DataFormatString="{0:dd/MM/yyyy}" HeaderText="Previsão Fechamento" 
                        ReadOnly="True" SortExpression="previsao_fechamento">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Valor (R$)" SortExpression="valor_total">
                        <EditItemTemplate>
                            <asp:Label ID="Label6" runat="server" 
                                Text='<%# Eval("valor_total", "{0:N2}") %>'></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="LblValor" runat="server" 
                                Text='<%# Bind("valor_total", "{0:N2}") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
                    </asp:TemplateField>
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                
                SelectCommand="call sp_rel_crm_previsao_venda(:empresa, :prev_i, :prev_f, :canal, :prob_i, :prob_f, :sts, :pais, :estado, :cidade, :representante, :funil)" 
                ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>">
                <SelectParameters>
                    <asp:SessionParameter ConvertEmptyStringToNull="False" DbType="String" 
                        Name=":empresa" SessionField="GlEmpresa" />
                    <asp:QueryStringParameter ConvertEmptyStringToNull="False" DbType="String" 
                        Name=":prev_i" QueryStringField="da1" />
                    <asp:QueryStringParameter ConvertEmptyStringToNull="False" DbType="String" 
                        Name=":prev_f" QueryStringField="da2" />
                    <asp:QueryStringParameter ConvertEmptyStringToNull="False" DbType="String" 
                        Name=":canal" QueryStringField="ca" />
                    <asp:QueryStringParameter ConvertEmptyStringToNull="False" DbType="String" 
                        Name=":prob_i" QueryStringField="pr1" />
                    <asp:QueryStringParameter ConvertEmptyStringToNull="False" DbType="String" 
                        Name=":prob_f" QueryStringField="pr2" />
                    <asp:QueryStringParameter ConvertEmptyStringToNull="False" DbType="String" 
                        Name=":sts" QueryStringField="st" />
                    <asp:QueryStringParameter ConvertEmptyStringToNull="False" DbType="String" 
                        Name=":pais" QueryStringField="pa" />
                    <asp:QueryStringParameter ConvertEmptyStringToNull="False" DbType="String" 
                        Name=":estado" QueryStringField="es" />
                    <asp:QueryStringParameter ConvertEmptyStringToNull="False" DbType="String" 
                        Name=":cidade" QueryStringField="ci" />
                    <asp:QueryStringParameter ConvertEmptyStringToNull="False" DbType="String" 
                        Name=":representante" QueryStringField="re" />
                    <asp:QueryStringParameter Name=":funil" QueryStringField="fu" />
                </SelectParameters>
            </asp:SqlDataSource>
            </td></tr><tr><td colspan="2" 
                style="vertical-align: bottom; text-align: right;">
            ___________________________<br />
            Total R$: 
            <asp:Label ID="LblTotalGeral" runat="server" Font-Bold="True" Text="0,00"></asp:Label>
            </td></tr></table>
    </form>
</body>
</html>
