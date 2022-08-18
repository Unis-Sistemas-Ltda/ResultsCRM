<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFImpressaoProposta407.aspx.vb" Inherits="ResultsCRM.WFImpressaoProposta407" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Proposta Comercial</title>
</head>
<body style="margin:0px; padding:0px; border: 0px">
    <form id="form1" runat="server">
    <table style="width:780px; font-family: Verdana; font-size: 8pt;">
        <tr>
            <td colspan="6">
                <div style="width: 30mm; position: relative; top: 0px; left: 0px">
                    <asp:Image ID="ImgLogo" runat="server" AlternateText="Proposta Comercial" 
                        Width="31mm" />
                </div>
                <div style="position: absolute; top: 17px; left: 34mm; width: 450px;">
                <span style="font-size:11pt"><asp:Label ID="LblRazaoSocialEmpresa" runat="server"></asp:Label></span>
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
                    <br />
                    E-mail:
                <asp:Label ID="LblEmailEmpresa" runat="server"></asp:Label></div>
            </td>
            <td style="width: 30%; text-align: center; vertical-align: top; ">
                <span style="font-size:11pt; font-weight: bold;">Orçamento<br />
                </span>
                <span style="font-size: 11pt; font-weight: bold;">
                Nº&nbsp;<asp:Label ID="LblCodNegociacaoCliente" runat="server" Text="0"></asp:Label></span>
                <span style="">
                <br />
                <br />
                Data Envio:&nbsp;<asp:Label ID="LblDataNegociacao" runat="server" Text="00/00/0000" 
                    Font-Bold="True" ></asp:Label>
                <br />
                Status:
                <asp:Label ID="LblStatusNegociacao" runat="server" 
                    Font-Bold="True" ></asp:Label>
                </span>
            </td>
        </tr>
        <tr>
            <td colspan="7" style="text-align: justify">
                <br />
                <asp:Label ID="LblCabecalho" runat="server" ></asp:Label>
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td style=" vertical-align: top; font-weight: bold;">
                Nº Chamado Cliente:</td>
            <td style="vertical-align: top;">
                <asp:Label ID="LblOSCliente" runat="server"></asp:Label>
            </td>
            <td style="vertical-align: top; font-weight: bold;" 
                colspan="3">
                Nº Chamado Ativa:</td>
            <td style="vertical-align: bottom;" colspan="2">
                <asp:Label ID="LblCodChamado" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="">
                &nbsp;</td>
            <td style="font-weight: bold; ;">
                &nbsp;</td>
            <td style="vertical-align: top; font-weight: bold;" 
                colspan="3">
                Nº OS Ativa:</td>
            <td style="vertical-align: top;" colspan="2">
                <asp:Label ID="LblCodOS" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="">
                &nbsp;</td>
            <td style="font-weight: bold; ;">
                &nbsp;</td>
            <td style="" colspan="3">
                &nbsp;</td>
            <td style=";" colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td style=" font-weight: bold;">
                Cliente:</td>
            <td colspan="6">
                <asp:Label ID="LblRazaoSocialTomador" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="font-weight: bold;">
                CNPJ/CPF:
                </td>
            <td style=";">
                <asp:Label ID="LblCNPJTomador" runat="server" Font-Bold="False"></asp:Label>
            </td>
            <td style="font-weight: bold;" colspan="3">
                IE:
                </td>
            <td style=";" colspan="2">
                <asp:Label ID="LblInscricaoEstadualTomador" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="font-weight: bold;">
                Endereço:</td>
            <td style=";" colspan="6">
                <asp:Label ID="LblEnderecoTomador" runat="server"></asp:Label>
                -
                <asp:Label ID="LblCidadeTomador" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="font-weight: bold;">
                Telefone(s):</td>
            <td style=";">
                &nbsp;<asp:Label ID="LblTelefoneTomador" runat="server" Font-Bold="False"></asp:Label>
            </td>
            <td style="" colspan="3">
                &nbsp;</td>
            <td style=";" colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="font-weight: bold;">
                Contato/e-mail:
                </td>
            <td style=";" colspan="6">
                <asp:Label ID="LblContatoTomador" runat="server"></asp:Label>
            &nbsp;/
                <asp:Label ID="LblContatoTomadorEmail" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="1" style=";">
                &nbsp;</td>
            <td style=";">
                &nbsp;</td>
            <td colspan="3" style="font-style: italic; ;">
                &nbsp;</td>
            <td colspan="2" style="font-style: italic; ;">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="1" style="font-weight: bold;">
                Cliente atendimento:</td>
            <td colspan="6" style="text-align: left">
                <asp:Label ID="LblRazaoSocialClienteAtendimento" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="1" style="font-weight: bold;">
                Ponto de atendimento:</td>
            <td colspan="6" style=";">
                <asp:Label ID="LblNumeroPontoAtendimento" runat="server"></asp:Label>
                -
                <asp:Label ID="LblNomePontoAtendimento" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="1" style="font-weight: bold;">
                Endereço:</td>
            <td colspan="6" style=";">
                <asp:Label ID="LblEnderecoPontoAtendimento" runat="server"></asp:Label>
                -
                <asp:Label ID="LblCidadePontoAtendimento" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="1" style="font-weight: bold;">
                Uniorg:</td>
            <td colspan="2" style=";">
                <asp:Label ID="LblUniorg" runat="server"></asp:Label>
                </td>
            <td colspan="2" style="font-weight: bold;">
                &nbsp;</td>
            <td colspan="2" style=";">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3" style="font-weight: bold;">
                &nbsp;</td>
            <td colspan="4" style=";">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="1" style="font-weight: bold;">
                Responsável acompanhamento:</td>
            <td colspan="6" style=";">
                <asp:Label ID="LblContatoPontoAtendimento" runat="server"></asp:Label>
                </td>
        </tr>
        <tr>
            <td colspan="1" style="font-weight: bold;">
                Nº matrícula responsável:</td>
            <td colspan="6" style="vertical-align: bottom">
                <asp:Label ID="LblMatriculaContatoPontoAtendimento" runat="server"></asp:Label>
                </td>
        </tr>
        <tr>
            <td colspan="3" style="">
                &nbsp;</td>
            <td colspan="4" style=";">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="vertical-align: top; font-weight: bold;">
                Grupo de Problema:</td>
            <td colspan="6" style="vertical-align: bottom;">
                <asp:Label ID="LblGrupoProblema" runat="server"></asp:Label>
                </td>
        </tr>
        <tr>
            <td style="vertical-align: top; font-weight: bold;">
                Problema:</td>
            <td colspan="6" style="vertical-align: bottom;">
                <asp:Label ID="LblProblemas" runat="server"></asp:Label>
                </td>
        </tr>
        <tr>
            <td style="vertical-align: top; font-weight: bold;">
                Necessita intervenção conjunta:</td>
            <td colspan="2" style="vertical-align: bottom;">
                <asp:Label ID="LblNecessariaIntervencaoConjunta" runat="server"></asp:Label>
                </td>
            <td colspan="2" 
                style="vertical-align: bottom; font-weight: bold;">
                Empresa:</td>
            <td colspan="2" style="vertical-align: bottom;">
                <asp:Label ID="LblNecessariaIntervencaoConjuntaEmpresa" runat="server"></asp:Label>
                </td>
        </tr>
        <tr>
            <td style="vertical-align: top; font-weight: bold;">
                Observações:</td>
            <td colspan="6" 
                style="vertical-align: top; text-align: justify;">
                <asp:Label ID="LblObservacao" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="7">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="7" 
                
                
                
                style="font-weight: bold; font-size: 10pt; ">
                Detalhamento dos Serviços</td>
        </tr>
        <tr>
            <td colspan="7">
                <asp:GridView ID="GridView1" runat="server" CellPadding="4" 
                    DataSourceID="SqlDataSource2" ForeColor="Black" GridLines="Horizontal" 
                    Width="100%" AutoGenerateColumns="False" BackColor="White" 
                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                    Font-Names="Verdana" Font-Size="8pt">
                    <Columns>
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
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("item_com_narrativa") %>'></asp:Label>
                                <br />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                            <ItemStyle HorizontalAlign="Justify" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Equipamento" 
                            SortExpression="descricao_equipamento">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox3" runat="server" 
                                    Text='<%# Bind("descricao_equipamento") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" 
                                    Text='<%# Bind("descricao_equipamento") %>'></asp:Label>
                                <br />
                                Pat:
                                <asp:Label ID="Label10" runat="server" Text='<%# Eval("numero_patrimonio") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Quantidade" SortExpression="qtd_ud">
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("qtd_ud", "{0:F2}") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("qtd_ud") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="preco_unitario" DataFormatString="{0:F2}" 
                            HeaderText="Preço Unitário (R$)" SortExpression="preco_unitario">
                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                        <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Subtotal (R$)" 
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
                    </Columns>
                    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                    <RowStyle VerticalAlign="Top" Font-Italic="False" />
                    <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle Font-Bold="False" ForeColor="Black" 
                        BorderStyle="None" Font-Italic="False" />
                    <SortedAscendingCellStyle BackColor="#F7F7F7" />
                    <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                    <SortedDescendingHeaderStyle BackColor="#242121" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="4" style="font-weight: bold; font-style: italic;">
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
                    SelectCommand="call sp_imp_negociacao(:empresa, :estabelecimento, '1', null, :negociacao)">
                    <SelectParameters>
                        <asp:QueryStringParameter Name=":empresa" QueryStringField="eid" />
                        <asp:QueryStringParameter Name=":estabelecimento" QueryStringField="sid" />
                        <asp:QueryStringParameter Name=":negociacao" QueryStringField="nid" />
                    </SelectParameters>
               </asp:SqlDataSource>
            </td>
            <td colspan="3" 
                style="font-weight: bold; text-align: right; vertical-align: top;">
                <asp:Label ID="Label9" runat="server" Text="Valor Total do Orçamento:" 
                    style="text-align: right"></asp:Label>
                &nbsp;&nbsp;<asp:Label ID="LblTotal" runat="server" Font-Bold="True" 
                     Text="0,00"></asp:Label>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="7" 
                
                
                style="text-align: justify; ; font-weight: bold; font-style: italic;">
                <br />
            </td>
        </tr>
        <tr>
            <td colspan="7">
                <asp:Label ID="LblRodape" runat="server" style="text-align: justify" 
                    Width="100%" Font-Bold="False" Font-Italic="False"></asp:Label>
                <br />
            </td>
        </tr>
        <tr>
            <td colspan="7" style="font-style: italic; font-weight: bold;">
                <br />
            </td>
        </tr>
        <tr>
            <td colspan="7" style="text-align: center">
                <asp:Label ID="Label3" runat="server" 
                    Text="____________________________________________"></asp:Label>
                <br />
                <asp:Label ID="LblNomeAgenteVendas" runat="server" Font-Bold="False"></asp:Label>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>