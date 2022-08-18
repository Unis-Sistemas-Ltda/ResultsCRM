<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFRelFMEA.aspx.vb" Inherits="ResultsCRM.WFRelFMEA" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
    <link href="../ResultsCRMAjax.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="../ResultsCRM.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" 
        EnableScriptGlobalization="True"></asp:ScriptManager>
    <div class="TituloRelatorio">
        Registros de Falha</div>
    <table width="100%" style="border-collapse: collapse"><tr><td class="Erro" 
            colspan="4" style="border-collapse: collapse">
        <asp:Label ID="LblErro" runat="server"></asp:Label>
        </td></tr><tr><td style="border-collapse: collapse; text-align: right">Período:</td>
            <td style="border-collapse: collapse">
        <asp:TextBox ID="TxtDataI" runat="server" CssClass="CampoCadastro" Width="75px"></asp:TextBox>
                <cc1:CalendarExtender id="CalendarExtender11" runat="server" firstdayofweek="Sunday" 
                        format="dd/MM/yyyy" targetcontrolid="TxtDataI" 
                    todaysdateformat="d MMMM yyyy"></cc1:CalendarExtender>
        <cc1:MaskedEditExtender ID="TxtDataI_MaskedEditExtender" runat="server" 
            BehaviorID="TxtDataI_MaskedEditExtender" Century="2000" 
            CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
            CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
            CultureThousandsPlaceholder="" CultureTimePlaceholder="" 
            MaskType="Date" TargetControlID="TxtDataI" UserDateFormat="DayMonthYear" 
            Mask="99/99/9999" />
        <asp:Label ID="Label7" runat="server" Text="&nbsp;a:&nbsp;" 
            style="text-align: right" Height="18px"></asp:Label>
        <asp:TextBox ID="TxtDataF" runat="server" CssClass="CampoCadastro" Width="75px"></asp:TextBox>
                <cc1:CalendarExtender id="CalendarExtender01" runat="server" firstdayofweek="Sunday" 
                        format="dd/MM/yyyy" targetcontrolid="TxtDataF" 
                    todaysdateformat="d MMMM yyyy"></cc1:CalendarExtender>
        <cc1:MaskedEditExtender ID="TxtDataF_MaskedEditExtender" runat="server" 
            BehaviorID="TxtDataF_MaskedEditExtender" Century="2000" 
            CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
            CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
            CultureThousandsPlaceholder="" CultureTimePlaceholder="" 
            MaskType="Date" TargetControlID="TxtDataF" UserDateFormat="DayMonthYear" 
            Mask="99/99/9999" />
            </td><td style="border-collapse: collapse; text-align: right">Cliente:</td>
            <td style="border-collapse: collapse">
                <asp:TextBox ID="TxtCodCliente" runat="server" CssClass="CampoCadastro" 
                    Width="60px" AutoPostBack="True"></asp:TextBox>
                <asp:ImageButton ID="BtnFiltrarCliente" runat="server" 
                ImageUrl="~/Imagens/search.png" ToolTip="Pesquisar" 
                onclientclick="ShowEditModal('../Pesquisas/WFPCliente.aspx?textbox=TxtCliente&amp;varmp=SCodClientePesquisado&amp;varma=SAlterouCodCliente','EditModalPopupClientes','IframeEdit');" 
                Height="16px" Width="16px" />
    <cc1:ModalPopupExtender ID="ModalPopupExtender2" BackgroundCssClass="ModalPopupBG"
        runat="server" CancelControlID="ButtonEditCancel" OkControlID="ButtonEditDone" 
        TargetControlID="BtnFiltrarCliente" PopupControlID="DivEditWindow" 
        OnCancelScript="EditCancelScript('IframeEdit');" OnOkScript="EditOkayScript('IframeEdit');"
        BehaviorID="EditModalPopupClientes">
    </cc1:ModalPopupExtender>
            <asp:Label ID="LblNomeCliente" runat="server" Font-Bold="False" Height="17px"></asp:Label>
            </td></tr><tr><td style="border-collapse: collapse; text-align: right">
            Grupo de Problema /
            Categoria:</td>
        <td style="border-collapse: collapse">
            <asp:DropDownList ID="DdlGrupoProblema" runat="server" CssClass="CampoCadastro" 
                Width="250px" AutoPostBack="True">
            </asp:DropDownList>
        </td><td style="border-collapse: collapse; text-align: right">Equipamento:</td>
        <td style="border-collapse: collapse">
            <asp:DropDownList ID="DdlEquipamento" runat="server" 
                CssClass="CampoCadastro" Width="250px">
            </asp:DropDownList>
        </td></tr><tr><td style="border-collapse: collapse; text-align: right">Problema / Modo de 
            Falha:</td><td style="border-collapse: collapse">
                <asp:DropDownList ID="DdlProblema" runat="server" CssClass="CampoCadastro" 
                    Width="250px">
                </asp:DropDownList>
            </td><td style="border-collapse: collapse; text-align: right">Item / Modelo:</td>
            <td style="border-collapse: collapse">
                <asp:TextBox ID="TxtCodItem" runat="server" CssClass="CampoCadastro" 
                    Width="60px" AutoPostBack="True"></asp:TextBox>
                        <asp:ImageButton ID="BtnFiltrarItem" runat="server" 
                ImageUrl="~/Imagens/search.png" ToolTip="Pesquisar" 
                onclientclick="ShowEditModal('../Pesquisas/WFPItem.aspx?textbox=TxtCodItem','EditModalPopupCliente','IframeEdit');" />
    <cc1:ModalPopupExtender ID="ModalPopupExtender1" BackgroundCssClass="ModalPopupBG"
        runat="server" CancelControlID="ButtonEditCancel" OkControlID="ButtonEditDone" 
        TargetControlID="BtnFiltrarItem" PopupControlID="DivEditWindow" 
        OnCancelScript="EditCancelScript('IframeEdit');" OnOkScript="EditOkayScript('IframeEdit');"
        BehaviorID="EditModalPopupCliente">
    </cc1:ModalPopupExtender>
            <asp:Label ID="LblDescricaoItem" runat="server" Font-Bold="False" 
                Height="17px"></asp:Label>
            </td></tr><tr><td style="border-collapse: collapse">&nbsp;</td>
            <td style="border-collapse: collapse">
                <asp:Button ID="BtnAplicarFiltro" runat="server" Text="Pesquisar" />
&nbsp;
                <asp:Button ID="BtnAplicarFiltro0" runat="server" onclientclick="self.print(); return false;" 
                    Text="Imprimir" />
            </td><td style="border-collapse: collapse">&nbsp;</td>
            <td style="border-collapse: collapse">&nbsp;</td></tr><tr><td colspan="4" 
            style="border-collapse: collapse">
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select pp.assunto descricao_problema, gp.descricao descricao_grupo, ch.data_chamado, eq.cod_item, eq.numero_serie, ca.descricao descricao_causa, ch.cod_chamado, usu.nome_usuario
  from chamado_problema cp inner join problema_padrao pp on pp.empresa = cp.empresa and pp.cod_problema = cp.cod_problema
                           inner join grupo_problema gp on gp.empresa = pp.empresa and gp.cod_grupo = pp.cod_grupo
                           inner join chamado ch on ch.empresa = cp.empresa and ch.cod_chamado = cp.cod_chamado
                           left outer join chamado_problema_causa cc on cc.empresa = cp.empresa and cc.cod_chamado = cp.cod_chamado and cc.seq_problema = cp.seq_problema
                           left outer join causa ca on ca.cod_causa = cc.cod_causa
                           inner join equipamento eq on eq.empresa = cp.empresa and eq.numero_serie = cp.numero_serie
                           inner join analista an on an.cod_analista = ch.cod_analista
                           inner join sysusuario usu on usu.cod_usuario = an.cod_analista
 where ch.empresa = :empresa
   and date(ch.data_chamado) between convert(date,f_isnull_or_empty(:data_i,'01/01/1900'),103) and convert(date,f_isnull_or_empty(:data_f,'31/12/2999'),103)
   and :grupo in (0,gp.cod_grupo)
   and :problema in (0,cp.cod_problema)
   and ch.cod_emitente = f_isnull_or_empty(:cliente,ch.cod_emitente)
   and isnull(eq.cod_item,'') = f_isnull_or_empty(:item,isnull(eq.cod_item,''))
 order by ch.data_chamado, cp.seq_problema">
            <SelectParameters>
                <asp:SessionParameter ConvertEmptyStringToNull="False" DbType="String" 
                    Name=":empresa" SessionField="GlEmpresa" />
                <asp:ControlParameter ControlID="TxtDataI" ConvertEmptyStringToNull="False" 
                    DbType="String" Name=":data_i" PropertyName="Text" />
                <asp:ControlParameter ControlID="TxtDataF" ConvertEmptyStringToNull="False" 
                    DbType="String" Name=":data_f" PropertyName="Text" />
                <asp:ControlParameter ControlID="DdlGrupoProblema" 
                    ConvertEmptyStringToNull="False" DbType="String" Name=":grupo" 
                    PropertyName="SelectedValue" />
                <asp:ControlParameter ControlID="DdlProblema" ConvertEmptyStringToNull="False" 
                    DbType="String" Name=":problema" PropertyName="SelectedValue" />
                <asp:ControlParameter ControlID="TxtCodCliente" 
                    ConvertEmptyStringToNull="False" DbType="String" Name=":cliente" 
                    PropertyName="Text" />
                <asp:ControlParameter ControlID="TxtCodItem" ConvertEmptyStringToNull="False" 
                    DbType="String" Name=":item" PropertyName="Text" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:GridView ID="GridView1" runat="server" AllowSorting="True" 
            AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource1" 
            EmptyDataText="Nenhum registro a exibir." ForeColor="#333333" GridLines="None" 
            Width="100%">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="descricao_problema" HeaderText="Modo de Falha" 
                    SortExpression="descricao_problema">
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="descricao_grupo" HeaderText="Categoria" 
                    SortExpression="descricao_grupo">
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="data_chamado" DataFormatString="{0:dd/MM/yyyy}" 
                    HeaderText="Data" SortExpression="data_chamado">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="cod_item" HeaderText="Modelo" 
                    SortExpression="cod_item">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="numero_serie" HeaderText="Número de Série" 
                    SortExpression="numero_serie">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="descricao_causa" HeaderText="Causa Provável" 
                    SortExpression="descricao_causa">
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="cod_chamado" HeaderText="Nº Chamado" 
                    SortExpression="cod_chamado">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="nome_usuario" HeaderText="Analista" 
                    SortExpression="nome_usuario">
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:BoundField>
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        </td></tr></table>
        <%--este é o html para pesquisa de itens--%><%--botões padrão que ficam ocultos, são necessários, não remover--%>
    <div class="popup_Buttons" style="display: none">
        <input id="ButtonEditDone" value="Done" type="button" />
        <input id="ButtonEditCancel" value="Cancel" type="button" />
    </div>
    <%--frame onde é mostrado o popup--%>
    <div id="DivEditWindow" style="display: none;" class="popupConfirmation">
        <iframe id="IframeEdit" frameborder="0" width="370" height="350" scrolling="no">
        </iframe>
    </div>
    </form>
</body>
</html>
