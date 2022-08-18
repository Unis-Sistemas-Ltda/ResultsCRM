<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFImpressaoOSElfaro.aspx.vb" Inherits="ResultsCRM.WFImpressaoOSElfaro" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Ordem de Serviço</title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
</head>
<body style="width: 100%; margin: 1px;">
    <form id="form1" runat="server" style="border-spacing: 0px">
      
        <table style="width:750px; color: #000000; font-size: 10pt; font-family: Calibri;" 
            class="TextoCadastro_BGBranco">
            <tr>
                <td rowspan="3" 
                    style="text-align: center; " valign="top">
                    <asp:Image ID="Image1" runat="server" Height="140px" 
                        ImageUrl="~/Imagens/logo_cliente_os.jpg" />
                </td>
                <td colspan="2" rowspan="3" valign="top">
                    <asp:Label ID="LblRazaoSocialEmpresa" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="LblEnderecoEmpresa" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="LblBairroEmpresa" runat="server"></asp:Label>
                    -
                    <asp:Label ID="LblMunicipioEmpresa" runat="server"></asp:Label>
                    /
                    <asp:Label ID="LblUFEmpresa" runat="server"></asp:Label>
                    <br />
                    Telefone/Fax:<asp:Label ID="LblTelefoneEmpresa1" runat="server"></asp:Label>
&nbsp;/
                    <asp:Label ID="LblTelefoneEmpresa2" runat="server"></asp:Label>
                    <br />
                    CNPJ:<asp:Label ID="LblCNPJEmpresa" runat="server"></asp:Label>
                    <br />
                    Insc. Est.:<asp:Label ID="LblInscEstEmpresa" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="LblErro" runat="server" CssClass="Erro"></asp:Label>
                </td>
                <td style="border: 1px solid #CCCCCC; font-size: 8pt; text-align: center">
                    Chamado<br />
                    <asp:Label ID="LblCodChamado" runat="server" Font-Bold="True" Font-Size="10pt" 
                        Width="90px"></asp:Label>
                </td>
                <td style="border: 1px solid #CCCCCC; font-size: 8pt; text-align: center">
                    Chamado Cliente<br />
                    <asp:Label ID="LblCodOSCliente" runat="server" Font-Bold="True" 
                        Font-Size="10pt" Width="90px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="border: 1px solid #CCCCCC; font-size: 8pt; text-align: center" 
                    colspan="2">
                    Abertura<br />
                    <asp:Label ID="LblDataAbertura" runat="server" Font-Bold="True" 
                        Font-Size="10pt"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="border: 1px solid #CCCCCC; font-size: 8pt; text-align: center" 
                    colspan="2">
                    Previsão de Encerramento<br />
                    <asp:Label ID="LblPrevisaoEncerramento" runat="server" Font-Bold="True" 
                        Font-Size="10pt"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="text-align: center; font-weight: bold; font-size: 11pt">
                    ORDEM DE SERVIÇO 
                    Nº
                    <asp:Label ID="LblCodOS" runat="server" Font-Bold="True"></asp:Label>
                    </td>
                <td colspan="2" 
                    style="border: 1px solid #CCCCCC; text-align: center; font-size: 8pt; height: 35px;">
                    Encerramento<br />
                    <asp:Label ID="LblEncerramento" runat="server" Font-Bold="True" 
                        Font-Size="10pt">____/____/_______&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;____:____</asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="5" style="text-align: left; font-size: 10pt">
                    <asp:Label ID="Label5" runat="server" Style="text-align: right" Text="Cliente:" 
                        Width="100px" Font-Bold="True"></asp:Label>
                    <asp:Label ID="LblNomeTomador" runat="server" Width="370px"></asp:Label>
                    <asp:Label ID="Label6" runat="server" Style="text-align: right" 
                        Text="CNPJ/CPF:" Width="65px"></asp:Label>
                    <asp:Label ID="LblCNPJTomador" runat="server" Width="190px"></asp:Label>
                    <br />
                    <asp:Label ID="Label7" runat="server" Style="text-align: right" 
                        Text="Endereço:" Width="100px"></asp:Label>
                    <asp:Label ID="LblEnderecoTomador" runat="server" Width="370px"></asp:Label>
                    <asp:Label ID="Label8" runat="server" Style="text-align: right" Text="Bairro:" 
                        Width="65px"></asp:Label>
                    <asp:Label ID="LblBairroTomador" runat="server" Width="190px"></asp:Label>
                    <br />
                    <asp:Label ID="Label9" runat="server" Style="text-align: right" 
                        Text="Município:" Width="100px"></asp:Label>
                    <asp:Label ID="LblMunicipioTomador" runat="server" Width="370px"></asp:Label>
                    <asp:Label ID="Label10" runat="server" Style="text-align: right" Text="CEP:" 
                        Width="65px"></asp:Label>
                    <asp:Label ID="LblCEPTomador" runat="server" Width="190px"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="Label11" runat="server" Style="text-align: right" 
                        Text="Ponto de Atend.:" Width="100px" Font-Bold="True"></asp:Label>
                    <asp:Label ID="LblNomeClienteAtendimento" runat="server" Width="370px"></asp:Label>
                    <br />
                    <asp:Label ID="Label12" runat="server" Style="text-align: right" 
                        Text="Endereço:" Width="100px"></asp:Label>
                    <asp:Label ID="LblEnderecoAtendimento" runat="server" Width="370px"></asp:Label>
                    <asp:Label ID="Label13" runat="server" Style="text-align: right" Text="Bairro:" 
                        Width="65px"></asp:Label>
                    <asp:Label ID="LblBairroAtendimento" runat="server" Width="190px"></asp:Label>
                    <br />
                    <asp:Label ID="Label14" runat="server" Style="text-align: right" 
                        Text="Município:" Width="100px"></asp:Label>
                    <asp:Label ID="LblMunicipioAtendimento" runat="server" Width="370px"></asp:Label>
                    <asp:Label ID="Label15" runat="server" Style="text-align: right" Text="CEP:" 
                        Width="65px"></asp:Label>
                    <asp:Label ID="LblCEPAtendimento" runat="server" Width="190px"></asp:Label>
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td colspan="5">
                    &nbsp;</tr>
            <tr>
                <td colspan="5">
                    <asp:GridView ID="GridView1" runat="server" 
                        CssClass="TextoCadastro_BGBranco" Width="100%" AutoGenerateColumns="False" CellPadding="3" 
                        DataSourceID="SqlDataSource1">
                        <RowStyle Height="21px" ForeColor="Black" />
                        <Columns>
                            <asp:BoundField DataField="cod_item" HeaderText="Produto" 
                                SortExpression="cod_item">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                            </asp:BoundField>
                            <asp:BoundField DataField="descricao_item" HeaderText="Descrição" 
                                SortExpression="descricao_item">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" />
                            <ItemStyle HorizontalAlign="Justify" VerticalAlign="Top" />
                            </asp:BoundField>
                            <asp:BoundField DataField="descricao_tamanho" HeaderText="Tamanho" 
                                SortExpression="descricao_tamanho" >
                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                            </asp:BoundField>
                            <asp:BoundField DataField="descricao_cor" HeaderText="Cor" 
                                SortExpression="descricao_cor">
                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                            </asp:BoundField>
                            <asp:BoundField DataField="lote" HeaderText="Lote" SortExpression="lote">
                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                            </asp:BoundField>
                        </Columns>
                        <HeaderStyle Font-Underline="True" ForeColor="Black" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select distinct i.cod_item, i.descricao descricao_item, t.descricao descricao_tamanho, c.descricao descricao_cor, e.lote
  from pedido_venda_solicitacao p inner join equipamento e on p.empresa = e.empresa and p.numero_serie = e.numero_serie
                                  inner join item i on i.cod_item = e.cod_item
                                  left outer join referencia r on r.cod_referencia = e.referencia
                                  left outer join cor_item c on c.cod_cor = r.cod_cor
                                  left outer join tamanho_item t on t.cod_tamanho = r.cod_tamanho
 where p.empresa          = :empresa
   and p.estabelecimento  = :estabelecimento
   and p.cod_pedido_venda = :pedido">
                        <SelectParameters>
                            <asp:QueryStringParameter Name="empresa" QueryStringField="eid" />
                            <asp:QueryStringParameter Name="estabelecimento" QueryStringField="sid" />
                            <asp:QueryStringParameter Name="pedido" QueryStringField="pid" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td colspan="5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="5">
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                        CellPadding="3" CssClass="TextoCadastro_BGBranco" 
                        DataSourceID="SqlDataSource2" Width="100%">
                        <Columns>
                            <asp:BoundField DataField="seq_solicitacao" SortExpression="seq_solicitacao">
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="115px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="servico_solicitado" 
                                HeaderText="Problemas / Serviços Solicitados" 
                                SortExpression="servico_solicitado">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" />
                            <ItemStyle HorizontalAlign="Justify" VerticalAlign="Top" />
                            </asp:BoundField>
                        </Columns>
                        <RowStyle Height="21px" ForeColor="Black" />
                        <HeaderStyle Font-Underline="True" ForeColor="Black" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td colspan="5">
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select convert(varchar(4),p.seq_solicitacao) seq_solicitacao, replace(replace(p.servico_solicitado,char(13),''), char(10),'') servico_solicitado
  from pedido_venda_solicitacao p
 where p.empresa          = :empresa
   and p.estabelecimento  = :estabelecimento
   and p.cod_pedido_venda = :pedido">
                        <SelectParameters>
                            <asp:QueryStringParameter Name="empresa" QueryStringField="eid" />
                            <asp:QueryStringParameter Name="estabelecimento" QueryStringField="sid" />
                            <asp:QueryStringParameter Name="pedido" QueryStringField="pid" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td colspan="5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="5" style="font-weight: bold">
                    Avaliação dos Problemas</td>
            </tr>
            <tr>
                <td colspan="5">
                    <asp:Label ID="Label16" runat="server"
                        Text="Responsável:" Width="390px"></asp:Label>
                    <asp:Label ID="Label18" runat="server" Width="160px">Data Início:</asp:Label>
                    <asp:Label ID="Label17" runat="server" Style="text-align: right" Text="Data Fim:" 
                        Width="65px"></asp:Label>
                    <br />
                </td>
            </tr>
            <tr>
                <td colspan="5">
                    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" 
                        CellPadding="3" CssClass="TextoCadastro_BGBranco" 
                        DataSourceID="SqlDataSource3" Width="100%">
                        <Columns>
                            <asp:BoundField DataField="seq_solicitacao" SortExpression="seq_solicitacao">
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="115px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="descricao" 
                                HeaderText="Causas" 
                                SortExpression="descricao">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" />
                            <ItemStyle HorizontalAlign="Justify" VerticalAlign="Top" />
                            </asp:BoundField>
                        </Columns>
                        <RowStyle Height="21px" ForeColor="Black" />
                        <HeaderStyle Font-Underline="True" ForeColor="Black" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td colspan="5">
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select p.seq_solicitacao, c.cod_causa, c.descricao
  from pedido_venda_solicitacao_causa p inner join causa c on p.cod_causa = c.cod_causa
 where p.empresa = :empresa
   and p.estabelecimento = :estabelecimento
   and p.cod_pedido_venda = :cod_pedido_venda
order by p.seq_solicitacao, c.descricao">
                        <SelectParameters>
                            <asp:QueryStringParameter Name="empresa" QueryStringField="eid" />
                            <asp:QueryStringParameter Name="estabelecimento" QueryStringField="sid" />
                            <asp:QueryStringParameter Name="pedido" QueryStringField="pid" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td colspan="5" style="font-weight: bold">
                    Execução</td>
            </tr>
            <tr>
                <td colspan="5">
                    <asp:Label ID="Label19" runat="server"
                        Text="Responsável:" Width="390px"></asp:Label>
                    <asp:Label ID="Label20" runat="server" Width="160px">Data Início:</asp:Label>
                    <asp:Label ID="Label21" runat="server" Style="text-align: right" Text="Data Fim:" 
                        Width="65px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="5">
                    <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" 
                        CellPadding="3" CssClass="TextoCadastro_BGBranco" 
                        DataSourceID="SqlDataSource4" Width="100%">
                        <Columns>
                            <asp:BoundField DataField="seq_item" SortExpression="seq_item">
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="115px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="servico_realizado" 
                                HeaderText="Serviço" 
                                SortExpression="servico_realizado">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" />
                            <ItemStyle HorizontalAlign="Justify" VerticalAlign="Top" Width="330px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="complemento_servico" 
                                HeaderText="Complemento Serviço" SortExpression="complemento_servico">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" />
                            <ItemStyle HorizontalAlign="Justify" VerticalAlign="Top" />
                            </asp:BoundField>
                        </Columns>
                        <RowStyle Height="21px" ForeColor="Black" />
                        <HeaderStyle Font-Underline="True" ForeColor="Black" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td colspan="5">
                    <asp:SqlDataSource ID="SqlDataSource4" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select convert(varchar(4),p.seq_solicitacao) seq_item, replace(replace(i.descricao,char(13),''), char(10),'') servico_realizado, replace(replace(p.narrativa,char(13),''), char(10),'') complemento_servico
  from pedido_venda_item p inner join item i on p.cod_item = i.cod_item
 where p.empresa          = :empresa
   and p.estabelecimento  = :estabelecimento
   and p.cod_pedido_venda = :pedido
order by p.seq_solicitacao, p.seq_item">
                        <SelectParameters>
                            <asp:QueryStringParameter Name="empresa" QueryStringField="eid" />
                            <asp:QueryStringParameter Name="estabelecimento" QueryStringField="sid" />
                            <asp:QueryStringParameter Name="pedido" QueryStringField="pid" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td colspan="5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center">
                    ____________________________________</td>
                <td colspan="3" style="text-align: center">
                    _____________________________________</td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center; font-size: 10pt;">
                    Responsável Avaliação</td>
                <td colspan="3" style="text-align: center; font-size: 10pt;">
                    Responsável Execução</td>
            </tr>
        </table>
    
    </form>
</body>
</html>
