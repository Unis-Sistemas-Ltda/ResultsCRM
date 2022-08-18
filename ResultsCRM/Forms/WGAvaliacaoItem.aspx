<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGAvaliacaoItem.aspx.vb" Inherits="ResultsCRM.WGAvaliacaoItem" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="TextoCadastro">
        <asp:Label ID="LblErro" runat="server" CssClass="Erro"></asp:Label>
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" DataSourceID="SqlDataSource1" 
            EmptyDataText="Nenhum registro foi incluído até o momento." 
            ForeColor="#333333" GridLines="None" Width="100%" CssClass="TextoCadastro">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="descricao_grupo" HeaderText="Grupo Item" 
                    SortExpression="descricao_grupo">
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="seq_item_avaliado" HeaderText="Seq. Item" 
                    SortExpression="seq_item_avaliado">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="descricao_item_avaliado" 
                    HeaderText="Item Avaliado" SortExpression="descricao_item_avaliado">
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="descricao_resultado" HeaderText="Resultado" 
                    SortExpression="descricao_resultado">
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton2" runat="server" CommandName="ALTERAR"
                            CommandArgument='<%# Eval("seq_item_avaliado") %>' ImageUrl="~/Imagens/BtnEditar.png" 
                            style="margin-top: 0px" ToolTip="Editar dados do registro" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Right" Width="45px" />
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
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
            
            
            SelectCommand="select i.cod_grupo_item, gi.descricao descricao_grupo, ai.seq_item_avaliado, i.descricao descricao_item_avaliado, ai.cod_grupo_resultado, ai.seq_resultado, ri.descricao descricao_resultado
  from avaliacao_cliente_item ai inner join item_avaliado i on i.empresa = ai.empresa and i.cod_tipo_avaliacao = ai.cod_tipo_avaliacao and i.seq_item_avaliado = ai.seq_item_avaliado
                                 inner join grupo_item_avaliado gi on gi.empresa = i.empresa and gi.cod_grupo_item = i.cod_grupo_item
                                 left outer join resultado_item_avaliado ri on ri.empresa = ai.empresa and ri.cod_grupo_resultado = ai.cod_grupo_resultado and ri.seq_resultado = ai.seq_resultado
 where ai.empresa       = :empresa
   and ai.cod_avaliacao = :cod_avaliacao
order by i.cod_grupo_item, ai.seq_item_avaliado">
            <SelectParameters>
                <asp:SessionParameter ConvertEmptyStringToNull="False" DbType="String" 
                    Name=":empresa" SessionField="GlEmpresa" />
                <asp:SessionParameter ConvertEmptyStringToNull="False" DbType="String" 
                    Name=":cod_grupo_resultado" SessionField="SCodAvaliacao" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>