<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFImpressaoPropostaDehon.aspx.vb" Inherits="ResultsCRM.WFImpressaoPropostaDehon" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Proposta Comercial</title>
</head>
<body id="body1" runat="server">
    <form id="form1" runat="server">
    <table style="width:800px; font-family: Verdana; font-size: 9pt;">
        <tr>
            <td 
                colspan="6">
                <asp:Button ID="BtnImprimir" runat="server" Text="Imprimir" />
            </td>
        </tr>
        <tr>
            <td style="text-align: left" 
                colspan="5">
                <img alt="Proposta Comercial" src="http://sinamm.no-ip.info/dehon/Imagens/logo_proposta.jpg" 
                    style="width: 70mm; height: 12mm" /></td>
            <td colspan="1" 
                
                style="text-align: right; font-size: 11pt; vertical-align: top;">
                NEGOCIAÇÃO Nº
                <asp:Label ID="LblCodNegociacao" runat="server" Font-Bold="True" Text="0"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: left" colspan="6">
                Fone/Fax:
                <asp:Label ID="LblTelefoneEmpresa" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: left" colspan="6">
                <asp:Label ID="LblEmailEmpresa" runat="server"></asp:Label>
&nbsp;-
                <asp:Label ID="LblSite" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: left" colspan="6">
                <asp:Label ID="LblEnderecoEmpresa" runat="server"></asp:Label>
            &nbsp;-
                <asp:Label ID="LblCidadeEmpresa" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="1" 
                
                
                style="border-width: 1px; border-style: solid none none none; border-color: #808080; text-align: right">
                Data: 
            </td>
            <td colspan="5" 
                
                
                style="border-width: 1px; border-style: solid none none none; border-color: #808080; text-align: left">
                <asp:Label ID="LblDataCadastramento" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="1" 
                
                style="text-align: right">
                *<asp:Label ID="LblAux1Label" runat="server"></asp:Label>
            </td>
            <td colspan="5">
                <asp:Label ID="LblAux1" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="1" 
                
                style="text-align: right">
                &nbsp;</td>
            <td colspan="5" 
                
                style="text-align: left; font-size: 7pt; color: #808080;">
                *Entrega de produtos novos 15 dias após aprovação da arte</td>
        </tr>
        <tr>
            <td colspan="1" 
                
                style="text-align: right">
                Vendedor:</td>
            <td colspan="5">
                <asp:Label ID="LblVendedor" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="6" 
                
                
                style="border-width: 1px; border-style: solid none none none; border-color: #808080; text-align: left">
                <asp:Label ID="LblCabecalho" runat="server" Width="100%"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                Cliente:</td>
            <td colspan="5">
                <asp:Label ID="LblRazaoSocial" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                Endereço:</td>
            <td colspan="5">
                <asp:Label ID="LblEndereco" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                Cidade/UF:</td>
            <td colspan="5">
                <asp:Label ID="LblCidade" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                CEP:</td>
            <td colspan="5">
                <asp:Label ID="LblCepCliente" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                Telefone:</td>
            <td colspan="2">
                <asp:Label ID="LblTelefone" runat="server"></asp:Label>
            </td>
            <td style="text-align: right" colspan="2">
                Celular:</td>
            <td>
                <asp:Label ID="LblCelularCliente" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                Contato:</td>
            <td colspan="5">
                <asp:Label ID="LblContato" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                E-mail:</td>
            <td colspan="5">
                <asp:Label ID="LblEmailCliente" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                CNPJ:</td>
            <td colspan="5">
                <asp:Label ID="LblCNPJ" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                Insc. Est.:</td>
            <td colspan="5">
                <asp:Label ID="LblInscricaoEstadual" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                Cond. de Pagto:</td>
            <td colspan="5">
                <asp:Label ID="LblCondPagto" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                Transportadora:</td>
            <td colspan="5">
                <asp:Label ID="LblTransportadora" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td 
                colspan="6">
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select i.cod_item,
       i.descricao || if trim(isnull(ni.narrativa,'')) &lt;&gt; '' then ' - ' || trim(isnull(ni.narrativa,'')) else '' endif  descricao_item,
       altura, 
       largura,
       espessura,
       aux1, 
       aux2,
       aux3,
       aux4,
       aux5,
       aux6,
       aux7,
       aux8,
       aux9,
       aux10,
       ni.qtd_pedida,
       ni.qtd_ud,
       isnull(ni.cod_unidade, i.cod_unidade) cod_unidade,
       preco_unitario,
       preco_unitario_ud,
       valor_desconto,
       valor_total_mercadoria
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
            <td colspan="6">
                <asp:GridView ID="GridView1" runat="server" 
                    DataSourceID="SqlDataSource2" GridLines="None" 
                    Width="100%" AutoGenerateColumns="False" CellPadding="2">
                    <RowStyle Font-Size="8pt" BorderColor="Silver" BorderStyle="Solid" 
                        BorderWidth="1px" />
                    <Columns>
                        <asp:BoundField DataField="qtd_ud" HeaderText="**Quant" 
                            SortExpression="qtd_ud" DataFormatString="{0:F2}" >
                            <HeaderStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="cod_unidade" HeaderText="Un" 
                            SortExpression="cod_unidade">
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Descrição" SortExpression="descricao_item">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox11" runat="server" Text='<%# Bind("descricao_item") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label11" runat="server" Text='<%# Bind("descricao_item") %>'></asp:Label>
                                (<asp:Label ID="Label12" runat="server" Text='<%# Eval("cod_item") %>'></asp:Label>
                                )
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="H x L/C x E" 
                            SortExpression="altura">
                            <ItemTemplate>
                                <asp:Label ID="Label13" runat="server" Text='<%# Bind("altura", "{0:N0}") %>'></asp:Label>
                                &nbsp;x
                                <asp:Label ID="Label14" runat="server" Text='<%# Eval("largura", "{0:N0}") %>'></asp:Label>
                                &nbsp;x
                                <asp:Label ID="Label15" runat="server" 
                                    Text='<%# Eval("espessura", "{0:N4}") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox12" runat="server" Text='<%# Bind("altura") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="120px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="aux1" SortExpression="aux1">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("aux1") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <HeaderTemplate>
                                <asp:Label ID="LblAux1" runat="server"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("aux1") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="aux2" SortExpression="aux2">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("aux2") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <HeaderTemplate>
                                <asp:Label ID="LblAux2" runat="server"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("aux2") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="aux3" SortExpression="aux3" Visible="False">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("aux3") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <HeaderTemplate>
                                <asp:Label ID="LblAux3" runat="server"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("aux3") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="aux4" SortExpression="aux4" Visible="False">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("aux4") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <HeaderTemplate>
                                <asp:Label ID="LblAux4" runat="server"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("aux4") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="aux5" SortExpression="aux5" Visible="False">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("aux5") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <HeaderTemplate>
                                <asp:Label ID="LblAux5" runat="server"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label5" runat="server" Text='<%# Bind("aux5") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="aux6" SortExpression="aux6" Visible="False">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("aux6") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <HeaderTemplate>
                                <asp:Label ID="LblAux6" runat="server"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label6" runat="server" Text='<%# Bind("aux6") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="aux7" SortExpression="aux7" Visible="False">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("aux7") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <HeaderTemplate>
                                <asp:Label ID="LblAux7" runat="server"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label7" runat="server" Text='<%# Bind("aux7") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="aux8" SortExpression="aux8" Visible="False">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("aux8") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <HeaderTemplate>
                                <asp:Label ID="LblAux8" runat="server"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label8" runat="server" Text='<%# Bind("aux8") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="aux9" SortExpression="aux9" Visible="False">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("aux9") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <HeaderTemplate>
                                <asp:Label ID="LblAux9" runat="server"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label9" runat="server" Text='<%# Bind("aux9") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="preco_unitario_ud" DataFormatString="{0:N2}" 
                            HeaderText="V.Unit." SortExpression="preco_unitario_ud">
                            <HeaderStyle HorizontalAlign="Right" BorderColor="Silver" BorderStyle="Solid" 
                                BorderWidth="1px" />
                            <ItemStyle HorizontalAlign="Right" BorderColor="Silver" BorderStyle="Solid" 
                                BorderWidth="1px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="valor_desconto" DataFormatString="{0:F2}" 
                            HeaderText="Desc." SortExpression="valor_desconto" Visible="False">
                            <HeaderStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="valor_total_mercadoria" DataFormatString="{0:N2}" 
                            HeaderText="Total" SortExpression="valor_total_mercadoria">
                            <HeaderStyle HorizontalAlign="Right" BorderColor="Silver" BorderStyle="Solid" 
                                BorderWidth="1px" />
                            <ItemStyle HorizontalAlign="Right" BorderColor="Silver" BorderStyle="Solid" 
                                BorderWidth="1px" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="aux10" SortExpression="aux10">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox10" runat="server" Text='<%# Bind("aux10") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <HeaderTemplate>
                                <asp:Label ID="LblAux10" runat="server"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label10" runat="server" Text='<%# Bind("aux10") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle 
                        Font-Size="8pt" Font-Overline="False" Font-Strikeout="False" 
                        Font-Underline="False" BorderColor="Silver" BorderStyle="Solid" 
                        BorderWidth="1px" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="4" style="font-size: 7pt; color: #808080;">
                ** As quantidades podem variar, na entrega, em até 20% para mais ou para menos.</td>
            <td colspan="2" 
                style="border: 2px solid #C0C0C0; text-align: center; font-weight: bold">
                                Total: R$
                <asp:Label ID="LblValorTotal" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="6" style="font-size: 7pt; color: #808080;">
                *** No item clichê identifica NOVO, ANTIGO e APLICAÇÃO NOVA (APL.N)</td>
        </tr>
        <tr>
            <td colspan="6" 
                
                style="text-align: left">
                <asp:Label ID="LblAux2Label" runat="server"></asp:Label>
                <asp:Label ID="LblAux2" runat="server"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="LblAux3Label" runat="server"></asp:Label>
                <asp:Label ID="LblAux3" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="6">
                Obs:
                <asp:Label ID="LblObservacao" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="6">
                <asp:Label ID="LblRodape" runat="server" style="text-align: justify" 
                    Width="100%"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="6">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="6" 
                style="text-align: center">
                Vendedor:___________________________________&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                Cliente:____________________________________</td>
        </tr>
    </table>
    </form>
</body>
</html>
