<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGRoteiroVisita.aspx.vb"
    Inherits="ResultsCRM.WGRoteiroVisita" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
    <script language="javascript" src="../ResultsCRM.js" type="text/javascript"> </script>
    <style type="text/css">
        .style1
        {
            font-size: 8pt;
            text-align: left;
            color: #CC0000;
            font-family: verdana;
            height: 15px;
        }
    </style>
</head>
<body style="padding: 0px; width: 100%; text-align: left; top: 0px; height: 100%;
    min-height: 100%; margin: 0px; clip: rect(auto auto auto auto)">
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True" />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                    <ProgressTemplate>
                        <div style="text-align: center; position: fixed; top: 10%; right: 46%; z-index: 10;">
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagens/carregando.gif" />
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <div class="TituloMovimento">
                    Roteiros de Atendimento</div>
                <div>
                    <table style="border: thin groove #CCCCCC; width: 100%; font-family: verdana; font-size: 7pt;
                        border-collapse: collapse;" class="TextoCadastro_BGBranco">
                        <tr>
                            <td class="style1" colspan="5">
                                <asp:Label ID="LblErro" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right">
                                Vendedor/Representante:
                            </td>
                            <td>
                                <asp:DropDownList ID="DdlRepresentante" runat="server" CssClass="CampoCadastro" Width="300px">
                                </asp:DropDownList>
                            </td>
                            <td style="text-align: right">
                                Período:
                            </td>
                            <td>
                                <asp:TextBox ID="TxtDataI" runat="server" CssClass="TextoCadastro" Width="70px"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" FirstDayOfWeek="Sunday"
                                    Format="dd/MM/yyyy" TargetControlID="TxtDataI" TodaysDateFormat="d MMMM yyyy" />
                                <asp:Label ID="Label18" runat="server" Height="16px" Text="&nbsp;a:&nbsp;"></asp:Label>
                                <asp:TextBox ID="TxtDataF" runat="server" CssClass="TextoCadastro" Width="70px"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" FirstDayOfWeek="Sunday"
                                    Format="dd/MM/yyyy" TargetControlID="TxtDataF" TodaysDateFormat="d MMMM yyyy" />
                                </asp:textbox>
                            </td>
                            <td style="text-align: right">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right">
                                Situação:
                            </td>
                            <td>
                                <asp:DropDownList ID="DdlSituacao" runat="server" CssClass="CampoCadastro" Width="300px">
                                    <asp:ListItem Selected="True" Value="-1">Todos</asp:ListItem>
                                    <asp:ListItem Value="1">Somente agendados</asp:ListItem>
                                    <asp:ListItem Value="2">Somente concluídos</asp:ListItem>
                                    <asp:ListItem Value="3">Somente cancelados</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td style="text-align: right">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td style="text-align: right">
                                <asp:Button ID="BtnAplicarFiltro" runat="server" Text="Pesquisar" />
                                &nbsp;
                                <asp:Button ID="BtnIncluir" runat="server" Text="Novo Registro" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="5">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="5">
                                <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                    CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None"
                                    PageSize="14" Width="100%">
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" />
                                    <Columns>
                                        <asp:BoundField DataField="cod_roteiro_visita" HeaderText="Roteiro" ReadOnly="True"
                                            SortExpression="cod_roteiro_visita">
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Vendedor/Representante" SortExpression="nome">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("nome") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("nome") %>'></asp:Label>
                                                (<asp:Label ID="Label10" runat="server" Text='<%# Eval("cod_representante") %>'></asp:Label>
                                                )
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Período" SortExpression="data_atendimento">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("data_atendimento") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("data_inicio", "{0:dd/MM/yyyy}") %>'></asp:Label>
                                                &nbsp;a
                                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("data_termino", "{0:dd/MM/yyyy}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="descricao_situacao" HeaderText="Situação" SortExpression="descricao_situacao">
                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                        </asp:BoundField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImageButton2" runat="server" CommandArgument='<%# Eval("cod_roteiro_visita") %>'
                                                    CommandName="ALTERAR" ImageUrl="~/Imagens/BtnEditar.png" ToolTip="Clique para alterar ou consultar o registro" />
                                                &nbsp;&nbsp;
                                                <asp:ImageButton ID="ImageButton3" runat="server" 
                                                    CommandArgument='<%# Eval("cod_roteiro_visita") %>' CommandName="EXCLUIR" 
                                                    ImageUrl="~/Imagens/BtnExcluir.png" 
                                                    onclientclick="return confirm('Deseja realmente excluir o registro?');" 
                                                    ToolTip="Excluir o registro" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="60px" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <PagerSettings FirstPageText="1&nbsp;&nbsp;" LastPageText="Últ." Mode="NumericFirstLast"
                                        PageButtonCount="15" />
                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                                    <EditRowStyle BackColor="#999999" />
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="5">
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                                    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select ra.empresa, ra.estabelecimento, ra.cod_roteiro_visita, ra.cod_representante, re.nome, ra.data_inicio, ra.data_termino,
       case isnull(ra.situacao,1) when 1 then 'Agendado' when 2 then 'Concluído' when 3 then 'Cancelado' end descricao_situacao
  from roteiro_visita ra inner join emitente re on ra.cod_representante = re.cod_emitente
 where ra.empresa = :empresa
   and ra.estabelecimento = :estabelecimento
   and isnull(:cod_representante,'') in ('','0',ra.cod_representante)
   and :situacao in ('-1', ra.situacao)
   and ra.data_inicio &gt;= convert(date, f_isnull_or_empty(:data_i,'01/01/1900'), 103)
   and ra.data_termino &lt;= convert(date, f_isnull_or_empty(:data_f,'31/12/2999'), 103)
   and ( f_isnull_or_empty(:cod_gestor1,'0') &lt;= 0 or exists(select 1 from gestor_conta_representante gr inner join gestor_conta gc on gr.cod_gestor = gc.cod_gestor where gc.cod_usuario =  f_isnull_or_empty(:cod_gestor2,'0') and gr.cod_representante = ra.cod_representante) )
order by ra.data_inicio desc, ra.cod_roteiro_visita desc">
                                    <SelectParameters>
                                        <asp:SessionParameter Name=":empresa" SessionField="GlEmpresa" DefaultValue="" ConvertEmptyStringToNull="False"
                                            DbType="String" />
                                        <asp:SessionParameter Name=":estabelecimento" SessionField="GlEstabelecimento" ConvertEmptyStringToNull="False"
                                            DbType="String" />
                                        <asp:ControlParameter ControlID="DdlRepresentante" ConvertEmptyStringToNull="False"
                                            DbType="String" Name=":cod_representante" PropertyName="SelectedValue" />
                                        <asp:ControlParameter ControlID="DdlSituacao" ConvertEmptyStringToNull="False" DbType="String"
                                            Name=":situacao" PropertyName="SelectedValue" />
                                        <asp:ControlParameter ControlID="TxtDataI" ConvertEmptyStringToNull="False" DbType="String"
                                            Name=":data_i" PropertyName="Text" />
                                        <asp:ControlParameter ControlID="TxtDataF" ConvertEmptyStringToNull="False" DbType="String"
                                            Name=":data_f" PropertyName="Text" />
                                        <asp:SessionParameter ConvertEmptyStringToNull="False" DbType="String" Name=":cod_gestor1"
                                            SessionField="GlCodGestor" />
                                        <asp:SessionParameter ConvertEmptyStringToNull="False" DbType="String" Name=":cod_gestor2"
                                            SessionField="GlCodGestor" />
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
