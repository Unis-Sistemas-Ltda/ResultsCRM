<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFImpressaoProposta.aspx.vb" Inherits="ResultsCRM.WFImpressaoProposta" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Proposta Comercial</title>
</head>
<body>
    <form id="form1" runat="server">
    <table style="width:900px; font-family: Verdana; font-size: 8pt;">
        <tr>
            <td colspan="2">
                <img alt="Proposta Comercial" src="../Imagens/logo_proposta.jpg" 
                    style="width: 60mm; height: 8mm" /></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="LblSite" runat="server" style="color: #808080"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="LblMensagem" runat="server" style="color: #808080"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:Label ID="LblCabecalho" runat="server" Width="100%" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" style="font-weight: bold">
                1. SOBRE AS PARTES</td>
        </tr>
        <tr>
            <td colspan="2" style="font-weight: bold">
                1.1 Dados do Cliente</td>
        </tr>
        <tr>
            <td style="width: 110px">
                <asp:Label ID="Label1" runat="server" Text="Nome do Contato"></asp:Label>
            </td>
            <td style="text-align: left; width: 790px">
                <asp:Label ID="LblContato" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Razão Social</td>
            <td style="text-align: left">
                <asp:Label ID="LblRazaoSocial" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Endereço</td>
            <td style="text-align: left">
                <asp:Label ID="LblEndereco" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Cidade</td>
            <td style="text-align: left">
                <asp:Label ID="LblCidade" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Telefone</td>
            <td style="text-align: left">
                <asp:Label ID="LblTelefone" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                CNPJ</td>
            <td style="text-align: left">
                <asp:Label ID="LblCNPJ" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Insc. Est.</td>
            <td style="text-align: left">
                <asp:Label ID="LblInscricaoEstadual" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" style="font-weight: bold">
                1.2 Dados do Fornecedor</td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                Razão Social</td>
            <td style="text-align: left">
                <asp:Label ID="LblRazaoSocialEmpresa" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Endereço</td>
            <td style="text-align: left">
                <asp:Label ID="LblEnderecoEmpresa" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Cidade</td>
            <td style="text-align: left">
                <asp:Label ID="LblCidadeEmpresa" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Telefone</td>
            <td style="text-align: left">
                <asp:Label ID="LblTelefoneEmpresa" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                CNPJ</td>
            <td style="text-align: left">
                <asp:Label ID="LblCNPJEmpresa" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Insc. Est.</td>
            <td style="text-align: left">
                <asp:Label ID="LblInscricaoEstadualEmpresa" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" style="font-weight: bold">
                2 RESUMO TÉCNICO</td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1" 
                    Width="100%">
                    <ItemTemplate>
                        <table style="border-style: solid; border-width: 1px; width:100%;">
                            <tr>
                                <td style="width: 5cm; text-align: center; border-style: solid; border-width: 1px;">
                                    <asp:Image ID="Imagem" ImageUrl='<%# String.Concat("..\Generico\GerarImagem.ashx?id=", Eval("cod_item")) %>' runat="server" Height="4cm" Width="4cm" />
                                </td>
                                <td style="text-align: center; border-style: solid; border-width: 1px;">
                                    <asp:Label ID="descricaoLabel" runat="server" Text='<%# Eval("descricao") %>' 
                                        style="font-weight: 700; font-size: 11pt" />
                                    <asp:Label ID="LblCodItem" runat="server" Text='<%# Eval("cod_item") %>' 
                                        Visible="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="border-style: solid; border-width: 1px;">
                                    <asp:Label ID="observacao_propostaLabel" runat="server" 
                                        Text='<%# Eval("observacao_proposta") %>' />
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select i.cod_item, i.descricao, i.observacao_proposta
  from item i inner join negociacao_cliente_item ni on ni.cod_item = i.cod_item
where ni.empresa = :empresa
   and ni.estabelecimento = :estabelecimento
   and ni.cod_negociacao_cliente = :negociacao">
                    <SelectParameters>
                        <asp:QueryStringParameter Name=":empresa" QueryStringField="eid" />
                        <asp:QueryStringParameter Name=":estabelecimento" QueryStringField="sid" />
                        <asp:QueryStringParameter Name=":negociacao" QueryStringField="nid" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="font-weight: bold">
                3 TABELA DE INVESTIMENTOS</td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="GridView1" runat="server" CellPadding="4" 
                    DataSourceID="SqlDataSource2" ForeColor="#333333" GridLines="None" 
                    Width="100%" AutoGenerateColumns="False">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                        <asp:BoundField DataField="seq_item" HeaderText="Item" 
                            SortExpression="seq_item">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="i.descricao || ni.narrativa" HeaderText="Descrição" 
                            ReadOnly="True" SortExpression="i.descricao || ni.narrativa">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="valor_total_mercadoria" DataFormatString="{0:N2}" 
                            HeaderText="Investimento (R$)" SortExpression="valor_total_mercadoria">
                            <HeaderStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                    </Columns>
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: right; font-weight: bold">
                Investimento Total: R$
                <asp:Label ID="LblValorTotal" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select ni.seq_item, i.descricao || ni.narrativa, ni.valor_total_mercadoria
  from negociacao_cliente_item ni inner join item i on ni.cod_item = i.cod_item
where ni.empresa = :empresa
   and ni.estabelecimento = :estabelecimento
   and ni.cod_negociacao_cliente = :negociacao">
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
                <asp:Label ID="LblRodape" runat="server" style="text-align: justify" 
                    Width="100%"></asp:Label>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
