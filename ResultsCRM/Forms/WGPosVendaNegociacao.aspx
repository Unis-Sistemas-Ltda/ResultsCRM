<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGPosVendaNegociacao.aspx.vb" Inherits="ResultsCRM.WGPosVendaNegociacao" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="TextoCadastro_BGBranco" style="font-weight: bold">
    
        <asp:Label ID="Label1" runat="server" Text="NEGOCIAÇÔES" Width="80%"></asp:Label>
        <asp:ImageButton ID="ImageButton2" runat="server" 
            ImageUrl="~/Imagens/BtnNovoRegistro.png" Visible="False" />
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" CssClass="TextoCadastro_BGBranco" DataSourceID="SqlDataSource1" 
            EmptyDataText="Nenhuma negociação encontrada." Font-Bold="False" ForeColor="#333333" 
            GridLines="None" Width="100%">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="cod_negociacao_cliente" HeaderText="Nº Neg" 
                    SortExpression="cod_negociacao_cliente" >
                </asp:BoundField>
                <asp:BoundField 
                    HeaderText="Contato" DataField="nome" SortExpression="nome">
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="data_recontato" HeaderText="Data Recontato" 
                    SortExpression="data_recontato" >
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField 
                    HeaderText="Etapa" DataField="descricao" SortExpression="descricao">
                </asp:BoundField>
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                HorizontalAlign="Center" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select n.cod_negociacao_cliente,c.nome, n.data_recontato ,e.descricao
from negociacao_cliente n inner join contatos c on n.cod_emitente = c.cod_emitente
 inner join etapa_negociacao e on n.cod_etapa = e.cod_etapa
where n.cod_emitente = :cod_farmacia
order by n.cod_negociacao_cliente
">
            <SelectParameters>
                <asp:SessionParameter Name=":cod_farmacia" SessionField="SCodEmitente" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
