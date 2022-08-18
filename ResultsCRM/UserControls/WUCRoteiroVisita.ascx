<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="WUCRoteiroVisita.ascx.vb"
    Inherits="ResultsCRM.WUCRoteiroVisita" %>
<%@ Register Src="../OutrosControles/TextBoxInteiro.ascx" TagName="TextBoxInteiro"
    TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="../OutrosControles/TextBoxData.ascx" TagName="TextBoxData" TagPrefix="uc2" %>
<link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
<div>
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True">
    </asp:ScriptManager>
    </div>
<table class="TextoCadastro" style="width: 100%;">
    <tr>
        <td class="Erro" colspan="2">
            <asp:Label ID="LblErro" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Roteiro:
        </td>
        <td class="CelulaCampoCadastro">
            <asp:Label ID="LblCodRoteiro" runat="server" Font-Bold="True"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Vendedor/Representante:
        </td>
        <td class="CelulaCampoCadastro">
            <asp:DropDownList ID="DdlRepresentante" runat="server" CssClass="CampoCadastro" Width="300px"
                AutoPostBack="True">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Período:
        </td>
        <td class="CelulaCampoCadastro">
            <uc2:TextBoxData ID="TxtDataInicial" runat="server" Width="90" />
            <asp:Label runat="server" ID="LblA" Text=" a " Style="height: 20px"></asp:Label>
            <uc2:TextBoxData ID="TxtDataFinal" runat="server" Width="90" />
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Situação:</td>
        <td class="CelulaCampoCadastro">
            <span>
            <asp:DropDownList ID="DdlSituacao" runat="server" AutoPostBack="True" 
                            CssClass="CampoCadastro" Width="200px">
                            <asp:ListItem Selected="True" Value="1">Agendado</asp:ListItem>
                            <asp:ListItem Value="2">Concluído</asp:ListItem>
                            <asp:ListItem Value="3">Cancelado</asp:ListItem>
                        </asp:DropDownList>
                    </span>
        </td>
    </tr>
    <tr>
        <td colspan="2" style="text-align: right">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td colspan="2" style="text-align: center">
            <asp:Button ID="BtnGravar" runat="server" CssClass="Botao" Text="Gravar" />
        </td>
    </tr>
    <tr>
        <td colspan="2" style="text-align: center">
            &nbsp;</td>
    </tr>
    <tr>
        <td colspan="2" class="SubTituloMovimento" 
            style="border-top-style: solid; border-width: 1px; border-color: #CCCCCC">
            Visitas</td>
    </tr>
    <tr>
        <td colspan="2" style="text-align: left">
        <asp:Button ID="Button1" runat="server" Text="Incluir Visita" />
        <br />
        <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="False" CellPadding="4"
            DataSourceID="SqlDataSource5" ForeColor="#333333" GridLines="None" Width="100%"
            AllowSorting="True" PageSize="14" 
                EmptyDataText="&lt;br&gt;&lt;br&gt;Nenhuma visita incluída até o momento. Para incluir uma visita, clique no botão Incluir acima.">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" />
            <Columns>
                <asp:BoundField DataField="seq_visita" HeaderText="Seq. Visita" ReadOnly="True" SortExpression="seq_visita">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="data_visita" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Data"
                    SortExpression="data_visita">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="hora_visita" HeaderText="Hora" SortExpression="hora_visita">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Cliente" SortExpression="nome_cliente">
                    <ItemTemplate>
                        <asp:Label ID="Label23" runat="server" Text='<%# Eval("nome_cliente") %>'></asp:Label>
                        (<asp:Label ID="Label24" runat="server" Text='<%# Eval("cod_emitente") %>'></asp:Label>)
                        &nbsp;CNPJ/CPF:
                        <asp:Label ID="Label22" runat="server" Text='<%# Eval("cnpj") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:BoundField DataField="situacao_nome" HeaderText="Situação" SortExpression="situacao_nome">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="titulo" HeaderText="Assunto" SortExpression="titulo">
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:TemplateField SortExpression="nome_cliente">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton5" runat="server" CommandArgument='<%# Eval("seq_visita") %>'
                            CommandName="ALTERAR" ImageUrl="~/Imagens/BtnEditar.png" ToolTip="Clique para alterar ou consultar o registro" />
                        &nbsp;&nbsp;
                        <asp:ImageButton ID="ImageButton6" runat="server" 
                            CommandArgument='<%# Eval("seq_visita") %>' CommandName="EXCLUIR" 
                            ImageUrl="~/Imagens/BtnExcluir.png" 
                            onclientclick="return confirm('Deseja realmente excluir o registro?');" 
                            ToolTip="Excluir o registro" />
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
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
        </td> </tr>
        <tr>
            <td>
                <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                    
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="  select v.empresa,
          v.estabelecimento,
          v.seq_visita,
          v.cod_representante,
          r.nome nome_representante,
          if isnull(v.id_cliente_generico,'N') = 'S' then 0 else v.cod_emitente endif cod_emitente,
          if trim(isnull(v.cnpj,'')) = '' then '(não informado)' else v.cnpj endif cnpj,
          if isnull(v.id_cliente_generico,'N') = 'S' then v.cliente_generico else c.nome endif nome_cliente,
          v.data_visita,
          v.hora_visita,
          v.situacao,
          case v.situacao when 1 then 'Agendada' when 2 then 'Concluída' when 3 then 'Cancelada' end situacao_nome,
          v.titulo,
          v.narrativa
     from  visitacao v left outer join emitente c on c.cod_emitente = v.cod_emitente
                      inner join emitente r on r.cod_emitente = v.cod_representante
    where v.empresa         = :empresa
      and v.estabelecimento = :estabelecimento
      and v.cod_roteiro_visita = :roteiro
    order by data_visita, nome_cliente, seq_visita;">
                    <SelectParameters>
                        <asp:SessionParameter Name=":empresa" SessionField="GlEmpresa" ConvertEmptyStringToNull="False"
                            DbType="String" />
                        <asp:SessionParameter ConvertEmptyStringToNull="False" DbType="String" Name=":estabelecimento"
                            SessionField="GlEstabelecimento" />
                        <asp:SessionParameter ConvertEmptyStringToNull="False" DbType="String" Name=":roteiro"
                            SessionField="SCodRoteiroVisita" />
                    </SelectParameters>
                </asp:SqlDataSource>
        </td>
    </tr>
</table>
