<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGNegociacaoMotivoFechamento.aspx.vb" Inherits="ResultsCRM.WGNegociacaoMotivoFechamento" %>

<%@ Register src="../UserControls/WUCNegociacaoTotais.ascx" tagname="WUCNegociacaoTotais" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
    </head>
<body>
    <form id="form1" runat="server">
    <div class="SubTituloMovimento">Motivos de Fechamento / Perda<br />
        <br />
    </div>
    <div >
        <asp:ImageButton ID="BtnNovoRegistro" runat="server" 
            AlternateText="Novo Registro" ImageUrl="~/Imagens/BtnNovoRegistro.png" 
            style="text-align: right" />
    
    
        <br />
         <asp:Label ID="LblErro" runat="server" CssClass="Erro" Font-Bold="False"></asp:Label>
            <br />
      
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" CssClass="TextoCadastro_BGBranco" DataSourceID="SqlDataSource1" 
            ForeColor="#333333" GridLines="None" Width="100%" AllowPaging="True" 
            PageSize="8">
            <PagerSettings FirstPageText="1" LastPageText="Última" Mode="NumericFirstLast" 
                PageButtonCount="8" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Right" 
                VerticalAlign="Middle" />
            <Columns>
                <asp:BoundField DataField="cod_motivo" HeaderText="Cód. Motivo" 
                    SortExpression="cod_motivo" ReadOnly="True" >
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="descricao" HeaderText="Descrição" 
                    SortExpression="descricao" >
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton2" runat="server" 
                            CommandArgument='<%# Eval("cod_motivo") %>' CommandName="EXCLUIR" 
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
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select nm.cod_motivo, mf.descricao
  from negociacao_cliente_motivo_fechamento nm inner join motivo_fechamento_negociacao mf on nm.cod_motivo = mf.cod_motivo
 where cod_negociacao_cliente = :codNegociacao
   and empresa = :empresa
   and estabelecimento = :estabelecimento
order by nm.cod_motivo">
            <SelectParameters>
                <asp:SessionParameter Name=":codNegociacao" SessionField="SCodNegociacao" />
                <asp:SessionParameter Name=":empresa" SessionField="GlEmpresa" />
                <asp:SessionParameter Name=":estabelecimento" 
                    SessionField="GlEstabelecimento" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
