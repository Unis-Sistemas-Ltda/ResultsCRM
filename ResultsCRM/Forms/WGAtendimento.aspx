<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGAtendimento.aspx.vb" Inherits="ResultsCRM.WGAtendimento" ClientIDMode="Static" %>
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
    <form id="form1" runat="server" defaultbutton="BtnPesquisar">
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
        <div class="TituloMovimento">Painel de Atendimentos</div>
        <div>
    
            <table style="border: thin groove #CCCCCC; width:100%; font-family: verdana; font-size: 7pt; border-collapse: collapse;" 
                class="TextoCadastro_BGBranco">
                <tr>
                    <td style="text-align: right; ">
                        Nº Chamado:</td>
                    <td style="text-align: left; ">
                        <asp:TextBox ID="TxtNrAtendimento" runat="server" 
                            CssClass="CampoCadastro" MaxLength="10" style="text-align: center" 
                            Width="70px"></asp:TextBox>
                    </td>
                    <td style="text-align: right; ">
                        Cód.
                        Cliente:</td>
                    <td style="vertical-align: top; ">
                        <asp:TextBox ID="TxtCodEmitente" runat="server"
                            CssClass="CampoCadastro" Width="60px" AutoPostBack="True"></asp:TextBox>
    &nbsp;</td>
                    <td style="text-align: right;">
                        Tipo Chamado:</td>
                    <td style="vertical-align: top; ">
                        <asp:DropDownList ID="ddlTipoChamado" runat="server"
                            CssClass="CampoCadastro" Width="170px">
                        </asp:DropDownList>
                    </td>
                    <td style="text-align: right; ">
                        <asp:Label ID="Label11" runat="server" Height="16px" Text="Analista:"></asp:Label>
    &nbsp;<asp:DropDownList ID="ddlAnalista" runat="server" 
                            CssClass="CampoCadastro" Width="180px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right; ">
                        Chamado Cliente:</td>
                    <td style="text-align: left; ">
                        <asp:TextBox ID="TxtOSCliente" runat="server" 
                            CssClass="CampoCadastro" MaxLength="10" style="text-align: center" 
                            Width="70px"></asp:TextBox>
                    </td>
                    <td style="text-align: right;">
                        Nome Cliente:</td>
                    <td style="vertical-align: top" class="style1">
                        <asp:TextBox ID="TxtNomeEmitente" runat="server" CssClass="CampoCadastro" 
                            ToolTip="Informe o nome ou parte do nome do cliente." Width="175px"></asp:TextBox>
                    </td>
                    <td style="text-align: right;">
                        <asp:Label ID="Label9" runat="server" Text="Tipo Status:"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlTipoStatus" runat="server" 
                            CssClass="CampoCadastro" Width="170px">
                            <asp:ListItem Value="1234">(Todos)</asp:ListItem>
                            <asp:ListItem Value="1">Inicial</asp:ListItem>
                            <asp:ListItem Value="2">Intermediário</asp:ListItem>
                            <asp:ListItem Value="3">Final</asp:ListItem>
                            <asp:ListItem Selected="True" Value="12">Inicial / Intermediário</asp:ListItem>
                            <asp:ListItem Value="23">Intermediário / Final</asp:ListItem>
                            <asp:ListItem Value="13">Inicial / Final</asp:ListItem>
                            <asp:ListItem Value="4">Cancelado</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td style="text-align: right; ">
                        <asp:Label ID="Label20" runat="server" Height="16px" Text="Incluído por:"></asp:Label>
                        &nbsp;<asp:DropDownList ID="DdlIncluidoPor" runat="server" 
                            CssClass="CampoCadastro" Width="180px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right; ">
                        OS Interna:</td>
                    <td style="text-align: left; ">
                        <asp:TextBox ID="TxtOSInterna" runat="server" 
                            CssClass="CampoCadastro" MaxLength="10" style="text-align: center" 
                            Width="70px"></asp:TextBox>
                    </td>
                    <td style="text-align: right;">
                        Contato:</td>
                    <td class="style1">
                        <asp:DropDownList ID="DdlContato" runat="server" 
                            CssClass="CampoCadastro" Width="180px">
                        </asp:DropDownList>
                    </td>
                    <td style="text-align: right;">
                        Status:</td>
                    <td>
                        <asp:DropDownList ID="DdlStatus" runat="server" 
                            CssClass="CampoCadastro" Width="170px">
                        </asp:DropDownList>
                    </td>
                    <td style="text-align: right; vertical-align: bottom">
                        <asp:Label ID="LblTecnico2" runat="server" Height="16px" Text="Técnico:"></asp:Label>
    &nbsp;<asp:DropDownList ID="ddlAgenteTecnico" runat="server" 
                            CssClass="CampoCadastro" Width="180px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right; ">
                        SLA:</td>
                    <td style="text-align: left; width: 180px;">
                        <asp:DropDownList ID="ddlsla" runat="server" CssClass="CampoCadastro" 
                            Width="170px">
                        </asp:DropDownList>
                    </td>
                    <td style="text-align: right;">
                        <asp:Label ID="LblPontoAtend" runat="server" Text="Ponto Atend.:"></asp:Label>
                    </td>
                    <td class="style1">
                        <asp:TextBox ID="TxtPontoDeAtendimento" runat="server" CssClass="CampoCadastro" 
                        
                            ToolTip="Informe o número, o nome ou parte do nome do ponto de atendimento" 
                            Width="175px"></asp:TextBox>
                        <asp:DropDownList ID="DdlReabertura" runat="server" 
                            CssClass="CampoCadastro" Visible="False" Width="90px">
                            <asp:ListItem Value="S">Sim</asp:ListItem>
                            <asp:ListItem Value="N">Não</asp:ListItem>
                            <asp:ListItem Selected="True" Value="T">Todos</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td style="text-align: right;">
                        <asp:Label ID="Label1" runat="server" Height="17px" Text="Assunto:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TxtAssunto" runat="server" Width="160px" 
                            CssClass="CampoCadastro"></asp:TextBox>
                    </td>
                    <td style="text-align: right; ">
                        <asp:Label ID="LblTecnico1" runat="server" Height="16px" Text="Observação:"></asp:Label>
                        &nbsp;<asp:TextBox ID="TxtObservacao" runat="server" 
                            CssClass="CampoCadastro" ToolTip="Informe a observação do chamado" 
                            Width="175px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right;">
                        Período:</td>
                    <td style="text-align: left; width: 180px;">
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
                            MaskType="Date" TargetControlID="TxtDataI" UserDateFormat="DayMonthYear" />
                        <asp:Label ID="Label18" runat="server" Height="17px" Text="&nbsp;a&nbsp;"></asp:Label>
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
                            MaskType="Date" TargetControlID="TxtDataF" UserDateFormat="DayMonthYear" />
                        <br />
                        <asp:Label ID="LblData" runat="server" Visible="False"></asp:Label>
                    </td>
                    <td style="text-align: right;">
                        <asp:Label ID="LblRegiaoAtend" runat="server" Height="16px" 
                            Text="Região Atend.:"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlRegiao" runat="server" CssClass="CampoCadastro" 
                            Width="180px">
                        </asp:DropDownList>
                    </td>
                    <td style="text-align: right;">
                        <asp:Label ID="LblTop" runat="server" Height="16px" Text="Exibir:"></asp:Label>
                    </td>
                    <td>
                        &nbsp;<asp:DropDownList ID="DdlTop" runat="server" CssClass="CampoCadastro" 
                            Width="100px">
                            <asp:ListItem Value="50">50 registros</asp:ListItem>
                            <asp:ListItem Value="75">75 registros</asp:ListItem>
                            <asp:ListItem Value="100">100 registros</asp:ListItem>
                            <asp:ListItem Value="125">125 registros</asp:ListItem>
                            <asp:ListItem Value="150">150 registros</asp:ListItem>
                            <asp:ListItem Value="200">200 registros</asp:ListItem>
                            <asp:ListItem Value="300">300 registros</asp:ListItem>
                            <asp:ListItem Value="400">400 registros</asp:ListItem>
                            <asp:ListItem Selected="True" Value="500">500 registros</asp:ListItem>
                            <asp:ListItem Value="1000">1000 registros</asp:ListItem>
                            <asp:ListItem Value="999999">Todos</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td style="text-align: right; vertical-align: bottom">
                        <asp:Button ID="BtnLimparFiltro" runat="server" Text="Limpar Filtros" />
                        &nbsp;&nbsp;
                        <asp:Button ID="BtnPesquisar" runat="server" Text="Pesquisar" />
                        &nbsp;&nbsp;&nbsp;<asp:Button ID="BtnNovoRegistro" runat="server" 
                            Text="Novo Registro" />
                    </td>
                </tr>
                <tr>
                    <td style="background-color: #FFFFE6;" class="Erro" colspan="7">
                        <asp:Label ID="LblErro" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="7">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                            CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" 
                            GridLines="None" Width="100%" AllowSorting="True" PageSize="14">
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" 
                                VerticalAlign="Top" />
                            <Columns>
                                <asp:BoundField DataField="seq" HeaderText="seq" ReadOnly="True" 
                                    SortExpression="seq" Visible="False" >
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="cod_chamado" HeaderText="Nº Chamado" ReadOnly="True" 
                                    SortExpression="cod_chamado" >
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="os_cliente" HeaderText="Chamado Cliente" 
                                    SortExpression="os_cliente">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="numeros_os" HeaderText="OS's" 
                                    SortExpression="numeros_os">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Cliente" SortExpression="nome_emitente">
                                    <EditItemTemplate>
                                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("nome_emitente") %>'></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("nome_emitente") %>'></asp:Label>
                                        &nbsp;(<asp:Label ID="Label6" runat="server" Text='<%# Eval("cod_emitente") %>'></asp:Label>
                                        )
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Ponto de Atendimento" 
                                    SortExpression="cod_emitente_atendimento">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox3" runat="server" 
                                            Text='<%# Bind("cod_emitente_atendimento") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label7" runat="server" 
                                            Text='<%# Eval("nome_emitente_atendimento") %>'></asp:Label>
                                        (<asp:Label ID="Label5" runat="server" 
                                            Text='<%# Bind("cod_emitente_atendimento") %>'></asp:Label>
                                        )
                                        <br />
                                        <asp:Label ID="Label8" runat="server" 
                                            Text='<%# Eval("nome_ponto_atendimento") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="tecnicos" HeaderText="Técnicos" 
                                    SortExpression="tecnicos" />
                                <asp:BoundField DataField="aceite_tecnico" HeaderText="Aceite Técnico" 
                                    SortExpression="aceite_tecnico">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Assunto" SortExpression="assunto">
                                    <EditItemTemplate>
                                        <asp:Label ID="Label5" runat="server" Text='<%# Eval("assunto") %>'></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label9" runat="server" Text='<%# Bind("assunto") %>' 
                                            ToolTip='<%# Eval("pergunta") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="observacao" HeaderText="Obs." 
                                    SortExpression="observacao">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Status" SortExpression="descricao_status">
                                    <EditItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("descricao_status") %>'></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("descricao_status") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="cf_situacao" HeaderText="Situação" 
                                    SortExpression="cf_situacao">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Label ID="LblDesobrigadoSLA" runat="server" 
                                            Text='<%# Eval("desobrigado_sla") %>' Visible="False"></asp:Label>
                                        <asp:Label ID="LblDesobrigadoSLACor" runat="server" Height="20px" 
                                            Text="&nbsp;&nbsp;&nbsp;" Width="20px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Tipo Chamado" SortExpression="nome_tipo_chamado">
                                    <EditItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("nome_tipo_chamado") %>'></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("nome_tipo_chamado") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="seq_prioridade" HeaderText="Seq Prioridade Cliente" 
                                    SortExpression="seq_prioridade">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Analista" SortExpression="nome_analista">
                                    <EditItemTemplate>
                                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("nome_analista") %>'></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("nome_analista") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="data_chamado" DataFormatString="{0:dd/MM/yyyy HH:mm}" 
                                    HeaderText="Data" SortExpression="data_chamado">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Reabertura" SortExpression="reabertura">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("reabertura") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="LblReabertura" runat="server" Text='<%# Eval("reabertura") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImageButton2" runat="server" 
                                            CommandArgument='<%# Eval("cod_chamado") %>' CommandName="ALTERAR" 
                                            ImageUrl="~/Imagens/BtnEditar.png" 
                                            ToolTip="Clique para alterar ou consultar o registro" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="tipo_status" SortExpression="tipo_status" 
                                    Visible="False">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("tipo_status") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="LblTipoStatus" runat="server" Text='<%# Bind("tipo_status") %>'></asp:Label>
                                        <asp:Label ID="LblIDTipo" runat="server" Text='<%# Eval("id_tipo") %>' 
                                            Visible="False"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="cf_dias" SortExpression="cf_dias" 
                                    Visible="False">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("cf_dias") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="LblDias" runat="server" Text='<%# Bind("cf_dias") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImageButton3" runat="server" 
                                            CommandArgument='<%# Eval("cod_chamado") %>' CommandName="TRANSFERIR" 
                                            Height="16px" ImageUrl="~/Imagens/setaverde.png" 
                                            onclientclick="return confirm('Deseja transferir o chamado?')" 
                                            ToolTip="Transferir o chamado" />
                                    </ItemTemplate>
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
                    <td colspan="7">
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
                        
                        
                        
                        
                        
                        
                        
                        
                        
                        
                        
                            
                            
                            
                            SelectCommand="call sp_atendimento(:empresa, :top, :codchamado, :assunto, :cod_status, :cod_analista, :cod_usuario, :cod_emitente, :cod_contato, :tipo_chamado, :tipo_status, :nome_emitente, :os_cliente, :os_interna, :ponto_atendimento, :agente_tecnico, :observacao, :strdata, :reabertura, :regiao, :cod_sla, :codemitenteexterno, :cod_gestor)">
                            <SelectParameters>
                                <asp:SessionParameter Name=":empresa" SessionField="GlEmpresa" />
                                <asp:ControlParameter ControlID="DdlTop" Name=":top" 
                                    PropertyName="SelectedValue" />
                                <asp:ControlParameter ControlID="TxtNrAtendimento" Name=":codchamado" 
                                    PropertyName="Text" ConvertEmptyStringToNull="False" Type="String" />
                                <asp:ControlParameter ControlID="TxtAssunto" Name=":assunto" 
                                    PropertyName="Text" ConvertEmptyStringToNull="False" Type="String" />
                                <asp:ControlParameter ControlID="DdlStatus" Name=":cod_status" 
                                    PropertyName="SelectedValue" />
                                <asp:ControlParameter ControlID="ddlAnalista" Name=":cod_analista" 
                                    PropertyName="SelectedValue" />
                                <asp:ControlParameter ControlID="DdlIncluidoPor" 
                                    ConvertEmptyStringToNull="False" DbType="String" DefaultValue="-1" 
                                    Name=":cod_usuario" PropertyName="SelectedValue" />
                                <asp:ControlParameter ControlID="TxtCodEmitente" Name=":cod_emitente" 
                                    PropertyName="Text" DefaultValue="" ConvertEmptyStringToNull="False" 
                                    Type="String" />
                                <asp:ControlParameter ControlID="DdlContato" 
                                    Name=":cod_contato" PropertyName="SelectedValue" />
                                <asp:ControlParameter ControlID="ddlTipoChamado" 
                                    Name=":tipo_chamado" PropertyName="SelectedValue" />
                                <asp:ControlParameter ControlID="ddlTipoStatus" DefaultValue="" 
                                    Name=":tipo_status" PropertyName="SelectedValue" />
                                <asp:ControlParameter ControlID="TxtNomeEmitente" 
                                    ConvertEmptyStringToNull="False" Name=":nome_emitente" PropertyName="Text" 
                                    Type="String" />
                                <asp:ControlParameter ControlID="TxtOSCliente" ConvertEmptyStringToNull="False" 
                                    Name=":os_cliente" PropertyName="Text" Type="String" />
                                <asp:ControlParameter ControlID="TxtOSInterna" ConvertEmptyStringToNull="False" 
                                    Name=":os_interna" PropertyName="Text" Type="String" />
                                <asp:ControlParameter ControlID="TxtPontoDeAtendimento" 
                                    ConvertEmptyStringToNull="False" Name=":ponto_atendimento" PropertyName="Text" 
                                    Type="String" />
                                <asp:ControlParameter ControlID="ddlAgenteTecnico" Name=":agente_tecnico" 
                                    PropertyName="SelectedValue" Type="String" />
                                <asp:ControlParameter ControlID="TxtObservacao" 
                                    ConvertEmptyStringToNull="False" DbType="String" Name=":observacao" 
                                    PropertyName="Text" />
                                <asp:ControlParameter ControlID="LblData" ConvertEmptyStringToNull="False" 
                                    DbType="String" Name=":strdata" PropertyName="Text" />
                                <asp:ControlParameter ControlID="DdlReabertura" 
                                    ConvertEmptyStringToNull="False" DbType="String" Name=":reabertura" 
                                    PropertyName="SelectedValue" />
                                <asp:ControlParameter ControlID="ddlRegiao" ConvertEmptyStringToNull="False" 
                                    DbType="String" Name=":regiao" PropertyName="SelectedValue" />
                                <asp:ControlParameter ControlID="ddlsla" Name=":cod_sla" 
                                    PropertyName="SelectedValue" />
                                <asp:SessionParameter Name=":codemitenteexterno" SessionField="GlCodEmitenteExterno" />
                                <asp:SessionParameter ConvertEmptyStringToNull="False" DbType="String" 
                                    Name=":cod_gestor" SessionField="GlCodGestor" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </td>
                </tr>
                <tr>
                    <td colspan="7" style="color: #000000">
                        <br />
                        RESUMO<br />
                        <br />
                        <asp:Label ID="Label12" runat="server" Text="Atendimentos encerrados:" style="text-align:right"
                            Width="280px" ForeColor="Black"></asp:Label>
                    &nbsp;<asp:Label ID="LblQtdAtendimentosEncerrados" runat="server" Font-Bold="True" 
                            Font-Size="8pt" ForeColor="Green" Text="0"></asp:Label>
                        <br />
                        <asp:Label ID="Label13" runat="server" Text="Atendimentos cancelados:" style="text-align:right"
                            Width="280px" ForeColor="Black"></asp:Label>
                    &nbsp;<asp:Label ID="LblQtdAtendimentosCancelados" runat="server" Font-Bold="True" 
                            Font-Size="8pt" ForeColor="Gray" Text="0"></asp:Label>
                        <br />
                        <asp:Label ID="Label14" runat="server" Text="Atendimentos com prazo vencido:" style="text-align:right"
                            Width="280px" ForeColor="Black"></asp:Label>
                    &nbsp;<asp:Label ID="LblQtdAtendimentosPrazoVencido" runat="server" 
                            Font-Bold="True" Font-Size="8pt" ForeColor="Red" Text="0"></asp:Label>
                        <br />
                        <asp:Label ID="Label15" runat="server" Text="Atendimentos com prazo futuro:" style="text-align:right"
                            Width="280px" ForeColor="Black"></asp:Label>
                    &nbsp;<asp:Label ID="LblQtdAtendimentosPrazoFuturo" runat="server" Font-Bold="True" 
                            Font-Size="8pt" ForeColor="Black" Text="0"></asp:Label>
                        <br />
                        <asp:Label ID="Label16" runat="server" Text="Atendimentos com prazo para hoje:" style="text-align:right"
                            Width="280px" ForeColor="Black"></asp:Label>
                    &nbsp;<asp:Label ID="LblQtdAtendimentosHoje" runat="server" Font-Bold="True" 
                            Font-Size="8pt" ForeColor="Blue" Text="0"></asp:Label>
                        <br />
                        <asp:Label ID="Label17" runat="server" Text="TOTAL DE ATENDIMENTOS:" style="text-align:right"
                            Width="280px" ForeColor="Black"></asp:Label>
                    &nbsp;<asp:Label ID="LblQtdAtendimentosTotal" runat="server" Font-Bold="True" 
                            Font-Size="8pt" ForeColor="Black" Text="0"></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="Label22" runat="server" BackColor="Red" Height="20px" 
                            Width="20px"></asp:Label>
                        <asp:Label ID="Label21" runat="server" ForeColor="Black" 
                            style="text-align:right" Text="Chamados desobrigados de cumprir prazo da SLA:" 
                            Width="260px"></asp:Label>
                        &nbsp;<asp:Label ID="LblQtdAtendimentosDesobrigados" runat="server" Font-Bold="True" 
                            Font-Size="8pt" ForeColor="Black" Text="0"></asp:Label>
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
