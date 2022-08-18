<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFClienteTEF.aspx.vb" Inherits="ResultsCRM.WFClienteTEF" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server"><asp:ScriptManager ID="ScriptManager1" runat="server" />
        <table class="Cadastro" 
        style="width:100%; color: #333333; border-collapse: collapse;">
        <tr>
            <td class="Erro" style="font-size: 8pt">
                <asp:Label ID="LblErro" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="Titulo2">
                Dados do Responsável pela Empresa e Contato Principal</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Razão Social:" 
                    Style="text-align: right" Width="115px"></asp:Label>
                <asp:Label ID="LblNomeFarmacia" runat="server" CssClass="TextoCadastro" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label10" runat="server" Text="Responsável:" 
                    Style="text-align: right" Width="115px" Height="17px"></asp:Label>
                <asp:TextBox ID="TxtNomeResponsavel" runat="server" CssClass="TextoCadastro" 
                    MaxLength="100" Width="225px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label11" runat="server" Text="Data Nascimento:" 
                    Style="text-align: right" Width="115px" Height="17px"></asp:Label>
                <asp:TextBox ID="TxtDataNascimento" runat="server" CssClass="TextoCadastro" 
                    MaxLength="15" Width="95px"></asp:TextBox>
                <cc1:MaskedEditExtender ID="TxtDataNascimento_MaskedEditExtender" 
                    runat="server" BehaviorID="TxtDataNascimento_MaskedEditExtender" Century="2000" 
                    CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                    CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                    CultureName="pt-BR" CultureThousandsPlaceholder="" CultureTimePlaceholder="" 
                    Mask="99/99/9999" MaskType="Date" TargetControlID="TxtDataNascimento" 
                    UserDateFormat="DayMonthYear">
                </cc1:MaskedEditExtender>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label12" runat="server" Text="CPF:" 
                    Style="text-align: right" Width="115px" Height="17px"></asp:Label>
                <asp:TextBox ID="TxtCPF" runat="server" CssClass="TextoCadastro" 
                    MaxLength="14" Width="95px"></asp:TextBox>
                <asp:Label ID="Label13" runat="server" Text="&nbsp;RG:&nbsp;" 
                    Style="text-align: right" Height="17px"></asp:Label>
                <asp:TextBox ID="TxtRG" runat="server" CssClass="TextoCadastro" 
                    MaxLength="15" Width="91px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Pessoa Contato:" 
                    Style="text-align: right" Width="115px" Height="17px"></asp:Label>
                <asp:TextBox ID="TxtNomeContato" runat="server" CssClass="TextoCadastro" 
                    MaxLength="100" Width="225px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Telefone(s):" 
                    Style="text-align: right" Width="115px" Height="17px"></asp:Label>
                <asp:TextBox ID="TxtFone1Contato" runat="server" CssClass="TextoCadastro" 
                    MaxLength="15" Width="95px"></asp:TextBox>
                <asp:Label ID="Label5" runat="server" Text="&nbsp;&nbsp;e&nbsp;&nbsp;" 
                    Style="text-align: right" Height="17px"></asp:Label>
                <asp:TextBox ID="TxtFone2Contato" runat="server" CssClass="TextoCadastro" 
                    MaxLength="15" Width="95px"></asp:TextBox>
                <asp:Label ID="Label6" runat="server" Text=" Ex: (11) 1234-5678" 
                    Height="17px"></asp:Label>
                </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="E-mail de contato:" 
                    Style="text-align: right" Width="115px" Height="17px"></asp:Label>
                <asp:TextBox ID="TxtEmailContato" runat="server" CssClass="TextoCadastro" 
                    MaxLength="100" Width="225px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <br />
                <asp:Button ID="BtnConfirmarDadosContato" runat="server" 
                    Text="Salvar alterações" Width="200px" CssClass="Botao" />
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td class="Titulo2">
                Dados das Lojas/Unidades</td>
        </tr>
        <tr>
            <td width="100%">
                <asp:Button ID="BtnIncluir" runat="server" Text="Incluir Loja/Unidade" 
                    Width="200px" />
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td width="100%">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" 
                    GridLines="None" Width="100%">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:TemplateField HeaderText="CNPJ" SortExpression="cnpj">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("cnpj") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="LblCNPJ" runat="server" Text='<%# Bind("cnpj") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Endereço" SortExpression="endereco">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("endereco") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label7" runat="server" Text='<%# Eval("endereco") %>'></asp:Label>
                                -
                                <asp:Label ID="Label8" runat="server" Text='<%# Eval("cidade_nome") %>'></asp:Label>
                                /
                                <asp:Label ID="Label9" runat="server" Text='<%# Eval("estado_sigla") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Alterar">
                            <ItemTemplate>
                                <asp:HyperLink ID="LnkContratar" runat="server" Font-Underline="True" CssClass='<%# Eval("css_class") %>' 
                                    Text='<%# Eval("texto_link") %>' ImageUrl="~/Imagens/BtnEditar.png"></asp:HyperLink>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td width="100%">
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select e.cnpj,
       e.endereco,
       e.cidade_nome,
       e.estado_sigla
  from v_emitente_endereco e inner join emitente_tef_loja l on e.cod_emitente = l.cod_emitente and e.cnpj = l.cnpj
 where e.ativo        = 'S'
   and e.cod_emitente = :cod_emitente">
                    <SelectParameters>
                        <asp:QueryStringParameter Name=":cod_emitente" QueryStringField="e" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <br />
            </td>
        </tr>
        </table>

    </form>
</body>
</html>
