<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGNegociacaoFollowUp.aspx.vb" Inherits="ResultsCRM.WGNegociacaoFollowUp" %>

<%@ Register src="../UserControls/WUCNegociacaoTotais.ascx" tagname="WUCNegociacaoTotais" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="SubTituloMovimento">Ações</div>
    <div>
    
        <br />
    
        <asp:ImageButton ID="ImageButton2" runat="server" 
            ImageUrl="~/Imagens/BtnNovoRegistro.png" />
    
        <br />
    
        <asp:Label ID="LblErro" runat="server" CssClass="Erro"></asp:Label>
    
        <br />
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" CssClass="TextoCadastro" 
            DataKeyNames="empresa,cod_emitente,seq_follow_up,cod_contato,cod_usuario" 
            DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" Width="100%">
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
                    <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:BoundField DataField="data_follow_up" HeaderText="Data" 
                    SortExpression="data_follow_up" DataFormatString="{0:dd/MM/yyyy}" 
                    Visible="False">
                    <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="hora_follow_up" HeaderText="Hora" 
                    SortExpression="hora_follow_up" DataFormatString="{0:HH:mm}" 
                    Visible="False">
                    <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="assunto" HeaderText="Assunto" 
                    SortExpression="assunto" Visible="False">
                    <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="nome" HeaderText="Contato" SortExpression="nome" 
                    Visible="False">
                    <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="nome_usuario" HeaderText="Usuário" 
                    SortExpression="nome_usuario" Visible="False">
                    <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkExpansao" runat="server" 
                            CommandArgument='<%# Eval("seq_follow_up") %>' CommandName="EXPANDIR" 
                            Font-Underline="False" style="font-weight: 700">+</asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle Font-Size="10pt" HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Ação">
                    <ItemTemplate>
                        em
                        <asp:Label ID="Label1" runat="server" style="font-weight: 700" 
                            Text='<%# Eval("data_follow_up", "{0:dd/MM/yyyy}") %>'></asp:Label>
                        &nbsp;<asp:Label ID="Label2" runat="server" style="font-weight: 700" 
                            Text='<%# Eval("hora_follow_up", "{0:t}") %>'></asp:Label>
                        &nbsp;-
                        <asp:Label ID="Label4" runat="server" style="font-weight: 700" 
                            Text='<%# Eval("descricao") %>'></asp:Label>
                        &nbsp;-
                        <asp:Label ID="Label3" runat="server" style="font-weight: 700" 
                            Text='<%# Eval("assunto") %>'></asp:Label>
                        &nbsp;- Pessoa contactada:
                        <asp:Label ID="Label5" runat="server" style="font-weight: 700" 
                            Text='<%# Eval("nome") %>'></asp:Label>
                        &nbsp;- por
                        <asp:Label ID="Label6" runat="server" style="font-weight: 700" 
                            Text='<%# Eval("nome_usuario") %>'></asp:Label>
                        <asp:Label ID="LblDetalhes" runat="server" 
                            Text='<%# "<br>" & Eval("fup_descricao") %>' Visible="False"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Font-Bold="False" />
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
            SelectCommand="select f.empresa, f.estabelecimento, f.cod_emitente, f.seq_follow_up, f.cod_negociacao_cliente, f.data_follow_up, f.hora_follow_up, f.assunto, f.cod_contato, f.cod_usuario, c.nome, s.nome_usuario, ac.descricao, f.descricao fup_descricao
  from follow_up_emitente f left outer join contatos c on c.cod_contato = f.cod_contato
                                                       and c.cod_emitente = f.cod_emitente
                            left outer join sysusuario s on s.cod_usuario = f.cod_usuario
                            left outer join acao_follow_up ac on ac.cod_acao = f.cod_acao
 where  f.empresa = :empresa
  and f.estabelecimento = :estabelecimento
  and f.cod_negociacao_cliente = :cod_negociacao
  and f.tipo = 2
order by f.data_follow_up desc, f.hora_follow_up desc">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="" Name=":empresa" 
                    SessionField="GlEmpresa" />
                <asp:SessionParameter Name=":estabelecimento" 
                    SessionField="GlEstabelecimento" />
                <asp:SessionParameter Name=":cod_negociacao" SessionField="SCodNegociacao" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
