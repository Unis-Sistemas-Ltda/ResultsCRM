<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGPosVendaSINAMM.aspx.vb" Inherits="ResultsCRM.WGPosVendaSINAMM" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="TextoCadastro_BGBranco" style="font-weight: bold">
    
        HISTÓRICO DE PARTICIPAÇÃO NO SINAMM<br />
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" CssClass="TextoCadastro_BGBranco" DataSourceID="SqlDataSource1" 
            EmptyDataText="Associado não participante de nenhuma edição do SINAMM." 
            EnableModelValidation="True" Font-Bold="False" ForeColor="#333333" 
            GridLines="None" Width="100%">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="descricao" HeaderText="Ciclo" 
                    SortExpression="descricao" />
                <asp:BoundField DataField="data_aceite_regulamento" 
                    DataFormatString="{0:dd/MM/yyyy HH:mm}" HeaderText="Aceite" 
                    SortExpression="data_aceite_regulamento" />
                <asp:BoundField DataField="data_validacao_regulamento" 
                    DataFormatString="{0:dd/MM/yyyy HH:mm}" HeaderText="Validação" 
                    SortExpression="data_validacao_regulamento" />
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
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select p.cod_planejamento, p.descricao, a.data_aceite_regulamento, a.data_validacao_regulamento
  from aceite_sinamm a inner join planejamento_analise p on a.planejamento = p.cod_planejamento
 where a.cod_farmacia = :cod_farmacia
   and a.regulamento_aceito = 'S'
   and a.regulamento_validado = 'S'">
            <SelectParameters>
                <asp:SessionParameter Name=":cod_farmacia" SessionField="SCodEmitente" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
