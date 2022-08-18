<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGRoteiroVisitaVisitacoes.aspx.vb"
    Inherits="ResultsCRM.WGRoteiroVisitaVisitacoes" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="Button1" runat="server" Text="Incluir" />
        <br />
        <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="False" CellPadding="4"
            DataSourceID="SqlDataSource5" ForeColor="#333333" GridLines="None" Width="100%"
            AllowSorting="True" PageSize="14" EmptyDataText="&lt;br&gt;&lt;br&gt;Nenhum registro a exibir.">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" />
            <Columns>
                <asp:BoundField DataField="seq_visita" HeaderText="Seq. Visita" ReadOnly="True" SortExpression="seq_visita">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="data_visita" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Data"
                    SortExpression="data_visita">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="hora_visita" HeaderText="Hora" SortExpression="hora_visita">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Cliente" SortExpression="nome_cliente">
                    <ItemTemplate>
                        <asp:Label ID="Label23" runat="server" Text='<%# Eval("nome_cliente") %>'></asp:Label>
                        (<asp:Label ID="Label24" runat="server" Text='<%# Eval("cod_emitente") %>'></asp:Label>)
                        &nbsp;CNPJ/CPF:
                        <asp:Label ID="Label22" runat="server" Text='<%# Eval("cnpj") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:BoundField DataField="situacao_nome" HeaderText="Situação" SortExpression="situacao_nome">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="titulo" HeaderText="Assunto" SortExpression="titulo">
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:TemplateField SortExpression="nome_cliente">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton5" runat="server" CommandArgument='<%# Eval("seq_visita") %>'
                            CommandName="ALTERAR" ImageUrl="~/Imagens/BtnEditar.png" ToolTip="Clique para alterar ou consultar o registro" />
                        &nbsp;&nbsp;
                        <asp:ImageButton ID="ImageButton6" runat="server" 
                            CommandArgument='<%# Eval("seq_visita") %>' CommandName="EXCLUIR" 
                            ImageUrl="~/Imagens/BtnExcluir.png" 
                            onclientclick="return confirm('Deseja realmente excluir o registro?');" 
                            ToolTip="Excluir o registro" />
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerSettings FirstPageText="1&nbsp;&nbsp;" LastPageText="Últ." Mode="NumericFirstLast"
                PageButtonCount="15" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
        </td> </tr>
        <tr>
            <td>
                <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                    
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="  select v.empresa,
          v.estabelecimento,
          v.seq_visita,
          v.cod_representante,
          r.nome nome_representante,
          if isnull(v.id_cliente_generico,'N') = 'S' then 0 else v.cod_emitente endif cod_emitente,
          if trim(isnull(v.cnpj,'')) = '' then '(não informado)' else v.cnpj endif cnpj,
          if isnull(v.id_cliente_generico,'N') = 'S' then v.cliente_generico else c.nome endif nome_cliente,
          v.data_visita,
          v.hora_visita,
          v.situacao,
          case v.situacao when 1 then 'Agendada' when 2 then 'Concluída' when 3 then 'Cancelada' end situacao_nome,
          v.titulo,
          v.narrativa
     from  visitacao v left outer join emitente c on c.cod_emitente = v.cod_emitente
                      inner join emitente r on r.cod_emitente = v.cod_representante
    where v.empresa         = :empresa
      and v.estabelecimento = :estabelecimento
      and v.cod_roteiro_visita = :roteiro
    order by data_visita, nome_cliente, seq_visita;">
                    <SelectParameters>
                        <asp:SessionParameter Name=":empresa" SessionField="GlEmpresa" ConvertEmptyStringToNull="False"
                            DbType="String" />
                        <asp:SessionParameter ConvertEmptyStringToNull="False" DbType="String" Name=":estabelecimento"
                            SessionField="GlEstabelecimento" />
                        <asp:SessionParameter ConvertEmptyStringToNull="False" DbType="String" Name=":roteiro"
                            SessionField="SCodRoteiroVisita" />
                    </SelectParameters>
                </asp:SqlDataSource>
    </div>
    </form>
</body>
</html>
