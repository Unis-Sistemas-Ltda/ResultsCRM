<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGPosVendaConvenio.aspx.vb" Inherits="ResultsCRM.WGPosVendaConvenio" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="TextoCadastro_BGBranco" style="font-weight: bold">
    
        <asp:Label ID="Label1" runat="server" Text="HISTÓRICO DE ADESÃO A CONVÊNIO" 
            Width="80%"></asp:Label>
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" CssClass="TextoCadastro_BGBranco" DataSourceID="SqlDataSource1" 
            EmptyDataText="Nenhum convênio cadastrado até o momento." Font-Bold="False" ForeColor="#333333" 
            GridLines="None" Width="100%">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="seq_adesao" HeaderText="Seq. Adesão" 
                    SortExpression="seq_adesao" >
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="nome_convenio" 
                    HeaderText="Convênio" SortExpression="nome_convenio">
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="data_aceite" 
                    HeaderText="Aceite" SortExpression="data_aceite" 
                    DataFormatString="{0:dd/MM/yyyy}">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="cnpjs" HeaderText="CNPJ(s)" 
                    SortExpression="cnpjs" >
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:BoundField>
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                HorizontalAlign="Left" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select a.seq_adesao,
       isnull(a.convenio,'S') convenio,
       (select nome_convenio from convenio_anfarmag where cod_convenio = convenio) nome_convenio,
       a.data_aceite,
       (select list(cnpj, '; ') from adesao_parceria_santander_cnpj c where a.empresa = c.empresa and a.seq_adesao = c.seq_adesao) cnpjs
  from adesao_parceria_santander a
 where a.cod_emitente = :cod_emitente
   and a.empresa      = :empresa
   and a.aceito       = 'S'">
            <SelectParameters>
                <asp:SessionParameter Name=":cod_farmacia" SessionField="SCodEmitente" />
                <asp:SessionParameter Name=":empresa" SessionField="GlEmpresa" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
