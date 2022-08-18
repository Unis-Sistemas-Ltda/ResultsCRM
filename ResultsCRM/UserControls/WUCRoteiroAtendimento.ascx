<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCRoteiroAtendimento.ascx.vb" Inherits="ResultsCRM.WUCRoteiroAtendimento" %>
<%@ Register src="../OutrosControles/TextBoxInteiro.ascx" tagname="TextBoxInteiro" tagprefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit"%>
<link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
<div class="TituloMovimento">
    <asp:ScriptManager ID="ScriptManager1" runat="server" 
        EnableScriptGlobalization="True">
    </asp:ScriptManager>
    Roteiro de Atendimento</div>
<table class="TextoCadastro" style="width:100%;">
    <tr>
        <td class="Erro" colspan="2">
            <asp:Label ID="LblErro" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Roteiro:</td>
        <td class="CelulaCampoCadastro">
            <asp:Label ID="LblCodRoteiro" runat="server" Font-Bold="True"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Técnico:</td>
        <td class="CelulaCampoCadastro">
                        <asp:DropDownList ID="DdlAgenteTecnico" runat="server" CssClass="CampoCadastro" 
                            Width="300px" AutoPostBack="True">
                        </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Data:</td>
        <td class="CelulaCampoCadastro">
                        <asp:TextBox ID="TxtDataAtendimento" runat="server" CssClass="CampoCadastro" 
                            MaxLength="10" style="text-align:center" Width="90px"></asp:TextBox><ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" 
                        TargetControlID="TxtDataAtendimento" FirstDayOfWeek="Sunday"
                        Format="dd/MM/yyyy" TodaysDateFormat="d MMMM yyyy"></ajaxToolkit:CalendarExtender>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            &nbsp;</td>
        <td class="CelulaCampoCadastro">
                        <asp:CheckBox ID="CbxSemTecnico" runat="server" AutoPostBack="True" 
                            Text="Mostrar OS's sem agente técnico vinculado" />
        </td>
    </tr>
    <tr>
        <td colspan="2" style="text-align: right">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" 
                GridLines="None" Width="100%">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:TemplateField SortExpression="marcado">
                        <EditItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("marcado") %>'></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="CbxMarcado" runat="server" Checked='<%# Bind("marcado") %>' />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Sequência" SortExpression="sequencia">
                        <EditItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("sequencia") %>'></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:TextBox ID="TxtSequencia" runat="server" CssClass="CampoCadastro" style="text-align:center"
                                MaxLength="3" Text='<%# Bind("sequencia") %>' Width="40px"></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="cod_chamado" HeaderText="Chamado" ReadOnly="True" 
                        SortExpression="cod_chamado">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="OS" SortExpression="cod_pedido_venda">
                        <EditItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Eval("cod_pedido_venda") %>'></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="LblCodPedidoVenda" runat="server" 
                                Text='<%# Bind("cod_pedido_venda") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Cliente" SortExpression="nome">
                        <EditItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("nome") %>'></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("nome") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="bairro_nome" HeaderText="Bairro" ReadOnly="True" 
                        SortExpression="bairro_nome">
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:BoundField>
                    <asp:BoundField DataField="cidade_nome" HeaderText="Cidade" ReadOnly="True" 
                        SortExpression="cidade_nome">
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:BoundField>
                    <asp:BoundField DataField="estado_sigla" HeaderText="UF" ReadOnly="True" 
                        SortExpression="estado_sigla">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                    </asp:BoundField>
                    <asp:BoundField DataField="assunto" HeaderText="Assunto" ReadOnly="True" 
                        SortExpression="assunto">
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:BoundField>
                    <asp:BoundField DataField="servico_solicitado" HeaderText="Serviço Solicitado" 
                        ReadOnly="True" SortExpression="servico_solicitado">
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
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select pv.empresa, pv.estabelecimento, pv.cod_pedido_venda cod_pedido_venda, 'False' marcado, null sequencia, 99999 seq_order, pv.cod_chamado, pv.cod_emitente, e.nome, isnull(pa.bairro,e.bairro_nome) bairro_nome, isnull(cip.nome_cidade,e.cidade_nome) cidade_nome, isnull(ufp.sigla,e.estado_sigla) estado_sigla, ch.assunto,
       (select list(servico_solicitado) from pedido_venda_solicitacao where empresa = pv.empresa and estabelecimento = pv.estabelecimento and cod_pedido_venda = pv.cod_pedido_venda) servico_solicitado
  from pedido_venda pv inner join pedido_venda_agente_tecnico pt on pv.empresa          = pt.empresa
                                                                and pv.estabelecimento  = pt.estabelecimento
                                                                and pv.cod_pedido_venda = pt.cod_pedido_venda
                       inner join chamado ch on ch.empresa         = pv.empresa
                                            and ch.cod_chamado     = pv.cod_chamado
                       inner join v_emitente_endereco e on pv.cod_emitente     = e.cod_emitente
                                                       and pv.cnpj_faturamento = e.cnpj
                       left outer join ponto_atendimento pa on pa.cod_emitente             = ch.cod_emitente_atendimento
                                                           and pa.numero_ponto_atendimento = ch.numero_ponto_atendimento
                       left outer join estado ufp on ufp.cod_pais   = pa.cod_pais
                                                 and ufp.cod_estado = pa.cod_estado
                       left outer join cidade cip on cip.cod_pais   = pa.cod_pais
                                                 and cip.cod_estado = pa.cod_estado
                                                 and cip.cod_cidade = pa.cod_cidade
 where pv.id_os              = 'S'
   and pv.empresa            = :empresa1
   and pv.estabelecimento    = :estabelecimento1
   and pt.cod_agente_tecnico = :cod_agente_tecnico1
   and pv.status_digitacao   = 1
   and not exists(select 1
                    from roteiro_atendimento_pedido_venda rp inner join roteiro_atendimento rot on rp.empresa         = rot.empresa
                                                                                               and rp.estabelecimento = rot.estabelecimento
                                                                                               and rp.cod_roteiro     = rot.cod_roteiro
                   where rp.empresa             = pv.empresa
                     and rp.estabelecimento     = pv.estabelecimento
                     and rp.cod_pedido_venda    = pv.cod_pedido_venda
                     and rot.cod_agente_tecnico = :cod_agente_tecnico2)
 union all
select pv.empresa, pv.estabelecimento, pv.cod_pedido_venda cod_pedido_venda, 'True' marcado, rp.sequencia sequencia, rp.sequencia seq_order, pv.cod_chamado, pv.cod_emitente, e.nome,isnull(pa.bairro,e.bairro_nome) bairro_nome, isnull(cip.nome_cidade,e.cidade_nome) cidade_nome, isnull(ufp.sigla,e.estado_sigla) estado_sigla, ch.assunto,
       (select list(servico_solicitado) from pedido_venda_solicitacao where empresa = pv.empresa and estabelecimento = pv.estabelecimento and cod_pedido_venda = pv.cod_pedido_venda) servico_solicitado
  from pedido_venda pv inner join pedido_venda_agente_tecnico pt on pv.empresa          = pt.empresa
                                                                and pv.estabelecimento  = pt.estabelecimento
                                                                and pv.cod_pedido_venda = pt.cod_pedido_venda
                       inner join chamado ch on ch.empresa         = pv.empresa
                                            and ch.cod_chamado     = pv.cod_chamado
                       inner join v_emitente_endereco e on pv.cod_emitente     = e.cod_emitente
                                                       and pv.cnpj_faturamento = e.cnpj
                       inner join roteiro_atendimento_pedido_venda rp on rp.empresa             = pv.empresa
                                                                     and rp.estabelecimento     = pv.estabelecimento
                                                                     and rp.cod_pedido_venda    = pv.cod_pedido_venda
                       inner join roteiro_atendimento rot on rp.empresa         = rot.empresa
                                                         and rp.estabelecimento = rot.estabelecimento
                                                         and rp.cod_roteiro     = rot.cod_roteiro
                       left outer join ponto_atendimento pa on pa.cod_emitente             = ch.cod_emitente_atendimento
                                                           and pa.numero_ponto_atendimento = ch.numero_ponto_atendimento
                       left outer join estado ufp on ufp.cod_pais   = pa.cod_pais
                                                 and ufp.cod_estado = pa.cod_estado
                       left outer join cidade cip on cip.cod_pais   = pa.cod_pais
                                                 and cip.cod_estado = pa.cod_estado
                                                 and cip.cod_cidade = pa.cod_cidade
 where pv.id_os              = 'S'
   and pv.empresa            = :empresa2
   and pv.estabelecimento    = :estabelecimento2
   and pt.cod_agente_tecnico = :cod_agente_tecnico3
   and pv.status_digitacao   = 1
   and rot.cod_roteiro       = :cod_roteiro
 union all
select pv.empresa, pv.estabelecimento, pv.cod_pedido_venda cod_pedido_venda, 'False' marcado, null sequencia, 99999 seq_order, pv.cod_chamado, pv.cod_emitente, e.nome, isnull(pa.bairro,e.bairro_nome) bairro_nome, isnull(cip.nome_cidade,e.cidade_nome) cidade_nome, isnull(ufp.sigla,e.estado_sigla) estado_sigla, ch.assunto,
       (select list(servico_solicitado) from pedido_venda_solicitacao where empresa = pv.empresa and estabelecimento = pv.estabelecimento and cod_pedido_venda = pv.cod_pedido_venda) servico_solicitado
  from pedido_venda pv inner join chamado ch on ch.empresa         = pv.empresa
                                            and ch.cod_chamado     = pv.cod_chamado
                       inner join v_emitente_endereco e on pv.cod_emitente     = e.cod_emitente
                                                       and pv.cnpj_faturamento = e.cnpj
                       left outer join ponto_atendimento pa on pa.cod_emitente             = ch.cod_emitente_atendimento
                                                           and pa.numero_ponto_atendimento = ch.numero_ponto_atendimento
                       left outer join estado ufp on ufp.cod_pais   = pa.cod_pais
                                                 and ufp.cod_estado = pa.cod_estado
                       left outer join cidade cip on cip.cod_pais   = pa.cod_pais
                                                 and cip.cod_estado = pa.cod_estado
                                                 and cip.cod_cidade = pa.cod_cidade
 where pv.id_os              = 'S'
   and pv.empresa            = :empresa3
   and pv.estabelecimento    = :estabelecimento3
   and pv.status_digitacao   = 1
   and not exists(select 1
                    from pedido_venda_agente_tecnico pt
                   where pt.empresa             = pv.empresa
                     and pt.estabelecimento     = pv.estabelecimento
                     and pt.cod_pedido_venda    = pv.cod_pedido_venda
                     and pt.cod_agente_tecnico  = :cod_agente_tecnico4)
   and :sem_tecnico = 'True'
 order by seq_order, cod_pedido_venda">
                <SelectParameters>
                    <asp:SessionParameter ConvertEmptyStringToNull="False" DbType="String" 
                        Name="empresa1" SessionField="GlEmpresa" />
                    <asp:SessionParameter ConvertEmptyStringToNull="False" DbType="String" 
                        Name="estabelecimento1" SessionField="GlEstabelecimento" />
                    <asp:ControlParameter ControlID="DdlAgenteTecnico" 
                        ConvertEmptyStringToNull="False" DbType="String" Name="cod_agente_tecnico1" 
                        PropertyName="SelectedValue" />
                    <asp:ControlParameter ControlID="DdlAgenteTecnico" 
                        ConvertEmptyStringToNull="False" DbType="String" Name="cod_agente_tecnico2" 
                        PropertyName="SelectedValue" />
                    <asp:SessionParameter ConvertEmptyStringToNull="False" DbType="String" 
                        Name="empresa2" SessionField="GlEmpresa" />
                    <asp:SessionParameter ConvertEmptyStringToNull="False" DbType="String" 
                        Name="estabelecimento2" SessionField="GlEstabelecimento" />
                    <asp:ControlParameter ControlID="DdlAgenteTecnico" 
                        ConvertEmptyStringToNull="False" DbType="String" Name="cod_agente_tecnico3" 
                        PropertyName="SelectedValue" />
                    <asp:ControlParameter ControlID="LblCodRoteiro" Name="cod_roteiro" 
                        PropertyName="Text" />
                    <asp:SessionParameter ConvertEmptyStringToNull="False" DbType="String" 
                        Name="empresa3" SessionField="GlEmpresa" />
                    <asp:SessionParameter ConvertEmptyStringToNull="False" DbType="String" 
                        Name="estabelecimento3" SessionField="GlEstabelecimento" />
                    <asp:ControlParameter ControlID="DdlAgenteTecnico" 
                        ConvertEmptyStringToNull="False" DbType="String" Name="cod_agente_tecnico4" 
                        PropertyName="SelectedValue" />
                    <asp:ControlParameter ControlID="CbxSemTecnico" 
                        ConvertEmptyStringToNull="False" DbType="String" Name="sem_tecnico" 
                        PropertyName="Checked" />
                </SelectParameters>
            </asp:SqlDataSource>
        </td>
    </tr>
    <tr>
        <td colspan="2" style="text-align: center">
            <asp:Button ID="BtnGravar" runat="server" CssClass="Botao" Text="Gravar" />
        &nbsp;
            <asp:Button ID="BtnVoltar" runat="server" CssClass="Botao" Text="Voltar" />
        </td>
    </tr>
</table>
