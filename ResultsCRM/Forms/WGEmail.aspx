<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGEmail.aspx.vb" Inherits="ResultsCRM.WGEmail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="TituloMovimento">
        Painel Geral de E-mails</div>
    <div class="TextoCadastro_BGBranco">
        <table style="width:100%;">
            <tr>
                <td colspan="2">
                    <asp:Label ID="LblErro" runat="server" CssClass="Erro"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
        Tipo:</td>
                <td>
                    <asp:RadioButtonList ID="RblTipo" runat="server" AutoPostBack="True">
                        <asp:ListItem Value="1" Selected="True">Atendimento</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    Status:</td>
                <td>
                    <asp:RadioButtonList ID="RblStatus" runat="server" RepeatColumns="3" 
                        AutoPostBack="True">
                        <asp:ListItem Value="1" Selected="True">Pendentes&nbsp;</asp:ListItem>
                        <asp:ListItem Value="2">Enviados&nbsp;</asp:ListItem>
                        <asp:ListItem Value="3">Todos</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    &nbsp;</td>
                <td>
        <asp:LinkButton ID="BtnEnviarEmails" runat="server" CssClass="CampoCadastro" 
            Font-Bold="True" Font-Size="8pt" ForeColor="Blue" 
            onclientclick="return confirm('Deseja enviar todos os e-mails pendentes?');">Clique aqui para enviar todos os e-mails pendentes.</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: right">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" CssClass="TextoCadastro" 
            DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" 
            Width="100%" EnableModelValidation="True" PageSize="3">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" />
            <Columns>
                <asp:TemplateField SortExpression="seq_follow_up" 
                    HeaderText="Detalhes do E-mail">
                    <EditItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("seq_follow_up") %>'></asp:Label>
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("data_email") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        Cliente:
                        <asp:Label ID="Label13" runat="server" Font-Bold="True" 
                            Text='<%# Eval("nome") %>'></asp:Label>
                        &nbsp;(<asp:Label ID="Label14" runat="server" Font-Bold="True" 
                            Text='<%# Eval("cod_emitente") %>'></asp:Label>
                        ) - CNPJ/CPF:
                        <asp:Label ID="Label15" runat="server" Font-Bold="True" 
                            Text='<%# Eval("cnpj") %>'></asp:Label>
                        <br />
                        Seq.:<asp:Label ID="LblSeqEmail" runat="server" Font-Bold="True" 
                            Text='<%# Eval("email") %>'></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp; Data:<asp:Label ID="Label8" runat="server" Font-Bold="True" 
                            Text='<%# Bind("data_email", "{0:dd/MM/yyyy}") %>'></asp:Label>
                        &nbsp;&nbsp;&nbsp; Enviado em:<asp:Label ID="Label9" runat="server" Font-Bold="True" 
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
                        )<br />Anexo(s):<asp:Label ID="Label12" runat="server" Font-Bold="True" 
                            Text='<%# Eval("anexos") %>'></asp:Label>
                        <br />
                        <asp:Label ID="Label16" runat="server" CssClass="Erro" 
                            Text='<%# Eval("erro") %>'></asp:Label>
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
                        <asp:LinkButton ID="LinkButton1" runat="server" 
                            CommandArgument='<%# Eval("email") %>' CommandName="ENVIAR" 
                            ToolTip="Clique para enviar este e-mail.">Enviar</asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerSettings FirstPageText="1&nbsp;&nbsp;" LastPageText="Últ." 
                Mode="NumericFirstLast" PageButtonCount="20" />
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
         email_saida.assunto,
         replace(replace(email_saida.mensagem,char(10), ''),char(13),'&lt;br/&gt;') mensagem,
         if length(isnull(email_saida.anexo,'')) &gt; 0 then 'Sim' else 'Não' endif as id_anexo,
         replace(anexo,';','; ') anexos,
         email_saida.enviado,
         e.cod_emitente,
         e.nome,
         c.cnpj,
         (select first descricao_erro from controle_email where empresa = c.empresa and chave1 = c.cod_chamado and chave2 = email_saida.email) erro
    FROM email_saida inner join chamado c on email_saida.cod_chamado = c.cod_chamado and email_saida.empresa = c.empresa
                     inner join emitente e on e.cod_emitente = c.cod_emitente
   WHERE email_saida.empresa     = :empresa
     AND c.cod_analista = :cod_usuario
     AND ( (:tipo in ('1','3') and ( enviado is null or trim(isnull(erro,'')) &lt;&gt; '') ) or (:tipo2 in ('2','3') and enviado is not null and trim(isnull(erro,'')) = '' ) )
order by email_saida.email desc">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="" Name=":empresa" 
                    SessionField="GlEmpresa" />
                <asp:SessionParameter Name=":cod_usuario" 
                    SessionField="GlCodUsuario" />
                <asp:ControlParameter ControlID="RblStatus" Name=":tipo" 
                    PropertyName="SelectedValue" />
                <asp:ControlParameter ControlID="RblStatus" Name=":tipo2" 
                    PropertyName="SelectedValue" />
            </SelectParameters>
        </asp:SqlDataSource>
    
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
