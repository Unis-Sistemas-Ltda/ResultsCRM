<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGSolicitacaoDesenvolvimentoAnexo.aspx.vb" Inherits="ResultsCRM.WGSolicitacaoDesenvolvimentoAnexo" %>

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
                <td style="text-align: right; width: 120px;">
                    <asp:ImageButton ID="BtnNovoRegistro" runat="server" 
                        ImageUrl="~/Imagens/BtnNovoRegistro.png" style="height: 18px" />
                </td>
            </tr>
        </table>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" CssClass="TextoCadastro" 
            DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" 
            Width="100%" AllowSorting="True" 
            EmptyDataText="Nenhum anexo inserido até o momento">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" 
                VerticalAlign="Top" />
            <Columns>
                <asp:BoundField DataField="descricao" HeaderText="Descrição" 
                    SortExpression="descricao" >
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:TemplateField SortExpression="anexo" 
                    HeaderText="Arquivo">
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" runat="server" Target="_blank"
                            NavigateUrl='<%# "~/Arquivos/AnexoSolicitacaoDesenvolvimento/" & Eval("anexo") %>' Text='<%# Eval("anexo") %>'></asp:HyperLink>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" CommandName="ALTERAR" 
                            ImageUrl="~/Imagens/BtnEditar.png" 
                            CommandArgument='<%# Eval("seq_anexo") %>' ToolTip="Alterar registro" />
                        &nbsp;<asp:ImageButton ID="ImageButton2" runat="server" CommandName="EXCLUIR" 
                            ImageUrl="~/Imagens/BtnExcluir.png" 
                            CommandArgument='<%# Eval("seq_anexo") %>' 
                            onclientclick="return confirm('Deseja realmente excluir este anexo?');" 
                            ToolTip="Excluir registro" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="80px" />
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
            SelectCommand="select seq_anexo, anexo, descricao 
  from solicitacao_desenvolvimento_anexo
 where empresa = :empresa
    and cod_solicitacao = :cod_solicitacao">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="" Name=":empresa" 
                    SessionField="GlEmpresa" />
                <asp:SessionParameter Name=":negociacao" 
                    SessionField="SCodSolicitacao" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
