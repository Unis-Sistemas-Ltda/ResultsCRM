<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGAvaliacao.aspx.vb" Inherits="ResultsCRM.WGAvaliacao" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server" defaultbutton="BtnPesquisar">
    <div class="TituloCadastro">
        Painel de Avaliações<asp:ScriptManager ID="ScriptManager1" 
            runat="server">
        </asp:ScriptManager>
    </div>
    <table style="width: 100%; border-collapse: collapse;">
        <tr>
            <td style="text-align: right">
                        Período:</td>
            <td>
                        <asp:TextBox ID="TxtDataI" runat="server" CssClass="CampoCadastro" 
                            MaxLength="10" style="text-align: center" Width="70px"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" 
                        TargetControlID="TxtDataI" FirstDayOfWeek="Sunday"
                        Format="dd/MM/yyyy" TodaysDateFormat="d MMMM yyyy"></ajaxToolkit:CalendarExtender>
                        <ajaxToolkit:MaskedEditExtender ID="TxtDataI_MaskedEditExtender" runat="server" 
                            BehaviorID="TxtDataI_MaskedEditExtender" Century="2000" 
                            CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                            CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                            CultureThousandsPlaceholder="" CultureTimePlaceholder="" Mask="99/99/9999" 
                            MaskType="Date" TargetControlID="TxtDataI" 
                    UserDateFormat="DayMonthYear" />
                        <asp:Label ID="Label18" runat="server" Height="17px" 
                    Text="&nbsp;a&nbsp;"></asp:Label>
                        <asp:TextBox ID="TxtDataF" runat="server" CssClass="CampoCadastro" 
                            MaxLength="10" style="text-align: center" Width="70px"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" 
                        TargetControlID="TxtDataF" FirstDayOfWeek="Sunday"
                        Format="dd/MM/yyyy" TodaysDateFormat="d MMMM yyyy"></ajaxToolkit:CalendarExtender>
                        <ajaxToolkit:MaskedEditExtender ID="TxtDataF_MaskedEditExtender" runat="server" 
                            BehaviorID="TxtDataF_MaskedEditExtender" Century="2000" 
                            CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                            CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                            CultureThousandsPlaceholder="" CultureTimePlaceholder="" Mask="99/99/9999" 
                            MaskType="Date" TargetControlID="TxtDataF" 
                    UserDateFormat="DayMonthYear" />
            </td>
            <td style="text-align: right">
            &nbsp;Cód. Cliente:</td>
            <td>
                        <asp:TextBox ID="TxtCodEmitente" runat="server"
                            CssClass="CampoCadastro" Width="60px" AutoPostBack="True"></asp:TextBox>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                        <asp:Label ID="Label11" runat="server" Height="16px" Text="Avaliador:"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="DdlAvaliador" runat="server" 
                            CssClass="CampoCadastro" Width="180px">
                        </asp:DropDownList>
            </td>
            <td style="text-align: right">
                Nome Cliente:</td>
            <td>
                        <asp:TextBox ID="TxtNomeEmitente" runat="server" CssClass="CampoCadastro" 
                            ToolTip="Informe o nome ou parte do nome do cliente." 
                    Width="175px"></asp:TextBox>
            </td>
            <td style="text-align: right">
                        <asp:Button ID="BtnPesquisar" runat="server" Text="Pesquisar" />
                        &nbsp;<asp:Button ID="BtnNovoRegistro" runat="server" 
                    Text="Novo Registro" />
            </td>
        </tr>
    </table>
    <div style="text-align: right">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" EmptyDataText="Nenhum registro foi cadastrado até o momento."
            CellPadding="4" CssClass="TextoCadastro" DataSourceID="SqlDataSource1" ForeColor="#333333"
            GridLines="None" Width="100%" AllowPaging="True" AllowSorting="True">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" />
            <Columns>
                <asp:BoundField DataField="cod_avaliacao" HeaderText="Código" ReadOnly="True" SortExpression="cod_avaliacao">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="data_avaliacao" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Data"
                    SortExpression="data_avaliacao">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="descricao_tipo_avaliacao" HeaderText="Tipo Avaliação"
                    SortExpression="descricao_tipo_avaliacao">
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Cliente" SortExpression="nome_emitente">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("nome_emitente") %>'></asp:Label>
                        (<asp:Label ID="Label3" runat="server" Text='<%# Eval("cod_emitente") %>'></asp:Label>
                        )
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("nome_emitente") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Avaliador" SortExpression="nome_avaliador">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("nome_avaliador") %>'></asp:Label>
                        (<asp:Label ID="Label4" runat="server" Text='<%# Eval("cod_avaliador") %>'></asp:Label>
                        )
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("nome_avaliador") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" CommandArgument='<%# Eval("cod_avaliacao") %>'
                            CommandName="ALTERAR" ImageUrl="~/Imagens/BtnEditar.png" 
                            ToolTip="Detalhes do Registro" />
                        &nbsp;<asp:ImageButton ID="ImageButton2" runat="server" CommandArgument='<%# Eval("cod_avaliacao") %>'
                            CommandName="EXCLUIR" ImageUrl="~/Imagens/BtnExcluir.png" OnClientClick="return confirm('Deseja realmente excluir o registro?')"
                            ToolTip="Excluir registro" Width="16px" />
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" Width="50px" />
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select av.cod_avaliacao, av.cod_tipo_avaliacao, ta.descricao descricao_tipo_avaliacao, av.cod_emitente, e.nome nome_emitente, av.data_avaliacao, av.cod_avaliador, ua.nome_usuario nome_avaliador
  from avaliacao_cliente av inner join tipo_avaliacao ta on ta.empresa = av.empresa and ta.cod_tipo_avaliacao = av.cod_tipo_avaliacao
                            inner join emitente e on e.cod_emitente = av.cod_emitente
                            inner join sysusuario ua on ua.cod_usuario = av.cod_avaliador
 where av.empresa = :empresa
     and date(av.data_avaliacao) between convert(date,f_isnull_or_empty(:data_i,'01/01/1900'),103) and convert(date,f_isnull_or_empty(:data_f,'31/12/2999'),103)
     and :cod_avaliador in (av.cod_avaliador, 0)
     and av.cod_emitente = f_isnull_or_empty(:cod_emitente,av.cod_emitente)
     and e.nome like '%' || replace(:nome_emitente,'+','%') || '%'
  order by av.cod_avaliacao desc">
            <SelectParameters>
                <asp:SessionParameter Name=":empresa" SessionField="GlEmpresa" />
                <asp:ControlParameter ControlID="TxtDataI" ConvertEmptyStringToNull="False" 
                    DbType="String" Name=":data_i" PropertyName="Text" />
                <asp:ControlParameter ControlID="TxtDataF" ConvertEmptyStringToNull="False" 
                    DbType="String" Name=":data_f" PropertyName="Text" />
                <asp:ControlParameter ControlID="DdlAvaliador" ConvertEmptyStringToNull="False" 
                    DbType="String" Name=":cod_avaliador" PropertyName="SelectedValue" />
                <asp:ControlParameter ControlID="TxtCodEmitente" 
                    ConvertEmptyStringToNull="False" DbType="String" Name=":cod_emitente" 
                    PropertyName="Text" />
                <asp:ControlParameter ControlID="TxtNomeEmitente" 
                    ConvertEmptyStringToNull="False" DbType="String" Name=":nome_emitente" 
                    PropertyName="Text" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>
    </form>
</body>
</html>
