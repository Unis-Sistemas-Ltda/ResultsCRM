<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFAlterarNumeroPontoAtendimento.aspx.vb" Inherits="ResultsCRM.WFAlterarNumeroPontoAtendimento" %>

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
                <td class="TituloMovimento" colspan="2">
                    Migrar Ponto de Atendimento</td>
            </tr>
            <tr>
                <td class="Erro" colspan="2">
                    <asp:Label ID="LblErro" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="Erro" colspan="2" style="text-align: center">
                    <asp:Label ID="LblOK" runat="server" Font-Bold="True" ForeColor="#009933"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: right;">
                    &nbsp;</td>
                <td>
                    Para 
                    migrar ponto de atendimento, preencha os campos abaixo com 
                    atenção.<br />
                    Obs: somente é possível migrar o ponto de atendimento se o novo número de ponto 
                    de atendimento informado não estiver cadastrado.</td>
            </tr>
            <tr>
                <td style="text-align: right;">
                    Cód. Cliente:</td>
                <td>
                    <asp:TextBox ID="TxtCodCliente" runat="server" CssClass="CampoCadastro" 
                        Width="115px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    Número do Ponto de Atendimento (original):</td>
                <td>
                    <asp:TextBox ID="TxtNumeroPontoAtendimentoAntigo" runat="server" 
                        CssClass="CampoCadastro" Width="115px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    Número do Ponto de Atendimento (novo):</td>
                <td>
                    <asp:TextBox ID="TxtNumeroPontoAtendimentoNovo" runat="server" 
                        CssClass="CampoCadastro" Width="115px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    Confirme o Número do Ponto de Atendimento (novo):</td>
                <td>
                    <asp:TextBox ID="TxtNumeroPontoAtendimentoNovoConfirmacao" runat="server" 
                        CssClass="CampoCadastro" Width="115px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    Usuário:</td>
                <td>
                    <asp:TextBox ID="TxtUsuario" runat="server" CssClass="CampoCadastro" 
                        Width="115px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    Senha:</td>
                <td>
                    <asp:TextBox ID="TxtSenha" runat="server" CssClass="CampoCadastro" 
                        TextMode="Password" Width="115px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: right" width="300px">
                    &nbsp;</td>
                <td>
                    <asp:Button ID="Button1" runat="server" 
                        onclientclick="return confirm('ATENÇÃO: OPERAÇÃO IRREVERSÍVEL. Deseja realmente alterar o número do ponto de atendimento, transferindo o histórico do ponto?')" 
                        Text="Gravar" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    Histórico</td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                        AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" 
                        BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                        DataSourceID="SqlDataSource1" 
                        EmptyDataText="Nenhum registro efetuado até o momento." ForeColor="Black" 
                        GridLines="Horizontal" PageSize="8" Width="100%">
                        <Columns>
                            <asp:BoundField DataField="seq" HeaderText="Seq." ReadOnly="True" 
                                SortExpression="seq">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="cod_emitente" HeaderText="Código Cliente" 
                                SortExpression="cod_emitente">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="numero_ponto_atendimento" 
                                HeaderText="Ponto Atendimento (Original)" 
                                SortExpression="numero_ponto_atendimento">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="numero_ponto_atendimento_novo" 
                                HeaderText="Ponto Atendimento (Novo)" 
                                SortExpression="numero_ponto_atendimento_novo">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="cod_usuario" HeaderText="Cód. Usuario" 
                                ReadOnly="True" SortExpression="cod_usuario">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="nome_usuario" HeaderText="Nome Usuário" 
                                SortExpression="nome_usuario">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="data_hora" HeaderText="Data" 
                                SortExpression="data_hora">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                        </Columns>
                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                        <SortedDescendingHeaderStyle BackColor="#242121" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select l.seq, l.cod_emitente, l.numero_ponto_atendimento, l.numero_ponto_atendimento_novo, l.cod_usuario, u.nome_usuario, l.data_hora
   from ponto_atendimento_log l left outer join sysusuario u on l.cod_usuario = u.cod_usuario
  order by seq desc"></asp:SqlDataSource>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
