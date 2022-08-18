<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGEmail3.aspx.vb" Inherits="ResultsCRM.WGEmail3" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" 
        EnableScriptGlobalization="True">
        </asp:ScriptManager>
    <div>
    
        <asp:CheckBox ID="CbxGeral" runat="server" Text="Conta Geral" Checked="True" 
            Width="110px" />
&nbsp;&nbsp;
        <asp:Label ID="Label5" runat="server" Height="18px" Text="Usuário:"></asp:Label>
&nbsp;<asp:DropDownList ID="DdlUsuarioGeral" runat="server" CssClass="CampoCadastro" 
            Width="200px">
        </asp:DropDownList>
        
        <br />
        <asp:CheckBox ID="CbxContaPessoal" runat="server" Text="Conta Pessoal" 
            Checked="True" Width="110px" />
&nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" Height="18px" Text="Usuário:"></asp:Label>
&nbsp;<asp:DropDownList ID="DdlUsuarioPessoal" runat="server" CssClass="CampoCadastro" 
            Width="200px">
        </asp:DropDownList>
        
        <br />
        <asp:Label ID="Label2" runat="server" Height="18px" 
            Text="Localizar mensagem - Palavra-chave:"></asp:Label>
&nbsp;<asp:TextBox ID="TxtPalavraChave" runat="server" CssClass="CampoCadastro" 
            Width="200px"></asp:TextBox>
        <asp:Label ID="Label3" runat="server" Height="18px" 
            Text="&nbsp;&nbsp;Período:"></asp:Label>
&nbsp;<asp:TextBox ID="TxtDataI" runat="server" CssClass="CampoCadastro" MaxLength="10" 
            Width="80px"></asp:TextBox><ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" 
                        TargetControlID="TxtDataI" FirstDayOfWeek="Sunday"
                        Format="dd/MM/yyyy" TodaysDateFormat="d MMMM yyyy"></ajaxToolkit:CalendarExtender>
        <ajaxToolkit:MaskedEditExtender ID="TxtDataI_MaskedEditExtender" runat="server" 
            BehaviorID="TxtDataI_MaskedEditExtender" Century="2000" 
            CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
            CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
            CultureName="pt-BR" CultureThousandsPlaceholder="" CultureTimePlaceholder="" 
            Mask="99/99/9999" MaskType="Date" TargetControlID="TxtDataI" 
            UserDateFormat="DayMonthYear" />
        <asp:Label ID="Label4" runat="server" Height="18px" 
            Text="&nbsp;&nbsp;a:&nbsp;&nbsp;"></asp:Label>
        <asp:TextBox ID="TxtDataF" runat="server" CssClass="CampoCadastro" 
            MaxLength="10" Width="80px"></asp:TextBox><ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" 
                        TargetControlID="TxtDataF" FirstDayOfWeek="Sunday"
                        Format="dd/MM/yyyy" TodaysDateFormat="d MMMM yyyy"></ajaxToolkit:CalendarExtender>
    
            <asp:Label ID="Label6" runat="server" Height="18px" 
                Text="&nbsp;Marcador:"></asp:Label>
    
            <asp:DropDownList ID="DdlMarcador" runat="server" CssClass="CampoCadastro" 
                Width="230px">
            </asp:DropDownList>
    
        <ajaxToolkit:MaskedEditExtender ID="TxtDataF_MaskedEditExtender" runat="server" 
            BehaviorID="TxtDataF_MaskedEditExtender" Century="2000" 
            CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
            CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
            CultureName="pt-BR" CultureThousandsPlaceholder="" CultureTimePlaceholder="" 
            Mask="99/99/9999" MaskType="Date" TargetControlID="TxtDataF" 
            UserDateFormat="DayMonthYear" />
&nbsp;<asp:Button ID="Button1" runat="server" CssClass="Botao" Text="Pesquisar" />
        <asp:GridView ID="GridView1" runat="server" 
            AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" 
            DataSourceID="SqlDataSource1" Font-Size="7pt" 
            GridLines="None" Width="100%" 
            EmptyDataText="&lt;br&gt;Nenhum e-mail a exibir." AllowPaging="True" 
            PageSize="80">
            <AlternatingRowStyle BackColor="White" CssClass="LinhaDoGrid" />
           <Columns>
                <asp:TemplateField HeaderText="Data" SortExpression="data_email">
                    <EditItemTemplate>
                        <asp:LinkButton ID="LinkButton7" runat="server" 
                            Text='<%# Eval("data_email", "{0:dd/MM/yy HH:mm}") %>' CommandName="ALTERAR" CommandArgument='<%# Eval("seq_email") %>' width="100%" Font-Underline="False" CssClass='<%# Eval("css_class") %>'></asp:LinkButton>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton7" runat="server" 
                            Text='<%# Bind("data_email", "{0:dd/MM/yy HH:mm}") %>' CommandName="ALTERAR" CommandArgument='<%# Eval("seq_email") %>' width="100%" Font-Underline="False" CssClass='<%# Eval("css_class") %>'></asp:LinkButton>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Seq." SortExpression="seq_email" Visible="False">
                    <EditItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" Text='<%# Eval("seq_email") %>' CommandName="ALTERAR" CommandArgument='<%# Eval("seq_email") %>' width="100%" Font-Underline="False" CssClass='<%# Eval("css_class") %>'></asp:LinkButton>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" Text='<%# Bind("seq_email") %>' CommandName="ALTERAR" CommandArgument='<%# Eval("seq_email") %>' width="100%" Font-Underline="False" CssClass='<%# Eval("css_class") %>'></asp:LinkButton>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Local" SortExpression="descricao_situacao">
                    <EditItemTemplate>
                        <asp:LinkButton ID="LinkButton2" runat="server" Text='<%# Eval("descricao_situacao") %>' CommandName="ALTERAR" CommandArgument='<%# Eval("seq_email") %>' width="100%" Font-Underline="False" CssClass='<%# Eval("css_class") %>'></asp:LinkButton>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton2" runat="server" Text='<%# Bind("descricao_situacao") %>' CommandName="ALTERAR" CommandArgument='<%# Eval("seq_email") %>' width="100%" Font-Underline="False" CssClass='<%# Eval("css_class") %>'></asp:LinkButton>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Usuário" SortExpression="nome_usuario">
                    <EditItemTemplate>
                        <asp:LinkButton ID="LinkButton3" runat="server" Text='<%# Eval("nome_usuario") %>' CommandName="ALTERAR" CommandArgument='<%# Eval("seq_email") %>' width="100%" Font-Underline="False" CssClass='<%# Eval("css_class") %>'></asp:LinkButton>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton3" runat="server" Text='<%# Bind("nome_usuario") %>' CommandName="ALTERAR" CommandArgument='<%# Eval("seq_email") %>' width="100%" Font-Underline="False" CssClass='<%# Eval("css_class") %>'></asp:LinkButton>
                        <asp:LinkButton ID="LinkButton10" runat="server" 
                            CommandArgument='<%# Eval("seq_email") %>' CommandName="ASSUMIR" 
                            Visible='<%# Eval("mostrar_link_assumir") %>'>Assumir</asp:LinkButton>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Remetente" SortExpression="remetente_nome">
                    <EditItemTemplate>
                        <asp:LinkButton ID="LinkButton4" runat="server" Text='<%# Eval("remetente_nome") %>' CommandName="ALTERAR" CommandArgument='<%# Eval("seq_email") %>' width="100%" Font-Underline="False" CssClass='<%# Eval("css_class") %>'></asp:LinkButton>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton4" runat="server" Text='<%# Bind("remetente_nome") %>' CommandName="ALTERAR" CommandArgument='<%# Eval("seq_email") %>' width="100%" Font-Underline="False" CssClass='<%# Eval("css_class") %>'></asp:LinkButton>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Destinatário" 
                    SortExpression="destinatario_email">
                    <EditItemTemplate>
                        <asp:LinkButton ID="LinkButton5" runat="server" Text='<%# Eval("destinatario_email") %>' CommandName="ALTERAR" CommandArgument='<%# Eval("seq_email") %>' width="100%" Font-Underline="False" CssClass='<%# Eval("css_class") %>'></asp:LinkButton>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton5" runat="server" Text='<%# Bind("destinatario_email") %>' CommandName="ALTERAR" CommandArgument='<%# Eval("seq_email") %>' width="100%" Font-Underline="False" CssClass='<%# Eval("css_class") %>'></asp:LinkButton>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Assunto" SortExpression="assunto">
                    <EditItemTemplate>
                        <asp:LinkButton ID="LinkButton6" runat="server" Text='<%# Eval("assunto") %>' CommandName="ALTERAR" CommandArgument='<%# Eval("seq_email") %>' width="100%" Font-Underline="False" CssClass='<%# Eval("css_class") %>'></asp:LinkButton>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton6" runat="server" Text='<%# Bind("assunto") %>' CommandName="ALTERAR" CommandArgument='<%# Eval("seq_email") %>' width="100%" Font-Underline="False" CssClass='<%# Eval("css_class") %>'></asp:LinkButton>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Marcadores" SortExpression="marcadores" 
                    Visible="False">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("marcadores") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton22" runat="server" 
                            CommandArgument='<%# Eval("seq_email") %>' CommandName="ALTERAR" 
                            CssClass='<%# Eval("css_class") %>' Font-Underline="False" 
                            Text='<%# Bind("marcadores") %>' width="100%"></asp:LinkButton>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Prioridade" 
                    SortExpression="descricao_prioridade">
                    <EditItemTemplate>
                        <asp:LinkButton ID="LinkButton8" runat="server" 
                            Text='<%# Eval("descricao_prioridade") %>' CommandName="ALTERAR" CommandArgument='<%# Eval("seq_email") %>' width="100%" Font-Underline="False" CssClass='<%# Eval("css_class") %>'></asp:LinkButton>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton8" runat="server" 
                            Text='<%# Bind("descricao_prioridade") %>' CommandName="ALTERAR" CommandArgument='<%# Eval("seq_email") %>' width="100%" Font-Underline="False" CssClass='<%# Eval("css_class") %>'></asp:LinkButton>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Chamado" SortExpression="chamado">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton18" runat="server" 
                            Text='<%# Bind("chamado") %>' CommandName="ALTERAR" CommandArgument='<%# Eval("seq_email") %>' width="100%" Font-Underline="False" CssClass='<%# Eval("css_class") %>'></asp:LinkButton>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Situação">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton9" runat="server" 
                            CommandArgument='<%# Eval("seq_email") & ";" & Eval("situacao_leitura") %>' 
                            CommandName="LIDO" Text='<%# Eval("texto_link_situacao") %>'></asp:LinkButton>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:TemplateField SortExpression="mostrar_icone_anexo">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" 
                            Text='<%# Bind("mostrar_icone_anexo") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagens/clip.png" Height="16px" Width="16px"
                            ToolTip="Contém anexo(s)." Visible='<%# Eval("mostrar_icone_anexo") %>' />
                    </ItemTemplate>
                    <ItemStyle Width="19px" />
                </asp:TemplateField>
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerSettings FirstPageText="Primeira" LastPageText="Última" 
                Mode="NumericFirstLast" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" Font-Underline="False" 
                CssClass="LinhaDoGrid" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
            
            
            
            
            
            SelectCommand="call sp_email(:empresa, :situacao,  :conta_geral, :cod_usuario_geral, :conta_pessoal, :cod_usuario_pessoal, :pesquisa, :datai, :dataf, :tipo_conteudo, :cod_conteudo, :cod_marcador) ">
            <SelectParameters>
                <asp:SessionParameter ConvertEmptyStringToNull="False" DbType="String" 
                    Name=":empresa" SessionField="GlEmpresa" />
                <asp:QueryStringParameter ConvertEmptyStringToNull="False" DbType="String" 
                    Name=":situacao" QueryStringField="t" />
                <asp:ControlParameter ControlID="CbxGeral" ConvertEmptyStringToNull="False" 
                    DbType="String" Name=":conta_geral" PropertyName="Checked" />
                <asp:ControlParameter ControlID="DdlUsuarioGeral" ConvertEmptyStringToNull="False" 
                    DbType="String" Name=":cod_usuario_geral" PropertyName="SelectedValue" />
                <asp:ControlParameter ControlID="CbxContaPessoal" 
                    ConvertEmptyStringToNull="False" DbType="String" Name=":conta_pessoal" 
                    PropertyName="Checked" />
                <asp:ControlParameter ControlID="DdlUsuarioPessoal" 
                    ConvertEmptyStringToNull="False" DbType="String" Name=":cod_usuario_pessoal" 
                    PropertyName="SelectedValue" />
                <asp:ControlParameter ControlID="TxtPalavraChave" 
                    ConvertEmptyStringToNull="False" DbType="String" Name=":pesquisa" 
                    PropertyName="Text" />
                <asp:ControlParameter ControlID="TxtDataI" ConvertEmptyStringToNull="False" 
                    DbType="String" Name=":datai" PropertyName="Text" />
                <asp:ControlParameter ControlID="TxtDataF" ConvertEmptyStringToNull="False" 
                    DbType="String" Name=":dataf" PropertyName="Text" />
                <asp:QueryStringParameter ConvertEmptyStringToNull="False" DbType="String" 
                    Name=":tipo_conteudo" QueryStringField="tc" />
                <asp:QueryStringParameter ConvertEmptyStringToNull="False" DbType="String" 
                    Name=":cod_conteudo" QueryStringField="cc" />
                <asp:ControlParameter ControlID="DdlMarcador" ConvertEmptyStringToNull="False" 
                    DbType="String" Name=":cod_marcador" PropertyName="SelectedValue" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
