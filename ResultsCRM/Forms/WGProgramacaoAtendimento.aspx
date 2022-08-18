<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGProgramacaoAtendimento.aspx.vb" Inherits="ResultsCRM.WGProgramacaoAtendimento" ClientIDMode="Static" %>
<%@ Register assembly="WebDataWindow" namespace="Sybase.DataWindow.Web" tagprefix="dw" %>
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
     <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                    <ProgressTemplate>
                        <div style="text-align:center; position: fixed; top: 10%; right: 46%; z-index: 10;">
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagens/carregando.gif" />
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
        <div class="TituloMovimento">Programação de Atendimento</div>
        <div>
    
            <table style="border: thin groove #CCCCCC; width:100%; font-family: verdana; font-size: 7pt; border-collapse: collapse;" 
                class="TextoCadastro_BGBranco">
                <tr>
                    <td style="text-align: right; ">
                        Cód. Programação:</td>
                    <td style="text-align: left; ">
                        <asp:TextBox ID="TxtCodProgramacao" runat="server" 
                            CssClass="CampoCadastro" MaxLength="10" style="text-align: center" 
                            Width="70px" AutoPostBack="True"></asp:TextBox>
                    </td>
                    <td style="text-align: right;">
                        Tipo Chamado:</td>
                    <td style="vertical-align: top; ">
                        <asp:DropDownList ID="ddlTipoChamado" runat="server"
                            CssClass="CampoCadastro" Width="170px" AutoPostBack="True">
                        </asp:DropDownList>
                    </td>
                    <td style="text-align: right; ">
                        <asp:Label ID="Label11" runat="server" Height="16px" Text="Analista:"></asp:Label>
    &nbsp;<asp:DropDownList ID="ddlAnalista" runat="server" 
                            CssClass="CampoCadastro" Width="180px" AutoPostBack="True">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right; ">
                        Cód. Cliente:</td>
                    <td style="text-align: left; ">
                        <asp:TextBox ID="TxtCodEmitente" runat="server" 
                            CssClass="CampoCadastro" 
                            Width="60px" AutoPostBack="True"></asp:TextBox>
                        </td>
                    <td style="text-align: right;">
                        <asp:Label ID="Label18" runat="server" Height="17px" Text="Assunto:"></asp:Label>
                    </td>
                    <td style="text-align: left;">
                        <asp:TextBox ID="TxtAssunto" runat="server" AutoPostBack="True" 
                            CssClass="CampoCadastro" Width="160px"></asp:TextBox>
                    </td>
                    <td style="text-align: right; ">
    &nbsp;</td>
                </tr>
                <tr>
                    <td style="text-align: right; ">
                        Nome Cliente:</td>
                    <td>
                        <asp:TextBox ID="TxtNomeEmitente" runat="server" AutoPostBack="True" 
                            CssClass="CampoCadastro" ToolTip="Informe o nome ou parte do nome do cliente." 
                            Width="175px"></asp:TextBox>
                    </td>
                    <td class="style1" style="text-align: right;">
                        <asp:Label ID="LblTecnico0" runat="server" Text="Observação:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TxtObservacao" runat="server" AutoPostBack="True" 
                            CssClass="CampoCadastro" MaxLength="10"
                            ToolTip="Informe a observação do chamado" Width="160px"></asp:TextBox>
                    </td>
                    <td style="text-align: right; vertical-align: bottom">
                        <asp:ImageButton ID="BtnNovoRegistro" runat="server" 
                            AlternateText="Novo Registro" BorderColor="#000099" BorderStyle="Outset" 
                            Height="18px" ImageAlign="Bottom" 
                            ImageUrl="~/Imagens/BtnNovoRegistro.png" />
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
                            GridLines="None" Width="100%" AllowSorting="True" PageSize="14">
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" 
                                VerticalAlign="Top" />
                            <Columns>
                                <asp:BoundField DataField="cod_programacao" HeaderText="Cód. Programação" 
                                    SortExpression="cod_programacao" >
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                </asp:BoundField>
                                <asp:BoundField DataField="cod_emitente" HeaderText="Cód. Cliente" 
                                    SortExpression="cod_emitente" >
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                </asp:BoundField>
                                <asp:BoundField DataField="cnpj" HeaderText="CNPJ" 
                                    SortExpression="cnpj">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nome" HeaderText="Nome Cliente" 
                                    SortExpression="nome">
                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                </asp:BoundField>
                                <asp:BoundField DataField="descricao" HeaderText="Contrato" 
                                    SortExpression="descricao" >
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                </asp:BoundField>
                                <asp:BoundField DataField="assunto" HeaderText="Assunto" 
                                    SortExpression="assunto">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                </asp:BoundField>
                                <asp:BoundField DataField="observacao" HeaderText="Observação" 
                                    SortExpression="observacao">
                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nome_usuario" HeaderText="Analista" 
                                    SortExpression="nome_usuario">
                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                </asp:BoundField>
                                <asp:BoundField DataField="descricao_tipo_agendamento" 
                                    HeaderText="Tipo Agendamento" SortExpression="descricao_tipo_agendamento">
                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                </asp:BoundField>
                                <asp:BoundField DataField="descricao_situacao" HeaderText="Situação" 
                                    SortExpression="descricao_situacao">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                </asp:BoundField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImageButton1" runat="server" 
                                            CommandArgument='<%# Eval("cod_programacao") %>' CommandName="ALTERAR" 
                                            ImageUrl="~/Imagens/BtnEditar.png" ToolTip="Alterar o registro" />
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
                    <td colspan="5">
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
                        
                        
                        
                        
                        
                        
                        
                        
                        
                        
                        
                            SelectCommand="select pa.cod_programacao, pa.cod_emitente, pa.cnpj, e.abreviado nome, pa.cod_analista, a.nome_usuario, pa.assunto, pa.observacao, pa.contrato, ct.descricao,
       case 
           when pa.tipo_agendamento &gt;= 1 and pa.tipo_agendamento &lt;= 31 then 'Dia ' || right('00' || pa.tipo_agendamento,2) || ' de cada mês'
           when pa.tipo_agendamento = 41 then 'Todo domingo'
           when pa.tipo_agendamento = 42 then 'Toda segunda-feira'
           when pa.tipo_agendamento = 43 then 'Toda terça-feira'
           when pa.tipo_agendamento = 44 then 'Toda quarta-feira'
           when pa.tipo_agendamento = 45 then 'Toda quinta-feira'
           when pa.tipo_agendamento = 46 then 'Toda sexta-feira'
           when pa.tipo_agendamento = 47 then 'Todo sábado'
           when pa.tipo_agendamento = 50 then 'Todos os dias'
           when pa.tipo_agendamento = 52 then 'Último dia de cada mês'
       end descricao_tipo_agendamento,
       case pa.situacao
          when 1 then 'Ativo'
          when 2 then 'Pausado'
          when 3 then 'Cancelado'
       end descricao_situacao
  from programacao_atendimento pa inner join v_emitente_endereco e on e.cod_emitente = pa.cod_emitente
                                                                  and e.cnpj         = pa.cnpj
                                  inner join sysusuario a on a.cod_usuario = pa.cod_analista 
                                  inner join tipo_chamado tc on tc.codigo = pa.cod_tipo_chamado
                                  left outer join contrato_manutencao ct on ct.empresa = pa.empresa
                                                                        and ct.contrato = pa.contrato
 where pa.empresa = :empresa
   and pa.cod_programacao  = f_isnull_or_empty(:cod_programacao, pa.cod_programacao)
   and pa.cod_emitente     = f_isnull_or_empty(:cod_emitente, pa.cod_emitente)
   and nome              like '%' || replace(:nome_emitente,' ','%') || '%'
   and pa.cod_tipo_chamado = f_isnull_or_empty(:tipo_chamado, pa.cod_tipo_chamado)
   and pa.assunto           like '%' || replace(:assunto,' ','%') || '%'
   and pa.observacao       like '%' || replace(:observacao,' ','%') || '%'
   and pa.cod_analista     = f_isnull_or_empty(:cod_analista, pa.cod_analista)
order by pa.cod_programacao">
                            <SelectParameters>
                                <asp:SessionParameter Name=":empresa" SessionField="GlEmpresa" 
                                    ConvertEmptyStringToNull="False" />
                                <asp:ControlParameter ControlID="TxtCodProgramacao" Name=":cod_programacao" 
                                    PropertyName="Text" ConvertEmptyStringToNull="False" Type="String" />
                                <asp:ControlParameter ControlID="TxtCodEmitente" Name=":cod_emitente" 
                                    PropertyName="Text" DefaultValue="" ConvertEmptyStringToNull="False" 
                                    Type="String" />
                                <asp:ControlParameter ControlID="TxtNomeEmitente" 
                                    ConvertEmptyStringToNull="False" Name=":nome_emitente" PropertyName="Text" 
                                    Type="String" />
                                <asp:ControlParameter ControlID="ddlTipoChamado" Name=":tipo_chamado" 
                                    PropertyName="SelectedValue" ConvertEmptyStringToNull="False" />
                                <asp:ControlParameter ControlID="TxtAssunto" Name=":assunto" 
                                    PropertyName="Text" ConvertEmptyStringToNull="False" Type="String" />
                                <asp:ControlParameter ControlID="TxtObservacao" 
                                    ConvertEmptyStringToNull="False" DbType="String" Name=":observacao" 
                                    PropertyName="Text" />
                                <asp:ControlParameter ControlID="ddlAnalista" Name=":cod_analista" 
                                    PropertyName="SelectedValue" ConvertEmptyStringToNull="False" />
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
