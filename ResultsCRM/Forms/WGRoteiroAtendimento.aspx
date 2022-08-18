<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGRoteiroAtendimento.aspx.vb" Inherits="ResultsCRM.WGRoteiroAtendimento" ClientIDMode="Static" %>
<%@ Register assembly="WebDataWindow" namespace="Sybase.DataWindow.Web" tagprefix="dw" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
    <script language="javascript" src="../ResultsCRM.js" type="text/javascript"> </script>
    <style type="text/css"> </style>
</head>
<body style="padding: 0px; width: 100%; text-align: left; top: 0px; height: 100%; min-height: 100%; margin: 0px; clip: rect(auto auto auto auto)">
    <form id="form1" runat="server">
    <div>
     <asp:ScriptManager ID="ScriptManager1" runat="server" 
            EnableScriptGlobalization="True" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                    <ProgressTemplate>
                        <div style="text-align:center; position: fixed; top: 10%; right: 46%; z-index: 10;">
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagens/carregando.gif" />
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
        <div class="TituloMovimento">Roteiros de Atendimento</div>
        <div>
    
            <table style="border: thin groove #CCCCCC; width:100%; font-family: verdana; font-size: 7pt; border-collapse: collapse;" 
                class="TextoCadastro_BGBranco">
               
                <tr>
                    <td class="Erro" colspan="5">
                        <asp:Label ID="LblErro" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">
                        Agente Técnico:</td>
                    <td>
                        <asp:DropDownList ID="DdlAgenteTecnico" runat="server" CssClass="CampoCadastro" 
                            Width="300px">
                        </asp:DropDownList>
                    </td>
                    <td style="text-align: right">
                        Data:</td>
                    <td>
                        <asp:TextBox ID="TxtDataI" runat="server" CssClass="CampoCadastro" 
                            MaxLength="10" style="text-align:center" Width="90px"></asp:TextBox><ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" 
                        TargetControlID="TxtDataI" FirstDayOfWeek="Sunday"
                        Format="dd/MM/yyyy" TodaysDateFormat="d MMMM yyyy"></ajaxToolkit:CalendarExtender>
                        <asp:Label ID="Label9" runat="server" Height="17px" 
                            Text="&nbsp;&nbsp;a:&nbsp;&nbsp;"></asp:Label>
                        <asp:TextBox ID="TxtDataF" runat="server" CssClass="CampoCadastro" 
                            MaxLength="10" style="text-align:center" Width="90px"></asp:TextBox><ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" 
                        TargetControlID="TxtDataF" FirstDayOfWeek="Sunday"
                        Format="dd/MM/yyyy" TodaysDateFormat="d MMMM yyyy"></ajaxToolkit:CalendarExtender>
                    </td>
                    <td style="text-align: right">
                        <asp:Button ID="BtnAplicarFiltro" runat="server" Text="Aplicar Filtro" />
                        &nbsp;
                        <asp:Button ID="BtnIncluir" runat="server" Text="Novo Registro" />
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="5">
                        <asp:GridView ID="GridView1" runat="server" AllowSorting="True" 
                            AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource1" 
                            ForeColor="#333333" GridLines="None" PageSize="14" Width="100%">
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" />
                            <Columns>
                                <asp:BoundField DataField="cod_roteiro" HeaderText="Roteiro" ReadOnly="True" 
                                    SortExpression="cod_roteiro">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Agente Técnico" SortExpression="nome">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("nome") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("nome") %>'></asp:Label>
                                        (<asp:Label ID="Label10" runat="server" 
                                            Text='<%# Eval("cod_agente_tecnico") %>'></asp:Label>
                                        )
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="data_atendimento" HeaderText="Data" 
                                    SortExpression="data_atendimento" DataFormatString="{0:dd/MM/yyyy}">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                </asp:BoundField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImageButton2" runat="server" 
                                            CommandArgument='<%# Eval("cod_roteiro") %>' CommandName="ALTERAR" 
                                            ImageUrl="~/Imagens/BtnEditar.png" 
                                            ToolTip="Clique para alterar ou consultar o registro" />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="60px" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImageButton3" runat="server" 
                                            CommandArgument='<%# Eval("cod_roteiro") %>' CommandName="EMAIL" 
                                            ImageUrl="~/Imagens/BtnEnviaEmail.png" 
                                            onclientclick="return confirm('Deseja enviar este roteiro por e-mail para o agente técnico?')" 
                                            ToolTip="Enviar roteiro por e-mail para o agente técnico" Width="23px" />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="60px" />
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <PagerSettings FirstPageText="1&nbsp;&nbsp;" LastPageText="Últ." 
                                Mode="NumericFirstLast" PageButtonCount="15" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                                HorizontalAlign="Left" />
                            <EditRowStyle BackColor="#999999" />
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
                            SelectCommand="select ra.empresa, ra.estabelecimento, ra.cod_roteiro, ra.cod_agente_tecnico, ate.nome, ra.data_atendimento
  from roteiro_atendimento ra inner join agente_tecnico ate on ate.cod_agente_tecnico = ra.cod_agente_tecnico
 where ra.empresa = :empresa
   and ra.estabelecimento = :estabelecimento
   and (isnull(:cod_agente_tecnico1,'') = '' or isnull(:cod_agente_tecnico2,'') = '0' or isnull(:cod_agente_tecnico3,'') = ra.cod_agente_tecnico)
   and ( (isnull(:data_i1,'') = '' and (isnull(:data_f1,'') = '')) or ( date(ra.data_atendimento) between convert(date, isnull(:data_i2,''), 103) and convert(date, isnull(:data_f2,''), 103) ) )
order by ra.data_atendimento desc, ra.cod_roteiro desc">
                            <SelectParameters>
                                <asp:SessionParameter Name=":empresa" SessionField="GlEmpresa" 
                                    DefaultValue="" ConvertEmptyStringToNull="False" DbType="String" />
                                <asp:SessionParameter Name=":estabelecimento" 
                                    SessionField="GlEstabelecimento" ConvertEmptyStringToNull="False" 
                                    DbType="String" />
                                <asp:ControlParameter ControlID="DdlAgenteTecnico" 
                                    ConvertEmptyStringToNull="False" DbType="String" Name=":cod_agente_tecnico1" 
                                    PropertyName="SelectedValue" />
                                <asp:ControlParameter ControlID="DdlAgenteTecnico" 
                                    ConvertEmptyStringToNull="False" DbType="String" Name=":cod_agente_tecnico2" 
                                    PropertyName="SelectedValue" />
                                <asp:ControlParameter ControlID="DdlAgenteTecnico" 
                                    ConvertEmptyStringToNull="False" DbType="String" Name=":cod_agente_tecnico3" 
                                    PropertyName="SelectedValue" />
                                <asp:ControlParameter ControlID="TxtDataI" ConvertEmptyStringToNull="False" 
                                    DbType="String" Name=":data_i1" PropertyName="Text" />
                                <asp:ControlParameter ControlID="TxtDataF" ConvertEmptyStringToNull="False" 
                                    DbType="String" Name=":data_f1" PropertyName="Text" />
                                <asp:ControlParameter ControlID="TxtDataI" ConvertEmptyStringToNull="False" 
                                    DbType="String" Name=":data_i2" PropertyName="Text" />
                                <asp:ControlParameter ControlID="TxtDataF" ConvertEmptyStringToNull="False" 
                                    DbType="String" Name=":data_f2" PropertyName="Text" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </td>
                </tr>
            </table>
    
            </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
