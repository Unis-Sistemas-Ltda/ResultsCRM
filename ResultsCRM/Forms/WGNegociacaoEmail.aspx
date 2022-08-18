<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGNegociacaoEmail.aspx.vb" Inherits="ResultsCRM.WGNegociacaoEmail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="SubTituloMovimento">E-mails</div>
    <div>
    
        <br />
        <table class="TextoCadastro_BGBranco" style="width:100%;">
            <tr>
                <td style="text-align: left">
                    <asp:ImageButton ID="BtnNovoRegistro" runat="server" 
                        ImageUrl="~/Imagens/BtnNovoRegistro.png" style="height: 18px" />
                &nbsp;<asp:LinkButton ID="BtnEnviarEmails" runat="server" CssClass="CampoCadastro" 
            Font-Bold="True" Font-Size="8pt" 
            onclientclick="return confirm('Deseja enviar todos os e-mails pendentes?');" 
                        Height="17px">Enviar 
                    e-mails pendentes</asp:LinkButton>
                </td>
                <td style="text-align: right">
                    &nbsp;</td>
            </tr>
        </table>
    
        <asp:Label ID="LblErro" runat="server" CssClass="Erro"></asp:Label>
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" CssClass="TextoCadastro" 
            DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" Width="100%">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" />
            <Columns>
                <asp:TemplateField SortExpression="seq_follow_up" 
                    HeaderText="Detalhes do E-mail">
                    <EditItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("seq_follow_up") %>'></asp:Label>
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("data_email") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        Seq.:<asp:Label ID="Label11" runat="server" Font-Bold="True" 
                            Text='<%# Eval("seq") %>'></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp; Data:<asp:Label ID="Label8" runat="server" Font-Bold="True" 
                            Text='<%# Bind("data_email", "{0:dd/MM/yyyy}") %>'></asp:Label>
                        &nbsp;&nbsp;&nbsp; Envio:<asp:Label ID="Label9" runat="server" Font-Bold="True" 
                            Text='<%# Eval("enviado", "{0:dd/MM/yyyy}") %>'></asp:Label>
                        <br />
                        Assunto:
                        <asp:Label ID="Label4" runat="server" Font-Bold="True" 
                            Text='<%# Eval("assunto") %>'></asp:Label>
                        <br />
                        De:
                        <asp:Label ID="Label2" runat="server" Font-Bold="True" 
                            Text='<%# Eval("remetente") %>'></asp:Label>
                        &nbsp;(<asp:Label ID="Label6" runat="server" Font-Bold="True" 
                            Text='<%# Eval("de") %>'></asp:Label>
                        )<br />
                        Para:
                        <asp:Label ID="Label5" runat="server" Font-Bold="True" 
                            Text='<%# Eval("destinatario") %>'></asp:Label>
                        &nbsp;(<asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Italic="False" 
                            Text='<%# Eval("para") %>'></asp:Label>
                        )<br />
                        Anexo(s):<asp:Label ID="Label12" runat="server" Font-Bold="True" 
                            Text='<%# Eval("anexos") %>'></asp:Label>
                        <br />
                        <br />
                        Mensagem:<br />
                        <asp:Label ID="Label3" runat="server" Font-Bold="False" ForeColor="#006600" 
                            Text='<%# Eval("mensagem") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" CommandName="ALTERAR" 
                            ImageUrl="~/Imagens/BtnEditar.png" 
                            CommandArgument='<%# Eval("seq") %>' ToolTip="Alterar registro" />
                        <br />
                        <br />
                        <asp:ImageButton ID="ImageButton2" runat="server" CommandName="EXCLUIR" 
                            ImageUrl="~/Imagens/BtnExcluir.png" 
                            CommandArgument='<%# Eval("seq") %>' 
                            onclientclick="return confirm('Deseja realmente excluir este e-mail?');" 
                            ToolTip="Excluir registro" />
                    </ItemTemplate>
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
            SelectCommand="  SELECT negociacao_cliente_email.seq,
         negociacao_cliente_email.data_email,
         negociacao_cliente_email.de,
         negociacao_cliente_email.remetente,
         negociacao_cliente_email.para,
         negociacao_cliente_email.destinatario,
         negociacao_cliente_email.assunto,
         replace(replace(negociacao_cliente_email.mensagem,char(10), '&lt;br/&gt;'),char(13),'&lt;br/&gt;') mensagem,
         if length(isnull(negociacao_cliente_email.anexo,'')) &gt; 0 then 'Sim' else 'Não' endif as id_anexo,
         replace(anexo,';','; ') anexos,
         negociacao_cliente_email.enviado
    FROM negociacao_cliente_email  
   WHERE negociacao_cliente_email.empresa     = :empresa
     AND negociacao_cliente_email.estabelecimento  = :estabelecimento
     AND negociacao_cliente_email.cod_negociacao_cliente = :negociacao
order by negociacao_cliente_email.seq desc">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="" Name=":empresa" 
                    SessionField="GlEmpresa" />
                <asp:SessionParameter Name=":estabelecimento" 
                    SessionField="GlEstabelecimento" />
                <asp:SessionParameter Name=":negociacao" SessionField="SCodNegociacao" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
