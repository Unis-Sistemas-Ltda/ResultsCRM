<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFRelListagemChamadosResumido.aspx.vb" Inherits="ResultsCRM.WFRelListagemChamadosResumido" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register src="../OutrosControles/TextBoxData.ascx" tagname="TextBoxData" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Listagem de Chamados - Resumo</title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
    <link href="../ResultsCRMAjax.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="../ResultsCRM.js"></script>
    </head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="Button1" runat="server" 
            onclientclick="self.print(); return false;" Text="Imprimir" />
        &nbsp;
    
        <asp:Button ID="Button2" runat="server" 
            onclientclick="history.back(); return false;" Text="Voltar" />
        <br />
    
        <br />
        <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" DataSourceID="SqlDataSource3" ForeColor="#333333" 
            GridLines="None" Width="100%">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:TemplateField HeaderText="Cliente" SortExpression="nome">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("nome") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <br />
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" 
                            Text='<%# Bind("nome") %>' Font-Size="9pt"></asp:Label>
                        (
                        <asp:Label ID="LblCodEmitente" runat="server" 
                            Text='<%# Eval("cod_emitente") %>' Font-Bold="True" Font-Size="9pt"></asp:Label>
                        )<br /> <br />
                        <div style="padding-left: 45px">
                            <asp:GridView ID="GridView1" runat="server" AllowSorting="True" 
                                AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource1" 
                                ForeColor="#333333" GridLines="None" 
                                OnDataBound="GridView1_DataBound"
                                ShowFooter="True" 
                                Width="80%">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Chamado" SortExpression="cod_chamado">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("cod_chamado") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            Total
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("cod_chamado") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" Font-Bold="False"/>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="data_chamado" DataFormatString="{0:dd/MM/yyyy}" 
                                        HeaderText="Abertura" SortExpression="data_chamado">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" Font-Bold="False"/>
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="data_encerramento" DataFormatString="{0:dd/MM/yyyy}" 
                                        HeaderText="Encerramento" SortExpression="data_encerramento">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" Font-Bold="False"/>
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="nome_tipo_chamado" HeaderText="Tipo de Chamado" 
                                        SortExpression="nome_tipo_chamado">
                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" Font-Bold="False"/>
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="cod_pedido_venda" HeaderText="OS" 
                                        SortExpression="cod_pedido_venda">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" Font-Bold="False"/>
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Serviços Solicitados" 
                                        SortExpression="servicos_solicitados">
                                        <EditItemTemplate>
                                            <asp:Label ID="Label4" runat="server" 
                                                Text='<%# Eval("servicos_solicitados") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label5" runat="server" 
                                                Text='<%# Bind("servicos_solicitados") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" Font-Bold="False"/>
                                        <ItemStyle HorizontalAlign="Justify" VerticalAlign="Top" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Serviços Realizados" 
                                        SortExpression="servicos_realizados">
                                        <EditItemTemplate>
                                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("servicos_realizados") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label6" runat="server" Text='<%# Bind("servicos_realizados") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" Font-Bold="False"/>
                                        <ItemStyle HorizontalAlign="Justify" VerticalAlign="Top" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="R$ Total" SortExpression="total_pedido">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("total_pedido") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="LblTotal" runat="server" Text="0,00"></asp:Label>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="LblValorOS" runat="server" 
                                                Text='<%# Bind("total_pedido", "{0:F2}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" />
                                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" Font-Bold="False"/>
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
                                    </asp:TemplateField>
                                </Columns>
                                <EditRowStyle BackColor="#999999" />
                                <FooterStyle BackColor="White" Font-Bold="True" ForeColor="#333333" />
                                <HeaderStyle BackColor="White" Font-Bold="False" ForeColor="#333333" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="White" ForeColor="#333333" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                            </asp:GridView>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                                ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select c.cod_chamado,
       c.data_chamado,
       c.data_encerramento,
       tc.nome nome_tipo_chamado,
       pv.cod_pedido_venda,
       (select list(distinct trim('&lt;b&gt;Equipamento: ' || if eq.numero_serie is null then '(não informado)' else eq.numero_serie || if i.descricao is null then '' else ' - ' ||  i.descricao endif || if isnull(eq.numero_registro,'') = '' then '' else ' (' || eq.numero_registro || ') ' endif || eq.referencia endif) || ': &lt;/b&gt;' || ( select list(pvsi.servico_solicitado, ' / ')
                                                                                                                                                                                                                                                                             from pedido_venda_solicitacao pvsi
                                                                                                                                                                                                                                                                            where pvsi.empresa                 = pv.empresa
                                                                                                                                                                                                                                                                              and pvsi.estabelecimento         = pv.estabelecimento
                                                                                                                                                                                                                                                                              and pvsi.cod_pedido_venda        = pv.cod_pedido_venda
                                                                                                                                                                                                                                                                              and isnull(pvsi.numero_serie,'') = isnull(eq.numero_serie,'')), '&lt;br&gt;')
          from pedido_venda_solicitacao pvs left outer join equipamento eq on pvs.empresa = eq.empresa and pvs.numero_serie = eq.numero_serie
                                            left outer join item i on i.cod_item = eq.cod_item
         where pvs.empresa          = pv.empresa
           and pvs.estabelecimento  = pv.estabelecimento
           and pvs.cod_pedido_venda = pv.cod_pedido_venda) servicos_solicitados,
       (select list(distinct trim('&lt;b&gt;Equipamento: ' || if eq.numero_serie is null then '(não informado)' else eq.numero_serie || if i.descricao is null then '' else ' - ' ||  i.descricao endif || if isnull(eq.numero_registro,'') = '' then '' else ' (' || eq.numero_registro || ') ' endif || eq.referencia endif) || ': &lt;/b&gt;' || ( select list(pvsi.narrativa, ' / ')
                                                                                                                                                                                                                                                                             from pedido_venda_item pvsi
                                                                                                                                                                                                                                                                            where pvsi.empresa                 = pv.empresa
                                                                                                                                                                                                                                                                              and pvsi.estabelecimento         = pv.estabelecimento
                                                                                                                                                                                                                                                                              and pvsi.cod_pedido_venda        = pv.cod_pedido_venda
                                                                                                                                                                                                                                                                              and isnull(pvsi.numero_serie,'') = isnull(eq.numero_serie,'')), '&lt;br&gt;')
          from pedido_venda_item pvs left outer join equipamento eq on pvs.empresa = eq.empresa and pvs.numero_serie = eq.numero_serie
                                     left outer join item i on i.cod_item = eq.cod_item
         where pvs.empresa          = pv.empresa
           and pvs.estabelecimento  = pv.estabelecimento
           and pvs.cod_pedido_venda = pv.cod_pedido_venda) servicos_realizados,
       sum(pvi.valor_total_mercadoria) total_pedido
  from chamado c left outer join pedido_venda pv on c.empresa = pv.empresa and c.cod_chamado = pv.cod_chamado
                 left outer join pedido_venda_item pvi on pvi.empresa = pv.empresa and pvi.estabelecimento = pv.estabelecimento and pvi.cod_pedido_venda = pv.cod_pedido_venda
                 left outer join tipo_chamado tc on tc.empresa = c.empresa and c.tipo_chamado = tc.codigo
 where isnull(date(c.data_chamado),'1900-01-01') between convert(date,f_isnull_or_empty(:da1,'01/01/1900'),103) and convert(date,f_isnull_or_empty(:da2,'31/12/2199'),103)
   and isnull(date(c.data_encerramento),'1900-01-01') between convert(date,f_isnull_or_empty(:de1,'01/01/1900'),103) and convert(date,f_isnull_or_empty(:de2,'31/12/2199'),103)
   and :tch in (isnull(c.tipo_chamado,-1),0)
   and :tco in (isnull(pvi.cod_tipo_cobranca_os,-1),0)
   and c.cod_emitente = f_isnull_or_empty(:cl, c.cod_emitente)
   and isnull(pvi.numero_serie,'') = f_isnull_or_empty(:eq, isnull(pvi.numero_serie,''))
   and c.cod_emitente = :cod_emitente
 group by pv.empresa, pv.estabelecimento, pv.cod_pedido_venda, c.cod_chamado, c.data_chamado, c.data_encerramento, tc.nome
 order by c.cod_chamado, pv.cod_pedido_venda">
                                <SelectParameters>
                                    <asp:QueryStringParameter ConvertEmptyStringToNull="False" DbType="String" 
                                        Name="da1" QueryStringField="da1" />
                                    <asp:QueryStringParameter ConvertEmptyStringToNull="False" DbType="String" 
                                        Name="da2" QueryStringField="da2" />
                                    <asp:QueryStringParameter ConvertEmptyStringToNull="False" DbType="String" 
                                        Name="de1" QueryStringField="de1" />
                                    <asp:QueryStringParameter ConvertEmptyStringToNull="False" DbType="String" 
                                        Name="de2" QueryStringField="de2" />
                                    <asp:QueryStringParameter ConvertEmptyStringToNull="False" DbType="String" 
                                        Name="tch" QueryStringField="tch" />
                                    <asp:QueryStringParameter ConvertEmptyStringToNull="False" DbType="String" 
                                        Name="tco" QueryStringField="tco" />
                                    <asp:QueryStringParameter ConvertEmptyStringToNull="False" DbType="String" 
                                        Name="cl" QueryStringField="cl" />
                                    <asp:QueryStringParameter ConvertEmptyStringToNull="False" DbType="String" 
                                        Name="eq" QueryStringField="eq" />
                                    <asp:ControlParameter ControlID="LblCodEmitente" Name="cod_emitente" 
                                        PropertyName="Text" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                            <br />
                            Resumo por Tipo de Chamado<asp:GridView ID="GridView2" runat="server" 
                                AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource2" 
                                OnDataBound="GridView2_DataBound"
                                ForeColor="#333333" GridLines="None" ShowFooter="True" Width="370px" 
                                AllowSorting="True">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Tipo de Chamado" 
                                        SortExpression="nome_tipo_chamado">
                                        <EditItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("nome_tipo_chamado") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            Total
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("nome_tipo_chamado") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" Font-Bold="False"/>
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Qtd. Chamados" SortExpression="qtd_chamado">
                                        <EditItemTemplate>
                                            <asp:Label ID="Label7" runat="server" Text='<%# Eval("qtd_chamado") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="LblQtdTotalChamados0" runat="server" Text="0"></asp:Label>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="LblQtdChamados0" runat="server" Text='<%# Bind("qtd_chamado") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" Font-Bold="False"/>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="R$ Total" SortExpression="valor_total">
                                        <EditItemTemplate>
                                            <asp:Label ID="Label8" runat="server" Text='<%# Eval("valor_total") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="LblTotal0" runat="server" Text="0,00"></asp:Label>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="LblValorOS0" runat="server" 
                                                Text='<%# Bind("valor_total", "{0:F2}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" />
                                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" Font-Bold="False" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
                                    </asp:TemplateField>
                                </Columns>
                                <EditRowStyle BackColor="#999999" />
                                <FooterStyle BackColor="White" Font-Bold="True" ForeColor="#333333" />
                                <HeaderStyle BackColor="White" Font-Bold="False" ForeColor="#333333" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="White" ForeColor="#333333" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                            </asp:GridView>
                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                                ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select isnull(tc.nome,'(não informado)') nome_tipo_chamado,
       count(distinct c.cod_chamado) qtd_chamado,
       sum(pvi.valor_total_mercadoria) valor_total
  from chamado c left outer join pedido_venda pv on c.empresa = pv.empresa and c.cod_chamado = pv.cod_chamado
                 left outer join pedido_venda_item pvi on pvi.empresa = pv.empresa and pvi.estabelecimento = pv.estabelecimento and pvi.cod_pedido_venda = pv.cod_pedido_venda
                 left outer join tipo_chamado tc on tc.empresa = c.empresa and c.tipo_chamado = tc.codigo
 where isnull(date(c.data_chamado),'1900-01-01') between convert(date,f_isnull_or_empty(:da1,'01/01/1900'),103) and convert(date,f_isnull_or_empty(:da2,'31/12/2199'),103)
   and isnull(date(c.data_encerramento),'1900-01-01') between convert(date,f_isnull_or_empty(:de1,'01/01/1900'),103) and convert(date,f_isnull_or_empty(:de2,'31/12/2199'),103)
   and :tch in (isnull(c.tipo_chamado,-1),0)
   and :tco in (isnull(pvi.cod_tipo_cobranca_os,-1),0)
   and c.cod_emitente = f_isnull_or_empty(:cl, c.cod_emitente)
   and isnull(pvi.numero_serie,'') = f_isnull_or_empty(:eq, isnull(pvi.numero_serie,''))
   and c.cod_emitente = :cod_emitente
 group by tc.nome">
                                <SelectParameters>
                                    <asp:QueryStringParameter ConvertEmptyStringToNull="False" DbType="String" 
                                        Name="da1" QueryStringField="da1" />
                                    <asp:QueryStringParameter ConvertEmptyStringToNull="False" DbType="String" 
                                        Name="da2" QueryStringField="da2" />
                                    <asp:QueryStringParameter ConvertEmptyStringToNull="False" DbType="String" 
                                        Name="de1" QueryStringField="de1" />
                                    <asp:QueryStringParameter ConvertEmptyStringToNull="False" DbType="String" 
                                        Name="de2" QueryStringField="de2" />
                                    <asp:QueryStringParameter ConvertEmptyStringToNull="False" DbType="String" 
                                        Name="tch" QueryStringField="tch" />
                                    <asp:QueryStringParameter ConvertEmptyStringToNull="False" DbType="String" 
                                        Name="tco" QueryStringField="tco" />
                                    <asp:QueryStringParameter ConvertEmptyStringToNull="False" DbType="String" 
                                        Name="cl" QueryStringField="cl" />
                                    <asp:QueryStringParameter ConvertEmptyStringToNull="False" DbType="String" 
                                        Name="eq" QueryStringField="eq" />
                                    <asp:ControlParameter ControlID="LblCodEmitente" Name="cod_emitente" 
                                        PropertyName="Text" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                            <br />
                        </div>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:TemplateField>
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="False" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select e.cod_emitente, e.nome
  from chamado c left outer join pedido_venda pv on c.empresa = pv.empresa and c.cod_chamado = pv.cod_chamado
                 left outer join pedido_venda_item pvi on pvi.empresa = pv.empresa and pvi.estabelecimento = pv.estabelecimento and pvi.cod_pedido_venda = pv.cod_pedido_venda
                 left outer join tipo_chamado tc on tc.empresa = c.empresa and c.tipo_chamado = tc.codigo
                 inner join emitente e on e.cod_emitente = c.cod_emitente
 where isnull(date(c.data_chamado),'1900-01-01') between convert(date,f_isnull_or_empty(:da1,'01/01/1900'),103) and convert(date,f_isnull_or_empty(:da2,'31/12/2199'),103)
   and isnull(date(c.data_encerramento),'1900-01-01') between convert(date,f_isnull_or_empty(:de1,'01/01/1900'),103) and convert(date,f_isnull_or_empty(:de2,'31/12/2199'),103)
   and :tch in (isnull(c.tipo_chamado,-1),0)
   and :tco in (isnull(pvi.cod_tipo_cobranca_os,-1),0)
   and c.cod_emitente = f_isnull_or_empty(:cl, c.cod_emitente)
   and isnull(pvi.numero_serie,'') = f_isnull_or_empty(:eq, isnull(pvi.numero_serie,''))
 group by e.cod_emitente, e.nome
 order by e.nome, e.cod_emitente">
            <SelectParameters>
                <asp:QueryStringParameter ConvertEmptyStringToNull="False" DbType="String" Name="da1" QueryStringField="da1" />
                <asp:QueryStringParameter ConvertEmptyStringToNull="False" DbType="String" Name="da2" QueryStringField="da2" />
                <asp:QueryStringParameter ConvertEmptyStringToNull="False" DbType="String" Name="de1" QueryStringField="de1" />
                <asp:QueryStringParameter ConvertEmptyStringToNull="False" DbType="String" Name="de2" QueryStringField="de2" />
                <asp:QueryStringParameter ConvertEmptyStringToNull="False" DbType="String" Name="tch" QueryStringField="tch" />
                <asp:QueryStringParameter ConvertEmptyStringToNull="False" DbType="String" Name="tco" QueryStringField="tco" />
                <asp:QueryStringParameter ConvertEmptyStringToNull="False" DbType="String" Name="cl" QueryStringField="cl" />
                <asp:QueryStringParameter ConvertEmptyStringToNull="False" DbType="String" Name="eq" QueryStringField="eq" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
