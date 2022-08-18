<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGClienteEquipamento.aspx.vb" Inherits="ResultsCRM.WGClienteEquipamento" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table style="width:100%;">
            <tr>
                <td class="TituloConsulta" colspan="2">
                    Equipamentos do PA</td>
            </tr>
            <tr>
                <td class="Erro">
    
                    <asp:Label ID="LblErro" runat="server"></asp:Label>
    
                </td>
                <td style="text-align: right">
    
        <asp:ImageButton ID="BtnNovoRegistro" runat="server" 
            AlternateText="Novo Registro" ImageUrl="~/Imagens/BtnNovoRegistro.png" 
                        style="height: 18px" />
    
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                        CellPadding="4" CssClass="CampoCadastro" DataSourceID="SqlDataSource1" 
                        
                        EmptyDataText="Nenhum equipamento cadastrado para este Ponto de Atendimento até o momento." 
                        ForeColor="#333333" GridLines="None" Width="100%">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:BoundField DataField="numero_serie" HeaderText="Código" 
                                SortExpression="numero_serie">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="observacao" HeaderText="Descrição" 
                                SortExpression="observacao">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="numero_registro" HeaderText="Patrimônio" 
                                SortExpression="numero_registro">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ativo" HeaderText="Ativo" SortExpression="ativo">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImageButton1" runat="server" 
                                        CommandArgument='<%# Eval("numero_serie") %>' CommandName="ALTERAR" 
                                        ImageUrl="~/Imagens/BtnEditar.png" ToolTip="Clique para alterar o registro." />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="BtnExcluir" runat="server" 
                                        CommandArgument='<%# Eval("numero_serie") %>' CommandName="EXCLUIR" 
                                        ImageUrl="~/Imagens/BtnExcluir.png" 
                                        onclientclick="return confirm('Deseja realmente excluir este equipamento?')" 
                                        ToolTip="Clique para remover o registro." />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                            HorizontalAlign="Left" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand=" select e.empresa,
        e.numero_serie, 
        e.estabelecimento_nfs,
        e.cod_cliente,
        e.cnpj,
        e.numero_ponto_atendimento,
        e.numero_registro,
        e.observacao,
        case isnull(e.ativo,'N') when 'S' then 'SIM' else 'NÃO' end ativo,
        s.razao_social
   from equipamento e left outer join estabelecimento s on e.empresa = s.empresa and e.estabelecimento_nfs = s.estabelecimento
  where e.empresa = :empresa
    and e.cod_cliente = :cod_cliente
    and e.numero_ponto_atendimento = :numero_ponto_atendimento">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="1" Name=":empresa" />
                            <asp:SessionParameter DefaultValue="" Name=":cod_cliente" 
                                SessionField="SCodEmitente" />
                            <asp:SessionParameter Name=":numero_ponto_atendimento" 
                                SessionField="SNumeroPontoAtendimento" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
