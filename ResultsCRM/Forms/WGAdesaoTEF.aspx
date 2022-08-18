<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGAdesaoTEF.aspx.vb" Inherits="ResultsCRM.WGAdesaoTEF" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="TituloMovimento">Painel de Adesões TEF</div>
    <div class="Erro">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:Label ID="LblErro" runat="server"></asp:Label>
    <div style="text-align: left; vertical-align: middle;">
    
            <asp:Label ID="Label11" runat="server" CssClass="TextoCadastro_BGBranco" 
                Height="16px" Text="Filtros"></asp:Label>
            <br />
    
            <asp:Label ID="Label2" runat="server" CssClass="TextoCadastro_BGBranco" 
                Height="16px"  style="text-align:right"
                Text="&nbsp;&nbsp;Código:" Width="55px"></asp:Label>
            <asp:TextBox ID="TxtCodigo" runat="server" CssClass="CampoCadastro" 
                MaxLength="6" Width="65px"></asp:TextBox>
&nbsp;
            <asp:Label ID="Label14" runat="server" CssClass="TextoCadastro_BGBranco" 
                Height="16px" Text="Nome:"></asp:Label>
            <asp:TextBox ID="TxtNome" runat="server" CssClass="CampoCadastro" Width="270px"></asp:TextBox>
            <asp:Label ID="Label3" runat="server" CssClass="TextoCadastro_BGBranco" style="text-align:right"
                Height="16px" Text="&nbsp;CNPJ:" Width="50px"></asp:Label>
            <asp:TextBox ID="TxtCNPJ" runat="server" CssClass="CampoCadastro" 
                MaxLength="14" Width="140px"></asp:TextBox>
            <br />
    
            <asp:Label ID="Label6" runat="server" CssClass="TextoCadastro_BGBranco" style="text-align:right"
                Height="16px" Text="Grupo:" Width="55px"></asp:Label>
            <asp:DropDownList ID="DdlGrupoTEF" runat="server" CssClass="CampoCadastro" 
                Width="150px">
            </asp:DropDownList>
    
            <asp:Label ID="Label12" runat="server" CssClass="TextoCadastro_BGBranco" 
                Height="16px"  style="text-align:right"
                Text="&nbsp;Ag. Vendas:" Width="84px"></asp:Label>
                    <asp:DropDownList ID="ddlAgente" runat="server" 
                        CssClass="CampoCadastro" Width="254px" ClientIDMode="Static">
                    </asp:DropDownList>
    
            <br />
    
            <asp:Label ID="Label17" runat="server" CssClass="TextoCadastro_BGBranco" style="text-align: right"
                Height="16px" Text="Fechado:" 
                Width="55px"></asp:Label>
            <asp:DropDownList ID="DdlFechado" runat="server" CssClass="CampoCadastro">
                <asp:ListItem Value="S">Sim</asp:ListItem>
                <asp:ListItem Value="N">Não</asp:ListItem>
                <asp:ListItem Selected="True" Value="A">Todos</asp:ListItem>
            </asp:DropDownList>
    
            <asp:Label ID="Label18" runat="server" CssClass="TextoCadastro_BGBranco"  style="text-align:right"
                Height="16px" Text="Fechamento:" Width="80px"></asp:Label>
            <asp:TextBox ID="TxtFechamentoI" runat="server" CssClass="CampoCadastro" 
                MaxLength="14" Width="65px"></asp:TextBox><cc1:MaskedEditExtender ID="TxtFechamentoI_MaskedEditExtender" runat="server" 
                BehaviorID="TxtFechamentoI_MaskedEditExtender" Century="2000" 
                CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                CultureThousandsPlaceholder="" CultureTimePlaceholder="" Mask="99/99/9999" 
                MaskType="Date" TargetControlID="TxtFechamentoI" UserDateFormat="DayMonthYear" />
            <asp:Label ID="Label19" runat="server" CssClass="TextoCadastro_BGBranco" style="text-align:center"
                Height="16px" Text="a" Width="16px"></asp:Label>
            <asp:TextBox ID="TxtFechamentoF" runat="server" CssClass="CampoCadastro" 
                MaxLength="14" Width="65px"></asp:TextBox><cc1:MaskedEditExtender ID="TxtFechamentoF_MaskedEditExtender" runat="server" 
                BehaviorID="TxtFechamentoF_MaskedEditExtender" Century="2000" 
                CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                CultureThousandsPlaceholder="" CultureTimePlaceholder="" Mask="99/99/9999" 
                MaskType="Date" TargetControlID="TxtFechamentoF" UserDateFormat="DayMonthYear" />
    
            <asp:Label ID="Label15" runat="server" CssClass="TextoCadastro_BGBranco"  style="text-align:right"
                Height="16px" Text="Inclusão:" Width="55px"></asp:Label>
            <asp:TextBox ID="TxtInclusaoI" runat="server" CssClass="CampoCadastro" 
                MaxLength="14" Width="65px"></asp:TextBox><cc1:MaskedEditExtender ID="TxtInclusaoI_MaskedEditExtender" runat="server" 
                BehaviorID="TxtInclusaoI_MaskedEditExtender" Century="2000" 
                CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                CultureThousandsPlaceholder="" CultureTimePlaceholder="" Mask="99/99/9999" 
                MaskType="Date" TargetControlID="TxtInclusaoI" UserDateFormat="DayMonthYear" />
            <asp:Label ID="Label16" runat="server" CssClass="TextoCadastro_BGBranco" style="text-align:center"
                Height="16px" Text="a" Width="16px"></asp:Label>
            <asp:TextBox ID="TxtInclusaoF" runat="server" CssClass="CampoCadastro" 
                MaxLength="14" Width="65px"></asp:TextBox><cc1:MaskedEditExtender ID="TxtInclusaoF_MaskedEditExtender" runat="server" 
                BehaviorID="TxtInclusaoF_MaskedEditExtender" Century="2000" 
                CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                CultureThousandsPlaceholder="" CultureTimePlaceholder="" Mask="99/99/9999" 
                MaskType="Date" TargetControlID="TxtInclusaoF" UserDateFormat="DayMonthYear" />
    
            <br />
    
            <asp:Label ID="Label7" runat="server" CssClass="TextoCadastro_BGBranco"  style="text-align:right"
                Height="16px" Text="Etapa1:" Width="55px"></asp:Label>
            <asp:DropDownList ID="DdlEtapa1" runat="server" CssClass="CampoCadastro">
                <asp:ListItem Value="S">Sim</asp:ListItem>
                <asp:ListItem Value="N">Não</asp:ListItem>
                <asp:ListItem Selected="True" Value="A">Todos</asp:ListItem>
            </asp:DropDownList>
    
            <asp:Label ID="Label8" runat="server" CssClass="TextoCadastro_BGBranco" style="text-align:right"
                Height="16px" 
                Text="&nbsp;&nbsp;Etapa2:" Width="80px"></asp:Label>
            <asp:DropDownList ID="DdlEtapa2" runat="server" CssClass="CampoCadastro">
                <asp:ListItem Value="S">Sim</asp:ListItem>
                <asp:ListItem Value="N">Não</asp:ListItem>
                <asp:ListItem Selected="True" Value="A">Todos</asp:ListItem>
            </asp:DropDownList>
    
            <asp:Label ID="Label9" runat="server" CssClass="TextoCadastro_BGBranco" style="text-align:right"
                Height="16px" Text="&nbsp;&nbsp;Aceito:" Width="120px"></asp:Label>
            <asp:DropDownList ID="DdlAceito" runat="server" CssClass="CampoCadastro">
                <asp:ListItem Value="S">Sim</asp:ListItem>
                <asp:ListItem Selected="True" Value="N">Não</asp:ListItem>
                <asp:ListItem Value="A">Todos</asp:ListItem>
            </asp:DropDownList>
    
            <asp:Label ID="Label10" runat="server" CssClass="TextoCadastro_BGBranco" style="text-align:right"
                Height="16px" Text="&nbsp;&nbsp;Validado:" Width="70px"></asp:Label>
            <asp:DropDownList ID="DdlValidado" runat="server" CssClass="CampoCadastro">
                <asp:ListItem Value="S">Sim</asp:ListItem>
                <asp:ListItem Value="N">Não</asp:ListItem>
                <asp:ListItem Selected="True" Value="A">Todos</asp:ListItem>
            </asp:DropDownList>
    
            <br />
    
            <asp:Label ID="Label20" runat="server" CssClass="TextoCadastro_BGBranco" 
                Height="16px" style="text-align: right"
                Text="&nbsp;&nbsp;Stone:" Width="55px"></asp:Label>
            <asp:DropDownList ID="DdlAdquirente" runat="server" CssClass="CampoCadastro">
                <asp:ListItem Value="S">Sim</asp:ListItem>
                <asp:ListItem Value="N">Não</asp:ListItem>
                <asp:ListItem Selected="True" Value="A">Todos</asp:ListItem>
            </asp:DropDownList>
    
            <asp:Label ID="Label21" runat="server" CssClass="TextoCadastro_BGBranco" style="text-align:right"
                Height="16px" Text="&nbsp;Cappta:" Width="80px"></asp:Label>
            <asp:DropDownList ID="DdlParceiro" runat="server" CssClass="CampoCadastro">
                <asp:ListItem Value="S">Sim</asp:ListItem>
                <asp:ListItem Value="N">Não</asp:ListItem>
                <asp:ListItem Value="A" Selected="True">Todos</asp:ListItem>
            </asp:DropDownList>
    
            <asp:Label ID="Label22" runat="server" CssClass="TextoCadastro_BGBranco" style="text-align:right"
                Height="16px" Text="&nbsp;&nbsp;Equip. Recebido:" Width="120px"></asp:Label>
            <asp:DropDownList ID="DdlEquipamento" runat="server" CssClass="CampoCadastro">
                <asp:ListItem Value="S">Sim</asp:ListItem>
                <asp:ListItem Value="N">Não</asp:ListItem>
                <asp:ListItem Selected="True" Value="A">Todos</asp:ListItem>
            </asp:DropDownList>
    
            <asp:Label ID="Label23" runat="server" CssClass="TextoCadastro_BGBranco" style="text-align:right"
                Height="16px" Text="&nbsp;&nbsp;Instalado:" Width="70px"></asp:Label>
            <asp:DropDownList ID="DdlInstalado" runat="server" CssClass="CampoCadastro">
                <asp:ListItem Value="S">Sim</asp:ListItem>
                <asp:ListItem Value="N">Não</asp:ListItem>
                <asp:ListItem Selected="True" Value="A">Todos</asp:ListItem>
            </asp:DropDownList>
    
            <br />
    
            <br />
            <asp:Button ID="BtnFiltrar" runat="server" CssClass="Botao" 
                Text="Aplicar filtro" />
            <br />
            <br />
    
    </div>
    <div style="text-align: right">
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select a.cod_emitente, e.cnpj,  a.data_inclusao, e.nome, 
       a.confirmou_contato, a.confirmou_lojas, a.aceito, a.validado, a.data_aceite, a.data_validacao,
       (select max(cod_adesao) from adesao_tef_loja where cod_emitente = e.cod_emitente) cod_adesao_tef,
       ad.nome_rede,
       al.cod_negociacao_cliente,
       pv.cod_pedido_venda,
       pv.data_emissao,
       av.nome_usuario,
       al.cadastro_adquirente,
       al.cadastro_parceiro,
       al.equipamento_enviado,
       trim(isnull((select first nff.serie || '/' || nff.cod_nfs from nfs_faturamento nff inner join nfs on nff.empresa = nfs.empresa and nff.estabelecimento = nfs.estabelecimento and nff.serie = nfs.serie and nff.cod_nfs = nfs.cod_nfs where nff.empresa = pv.empresa and nff.estabelecimento = pv.estabelecimento and nff.cod_pedido_venda = pv.cod_pedido_venda and nfs.situacao = 1),'')) nf,
       if nf = '' then 'N' else 'S' endif faturado,
       if exists(select 1 from chamado ch inner join status_chamado sc on sc.cod_status = ch.cod_status where sc.tipo = '3' and ch.empresa = al.empresa and ch.cod_chamado = al.cod_chamado_instalacao) then 'S' else 'N' endif instalado,
       e.cod_emitente || ';' || e.cnpj chave,
       if pv.cod_pedido_venda is not null then 'S' else 'N' endif gerou_pedido
  from adesao_tef_emitente a left outer join v_emitente_endereco e on a.cod_emitente = e.cod_emitente
                             left outer join adesao_tef_loja al on al.empresa = a.empresa and al.cod_emitente = a.cod_emitente and al.cnpj = e.cnpj
                             left outer join adesao_tef ad on a.empresa = ad.empresa and ad.cod_adesao = cod_adesao_tef
                             left outer join negociacao_cliente nc on nc.empresa = al.empresa and nc.cod_negociacao_cliente = al.cod_negociacao_cliente
                             left outer join pedido_venda pv on pv.empresa = nc.empresa and pv.estabelecimento = nc.estabelecimento and pv.cod_negociacao_cliente = nc.cod_negociacao_cliente
                             left outer join sysusuario av on av.cod_usuario = nc.cod_agente_venda
 where e.cod_emitente = f_isnull_or_empty(:codigo, e.cod_emitente)
   and (:grupo1 = -1 or cod_adesao_tef = :grupo2)
   and e.nome like '%' || f_isnull_or_empty(:nome, e.nome) || '%'
   and e.cnpj = f_isnull_or_empty(:cnpj, e.cnpj)
   and al.cod_negociacao_cliente is not null
   and :etapa1 in (isnull(a.confirmou_contato,'N'),'A')
   and :etapa2 in (isnull(a.confirmou_lojas,'N'),'A')
   and :aceito in (isnull(a.aceito,'N'),'A')
   and :validado in (isnull(a.validado,'N'),'A')
   and :agente in (nc.cod_agente_venda,0)
   and exists(select 1 from acesso_campanha_tef where empresa = 1 and cod_emitente = e.cod_emitente and tipo_conteudo = 2)
   and date(isnull(pv.data_emissao,'1900-01-01')) between convert(date,f_isnull_or_empty(:fechamento_i,convert(varchar(10),date(isnull(pv.data_emissao,'1900-01-01')),103)),103) and convert(date,f_isnull_or_empty(:fechamento_f,convert(varchar(10),date(isnull(pv.data_emissao,'1900-01-01')),103)),103)
   and :fechado in ('A', gerou_pedido)
   and date(isnull(a.data_inclusao,'1900-01-01')) between convert(date,f_isnull_or_empty(:inclusao_i,convert(varchar(10),date(isnull(a.data_inclusao,'1900-01-01')),103)),103) and convert(date,f_isnull_or_empty(:inclusao_f,convert(varchar(10),date(isnull(a.data_inclusao,'1900-01-01')),103)),103)
   and :adquirente in ('A', isnull(al.cadastro_adquirente,'N'))
   and :parceiro in ('A', isnull(al.cadastro_parceiro,'N'))
   and :equipamento in ('A', isnull(al.equipamento_enviado,'N'))
   and :instalado in ('A', isnull(instalado,'N'))
order by a.data_aceite desc, e.nome">
            <SelectParameters>
                <asp:ControlParameter ControlID="TxtCodigo"      ConvertEmptyStringToNull="False" DbType="String" Name=":codigo"       PropertyName="Text" />
                <asp:ControlParameter ControlID="DdlGrupoTEF"    ConvertEmptyStringToNull="False" DbType="String" Name=":grupo1"       PropertyName="SelectedValue" />
                <asp:ControlParameter ControlID="DdlGrupoTEF"    ConvertEmptyStringToNull="False" DbType="String" Name=":grupo2"       PropertyName="SelectedValue" />
                <asp:ControlParameter ControlID="TxtNome"        ConvertEmptyStringToNull="False" DbType="String" Name=":nome"         PropertyName="Text" />
                <asp:ControlParameter ControlID="TxtCNPJ"        ConvertEmptyStringToNull="False" DbType="String" Name=":cnpj"         PropertyName="Text" />
                <asp:ControlParameter ControlID="DdlEtapa1"      ConvertEmptyStringToNull="False" DbType="String" Name=":etapa1"       PropertyName="SelectedValue" />
                <asp:ControlParameter ControlID="DdlEtapa2"      ConvertEmptyStringToNull="False" DbType="String" Name=":etapa2"       PropertyName="SelectedValue" />
                <asp:ControlParameter ControlID="DdlAceito"      ConvertEmptyStringToNull="False" DbType="String" Name=":aceito"       PropertyName="SelectedValue" />
                <asp:ControlParameter ControlID="DdlValidado"    ConvertEmptyStringToNull="False" DbType="String" Name=":validado"     PropertyName="SelectedValue" />
                <asp:ControlParameter ControlID="ddlAgente"      ConvertEmptyStringToNull="False" DbType="String" Name=":agente"       PropertyName="SelectedValue" />
                <asp:ControlParameter ControlID="TxtFechamentoI" ConvertEmptyStringToNull="False" DbType="String" Name=":fechamento_i" PropertyName="Text" />
                <asp:ControlParameter ControlID="TxtFechamentoF" ConvertEmptyStringToNull="False" DbType="String" Name=":fechamento_f" PropertyName="Text" />
                <asp:ControlParameter ControlID="DdlFechado"     ConvertEmptyStringToNull="False" DbType="String" Name=":fechado"      PropertyName="SelectedValue" />
                <asp:ControlParameter ControlID="TxtInclusaoI"   ConvertEmptyStringToNull="False" DbType="String" Name=":inclusao_i"   PropertyName="Text" />
                <asp:ControlParameter ControlID="TxtInclusaoF"   ConvertEmptyStringToNull="False" DbType="String" Name=":inclusao_f"   PropertyName="Text" />
                <asp:ControlParameter ControlID="DdlAdquirente"  ConvertEmptyStringToNull="False" DbType="String" Name=":adquirente"   PropertyName="SelectedValue" />
                <asp:ControlParameter ControlID="DdlParceiro"    ConvertEmptyStringToNull="False" DbType="String" Name=":parceiro"     PropertyName="SelectedValue" />
                <asp:ControlParameter ControlID="DdlEquipamento" ConvertEmptyStringToNull="False" DbType="String" Name=":equipamento"  PropertyName="SelectedValue" />
                <asp:ControlParameter ControlID="DdlInstalado"   ConvertEmptyStringToNull="False" DbType="String" Name=":instalado"    PropertyName="SelectedValue" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" CssClass="TextoCadastro" DataSourceID="SqlDataSource1" 
            ForeColor="#333333" GridLines="None" Width="100%" 
            AllowSorting="True" Font-Size="7pt">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" />
            <Columns>
                <asp:BoundField DataField="nome_rede" HeaderText="Grupo TEF" 
                    SortExpression="nome_rede">
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Código" SortExpression="cod_emitente">
                    <ItemTemplate>
                        <asp:Label ID="LblCodEmitente" runat="server" 
                            Text='<%# Bind("cod_emitente") %>'></asp:Label>
                        <asp:Label ID="LblCodAdesao" runat="server" 
                            Text='<%# Bind("cod_adesao_tef") %>' Visible="False"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("cod_emitente") %>'></asp:Label>
                    </EditItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:BoundField DataField="nome" HeaderText="Razão Social" 
                    SortExpression="nome" >
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="cnpj" HeaderText="CNPJ" SortExpression="cnpj" >
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="data_inclusao" DataFormatString="{0:dd/MM/yy HH:mm}" 
                    HeaderText="Inclusão" SortExpression="data_inclusao">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="aceito" HeaderText="Aceito" 
                    SortExpression="aceito" >
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="validado" HeaderText="Validado" 
                    SortExpression="validado" >
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="nome_usuario" HeaderText="Agente de Vendas" 
                    SortExpression="nome_usuario">
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="cod_negociacao_cliente" HeaderText="Nº Negociação" 
                    SortExpression="cod_negociacao_cliente">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="cod_pedido_venda" HeaderText="Nº Pedido" 
                    SortExpression="cod_pedido_venda">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="data_emissao" DataFormatString="{0:dd/MM/yyyy}" 
                    HeaderText="Data Fechamento" SortExpression="data_emissao">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="cadastro_adquirente" HeaderText="Cadastro Stone" 
                    SortExpression="cadastro_adquirente">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="cadastro_parceiro" HeaderText="Cadastro Cappta" 
                    SortExpression="cadastro_parceiro">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="equipamento_enviado" 
                    HeaderText="Equipamento Recebido" SortExpression="equipamento_enviado">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Faturado" SortExpression="faturado">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("faturado") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("faturado") %>'></asp:Label>
                        <br />
                        <asp:Label ID="Label13" runat="server" Text='<%# Eval("nf") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:BoundField DataField="instalado" HeaderText="Instalado" 
                    SortExpression="instalado">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Editar">
                    <ItemTemplate>
                        <asp:ImageButton ID="BtnAlterarRegistro" runat="server" 
                            CommandArgument='<%# Eval("chave") %>' CommandName="ALTERAR" 
                            ImageUrl="~/Imagens/BtnEditar.png" ToolTip="Alterar dados do registro." />
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="LnkAdesao" runat="server">Adesão</asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
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
    </div>
    <div class="TextoCadastro" style="text-align: center">
        <br />
        <asp:Label ID="Label5" runat="server" Text="Qtd. Registros:"></asp:Label>
        &nbsp;<asp:Label ID="LblQtd" runat="server" Font-Bold="True" Text="Label"></asp:Label>
        </div>
    </form>
</body>
</html>
