<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGNegociacaoItemFormula.aspx.vb" Inherits="ResultsCRM.WGNegociacaoItemFormula" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
         <div class="SubTituloMovimento">Fórmula</div>
    <div>
        <asp:ImageButton ID="BtnNovoRegistro" runat="server" 
            AlternateText="Novo Registro" 
                ImageUrl="~/Imagens/BtnNovoRegistro.png" />&nbsp;
                            
    </div>
     <div>
        <asp:Label ID="LblErro" runat="server" CssClass="Erro" Font-Bold="False"></asp:Label>
       
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" CssClass="TextoCadastro" DataSourceID="SqlDataSource1" 
            ForeColor="#333333" GridLines="None" Width="100%">
            <PagerSettings FirstPageText="1" LastPageText="Última" Mode="NumericFirstLast" 
                PageButtonCount="8" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Right" 
                VerticalAlign="Middle" />
            <Columns>
                <asp:BoundField DataField="seq_formula" HeaderText="Sequência" 
                    SortExpression="seq_formula" >
                    <HeaderStyle HorizontalAlign="Center" />
                     <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="descricao_componente" HeaderText="Componente/Matéria Prima" 
                    SortExpression="descricao_componente">
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="percentual" DataFormatString="{0:F2}" 
                    HeaderText="Percentual(%)" SortExpression="percentual" >
                   <HeaderStyle HorizontalAlign="Center" />
                   <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>  
                <asp:BoundField DataField="qsp"  
                    HeaderText="QSP." SortExpression="qsp" >
                   <HeaderStyle HorizontalAlign="Center" />
                   <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>                 
                
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" 
                            CommandArgument='<%# Eval("seq_formula") %>' CommandName="ALTERAR" 
                            ImageUrl="~/Imagens/BtnEditar.png" ToolTip="Detalhes do registro" />
                    </ItemTemplate>
                </asp:TemplateField>                
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton3" runat="server" 
                            CommandArgument='<%# Eval("seq_formula") %>' CommandName="EXCLUIR" 
                            ImageUrl="~/Imagens/BtnExcluir.png" 
                            onclientclick="return confirm('Deseja realmente excluir o item selecionado?');" 
                            ToolTip="Excluir o registro" Width="22px" />
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
    
        </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select seq_formula, descricao_componente, percentual, qsp
  from negociacao_cliente_item_formula
 where cod_negociacao_cliente = :codNegociacao
   and empresa = :empresa
   and estabelecimento = :estabelecimento
  and seq_item = :seqitem
order by seq_formula">
            <SelectParameters>
                <asp:SessionParameter Name=":codNegociacao" SessionField="SCodNegociacao" />
                <asp:SessionParameter Name=":empresa" SessionField="GlEmpresa" />
                <asp:SessionParameter Name=":estabelecimento" 
                    SessionField="SEstabelecimentoNegociacao" />
                <asp:SessionParameter DefaultValue="" Name=":seqitem" SessionField="SSeqItemNegociacao" />
            </SelectParameters>
        </asp:SqlDataSource>
    </form>
</body>
</html>
