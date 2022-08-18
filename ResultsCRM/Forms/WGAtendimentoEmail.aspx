<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGAtendimentoEmail.aspx.vb" Inherits="ResultsCRM.WGAtendimentoEmail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="LblErro" runat="server" CssClass="Erro" BackColor="#FFFFE8" 
            Width="100%"></asp:Label>
    
        <br />
        <table class="TextoCadastro_BGBranco" style="width:100%;">
            <tr>
                <td style="text-align: left">
                    <asp:Label ID="LblIdentificador" runat="server" Font-Bold="True"></asp:Label>
                </td>
                <td style="text-align: right">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: left">
        <asp:LinkButton ID="BtnEnviarEmails" runat="server" CssClass="CampoCadastro" 
            Font-Bold="True" Font-Size="8pt" ForeColor="Blue" 
            onclientclick="return confirm('Deseja enviar todos os e-mails pendentes?');">Enviar todos os e-mails pendentes</asp:LinkButton>
                </td>
                <td style="text-align: right">
                    <asp:ImageButton ID="BtnNovoRegistro" runat="server" 
                        ImageUrl="~/Imagens/BtnNovoRegistro.png" style="height: 18px" />
                </td>
            </tr>
        </table>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" CssClass="TextoCadastro" 
            DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" 
            Width="100%">
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
                            Text='<%# Eval("email") %>'></asp:Label>
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
                        )<br />Para:
                        <asp:Label ID="Label5" runat="server" Font-Bold="True" 
                            Text='<%# Eval("destinatario") %>'></asp:Label>
                        &nbsp;(<asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Italic="False" 
                            Text='<%# Eval("para") %>'></asp:Label>
                        )<asp:Label ID="LblCCO" runat="server" Text="&nbsp;CCO:" 
                            Visible='<%# Eval("cco_visible") %>'></asp:Label>
                        <asp:Label ID="Label13" runat="server" Font-Bold="True" 
                            Text='<%# Eval("destinatario_cco") %>' Visible='<%# Eval("cco_visible") %>'></asp:Label>
                        <br />
                        Anexo(s):&nbsp;
                        <asp:HyperLink ID="HyperLink1" runat="server" Text='<%# Eval("anexo1") %>' target="_blank"
                            Visible='<%# Eval("possui_anexo1") %>'></asp:HyperLink>
                        &nbsp;&nbsp;
                        <asp:HyperLink ID="HyperLink2" runat="server" Text='<%# Eval("anexo2") %>' target="_blank"
                            Visible='<%# Eval("possui_anexo2") %>'></asp:HyperLink>
                        &nbsp;&nbsp;
                        <asp:HyperLink ID="HyperLink3" runat="server" Text='<%# Eval("anexo3") %>' target="_blank"
                            Visible='<%# Eval("possui_anexo3") %>'></asp:HyperLink>
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
                            CommandArgument='<%# Eval("email") %>' ToolTip="Alterar registro" />
                        <br />
                        <br />
                        <asp:ImageButton ID="ImageButton2" runat="server" CommandName="EXCLUIR" 
                            ImageUrl="~/Imagens/BtnExcluir.png" 
                            CommandArgument='<%# Eval("email") %>' 
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
            SelectCommand="  SELECT email_saida.email,
         email_saida.data_email,
         email_saida.de,
         email_saida.remetente,
         email_saida.para,
         email_saida.destinatario,
         email_saida.destinatario_cco,
         if trim(isnull(email_saida.destinatario_cco,'')) = '' then 'False' else 'True' endif as cco_visible,
         email_saida.assunto,
         replace(replace(email_saida.mensagem,char(10), ''),char(13),'&lt;br/&gt;') mensagem,
         if length(isnull(email_saida.anexo,'')) &gt; 0 then 'Sim' else 'Não' endif as id_anexo,
         trim(isnull(anexo,'')) anexos,
         email_saida.enviado,
         locate(anexos,';',0) pos1,
         f_nome_arquivo(trim(if pos1 &gt; 0 then substr(anexos,0,pos1-1) else substr(anexos,0) endif)) anexo1,
         if anexo1 &lt;&gt; '' then 'True' else 'False' endif possui_anexo1,
         if pos1 = 0 then 0 else locate(anexos,';',pos1+1) endif pos2,
         f_nome_arquivo(trim(if pos2 &gt; 0 then substr(anexos,pos1+1,pos2-1) else if pos1 &gt; 0 then substr(anexos,pos1+1) else '' endif endif)) anexo2,
         if anexo2 &lt;&gt; '' then 'True' else 'False' endif possui_anexo2,
         if pos1 = 0 or pos2 = 0 then 0 else locate(anexos,';',pos2+1) endif pos3,
         f_nome_arquivo(trim(if pos3 &gt; 0 then substr(anexos,pos2+1,pos3-1) else if pos2 &gt; 0 then substr(anexos,pos2+1) else '' endif endif)) anexo3,
         if anexo3 &lt;&gt; '' then 'True' else 'False' endif possui_anexo3
    FROM email_saida  
   WHERE email_saida.empresa     = :empresa
     AND email_saida.cod_chamado = :chamado
     AND isnull(enviado_automatico,'N') = if :eid = 'P' then 'N' else 'S' endif
order by email_saida.email desc">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="" Name=":empresa" 
                    SessionField="GlEmpresa" />
                <asp:SessionParameter Name=":chamado" 
                    SessionField="SCodAtendimento" />
                <asp:QueryStringParameter Name=":eid" QueryStringField="eid" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
