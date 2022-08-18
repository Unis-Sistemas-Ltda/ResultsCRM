<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGOSMaterialBaixa.aspx.vb" Inherits="ResultsCRM.WGOSMaterialBaixa" %>

<%@ Register src="../UserControls/WUCBaixaMaterial.ascx" tagname="WUCBaixaMaterial" tagprefix="uc4" %>

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
    
                    <uc4:WUCBaixaMaterial ID="WUCBaixaMaterial1" runat="server" />
    
                </td>
            </tr>
            <tr>
                <td>
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" CssClass="TextoCadastro_BGBranco" 
            DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" 
            Width="100%" ShowFooter="True" 
                        
                        
                        EmptyDataText="Você ainda não baixou nenhum material nesta Ordem de Serviço." 
                        AllowSorting="True">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" 
                VerticalAlign="Top" />
            <Columns>
                <asp:BoundField DataField="nome" HeaderText="Agente Técnico" 
                    SortExpression="nome">
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="cod_item" HeaderText="Cód. Item" 
                    SortExpression="cod_item" ReadOnly="True" >
                <HeaderStyle HorizontalAlign="Right" />
                <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="item_descricao" 
                    HeaderText="Descrição Item" SortExpression="item_descricao">
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="lote" 
                    HeaderText="Lote" SortExpression="lote" >
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="quantidade" DataFormatString="{0:F1}" 
                    HeaderText="Qtde." SortExpression="quantidade" >
                <HeaderStyle HorizontalAlign="Right" />
                <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="nome_usuario" HeaderText="Usuário" 
                    SortExpression="nome_usuario">
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="datahora" DataFormatString="{0:dd/MM/yy HH:mm}" 
                    HeaderText="Data/Hora" SortExpression="datahora">
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Gerou Pend." SortExpression="gerou_pendencia">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("gerou_pendencia") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("gerou_pendencia") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Item Retorno / Lote" 
                    SortExpression="item_lote_retorno">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" 
                            Text='<%# Bind("item_lote_retorno") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("item_lote_retorno") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton3" runat="server" 
                            CommandArgument='<%# Eval("chave") %>' CommandName="EXCLUIR" 
                            ImageUrl="~/Imagens/BtnExcluir.png" 
                            onclientclick="return confirm('Deseja realmente estornar esta baixa?');" 
                            ToolTip="Estornar Baixa de Material" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
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
            SelectCommand="select t.cod_transferencia, t.seq_transferencia, t.cod_item, te.nome, i.descricao item_descricao, t.lote, t.quantidade, su.nome_usuario,
       t.cod_transferencia || ';' || t.seq_transferencia || ';' || t.seq_baixa chave, t.datahora,
       if exists ( select 1
                     from transferencia_tecnico_instalacao_retorno
                    where empresa           = t.empresa
                      and estabelecimento   = t.estabelecimento
                      and cod_transferencia = t.cod_transferencia
                      and seq_transferencia = t.seq_transferencia
                      and seq_baixa_origem  = t.seq_baixa ) then 'Sim, de retorno' else 'Não' endif gerou_retorno_instalacao,
       if exists ( select 1
                     from transferencia_tecnico_pendencia_solicitacao
                    where empresa           = t.empresa
                      and estabelecimento   = t.estabelecimento
                      and cod_transferencia = t.cod_transferencia
                      and seq_transferencia = t.seq_transferencia
                      and seq_baixa         = t.seq_baixa ) then 'Sim, de remessa' else 'Não' endif gerou_pendencia_remessa,
       isnull(i.controla_por_lote,'N') cont_lote,
       if cont_lote = 'S' then gerou_retorno_instalacao else gerou_pendencia_remessa endif gerou_pendencia,
       tr.cod_item_retorno,
       tr.lote_retorno,
       iret.descricao item_retorno_descricao,
       if item_retorno_descricao is not null then item_retorno_descricao || ' (' || cod_item_retorno || ')  &lt;br&gt;' || 'Lote: ' || lote_retorno else '' endif item_lote_retorno
  from transferencia_tecnico_baixa t inner join item i on i.cod_item = t.cod_item
                                     inner join sysusuario su on su.cod_usuario = t.cod_usuario
                                     inner join transferencia_tecnico tt on tt.empresa = t.empresa and tt.estabelecimento = t.estabelecimento and tt.cod_transferencia = t.cod_transferencia
                                     inner join agente_tecnico te on te.cod_agente_tecnico = tt.cod_agente_tecnico and isnull(te.empresa,1) = tt.empresa and isnull(te.estabelecimento,1) = tt.estabelecimento
                                     left outer join transferencia_tecnico_instalacao_retorno tr on t.empresa =  tr.empresa and t.estabelecimento = tr.estabelecimento and t.cod_transferencia = tr.cod_transferencia and t.seq_transferencia = tr.seq_transferencia and t.seq_baixa = tr.seq_baixa_origem and tr.seq_retorno = 1
                                     left outer join item iret on iret.cod_item = tr.cod_item_retorno
 where t.empresa = :empresa
   and t.estabelecimento = :estabelecimento
   and t.cod_pedido_venda = :cod_pedido
 order by t.datahora desc">
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
