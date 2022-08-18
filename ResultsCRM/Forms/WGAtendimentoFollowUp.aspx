<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGAtendimentoFollowUp.aspx.vb" Inherits="ResultsCRM.WGAtendimentoFollowUp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:ImageButton ID="LblIncluir" runat="server" 
            ImageUrl="~/Imagens/BtnNovoRegistro.png" />
    
        <br />
    
        <asp:Label ID="LblErro" runat="server" CssClass="Erro" BackColor="#FFFFE8" 
            Width="100%"></asp:Label>
    
        <br />
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" CssClass="TextoCadastro" 
            DataKeyNames="empresa,cod_chamado,seq_follow_up" 
            DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" 
            Width="100%" 
            
            EmptyDataText="&lt;br&gt;&lt;br&gt;Não há follow-ups cadastrados para o chamado em questão" 
            AllowSorting="True">
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
                            Text='<%# Eval("data_follow_up", "{0:dd/MM/yy HH:mm}") %>'></asp:Label>
                        &nbsp;<asp:Label ID="LblUsuario" runat="server" Text='<%# Eval("nome_usuario") %>' 
                            Font-Bold="True" Font-Italic="False"></asp:Label>
                        escreveu:<br />
                        <br />
                        <asp:Label ID="LblComentario" runat="server" 
                            Text='<%# Bind("fup_descricao") %>' Font-Italic="False" 
                            ForeColor="#0033CC"></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="LblAnexo" runat="server" Text="Anexo(s): " 
                            Visible='<%# Eval("contem_anexo1") %>'></asp:Label>
                        &nbsp;&nbsp;<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "~/anexo_chamado/" &  Eval("anexo1") %>' Text='<%# Eval("anexo1") %>' Visible='<%# Eval("contem_anexo1") %>'></asp:HyperLink>
                        &nbsp;&nbsp;&nbsp;<asp:HyperLink ID="HyperLink2" runat="server" Target="_blank" NavigateUrl='<%# "~/anexo_chamado/" &   Eval("anexo2") %>' Text='<%# Eval("anexo2") %>' Visible='<%# Eval("contem_anexo2") %>'></asp:HyperLink>
                        &nbsp;&nbsp;&nbsp;<asp:HyperLink ID="HyperLink3" runat="server" Target="_blank" NavigateUrl='<%# "~/anexo_chamado/" &   Eval("anexo3") %>' Text='<%# Eval("anexo3") %>' Visible='<%# Eval("contem_anexo3") %>'></asp:HyperLink>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("fup_descricao") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemStyle Font-Italic="False" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="@" SortExpression="email">
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("email") %>' 
                            Enabled="False" ToolTip='<%# Eval("email_tooltip") %>' />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("email") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:BoundField DataField="data_email" DataFormatString="{0:dd/MM/yyyy HH:mm}" 
                    HeaderText="E-mail Env." SortExpression="data_email" >
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="tipo" HeaderText="Tipo" SortExpression="tipo">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
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
            SelectCommand="select f.empresa, f.seq_follow_up, f.cod_chamado, f.data_follow_up, f.data_email, f.cod_usuario, s.nome_usuario, replace(f.descricao,char(13),'&lt;br/&gt;') fup_descricao, if f.email = 'S' then 'True' else 'False' endif email, if f.email = 'True' then 'Este comentário gera envio de e-mail.' else 'Este comentário não gera envio de e-mail.' endif email_tooltip, case f.tipo  when 1 then 'Comentário' when 2 then 'Pergunta' else 'Resposta' end tipo,

(select arquivo
  from follow_up_chamado_anexo
 where empresa = f.empresa
   and cod_chamado = f.cod_chamado
   and seq_follow_up = f.seq_Follow_up
   and seq_anexo = 1) anexo1,
if anexo1 is null then 'False' else 'True' endif contem_anexo1,

(select arquivo
  from follow_up_chamado_anexo
 where empresa = f.empresa
   and cod_chamado = f.cod_chamado
   and seq_follow_up = f.seq_Follow_up
   and seq_anexo = 2) anexo2,
if anexo2 is null then 'False' else 'True' endif contem_anexo2,

(select arquivo
  from follow_up_chamado_anexo
 where empresa = f.empresa
   and cod_chamado = f.cod_chamado
   and seq_follow_up = f.seq_Follow_up
   and seq_anexo = 3) anexo3,
if anexo3 is null then 'False' else 'True' endif contem_anexo3,

(select first caminho_anexo_follow_up from parametros_manutencao where empresa = f.empresa) caminho

  from follow_up_chamado f left outer join sysusuario s on s.cod_usuario = f.cod_usuario
 where f.empresa = :empresa
   and f.cod_chamado = :cod_atendimento
 order by seq_follow_up desc">
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
