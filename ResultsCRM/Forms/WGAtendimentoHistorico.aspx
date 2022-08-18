<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGAtendimentoHistorico.aspx.vb" Inherits="ResultsCRM.WGAtendimentoHistorico" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <br />
    
        <asp:Label ID="LblErro" runat="server" CssClass="Erro" BackColor="#FFFFE8" 
            Width="100%"></asp:Label>
    
        <br />
    
        <asp:Label ID="Label3" runat="server" CssClass="TextoCadastro_BGBranco" 
            Text="Status"></asp:Label>
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" CssClass="TextoCadastro" 
            DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" Width="100%">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Right" />
            <Columns>
                <asp:BoundField DataField="seq_historico" HeaderText="Seq." 
                    SortExpression="seq_historico" DataFormatString="{0:F0}">
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="data_status" DataFormatString="{0:dd/MM/yyyy HH:mm:ss}" 
                    HeaderText="Data/Hora" SortExpression="data_status" >
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Status" SortExpression="cod_status">
                    <EditItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("cod_status") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="LblDescricaoStatus" runat="server" 
                            Text='<%# Eval("descricao") %>'></asp:Label>
                        (<asp:Label ID="LblCodStatus" runat="server" Text='<%# Bind("cod_status") %>'></asp:Label>
                        )
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Usuário" SortExpression="cod_usuario">
                    <EditItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("cod_usuario") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="LblNomeUsuario" runat="server" 
                            Text='<%# Eval("nome_usuario") %>'></asp:Label>
                        (<asp:Label ID="LblCodUsuario" runat="server" Text='<%# Bind("cod_usuario") %>'></asp:Label>
                        )
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                HorizontalAlign="Right" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
            SelectCommand="  SELECT chamado_historico.seq_historico,
         chamado_historico.cod_status,
         chamado_historico.cod_usuario,
         chamado_historico.data_status,
         status_chamado.descricao,
         sysusuario.nome_usuario
    FROM chamado_historico,
         status_chamado,
         sysusuario
   WHERE sysusuario.cod_usuario        = chamado_historico.cod_usuario
     AND status_chamado.cod_status     = chamado_historico.cod_status
     AND chamado_historico.empresa     = :empresa
     AND chamado_historico.cod_chamado = :cod_atendimento
order by chamado_historico.seq_historico">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="" Name=":empresa" 
                    SessionField="GlEmpresa" />
                <asp:SessionParameter Name=":cod_atendimento" 
                    SessionField="SCodAtendimento" />
            </SelectParameters>
        </asp:SqlDataSource>
    
        <asp:Label ID="Label5" runat="server" CssClass="TextoCadastro_BGBranco" 
            Text="&lt;br/&gt;Demais alterações"></asp:Label>
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" CssClass="TextoCadastro" DataSourceID="SqlDataSource2" 
            ForeColor="#333333" GridLines="None" Width="100%">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" />
            <Columns>
                <asp:BoundField DataField="seq" HeaderText="Seq." ReadOnly="True" 
                    SortExpression="seq">
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Usuário" SortExpression="nome_usuario">
                    <EditItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("nome_usuario") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("nome_usuario") %>'></asp:Label>
                        (<asp:Label ID="Label4" runat="server" Text='<%# Eval("cod_usuario") %>'></asp:Label>
                        )
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:BoundField DataField="data_alteracao" 
                    DataFormatString="{0:dd/MM/yyyy HH:mm:ss}" HeaderText="Data/Hora Alteração" 
                    ReadOnly="True" SortExpression="data_alteracao">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="campo_descricao" HeaderText="Campo Alterado" 
                    ReadOnly="True" SortExpression="campo_descricao">
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="conteudo_anterior" HeaderText="Conteúdo (De)" 
                    ReadOnly="True" SortExpression="conteudo_anterior">
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="conteudo_atual" HeaderText="Conteúdo (Para)" 
                    ReadOnly="True" SortExpression="conteudo_atual">
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
            </Columns>
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                HorizontalAlign="Left" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
            
            SelectCommand="call sp_chamado_historico_alteracao(:empresa,:cod_atendimento)">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="" Name=":empresa" 
                    SessionField="GlEmpresa" />
                <asp:SessionParameter Name=":cod_atendimento" 
                    SessionField="SCodAtendimento" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
