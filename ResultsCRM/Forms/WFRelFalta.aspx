<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFRelFalta.aspx.vb" Inherits="ResultsCRM.WFRelFalta" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="TituloRelatorio"> 
        <asp:ScriptManager ID="ScriptManager1" runat="server" 
            EnableScriptGlobalization="True">
        </asp:ScriptManager>
        Relatório de
        Faltas de Agente Técnico</div>
    <div>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Estabelecimento:" 
            style="text-align: right" Width="110px" Height="18px"></asp:Label>
        <asp:DropDownList ID="DdlEstabelecimento" runat="server" 
            CssClass="CampoCadastro" Width="225px">
        </asp:DropDownList>
        <asp:Label ID="Label5" runat="server" Text="Período:" style="text-align: right" 
            Width="85px" Height="18px"></asp:Label>
        <asp:TextBox ID="TxtDataI" runat="server" CssClass="CampoCadastro" Width="75px"></asp:TextBox><ajaxToolkit:CalendarExtender id="CalendarExtender11" runat="server" firstdayofweek="Sunday" 
                        format="dd/MM/yyyy" targetcontrolid="TxtDataI" todaysdateformat="d MMMM yyyy"></ajaxToolkit:CalendarExtender>
        <ajaxToolkit:MaskedEditExtender ID="TxtDataI_MaskedEditExtender" runat="server" 
            BehaviorID="TxtDataI_MaskedEditExtender" Century="2000" 
            CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
            CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
            CultureThousandsPlaceholder="" CultureTimePlaceholder="" 
            MaskType="Date" TargetControlID="TxtDataI" UserDateFormat="DayMonthYear" 
            Mask="99/99/9999" />
        <asp:Label ID="Label7" runat="server" Text="&nbsp;a:&nbsp;" 
            style="text-align: right" Height="18px"></asp:Label>
        <asp:TextBox ID="TxtDataF" runat="server" CssClass="CampoCadastro" Width="75px"></asp:TextBox></asp:TextBox><ajaxToolkit:CalendarExtender id="CalendarExtender01" runat="server" firstdayofweek="Sunday" 
                        format="dd/MM/yyyy" targetcontrolid="TxtDataF" todaysdateformat="d MMMM yyyy"></ajaxToolkit:CalendarExtender>
        <ajaxToolkit:MaskedEditExtender ID="TxtDataF_MaskedEditExtender" runat="server" 
            BehaviorID="TxtDataF_MaskedEditExtender" Century="2000" 
            CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
            CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
            CultureThousandsPlaceholder="" CultureTimePlaceholder="" 
            MaskType="Date" TargetControlID="TxtDataF" UserDateFormat="DayMonthYear" 
            Mask="99/99/9999" />
        <asp:Label ID="Label8" runat="server" Text="Justificadas:" 
            style="text-align: right" Width="100px" Height="18px"></asp:Label>
        <asp:DropDownList ID="DdlJustificadas" runat="server" CssClass="CampoCadastro" 
            Width="75px">
            <asp:ListItem Value="S">Sim</asp:ListItem>
            <asp:ListItem Value="N">Não</asp:ListItem>
            <asp:ListItem Selected="True" Value="A">Todas</asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Agente Técnico:" 
            style="text-align: right" Width="110px" Height="18px"></asp:Label>
        <asp:DropDownList ID="DdlAgenteTecnico" runat="server" CssClass="CampoCadastro" 
            Width="225px">
        </asp:DropDownList>
        <asp:Label ID="Label6" runat="server" Text="Motivo:" style="text-align: right" 
            Width="85px" Height="18px"></asp:Label>
        <asp:TextBox ID="TxtMotivo" runat="server" CssClass="CampoCadastro" 
            Width="180px"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="BtnLimparFiltro" runat="server" 
            Text="Limpar Filtros" />
        &nbsp;<asp:Button ID="BtnPesquisar" runat="server" Text="Pesquisar" />
        &nbsp;<asp:ImageButton ID="ImageButton1" runat="server" 
                        ImageUrl="~/Imagens/BtnExcel.png" ToolTip="Download no formato Excel" />
        <br />
        <br />
    </div>
    <div class="TextoCadastro_BGBranco">
    
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" 
            DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" 
            Width="100%" Font-Size="7pt">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <Columns>
                <asp:BoundField DataField="cod_falta" HeaderText="Código" 
                    SortExpression="cod_falta">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Estabelecimento" SortExpression="nome_abreviado">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("nome_abreviado") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("nome_abreviado") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Agente Técnico" SortExpression="nome">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("nome") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("nome") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:BoundField DataField="data_falta" HeaderText="Data" 
                    SortExpression="data_falta" DataFormatString="{0:dd/MM/yy}">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="hora_inicio" HeaderText="Hora Início" 
                    SortExpression="hora_inicio">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="hora_termino" HeaderText="Hora Término" 
                    SortExpression="hora_termino">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="motivo" HeaderText="Motivo" SortExpression="motivo">
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Justify" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="justificada" HeaderText="Justificada" 
                    SortExpression="justificada">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
            </Columns>
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <EmptyDataTemplate>
                <asp:ImageButton ID="ImageButton1" runat="server" AlternateText="ALTERAR" />
            </EmptyDataTemplate>
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
            SelectCommand="select ft.cod_falta,
       es.estabelecimento,
       es.nome_abreviado,
       ate.cod_agente_tecnico,
       ate.nome,
       ft.data_falta,
       ft.hora_inicio,
       ft.hora_termino,
       ft.motivo,
       ft.justificada
  from falta_tecnico ft inner join agente_tecnico ate on ft.cod_agente_tecnico = ate.cod_agente_tecnico
                        inner join estabelecimento es on es.empresa = ft.empresa and es.estabelecimento = ft.estabelecimento
 where ft.empresa            = :empresa
   and ft.estabelecimento    = :estabelecimento
   and :cod_agente_tecnico in (0, ft.cod_agente_tecnico)
   and ft.data_falta between if :datai1 = '' then '1900-01-01' else convert(date,:datai2,103) endif and if :dataf1 = '' then '2900-12-31' else convert(date, :dataf2, 103) endif 
   and (:motivo1 = '' or ft.motivo like '%' || :motivo2 || '%')
   and :justificada in ('A', ft.justificada)
 order by data_falta, cod_falta">
            <SelectParameters>
                <asp:SessionParameter Name=":empresa" SessionField="GlEmpresa" 
                    ConvertEmptyStringToNull="False" DbType="String" />
                <asp:ControlParameter ControlID="DdlEstabelecimento" 
                    ConvertEmptyStringToNull="False" DbType="String" Name=":estabelecimento" 
                    PropertyName="SelectedValue" />
                <asp:ControlParameter ControlID="DdlAgenteTecnico" 
                    ConvertEmptyStringToNull="False" DbType="String" Name=":cod_agente_tecnico" 
                    PropertyName="SelectedValue" />
                <asp:ControlParameter ControlID="TxtDataI" ConvertEmptyStringToNull="False" 
                    DbType="String" Name=":datai1" PropertyName="Text" />
                <asp:ControlParameter ControlID="TxtDataI" ConvertEmptyStringToNull="False" 
                    DbType="String" Name=":datai2" PropertyName="Text" />
                <asp:ControlParameter ControlID="TxtDataF" ConvertEmptyStringToNull="False" 
                    DbType="String" Name=":dataf1" PropertyName="Text" />
                <asp:ControlParameter ControlID="TxtDataF" ConvertEmptyStringToNull="False" 
                    DbType="String" Name=":dataf2" PropertyName="Text" />
                <asp:ControlParameter ControlID="TxtMotivo" ConvertEmptyStringToNull="False" 
                    DbType="String" Name=":motivo1" PropertyName="Text" />
                <asp:ControlParameter ControlID="TxtMotivo" ConvertEmptyStringToNull="False" 
                    DbType="String" Name=":motivo2" PropertyName="Text" />
                <asp:ControlParameter ControlID="DdlJustificadas" 
                    ConvertEmptyStringToNull="False" DbType="String" Name=":justificada" 
                    PropertyName="SelectedValue" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>

