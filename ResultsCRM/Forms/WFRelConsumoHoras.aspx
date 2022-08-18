<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WFRelConsumoHoras.aspx.vb" Inherits="ResultsCRM.WFRelConsumoHoras" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <table width="100%">
    <tr>
        <td colspan="7" class="TituloRelatorio">

            Consumo de Horas por Cliente/Contrato<asp:ScriptManager 
                ID="ScriptManager1" runat="server" EnableScriptGlobalization="True">
            </asp:ScriptManager>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">

            Cód. Cliente:</td>
        <td>

                    <asp:TextBox ID="TxtCodEmitente" runat="server" 
                        CssClass="CampoCadastro" Width="60px" AutoPostBack="True"></asp:TextBox>

        </td>
        <td style="text-align: right">

            Nome:</td>
        <td>

                    <asp:TextBox ID="TxtNomeEmitente" runat="server" CssClass="CampoCadastro" 
                        ToolTip="Informe o nome ou parte do nome do cliente." Width="195px"></asp:TextBox>

        </td>
        <td style="text-align: right">

            Período:</td>
        <td>

                    <asp:TextBox ID="TxtDataI" runat="server" CssClass="CampoCadastro" 
                        Width="80px"></asp:TextBox><cc1:CalendarExtender id="CalendarExtender01" runat="server" firstdayofweek="Sunday" 
                        format="dd/MM/yyyy" targetcontrolid="TxtDataI" todaysdateformat="d MMMM yyyy"></cc1:CalendarExtender>
                        <cc1:MaskedEditExtender ID="TxtDataI_MaskedEditExtender" runat="server" 
                BehaviorID="TxtDataI_MaskedEditExtender" Century="2000" 
                CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                CultureThousandsPlaceholder="" CultureTimePlaceholder="" Mask="99/99/9999" 
                MaskType="Date" TargetControlID="TxtDataI" 
                UserDateFormat="DayMonthYear" />
                    <asp:Label ID="Label17" runat="server" Height="16px" Text="&nbsp;a&nbsp;" 
                        Width="16px"></asp:Label>
                    <asp:TextBox ID="TxtDataF" runat="server" CssClass="CampoCadastro" 
                Width="80px"></asp:TextBox><cc1:CalendarExtender id="CalendarExtender2" runat="server" firstdayofweek="Sunday" 
                        format="dd/MM/yyyy" targetcontrolid="TxtDataF" todaysdateformat="d MMMM yyyy"></cc1:CalendarExtender>
                <cc1:MaskedEditExtender ID="TxtDataF_MaskedEditExtender" runat="server" 
                BehaviorID="TTxtDataF_MaskedEditExtender" Century="2000" 
                CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                CultureThousandsPlaceholder="" CultureTimePlaceholder="" Mask="99/99/9999" 
                MaskType="Date" TargetControlID="TxtDataF" 
                UserDateFormat="DayMonthYear" />

        </td>
        <td>

                    <asp:Button ID="BtnAplicarFiltro" runat="server" CssClass="Botao" 
                        Text="Aplicar Filtro" />
                &nbsp;<asp:Button ID="BtnAplicarFiltro0" runat="server" CssClass="Botao" 
                        Text="Imprimir" onclientclick="self.print(); return false;" />

        </td>
    </tr>
    </table>
    <div>
    
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                        CellPadding="4" DataSourceID="SqlDataSource2" ForeColor="#333333" 
                        GridLines="None" Width="100%" Font-Size="8pt">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:BoundField DataField="cod_emitente" HeaderText="Cód. Cliente" 
                                SortExpression="cod_emitente">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                            </asp:BoundField>
                            <asp:BoundField DataField="nome" HeaderText="Nome Cliente" 
                                SortExpression="nome">
                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                            </asp:BoundField>
                            <asp:BoundField DataField="contrato" HeaderText="Nº Contrato" 
                                SortExpression="contrato">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                            </asp:BoundField>
                            <asp:BoundField DataField="descricao" HeaderText="Descrição Contrato" 
                                SortExpression="descricao">
                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                            </asp:BoundField>
                            <asp:BoundField DataField="mes" HeaderText="Mês" SortExpression="mes">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ano" HeaderText="Ano" SortExpression="ano">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                            </asp:BoundField>
                            <asp:BoundField DataField="horas_contratadas" DataFormatString="{0:F2}" 
                                HeaderText="Horas Contratadas" SortExpression="horas_contratadas">
                            <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
                            </asp:BoundField>
                            <asp:BoundField DataField="horas_consumidas" DataFormatString="{0:F2}" 
                                HeaderText="Horas Consumidas" SortExpression="horas_consumidas">
                            <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
                            </asp:BoundField>
                        </Columns>
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                            Font-Size="8pt" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Font-Size="8pt" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
                        
                        
                        
                        
                        
                        
                        
                        
                        
                        
                        
                        SelectCommand="select e.cod_emitente,
       e.nome,
       cm.contrato,
       cm.descricao,
       month(pvi.data_entrega) mes,
       year(pvi.data_entrega) ano,
       sum(cmi.quantidade) horas_contratadas,
       sum(pvi.qtd_pedida) horas_consumidas
  from chamado c inner join pedido_venda pv on c.empresa     = pv.empresa
                                           and c.cod_chamado = pv.cod_chamado
                 inner join emitente e on e.cod_emitente = c.cod_emitente
                 inner join pedido_venda_item pvi on pvi.empresa          = pv.empresa
                                                 and pvi.estabelecimento  = pv.estabelecimento
                                                 and pvi.cod_pedido_venda = pv.cod_pedido_venda
                 inner join item i on i.cod_item = pvi.cod_item
                 left outer join contrato_manutencao cm on cm.empresa  = c.empresa
                                                       and cm.contrato = c.contrato
                 left outer join contrato_manutencao_item cmi on cmi.empresa  = c.empresa
                                                             and cmi.contrato = c.contrato
                                                             and cmi.cod_item = i.cod_item
                 left outer join tipo_cobranca_os tco on tco.cod_tipo_cobranca_os = pvi.cod_tipo_cobranca_os
 where pv.status_digitacao                in (1,2)
   and isnull(i.tipo_despesa_consultor,0) = 1
   and isnull(cmi.tipo_horas,0)           = 0
   and isnull(tco.faturado,'S')          &lt;&gt; 'N'
   and c.empresa = :empresa
   and e.cod_emitente = f_isnull_or_empty(:cod_emitente, c.cod_emitente)
   and e.nome like '%' || f_isnull_or_empty(:nome, e.nome) || '%'
   and date(pvi.data_entrega) between convert(date,f_isnull_or_empty(:data_i, date(pvi.data_entrega)),103) and convert(date,f_isnull_or_empty(:data_f, date(pvi.data_entrega)),103)
 group by e.cod_emitente, e.nome, cm.contrato, cm.descricao, mes, ano
 order by e.nome, e.cod_emitente, cm.descricao, ano, mes">
                        <SelectParameters>
                            <asp:SessionParameter Name=":empresa" SessionField="GlEmpresa" 
                                ConvertEmptyStringToNull="False" DbType="String" />
                            <asp:ControlParameter ControlID="TxtCodEmitente" Name=":cod_emitente" 
                                PropertyName="Text" ConvertEmptyStringToNull="False" DbType="String" />
<asp:ControlParameter ControlID="TxtNomeEmitente" PropertyName="Text" DbType="String" Name=":nome" 
                                ConvertEmptyStringToNull="False"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="TxtDataI" 
                                ConvertEmptyStringToNull="False" Name=":data_i" PropertyName="Text" 
                                DbType="String" />
                            <asp:ControlParameter ControlID="TxtDataF" 
                                Name=":data_f" PropertyName="Text" ConvertEmptyStringToNull="False" 
                                DbType="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
