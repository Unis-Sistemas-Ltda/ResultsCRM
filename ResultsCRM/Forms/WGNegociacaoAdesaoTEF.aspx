<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGNegociacaoAdesaoTEF.aspx.vb" Inherits="ResultsCRM.WGNegociacaoAdesaoTEF" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

.TextoCadastro
{
    font-size: 8pt;
    text-align: left;
    font-family: verdana;
    color: #2A2A2A;
    border-collapse: collapse;
    margin-bottom: 0px;
}

    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" CssClass="TextoCadastro" DataSourceID="SqlDataSource1" 
            ForeColor="#333333" GridLines="None" Width="100%" 
            AllowSorting="True" Font-Size="7pt">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" />
            <Columns>
                <asp:BoundField DataField="nome_rede" HeaderText="Grupo TEF" 
                    SortExpression="nome_rede">
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Código" SortExpression="cod_emitente">
                    <ItemTemplate>
                        <asp:Label ID="LblCodEmitente" runat="server" 
                            Text='<%# Bind("cod_emitente") %>'></asp:Label>
                        <asp:Label ID="LblCodAdesao" runat="server" 
                            Text='<%# Bind("cod_adesao_tef") %>' Visible="False"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("cod_emitente") %>'></asp:Label>
                    </EditItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:BoundField DataField="nome" HeaderText="Razão Social" 
                    SortExpression="nome" >
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="cnpj" HeaderText="CNPJ" SortExpression="cnpj" >
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="data_inclusao" DataFormatString="{0:dd/MM/yy HH:mm}" 
                    HeaderText="Inclusão" SortExpression="data_inclusao">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="aceito" HeaderText="Aceito" 
                    SortExpression="aceito" >
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="validado" HeaderText="Validado" 
                    SortExpression="validado" >
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="nome_usuario" HeaderText="Agente de Vendas" 
                    SortExpression="nome_usuario">
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="cod_negociacao_cliente" HeaderText="Nº Negociação" 
                    SortExpression="cod_negociacao_cliente">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="cod_pedido_venda" HeaderText="Nº Pedido" 
                    SortExpression="cod_pedido_venda">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="data_emissao" DataFormatString="{0:dd/MM/yyyy}" 
                    HeaderText="Data Fechamento" SortExpression="data_emissao">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="cadastro_adquirente" HeaderText="Cadastro Stone" 
                    SortExpression="cadastro_adquirente">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="cadastro_parceiro" HeaderText="Cadastro Cappta" 
                    SortExpression="cadastro_parceiro">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="equipamento_enviado" 
                    HeaderText="Equipamento Recebido" SortExpression="equipamento_enviado">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Faturado" SortExpression="faturado">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("faturado") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label14" runat="server" Text='<%# Bind("faturado") %>'></asp:Label>
                        <br />
                        <asp:Label ID="Label13" runat="server" Text='<%# Eval("nf") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:BoundField DataField="instalado" HeaderText="Instalado" 
                    SortExpression="instalado">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Editar">
                    <ItemTemplate>
                        <asp:ImageButton ID="BtnAlterarRegistro" runat="server" 
                            CommandArgument='<%# Eval("chave") %>' CommandName="ALTERAR" 
                            ImageUrl="~/Imagens/BtnEditar.png" ToolTip="Alterar dados do registro." />
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="LnkAdesao" runat="server">Adesão</asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                HorizontalAlign="Left" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select a.cod_emitente, e.cnpj,  a.data_inclusao, e.nome, 
       a.confirmou_contato, a.confirmou_lojas, a.aceito, a.validado, a.data_aceite, a.data_validacao,
       (select max(cod_adesao) from adesao_tef_loja where cod_emitente = e.cod_emitente) cod_adesao_tef,
       ad.nome_rede,
       al.cod_negociacao_cliente,
       pv.cod_pedido_venda,
       pv.data_emissao,
       av.nome_usuario,
       al.cadastro_adquirente,
       al.cadastro_parceiro,
       al.equipamento_enviado,
       trim(isnull((select first nff.serie || '/' || nff.cod_nfs from nfs_faturamento nff inner join nfs on nff.empresa = nfs.empresa and nff.estabelecimento = nfs.estabelecimento and nff.serie = nfs.serie and nff.cod_nfs = nfs.cod_nfs where nff.empresa = pv.empresa and nff.estabelecimento = pv.estabelecimento and nff.cod_pedido_venda = pv.cod_pedido_venda and nfs.situacao = 1),'')) nf,
       if nf = '' then 'N' else 'S' endif faturado,
       if exists(select 1 from chamado ch inner join status_chamado sc on sc.cod_status = ch.cod_status where sc.tipo = '3' and ch.empresa = al.empresa and ch.cod_chamado = al.cod_chamado_instalacao) then 'S' else 'N' endif instalado,
       e.cod_emitente || ';' || e.cnpj chave,
       if pv.cod_pedido_venda is not null then 'S' else 'N' endif gerou_pedido
  from adesao_tef_emitente a left outer join v_emitente_endereco e on a.cod_emitente = e.cod_emitente
                             left outer join adesao_tef_loja al on al.empresa = a.empresa and al.cod_emitente = a.cod_emitente and al.cnpj = e.cnpj
                             left outer join adesao_tef ad on a.empresa = ad.empresa and ad.cod_adesao = cod_adesao_tef
                             left outer join negociacao_cliente nc on nc.empresa = al.empresa and nc.cod_negociacao_cliente = al.cod_negociacao_cliente
                             left outer join pedido_venda pv on pv.empresa = nc.empresa and pv.estabelecimento = nc.estabelecimento and pv.cod_negociacao_cliente = nc.cod_negociacao_cliente
                             left outer join sysusuario av on av.cod_usuario = nc.cod_agente_venda
 where al.cod_negociacao_cliente = :codNegociacao
   and exists(select 1 from acesso_campanha_tef where empresa = 1 and cod_emitente = e.cod_emitente and tipo_conteudo = 2)
order by a.data_aceite desc, e.nome">
            <SelectParameters>
                <asp:SessionParameter Name=":codNegociacao" SessionField="SCodNegociacao" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
