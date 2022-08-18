<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGTEF.aspx.vb" Inherits="ResultsCRM.WGTEF" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="TituloMovimento">Painel de Campanha TEF</div>
    <div class="Erro"><asp:Label ID="LblErro" runat="server"></asp:Label>
    <div style="text-align: left; vertical-align: middle;">
    
            <asp:Label ID="Label2" runat="server" CssClass="TextoCadastro_BGBranco" Height="16px"  style="text-align:right"
                Text="Código:" Width="50px"></asp:Label>
            <asp:TextBox ID="TxtCodigo" runat="server" CssClass="CampoCadastro" 
                MaxLength="6" Width="65px"></asp:TextBox>
&nbsp;
            <asp:Label ID="Label1" runat="server" CssClass="TextoCadastro_BGBranco" 
                Height="16px" Text="Nome:"></asp:Label>
            <asp:TextBox ID="TxtNome" runat="server" CssClass="CampoCadastro" Width="211px"></asp:TextBox>
            <asp:Label ID="Label3" runat="server" CssClass="TextoCadastro_BGBranco" 
                Height="16px" Text="&nbsp;CNPJ:"></asp:Label>
            <asp:TextBox ID="TxtCNPJ" runat="server" CssClass="CampoCadastro" 
                MaxLength="14" Width="121px"></asp:TextBox>
            <br />
    
            <asp:Label ID="Label6" runat="server" CssClass="TextoCadastro_BGBranco" style="text-align:right"
                Height="16px" Text="Grupo:" Width="50px"></asp:Label>
            <asp:DropDownList ID="DdlGrupoTEF" runat="server" CssClass="CampoCadastro" 
                Width="175px">
            </asp:DropDownList>
    
            &nbsp;<asp:Label ID="Label8" runat="server" CssClass="TextoCadastro_BGBranco" 
                Height="16px" Text="Estado:"></asp:Label>
            <asp:DropDownList ID="DdlUF" runat="server" CssClass="CampoCadastro" 
                Width="61px">
            </asp:DropDownList>
    
            <asp:Label ID="Label12" runat="server" CssClass="TextoCadastro_BGBranco" style="text-align:right"
                Height="16px" Text="Negociações:" Width="106px"></asp:Label>
            <asp:DropDownList ID="DdlComNegociacao" runat="server" CssClass="CampoCadastro" 
                Width="102px">
                <asp:ListItem Value="S">Com negociação</asp:ListItem>
                <asp:ListItem Value="N">Sem negociação</asp:ListItem>
                <asp:ListItem Selected="True" Value="A">Todos</asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:Label ID="Label7" runat="server" CssClass="TextoCadastro_BGBranco"  style="text-align:right"
                Height="16px" Text="E-mail:" Width="50px"></asp:Label>
            <asp:TextBox ID="TxtEmail" runat="server" CssClass="CampoCadastro" 
                Width="168px"></asp:TextBox>
            <asp:Label ID="Label9" runat="server" CssClass="TextoCadastro_BGBranco" 
                Height="16px" Text="&nbsp;E-mails enviados:"></asp:Label>
            <asp:DropDownList ID="DdlEmailsEnviados" runat="server" 
                CssClass="CampoCadastro">
                <asp:ListItem Value="S">Sim</asp:ListItem>
                <asp:ListItem Value="N">Não</asp:ListItem>
                <asp:ListItem Selected="True" Value="A">Todos</asp:ListItem>
            </asp:DropDownList>
            <asp:Label ID="Label13" runat="server" CssClass="TextoCadastro_BGBranco" 
                Height="16px" Text="&nbsp;E-mail cadastrado:"></asp:Label>
            <asp:DropDownList ID="DdlEmailsCadastrados" runat="server" 
                CssClass="CampoCadastro">
                <asp:ListItem Value="S">Sim</asp:ListItem>
                <asp:ListItem Value="N">Não</asp:ListItem>
                <asp:ListItem Selected="True" Value="A">Todos</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="Label10" runat="server" CssClass="TextoCadastro_BGBranco" 
                Height="16px" Width="50px"></asp:Label>
            <asp:Button ID="BtnFiltrar" runat="server" CssClass="Botao" 
                Text="Aplicar Filtro" Width="105px" />
            &nbsp;&nbsp;<asp:Button ID="BtnFiltrar0" runat="server" CssClass="Botao" 
                Text="Novo Registro" Height="19px" Width="105px" />
            <br />
            <br />
    
    </div>
    <div style="text-align: right">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" CssClass="TextoCadastro" DataSourceID="SqlDataSource1" 
            ForeColor="#333333" GridLines="None" Width="100%" AllowPaging="True" 
            AllowSorting="True" Font-Size="7pt">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" />
            <Columns>
                <asp:BoundField DataField="nome_rede" HeaderText="Grupo TEF" 
                    SortExpression="nome_rede">
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="cod_emitente" HeaderText="Código" ReadOnly="True" 
                    SortExpression="cod_emitente">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="razao_social" HeaderText="Razão Social" 
                    SortExpression="razao_social" >
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="cnpj" HeaderText="CNPJ" SortExpression="cnpj" >
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="telefone" HeaderText="Telefone" 
                    SortExpression="telefone" >
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="email" HeaderText="E-mail" SortExpression="email">
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="sigla" HeaderText="Estado" SortExpression="sigla">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="nome_cidade" HeaderText="Cidade" 
                    SortExpression="nome_cidade">
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="desc_status_adesao" HeaderText="Status" 
                    SortExpression="desc_status_adesao" >
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="cod_negociacao_cliente" HeaderText="Nº Negociação" 
                    SortExpression="cod_negociacao_cliente">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="email_enviado" HeaderText="E-mail enviado" 
                    SortExpression="email_enviado">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" 
                            CommandArgument='<%# Eval("chave") %>' CommandName="ALTERAR" 
                            ImageUrl="~/Imagens/BtnEditar.png" ToolTip="Detalhes do Registro" />
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="BtnExcluir" runat="server" 
                            CommandArgument='<%# Eval("chave") %>' CommandName="EXCLUIR" 
                            ImageUrl="~/Imagens/BtnExcluir.png" 
                            onclientclick="return confirm('Deseja realmente excluir este cliente?');" 
                            ToolTip="Excluir" 
                            Visible='<%# iif( session("GlBloquearCadastroEmitenteRepresentante") = "S", "False", "True") %>' />
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
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select l.cod_adesao, l.cod_emitente, l.razao_social, l.cnpj, a.nome_rede, s.descricao desc_status_adesao, :empresa emp, :codigo cod, :grupo grp, l.cod_emitente || ';' || l.cnpj chave, uf.sigla, ci.nome_cidade, ee.telefone,
       isnull((select first 'S' from email_campanha_tef where cod_emitente = l.cod_emitente and cnpj = l.cnpj),'N') email_enviado,
       if l.cod_negociacao_cliente is null then 'N' else 'S' endif com_negociacao,
       l.cod_negociacao_cliente,
       trim(isnull((select email from contatos where cod_emitente = l.cod_emitente and preferencial = 'S'),'')) email,
       if email = '' then 'N' else 'S' endif email_preenchido
  from adesao_tef_loja l left outer join adesao_tef a on l.empresa = a.empresa and l.cod_adesao = a.cod_adesao
                         inner join endereco_emitente ee on ee.cod_emitente = l.cod_emitente and ee.cnpj = l.cnpj
                         inner join estado uf on uf.cod_pais = ee.cod_pais and uf.cod_estado = ee.cod_estado
                         inner join cidade ci on ci.cod_pais = ee.cod_pais and ci.cod_estado = ee.cod_estado and ci.cod_cidade = ee.cod_cidade
                         left outer join status_adesao_tef s on s.cod_status = l.cod_status
 where l.empresa = emp
     and ( trim(cod) = '' or l.cod_emitente = cod)
     and l.razao_social like '%' || replace(:nome,' ','%') || '%'
     and l.cnpj like '%' || :cnpj || '%'
     and (grp = -1 or l.cod_adesao = grp)
     and (trim(isnull(:pesq_email1,'')) = '' or exists(select 1 from contatos where cod_emitente = l.cod_emitente and email like '%' || :pesq_email2 || '%') or exists(select 1 from endereco_emitente where cod_emitente = l.cod_emitente and email like '%' || :pesq_email3 || '%' ) )
     and (:uf in (0,ee.cod_estado))
     and (:email_enviado in ('A', email_enviado))
     and (:com_negociacao in ('A', com_negociacao))
     and (:email_preenchido in ('A', email_preenchido))
order by l.razao_social">
            <SelectParameters>
                <asp:SessionParameter Name=":empresa" SessionField="GlEmpresa" />
                <asp:ControlParameter ControlID="TxtCodigo" ConvertEmptyStringToNull="False" 
                    Name=":codigo" PropertyName="Text" />
                <asp:ControlParameter ControlID="DdlGrupoTEF" Name=":grupo" 
                    PropertyName="SelectedValue" ConvertEmptyStringToNull="False" 
                    DbType="String" />
                <asp:ControlParameter ControlID="TxtNome" ConvertEmptyStringToNull="False" 
                    Name=":nome" PropertyName="Text" />
                <asp:ControlParameter ControlID="TxtCNPJ" ConvertEmptyStringToNull="False" 
                    DbType="String" Name=":cnpj" PropertyName="Text" />
                <asp:ControlParameter ControlID="TxtEmail" ConvertEmptyStringToNull="False" 
                    DbType="String" Name=":pesq_email1" PropertyName="Text" />
                <asp:ControlParameter ControlID="TxtEmail" ConvertEmptyStringToNull="False" 
                    DbType="String" Name=":pesq_email2" PropertyName="Text" />
                <asp:ControlParameter ControlID="TxtEmail" ConvertEmptyStringToNull="False" 
                    DbType="String" Name=":pesq_email3" PropertyName="Text" />
                <asp:ControlParameter ControlID="DdlUF" ConvertEmptyStringToNull="False" 
                    DbType="String" Name=":uf" PropertyName="SelectedValue" />
                <asp:ControlParameter ControlID="DdlEmailsEnviados" 
                    ConvertEmptyStringToNull="False" DbType="String" Name=":email_enviado" 
                    PropertyName="SelectedValue" />
                <asp:ControlParameter ControlID="DdlComNegociacao" 
                    ConvertEmptyStringToNull="False" DbType="String" Name=":com_negociacao" 
                    PropertyName="SelectedValue" />
                <asp:ControlParameter ControlID="DdlEmailsCadastrados" 
                    ConvertEmptyStringToNull="False" DbType="String" Name=":email_preenchido" 
                    PropertyName="SelectedValue" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>
    <div class="TextoCadastro" style="text-align: center">
        <br />
        <asp:Label ID="Label5" runat="server" Text="Qtd. Registros:"></asp:Label>
        &nbsp;<asp:Label ID="LblQtd" runat="server" Font-Bold="True" Text="0"></asp:Label>
        </div>
    </form>
</body>
</html>
