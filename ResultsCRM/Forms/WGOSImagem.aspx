<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGOSImagem.aspx.vb" Inherits="ResultsCRM.WGOSImagem" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table class="TextoCadastro_BGBranco" style="width:100%;">
            <tr>
                <td style="font-weight: bold">
                    <asp:Label ID="LblErro" runat="server" CssClass="Erro" Font-Bold="False"></asp:Label>
                    <br />
                    DIGITALIZAÇÃO DA OS</td>
                <td style="text-align: right; vertical-align: bottom;">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">
    
        <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" CssClass="TextoCadastro_BGBranco" 
            DataSourceID="SqlDataSource4" GridLines="None" 
            Width="100%" ShowFooter="True" 
                        
                        
                        EmptyDataText="Nenhuma imagem cadastrada nesta modalidade." 
                        AllowSorting="True" Font-Size="7pt" ForeColor="#333333">
            <RowStyle 
                VerticalAlign="Top" BackColor="#F7F6F3" ForeColor="#333333" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="descricao" HeaderText="Descrição" 
                    SortExpression="descricao">
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Arquivo" SortExpression="arquivo">
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" runat="server" 
                            NavigateUrl='<%# "http://ativa02:8000/upload/" & Eval("arquivo") %>' Font-Underline="True" Target="_blank">
                            <asp:Label ID="Label5" runat="server" Text='<%# Eval("arquivo") %>'></asp:Label>
                            </asp:HyperLink>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Excluir">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" 
                            CommandArgument='<%# Eval("seq_imagem") %>' CommandName="EXCLUIR" 
                            ImageUrl="~/Imagens/BtnExcluir.png" ToolTip="Excluir o registro" 
                            onclientclick="return confirm('Deseja realmente excluir esta imagem?');" />
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle 
                HorizontalAlign="Right" BackColor="#5D7B9D" Font-Bold="True" 
                ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle Font-Bold="True" 
                HorizontalAlign="Left" BackColor="#5D7B9D" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource4" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
            SelectCommand="select seq_imagem, descricao, arquivo
  from pedido_venda_imagem
 where empresa = :empresa
   and estabelecimento = :estabelecimento
   and cod_pedido_venda = :cod_pedido
   and tipo = 2">
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
    
    <div>
        <table class="TextoCadastro_BGBranco" style="width:100%;">
            <tr>
                <td style="font-weight: bold">
                    <br />
                    FOTOS</td>
                <td style="text-align: right; vertical-align: bottom;">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">
    
        <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" CssClass="TextoCadastro_BGBranco" 
            DataSourceID="SqlDataSource5" GridLines="None" 
            Width="100%" ShowFooter="True" 
                        
                        
                        EmptyDataText="Nenhuma imagem cadastrada nesta modalidade." 
                        AllowSorting="True" Font-Size="7pt" ForeColor="#333333">
            <RowStyle 
                VerticalAlign="Top" BackColor="#F7F6F3" ForeColor="#333333" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="descricao" HeaderText="Descrição" 
                    SortExpression="descricao">
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Arquivo" SortExpression="arquivo">
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" runat="server" 
                            NavigateUrl='<%# "http://ativa02:8000/upload/" & Eval("arquivo") %>' Font-Underline="True" Target="_blank">
                            <asp:Label ID="Label5" runat="server" Text='<%# Eval("arquivo") %>'></asp:Label>
                        </asp:HyperLink>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:BoundField DataField="previsao_insercao" 
                    DataFormatString="{0:dd/MM/yy HH:mm}" HeaderText="Previsão Inserção" 
                    SortExpression="previsao_insercao">
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="data_inclusao" DataFormatString="{0:dd/MM/yy HH:mm}" 
                    HeaderText="Inserção" SortExpression="data_inclusao">
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Ocorrência" SortExpression="diferenca">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("diferenca") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label101" runat="server" Text='<%# Bind("diferenca") %>'></asp:Label>
                        <asp:Label ID="Label102" runat="server" Text='<%# Eval("nome_diferenca") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Excluir">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" 
                            CommandArgument='<%# Eval("seq_imagem") %>' CommandName="EXCLUIR" 
                            ImageUrl="~/Imagens/BtnExcluir.png" ToolTip="Excluir o registro" 
                            onclientclick="return confirm('Deseja realmente excluir esta imagem?');" />
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle 
                HorizontalAlign="Right" BackColor="#5D7B9D" Font-Bold="True" 
                ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle Font-Bold="True" 
                HorizontalAlign="Left" BackColor="#5D7B9D" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource5" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
            SelectCommand="select pvi.seq_imagem, pvi.descricao, pvi.arquivo, pvi.data_inclusao, pvi.data_alteracao,
       dateadd(hour, isnull(pm.prazo_insercao_foto_os,0), isnull(pv.data_termino_execucao,isnull(pv.data_encerramento, isnull(c.data_encerramento, c.data_encerramento_prevista)))) previsao_insercao,
       datediff(hour, previsao_insercao, pvi.data_inclusao) diferenca,
       if diferenca is null then '' else if diferenca &lt;= 0 then 'hora(s) ' || if abs(diferenca) &gt; 24 then '(' || abs(datediff(day, previsao_insercao, pvi.data_inclusao)) || ' dia(s)) ' else '' endif || ' antes do prazo' else 'hora(s) ' || if abs(diferenca) &gt; 24 then '(' || abs(datediff(day, previsao_insercao, pvi.data_inclusao)) || ' dia(s))' else '' endif || ' após o prazo' endif endif nome_diferenca
  from pedido_venda_imagem pvi inner join pedido_venda pv on pvi.empresa          = pv.empresa
                                                         and pvi.estabelecimento  = pv.estabelecimento
                                                         and pvi.cod_pedido_venda = pv.cod_pedido_venda
                               inner join chamado c  on c.empresa     = pv.empresa
                                                    and c.cod_chamado = pv.cod_chamado
                               inner join parametros_manutencao pm on pm.empresa         = pv.empresa
                                                                  and pm.estabelecimento = pv.estabelecimento
 where pvi.empresa          = :empresa
   and pvi.estabelecimento  = :estabelecimento
   and pvi.cod_pedido_venda = :cod_pedido
   and tipo                 = 1">
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
