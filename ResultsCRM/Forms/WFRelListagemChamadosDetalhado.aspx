<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFRelListagemChamadosDetalhado.aspx.vb" Inherits="ResultsCRM.WFRelListagemChamadosDetalhado" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register src="../OutrosControles/TextBoxData.ascx" tagname="TextBoxData" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Listagem de Chamados - Detalhada</title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
    <link href="../ResultsCRMAjax.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="../ResultsCRM.js"></script>
    </head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="Button1" runat="server" 
            onclientclick="self.print(); return false;" Text="Imprimir" />
        &nbsp;
    
        <asp:Button ID="Button2" runat="server" 
            onclientclick="history.back(); return false;" Text="Voltar" />
        <br />
    
        <br />
        <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" DataSourceID="SqlDataSource3" ForeColor="#333333" 
            GridLines="None" Width="100%">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:TemplateField HeaderText="Cliente" SortExpression="nome">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("nome") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <br />
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" 
                            Text='<%# Bind("nome") %>' Font-Size="9pt"></asp:Label>
                        (
                        <asp:Label ID="LblCodEmitente" runat="server" 
                            Text='<%# Eval("cod_emitente") %>' Font-Bold="True" Font-Size="9pt"></asp:Label>
                        )<br /> <br />
                        <div style="padding-left: 45px">
                            <asp:GridView ID="GridView1" runat="server" AllowSorting="True" 
                                AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource1" 
                                ForeColor="#333333" GridLines="None" 
                                Width="80%" ShowHeader="False">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Chamado(s)" SortExpression="cod_chamado">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("cod_chamado") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            Total
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            Chamado:
                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("cod_chamado") %>'></asp:Label>
                                            <br />
                                            Abertura:
                                            <asp:Label ID="Label2" runat="server" 
                                                Text='<%# Bind("data_chamado", "{0:dd/MM/yyyy HH:mm}") %>'></asp:Label>
                                            <br />
                                            Encerramento:
                                            <asp:Label ID="Label3" runat="server" 
                                                Text='<%# Bind("data_encerramento", "{0:dd/MM/yyyy}") %>'></asp:Label>
                                            <br />
                                            <br />
                                            Assunto:
                                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("assunto") %>'></asp:Label>
                                            <br />
                                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("follow_up") %>'></asp:Label>
                                            <br />
                                            <br />
                                            <asp:Label ID="Label6" runat="server" Text='<%# Bind("em") %>'></asp:Label>
                                            <br />
                                            <asp:Label ID="Label7" runat="server" BackColor="#CCCCCC" BorderStyle="None" 
                                                Font-Size="1pt" Height="1px" Text=" " Width="100%"></asp:Label>
                                            <br />
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" Font-Bold="False"/>
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                    </asp:TemplateField>
                                </Columns>
                                <EditRowStyle BackColor="#999999" />
                                <FooterStyle BackColor="White" Font-Bold="True" ForeColor="#333333" />
                                <HeaderStyle BackColor="White" Font-Bold="False" ForeColor="#333333" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="White" ForeColor="#333333" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                            </asp:GridView>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                                ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select c.cod_chamado,
       c.data_chamado,
       c.data_encerramento,
       tc.nome nome_tipo_chamado,
       c.assunto,
       (select list(f.descricao,' /') from follow_up_chamado f where f.empresa = c.empresa and f.cod_chamado = c.cod_chamado) follow_up,
       f_email_chamado_complemento_new(c.empresa, c.cod_chamado, c.cod_status,'S','S','S','N') em
  from chamado c left outer join pedido_venda pv on c.empresa = pv.empresa and c.cod_chamado = pv.cod_chamado
                 left outer join pedido_venda_item pvi on pvi.empresa = pv.empresa and pvi.estabelecimento = pv.estabelecimento and pvi.cod_pedido_venda = pv.cod_pedido_venda
                 left outer join tipo_chamado tc on tc.empresa = c.empresa and c.tipo_chamado = tc.codigo
where isnull(date(c.data_chamado),'1900-01-01') between convert(date,f_isnull_or_empty(:da1,'01/01/1900'),103) and convert(date,f_isnull_or_empty(:da2,'31/12/2199'),103)
   and isnull(date(c.data_encerramento),'1900-01-01') between convert(date,f_isnull_or_empty(:de1,'01/01/1900'),103) and convert(date,f_isnull_or_empty(:de2,'31/12/2199'),103)
   and :tch in (isnull(c.tipo_chamado,-1),0)
   and :tco in (isnull(pvi.cod_tipo_cobranca_os,-1),0)
   and c.cod_emitente = f_isnull_or_empty(:cl, c.cod_emitente)
   and isnull(pvi.numero_serie,'') = f_isnull_or_empty(:eq, isnull(pvi.numero_serie,''))
   and c.cod_emitente = :cod_emitente
 group by c.empresa,
          c.cod_chamado,
          c.data_chamado,
          c.data_encerramento,
          tc.nome,
          c.assunto, c.cod_status
 order by c.cod_chamado desc">
                                <SelectParameters>
                                    <asp:QueryStringParameter ConvertEmptyStringToNull="False" DbType="String" 
                                        Name="da1" QueryStringField="da1" />
                                    <asp:QueryStringParameter ConvertEmptyStringToNull="False" DbType="String" 
                                        Name="da2" QueryStringField="da2" />
                                    <asp:QueryStringParameter ConvertEmptyStringToNull="False" DbType="String" 
                                        Name="de1" QueryStringField="de1" />
                                    <asp:QueryStringParameter ConvertEmptyStringToNull="False" DbType="String" 
                                        Name="de2" QueryStringField="de2" />
                                    <asp:QueryStringParameter ConvertEmptyStringToNull="False" DbType="String" 
                                        Name="tch" QueryStringField="tch" />
                                    <asp:QueryStringParameter ConvertEmptyStringToNull="False" DbType="String" 
                                        Name="tco" QueryStringField="tco" />
                                    <asp:QueryStringParameter ConvertEmptyStringToNull="False" DbType="String" 
                                        Name="cl" QueryStringField="cl" />
                                    <asp:QueryStringParameter ConvertEmptyStringToNull="False" DbType="String" 
                                        Name="eq" QueryStringField="eq" />
                                    <asp:ControlParameter ControlID="LblCodEmitente" Name="cod_emitente" 
                                        PropertyName="Text" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                            <br />
                        </div>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:TemplateField>
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="False" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select e.cod_emitente, e.nome
  from chamado c left outer join pedido_venda pv on c.empresa = pv.empresa and c.cod_chamado = pv.cod_chamado
                 left outer join pedido_venda_item pvi on pvi.empresa = pv.empresa and pvi.estabelecimento = pv.estabelecimento and pvi.cod_pedido_venda = pv.cod_pedido_venda
                 left outer join tipo_chamado tc on tc.empresa = c.empresa and c.tipo_chamado = tc.codigo
                 inner join emitente e on e.cod_emitente = c.cod_emitente
 where isnull(date(c.data_chamado),'1900-01-01') between convert(date,f_isnull_or_empty(:da1,'01/01/1900'),103) and convert(date,f_isnull_or_empty(:da2,'31/12/2199'),103)
   and isnull(date(c.data_encerramento),'1900-01-01') between convert(date,f_isnull_or_empty(:de1,'01/01/1900'),103) and convert(date,f_isnull_or_empty(:de2,'31/12/2199'),103)
   and :tch in (isnull(c.tipo_chamado,-1),0)
   and :tco in (isnull(pvi.cod_tipo_cobranca_os,-1),0)
   and c.cod_emitente = f_isnull_or_empty(:cl, c.cod_emitente)
   and isnull(pvi.numero_serie,'') = f_isnull_or_empty(:eq, isnull(pvi.numero_serie,''))
 group by e.cod_emitente, e.nome
 order by e.nome, e.cod_emitente">
            <SelectParameters>
                <asp:QueryStringParameter ConvertEmptyStringToNull="False" DbType="String" Name="da1" QueryStringField="da1" />
                <asp:QueryStringParameter ConvertEmptyStringToNull="False" DbType="String" Name="da2" QueryStringField="da2" />
                <asp:QueryStringParameter ConvertEmptyStringToNull="False" DbType="String" Name="de1" QueryStringField="de1" />
                <asp:QueryStringParameter ConvertEmptyStringToNull="False" DbType="String" Name="de2" QueryStringField="de2" />
                <asp:QueryStringParameter ConvertEmptyStringToNull="False" DbType="String" Name="tch" QueryStringField="tch" />
                <asp:QueryStringParameter ConvertEmptyStringToNull="False" DbType="String" Name="tco" QueryStringField="tco" />
                <asp:QueryStringParameter ConvertEmptyStringToNull="False" DbType="String" Name="cl" QueryStringField="cl" />
                <asp:QueryStringParameter ConvertEmptyStringToNull="False" DbType="String" Name="eq" QueryStringField="eq" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
