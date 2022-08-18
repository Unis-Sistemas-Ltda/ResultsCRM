<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGItemAvaliado.aspx.vb" Inherits="ResultsCRM.WGItemAvaliado" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="LblErro" runat="server" CssClass="Erro"></asp:Label>
        <br />
        <asp:Button ID="BtnIncluir" runat="server" Text="Incluir" />
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" DataSourceID="SqlDataSource1" 
            EmptyDataText="Nenhum registro foi incluído até o momento." 
            ForeColor="#333333" GridLines="None" Width="100%">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="seq_item_avaliado" HeaderText="Seq. Item" 
                    SortExpression="seq_item_avaliado">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="descricao_item_avaliado" HeaderText="Descrição" 
                    SortExpression="descricao_item_avaliado">
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="descricao_grupo_item" 
                    HeaderText="Grupo Item" SortExpression="descricao_grupo_item">
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="descricao_grupo_resultado" 
                    HeaderText="Grupo Resultado" SortExpression="descricao_grupo_resultado">
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton2" runat="server" CommandName="ALTERAR"
                            CommandArgument='<%# Eval("seq_item_avaliado") %>' ImageUrl="~/Imagens/BtnEditar.png" 
                            style="margin-top: 0px" ToolTip="Editar dados do registro" />
                        &nbsp;<asp:ImageButton ID="ImageButton1" runat="server" 
                            CommandArgument='<%# Eval("seq_item_avaliado") %>' CommandName="EXCLUIR" 
                            ImageUrl="~/Imagens/BtnExcluir.png" 
                            onclientclick="return confirm('Deseja excluir o registro?')" 
                            ToolTip="Excluir o registro" />
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
            
            
            SelectCommand=" select r.seq_item_avaliado, r.descricao descricao_item_avaliado, g.descricao descricao_grupo_item, gr.descricao descricao_grupo_resultado
   from item_avaliado r inner join grupo_item_avaliado g on g.empresa = r.empresa and g.cod_grupo_item = r.cod_grupo_item
                        inner join grupo_resultado_item_avaliado gr on gr.empresa = r.empresa and gr.cod_grupo_resultado = r.cod_grupo_resultado
  where r.empresa = :empresa
    and r.cod_tipo_avaliacao = :cod_tipo_avaliacao
  order by seq_item_avaliado">
            <SelectParameters>
                <asp:SessionParameter ConvertEmptyStringToNull="False" DbType="String" 
                    Name=":empresa" SessionField="GlEmpresa" />
                <asp:SessionParameter ConvertEmptyStringToNull="False" DbType="String" 
                    Name=":cod_tipo_avaliacao" SessionField="SCodTipoAvaliacao" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>