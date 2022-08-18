<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGVisitacao.aspx.vb" Inherits="ResultsCRM.WGVisitacao" ClientIDMode="Static" %>
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
        <div class="TituloMovimento">Painel de Visitações</div>
        <div>
    
            <table style="border: thin groove #CCCCCC; width:100%; font-family: verdana; font-size: 7pt; border-collapse: collapse;" 
                class="TextoCadastro_BGBranco">
                <tr>
                    <td style="text-align: right; ">
                        Seq. Visita:</td>
                    <td style="text-align: left; width: 175px;">
                        <asp:TextBox ID="TxtSeqVisita" runat="server" 
                            CssClass="CampoCadastro" MaxLength="10" style="text-align: center" 
                            Width="70px"></asp:TextBox>
                    </td>
                    <td style="text-align: right; ">
                        Cód.
                        Cliente:</td>
                    <td style="vertical-align: top; ">
                        <asp:TextBox ID="TxtCodEmitente" runat="server"
                            CssClass="CampoCadastro" Width="60px"></asp:TextBox>
    &nbsp;</td>
                    <td style="text-align: right; ">
                        <asp:Label ID="Label11" runat="server" Height="16px" 
                            Text="Vendedor/Representante:"></asp:Label>
    &nbsp;<asp:DropDownList ID="ddlRepresentante" runat="server" 
                            CssClass="CampoCadastro" Width="200px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right; ">
                        Período:</td>
                    <td>
                        <asp:TextBox ID="TxtDataI" runat="server" 
                            CssClass="TextoCadastro" Width="70px"></asp:TextBox> <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" 
                        TargetControlID="TxtDataI" FirstDayOfWeek="Sunday"
                        Format="dd/MM/yyyy" TodaysDateFormat="d MMMM yyyy"></ajaxToolkit:CalendarExtender>
                        <asp:Label ID="Label18" runat="server" Height="16px" Text="&nbsp;a:&nbsp;"></asp:Label>
                        <asp:TextBox ID="TxtDataF" runat="server" 
                            CssClass="TextoCadastro" Width="70px"></asp:TextBox></asp:TextBox> <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" 
                        TargetControlID="TxtDataF" FirstDayOfWeek="Sunday"
                        Format="dd/MM/yyyy" TodaysDateFormat="d MMMM yyyy"></ajaxToolkit:CalendarExtender>
                    </td>
                    <td style="text-align: right;">
                        Nome Cliente:</td>
                    <td>
                        <asp:TextBox ID="TxtNomeEmitente" runat="server" 
                            CssClass="CampoCadastro" ToolTip="Informe o nome ou parte do nome do cliente." 
                            Width="195px"></asp:TextBox>
                    </td>
                    <td style="text-align: right; ">
                        <asp:Label ID="Label19" runat="server" Height="16px" Text="Situação:"></asp:Label>
                        &nbsp;<asp:DropDownList ID="DdlSituacao" runat="server" 
                            CssClass="CampoCadastro" Width="200px">
                            <asp:ListItem Value="-1" Selected="True">Todas</asp:ListItem>
                            <asp:ListItem Value="1">Somente agendadas</asp:ListItem>
                            <asp:ListItem Value="2">Somente concluídas</asp:ListItem>
                            <asp:ListItem Value="3">Somente canceladas</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right;" colspan="4">
                        &nbsp;</td>
                    <td style="text-align: right; vertical-align: bottom">
                        <asp:Button ID="Button1" runat="server" Text="Pesquisar" />
                        &nbsp;
                        <asp:Button ID="Button2" runat="server" Text="Novo Registro" />
                    </td>
                </tr>
                <tr>
                    <td style="background-color: #FFFFE6;" class="Erro" colspan="5">
                        <asp:Label ID="LblErro" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                            CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" 
                            GridLines="None" Width="100%" AllowSorting="True" PageSize="14" 
                            EmptyDataText="&lt;br&gt;&lt;br&gt;Nenhum registro a exibir.">
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" />
                            <Columns>
                                <asp:BoundField DataField="seq_visita" HeaderText="Seq. Visita" ReadOnly="True" 
                                    SortExpression="seq_visita" >
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                </asp:BoundField>
                                <asp:BoundField DataField="data_visita" DataFormatString="{0:dd/MM/yyyy}" 
                                    HeaderText="Data" SortExpression="data_visita">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                </asp:BoundField>
                                <asp:BoundField DataField="hora_visita" HeaderText="Hora" 
                                    SortExpression="hora_visita">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Vendedor/Representante" 
                                    SortExpression="nome_representante">
                                    <ItemTemplate>
                                        <asp:Label ID="Label21" runat="server" 
                                            Text='<%# Bind("nome_representante") %>'></asp:Label>
                                        (<asp:Label ID="Label20" runat="server" Text='<%# Eval("cod_representante") %>'></asp:Label>
                                        )
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cliente" 
                                    SortExpression="nome_cliente">
                                    <ItemTemplate>
                                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("nome_cliente") %>'></asp:Label>
                                        (<asp:Label ID="Label6" runat="server" Text='<%# Eval("cod_emitente") %>'></asp:Label>)
                                        &nbsp;CNPJ/CPF:
                                        <asp:Label ID="Label22" runat="server" Text='<%# Eval("cnpj") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="situacao_nome" HeaderText="Situação" 
                                    SortExpression="situacao_nome">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                </asp:BoundField>
                                <asp:BoundField DataField="titulo" HeaderText="Assunto" SortExpression="titulo">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                </asp:BoundField>
                                <asp:TemplateField SortExpression="nome_cliente">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImageButton2" runat="server" 
                                            CommandArgument='<%# Eval("seq_visita") %>' CommandName="ALTERAR" 
                                            ImageUrl="~/Imagens/BtnEditar.png" 
                                            ToolTip="Clique para alterar ou consultar o registro" />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
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
                            
                            SelectCommand="call sp_visitacao(:empresa, :estabelecimento, :seq_visita, :cod_cliente, :nome_cliente, :data_visita_i, :data_visita_f, :situacao, :cod_representante)">
                            <SelectParameters>
                                <asp:SessionParameter Name=":empresa" SessionField="GlEmpresa" 
                                    ConvertEmptyStringToNull="False" DbType="String" />
                                <asp:SessionParameter ConvertEmptyStringToNull="False" DbType="String" 
                                    Name=":estabelecimento" SessionField="GlEstabelecimento" />
                                <asp:ControlParameter ControlID="TxtSeqVisita" ConvertEmptyStringToNull="False" 
                                    DbType="String" Name=":seq_visita" PropertyName="Text" />
                                <asp:ControlParameter ControlID="TxtCodEmitente" Name=":cod_cliente" 
                                    PropertyName="Text" ConvertEmptyStringToNull="False" DbType="String" />
                                <asp:ControlParameter ControlID="TxtNomeEmitente" 
                                    ConvertEmptyStringToNull="False" DbType="String" Name=":nome_cliente" 
                                    PropertyName="Text" />
                                <asp:ControlParameter ControlID="TxtDataI" ConvertEmptyStringToNull="False" 
                                    DbType="String" Name=":data_visita_i" PropertyName="Text" />
                                <asp:ControlParameter ControlID="TxtDataF" ConvertEmptyStringToNull="False" 
                                    DbType="String" Name=":data_visita_f" PropertyName="Text" />
                                <asp:ControlParameter ControlID="DdlSituacao" ConvertEmptyStringToNull="False" 
                                    DbType="String" Name=":situacao" PropertyName="SelectedValue" />
                                <asp:ControlParameter ControlID="ddlRepresentante" 
                                    ConvertEmptyStringToNull="False" DbType="String" Name=":cod_representante" 
                                    PropertyName="SelectedValue" />
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
