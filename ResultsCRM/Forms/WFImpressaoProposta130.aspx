<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFImpressaoProposta130.aspx.vb" Inherits="ResultsCRM.WFImpressaoProposta130" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Proposta Comercial</title>
    <style type="text/css">
        .auto-style1 {
            width: 135px;
        }

        .auto-style2 {
            width: 160px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table style="width: 800px; font-family: Arial; font-size: 9pt; border-collapse: collapse;">
            <tr>
                <td colspan="3">
                    <div style="width: 30mm; position: relative; top: 0px; left: 0px">                        
                        <asp:Image ID="LogoEmpresa" runat="server" Height="50" Width="50"/>
                    </div>
                    <div style="position: absolute; top: 17px; left: 35mm; width: 470px;">
                        <span style="font-size: 12pt">
                            <asp:Label ID="LblRazaoSocialEmpresa" runat="server"></asp:Label></span>
                        <br />
                        <br />
                        CNPJ:
                <asp:Label ID="LblCNPJEmpresa" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="LblEnderecoEmpresa" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="LblCidadeEmpresa" runat="server"></asp:Label>
                        <br />
                        Fone:
                <asp:Label ID="LblTelefoneEmpresa" runat="server"></asp:Label>
                    </div>
                </td>
                <td style="width: 30%; text-align: center; vertical-align: top; font-style: italic;">
                    <span style="font-size: 16pt; font-weight: bold;">Proposta Comercial</span><br />
                    <asp:Label ID="LblFpVd" Text="FP VD 03 01" runat="server" Font-Bold="True" Font-Size="9pt" Visible="True"></asp:Label><br />
                    <span style="font-size: 12pt; font-weight: bold;">Nº&nbsp;<asp:Label ID="LblCodNegociacaoCliente" runat="server" Text="0"></asp:Label></span>
                    <span style="font-size: 9pt">
                        <br />
                        <br />
                        Data:&nbsp;<asp:Label ID="LblDataNegociacao" runat="server" Text="00/00/0000"
                            Font-Bold="True" Font-Size="9pt"></asp:Label>
                        <br />
                        Validade:&nbsp;<asp:Label ID="LblValidade" runat="server" Text="00/00/0000"
                            Font-Bold="True" Font-Size="9pt"></asp:Label>
                    </span>
                </td>
            </tr>
            <tr>
                <td colspan="4" style="text-align: center">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="4" style="font-style: italic; font-weight: bold; font-size: 15pt;">A</td>
            </tr>
            <tr>
                <td style="font-style: italic; font-weight: bold; font-size: 15pt;">
                    <asp:Label ID="LblRazaoSocial" runat="server" Font-Bold="True" Font-Size="15pt"></asp:Label>
                </td>
                <td style="font-style: italic; font-size: 9pt;" colspan="3">CNPJ/CPF:
                <asp:Label ID="LblCNPJ" runat="server" Font-Bold="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="font-style: italic; font-size: 9pt;">
                    <asp:Label ID="LblEndereco" runat="server"></asp:Label>
                    -
                <asp:Label ID="LblCidade" runat="server"></asp:Label>
                </td>
                <td style="font-style: italic; font-size: 9pt;" colspan="3">IE:
                <asp:Label ID="LblInscricaoEstadual" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="font-style: italic; font-size: 9pt;">Fone(s):
                <asp:Label ID="LblTelefone" runat="server" Font-Bold="False"></asp:Label>
                </td>
                <td style="font-style: italic; font-size: 9pt;" colspan="3">Fax:
                    <asp:Label ID="LblFAX" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="font-style: italic; font-size: 9pt;">Contato:
                <asp:Label ID="LblContato" runat="server"></asp:Label>
                </td>
                <td style="font-style: italic; font-size: 9pt;" colspan="3">E-mail:
                <asp:Label ID="LblContatoEmail" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="font-style: italic; font-size: 9pt;" class="auto-style1">Representante:
                <asp:Label ID="LlbRepresentante" runat="server"></asp:Label>
                </td>
                <td colspan="2" style="font-style: italic; font-size: 9pt;">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="2" style="font-style: italic; font-size: 9pt;" class="auto-style1">Transportador:
                <asp:Label ID="LblTransportador" runat="server"></asp:Label>
                </td>
                <td colspan="2" style="font-style: italic; font-size: 9pt;">
                
                </td>
            </tr>
            <tr>
                <td colspan="4" style="font-style: italic; font-weight: bold; font-size: 9pt;">
                    <br />
                    <asp:Label ID="LblCabecalho" runat="server" Font-Size="9pt"></asp:Label>
                    <br />
                </td>
            </tr>
            <tr>
                <td colspan="4">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="4"
                    style="padding: 5px; border-style: none; border-width: 0px; font-weight: bold; font-size: 14pt; font-style: italic;">Descrição dos Materiais</td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:GridView ID="GridView1" runat="server" CellPadding="4"
                        DataSourceID="SqlDataSource2" ForeColor="Black" GridLines="Horizontal"
                        Width="100%" AutoGenerateColumns="False" BackColor="White"
                        BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" Font-Size="8pt">
                        <Columns>
                            <asp:TemplateField HeaderText="Item" SortExpression="seq_item">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("seq_item") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LblSeqItem" runat="server"
                                        Text='<%# Bind("seq_item", "{0:000}") %>'></asp:Label>
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
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("item_ou_narrativa") %>'></asp:Label>
                                    <br />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Justify" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Material disponível em"
                                SortExpression="prazo_entrega">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("prazo_entrega") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("prazo_entrega") %>'></asp:Label>
                                    úteis
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="classificacao_fiscal" HeaderText="NCM"
                                SortExpression="classificacao_fiscal">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="aliquota_ipi" DataFormatString="{0:F2}"
                                HeaderText="% IPI" SortExpression="aliquota_ipi">
                                <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="aliquota_icms" DataFormatString="{0:F2}"
                                HeaderText="% ICMS" SortExpression="aliquota_icms">
                                <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Quantidade/UN" SortExpression="qtd_ud">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("qtd_ud") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("qtd_ud", "{0:F2}") %>'></asp:Label>
                                    &nbsp;<asp:Label ID="Label7" runat="server" Text='<%# Eval("un") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="preco_unitario" DataFormatString="{0:F2}"
                                HeaderText="Valor Unitário (R$)" SortExpression="preco_unitario">
                                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="desconto" DataFormatString="{0:F2}"
                                HeaderText="Valor Desc (R$)" SortExpression="desconto">
                                <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Valor Total (R$)"
                                SortExpression="valor_mercadoria">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox2" runat="server"
                                        Text='<%# Bind("total_mercadoria") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LblValorMercadoria" runat="server"
                                        Text='<%# Bind("valor_mercadoria", "{0:F2}") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Valor IPI" SortExpression="valor_ipi"
                                Visible="False">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("valor_ipi") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LblValorIPI" runat="server" Text='<%# Bind("valor_ipi") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Valor ICMS ST" SortExpression="valor_icms_st"
                                Visible="False">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("valor_icms_st") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LblICMSST" runat="server" Text='<%# Bind("valor_icms_st") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                        <RowStyle VerticalAlign="Top" Font-Italic="True" />
                        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle Font-Bold="False" ForeColor="Black"
                            BorderStyle="None" Font-Italic="True" />
                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                        <SortedDescendingHeaderStyle BackColor="#242121" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td colspan="4" style="text-align: right; font-weight: bold">
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server"
                        ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>"
                        SelectCommand="call sp_imp_negociacao(:empresa, :estabelecimento, '1', null, :negociacao)">
                        <SelectParameters>
                            <asp:QueryStringParameter Name=":empresa" QueryStringField="eid" />
                            <asp:SessionParameter Name=":estabelecimento" SessionField="SEstabelecimentoNegociacao" />
                            <asp:QueryStringParameter Name=":negociacao" QueryStringField="nid" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td colspan="4" style="font-style: italic; font-weight: bold; font-size: 9pt; text-align:right; padding-right: 20px;">
                    <br />
                    <asp:Label ID="Label4" runat="server" Text="Total dos Materiais:&nbsp;" ></asp:Label>
                    <asp:Label ID="LblTotalMateriais" runat="server" Font-Bold="True"
                        Font-Size="9pt" Text="0,00"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="4"
                    style="padding: 5px; border-style: none; border-width: 0px; font-weight: bold; font-size: 14pt; font-style: italic;">Descrição das Despesas</td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:GridView ID="GridView2" runat="server" CellPadding="4"
                        DataSourceID="SqlDataSourceDespesas" ForeColor="Black" GridLines="Horizontal"
                        Width="100%" AutoGenerateColumns="False" BackColor="White"
                        BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" Font-Size="8pt">
                        <Columns>
                           
                            <asp:TemplateField HeaderText="Descrição" SortExpression="descricao">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("descricao") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LblDescricaoDespesa" runat="server" Text='<%# Bind("descricao") %>'></asp:Label>
                                    <br />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Justify" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Valor (R$)"
                                SortExpression="valor">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox2" runat="server"
                                        Text='<%# Bind("valor") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LblValorDespesa" runat="server"
                                        Text='<%# Bind("valor", "{0:F2}") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                        <RowStyle VerticalAlign="Top" Font-Italic="True" />
                        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle Font-Bold="False" ForeColor="Black"
                            BorderStyle="None" Font-Italic="True" />
                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                        <SortedDescendingHeaderStyle BackColor="#242121" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td colspan="4" style="text-align: right; font-weight: bold">
                    <asp:SqlDataSource ID="SqlDataSourceDespesas" runat="server"
                        ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>"
                        SelectCommand="select t.cod_tipo_desp_acess, t.descricao, n.valor
  from negociacao_cliente_despesas n inner join tipo_despesa_acessoria t on t.empresa = n.empresa and n.cod_tipo_desp_acess = t.cod_tipo_desp_acess
 where n.cod_negociacao_cliente = :negociacaoid
   and n.empresa = :empresaid
   and n.estabelecimento = :estabelecimentoid
order by t.descricao">
                        <SelectParameters>
                            <asp:QueryStringParameter Name=":negociacaoid" QueryStringField="nid" />
                            <asp:QueryStringParameter Name=":empresaid" QueryStringField="eid" />
                            <asp:SessionParameter Name=":estabelecimentoid" SessionField="SEstabelecimentoNegociacao" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td colspan="4" style="font-style: italic; font-weight: bold; font-size: 9pt; text-align: right; padding-right: 20px;">
                    <br />
                    <asp:Label ID="Label2" runat="server" Text="Total das Despesas:&nbsp;" Style="text-align: right;"></asp:Label>
                    <asp:Label ID="LblTotalDespesas" runat="server" Font-Bold="True"
                        Font-Size="9pt" Text="0,00"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="4" style="font-style: italic; font-weight: bold; font-size: 12pt; text-align: right; padding-right: 20px;">
                    <br />
                    <asp:Label ID="Label5" runat="server" Text="Valor Total da Proposta:&nbsp;" Style="text-align: right"></asp:Label>
                    <asp:Label ID="LblTotal" runat="server" Font-Bold="True"
                        Font-Size="9pt" Text="0,00"></asp:Label>
                </td>
            </tr>
             <tr>
                <td colspan="4"
                    style="padding: 5px; border-style: none; border-width: 0px; font-weight: bold; font-size: 14pt; font-style: italic;">Descrição dos Títulos</td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:GridView ID="GridView3" runat="server" CellPadding="4"
                        DataSourceID="SqlDataSourceTitulos" ForeColor="Black" GridLines="Horizontal"
                        Width="100%" AutoGenerateColumns="False" BackColor="White"
                        BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" Font-Size="8pt">
                        <Columns>
                            <asp:TemplateField HeaderText="Parcela" SortExpression="seq_item">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("parcela") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LblSeqItem" runat="server"
                                        Text='<%# Bind("parcela", "{0:00}") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Prazo/Dias" SortExpression="cod_item">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("prazo_dias") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LblCodItem" runat="server" Text='<%# Bind("prazo_dias") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Percentual" SortExpression="descricao">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("percentual") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("percentual") %>'></asp:Label>
                                    <br />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Justify" />
                            </asp:TemplateField>                                                
                          
                            <asp:BoundField DataField="valor_parcela" DataFormatString="{0:F2}"
                                HeaderText="Valor da parcela (R$)" SortExpression="valor_parcela">
                                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>                          
                         
                        </Columns>
                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                        <RowStyle VerticalAlign="Top" Font-Italic="True" />
                        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle Font-Bold="False" ForeColor="Black"
                            BorderStyle="None" Font-Italic="True" />
                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                        <SortedDescendingHeaderStyle BackColor="#242121" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td colspan="4" style="text-align: right; font-weight: bold">
                    <asp:SqlDataSource ID="SqlDataSourceTitulos" runat="server"
                        ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>"
                        SelectCommand="call sp_imp_negociacao_titulos(:empresa, :estabelecimento, '1', null, :negociacao)">
                        <SelectParameters>
                            <asp:QueryStringParameter Name=":empresa" QueryStringField="eid" />
                            <asp:SessionParameter Name=":estabelecimento" SessionField="SEstabelecimentoNegociacao" />
                            <asp:QueryStringParameter Name=":negociacao" QueryStringField="nid" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td colspan="4"
                    style="padding: 5px; border-style: none; border-width: 0px; font-weight: bold; font-size: 14pt; font-style: italic;">Detalhes da Proposta</td>
            </tr>
            <tr>
                <td colspan="4">
                    <table width="100%">
                        <tr>
                            <td style="font-style: italic; font-weight: bold; font-size: 9pt; text-align: right; vertical-align: top;" class="auto-style2">
                                <asp:Label ID="LblTxtFormulacoes" Text="Formulações:&nbsp;" runat="server"></asp:Label></td>
                </td>
                <td style="font-style: italic; font-weight:normal; font-size: 9pt;">
                    <asp:Label ID="LblDetalhesFormulacoes" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td style="font-style: italic; font-weight: bold; font-size: 9pt; text-align: right; vertical-align: top;" class="auto-style2">
                    <asp:Label ID="LblTxtEmbalagens" Text="Embalagens:&nbsp;" runat="server"></asp:Label></td>
                </td>
                            <td style="font-style: italic; font-weight: normal; font-size: 9pt;">
                                <asp:Label ID="LblDetalhesEmbalagem" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td style="font-style: italic; font-weight: bold; font-size: 9pt; text-align: right; vertical-align: top;" class="auto-style2">
                    <asp:Label ID="LblTxtRotulos" Text="Rótulos:&nbsp;" runat="server"></asp:Label>
                </td>
                <td style="font-style: italic; font-weight: normal; font-size: 9pt;">
                    <asp:Label ID="LblDetalhesRotulos" runat="server"></asp:Label></td>
            </tr>
               <tr>
                <td style="font-style: italic; font-weight: bold; font-size: 9pt; text-align: right; vertical-align: top;" class="auto-style2">
                    <asp:Label ID="LblTxtFrete" Text="Frete:&nbsp;" runat="server"></asp:Label>
                </td>
                <td style="font-style: italic; font-weight: normal; font-size: 9pt;">
                    <asp:Label ID="lblFrete" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td style="font-style: italic; font-weight: bold; font-size: 9pt; text-align: right; vertical-align: top;" >
                    <asp:Label ID="LblTxtPrazoEntrega" Text="Prazo de Entrega:&nbsp;" runat="server"></asp:Label>
                </td>
                <td style="font-style: italic; font-weight: normal; font-size: 9pt;">
                    <asp:Label ID="LblDetalhesPrazoEntrega" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td style="font-style: italic; font-weight: bold; font-size: 9pt; text-align: right; vertical-align: top;" >
                    <asp:Label ID="LblTxtDetalhesPagamento" Text="Detalhes do Pagamento:&nbsp;" runat="server">   </asp:Label>
                </td>
                <td style="font-style: italic; font-weight: normal; font-size: 9pt;">
                    <asp:Label ID="LblDetalhesPagamento" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td style="font-style: italic; font-weight: bold; font-size: 9pt; text-align: right; vertical-align: top;" class="auto-style2">Forma de Pagamento:&nbsp;               
                </td>
                <td style="font-style: italic; font-weight: normal; font-size: 9pt;">
                    <asp:Label ID="LblFormaPagamento" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td style="font-style: italic; font-weight: bold; font-size: 9pt; text-align: right;" class="auto-style2">Condição de Pagamento:&nbsp;
                
                </td>
                <td style="font-style: italic; font-weight: normal; font-size: 9pt;">
                    <asp:Label ID="LblCondicaoPagamento" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td  style="font-size: 9pt; font-weight: bold; font-style: italic;text-align: right" class="auto-style2">
                     IPI:&nbsp;
                </td>
                <td style="font-style: italic; font-weight: normal; font-size: 9pt;">                   
                    <asp:Label ID="LblTotalIPI" runat="server" Font-Bold="True"
                        Font-Size="9pt" Text="0,00"></asp:Label>
                </td>
            </tr>
            <tr>
                <td  style="font-size: 9pt; font-weight: bold; font-style: italic;text-align: right;" class="auto-style2">ICMS Substituição:&nbsp;</td>
                <td  style="font-style: italic; font-weight: normal; font-size: 9pt;">                   
                    <asp:Label ID="LblTotalST" runat="server" Font-Bold="True"
                        Font-Size="9pt" Text="0,00"></asp:Label>
                </td>
            </tr>
        </table>
        </td>
            </tr>


           
          
            <tr>
                <td colspan="4"
                    style="text-align: justify; font-size: 9pt; font-weight: bold; font-style: italic;">
                    <br />                    
                    <asp:Label ID="lblTxtObervacao" Text="Observações:" runat="server"></asp:Label>
                    <asp:Label ID="LblObservacao" runat="server"></asp:Label>
                </td>
            </tr>
        <tr>
            <td colspan="4">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Label ID="LblRodape" runat="server" Style="text-align: justify"
                    Width="100%" Font-Bold="True" Font-Italic="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="4">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="4" style="font-style: italic; font-weight: bold;">Favor conferir os produtos solicitados, pelos mesmos aqui relacionados.<br />
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td colspan="4" style="text-align: center">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="4" style="text-align: center">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="4" style="text-align: center">
                <asp:Label ID="Label3" runat="server"
                    Text="____________________________________________"></asp:Label>
                <br />
                <asp:Label ID="LblNomeAgenteVendas" runat="server" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        </table>
    </form>
</body>
</html>
