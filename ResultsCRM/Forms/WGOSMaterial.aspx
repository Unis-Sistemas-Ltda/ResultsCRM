<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGOSMaterial.aspx.vb" Inherits="ResultsCRM.WGOSMaterial" %>

<%@ Register src="../UserControls/WUCAtendimentoPedidoCabecalho.ascx" tagname="WUCAtendimentoPedidoCabecalho" tagprefix="uc1" %>

<%@ Register src="../UserControls/WUCAtendimentoPedidoItem.ascx" tagname="WUCAtendimentoPedidoItem" tagprefix="uc2" %>

<%@ Register src="../UserControls/WUCSolicitacaoMaterial.ascx" tagname="WUCSolicitacaoMaterial" tagprefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
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
    
                    <uc3:WUCSolicitacaoMaterial ID="WUCSolicitacaoMaterial1" runat="server" />
    
                </td>
            </tr>
            <tr>
                <td>
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" CssClass="TextoCadastro_BGBranco" 
            DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" 
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
                <asp:BoundField DataField="data_solicitacao" DataFormatString="{0:dd/MM/yyyy HH:mm}" 
                    HeaderText="Solicitação" SortExpression="data_solicitacao" >
                <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="data_entrega" DataFormatString="{0:dd/MM/yyyy HH:mm}" 
                    HeaderText="Entrega" SortExpression="data_entrega" >
                <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="prioridade_descricao" HeaderText="Prioridade" 
                    SortExpression="prioridade_descricao" >
                <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" 
                            CommandArgument='<%# eval("cod_solicitacao") %>' CommandName="ALTERAR" 
                            ImageUrl="~/Imagens/BtnEditar.png" ToolTip="Editar Solicitação" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton3" runat="server" 
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
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
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
        </table>
    
    </div>
    </form>
</body>
</html>
