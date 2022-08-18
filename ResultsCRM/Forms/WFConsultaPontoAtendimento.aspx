<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFConsultaPontoAtendimento.aspx.vb" Inherits="ResultsCRM.WFConsultaPontoAtendimento" %>

<%@ Register src="../UserControls/WUCAtendimentoPedidoCabecalho.ascx" tagname="WUCAtendimentoPedidoCabecalho" tagprefix="uc1" %>

<%@ Register src="../UserControls/WUCAtendimentoPedidoItem.ascx" tagname="WUCAtendimentoPedidoItem" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="TituloConsulta">Histórico do Ponto de Atendimento</div>
    <div>
    
        <asp:Label ID="LblErro" runat="server" CssClass="Erro" BackColor="#FFFFE8" 
            Width="100%"></asp:Label>
    
        </div>
    <div class="TextoCadastro_BGBranco" 
        style="border-width: 1px; border-color: #C0C0C0; border-style: solid">
    
        <table style="width:100%; font-size: 10pt;">
            <tr>
                <td style="text-align: right">
    
                    <asp:Label ID="Label4" runat="server" Text="Cliente:"></asp:Label>
                </td>
                <td style="font-weight: bold">
    
                    <asp:Label ID="LblCodCliente" runat="server"></asp:Label>
                    -
                    <asp:Label ID="LblNomeCliente" runat="server"></asp:Label>
                </td>
                <td style="text-align: right">
    
                    <asp:Label ID="Label5" runat="server" Text="Ponto de Atendimento:"></asp:Label>
                </td>
                <td style="font-weight: bold">
    
                    <asp:Label ID="LblNumeroPontoAtendimento" runat="server"></asp:Label>
                    -
                    <asp:Label ID="LblNomePontoAtendimento" runat="server"></asp:Label>
                </td>
                <td style="text-align: right">
    
                    <asp:Button ID="BtnVoltar" runat="server" CssClass="Botao" Text="Voltar" />
                </td>
            </tr>
            <tr>
                <td style="text-align: right; font-size: 8pt;">
    
                    Equipamento:</td>
                <td style="font-size: 8pt;">
    
                    <asp:TextBox ID="TxtEquipamento" runat="server" AutoPostBack="True" 
                        CssClass="CampoCadastro" Width="150px"></asp:TextBox>
                </td>
                <td style="text-align: right; font-size: 8pt;">
    
                    Patrimônio:</td>
                <td style="font-size: 8pt;">
    
                    <asp:TextBox ID="TxtPatrimonio" runat="server" AutoPostBack="True" 
                        CssClass="CampoCadastro" Width="150px"></asp:TextBox>
                </td>
                <td style="text-align: right; font-size: 8pt;">
    
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="5">
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="5" CssClass="TextoCadastro_BGBranco" 
            DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" 
            Width="100%" 
                        EmptyDataText="Não há histórico para este Ponto de Atendimento." 
                        CellSpacing="1" EnableModelValidation="True">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Right" 
                VerticalAlign="Top" />
            <Columns>
                <asp:BoundField DataField="cod_pedido_venda" HeaderText="Nº OS" 
                    SortExpression="cod_pedido_venda">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="data_encerramento" 
                    DataFormatString="{0:dd/MM/yyyy HH:mm}" HeaderText="Encerramento" 
                    SortExpression="data_encerramento">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Seq. Item" SortExpression="seq_item" 
                    Visible="False">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("seq_item") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="LblSeq" runat="server" Text='<%# Bind("seq_item", "{0:F0}") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:BoundField DataField="seq_solicitacao" HeaderText="Seq. Solic." 
                    SortExpression="seq_solicitacao" Visible="False">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Equipamento" SortExpression="numero_serie">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("numero_serie") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("numero_serie") %>'></asp:Label>
                        &nbsp;-
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("desc_equipamento") %>'></asp:Label>
                        <br />
                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("componentes") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:BoundField DataField="numero_registro" HeaderText="Patrimônio" 
                    SortExpression="numero_registro">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Item" 
                    SortExpression="cod_item">
                    <EditItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("cod_item") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="LblCodItem" runat="server" Text='<%# Bind("cod_item") %>' 
                            Font-Bold="True"></asp:Label>
                        &nbsp;-
                        <asp:Label ID="LblDescricaoItem" runat="server" Text='<%# Eval("descricao") %>' 
                            Font-Bold="True"></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:BoundField DataField="narrativa" HeaderText="Serv. Realizado" 
                    SortExpression="narrativa">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="tecnicos" HeaderText="Técnico(s)" 
                    SortExpression="tecnicos">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
            </Columns>
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                HorizontalAlign="Right" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                HorizontalAlign="Right" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
            SelectCommand="select c.cod_emitente_atendimento, c.numero_ponto_atendimento, pi.cod_pedido_venda, pi.seq_item, pi.numero_serie, eq.observacao desc_equipamento, pi.servico_solicitado, pi.cod_item, i.descricao, pi.narrativa, pi.qtd_pedida, pi.preco_unitario, pi.valor_total_mercadoria, eq.numero_registro, pi.seq_solicitacao, p.data_entrega, p.data_encerramento,
       trim((select list(' ' || ate.nome || ' (' || pat.cod_agente_tecnico || ')') from pedido_venda_agente_tecnico pat inner join agente_tecnico ate on ate.cod_agente_tecnico = pat.cod_agente_tecnico where pat.empresa = p.empresa and pat.estabelecimento = p.estabelecimento and pat.cod_pedido_venda = p.cod_pedido_venda)) tecnicos,
       trim(list(' ' || (select trim(list(' ' || itq.descricao || if trim(isnull(eqcc.observacao,'')) &lt;&gt; '' then ' - ' || eqcc.observacao else '' endif))
                            from item itq inner join equipamento_componente eqcc on itq.cod_item = eqcc.cod_item
                           where eqcc.empresa = p.empresa
                             and eqcc.numero_serie = pi.numero_serie
                             and eqcc.seq_componente = pi.seq_componente))) componentes
  from pedido_venda p inner join pedido_venda_item pi on p.empresa          = pi.empresa
                                                     and p.estabelecimento  = pi.estabelecimento
                                                     and p.cod_pedido_venda = pi.cod_pedido_venda
                      left outer join item i on pi.cod_item = i.cod_item
                      left outer join equipamento eq on eq.numero_serie = pi.numero_serie
                                                    and eq.empresa      = pi.empresa
                      inner join chamado c on c.cod_chamado = p.cod_chamado
                                          and c.empresa     = p.empresa
 where p.empresa         = :empresa
   and p.estabelecimento = :estabelecimento
   and c.cod_emitente_atendimento    = :cod_emitente
   and c.numero_ponto_atendimento = :numero_ponto_atendimento
   and (isnull(pi.numero_serie,'') like '%' || :equip1 || '%' or isnull(desc_equipamento,'') like '%' || :equip2 || '%')
   and (isnull(eq.numero_registro,'') like '%' || :numero_registro || '%' )
group by p.empresa, p.estabelecimento, p.cod_pedido_venda, c.cod_emitente_atendimento, c.numero_ponto_atendimento, pi.cod_pedido_venda, pi.seq_item, pi.numero_serie, eq.observacao, pi.servico_solicitado, pi.cod_item, i.descricao, pi.narrativa, pi.qtd_pedida, pi.preco_unitario, pi.valor_total_mercadoria, pi.seq_solicitacao, p.data_entrega, p.data_encerramento, eq.numero_registro
order by p.cod_pedido_venda desc, pi.seq_item asc">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="" Name=":empresa" 
                    SessionField="GlEmpresa" />
                <asp:SessionParameter Name=":estabelecimento" 
                    SessionField="GlEstabelecimento" />
                <asp:QueryStringParameter Name=":cod_emitente" QueryStringField="ceid" />
                <asp:QueryStringParameter Name=":numero_ponto_atendimento" 
                    QueryStringField="paid" />
                <asp:ControlParameter ControlID="TxtEquipamento" 
                    ConvertEmptyStringToNull="False" Name=":equip1" PropertyName="Text" />
                <asp:ControlParameter ControlID="TxtEquipamento" 
                    ConvertEmptyStringToNull="False" Name=":equip2" PropertyName="Text" />
                <asp:ControlParameter ControlID="TxtPatrimonio" 
                    ConvertEmptyStringToNull="False" Name=":numero_registro" PropertyName="Text" />
            </SelectParameters>
        </asp:SqlDataSource>
    
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
