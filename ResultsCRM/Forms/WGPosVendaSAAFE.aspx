<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGPosVendaSAAFE.aspx.vb" Inherits="ResultsCRM.WGPosVendaSAAFE" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="TextoCadastro_BGBranco" style="font-weight: bold">
    
        HISTÓRICO SPDO<br />
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" CssClass="TextoCadastro_BGBranco" DataSourceID="SqlDataSource1" 
            EmptyDataText="Não há registros." 
            Font-Bold="False" ForeColor="#333333" 
            GridLines="None" Width="100%" AllowPaging="True" AllowSorting="True" 
            DataKeyNames="seq_arquivo,cod_resolucao" PageSize="2">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="seq_arquivo" HeaderText="Seq." 
                    SortExpression="seq_arquivo" ReadOnly="True" >
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="data_publicacao" 
                    DataFormatString="{0:dd/MM/yyyy}" HeaderText="Data" 
                    SortExpression="data_publicacao" >
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="cod_resolucao" 
                    DataFormatString="{0:F0}" HeaderText="Resolução" 
                    SortExpression="cod_resolucao" ReadOnly="True" >
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Descrição" SortExpression="descricao">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("descricao") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("descricao") %>'></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("artigos") %>'></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("responsavel") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Justify" />
                    <ItemStyle HorizontalAlign="Justify" />
                </asp:TemplateField>
                <asp:BoundField DataField="email_enviado" HeaderText="E-mail enviado em" 
                    ReadOnly="True" SortExpression="email_enviado">
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                HorizontalAlign="Center" />
            <PagerSettings FirstPageText="1º" LastPageText="Última" 
                Mode="NumericFirstLast" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" 
                VerticalAlign="Top" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand=" select distinct ra.seq_arquivo, a.data_publicacao,
        r.cod_resolucao,
        r.descricao,
        f_diario_oficial_artigo(a.seq_arquivo, r.cod_resolucao) artigos, r.responsavel,
        (select list(distinct convert(varchar(10),em.data_envio,103) || ' ' || convert(varchar(8),em.data_envio,114) , ' / ')
           from diario_oficial_resolucao_email em
          where em.seq_arquivo   = r.seq_arquivo
            and em.cod_resolucao = r.cod_resolucao
            and em.cod_farmacia  = ra.cod_emitente) data_envio,
        if trim(isnull(data_envio,'')) = '' then ' (ainda não enviado) ' else data_envio endif email_enviado
   from diario_oficial_arquivo a inner join diario_oficial_resolucao r on a.seq_arquivo = r.seq_arquivo
                                 inner join diario_oficial_resolucao_anexo ra on r.seq_arquivo = ra.seq_arquivo and r.cod_resolucao = ra.cod_resolucao
  where ra.cod_emitente = :cod_farmacia
order by ra.seq_arquivo desc">
            <SelectParameters>
                <asp:SessionParameter Name=":cod_farmacia" SessionField="SCodEmitente" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
