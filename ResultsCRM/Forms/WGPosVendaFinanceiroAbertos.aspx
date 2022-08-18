<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGPosVendaFinanceiroAbertos.aspx.vb" Inherits="ResultsCRM.WGPosVendaFinanceiroAbertos" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="TextoCadastro_BGBranco" style="font-weight: bold">
    
        HISTÓRICO FINANCEIRO - TÍTULOS EM ABERTO<br />
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" CssClass="TextoCadastro_BGBranco" DataSourceID="SqlDataSource1" 
            EmptyDataText="Nenhum título em aberto encontrado." 
            EnableModelValidation="True" Font-Bold="False" ForeColor="#333333" 
            GridLines="None" Width="100%">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="serie" HeaderText="Série" 
                    SortExpression="serie" >
                </asp:BoundField>
                <asp:BoundField DataField="cod_tit_cr" 
                    HeaderText="Título" SortExpression="cod_tit_cr">
                </asp:BoundField>
                <asp:BoundField DataField="parcela" 
                    HeaderText="Parcela" SortExpression="parcela">
                </asp:BoundField>
                <asp:BoundField DataField="descricao" HeaderText="Espécie" 
                    SortExpression="descricao" >
                </asp:BoundField>
                <asp:BoundField DataField="data_emissao" DataFormatString="{0:dd/MM/yy}" 
                    HeaderText="Emissão" SortExpression="data_emissao">
                </asp:BoundField>
                <asp:BoundField DataField="data_vencimento" DataFormatString="{0:dd/MM/yy}" 
                    HeaderText="Vencimento" SortExpression="data_vencimento">
                </asp:BoundField>
                <asp:BoundField DataField="valor_original" DataFormatString="{0:F2}" 
                    HeaderText="Vlr. Original" SortExpression="valor_original">
                <HeaderStyle HorizontalAlign="Right" />
                <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="valor_recebido" DataFormatString="{0:F2}" 
                    HeaderText="Vlr. Recebido" SortExpression="valor_recebido">
                <HeaderStyle HorizontalAlign="Right" />
                <ItemStyle HorizontalAlign="Right" />
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
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="  SELECT titulo_cr.cod_especie,   
         titulo_cr.serie,   
         titulo_cr.cod_tit_cr,   
         titulo_cr.parcela,   
         titulo_cr.data_emissao,   
         titulo_cr.data_vencimento,   
         (titulo_cr.valor_original * (if es.tipo = 2 then -1 else 1 endif)) as valor_original,   
         titulo_cr.valor_recebido,   
 			es.descricao  
   FROM 	titulo_cr,   
			especie_documento_cr es
   WHERE ((es.tipo	= 3 and titulo_cr.situacao &lt;&gt; 4) or es.tipo &lt;&gt; 3 )
	  AND es.cod_especie                   = titulo_cr.cod_especie	
	  AND es.empresa     						= titulo_cr.empresa
	  AND titulo_cr.valor_saldo				&gt; 0
	  AND titulo_cr.sit_saldo 					= 1     
     AND titulo_cr.cod_emitente 				= :cod_farmacia
     order by titulo_cr.data_emissao desc">
            <SelectParameters>
                <asp:SessionParameter Name=":cod_farmacia" SessionField="SCodEmitente" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
