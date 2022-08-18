<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGOSFollowUp.aspx.vb" Inherits="ResultsCRM.WGOSFollowUp" %>

<%@ Register src="../UserControls/WUCAtendimentoPedidoSolicitacao.ascx" tagname="WUCAtendimentoPedidoSolicitacao" tagprefix="uc2" %>

<%@ Register src="../UserControls/WUCFollowUP.ascx" tagname="WUCFollowUP" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="LblErro" runat="server" CssClass="Erro" BackColor="#FFFFE8" 
            Width="100%"></asp:Label>
    
        </div>
    <div class="TextoCadastro_BGBranco" 
        style="border-style: none">
    
        <table style="width:100%;">
            <tr>
                <td>
                    <uc1:WUCFollowUP ID="WUCFollowUP1" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" CssClass="TextoCadastro_BGBranco" 
            DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" 
            Width="100%" 
                        
                        
                        EmptyDataText="Nenhuma solicitação incluída nesta OS até o momento. Para incluir uma solicitação, clique na pasta Serv. Solicitados.">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Right" 
                VerticalAlign="Top" />
            <Columns>
                <asp:BoundField DataField="seq_follow_up" HeaderText="Seq." 
                    SortExpression="seq_follow_up">
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="data_follow_up" DataFormatString="{0:dd/MM/yyyy}" 
                    HeaderText="Data" SortExpression="data_follow_up">
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="descricao" HeaderText="Descrição" 
                    SortExpression="descricao">
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Usuário" SortExpression="nome_usuario">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("nome_usuario") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" 
                            Text='<%# Bind("nome_usuario") %>'></asp:Label>
                        (<asp:Label ID="Label2" runat="server" Text='<%# Eval("cod_usuario") %>'></asp:Label>
                        )
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" 
                            CommandArgument='<%# Eval("seq_follow_up") %>' CommandName="ALTERAR" 
                            ImageUrl="~/Imagens/BtnEditar.png" ToolTip="Editar Item da OS" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton3" runat="server" 
                            CommandArgument='<%# Eval("seq_follow_up") %>' CommandName="EXCLUIR" 
                            ImageUrl="~/Imagens/BtnExcluir.png" 
                            onclientclick="return confirm('ATENÇÃO: Procedimento irreversível! &nbsp;&nbsp;Deseja realmente excluir o follow-up selecionado?');" 
                            ToolTip="Excluir" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                HorizontalAlign="Right" />
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
            SelectCommand="  SELECT follow_up_emitente.seq_follow_up,   
         follow_up_emitente.data_follow_up,   
         follow_up_emitente.descricao,
         follow_up_emitente.cod_usuario,
         s.nome_usuario
    FROM follow_up_emitente inner join sysusuario s on follow_up_emitente.cod_usuario = s.cod_usuario
   WHERE follow_up_emitente.tipo = 3
     AND follow_up_emitente.empresa 			= :empresa
     AND follow_up_emitente.estabelecimento 	= :estabelecimento
     AND follow_up_emitente.cod_pedido_venda = :cod_pedido">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="" Name=":empresa" 
                    SessionField="GlEmpresa" />
                <asp:SessionParameter Name=":estabelecimento" 
                    SessionField="GlEstabelecimento" />
                <asp:SessionParameter Name=":cod_pedido" 
                    SessionField="SAtCodPedido" />
            </SelectParameters>
        </asp:SqlDataSource>
    
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
