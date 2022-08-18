<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFRelAcompanhamentoChamado.aspx.vb" Inherits="ResultsCRM.WFRelAcompanhamentoChamado" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="../ResultsCRM.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table style="border: thin groove #CCCCCC; width:100%; font-family: verdana; font-size: 7pt; border-collapse: collapse;" 
            class="TextoCadastro_BGBranco">
            <tr>
                <td class="TituloRelatorio" colspan="8">
                    <asp:ScriptManager ID="ScriptManager1" runat="server" 
                        EnableScriptGlobalization="True">
                    </asp:ScriptManager>
                    Acompanhamento de Chamados Encerrados</td>
            </tr>
            <tr>
                <td colspan="8">
                    <asp:Label ID="LblErro" runat="server" CssClass="Erro"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; ">
                    Tipo Chamado:</td>
                <td style="text-align: left; ">
                    <asp:DropDownList ID="ddlTipoChamado" runat="server" 
                        CssClass="CampoCadastro" Width="200px">
                    </asp:DropDownList>
                </td>
                <td style="text-align: right; ">
                    Cód.
                    Cliente:</td>
                <td style="vertical-align: top; ">
                    <asp:TextBox ID="TxtCodEmitente" runat="server" 
                        CssClass="CampoCadastro" Width="60px"></asp:TextBox>
                </td>
                <td style="text-align: right;">
                    Departamento:</td>
                <td style="vertical-align: top; ">
                    <asp:DropDownList ID="DdlDepartamento" runat="server" 
                        CssClass="CampoCadastro" Width="200px">
                    </asp:DropDownList>
                </td>
                <td style="text-align: right; " colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: right; ">
                    Abertura:</td>
                <td style="text-align: left; ">
                    <asp:TextBox ID="TxtDataAberturaI" runat="server" CssClass="CampoCadastro" 
                        Width="80px"></asp:TextBox><cc1:CalendarExtender id="CalendarExtender01" runat="server" firstdayofweek="Sunday" 
                        format="dd/MM/yyyy" targetcontrolid="TxtDataAberturaI" todaysdateformat="d MMMM yyyy"></cc1:CalendarExtender>
                    <asp:Label ID="Label18" runat="server" Height="16px" Text="a"></asp:Label>
&nbsp;<asp:TextBox ID="TxtDataAberturaF" runat="server" CssClass="CampoCadastro" Width="80px"></asp:TextBox><cc1:CalendarExtender id="CalendarExtender2" runat="server" firstdayofweek="Sunday" 
                        format="dd/MM/yyyy" targetcontrolid="TxtDataAberturaF" todaysdateformat="d MMMM yyyy"></cc1:CalendarExtender>
                </td>
                <td style="text-align: right;">
                    Nome Cliente:</td>
                <td style="vertical-align: top" >
                    <asp:TextBox ID="TxtNomeEmitente" runat="server" CssClass="CampoCadastro" 
                        ToolTip="Informe o nome ou parte do nome do cliente." Width="195px"></asp:TextBox>
                </td>
                <td style="text-align: right;" >
                    <asp:Label ID="Label11" runat="server" Height="16px" Text="Analista:"></asp:Label>
                </td>
                <td style="vertical-align: top" >
                    <asp:DropDownList ID="ddlAnalista" runat="server" 
                        CssClass="CampoCadastro" Width="200px">
                    </asp:DropDownList>
                </td>
                <td style="text-align: right; " rowspan="2">
                    <asp:ImageButton ID="ImageButton1" runat="server" 
                        ImageUrl="~/Imagens/BtnExcel.png" ToolTip="Download no formato Excel" />
                    &nbsp;</td>
                <td style="text-align: right; ">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: right; ">
                    Encerramento:</td>
                <td style="text-align: left; ">
                    <asp:TextBox ID="TxtDataEncerramentoI" runat="server" CssClass="CampoCadastro" 
                        Width="80px"></asp:TextBox><cc1:CalendarExtender id="CalendarExtender3" runat="server" firstdayofweek="Sunday" 
                        format="dd/MM/yyyy" targetcontrolid="TxtDataEncerramentoI" todaysdateformat="d MMMM yyyy"></cc1:CalendarExtender>
                    <asp:Label ID="Label17" runat="server" Height="16px" Text="a"></asp:Label>
&nbsp;<asp:TextBox ID="TxtDataEncerramentoF" runat="server" CssClass="CampoCadastro" Width="80px"></asp:TextBox><cc1:CalendarExtender id="CalendarExtender4" runat="server" firstdayofweek="Sunday" 
                        format="dd/MM/yyyy" targetcontrolid="TxtDataEncerramentoF" todaysdateformat="d MMMM yyyy"></cc1:CalendarExtender>
                </td>
                <td style="text-align: right;">
                    Região Atend.:</td>
                <td >
                        <asp:DropDownList ID="ddlRegiao" runat="server" CssClass="CampoCadastro" 
                            Width="200px">
                        </asp:DropDownList>
                    </td>
                <td style="text-align: right;" >
                    &nbsp;</td>
                <td >
                    &nbsp;</td>
                <td style="text-align: right; vertical-align: bottom">
                    <asp:Button ID="BtnAplicarFiltro" runat="server" CssClass="Botao" 
                        Text="Aplicar Filtro" />
                </td>
            </tr>
        </table>
        <table style="border: thin groove #CCCCCC; width: 100%; font-family: verdana; font-size: 7pt; border-collapse: collapse;">
        <tr><td colspan="4">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                        CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" 
                        GridLines="None" Width="100%" AllowSorting="True">
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" />
                        <Columns>
                            <asp:BoundField DataField="cod_chamado" HeaderText="Nº Chamado" ReadOnly="True" 
                                SortExpression="cod_chamado" >
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="data_chamado" HeaderText="Abertura" 
                                SortExpression="data_chamado" DataFormatString="{0:dd/MM/yyyy HH:mm}" >
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="data_encerramento_prevista" HeaderText="Previsão" 
                                SortExpression="data_encerramento_prevista" 
                                DataFormatString="{0:dd/MM/yyyy HH:mm}">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="data_encerramento" HeaderText="Encerramento" 
                                SortExpression="data_encerramento" 
                                DataFormatString="{0:dd/MM/yyyy HH:mm}" >
                            <HeaderStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Tempo (h)" SortExpression="tempo_em_horas">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("tempo_em_horas") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LblTempoH" runat="server" Text='<%# Bind("tempo_em_horas") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tempo (dias)" SortExpression="tempo_em_dias">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("tempo_em_dias") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LblTempoDias" runat="server" Text='<%# Bind("tempo_em_dias") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="No Prazo" SortExpression="encerrado_no_prazo">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" 
                                        Text='<%# Bind("encerrado_no_prazo") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LblSituacao" runat="server" 
                                        Text='<%# Bind("encerrado_no_prazo") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                            HorizontalAlign="Left" />
                        <EditRowStyle BackColor="#999999" />
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
                        
                        
                        
                        
                        
                        
                        
                        
                        
                        
                        SelectCommand="select :cod_emitente cod_em, :cod_analista cod_an, :tipo_chamado tp_cha, cod_chamado, data_chamado, data_encerramento_prevista, data_encerramento,
       convert(numeric(12,2), convert(numeric(12,2), datediff(minute, data_chamado, if data_encerramento &lt; data_chamado then data_chamado else data_encerramento endif) ) / 60 ) tempo_em_horas,
       convert(numeric(12,2), convert(numeric(12,2), tempo_em_horas) / 24) tempo_em_dias,
       if data_encerramento_prevista &gt;= data_encerramento then 'SIM' else 'NÃO' endif encerrado_no_prazo
  from chamado c inner join emitente e on e.cod_emitente = c.cod_emitente
                 inner join sysusuario u on u.cod_usuario = c.cod_analista
 where c.empresa = :empresa 
   and c.data_encerramento       is not null
   and date(c.data_chamado)      between convert(date,:abertura_i,103) and convert(date,:abertura_f,103)
   and date(c.data_encerramento) between convert(date,:data_i,103) and convert(date,:data_f,103)
   and c.tipo_chamado = if tp_cha = 0 then c.tipo_chamado else tp_cha endif
   and c.cod_emitente  = if cod_em = 0 then c.cod_emitente else cod_em endif
   and e.nome like '%' || :nome_emitente || '%'
   and c.cod_analista = if cod_an = 0 then c.cod_analista else cod_an endif
   and (u.cod_departamento = :departamento1 or :departamento2 = '0')
   and ( trim(:codregiao1) in ('','0','-1') or f_busca_regiao_ponto_atendimento(c.empresa, c.cod_emitente_atendimento, c.numero_ponto_atendimento) = :codregiao2 )">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="TxtCodEmitente" Name=":cod_emitente" 
                                PropertyName="Text" DefaultValue="" ConvertEmptyStringToNull="False" 
                                Type="String" />
                            <asp:ControlParameter ControlID="ddlAnalista" Name=":cod_analista" 
                                PropertyName="SelectedValue" />
                            <asp:ControlParameter ControlID="ddlTipoChamado" 
                                Name=":tipo_chamado" PropertyName="SelectedValue" />
                            <asp:SessionParameter Name=":empresa" SessionField="GlEmpresa" />
                            <asp:ControlParameter ControlID="TxtDataAberturaI" 
                                ConvertEmptyStringToNull="False" Name=":abertura_i" PropertyName="Text" />
                            <asp:ControlParameter ControlID="TxtDataAberturaF" 
                                ConvertEmptyStringToNull="False" Name=":abertura_f" PropertyName="Text" />
                            <asp:ControlParameter Name=":data_i" DefaultValue="" 
                                ControlID="TxtDataEncerramentoI" ConvertEmptyStringToNull="False" 
                                PropertyName="Text" />
                            <asp:ControlParameter ControlID="TxtDataEncerramentoF" 
                                ConvertEmptyStringToNull="False" Name=":data_f" PropertyName="Text" />
                            <asp:ControlParameter ControlID="TxtNomeEmitente" 
                                ConvertEmptyStringToNull="False" Name=":nome_emitente" PropertyName="Text" 
                                Type="String" />
                            <asp:ControlParameter ControlID="DdlDepartamento" 
                                ConvertEmptyStringToNull="False" Name=":departamento1" 
                                PropertyName="SelectedValue" Type="String" />
                            <asp:ControlParameter ControlID="DdlDepartamento" 
                                ConvertEmptyStringToNull="False" Name=":departamento2" 
                                PropertyName="SelectedValue" Type="String" />
                            <asp:ControlParameter ControlID="ddlRegiao" ConvertEmptyStringToNull="False" 
                                DbType="String" Name=":codregiao1" PropertyName="SelectedValue" />
                            <asp:ControlParameter ControlID="ddlRegiao" ConvertEmptyStringToNull="False" 
                                DbType="String" Name=":codregiao2" PropertyName="SelectedValue" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
        </tr>
        <tr>
        <td>&nbsp;</td>
        <td style="text-align: center; font-weight: bold">&nbsp;</td>
        <td colspan="2" 
                style="text-align: center; font-weight: bold; border-collapse: collapse;">&nbsp;</td>
        </tr>
        <tr>
        <td></td>
        <td style="text-align: center; font-weight: bold">Absoluto</td>
        <td style="text-align: center; font-weight: bold">Percentual</td>
        <td style="width: 60%">&nbsp;</td>
        </tr>
        <tr>
        <td style="text-align: right; font-weight: bold">Total</td>
        <td style="text-align: center; font-weight: bold">
            <asp:Label ID="LblTotalAbsoluto" runat="server" Text="0"></asp:Label>
            </td>
        <td style="text-align: center; font-weight: bold">
            <asp:Label ID="LblTotalPercentual" runat="server" Text="0"></asp:Label>
            </td>
        <td style="text-align: center; font-weight: bold">&nbsp;</td>
        </tr>
        <tr>
        <td style="text-align: right; font-weight: bold">No Prazo</td>
        <td style="text-align: center; font-weight: bold">
            <asp:Label ID="LblTotalConforme" runat="server" Text="0"></asp:Label>
            </td>
        <td style="text-align: center; font-weight: bold">
            <asp:Label ID="LblPercentualConforme" runat="server" Text="0"></asp:Label>
            </td>
        <td style="text-align: center; font-weight: bold">&nbsp;</td>
        </tr>
        <tr>
        <td style="text-align: right; font-weight: bold">Fora do Prazo</td>
        <td style="text-align: center; font-weight: bold">
            <asp:Label ID="LblTotalNaoConforme" runat="server" Text="0"></asp:Label>
            </td>
        <td style="text-align: center; font-weight: bold">
            <asp:Label ID="LblPercentualNaoConforme" runat="server" Text="0"></asp:Label>
            </td>
        <td style="text-align: center; font-weight: bold">&nbsp;</td>
        </tr>
        <tr>
        <td style="text-align: right; font-weight: bold">&nbsp;</td>
        <td style="text-align: center; font-weight: bold">
            &nbsp;</td>
        <td style="text-align: center; font-weight: bold">
            &nbsp;</td>
        <td style="text-align: center; font-weight: bold">&nbsp;</td>
        </tr>
        <tr>
        <td style="text-align: right; font-weight: bold">&nbsp;</td>
        <td style="text-align: center; font-weight: bold">
            Horas</td>
        <td style="text-align: center; font-weight: bold">
            Dias</td>
        <td style="text-align: center; font-weight: bold">&nbsp;</td>
        </tr>
        <tr>
        <td style="text-align: right; font-weight: bold">Média</td>
        <td style="text-align: center; font-weight: bold">
            <asp:Label ID="LblQtdMediaHoras" runat="server" Text="0,00"></asp:Label>
            </td>
        <td style="text-align: center; font-weight: bold">
            <asp:Label ID="LblQtdMediaDias" runat="server" Text="0,00"></asp:Label>
            </td>
        <td style="text-align: center; font-weight: bold">&nbsp;</td>
        </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
