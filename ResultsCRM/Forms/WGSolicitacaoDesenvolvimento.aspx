<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGSolicitacaoDesenvolvimento.aspx.vb" Inherits="ResultsCRM.WGSolicitacaoDesenvolvimento" %>
<%@ Register src="../OutrosControles/TextBoxData.ascx" tagname="TextBoxData" tagprefix="uc1" %>
<script language="javascript" src="../ResultsCRM.js" type="text/javascript"></script>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="TituloMovimento">
                Painel de Solicitações de Desenvolvimento</div>
        <div class="Erro">
            <asp:Label ID="LblErro" runat="server"></asp:Label>
    </div>
    <table style="width: 100%; border-collapse: collapse;"><tr><td style="text-align: right">
            <asp:Label 
                ID="Label7" runat="server" CssClass="TextoCadastro_BGBranco" Height="16px" 
                Text="Assunto:"></asp:Label>
            </td><td>
            <asp:TextBox ID="TxtAssunto" runat="server" CssClass="CampoCadastro" 
                Width="250px"></asp:TextBox>
            </td><td style="text-align: right">
                <asp:Label 
                ID="Label10" runat="server" CssClass="TextoCadastro_BGBranco" Height="16px" 
                Text="Desenvolvedor:"></asp:Label>
            </td><td>
            <asp:DropDownList ID="ddlDesenvolvedor" runat="server" CssClass="CampoCadastro" 
                Width="250px">
            </asp:DropDownList>
            </td><td style="text-align: right"><asp:Label 
                ID="Label2" runat="server" CssClass="TextoCadastro_BGBranco" Height="16px" 
                Text="Nº Solicitação:"></asp:Label>
            </td><td>
            <asp:TextBox ID="TxtCodSolicitacao" runat="server" CssClass="CampoCadastro" 
                Width="60px"></asp:TextBox>
        </td><td style="text-align: left">
            <asp:Label 
                ID="Label9" runat="server" CssClass="TextoCadastro_BGBranco" 
                Text="Tipo Status:"></asp:Label>
            <asp:CheckBox ID="CbxInicial" runat="server" Checked="True" 
                CssClass="TextoCadastro_BGBranco" Text="Inicial" />
            <asp:CheckBox ID="CbxIntermediario" runat="server" Checked="True" 
                CssClass="TextoCadastro_BGBranco" Text="Intermediário" />
            <asp:CheckBox ID="CbxFinal" runat="server" CssClass="TextoCadastro_BGBranco" 
                Text="Final" />
        </td><td style="text-align: right">
            <asp:Button ID="BtnFiltrar" runat="server" CssClass="Botao" Text="Filtrar" />
        </td></tr><tr><td style="text-align: right">
            <asp:Label ID="Label1" runat="server" CssClass="TextoCadastro_BGBranco" 
                Height="16px" Text="Cliente:"></asp:Label>
            </td><td>
            <asp:TextBox ID="TxtNomeCliente" runat="server" CssClass="CampoCadastro" 
                Width="250px"></asp:TextBox>
            </td><td style="text-align: right">
                <asp:Label 
                ID="Label3" runat="server" CssClass="TextoCadastro_BGBranco" Height="16px" 
                Text="Data Solicitação:"></asp:Label>
            </td><td>
            <asp:TextBox ID="txtPeriodoI" runat="server" CssClass="CampoCadastro" 
                Width="70px"></asp:TextBox>
            <asp:Label 
                ID="Label4" runat="server" CssClass="TextoCadastro_BGBranco" Height="16px" 
                Text="a:"></asp:Label>
            <asp:TextBox ID="txtPeriodoF" runat="server" CssClass="CampoCadastro" 
                Width="70px"></asp:TextBox>
            </td><td style="text-align: right">
            <asp:Label 
                ID="Label5" runat="server" CssClass="TextoCadastro_BGBranco" Height="16px" 
                Text="Urgência:"></asp:Label>
            </td><td colspan="2"><asp:DropDownList ID="ddlUrgencia" runat="server" CssClass="CampoCadastro" 
                Width="70px">
                <asp:ListItem Value="0">Baixa</asp:ListItem>
                <asp:ListItem Value="1">Média</asp:ListItem>
                <asp:ListItem Value="2">Alta</asp:ListItem>
                <asp:ListItem Selected="True" Value="99">Todas</asp:ListItem>
            </asp:DropDownList>
            <asp:Label 
                ID="Label13" runat="server" CssClass="TextoCadastro_BGBranco" Height="16px" style="text-align:right"
                Text="Versão:&nbsp;" Width="50px"></asp:Label>
            <asp:DropDownList ID="DdlReleaseVersaoBanco" runat="server" CssClass="CampoCadastro" 
                Width="120px">
            </asp:DropDownList>
            </td><td style="text-align: right; vertical-align: bottom" colspan="1">
            </td></tr><tr><td style="text-align: right">
            <asp:Label 
                ID="Label6" runat="server" CssClass="TextoCadastro_BGBranco" Height="16px" 
                Text="Analista:"></asp:Label>
            </td><td>
            <asp:DropDownList ID="ddlAnalista" runat="server" CssClass="CampoCadastro" 
                Width="250px">
            </asp:DropDownList>
            </td><td style="text-align: right">
                <asp:Label 
                ID="Label12" runat="server" CssClass="TextoCadastro_BGBranco" Height="16px" 
                Text="Entrega Prevista:"></asp:Label>
            </td><td>
            <asp:TextBox ID="txtEntregaI" runat="server" CssClass="CampoCadastro" 
                Width="70px"></asp:TextBox>
            <asp:Label 
                ID="Label11" runat="server" CssClass="TextoCadastro_BGBranco" Height="16px" 
                Text="a:"></asp:Label>
            <asp:TextBox ID="txtEntregaF" runat="server" CssClass="CampoCadastro" 
                Width="70px"></asp:TextBox>
            </td><td style="text-align: right">
            <asp:Label 
                ID="Label8" runat="server" CssClass="TextoCadastro_BGBranco" Height="16px" 
                Text="Situação:"></asp:Label>
            </td><td colspan="2">
            <asp:DropDownList ID="DdlStatus" runat="server" CssClass="CampoCadastro" 
                Width="260px">
                <asp:ListItem Value="0">Solicitado</asp:ListItem>
                <asp:ListItem Value="4">Analisado - aguardando agendamento</asp:ListItem>
                <asp:ListItem Value="5">Aguardando aprovação cliente (Desenv. com custo)</asp:ListItem>
                <asp:ListItem Value="6">Desenvolvimento agendado</asp:ListItem>
                <asp:ListItem Value="1">Em desenvolvimento</asp:ListItem>
                <asp:ListItem Value="2">Desenvolvimento finalizado</asp:ListItem>
                <asp:ListItem Value="3">Entregue/atualizado</asp:ListItem>
                <asp:ListItem Value="7">Desenvolvimento cancelado</asp:ListItem>
                <asp:ListItem Selected="True" Value="99">(Todos)</asp:ListItem>
            </asp:DropDownList>
            </td><td style="text-align: right; vertical-align: bottom" colspan="1">
                <asp:ImageButton ID="BtnNovoRegistro" runat="server" 
            AlternateText="Novo Registro" ImageUrl="~/Imagens/BtnNovoRegistro.png" />
    
            </td></tr></table>
    <div style="text-align: right">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="2" CssClass="TextoCadastro" DataSourceID="SqlDataSource1" 
            ForeColor="#333333" GridLines="None" Width="100%" AllowPaging="True" 
            AllowSorting="True" DataKeyNames="empresa,cod_solicitacao,cod_emitente" 
            EmptyDataText="Nenhuma solicitação cadastrada até o momento" PageSize="20">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" />
            <Columns>
                <asp:BoundField DataField="cod_solicitacao" HeaderText="Nº Solicitação" ReadOnly="True" 
                    SortExpression="cod_solicitacao">
                <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="data_solicitacao" HeaderText="Solicitação" 
                    SortExpression="data_solicitacao" DataFormatString="{0:dd/MM/yy}" >
                <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="previsao_entrega" HeaderText="Previsão" 
                    SortExpression="previsao_entrega" DataFormatString="{0:dd/MM/yy}" >
                <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="assunto" HeaderText="Assunto" ReadOnly="True" 
                    SortExpression="assunto">
                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="urgencia" HeaderText="Urgência" 
                    SortExpression="urgencia">
                <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="descricao_status" HeaderText="Situação" 
                    SortExpression="descricao_status">
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="origem" HeaderText="Origem" 
                    SortExpression="origem" >
                <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="nome" HeaderText="Cliente" SortExpression="nome" >
                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="nome_usuario" HeaderText="Analista" 
                    SortExpression="nome_usuario" >
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="nome_desenvolvedor" HeaderText="Desenvolvedor" 
                    SortExpression="nome_desenvolvedor" >
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="seq_prioridade_cliente" 
                    HeaderText="Seq. Prioridade Cliente" SortExpression="seq_prioridade_cliente">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Editar">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" 
                            CommandArgument='<%# Eval("cod_solicitacao") %>' CommandName="ALTERAR" 
                            ImageUrl="~/Imagens/BtnEditar.png" />
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerSettings FirstPageText="1&nbsp;&nbsp;" LastPageText="Últ." 
                Mode="NumericFirstLast" PageButtonCount="15" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" 
                Font-Names="Verdana" Font-Size="8pt"/>
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                HorizontalAlign="Left" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
            
            
            SelectCommand="call sp_solicitacao_desenvolvimento(:empresa, :cod_solicitacao,:periodo_i, :periodo_f, '',:nome_cliente,:urgencia,:cod_analista,:assunto, :status, if convert(varchar(5),:inicial) = 'True' then 'S' else 'N' endif, if convert(varchar(5),:intermediario) = 'True' then 'S' else 'N' endif, if convert(varchar(5),:final) = 'True' then 'S' else 'N' endif,:entrega_i, :entrega_f, :cod_desenvolvedor, :versao)">
            <SelectParameters>
                <asp:SessionParameter ConvertEmptyStringToNull="False" DbType="String" 
                    Name=":empresa" SessionField="GlEmpresa" />
                <asp:ControlParameter ControlID="TxtCodSolicitacao" 
                    ConvertEmptyStringToNull="False" DbType="String" Name=":cod_solicitacao" 
                    PropertyName="Text" />
                <asp:ControlParameter ControlID="txtPeriodoI" ConvertEmptyStringToNull="False" 
                    DbType="String" Name=":periodo_i" PropertyName="Text" />
                <asp:ControlParameter ControlID="txtPeriodoF" ConvertEmptyStringToNull="False" 
                    DbType="String" Name=":periodo_f" PropertyName="Text" />
                <asp:ControlParameter ControlID="TxtNomeCliente" 
                    ConvertEmptyStringToNull="False" DbType="String" Name=":nome_cliente" 
                    PropertyName="Text" />
                <asp:ControlParameter ControlID="ddlUrgencia" ConvertEmptyStringToNull="False" 
                    DbType="String" Name=":urgencia" PropertyName="SelectedValue" />
                <asp:ControlParameter ControlID="ddlAnalista" ConvertEmptyStringToNull="False" 
                    DbType="String" Name=":cod_analista" PropertyName="SelectedValue" />
                <asp:ControlParameter ControlID="TxtAssunto" ConvertEmptyStringToNull="False" 
                    DbType="String" Name=":assunto" PropertyName="Text" />
                <asp:ControlParameter ControlID="DdlStatus" ConvertEmptyStringToNull="False" 
                    DbType="String" Name=":status" PropertyName="SelectedValue" />
                <asp:ControlParameter ControlID="CbxInicial" ConvertEmptyStringToNull="False" 
                    DbType="String" Name=":inicial" PropertyName="Checked" />
                <asp:ControlParameter ControlID="CbxIntermediario" 
                    ConvertEmptyStringToNull="False" DbType="String" Name=":intermediario" 
                    PropertyName="Checked" />
                <asp:ControlParameter ControlID="CbxFinal" ConvertEmptyStringToNull="False" 
                    DbType="String" Name=":final" PropertyName="Checked" />
                <asp:ControlParameter ControlID="txtEntregaI" ConvertEmptyStringToNull="False" 
                    DbType="String" Name=":entrega_i" PropertyName="Text" />
                <asp:ControlParameter ControlID="txtEntregaF" ConvertEmptyStringToNull="False" 
                    DbType="String" Name=":entrega_f" PropertyName="Text" />
                <asp:ControlParameter ControlID="ddlDesenvolvedor" ConvertEmptyStringToNull="False" 
                    DbType="String" Name=":cod_desenvolvedor" PropertyName="SelectedValue" />
                <asp:ControlParameter ControlID="DdlReleaseVersaoBanco" 
                    ConvertEmptyStringToNull="False" DbType="String" Name=":versao" 
                    PropertyName="SelectedValue" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
