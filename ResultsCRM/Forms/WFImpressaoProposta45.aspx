<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFImpressaoProposta45.aspx.vb" Inherits="ResultsCRM.WFImpressaoProposta45" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Proposta Comercial</title>
</head>
<body>
    <form id="form1" runat="server">
    <table style="width:900px; font-family: Verdana; font-size: 8pt; border-collapse: collapse;">
        <tr>
            <td colspan="3">
                <div style="width: 30mm; position: relative; top: 0px; left: 0px"><img alt="Proposta Comercial" src="http://matriz.unissistemas.com.br/webdeskunis/Imagens/unis.jpg" 
                    style="width: 30mm; height: 30mm" /></div>
                <div style="position: absolute; top: 17px; left: 35mm; width: 470px;">
                <span style="font-size:12pt"><asp:Label ID="LblRazaoSocialEmpresa" runat="server"></asp:Label></span>
                <br />
                <br />
                CNPJ:
                <asp:Label ID="LblCNPJEmpresa" runat="server"></asp:Label>
                <br />
                <asp:Label ID="LblEnderecoEmpresa" runat="server"></asp:Label>
                <br />
                <asp:Label ID="LblCidadeEmpresa" runat="server"></asp:Label>
                <br />
                <asp:Label ID="LblTelefoneEmpresa" runat="server"></asp:Label></div>
            </td>
            <td style="width: 30%; text-align: center; vertical-align: top;">
                <span style="font-size:14pt">Proposta Comercial</span><br />
                <span style="font-size: 12pt">
                Nº&nbsp;<asp:Label ID="LblCodNegociacaoCliente" runat="server" Text="0"></asp:Label></span><span>
                <br />
                <br />
                Emitida em:&nbsp;<asp:Label ID="LblDataNegociacao" runat="server" Text="00/00/0000"></asp:Label>
                <br />
                Válida até:&nbsp;<asp:Label ID="LblValidade" runat="server" Text="00/00/0000"></asp:Label>
                </span>
            </td>
        </tr>
        <tr>
            <td colspan="4" style="text-align: center">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">
                À</td>
        </tr>
        <tr>
            <td style="font-size: 10pt;">
                <asp:Label ID="LblRazaoSocial" runat="server" Font-Bold="False"></asp:Label>
            </td>
            <td style="text-align: left; font-size: 10pt;" colspan="3">
                CNPJ/CPF:
                <asp:Label ID="LblCNPJ" runat="server" Font-Bold="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LblEndereco" runat="server"></asp:Label>
                -
                <asp:Label ID="LblCidade" runat="server"></asp:Label>
            </td>
            <td style="text-align: left" colspan="3">
                IE:
                <asp:Label ID="LblInscricaoEstadual" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Fone(s):
                e<asp:Label ID="LblTelefone" runat="server" Font-Bold="False"></asp:Label>
                &nbsp;&nbsp;Fax:&nbsp;<asp:Label ID="LblFAX" runat="server"></asp:Label>
            </td>
            <td style="text-align: left" colspan="3">
                E-mail:
                <asp:Label ID="LblEmitenteEmail" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Contato:
                <asp:Label ID="LblContato" runat="server"></asp:Label>
            </td>
            <td style="text-align: left" colspan="3">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">
                <br />
                </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Label ID="LblCabecalho" runat="server" Width="100%" Font-Bold="False"></asp:Label>
                <br />
            </td>
        </tr>
        <tr>
            <td colspan="4">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                    DataSourceID="SqlDataSource3" GridLines="None" ShowHeader="False" Width="100%">
                    <Columns>
                        <asp:TemplateField HeaderText="cod_grupo" SortExpression="cod_grupo">
                            <EditItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("cod_grupo") %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="LblCodGrupo" runat="server" Text='<%# Bind("cod_grupo") %>' 
                                    Visible="False"></asp:Label>
                                <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Italic="True" 
                                    Text='<%# Eval("descricao") %>' Width="100%"></asp:Label>
                                <br />
                                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                                    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                                    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
                                    SelectCommand="select nci.seq_item, nci.cod_item, i.descricao, nci.narrativa negitem_narrativa, nci.qtd_ud, nci.preco_unitario_ud preco_unitario, nci.valor_total_mercadoria total_mercadoria
  from negociacao_cliente_item nci inner join item i on i.cod_item = nci.cod_item
 where nci.empresa                = :empresa
   and nci.estabelecimento        = :estabelecimento
   and nci.cod_negociacao_cliente = :negociacao
   and ( :cod_grupo is null or :cod_grupo in ('0',(select cod_grupo from item_grupo_comercial where cod_item = nci.cod_item) ) )
 order by nci.seq_item">
                                    <SelectParameters>
                                        <asp:QueryStringParameter Name=":empresa" QueryStringField="eid" />
                                        <asp:QueryStringParameter Name=":estabelecimento" QueryStringField="sid" />
                                        <asp:QueryStringParameter Name=":negociacao" QueryStringField="nid" />
                                        <asp:ControlParameter ControlID="LblCodGrupo" Name=":cod_grupo" 
                                            PropertyName="Text" />
                                        <asp:ControlParameter ControlID="LblCodGrupo" Name=":cod_grupo" 
                                            PropertyName="Text" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                                <div style="padding-left: 40px; font-weight: normal;">
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                        BackColor="White" BorderColor="#E2E2E2" BorderStyle="None" BorderWidth="1px" 
                                        CellPadding="4" DataSourceID="SqlDataSource2" Font-Size="8pt" ForeColor="Black" 
                                        GridLines="Horizontal" Width="838px" 
                                        OnDataBound="GridView1_DataBound" ShowFooter="True">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Item" SortExpression="seq_item">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("seq_item") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="LblSeqItem" runat="server" Text='<%# Bind("seq_item") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Código" SortExpression="cod_item">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("cod_item") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="LblCodItem" runat="server" Text='<%# Bind("cod_item") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Descrição" SortExpression="descricao">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("descricao") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("descricao") %>'></asp:Label>
                                                    <br />
                                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("negitem_narrativa") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                                <ItemStyle HorizontalAlign="Justify" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="qtd_ud" DataFormatString="{0:F2}" 
                                                HeaderText="Quantidade" SortExpression="qtd_ud">
                                            <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                            <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="preco_unitario" DataFormatString="{0:F2}" 
                                                HeaderText="R$ Unitário" SortExpression="preco_unitario">
                                            <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                            <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="R$ Total" SortExpression="total_mercadoria">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox2" runat="server" 
                                                        Text='<%# Bind("total_mercadoria") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    Total: R$
                                                    <asp:Label ID="LblTotal" runat="server" Font-Bold="True" Text="0,00"></asp:Label>
                                                </FooterTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="LblValorMercadoria" runat="server" 
                                                        Text='<%# Bind("total_mercadoria", "{0:F2}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                                <ItemStyle HorizontalAlign="Right" Width="110px" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <FooterStyle ForeColor="Black" HorizontalAlign="Right" />
                                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                                        <RowStyle VerticalAlign="Top" />
                                        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BorderStyle="None" Font-Bold="False" ForeColor="Black" />
                                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                        <SortedDescendingHeaderStyle BackColor="#242121" />
                                    </asp:GridView>
                                </div>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="4" style="text-align: right; font-weight: bold">
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" SelectCommand="select isnull(igc.cod_grupo,0) cod_grupo, isnull(g.descricao,'&lt;b style=&quot;color:red&quot;&gt;GRUPO COMERCIAL NÃO INFORMADO NO CADASTRO DO ITEM'||nci.cod_item||'. AJUSTAR.&lt;/b&gt;') descricao
  from negociacao_cliente_item nci left outer join item_grupo_comercial igc on igc.cod_item = nci.cod_item
                                   left outer join grupo_comercial g on g.cod_grupo = igc.cod_grupo
 where nci.empresa                = :empresa
   and nci.estabelecimento        = :estabelecimento
   and nci.cod_negociacao_cliente = :negociacao
 group by igc.cod_grupo, descricao
 order by igc.cod_grupo" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>">
                    <SelectParameters>
                        <asp:QueryStringParameter Name=":empresa" QueryStringField="eid" />
                        <asp:QueryStringParameter Name=":estabelecimento" QueryStringField="sid" />
                        <asp:QueryStringParameter Name=":negociacao" QueryStringField="nid" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <br />
                Forma de Pagamento:
                <asp:Label ID="LblFormaPagamento" runat="server"></asp:Label>
            </td>
            <td colspan="2">
                <br />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                Condição de Pagamento:
                <asp:Label ID="LblCondicaoPagamento" runat="server"></asp:Label>
            </td>
            <td colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;</td>
            <td colspan="2">
            </td>
        </tr>
        <tr>
            <td colspan="4" style="text-align: justify">
                <br />
                <asp:Label ID="LblRodape" runat="server" style="text-align: justify" 
                    Width="100%"></asp:Label>
                <br />
            </td>
        </tr>
        <tr>
            <td colspan="4">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">
                <span style="font-weight:bold">Observações:</span>  
                <asp:Label ID="LblObservacao" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4" style="text-align: center">
                <asp:Label ID="Label3" runat="server" 
                    Text="____________________________________________"></asp:Label>
                <br />
                <asp:Label ID="LblNomeAgenteVendas" runat="server"></asp:Label>
                <br />
                E-mail: <asp:Label ID="LblEmailAgenteVendas" runat="server"></asp:Label>
                <br />
                Skype: <asp:Label ID="LblSkypeAgenteVendas" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
