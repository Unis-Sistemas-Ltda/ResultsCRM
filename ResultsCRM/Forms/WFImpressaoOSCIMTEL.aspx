<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFImpressaoOSCIMTEL.aspx.vb"
    Inherits="ResultsCRM.WFImpressaoOSCIMTEL" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Ordem de Serviço</title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
</head>
<body style="width: 100%; margin: 1px;">
    <form id="form1" runat="server" style="border-spacing: 0px">
    <table style="width: 750px; color: #000000; font-size: 9pt; font-family: Arial, Helvetica, sans-serif;"
        class="TextoCadastro_BGBranco">
        <tr>
            <td style="text-align: center; border-bottom-style: solid; border-bottom-width: 1px;
                border-bottom-color: #CCCCCC;" colspan="6">
                <table style="width: 100%; font-size: 9pt">
                    <tr>
                        <td style="width: 33%">
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagens/logo_cliente_os.jpg" />
                        </td>
                        <td style="text-align: left; vertical-align: top">
                            <asp:Label ID="LblEnderecoEmpresa" runat="server"></asp:Label>
                            <br />
                            <asp:Label ID="LblBairroEmpresa" runat="server"></asp:Label>
                            &nbsp;-
                            <asp:Label ID="LblMunicipioEmpresa" runat="server"></asp:Label>
                            /
                            <asp:Label ID="LblUFEmpresa" runat="server"></asp:Label>
                            <br />
                            <asp:Label ID="LblInformacaoEmpresa" runat="server" Font-Bold="True"></asp:Label>
                            <br />
                            <asp:Label ID="LblSiteEmpresa" runat="server"></asp:Label>
                            /<asp:Label ID="LblEmailEmpresa" runat="server"></asp:Label>
                            Fone:<asp:Label ID="LblTelefoneEmpresa1" runat="server"></asp:Label>
                            &nbsp;- Fax:<asp:Label ID="LblTelefoneEmpresa2" runat="server"></asp:Label>
                            <br />
                            <asp:Label ID="LblErro" runat="server" CssClass="Erro"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="4" style="text-align: center; font-weight: bold; font-size: 11pt; width: 500px;">
                ORDEM DE SERVIÇO
                <asp:Label ID="LblCodOS" runat="server" Font-Bold="True"></asp:Label>
            </td>
            <td style="text-align: right; font-size: 9pt;" colspan="2">
                <asp:Label ID="LblTipoChamado" runat="server" Font-Bold="True" Width="235px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="4" style="text-align: left; font-weight: bold;" rowspan="5">
                Chamado
                <asp:Label ID="LblCodChamado" runat="server" Font-Bold="False" Font-Underline="True"></asp:Label>
                &nbsp;originado em:
                <asp:Label ID="LblDataChamado" runat="server" Font-Bold="False"></asp:Label>
                <br />
                Cliente:
                <asp:Label ID="LblNomeCliente" runat="server" Font-Bold="False"></asp:Label>
                &nbsp;(<asp:Label ID="LblCodCliente" runat="server" Font-Bold="False"></asp:Label>
                )<br />
                Endereço:
                <asp:Label ID="LblEnderecoCliente" runat="server" Font-Bold="False"></asp:Label>
                &nbsp;Bairro:
                <asp:Label ID="LblBairroCliente" runat="server" Font-Bold="False"></asp:Label>
                <br />
                Cidade:
                <asp:Label ID="LblCidade" runat="server" Font-Bold="False"></asp:Label>
                &nbsp;/
                <asp:Label ID="LblUF" runat="server" Font-Bold="False"></asp:Label>
                &nbsp;- CEP:
                <asp:Label ID="LblCEP" runat="server" Font-Bold="False"></asp:Label>
                &nbsp;-
                <asp:Label ID="LblCNPJ_CPF" runat="server" Text="CNPJ:"></asp:Label>
                &nbsp;<asp:Label ID="LblCNPJCliente" runat="server" Font-Bold="False"></asp:Label>
                <br />
                Contato:
                <asp:Label ID="LblContatoNome" runat="server" Font-Bold="False"></asp:Label>
                &nbsp;Fone1:
                <asp:Label ID="LblTelefone1Cliente" runat="server" Font-Bold="False"></asp:Label>
                &nbsp;Fone2:
                <asp:Label ID="LblTelefone2Cliente" runat="server" Font-Bold="False"></asp:Label>
                <br />
                Referência:
                <asp:Label ID="LblReferencia" runat="server" Font-Bold="False"></asp:Label>
            </td>
            <td style="border-width: 1px; border-color: #CCCCCC; text-align: center; border-left-style: solid;
                vertical-align: bottom; border-right-style: solid; border-top-style: solid; font-size: 8pt;"
                colspan="2">
                Registros - Uso interno - administrativo
            </td>
        </tr>
        <tr>
            <td style="font-size: 10pt; border-width: 1px; border-color: #CCCCCC; text-align: center;
                border-left-style: solid; vertical-align: bottom; font-size: 8pt; border-right-style: solid;"
                colspan="2">
                ___/___/______ - _____________
            </td>
        </tr>
        <tr>
            <td style="font-size: 10pt; border-width: 1px; border-color: #CCCCCC; text-align: center;
                border-left-style: solid; vertical-align: bottom; font-size: 8pt; border-right-style: solid;"
                colspan="2">
                ___/___/______ - _____________
            </td>
        </tr>
        <tr>
            <td style="font-size: 10pt; border-width: 1px; border-color: #CCCCCC; text-align: center;
                border-left-style: solid; vertical-align: bottom; font-size: 8pt; border-right-style: solid;"
                colspan="2">
                ___/___/______ - _____________
            </td>
        </tr>
        <tr>
            <td style="font-size: 10pt; border-width: 1px; border-color: #CCCCCC; text-align: center;
                border-left-style: solid; border-bottom-style: solid; font-size: 8pt; border-right-style: solid;"
                colspan="2">
                ___/___/______ - _____________
            </td>
        </tr>
        <tr>
            <td colspan="6" style="border-width: 1px; border-color: #999999; border-top-style: solid;
                font-weight: bold;">
                Assunto:
                <asp:Label ID="LblAssunto" runat="server" Font-Bold="False"></asp:Label>
        </tr>
        <tr>
            <td colspan="6" style="border-width: 1px; border-color: #999999; border-top-style: solid;">
            SERVIÇOS SOLICITADOS</tr>
        <tr>
            <td colspan="6">
                <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" Font-Names="Arial"
                    Font-Size="8pt" ShowHeader="False" Width="100%" BorderColor="#CCCCCC">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <div style="width: calc(100% - 2px); border: 1px solid #CCCCCC; margin-top: 1px; margin-bottom: 1px"><strong>Equipamento: </strong>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("cf_item_descricao") %>'></asp:Label>
                                    /<asp:Label ID="Label5" runat="server" Text='<%# Eval("nr_patrimonio") %>'></asp:Label>
                                    <asp:Label ID="LblNumeroSerieEquipamentoOS" runat="server" Text='<%# Eval("numero_serie") %>'
                                        Visible="False"></asp:Label>
                                </div>
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="0"
                                    CssClass="TextoCadastro_BGBranco" Font-Names="Arial" Font-Size="8pt" ForeColor="Black"
                                    Width="100%">
                                    <RowStyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Height="28px" />
                                    <Columns>
                                        <asp:BoundField DataField="seq_solicitacao" DataFormatString="{0:F0}" HeaderText="Seq."
                                            SortExpression="seq_solicitacao">
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="40px" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Descrição" SortExpression="servico_solicitado">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("servico_solicitado") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("servico_solicitado") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Underline="True" />
                                </asp:GridView>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <RowStyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="6">
                <br />
            </td>
        </tr>
        <tr>
            <td colspan="6" style="border-width: 1px; border-color: #999999; border-top-style: solid;">
                SERVIÇOS REALIZADOS
            </td>
        </tr>
        <tr>
            <td colspan="6" style="border-style: none;">
                Se necessário, utilizar o verso do documento para registro de orçamentos e outros
                detalhes.
            </td>
        </tr>
        <tr>
            <td colspan="6">
                <asp:GridView ID="GridView2" runat="server" CssClass="TextoCadastro_BGBranco" ForeColor="Black"
                    Width="100%" AutoGenerateColumns="False" BorderColor="#CCCCCC" DataKeyNames="cod_item"
                    Font-Size="8pt" Font-Names="Arial" CellPadding="0">
                    <RowStyle VerticalAlign="Top" Height="35px" BorderColor="#CCCCCC" BorderStyle="Solid"
                        BorderWidth="1px" />
                    <Columns>
                        <asp:BoundField DataField="cod_item" HeaderText="Cód." ReadOnly="True" SortExpression="cod_item">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="qtd_pedida" DataFormatString="{0:F2}" HeaderText="Qtde."
                            SortExpression="qtd_pedida">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Right" Width="75px" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Descrição" SortExpression="item_descricao">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("item_descricao") %>'></asp:Label>
                                <br />
                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("narrativa") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("item_descricao") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="V.U." SortExpression="preco_unitario">
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("preco_unitario", "R$ {0:F2}") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("preco_unitario") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Right" Width="100px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Subtotal" SortExpression="valor_mercadoria">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("valor_mercadoria") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="LblValorTotalItem" runat="server" Text='<%# Bind("valor_mercadoria", "R$ {0:F2}") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Right" Width="75px" />
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Underline="True" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td style="text-align: right; font-weight: bold">
                Data da Execução:
            </td>
            <td>
                ____________
            </td>
            <td style="text-align: right; font-weight: bold">
                Garantia:
            </td>
            <td>
                ____________
            </td>
            <td style="text-align: right; font-weight: bold">
                Total de Peças R$:
            </td>
            <td style="text-align: right">
                ____________
            </td>
        </tr>
        <tr>
            <td style="text-align: right; font-weight: bold">
                Hora da Chegada:
            </td>
            <td>
                ____________
            </td>
            <td style="text-align: right; font-weight: bold">
                Hora da Saída:
            </td>
            <td>
                ____________
            </td>
            <td style="text-align: right; font-weight: bold">
                Mão de Obra R$:
            </td>
            <td style="text-align: right">
                ____________
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td style="text-align: right; font-weight: bold">
                TOTAL R$:
            </td>
            <td style="text-align: right">
                ____________
            </td>
        </tr>
        <tr>
            <td colspan="6" style="font-weight: bold; font-size: 8pt;">
                Técnico(s):<asp:Label ID="LblTecnicos" runat="server" Style="border-bottom: 1px solid DarkGray"
                    Width="650px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="4" style="font-weigth: bold; font-size: 8pt;">
                Obs: A garantia cobre apenas os produtos e serviços prestados e listados acima.
            </td>
            <td colspan="2" style="border-width: 1px; border-color: #CCCCCC; border-top-style: solid;
                border-right-style: solid; border-left-style: solid; font-size: 8pt;">
                (&nbsp;&nbsp;&nbsp;&nbsp;) Pagamento em dinheiro
            </td>
        </tr>
        <tr>
            <td colspan="4" rowspan="5" style="vertical-align: top">
                <asp:Label ID="LblObservacao" runat="server" Width="400px"></asp:Label>
            </td>
            <td colspan="2" style="border-width: 1px; border-color: #CCCCCC; border-right-style: solid;
                border-left-style: solid; font-size: 8pt;">
                (&nbsp;&nbsp;&nbsp;&nbsp;) Pagamento em cheque
            </td>
        </tr>
        <tr>
            <td colspan="2" style="border-width: 1px; border-color: #CCCCCC; border-right-style: solid;
                border-left-style: solid; font-size: 8pt;">
                Banco ________ Ag ______ N ______
            </td>
        </tr>
        <tr>
            <td colspan="2" style="border-width: 1px; border-color: #CCCCCC; border-right-style: solid;
                border-left-style: solid; font-size: 8pt;">
                (&nbsp;&nbsp;&nbsp;&nbsp;) Faturar junto com CONTRATO
            </td>
        </tr>
        <tr>
            <td colspan="2" style="border-width: 1px; border-color: #CCCCCC; border-right-style: solid;
                border-left-style: solid; font-size: 8pt;">
                (&nbsp;&nbsp;&nbsp;&nbsp;) Faturar / Boleto - Enviar por e-mail
            </td>
        </tr>
        <tr>
            <td colspan="2" style="border-width: 1px; border-color: #CCCCCC; border-right-style: solid;
                border-left-style: solid; border-bottom-style: solid; font-size: 8pt;">
                Confirmar o e-mail do cliente - LEGÍVEL
            </td>
        </tr>
        <tr>
            <td colspan="6" style="text-align: center">
                <br />
                ________________________________________________&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;________________________________________________
            </td>
        </tr>
        <tr>
            <td colspan="6" style="text-align: center">
                <asp:Label ID="LblEmpresaRazaoSocial" runat="server" Width="315px"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="LblNomeClienteRodape" runat="server"
                    Width="315px" Font-Bold="True"></asp:Label>
                <br />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Nome:________________________________________<br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Declaro
                    ter recebido os serviços acima descritos.</b>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
