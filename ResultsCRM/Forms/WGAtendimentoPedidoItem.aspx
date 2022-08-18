<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGAtendimentoPedidoItem.aspx.vb" Inherits="ResultsCRM.WGAtendimentoPedidoItem" %>

<%@ Register src="../UserControls/WUCAtendimentoPedidoCabecalho.ascx" tagname="WUCAtendimentoPedidoCabecalho" tagprefix="uc1" %>

<%@ Register src="../UserControls/WUCAtendimentoPedidoSolicitacao.ascx" tagname="WUCAtendimentoPedidoSolicitacao" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
    <style type="text/css">


.popup_Buttons
{
	margin:10px;
}

.popupConfirmation
{
	width: 370px;
	height: 350px;
}

        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="LblErro" runat="server" CssClass="Erro" BackColor="#FFFFE8" 
            Width="100%"></asp:Label>
    
        </div>
    <div class="TextoCadastro_BGBranco" 
        style="border-width: 1px; border-color: #C0C0C0; border-style: solid">
        <table style="width:100%;">
            <tr>
                <td>
                    <uc1:WUCAtendimentoPedidoCabecalho ID="WUCAtendimentoPedidoCabecalho1" 
                        runat="server" />
                </td>
            </tr>
        </table>
    </div>
    <div class="TextoCadastro_BGBranco" 
        style="border-width: 1px; border-color: #C0C0C0; border-style: solid">
    
        <table style="width:100%;">
            <tr>
                <td>
                    Serviços Solicitados</td>
                <td style="text-align: right">
                    <asp:ImageButton ID="BtnIncluirServicoSolicitado" runat="server" 
                        ImageUrl="~/Imagens/BtnNovoRegistro.png" />
    
                </td>
            </tr>
            <tr>
                <td colspan="2">
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" CssClass="TextoCadastro_BGBranco" 
            DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" 
            Width="100%" 
                        
                        
                        EmptyDataText="Você ainda não incluiu nenhum item nesta OS. Para adicionar itens, clique no botão &lt;b&gt;Novo Registro&lt;/b&gt; acima.">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Right" 
                VerticalAlign="Top" />
            <Columns>
                <asp:TemplateField HeaderText="Seq." SortExpression="seq_solicitacao">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("seq_solicitacao") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="LblSeq" runat="server" 
                            Text='<%# Eval("seq_solicitacao", "{0:F0}") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Equipamento / Solicitação" 
                    SortExpression="numero_serie">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("numero_serie") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="LblNumeroSerie" runat="server" 
                            Text='<%# Bind("numero_serie") %>' Font-Bold="True"></asp:Label>
                        &nbsp;-
                        <asp:Label ID="LblDescEquipamento" runat="server" Font-Bold="True" 
                            Text='<%# Eval("desc_equipamento") %>'></asp:Label>
                        <br />
                        <asp:Label ID="LblServicoSolicitado" runat="server" 
                            Text='<%# Eval("servico_solicitado") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:BoundField DataField="tipo_servico" HeaderText="Tipo Serviço" 
                    SortExpression="tipo_servico">
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" 
                            CommandArgument='<%# Eval("seq_solicitacao") %>' CommandName="ALTERAR" 
                            ImageUrl="~/Imagens/BtnEditar.png" ToolTip="Editar Item da OS" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton3" runat="server" 
                            CommandArgument='<%# Eval("seq_solicitacao") %>' CommandName="EXCLUIR" 
                            ImageUrl="~/Imagens/BtnExcluir.png" 
                            onclientclick="return confirm('ATENÇÃO: Procedimento irreversível! &nbsp;&nbsp;Deseja realmente excluir o item selecionado?');" 
                            ToolTip="Excluir" />
                    </ItemTemplate>
                </asp:TemplateField>
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
            SelectCommand="select convert(char,:tpfat) tpfat, pi.cod_pedido_venda, pi.seq_solicitacao, pi.numero_serie, if tpfat = 'G' then i.descricao || ' (' || i.cod_item || ') ' || eq.referencia else eq.observacao endif desc_equipamento, pi.servico_solicitado,
(select list(ta.descricao, ', ') from pedido_venda_solicitacao_tipo_servico_atendimento ts inner join tipo_servico_atendimento ta on ts.cod_tipo_servico = ta.cod_tipo_servico where ts.empresa = pi.empresa and ts.estabelecimento = pi.estabelecimento and ts.cod_pedido_venda = pi.cod_pedido_venda and ts.seq_solicitacao = pi.seq_solicitacao) tipo_servico
  from pedido_venda p inner join pedido_venda_solicitacao pi on p.empresa          = pi.empresa
                                                     and p.estabelecimento  = pi.estabelecimento
                                                     and p.cod_pedido_venda = pi.cod_pedido_venda
                       left outer join equipamento eq on eq.numero_serie = pi.numero_serie
                                                    and eq.empresa      = pi.empresa
                       left outer join item i on eq.cod_item = i.cod_item
 where p.empresa           = :empresa
   and p.estabelecimento   = :estabelecimento
   and p.cod_pedido_venda  = :cod_pedido
order by pi.seq_solicitacao">
            <SelectParameters>
                <asp:SessionParameter ConvertEmptyStringToNull="False" DbType="String" 
                    Name=":tpfat" SessionField="GlTipoFaturamento" />
                <asp:SessionParameter DefaultValue="" Name=":empresa" 
                    SessionField="GlEmpresa" />
                <asp:SessionParameter Name=":estabelecimento" 
                    SessionField="GlEstabelecimento" />
                <asp:SessionParameter Name=":cod_pedido" 
                    SessionField="SAtCodPedido" />
            </SelectParameters>
        </asp:SqlDataSource>
    
                </td>
            </tr>
        </table>
    
    </div>
    <div style="border-width: 1px; border-color: #C0C0C0; border-style: solid">
        <table class="TextoCadastro_BGBranco" style="width:100%;">
            <tr>
                <td colspan="2">
                    <asp:Label ID="LblAgTecnicoTitulo" runat="server" Text="Agentes Técnicos"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    <asp:Label ID="LblAgTecnico" runat="server" Text="Ag. Técnico:"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="DdlAgenteTecnico" runat="server" CssClass="CampoCadastro" 
                        Width="300px">
                    </asp:DropDownList>
                    <asp:Button ID="BtnVincularTecnico" runat="server" CssClass="Botao" 
                        Text="Vincular" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                        CellPadding="4" datasourceid="SqlDataSource2" 
                        EmptyDataText="Não há agente(s) técnico(s) vinculado(s). Escolha um agente técnico acima e clique no botão &lt;b&gt;Vincular&lt;/b&gt; para vinculá-lo." 
                        ForeColor="#333333" GridLines="None" Width="100%">
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <Columns>
                            <asp:BoundField DataField="cod_agente_tecnico" HeaderText="Cód." 
                                SortExpression="cod_agente_tecnico">
                                <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="nome_usuario" HeaderText="Nome Ag. Técnico" 
                                SortExpression="nome_usuario">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Desvincular">
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImageButton2" runat="server" 
                                        CommandArgument='<%# Eval("cod_agente_tecnico") %>' CommandName="EXCLUIR" 
                                        ImageUrl="~/Imagens/BtnExcluir.png" 
                                        onclientclick="return confirm('Deseja realmente desvincular o técnico selecionado?');" />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#999999" />
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select p.cod_agente_tecnico , u.nome nome_usuario
  from pedido_venda_agente_tecnico p inner join agente_tecnico u on u.cod_agente_tecnico = p.cod_agente_tecnico
 where p.empresa = :empresa
   and p.estabelecimento = :estabelecimento
   and p.cod_pedido_venda = :codPedidoVenda
order by nome_usuario">
                        <SelectParameters>
                            <asp:SessionParameter Name=":empresa" SessionField="GlEmpresa" />
                            <asp:SessionParameter Name=":estabelecimento" 
                                SessionField="GlEstabelecimento" />
                            <asp:SessionParameter Name=":codPedidoVenda" SessionField="SAtCodPedido" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
            </tr>
        </table>
    </div>
    
    <div style="border-width: 1px; border-color: #C0C0C0; border-style: solid">
        <table class="TextoCadastro_BGBranco" style="width:100%;">
            <tr>
                <td c>
                    <asp:Label ID="LblMateriaisTitulo" runat="server" Text="Materiais Solicitados"></asp:Label>
                </td>
                <td style="text-align: right">
                    <asp:ImageButton ID="BtnIncluirSolicitacaoMaterial" runat="server" 
                        ImageUrl="~/Imagens/BtnNovoRegistro.png" />
    
                </td>
            </tr>
            <tr>
                <td colspan="2" 
                    style="border-width: 1px; border-color: #C0C0C0; border-style: solid">
    
        <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" CssClass="TextoCadastro_BGBranco" 
            DataSourceID="SqlDataSource3" ForeColor="#333333" GridLines="None" 
            Width="100%" ShowFooter="True" 
                        
                        
                        EmptyDataText="Você ainda não incluiu nenhuma solicitação de material nesta OS. Clique no botão &lt;b&gt;Novo Registro&lt;/b&gt; acima para incluir uma." 
                        AllowSorting="True">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" 
                VerticalAlign="Top" />
            <Columns>
                <asp:BoundField DataField="cod_solicitacao" HeaderText="Cód. Solicitação" 
                    SortExpression="cod_solicitacao">
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="nome" HeaderText="Agente Técnico" 
                    SortExpression="nome" >
                <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="descricao" HeaderText="Item" 
                    SortExpression="descricao" >
                <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="quantidade" DataFormatString="{0:F4}" 
                    HeaderText="Quantidade" SortExpression="quantidade">
                <HeaderStyle HorizontalAlign="Right" />
                <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="data_solicitacao" DataFormatString="{0:dd/MM/yyyy}" 
                    HeaderText="Solicitação" SortExpression="data_solicitacao" >
                <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="data_entrega" DataFormatString="{0:dd/MM/yyyy}" 
                    HeaderText="Entrega" SortExpression="data_entrega" >
                <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="prioridade_descricao" HeaderText="Prioridade" 
                    SortExpression="prioridade_descricao" >
                <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton4" runat="server" 
                            CommandArgument='<%# eval("cod_solicitacao") %>' CommandName="ALTERAR" 
                            ImageUrl="~/Imagens/BtnEditar.png" ToolTip="Editar Solicitação" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton5" runat="server" 
                            CommandArgument='<%# Eval("cod_solicitacao") %>' CommandName="EXCLUIR" 
                            ImageUrl="~/Imagens/BtnExcluir.png" 
                            onclientclick="return confirm('ATENÇÃO: Procedimento irreversível! &nbsp;&nbsp;Deseja realmente excluir esta solicitação?');" 
                            ToolTip="Excluir Solicitação" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                HorizontalAlign="Right" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                HorizontalAlign="Left" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
            SelectCommand="select st.cod_solicitacao,
       st.cod_solicitante,
       su.nome_usuario nome_solicitante, 
       st.cod_agente_tecnico, 
       tec.nome, 
       st.cod_item, 
       it.descricao, 
       st.quantidade, 
       st.data_solicitacao, 
       st.data_entrega, 
       st.prioridade, 
       case st.prioridade when '1' then 'Normal' when '2' then 'Urgente' else 'Normal' end prioridade_descricao,
       st.situacao,
       case isnull(st.situacao,'1') when '1' then 'Pendente' when 2 then 'Transf. Gerada' else convert(varchar(30),st.situacao) end situacao_descricao,
       st.forma_entrega,
       case st.forma_entrega when '1' then 'Retirada' when '2' then 'Transportadora' when '3' then 'SEDEX' when '4' then 'SEDEX 10' else convert(varchar(30),st.forma_entrega) end forma_entrega_descricao
  from solicitacao_tecnico st inner join sysusuario su on st.cod_solicitante = su.cod_usuario
                              inner join agente_tecnico tec on tec.cod_agente_tecnico = st.cod_agente_tecnico
                              inner join item it on it.cod_item = st.cod_item
 where st.empresa = :empresa
   and st.estabelecimento = :estabelecimento
   and st.cod_pedido_venda = :cod_pedido">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="" Name=":empresa" 
                    SessionField="GlEmpresa" />
                <asp:SessionParameter Name=":estabelecimento" 
                    SessionField="GlEstabelecimento" />
                <asp:SessionParameter Name=":cod_pedido" 
                    SessionField="SAtCodPedido" />
            </SelectParameters>
        </asp:SqlDataSource>
    
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LblItensOSTitulo" runat="server" Text="Serviços Executados/Itens"></asp:Label>
                </td>
                <td style="text-align: right">
                    <asp:ImageButton ID="BtnIncluirItem" runat="server" ImageUrl="~/Imagens/BtnNovoRegistro.png" Visible="False" />
                </td>
            </tr>
            <tr>
                <td colspan="2" 
                    style="border-width: 1px; border-color: #C0C0C0; border-style: solid">
    
        <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" CssClass="TextoCadastro_BGBranco" 
            DataSourceID="SqlDataSource4" ForeColor="#333333" GridLines="None" 
            Width="100%" ShowFooter="True" 
                        
                        
                        
                        EmptyDataText="Você ainda não incluiu nenhum item nesta OS. Clique no botão &lt;b&gt;Novo Registro&lt;/b&gt; acima para incluir um item." 
                        Visible="False">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Right" 
                VerticalAlign="Top" />
            <Columns>
                <asp:TemplateField HeaderText="Seq. Item" SortExpression="seq_item">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("seq_item") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="LblSeq0" runat="server" Text='<%# Bind("seq_item", "{0:F0}") %>'></asp:Label>
                        <asp:Label ID="LblValorVisible" runat="server" 
                            Text='<%# Eval("valor_visible") %>' Visible="False"></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:BoundField DataField="seq_solicitacao" HeaderText="Seq. Solic." 
                    SortExpression="seq_solicitacao" Visible="False">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Serv. Executado / Item" 
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
                        <br />
                        <asp:Label ID="LblNarrativa" runat="server" Text='<%# Eval("narrativa") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Equipamento / Componente" 
                    SortExpression="desc_equipamento" Visible="False">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox5" runat="server" 
                            Text='<%# Bind("desc_equipamento") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Italic="False" 
                            Text='<%# Bind("desc_equipamento") %>'></asp:Label>
                        (<asp:Label ID="Label2" runat="server" Font-Bold="True" 
                            Text='<%# Eval("numero_registro") %>'></asp:Label>
                        )<br />
                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("ic_Descricao") %>'></asp:Label>
                        &nbsp;-
                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("observacao") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:BoundField DataField="qtd_pedida" HeaderText="Qtd." 
                    SortExpression="qtd_pedida" DataFormatString="{0:F2}">
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Preço Unit." SortExpression="preco_unitario">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("preco_unitario") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="LblPrecoUnitario" runat="server" 
                            Text='<%# Bind("preco_unitario", "R$ {0:F2}") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Total" SortExpression="valor_total_mercadoria">
                    <ItemTemplate>
                        R$
                        <asp:Label ID="LblValorTotal" runat="server" 
                            Text='<%# Bind("valor_total_mercadoria", "{0:F2}") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" 
                            Text='<%# Bind("valor_total_mercadoria") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        R$
                        <asp:Label ID="LblTotalGeral" runat="server" Text="0,00"></asp:Label>
                    </FooterTemplate>
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton6" runat="server" 
                            CommandArgument='<%# eval("seq_item") %>' CommandName="ALTERAR" 
                            ImageUrl="~/Imagens/BtnEditar.png" ToolTip="Editar Item da OS" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton7" runat="server" 
                            CommandArgument='<%# Eval("seq_item") %>' CommandName="EXCLUIR" 
                            ImageUrl="~/Imagens/BtnExcluir.png" 
                            onclientclick="return confirm('ATENÇÃO: Procedimento irreversível! &nbsp;&nbsp;Deseja realmente excluir o item selecionado?');" 
                            ToolTip="Excluir" />
                    </ItemTemplate>
                </asp:TemplateField>
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
        <asp:SqlDataSource ID="SqlDataSource4" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
            SelectCommand="select convert(char,:tpfat) tpfat, pi.cod_pedido_venda, pi.seq_item, pi.numero_serie, if tpfat = 'G' then eq.cod_item else eq.numero_registro endif numero_registro, if tpfat = 'G' then (select descricao from item where cod_item = eq.cod_item) else eq.observacao endif desc_equipamento, pi.seq_componente, if tpfat = 'G' then eq.referencia else ic.descricao endif ic_Descricao, eqc.observacao, pi.servico_solicitado, pi.cod_item, i.descricao, pi.narrativa || ' ' || trim(isnull(narrativa_complementar,'')) narrativa, pi.qtd_pedida, pi.preco_unitario, pi.valor_total_mercadoria, pi.seq_solicitacao,
       if i.tipo_despesa_consultor in (1,2) then '&lt;br&gt; Data: ' || convert(varchar(10), pi.data_entrega, 103) || ' ' || if isnull(pi.km_inicial,0) &gt; 0 then ' KM Inicial: ' || isnull(pi.km_inicial,0) else '' endif || ' ' || if isnull(pi.km_final,0) &gt; 0 then ' KM Final: ' || isnull(pi.km_final,0) else '' endif || ' ' || if isnull(pi.hora_inicial,'') &lt;&gt; '' then ' - Horário: ' || isnull(pi.hora_inicial,'') || ' às ' || isnull(pi.hora_final,'') else '' endif else '' endif || if pi.cod_agente_tecnico is null then '' else '&lt;br&gt;Técnico: ' || (select nome from agente_tecnico where cod_agente_tecnico = pi.cod_agente_tecnico) endif narrativa_complementar,
if isnull(pm.mostrar_valor_os_crm,'N') = 'S' then 'True' else 'False' endif valor_visible
  from pedido_venda p inner join pedido_venda_item pi on p.empresa          = pi.empresa
                                                     and p.estabelecimento  = pi.estabelecimento
                                                     and p.cod_pedido_venda = pi.cod_pedido_venda
                      left outer join item i on pi.cod_item = i.cod_item
                      left outer join equipamento eq on eq.numero_serie = pi.numero_serie
                                                    and eq.empresa      = pi.empresa
                      left outer join equipamento_componente eqc on eqc.empresa = eq.empresa
                                                                and eqc.numero_serie = eq.numero_serie
                                                                and eqc.seq_componente = pi.seq_componente
                      left outer join item ic on ic.cod_item = eqc.cod_item
                      left outer join parametros_manutencao pm on pm.empresa = p.empresa and pm.estabelecimento = p.estabelecimento
 where p.empresa         = :empresa
   and p.estabelecimento = :estabelecimento
   and p.cod_pedido_venda    = :cod_pedido
order by pi.seq_item desc">
            <SelectParameters>
                <asp:SessionParameter ConvertEmptyStringToNull="False" DbType="String" 
                    Name=":tpfat" SessionField="GlTipoFaturamento" />
                <asp:SessionParameter DefaultValue="" Name=":empresa" 
                    SessionField="GlEmpresa" />
                <asp:SessionParameter Name=":estabelecimento" 
                    SessionField="GlEstabelecimento" />
                <asp:SessionParameter Name=":cod_pedido" 
                    SessionField="SAtCodPedido" />
            </SelectParameters>
        </asp:SqlDataSource>
    
                    <br />
    
                </td>
            </tr>
            <tr>
                <td>
    
                    Despesas Acessórias</td>
                <td style="text-align: right">
    
                    <asp:ImageButton ID="BtnIncluirDespesaAcessoria" runat="server" 
                        ImageUrl="~/Imagens/BtnNovoRegistro.png" />
    
                </td>
            </tr>
            <tr>
                <td colspan="2" 
                    style="border-width: 1px; border-color: #C0C0C0; border-style: solid">
    
        <asp:GridView ID="GridView6" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" CssClass="TextoCadastro_BGBranco" 
            DataSourceID="SqlDataSource6" ForeColor="#333333" GridLines="None" 
            Width="100%" ShowFooter="True" 
                        
                        
                        
                        
                        EmptyDataText="Você ainda não incluiu nenhuma despesa nesta OS. Clique no botão &lt;b&gt;Novo Registro&lt;/b&gt; acima para incluir uma despesa.">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Right" 
                VerticalAlign="Top" />
            <Columns>
                <asp:BoundField DataField="cod_tipo_desp_acess" HeaderText="Código" 
                    SortExpression="cod_tipo_desp_acess" ReadOnly="True" >
                    <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="descricao" HeaderText="Descrição" 
                    SortExpression="descricao" >
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="valor" DataFormatString="{0:F2}" HeaderText="Valor" 
                    SortExpression="valor">
                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton2" runat="server" 
                            CommandArgument='<%# Eval("cod_tipo_desp_acess") %>' CommandName="ALTERAR" 
                            ImageUrl="~/Imagens/BtnEditar.png" ToolTip="Editar o registro" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton3" runat="server" 
                            CommandArgument='<%# Eval("cod_tipo_desp_acess") %>' CommandName="EXCLUIR" 
                            ImageUrl="~/Imagens/BtnExcluir.png" 
                            onclientclick="return confirm('Deseja excluir o registro selecionado?');" 
                            ToolTip="Excluir o registro" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                HorizontalAlign="Right" VerticalAlign="Bottom" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource6" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select t.cod_tipo_desp_acess, t.descricao, n.valor
  from pedido_venda_despesas n inner join tipo_despesa_acessoria t on t.empresa = n.empresa and n.cod_tipo_desp_acess = t.cod_tipo_desp_acess
 where n.cod_pedido_venda = :codPedido
   and n.empresa = :empresa
   and n.estabelecimento = :estabelecimento
order by t.descricao">
            <SelectParameters>
                <asp:SessionParameter Name=":codPedido" SessionField="SAtCodPedido" />
                <asp:SessionParameter Name=":empresa" SessionField="GlEmpresa" />
                <asp:SessionParameter Name=":estabelecimento" 
                    SessionField="GlEstabelecimento" />
            </SelectParameters>
        </asp:SqlDataSource>
    
                </td>
            </tr>
            <tr>
                <td>
    
                    <asp:Label ID="LblFollowUpOS" runat="server" 
                        Text="Follow-UP da OS"></asp:Label>
    
                </td>
                <td style="text-align: right">
    
                    <asp:ImageButton ID="BtnIncluirFollowUpOS" runat="server" 
                        ImageUrl="~/Imagens/BtnNovoRegistro.png" Visible="False" />
    
                </td>
            </tr>
            <tr>
                <td colspan="2" 
                    style="border-width: 1px; border-color: #C0C0C0; border-style: solid">
    
        <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" CssClass="TextoCadastro_BGBranco" 
            DataSourceID="SqlDataSource5" ForeColor="#333333" GridLines="None" 
            Width="100%" 
                        
                        
                        EmptyDataText="Nenhum follow-up a exibir.">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Right" 
                VerticalAlign="Top" />
            <Columns>
                <asp:BoundField DataField="seq_follow_up" HeaderText="Seq." 
                    SortExpression="seq_follow_up">
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="data_follow_up" DataFormatString="{0:dd/MM/yyyy}" 
                    HeaderText="Data" SortExpression="data_follow_up">
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="descricao" HeaderText="Descrição" 
                    SortExpression="descricao">
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Usuário" SortExpression="nome_usuario">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("nome_usuario") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label6" runat="server" 
                            Text='<%# Bind("nome_usuario") %>'></asp:Label>
                        (<asp:Label ID="Label7" runat="server" Text='<%# Eval("cod_usuario") %>'></asp:Label>
                        )
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton8" runat="server" 
                            CommandArgument='<%# Eval("seq_follow_up") %>' CommandName="ALTERAR" 
                            ImageUrl="~/Imagens/BtnEditar.png" ToolTip="Editar Item da OS" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton9" runat="server" 
                            CommandArgument='<%# Eval("seq_follow_up") %>' CommandName="EXCLUIR" 
                            ImageUrl="~/Imagens/BtnExcluir.png" 
                            onclientclick="return confirm('ATENÇÃO: Procedimento irreversível! &nbsp;&nbsp;Deseja realmente excluir o follow-up selecionado?');" 
                            ToolTip="Excluir" />
                    </ItemTemplate>
                </asp:TemplateField>
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
        <asp:SqlDataSource ID="SqlDataSource5" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
            SelectCommand="  SELECT follow_up_emitente.seq_follow_up,   
         follow_up_emitente.data_follow_up,   
         follow_up_emitente.descricao,
         follow_up_emitente.cod_usuario,
         s.nome_usuario
    FROM follow_up_emitente inner join sysusuario s on follow_up_emitente.cod_usuario = s.cod_usuario
   WHERE follow_up_emitente.tipo = 3
     AND follow_up_emitente.empresa 			= :empresa
     AND follow_up_emitente.estabelecimento 	= :estabelecimento
     AND follow_up_emitente.cod_pedido_venda = :cod_pedido">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="" Name=":empresa" 
                    SessionField="GlEmpresa" />
                <asp:SessionParameter Name=":estabelecimento" 
                    SessionField="GlEstabelecimento" />
                <asp:SessionParameter Name=":cod_pedido" 
                    SessionField="SAtCodPedido" />
            </SelectParameters>
        </asp:SqlDataSource>
    
                </td>
            </tr>
            <tr>
                <td colspan="2">
    
                    Nota Fiscal</td>
            </tr>
            <tr>
                <td colspan="2" 
                    style="border-width: 1px; border-color: #C0C0C0; border-style: solid">
    
        <asp:GridView ID="GridView7" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" CssClass="TextoCadastro_BGBranco" 
            DataSourceID="SqlDataSource7" ForeColor="#333333" GridLines="None" 
            Width="100%" 
                        
                        
                        EmptyDataText="Nenhuma nota fiscal a exibir." 
                        
                        DataKeyNames="empresa,estabelecimento,serie,cod_nfs,cod_item,cod_cond_pagto">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Right" 
                VerticalAlign="Top" />
            <Columns>
                <asp:BoundField DataField="data_faturamento" HeaderText="Data Faturamento" 
                    SortExpression="data_faturamento" DataFormatString="{0:dd/MM/yy}">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="serie" HeaderText="Série" 
                    SortExpression="serie" ReadOnly="True">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="cod_nfs" HeaderText="NF" ReadOnly="True" 
                    SortExpression="cod_nfs" >
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="seq_item_nfs" HeaderText="Seq. Item NF" 
                    SortExpression="seq_item_nfs" >
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="qtd_pedida" HeaderText="Qtd. Pedida" 
                    SortExpression="qtd_pedida" DataFormatString="{0:F2}" >
                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="qtd_entregue" HeaderText="Qtd. Faturada" 
                    SortExpression="qtd_entregue" DataFormatString="{0:F2}" >
                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="qtd_pendente" HeaderText="Qtd. Pendente" 
                    SortExpression="qtd_pendente" DataFormatString="{0:F2}" >
                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="seq_item" HeaderText="Seq. Item OS" 
                    SortExpression="seq_item" >
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Item" SortExpression="descricao">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("descricao") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("descricao") %>'></asp:Label>
                        (<asp:Label ID="Label8" runat="server" Text='<%# Eval("cod_item") %>'></asp:Label>
                        )
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Transportador" 
                    SortExpression="nome_transportador">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" 
                            Text='<%# Bind("nome_transportador") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("nome_transportador") %>'></asp:Label>
                        (<asp:Label ID="Label9" runat="server" Text='<%# Eval("cod_transportador") %>'></asp:Label>
                        )
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Condição de Pagamento" 
                    SortExpression="descricao_cond_pagto">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" 
                            Text='<%# Bind("descricao_cond_pagto") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" 
                            Text='<%# Bind("descricao_cond_pagto") %>'></asp:Label>
                        (<asp:Label ID="Label10" runat="server" Text='<%# Eval("cod_cond_pagto") %>'></asp:Label>
                        )
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:TemplateField>
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
        <asp:SqlDataSource ID="SqlDataSource7" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
            SelectCommand="SELECT nfs_faturamento.empresa,
		 nfs_faturamento.estabelecimento,
		 nfs_faturamento.serie,
		 nfs_faturamento.cod_nfs,
		 nfs_faturamento.seq_item_nfs,
		 nfs_faturamento.cod_pedido_venda,
		 nfs_faturamento.seq_item,
		 nfs_faturamento.seq_programacao,
		 nfs_faturamento.qtd_pedida,
		 nfs_faturamento.qtd_pendente,
		 nfs_faturamento.qtd_entregue,
		 nfs_faturamento.data_faturamento,
		 nfs_faturamento.tipo,
		 item.descricao,
		 item.cod_item,
		 item.cod_familia,
		 item.descricao_cupom_fisc,
		 nfs.atualizado,
		 nfs.atualizado_estoque,
		 nfs.cod_transportador,
		 nfs_faturamento.cod_cond_pagto,
       c.descricao descricao_cond_pagto, 
       (select nome from emitente where cod_emitente = nfs.cod_transportador) nome_transportador
  FROM nfs_faturamento left outer join cond_pagto_venda c on c.cod_cond_pagto = nfs_faturamento.cod_cond_pagto,
       item,
       pedido_venda_item,
		 nfs
 WHERE item.cod_item								= pedido_venda_item.cod_item
	AND nfs.situacao								= 1
   and isnull(nfs.situacao_nf_eletronica,1) &lt;&gt; 11
	AND nfs.cod_nfs								= nfs_faturamento.cod_nfs
	AND nfs.serie									= nfs_faturamento.serie
	AND nfs.estabelecimento						= nfs_faturamento.estabelecimento
	AND nfs.empresa								= nfs_faturamento.empresa
   AND pedido_venda_item.seq_item 			= nfs_faturamento.seq_item
   AND pedido_venda_item.cod_pedido_venda = nfs_faturamento.cod_pedido_venda
   AND pedido_venda_item.estabelecimento 	= nfs_faturamento.estabelecimento
   AND pedido_venda_item.empresa			 	= nfs_faturamento.empresa
   AND nfs_faturamento.cod_pedido_venda	= :cod_pedido
   AND nfs_faturamento.estabelecimento 	= :estabelecimento
   AND nfs_faturamento.empresa 				= :empresa">
            <SelectParameters>
                <asp:SessionParameter Name=":cod_pedido" 
                    SessionField="SAtCodPedido" />
                <asp:SessionParameter Name=":estabelecimento" 
                    SessionField="GlEstabelecimento" />
                <asp:SessionParameter DefaultValue="" Name=":empresa" 
                    SessionField="GlEmpresa" />
            </SelectParameters>
        </asp:SqlDataSource>
    
                </td>
            </tr>
        </table>
    </div>
    
    </form>
</body>
</html>
