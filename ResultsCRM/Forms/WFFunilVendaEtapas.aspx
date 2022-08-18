<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFFunilVendaEtapas.aspx.vb" Inherits="ResultsCRM.WFFunilVendaEtapas" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="TituloCadastro">Etapas do Funil de Vendas:
        <asp:Label ID="LblDescricaoFunil" runat="server"></asp:Label>
    </div>
    <div><asp:Label ID="LblErro" runat="server" CssClass="Erro"></asp:Label></div>
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" 
            GridLines="None" Width="100%">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:TemplateField HeaderText="Seleção" SortExpression="marcado">
                    <EditItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("marcado") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="CbxMarcado" runat="server" Checked='<%# Bind("marcado") %>' />
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="70px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Etapa" SortExpression="descricao">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("descricao") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="LblDescricaoEtapa" runat="server" 
                            Text='<%# Bind("descricao") %>'></asp:Label>
                        (<asp:Label ID="LblCodEtapa" runat="server" Text='<%# Eval("cod_etapa") %>'></asp:Label>
                        )
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Sequência" SortExpression="seq_pipeline">
                    <EditItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("seq_pipeline") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:TextBox ID="TxtSequencia" runat="server" CssClass="CampoCadastro" 
                            MaxLength="3" Text='<%# Bind("seq_pipeline") %>' Width="45px"></asp:TextBox>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
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
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select e.cod_etapa, e.descricao,
       if exists(select 1 from funil_venda_etapa_negociacao f where f.empresa = e.empresa and f.cod_funil = :cod_funil1 and f.cod_etapa = e.cod_etapa) then 'True' else 'False' endif marcado,
       (select seq_pipeline from funil_venda_etapa_negociacao f where f.empresa = e.empresa and f.cod_funil = :cod_funil2 and f.cod_etapa = e.cod_etapa) seq_pipeline
  from etapa_negociacao e
 order by e.descricao">
            <SelectParameters>
                <asp:SessionParameter Name=":cod_funil1" SessionField="SCodFunil" />
                <asp:SessionParameter Name=":cod_funil2" SessionField="SCodFunil" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>
    <div style="text-align:center">
        <asp:Button ID="BtnVoltar" runat="server" Text="Voltar" />
&nbsp;
        <asp:Button ID="BtnGravar" runat="server" Text="Gravar" />
    </div>
    </form>
</body>
</html>
