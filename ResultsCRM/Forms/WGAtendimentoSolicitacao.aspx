<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGAtendimentoSolicitacao.aspx.vb" Inherits="ResultsCRM.WGAtendimentoSolicitacao" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="TextoCadastro_BGBranco" style="width:100%;">
            <tr>
                <td style="text-align: left">
                    <asp:Label ID="LblErro" runat="server" CssClass="Erro"></asp:Label>
    
                </td>
                <td style="text-align: right; ">
                    <asp:Label ID="Label1" runat="server" Height="17px" Text="Nº SD:&nbsp;"></asp:Label>
                    <asp:TextBox ID="TxtCodSolicitacao" runat="server" CssClass="CampoCadastro" 
                        MaxLength="8" Width="55px"></asp:TextBox>
                    &nbsp;<asp:Button ID="BtnVincular" runat="server" Text="Vincular" />
                </td>
            </tr>
        </table>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" CssClass="TextoCadastro" 
            DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" 
            Width="100%" AllowSorting="True" 
            EmptyDataText="Nenhum chamado vinculado.">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" 
                VerticalAlign="Top" />
            <Columns>
                <asp:BoundField DataField="cod_solicitacao" HeaderText="SD" 
                    SortExpression="cod_solicitacao" >
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="assunto" HeaderText="Assunto" 
                    SortExpression="assunto">
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="nome_usuario" HeaderText="Analista" 
                    SortExpression="nome_usuario">
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="data_solicitacao" 
                    DataFormatString="{0:dd/MM/yyyy HH:mm}" HeaderText="Abertura" 
                    SortExpression="data_solicitacao">
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="previsao_entrega" 
                    DataFormatString="{0:dd/MM/yyyy HH:mm}" HeaderText="Previsão Entrega" 
                    SortExpression="previsao_entrega">
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Desvincular">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" 
                            CommandArgument='<%# Eval("cod_solicitacao") %>' CommandName="EXCLUIR" 
                            ImageUrl="~/Imagens/BtnExcluir.png" 
                            onclientclick="return confirm('Deseja realmente excluir o registro?')" 
                            ToolTip="Excluir Registro" />
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                HorizontalAlign="Left" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
            SelectCommand="select c.cod_solicitacao, c.assunto, ana.nome_usuario, c.data_solicitacao, c.previsao_entrega
  from chamado_solicitacao_desenvolvimento cd inner join solicitacao_desenvolvimento c on cd.empresa         = c.empresa
                                                                                      and cd.cod_solicitacao = c.cod_solicitacao
                                              inner join sysusuario ana on ana.cod_usuario = c.cod_analista
 where cd.empresa = :empresa
   and cd.cod_chamado = :solic">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="" Name=":empresa" 
                    SessionField="GlEmpresa" />
                <asp:SessionParameter Name=":solic" 
                    SessionField="SCodAtendimento" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
