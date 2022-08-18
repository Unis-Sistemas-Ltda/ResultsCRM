<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFImpressaoOSAtiva.aspx.vb" Inherits="ResultsCRM.WFImpressaoOSAtiva" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Ordem de Serviço</title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
</head>
<body style="width: 100%; margin: 1px;">
    <form id="form1" runat="server" style="border-spacing: 0px">
      
        <table style="width:750px; color: #000000; font-size: 10pt; font-family: Arial, Helvetica, sans-serif;" 
            class="TextoCadastro_BGBranco">
            <tr>
                <td rowspan="3" 
                    style="text-align: center; border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #CCCCCC;">
                    <asp:Image ID="Image1" runat="server" Height="140px" 
                        ImageUrl="~/Imagens/logo_cliente_os.jpg" />
                </td>
                <td colspan="2" rowspan="3" 
                    style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #CCCCCC">
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
                <td style="text-align: right" colspan="2">
                    OS Nº
                    <asp:Label ID="LblCodOS" runat="server" Font-Bold="True"></asp:Label>
                    &nbsp;&nbsp;</td>
            </tr>
            <tr>
                <td style="border: 1px solid #CCCCCC; font-size: 9pt; text-align: center">
                    Chamado<br />
                    <asp:Label ID="LblCodChamado" runat="server" Font-Bold="True" Font-Size="10pt"></asp:Label>
                </td>
                <td style="border: 1px solid #CCCCCC; font-size: 9pt; text-align: center">
                    Chamado Cliente<br />
                    <asp:Label ID="LblCodOSCliente" runat="server" Font-Bold="True" 
                        Font-Size="10pt"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="border: 1px solid #CCCCCC; font-size: 9pt; text-align: center" 
                    colspan="2">
                    Data do Agendamento<br />
                    <asp:Label ID="LblDataAgendamento" runat="server" Font-Bold="True" 
                        Font-Size="10pt"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="text-align: center; font-weight: bold; font-size: 11pt">
                    ORDEM DE SERVIÇO</td>
                <td style="border-width: 1px; border-color: #CCCCCC; text-align: left; font-size: 10pt; border-left-style: solid; border-top-style: solid; vertical-align: top; border-right-style: solid;" 
                    colspan="2">
                    Solicitante:<asp:Label ID="LblSolicitante" runat="server" Font-Size="9pt"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="text-align: left; font-size: 10pt" rowspan="5">
                    Cliente(CNPJ):                     <asp:Label ID="LblNomeCliente" runat="server"></asp:Label>
                    &nbsp;(<asp:Label ID="LblCNPJCliente" runat="server"></asp:Label>
                    )<br />
                    Banco/Empresa:
                    <asp:Label ID="LblBancoEmpresa" runat="server"></asp:Label>
                    <br />
                    Ponto de Atend.:
                    <asp:Label ID="LblPontoDeAtendimento" runat="server"></asp:Label>
                    <br />
                    CNPJ/Insc.Est.:
                    <asp:Label ID="LblCNPJ" runat="server"></asp:Label>
                &nbsp;/
                    <asp:Label ID="LblInscEst" runat="server"></asp:Label>
                    <br />
                    Endereço:
                    <asp:Label ID="LblEnderecoCliente" runat="server"></asp:Label>
                &nbsp;<asp:Label ID="LblBairroCliente" runat="server"></asp:Label>
                    <br />
                    Município:
                    <asp:Label ID="LblCidade" runat="server"></asp:Label>
&nbsp;/
                    <asp:Label ID="LblUF" runat="server"></asp:Label>
                &nbsp;- CEP:<asp:Label ID="LblCEP" runat="server"></asp:Label>
                    <br />
                    Telefone:<asp:Label ID="LblTelefone" runat="server"></asp:Label>
                </td>
                <td style="border-width: 1px; border-color: #CCCCCC; text-align: left; font-size: 10pt; border-left-style: solid; vertical-align: bottom; height: 24px; border-right-style: solid; width: 250px;" 
                    colspan="2">
                    Data&nbsp;Atendim..:____/____/_____</td>
            </tr>
            <tr>
                <td style="border-width: 1px; border-color: #CCCCCC; text-align: left; border-left-style: solid; vertical-align: bottom; font-size: 10pt; height: 24px; border-right-style: solid;" 
                    colspan="2">
                    Hora&nbsp;Chegada.:___:___</td>
            </tr>
            <tr>
                <td style="border-width: 1px; border-color: #CCCCCC; text-align: left; border-left-style: solid; vertical-align: bottom; font-size: 10pt; height: 24px; border-right-style: solid;" 
                    colspan="2">
                    Hora&nbsp;Início.......:___:___</td>
            </tr>
            <tr>
                <td style="border-width: 1px; border-color: #CCCCCC; text-align: left; border-left-style: solid; vertical-align: bottom; font-size: 10pt; height: 24px; border-right-style: solid;" 
                    colspan="2">
                    Hora&nbsp;Término...:___:___</td>
            </tr>
            <tr>
                <td style="border-width: 1px; border-color: #CCCCCC; text-align: left; border-left-style: solid; border-bottom-style: solid; font-size: 10pt; border-right-style: solid;" 
                    colspan="2">
                    Técnico:<asp:Label ID="LblTecnico" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="5" 
                    style="border-width: 1px; border-color: #999999; border-top-style: solid;">
                    EQUIPAMENTOS DA OS</tr>
            <tr>
                <td colspan="5">
                    <asp:GridView ID="GridView1" runat="server" 
                        CssClass="TextoCadastro_BGBranco" 
                        ForeColor="Black" Width="100%" AutoGenerateColumns="False"
                        Font-Size="10pt" Font-Names="Arial">
                        <RowStyle Height="28px" BorderColor="#CCCCCC" BorderStyle="Solid" 
                            BorderWidth="1px" />
                        <Columns>
                            <asp:BoundField DataField="seq_solicitacao" HeaderText="Seq." 
                                SortExpression="seq_solicitacao" DataFormatString="{0:F0}">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" Width="60px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="numero_serie" HeaderText="Cód." 
                                SortExpression="numero_serie">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" Width="60px" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Equipamento / Serviço Solicitado" 
                                SortExpression="descricao">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("desc_equipamento") %>'></asp:Label>
                                    :&nbsp;<asp:Label ID="Label4" runat="server" Text='<%# Bind("componentes") %>'></asp:Label>
                                    &nbsp;-
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("servico_solicitado") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("descricao") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="nr_patrimonio" HeaderText="Nº Patrimônio" 
                                SortExpression="nr_patrimonio" />
                            <asp:BoundField DataField="numero_serie_terceiro" HeaderText="Nº Série" 
                                SortExpression="numero_serie_terceiro" />
                        </Columns>
                        <HeaderStyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" 
                            Font-Underline="True" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td colspan="5">
                    Observações:
                    <asp:Label ID="LblObsEquipamento" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="LblNomeCliente0" runat="server" Width="470px">Lacres</asp:Label>
                    <br />
                    CPU:___________ Tranca:___________ Painel:___________ Pack:__________ 
                    Patrimônio:__________ Lacre Ativa:__________</td>
            </tr>
            <tr>
                <td colspan="5" style="line-height: 2px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="5" 
                    style="border-width: 1px; border-color: #999999; border-top-style: solid;">
                    SERVIÇOS REALIZADOS</td>
            </tr>
            <tr>
                <td colspan="5">
                    <asp:GridView ID="GridView2" runat="server" 
                        CssClass="TextoCadastro_BGBranco" 
                        ForeColor="Black" Width="100%" AutoGenerateColumns="False" 
                        BorderColor="#CCCCCC" 
                        DataKeyNames="cod_item" Font-Size="10pt" Font-Names="Arial">
                        <RowStyle VerticalAlign="Top" 
                            Height="35px" BorderColor="#CCCCCC" BorderStyle="Solid" 
                            BorderWidth="1px" />
                        <Columns>
                            <asp:BoundField DataField="seq_solicitacao" HeaderText="Seq." 
                                SortExpression="seq_solicitacao">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" Width="50px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="cod_item" HeaderText="Cód." ReadOnly="True" 
                                SortExpression="cod_item">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" Width="60px" />
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
                                <ItemStyle HorizontalAlign="Left" Width="50%" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="qtd_pedida" DataFormatString="{0:F2}" 
                                HeaderText="Qtde." SortExpression="qtd_pedida">
                                <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" Width="75px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="preco_unitario" DataFormatString="R$ {0:F2}" 
                                HeaderText="Valor&nbsp;Unitário" SortExpression="preco_unitario">
                                <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="valor_mercadoria" DataFormatString="R$ {0:F2}" 
                                HeaderText="Valor Total" SortExpression="valor_mercadoria">
                                <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" Width="75px" />
                            </asp:BoundField>
                        </Columns>
                        <HeaderStyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" 
                            Font-Underline="True" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td colspan="5" style="line-height: 21px; vertical-align: bottom;">
                    Observações:_____________________________________________________________________________________________</td>
            </tr>
            <tr>
                <td colspan="5" style="height: 18px; vertical-align: bottom">
                                        &nbsp;
                                        _______________________________________________________________________________________________________</td>
            </tr>
            <tr>
                <td colspan="5" style="height: 18px; vertical-align: bottom">
                                        &nbsp; _______________________________________________________________________________________________________</td>
            </tr>
            <tr>
                <td colspan="5" style="height: 18px; vertical-align: bottom">
                                        &nbsp; 
                                        _______________________________________________________________________________________________________</td>
            </tr>
            <tr>
                <td colspan="5" style="text-align: justify">
                    Declaramos que os serviços especificados foram a contento e que acolheremos o 
                    débito correspondente, para cobrança, tão logo este seja apresentado.</td>
            </tr>
            <tr>
                <td colspan="5" style="line-height: 3px">
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
                    Assinatura do Técnico</td>
                <td colspan="3" style="text-align: center; font-size: 10pt;">
                    Carimbo e assinatura do Responsável</td>
            </tr>
        </table>
    
    </form>
</body>
</html>
