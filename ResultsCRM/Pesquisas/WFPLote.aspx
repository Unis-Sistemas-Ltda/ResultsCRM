<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFPLote.aspx.vb" Inherits="ResultsCRM.WFPLote" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Pesquisa de Itens</title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
    <link href="../ResultsCRMAjax.css" rel="stylesheet" type="text/css" />
     <script language="javascript" type="text/javascript">
        function getbacktostepone() {
            window.location = "WFPLote.aspx";
        }
        function onSuccess() {
            window.parent.document.forms.item(0).submit();
            window.parent.document.getElementById('ButtonEditDone').click();
        }
        function onError() {
            getbacktostepone();
        }
        function cancel() {
            window.parent.document.getElementById('ButtonEditCancel').click();
        }
    </script>
</head>
<body class="TextoCadastro">
    <form id="form1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <asp:MultiView ID="MultiViewExpanse" runat="server">
        <asp:View ID="ViewInput" runat="server">
            <table class="TextoCadastro" 
                
                style="width: 350px; height: 340px; font-size: 7pt; background-color: #FFFFFF;">
                <tr>
                    <td class="TituloConsulta" colspan="3" style="height: 20px">
                        Pesquisa de Lotes</td>
                </tr>
                <tr>
                    <td style="height: 25px; width: 210px;">
                        <asp:Label ID="LblFornecedor" runat="server" 
                            Text="Informe o lote ou parte do lote:"></asp:Label>
                    </td>
                    <td class="CelulaCampoCadastro">
                        <asp:TextBox ID="TxtLote" runat="server" Width="90px"></asp:TextBox>
                    </td>
                    <td class="CelulaCampoCadastro">
                        <asp:Button ID="BtnFiltrar" runat="server" CssClass="Botao" Text="Filtrar" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="vertical-align: top">
                        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                            AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" 
                            DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" 
                            CssClass="CampoCadastro" Width="350px" PageSize="5" Font-Size="7pt" 
                            EmptyDataText="&lt;br&gt;&lt;br&gt;Informe o lote para busca&lt;br&gt;">
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <Columns>
                                <asp:TemplateField HeaderText="Lote" SortExpression="lote">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("lote") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="BtnSelecionar" runat="server" 
                                            CommandArgument='<%# Eval("lote") %>' ForeColor="Black" 
                                            Text='<%# Eval("lote") %>' CommandName="SELECIONAR"></asp:LinkButton>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Dados" SortExpression="descricao_item">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("descricao_item") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        Item:
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("descricao_item") %>'></asp:Label>
                                        <br />
                                        Depósito:
                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("descricao_deposito") %>'></asp:Label>
                                        <br />
                                        Localização:
                                        <asp:Label ID="Label3" runat="server" 
                                            Text='<%# Bind("descricao_localizacao") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="saldo" DataFormatString="{0:F2}" HeaderText="Qtde." 
                                    SortExpression="saldo">
                                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Top" Wrap="True" />
                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
                                </asp:BoundField>
                            </Columns>
                            <PagerSettings FirstPageText="1&nbsp;" LastPageText="Última" 
                                Mode="NumericFirstLast" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" />
                            <EditRowStyle BackColor="#999999" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                                HorizontalAlign="Left" />
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select se.lote,
       d.nome_deposito || ' (' || se.cod_deposito || ')' descricao_deposito,
       l.nome_localizacao || ' (' || l.cod_localizacao || ')' descricao_localizacao,
       i.descricao || ' (' || i.cod_item || ')' descricao_item,
       se.saldo,
       trim(:lote) lote_filtro
  from saldo_estoque se inner join item i on se.cod_item = i.cod_item
                        inner join deposito d on d.empresa         = se.empresa
                                             and d.estabelecimento = se.estabelecimento
                                             and d.cod_deposito    = se.cod_deposito
                        inner join localizacao l on l.empresa         = se.empresa
                                                and l.estabelecimento = se.estabelecimento
                                                and l.cod_deposito    = se.cod_deposito
                                                and l.cod_localizacao = se.cod_localizacao
 where lote_filtro &lt;&gt; ''
   and se.lote like '%' || lote_filtro ||  '%'
   and se.saldo                  &gt; 0
   and se.empresa             = :empresa
   and se.estabelecimento = :estabelecimento
 order by se.lote, se.cod_item">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="TxtLote" ConvertEmptyStringToNull="False" 
                                    DbType="String" Name=":lote" PropertyName="Text" />
                                <asp:SessionParameter DefaultValue="1" Name=":empresa" ConvertEmptyStringToNull="False" 
                                    SessionField="GlEmpresa" />
                                <asp:SessionParameter DefaultValue="1" Name=":estabelecimento" ConvertEmptyStringToNull="False" 
                                    SessionField="GlEstabelecimento" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </td>
                </tr>
                    <tr>
                        <td colspan="2" style="height: 16px; text-align: left;">
                            &nbsp;</td>
                        <td colspan="1" style="height: 16px">
                            <asp:Button ID="btnOkay" runat="server" CssClass="Botao" 
                                OnClick="btnOkay_Click" Text="Done" Visible="False" />
                            <input ID="btnCancel" class="Botao" onclick="cancel();" 
                                style="border-style: none; font-family: verdana; text-decoration: underline; text-align: center;" 
                                type="button" value="Fechar" /></td>
                    </tr>
                </table>
            </asp:View>
        </asp:MultiView>
    </form>
</body>
</html>