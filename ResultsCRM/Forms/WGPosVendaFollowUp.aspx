<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGPosVendaFollowUp.aspx.vb" Inherits="ResultsCRM.WGPosVendaFollowUp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label2" runat="server" CssClass="TextoCadastro_BGBranco" 
            Font-Bold="True" Text="FOLLOW-UP DO CLIENTE" Width="80%"></asp:Label>
        <asp:ImageButton ID="LblIncluir" runat="server" 
            ImageUrl="~/Imagens/BtnNovoRegistro.png" />
    
        <asp:Label ID="LblErro" runat="server" CssClass="Erro" BackColor="#FFFFE8" 
            Width="100%"></asp:Label>
    
        <br />
    
        <br />
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" CssClass="TextoCadastro" 
            DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" 
            Width="100%" EnableModelValidation="True">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" />
            <Columns>
                <asp:TemplateField HeaderText="Seq" SortExpression="seq_follow_up">
                    <EditItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("seq_follow_up") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="LblCodFollowUp" runat="server" 
                            Text='<%# Bind("seq_follow_up") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Comentário" SortExpression="fup_descricao">
                    <ItemTemplate>
                        Em
                        <asp:Label ID="LblData" runat="server" Font-Bold="True" Font-Italic="False" 
                            Text='<%# Eval("data_follow_up", "{0:dd/MM/yy HH:mm}") %>'></asp:Label>
                        &nbsp;<asp:Label ID="LblUsuario" runat="server" Text='<%# Eval("nome_usuario") %>' 
                            Font-Bold="True" Font-Italic="False"></asp:Label>
                        escreveu:<br />
                        <asp:Label ID="LblComentario" runat="server" 
                            Text='<%# Eval("descricao") %>' Font-Italic="False" 
                            ForeColor="#0033CC"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("fup_descricao") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemStyle Font-Italic="False" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" 
                            CommandArgument='<%# eval("seq_follow_up") %>' CommandName="ALTERAR" 
                            ImageUrl="~/Imagens/BtnEditar.png" />
                    </ItemTemplate>
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
            SelectCommand="  SELECT follow_up_emitente.cod_emitente,   
         follow_up_emitente.empresa,   
         follow_up_emitente.seq_follow_up,   
         follow_up_emitente.data_follow_up,   
         follow_up_emitente.descricao,   
         follow_up_emitente.estabelecimento,   
         follow_up_emitente.cod_pedido_venda,   
         follow_up_emitente.cod_negociacao_cliente,   
         follow_up_emitente.tipo,
         su.nome_usuario
    FROM follow_up_emitente  inner join sysusuario su on su.cod_usuario = follow_up_emitente.cod_usuario
   WHERE follow_up_emitente.cod_emitente = :cod_emitente
     AND follow_up_emitente.tipo         = 1
order by seq_follow_up desc">
            <SelectParameters>
                <asp:SessionParameter Name=":cod_emitente" 
                    SessionField="SCodEmitente" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
