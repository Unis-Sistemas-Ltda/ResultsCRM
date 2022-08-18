<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFImpressaoOSUnis.aspx.vb" Inherits="ResultsCRM.WFImpressaoOSUnis" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="Erro">
        <asp:Label ID="LblErro" runat="server"></asp:Label>
    </div>
<table style="width:750px; color: #000000; font-size: 8pt; font-family: 'Trebuchet MS'; border-collapse: collapse;" 
            class="TextoCadastro_BGBranco">
            <tr>
                <td rowspan="2" 
                    
                    
                    
                    style="text-align: left; border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #CCCCCC; border-top-style: solid; border-left-style: solid; border-left-width: 1px; border-top-width: 1px; border-left-color: #CCCCCC; border-top-color: #CCCCCC;">
                    <asp:Image ID="Image1" runat="server" Height="140px" 
                        ImageUrl="~/Imagens/logo_cliente_os.jpg" />
                </td>
                <td rowspan="2" 
                    
                    
                    
                    
                    style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #CCCCCC; border-top-style: solid; border-top-width: 1px; border-top-color: #CCCCCC; width: 500px;">
                    <asp:Label ID="LblRazaoSocialEmpresa" runat="server" Font-Bold="True"></asp:Label>
                    <br />
                    <asp:Label ID="LblEnderecoEmpresa" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="LblBairroEmpresa" runat="server"></asp:Label>
                    -
                    <asp:Label ID="LblMunicipioEmpresa" runat="server"></asp:Label>
                    /
                    <asp:Label ID="LblUFEmpresa" runat="server"></asp:Label>
                    <br />
                    Telefone:<asp:Label ID="LblTelefoneEmpresa1" runat="server"></asp:Label>
                    <br />
                    CNPJ:<asp:Label ID="LblCNPJEmpresa" runat="server"></asp:Label>
                    <br />
                    Insc. Est.:<asp:Label ID="LblInscEstEmpresa" runat="server"></asp:Label>
                    <br />
                </td>
                <td style="border: 1px solid #CCCCCC; text-align: center; width: 120px;">
                    Ordem de Serviço<br />
                    <asp:Label ID="LblCodOS" runat="server" Font-Bold="True"></asp:Label>
                    &nbsp;&nbsp;</td>
            </tr>
            <tr>
                <td style="border: 1px solid #CCCCCC; text-align: center">
                    Chamado<br />
                    <asp:Label ID="LblCodChamado" runat="server" Font-Bold="True"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3" 
                    
                    style="border: 1px solid #CCCCCC; text-align: center; font-weight: bold; font-size: 10pt">
                    <br />
                    ORDEM DE SERVIÇO<br />
                </td>
            </tr>
            <tr>
                <td colspan="3" 
                    style="border: 1px solid #CCCCCC; text-align: left; ">
                    <br />
                    <asp:Label ID="Label15" runat="server" Text="Cliente:" style="text-align: right" Width="120px"></asp:Label>
                    <asp:Label ID="LblNomeCliente" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="Label1" runat="server" Text="CNPJ:" style="text-align: right" Width="120px"></asp:Label><asp:Label ID="LblCNPJCliente" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="Label10" runat="server" Text="Endereço:" style="text-align: right" Width="120px"></asp:Label>
                    <asp:Label ID="LblEnderecoCliente" runat="server"></asp:Label>
                &nbsp;<asp:Label ID="LblBairroCliente" runat="server"></asp:Label>
                    <br /><asp:Label ID="Label16" runat="server" Text="Município:" style="text-align: right" Width="120px"></asp:Label>
                    <asp:Label ID="LblCidade" runat="server"></asp:Label>
&nbsp;/
                    <asp:Label ID="LblUF" runat="server"></asp:Label>
                &nbsp;- CEP:<asp:Label ID="LblCEP" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="Label17" runat="server" Text="Telefone:" style="text-align: right" Width="120px"></asp:Label><asp:Label ID="LblTelefone" runat="server"></asp:Label>
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td colspan="3" 
                    style="border: 1px solid #CCCCCC; text-align: left; ">
                    <br />
                    CONTABILIZAÇÃO DAS HORAS TRABALHADAS</td>
            </tr>
            <tr>
                <td colspan="3" 
                    style="border: 1px solid #CCCCCC; text-align: left; font-size: 10pt; ">
                    <div style="min-height: 375px">
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                        CellPadding="4" DataSourceID="SqlDataSource1" Font-Size="7pt" 
                                        ForeColor="#333333" GridLines="None" Width="100%">
                                        <AlternatingRowStyle ForeColor="#345C9A" />
                                        <Columns>
                                            <asp:BoundField DataField="tecnico" HeaderText="Consultor" ReadOnly="True" 
                                                SortExpression="tecnico">
                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="90px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="narrativa" HeaderText="Descrição" 
                                                ReadOnly="True" SortExpression="narrativa">
                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="data_entrega" DataFormatString="{0:dd/MM/yyyy}" 
                                                HeaderText="Data" ReadOnly="True" 
                                                SortExpression="data_entrega">
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="70px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="hora_inicial" HeaderText="Hora Inicial" ReadOnly="True" 
                                                SortExpression="hora_inicial">
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="70px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="hora_final" HeaderText="Hora Final" ReadOnly="True" 
                                                SortExpression="hora_final">
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="70px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="tempo" HeaderText="Total" ReadOnly="True" 
                                                SortExpression="tempo">
                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="70px" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="qtd_pedida" SortExpression="qtd_pedida" 
                                                Visible="False">
                                                <EditItemTemplate>
                                                    <asp:Label ID="Label2" runat="server" 
                                                        Text='<%# Eval("qtd_pedida", "{0:F4}") %>'></asp:Label>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label4" runat="server" 
                                                        Text='<%# Bind("qtd_pedida", "{0:F4}") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Tipo Cobrança" 
                                                SortExpression="descricao_tipo_cobranca">
                                                <EditItemTemplate>
                                                    <asp:Label ID="Label3" runat="server" 
                                                        Text='<%# Eval("descricao_tipo_cobranca") %>'></asp:Label>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label5" runat="server" 
                                                        Text='<%# Bind("descricao_tipo_cobranca") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="70px" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <EditRowStyle BackColor="#999999" />
                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle Font-Bold="True" Font-Underline="True" />
                                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle ForeColor="#333333" />
                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                    </asp:GridView>
                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                                        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="     select  pvi.narrativa,
             if pvi.qtd_pedida &gt;= 1 then floor(pvi.qtd_pedida) || 'h ' else '' endif || if pvi.qtd_pedida &lt;&gt; floor(pvi.qtd_pedida) then (60 * (pvi.qtd_pedida - floor(pvi.qtd_pedida))) || 'min' else '' endif  tempo,
             pvi.qtd_pedida,
             pvi.hora_inicial,
             pvi.hora_final,
             pvi.data_entrega,
             ( if pvi.cod_agente_tecnico is not null then (select nome from agente_tecnico where cod_agente_tecnico = pvi.cod_agente_tecnico) else (select list(ate.nome,' / ') from agente_tecnico ate inner join pedido_venda_agente_tecnico pat on pat.empresa = pvi.empresa and pat.estabelecimento = pvi.estabelecimento and pat.cod_pedido_venda = pvi.cod_pedido_venda) endif) tecnico,
             t.cod_tipo_cobranca_os,
             t.descricao descricao_tipo_cobranca
        from chamado c inner join pedido_venda pv on c.empresa = pv.empresa
                                                 and c.cod_chamado = pv.cod_chamado
                       inner join pedido_venda_item pvi on pvi.empresa          = pv.empresa
                                                       and pvi.estabelecimento  = pv.estabelecimento
                                                       and pvi.cod_pedido_venda = pv.cod_pedido_venda
                       inner join item i on i.cod_item = pvi.cod_item
                       left outer join tipo_cobranca_os t on t.cod_tipo_cobranca_os = pvi.cod_tipo_cobranca_os
       where pv.empresa = :empresa
         and pv.estabelecimento = :estabelecimento
         and pv.cod_pedido_venda = :cod_pedido_venda
         and i.tipo_despesa_consultor = 1">
                                        <SelectParameters>
                                            <asp:QueryStringParameter Name="empresa" QueryStringField="eid" />
                                            <asp:QueryStringParameter Name="estabelecimento" QueryStringField="sid" />
                                            <asp:QueryStringParameter Name="cod_pedido_venda" QueryStringField="pid" />
                                        </SelectParameters>
                                    </asp:SqlDataSource></div>
                </td>
            </tr>
            <tr>
                <td colspan="3" 
                    style="border: 1px solid #CCCCCC; text-align: left; ">
                    <br />
                    DESLOCAMENTO</td>
            </tr>
            <tr>
                <td colspan="3" 
                    
                    
                    style="border: 1px solid #CCCCCC; text-align: left; font-size: 10pt; vertical-align: top;">
                    <div style="min-height: 140px">
                                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                                        CellPadding="4" DataSourceID="SqlDataSource2" Font-Size="7pt" 
                                        ForeColor="#333333" GridLines="None" Width="100%" 
                                        
                                        EmptyDataText="&lt;br&gt;&lt;br&gt;Nenhum deslocamento foi contabilizado nesta ordem de serviço.&lt;br&gt;&lt;br&gt;">
                                        <AlternatingRowStyle ForeColor="#345C9A" />
                                        <Columns>
                                            <asp:BoundField DataField="tecnico" HeaderText="Consultor" ReadOnly="True" 
                                                SortExpression="tecnico">
                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="100px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="narrativa" HeaderText="Descrição" 
                                                ReadOnly="True" SortExpression="narrativa" Visible="False">
                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom"/>
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="local_origem" HeaderText="Local Origem" ReadOnly="True" 
                                                SortExpression="local_origem">
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="local_destino" HeaderText="Local Destino" ReadOnly="True" 
                                                SortExpression="local_destino">
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="data_entrega" DataFormatString="{0:dd/MM/yyyy}" 
                                                HeaderText="Data" ReadOnly="True" 
                                                SortExpression="data_entrega">
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="70px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="qtd_pedida" HeaderText="Qtd. Km" ReadOnly="True" 
                                                SortExpression="qtd_pedida" DataFormatString="{0:F1}">
                                                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="70px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="preco_unitario" HeaderText="R$/Km" ReadOnly="True" 
                                                SortExpression="preco_unitario" DataFormatString="{0:F2}">
                                                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="70px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="valor_total_mercadoria" HeaderText="R$ Total" ReadOnly="True" 
                                                SortExpression="valor_total_mercadoria" DataFormatString="{0:F2}">
                                                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="70px" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="qtd_pedida" SortExpression="qtd_pedida" 
                                                Visible="False">
                                                <EditItemTemplate>
                                                    <asp:Label ID="Label6" runat="server" 
                                                        Text='<%# Eval("qtd_pedida", "{0:F4}") %>'></asp:Label>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label7" runat="server" 
                                                        Text='<%# Bind("qtd_pedida", "{0:F4}") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Tipo Cobrança" 
                                                SortExpression="descricao_tipo_cobranca">
                                                <EditItemTemplate>
                                                    <asp:Label ID="Label8" runat="server" 
                                                        Text='<%# Eval("descricao_tipo_cobranca") %>'></asp:Label>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label9" runat="server" 
                                                        Text='<%# Bind("descricao_tipo_cobranca") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="70px" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <EditRowStyle BackColor="#999999" />
                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle Font-Bold="True" Font-Underline="True" />
                                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle ForeColor="#333333" />
                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                    </asp:GridView>
                                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" SelectCommand=" select  pvi.narrativa,
             pvi.qtd_pedida,
             pvi.local_origem,
             pvi.local_destino,
             pvi.data_entrega,
             ( if pvi.cod_agente_tecnico is not null then (select nome from agente_tecnico where cod_agente_tecnico = pvi.cod_agente_tecnico) else (select list(ate.nome,' / ') from agente_tecnico ate inner join pedido_venda_agente_tecnico pat on pat.empresa = pvi.empresa and pat.estabelecimento = pvi.estabelecimento and pat.cod_pedido_venda = pvi.cod_pedido_venda) endif) tecnico,
             t.cod_tipo_cobranca_os,
             t.descricao descricao_tipo_cobranca,
             pvi.preco_unitario,
             pvi.valor_total_mercadoria
        from chamado c inner join pedido_venda pv on c.empresa = pv.empresa
                                                 and c.cod_chamado = pv.cod_chamado
                       inner join pedido_venda_item pvi on pvi.empresa          = pv.empresa
                                                       and pvi.estabelecimento  = pv.estabelecimento
                                                       and pvi.cod_pedido_venda = pv.cod_pedido_venda
                       inner join item i on i.cod_item = pvi.cod_item
                       left outer join tipo_cobranca_os t on t.cod_tipo_cobranca_os = pvi.cod_tipo_cobranca_os
       where pv.empresa = :empresa
         and pv.estabelecimento = :estabelecimento
         and pv.cod_pedido_venda = :cod_pedido_venda
         and i.tipo_despesa_consultor = 2" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                                        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>">
                <SelectParameters>
                                            <asp:QueryStringParameter Name="empresa" QueryStringField="eid" />
                                            <asp:QueryStringParameter Name="estabelecimento" QueryStringField="sid" />
                                            <asp:QueryStringParameter Name="cod_pedido_venda" QueryStringField="pid" />
                                        </SelectParameters>
                </asp:SqlDataSource></div>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="border: 1px solid #CCCCCC; text-align: center">
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <asp:Label ID="Label11" runat="server" Text="__________________________" 
                        Width="185px"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label12" runat="server" Text="__________________________" 
                        Width="185px"></asp:Label>
                    <br />
                    <asp:Label ID="Label13" runat="server" Text="Assinatura do Consultor" 
                        Width="185px"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label14" runat="server" Text="Assinatura do Cliente" 
                        Width="185px"></asp:Label>
                    <br />
                    <br />
                                    </td>
            </tr>
            </table>
    </form>
</body>
</html>
