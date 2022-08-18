<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGTEFFollowUp.aspx.vb" Inherits="ResultsCRM.WGTEFFollowUp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
     <div style="text-align: right">
    
         <asp:ImageButton ID="LblIncluir" runat="server" 
            ImageUrl="~/Imagens/BtnNovoRegistro.png" />
    
        <br />
    
        <asp:Label ID="LblErro" runat="server" CssClass="Erro" BackColor="#FFFFE8" 
            Width="100%"></asp:Label>
    
        <br />
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" CssClass="TextoCadastro" 
            DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" 
            Width="100%" 
            
             
             EmptyDataText="&lt;br&gt;&lt;br&gt;Não há follow-ups cadastrados para o cliente em questão.">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" />
            <Columns>
                <asp:TemplateField HeaderText="Seq" SortExpression="seq_follow_up" 
                    Visible="False">
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
                            Text='<%# Eval("data_inclusao", "{0:dd/MM/yy HH:mm}") %>'></asp:Label>
                        &nbsp;<asp:Label ID="LblUsuario" runat="server" Text='<%# Eval("nome_usuario") %>' 
                            Font-Bold="True" Font-Italic="False"></asp:Label>
                        escreveu:<br />
                        <br />
                        <asp:Label ID="LblComentario" runat="server" 
                            Text='<%# Eval("descricao") %>' Font-Italic="False" 
                            ForeColor="#0033CC"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("fup_descricao") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle Font-Italic="False" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" 
                            CommandArgument='<%# eval("seq_follow_up") %>' CommandName="ALTERAR" 
                            ImageUrl="~/Imagens/BtnEditar.png" ToolTip="Alterar o registro" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton2" runat="server" 
                            CommandArgument='<%# eval("seq_follow_up") %>' CommandName="EXCLUIR" 
                            ImageUrl="~/Imagens/BtnExcluir.png" 
                            onclientclick="return confirm('Deseja realmente excluir este follow-up?')" 
                            ToolTip="Excluir o registro" />
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
            SelectCommand="select a.seq_follow_up, a.descricao, a.data_inclusao, a.cod_usuario_inclusao, s.nome_usuario
from adesao_tef_follow_up a inner join sysusuario s on a.cod_usuario_inclusao = s.cod_usuario
where a.empresa = :empresa
and a.cod_emitente = :cod_emitente
and a.cnpj = :cnpj
order by a.seq_follow_up">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="" Name=":empresa" 
                    SessionField="GlEmpresa" />
                <asp:SessionParameter Name=":cod_emitente" 
                    SessionField="SCodLoja" ConvertEmptyStringToNull="False" DbType="String" />
                <asp:SessionParameter ConvertEmptyStringToNull="False" DbType="String" 
                    Name=":cnpj" SessionField="SCNPJLoja" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
