<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGTarefas.aspx.vb" Inherits="ResultsCRM.WGTarefas" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register src="../OutrosControles/TextBoxData.ascx" tagname="TextBoxData" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Tarefas do usuário</title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server" class="TextoCadastro_BGBranco">
    <asp:ScriptManager 
        ID="ScriptManager1" runat="server" EnableScriptGlobalization="True">
    </asp:ScriptManager>
    <table style="border: thin groove #CCCCCC; width:100%;">
        <tr>
            <td class="TituloMovimento" colspan="3">
    
                Painel de Tarefas</td>
        </tr>
        <tr>
            <td class="CelulaCampoCadastro" style="font-weight: bold">
                Mostrar:</td>
            <td rowspan="2" style="text-align: right">
                <table>
                    <tr>
                        <td colspan="4" style="font-weight: bold">
                <asp:Label ID="LblDataInicial" runat="server" Visible="False"></asp:Label>
                <asp:Label ID="LblDataFinal" runat="server" Visible="False"></asp:Label>
                Período Previsão:</td>
                    </tr>
                    <tr>
                        <td width="230px">
                <asp:RadioButtonList ID="RblPeriodo" runat="server" AutoPostBack="True" 
                    RepeatColumns="4" Width="310px">
                    <asp:ListItem Value="H">Hoje</asp:ListItem>
                    <asp:ListItem Selected="True" Value="S">Esta semana</asp:ListItem>
                    <asp:ListItem Value="M">Este mês</asp:ListItem>
                    <asp:ListItem Value="A">Este ano</asp:ListItem>
                </asp:RadioButtonList>
                        </td>
                        <td width="95px">
                <asp:TextBox ID="TxtDataInicial" runat="server" CssClass="CampoCadastro" 
                    style="text-align: center" Width="80px"></asp:TextBox><ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" 
                        TargetControlID="TxtDataInicial" FirstDayOfWeek="Sunday"
                        Format="dd/MM/yyyy" TodaysDateFormat="d MMMM yyyy"></ajaxToolkit:CalendarExtender>
                        </td>
                        <td width="15px">
                            a</td>
                        <td width="95px">
                <asp:TextBox ID="TxtDataFinal" runat="server" CssClass="CampoCadastro" 
                    style="text-align: center" Width="90px"></asp:TextBox><ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" 
                        TargetControlID="TxtDataFinal" FirstDayOfWeek="Sunday"
                        Format="dd/MM/yyyy" TodaysDateFormat="d MMMM yyyy"></ajaxToolkit:CalendarExtender>
                        </td>
                    </tr>
                </table>
            </td>
            <td rowspan="3" style="text-align: right; vertical-align: bottom;">
                <asp:Button ID="BtnFiltrar" runat="server" CssClass="Botao" Text="Filtrar" />
            </td>
        </tr>
        <tr>
            <td class="CelulaCampoCadastro">
                <asp:RadioButtonList ID="RblTipo" runat="server" CssClass="CampoCadastro" 
                    RepeatColumns="2">
                    <asp:ListItem Selected="True" Value="P">Pendentes</asp:ListItem>
                    <asp:ListItem Value="T">Todas</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td class="CelulaCampoCadastro" colspan="2">
                <asp:Label ID="Label5" runat="server" Height="18px" Text="Responsável:"></asp:Label>
                <asp:DropDownList ID="DdlAgenteVendas" runat="server" CssClass="CampoCadastro" 
                    Width="300px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="3">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="1" DataSourceID="SqlDataSource1" ForeColor="#333333" 
            GridLines="None" Width="100%" AllowSorting="True">
            <PagerSettings FirstPageText="1&nbsp;" LastPageText="Última" 
                Mode="NumericFirstLast" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Center" />
            <Columns>
                <asp:BoundField DataField="nome_usuario" HeaderText="Responsável" 
                    SortExpression="nome_usuario" >
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Cliente" SortExpression="nome_cliente">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Font-Italic="False" 
                            Text='<%# Bind("nome_cliente") %>'></asp:Label>
                        <br />
                        <asp:Label ID="Label2" runat="server" Font-Italic="True" 
                            Text='<%# Eval("nome") %>'></asp:Label>
                        <asp:Label ID="Label3" runat="server" Font-Italic="True" 
                            Text='<%# Eval("email") %>'></asp:Label>
                        <asp:Label ID="Label4" runat="server" Font-Italic="True" 
                            Text='<%# Eval("fones") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("nome_cliente") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:BoundField DataField="cod_negociacao_cliente" HeaderText="Negociação" 
                    SortExpression="cod_negociacao_cliente" />
                <asp:BoundField DataField="seq_tarefa" HeaderText="Seq. Tarefa" 
                    SortExpression="seq_tarefa" Visible="False" />
                <asp:BoundField DataField="descricao_resumida" HeaderText="Tarefa" 
                    SortExpression="descricao_resumida">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="prioridade" HeaderText="Prioridade" 
                    SortExpression="prioridade" />
                <asp:BoundField DataField="previsao_finalizacao" 
                    DataFormatString="{0:dd/MM/yyyy}" HeaderText="Previsão" 
                    SortExpression="previsao_finalizacao" />
                <asp:BoundField DataField="situacao" HeaderText="Situação" 
                    SortExpression="situacao" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" 
                            
                            CommandArgument='<%# Eval("cod_negociacao_cliente", "{0:00000000}") & Eval("seq_tarefa", "{0:0000}") %>' CommandName="ALTERAR" 
                            ImageUrl="~/Imagens/BtnEditar.png" ToolTip="Detalhes do Registro" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                HorizontalAlign="Center" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="3">
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
                    
                    
                    SelectCommand="select :cod_usuario usuarioselecionado,
       usu.cod_usuario,
       usu.nome_usuario,
       nt.cod_negociacao_cliente, 
       seq_tarefa, 
       tp.descricao_resumida, 
       case nt.prioridade when 'A' then 'Alta' when 'B' then 'Baixa' when 'M' then 'Média' end prioridade, 
       previsao_finalizacao, 
       case nt.situacao when 1 then 'Aguardando retorno do cliente' when 2 then 'Aguardar' when 3 then 'Cancelada' when 4 then 'Concluída' when 5 then 'Em andamento' when 6 then 'Não iniciada' end situacao,
       e.nome || ' (' || e.cod_emitente || ')' nome_cliente,
       ct.nome,
       if trim(isnull(ct.email,'')) &lt;&gt; '' then '(' || ct.email || ')' else null endif email,


       trim(isnull(ct.telefone,'')) || if trim(isnull(ct.telefone,'')) not in ('','0','00') then '; ' else '' endif ||
       trim(isnull(ct.telefone2,'')) || if trim(isnull(ct.telefone2,'')) not in ('','0','00') then '; ' else '' endif ||
       trim(isnull(ct.celular,'')) || if trim(isnull(ct.celular,'')) not in ('','0','00') then '; ' else '' endif ||
       trim(isnull(ct.celular2,'')) telefone,

       if trim(replace(replace(telefone,';',''),'0','')) &lt;&gt; '' then 'Fone:' || telefone else '' endif fones

  from negociacao_tarefa nt inner join tarefa_padrao tp on nt.cod_tarefa_padrao = tp.cod_tarefa_padrao
                            left outer join negociacao_cliente nc on nt.empresa = nc.empresa and nt.estabelecimento = nc.estabelecimento and nt.cod_negociacao_cliente = nc.cod_negociacao_cliente
                            left outer join emitente e on e.cod_emitente = nc.cod_emitente
                            left outer join contatos ct on ct.cod_emitente = nc.cod_emitente and ct.cod_contato = nc.cod_contato
                            inner join sysusuario usu on usu.cod_usuario = nt.cod_responsavel
 where ( (:mostrar = 'P' and nt.situacao in (1, 2, 5, 6)) or (:mostrar2 = 'T' ) )
   and nt.cod_responsavel = if trim(isnull(usuarioselecionado,'')) = '' or trim(isnull(usuarioselecionado,'')) = '0' then nt.cod_responsavel else usuarioselecionado endif
   and previsao_finalizacao between if isnull(:data_i,'') = '' then previsao_finalizacao else :data_i2 endif and if isnull(:data_f,'') = '' then previsao_finalizacao else :data_f2 endif
order by previsao_finalizacao, nt.cod_negociacao_cliente, nt.seq_tarefa">
            <SelectParameters>
                <asp:ControlParameter ControlID="DdlAgenteVendas" Name=":cod_usuario" 
                    PropertyName="SelectedValue" />
                <asp:ControlParameter ControlID="RblTipo" Name=":mostrar" 
                    PropertyName="SelectedValue" />
                <asp:ControlParameter ControlID="RblTipo" Name=":mostar2" 
                    PropertyName="SelectedValue" />
                <asp:ControlParameter ControlID="LblDataInicial" 
                    ConvertEmptyStringToNull="False" Name=":data_i" PropertyName="Text" />
                <asp:ControlParameter ControlID="LblDataInicial" Name=":data_i2" 
                    PropertyName="Text" />
                <asp:ControlParameter ControlID="LblDataFinal" ConvertEmptyStringToNull="False" 
                    Name=":data_f" PropertyName="Text" />
                <asp:ControlParameter ControlID="LblDataFinal" Name=":data_f2" 
                    PropertyName="Text" />
            </SelectParameters>
                </asp:SqlDataSource>
    
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
