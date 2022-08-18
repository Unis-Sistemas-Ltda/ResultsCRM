<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGAtendimentoProblema.aspx.vb" Inherits="ResultsCRM.WGAtendimentoProblema" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../ResultsCRM.css" rel="stylesheet" type="text/css" />
    <link href="../ResultsCRMAjax.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="../ResultsCRM.js"></script>
</head>
<body>
    <form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div>
        <asp:Label ID="LblErro" runat="server" CssClass="Erro"></asp:Label>
        <br />
        <div class="Titulo2" 
            style="font-weight: bold; text-align: left; font-size: 9pt;">Problemas / Modos 
            de Falha</div>
    
        <asp:Label ID="Label3" runat="server" Height="17px" Text="Equipamento:&nbsp;" style="text-align:right"
            Width="190px"></asp:Label>
    
            <asp:DropDownList ID="DdlEquipamento" runat="server" CssClass="CampoCadastro" 
                Width="300px" AutoPostBack="True">
            </asp:DropDownList>
        &nbsp;<span><asp:ImageButton ID="BtnIncluirEquipamento" runat="server" 
                AlternateText="Novo Equipamento" Height="16px" ToolTip="Incluir Equipamento" 
                ImageUrl="~/Imagens/BtnIncluir.png" 
                
                
                
                onclientclick="ShowEditModal('../Forms/WFEquipamento.aspx?aid=I','EditModalPopupClientes','IframeEdit');" />
     <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender3" BackgroundCssClass="ModalPopupBG"
        runat="server" CancelControlID="ButtonEditCancel" OkControlID="ButtonEditDone" 
        TargetControlID="BtnIncluirEquipamento" PopupControlID="DivEditWindow" 
        OnCancelScript="EditCancelScript('IframeEdit');" OnOkScript="EditOkayScript('IframeEdit');"
        BehaviorID="EditModalPopupIncluirContato">
    </ajaxToolkit:ModalPopupExtender>
            &nbsp;<asp:ImageButton ID="BtnAlterarEquipamento" runat="server" 
                AlternateText="Alterar equipamento" Height="16px" 
                ToolTip="Alterar informações do Equipamento" 
                ImageUrl="~/Imagens/BtnEditar.png" 
                
                
                
                onclientclick="ShowEditModal('../Forms/WFEquipamento.aspx?aid=A','EditModalPopupClientes','IframeEdit');" />
     <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender4" BackgroundCssClass="ModalPopupBG"
        runat="server" CancelControlID="ButtonEditCancel" OkControlID="ButtonEditDone" 
        TargetControlID="BtnAlterarEquipamento" PopupControlID="DivEditWindow" 
        OnCancelScript="EditCancelScript('IframeEdit');" OnOkScript="EditOkayScript('IframeEdit');"
        BehaviorID="EditModalPopupAlterarContato">
    </ajaxToolkit:ModalPopupExtender>
            &nbsp;</span><br />
    
        <asp:Label ID="Label2" runat="server" Height="17px" 
            Text="Grupo de Problema / Categoria:&nbsp;" style="text-align:right"
            Width="190px"></asp:Label>
    
        <asp:DropDownList ID="DdlGrupo" runat="server" CssClass="CampoCadastro" 
            Width="300px" AutoPostBack="True">
        </asp:DropDownList>
        <br />
    
        <asp:Label ID="Label1" runat="server" Height="17px" 
            Text="Problema / Modo de Falha:&nbsp;" style="text-align:right"
            Width="190px"></asp:Label>
    
        <asp:DropDownList ID="DdlProblema" runat="server" CssClass="CampoCadastro" 
            Width="300px">
        </asp:DropDownList>
&nbsp;<asp:Button ID="BtnIncluir" runat="server" Text="Incluir Problema/Modo de Falha" 
            Width="200px" />
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="2" DataSourceID="SqlDataSource1" 
            EmptyDataText="&lt;br&gt;Nenhum problema foi incluído até o momento." 
            ForeColor="#333333" GridLines="None" Width="100%">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:TemplateField HeaderText="Equipamento" SortExpression="numero_serie">
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("descricao_item") %>'></asp:Label>
                        &nbsp;<asp:Label ID="Label5" runat="server" Text='<%# Eval("observacao") %>'></asp:Label>
                        (<asp:Label ID="Label1" runat="server" Text='<%# Bind("numero_serie") %>'></asp:Label>
                        )
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("numero_serie") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:BoundField DataField="descricao" HeaderText="Grupo / Categoria" 
                    SortExpression="descricao">
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Problema / Modo de Falha" 
                    SortExpression="assunto">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("assunto") %>'></asp:Label>
                        (<asp:Label ID="Label28" runat="server" Text='<%# Eval("cod_problema") %>'></asp:Label>
                        )<br />
                        <asp:Label ID="Label29" runat="server" Text='<%# Eval("pergunta") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("assunto") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" 
                            CommandArgument='<%# Eval("cod_problema") %>' CommandName="EXCLUIR" 
                            ImageUrl="~/Imagens/BtnExcluir.png" 
                            onclientclick="return confirm('Deseja excluir o registro?')" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Right" />
                </asp:TemplateField>
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
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select e.cod_problema, e.assunto, gp.descricao, eq.numero_serie, eq.observacao, i.descricao descricao_item, e.pergunta
from problema_padrao e  inner join grupo_problema gp   on gp.empresa = e.empresa 
                                                      and gp.cod_grupo = e.cod_grupo
                        inner join chamado_problema ce on e.empresa = ce.empresa 
                                                      and e.cod_problema = ce.cod_problema
                        left outer join equipamento eq      on eq.empresa      = ce.empresa
                                                      and eq.numero_serie = ce.numero_serie
                        left outer join item i         on i.cod_item = eq.cod_item
where ce.empresa     = :empresa
  and ce.cod_chamado = :cod_chamado">
            <SelectParameters>
                <asp:SessionParameter ConvertEmptyStringToNull="False" DbType="String" 
                    Name=":empresa" SessionField="GlEmpresa" />
                <asp:SessionParameter ConvertEmptyStringToNull="False" DbType="String" 
                    Name=":cod_chamado" SessionField="SCodAtendimento" />
            </SelectParameters>
        </asp:SqlDataSource>
    
        <br />
        <div class="Titulo2" 
            style="font-weight: bold; text-align: left; font-size: 9pt;">Causas Prováveis</div>
    
        <asp:Label ID="Label6" runat="server" Height="17px" 
            Text="Problema / Modo de Falha:&nbsp;" style="text-align:right"
            Width="190px"></asp:Label>
    
        <asp:DropDownList ID="DdlProblemaCausa" runat="server" CssClass="CampoCadastro" 
            Width="300px" AutoPostBack="True">
        </asp:DropDownList>
&nbsp;<br />
    
        <asp:Label ID="Label7" runat="server" Height="17px" Text="Causa:&nbsp;" style="text-align:right"
            Width="190px"></asp:Label>
    
        <asp:DropDownList ID="DdlCausa" runat="server" CssClass="CampoCadastro" 
            Width="300px">
        </asp:DropDownList>
&nbsp;<asp:Button ID="BtnIncluirCausa" runat="server" Text="Incluir Causa" 
            Width="200px" />
        <br />
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
            CellPadding="2" DataSourceID="SqlDataSource2" 
            EmptyDataText="&lt;br&gt;Nenhuma causa foi incluída até o momento." 
            ForeColor="#333333" GridLines="None" Width="100%">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:TemplateField HeaderText="Equipamento" SortExpression="numero_serie">
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("descricao_item") %>'></asp:Label>
                        &nbsp;<asp:Label ID="Label5" runat="server" Text='<%# Eval("observacao") %>'></asp:Label>
                        (<asp:Label ID="Label1" runat="server" Text='<%# Bind("numero_serie") %>'></asp:Label>
                        )
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("numero_serie") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Problema / Modo de Falha" 
                    SortExpression="assunto">
                    <ItemTemplate>
                        <asp:Label ID="Label8" runat="server" Text='<%# Bind("assunto") %>'></asp:Label>
                        (<asp:Label ID="Label9" runat="server" Text='<%# Eval("cod_problema") %>'></asp:Label>
                        )
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("assunto") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Causa Provável" SortExpression="descricao">
                    <ItemTemplate>
                        <asp:Label ID="Label10" runat="server" Text='<%# Bind("descricao") %>'></asp:Label>
                        (<asp:Label ID="Label11" runat="server" Text='<%# Eval("cod_causa") %>'></asp:Label>
                        )
                        <br />
                        <asp:Label ID="Label30" runat="server" Text='<%# Eval("descricao_completa") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("descricao") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton2" runat="server" 
                            CommandArgument='<%# Eval("seq_problema") & ";" & Eval("cod_causa") %>' CommandName="EXCLUIR" 
                            ImageUrl="~/Imagens/BtnExcluir.png" 
                            onclientclick="return confirm('Deseja excluir o registro?')" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Right" />
                </asp:TemplateField>
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
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select cp.seq_problema, e.cod_problema, e.assunto, ca.cod_causa, ca.descricao, eq.numero_serie, eq.observacao, i.descricao descricao_item, ca.descricao_completa
  from chamado_problema_causa cc inner join causa ca on ca.empresa = cc.empresa and ca.cod_causa = cc.cod_causa
                                 inner join chamado_problema cp on cc.empresa = cp.empresa and cc.cod_chamado = cp.cod_chamado and cc.seq_problema = cp.seq_problema
                                 inner join problema_padrao e on e.empresa = cp.empresa and e.cod_problema = cp.cod_problema
                        left outer join equipamento eq      on eq.empresa      = cp.empresa
                                                      and eq.numero_serie = cp.numero_serie
                        left outer join item i         on i.cod_item = eq.cod_item
 where cc.empresa     = :empresa
   and cc.cod_chamado = :cod_chamado
 order by e.assunto, e.cod_problema, ca.descricao, ca.cod_causa">
            <SelectParameters>
                <asp:SessionParameter ConvertEmptyStringToNull="False" DbType="String" 
                    Name=":empresa" SessionField="GlEmpresa" />
                <asp:SessionParameter ConvertEmptyStringToNull="False" DbType="String" 
                    Name=":cod_chamado" SessionField="SCodAtendimento" />
            </SelectParameters>
        </asp:SqlDataSource>
    
        <div class="Titulo2" 
            style="font-weight: bold; text-align: left; font-size: 9pt;">
            <br />
            Efeitos</div>
    
        <asp:Label ID="Label12" runat="server" Height="17px" 
            Text="Problema / Modo de Falha:&nbsp;" style="text-align:right"
            Width="190px"></asp:Label>
    
        <asp:DropDownList ID="DdlProblemaEfeito" runat="server" CssClass="CampoCadastro" 
            Width="300px" AutoPostBack="True">
        </asp:DropDownList>
&nbsp;<br />
    
        <asp:Label ID="Label13" runat="server" Height="17px" 
            Text="Causa Provável:&nbsp;" style="text-align:right"
            Width="190px"></asp:Label>
    
        <asp:DropDownList ID="DdlCausaEfeito" runat="server" CssClass="CampoCadastro" 
            Width="300px" AutoPostBack="True">
        </asp:DropDownList>
&nbsp;<br />
    
        <asp:Label ID="Label14" runat="server" Height="17px" Text="Efeito:&nbsp;" style="text-align:right"
            Width="190px"></asp:Label>
    
        <asp:DropDownList ID="DdlEfeito" runat="server" CssClass="CampoCadastro" 
            Width="300px">
        </asp:DropDownList>
&nbsp;<asp:Button ID="BtnIncluirEfeito" runat="server" Text="Incluir Efeito" 
            Width="200px" />
        <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" 
            CellPadding="2" DataSourceID="SqlDataSource3" 
            EmptyDataText="&lt;br&gt;Nenhum efeito foi incluído até o momento." 
            ForeColor="#333333" GridLines="None" Width="100%">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:TemplateField HeaderText="Equipamento" SortExpression="numero_serie">
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("descricao_item") %>'></asp:Label>
                        &nbsp;<asp:Label ID="Label5" runat="server" Text='<%# Eval("observacao") %>'></asp:Label>
                        (<asp:Label ID="Label1" runat="server" Text='<%# Bind("numero_serie") %>'></asp:Label>
                        )
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("numero_serie") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Problema / Modo de Falha" 
                    SortExpression="assunto">
                    <ItemTemplate>
                        <asp:Label ID="Label15" runat="server" Text='<%# Bind("assunto") %>'></asp:Label>
                        (<asp:Label ID="Label16" runat="server" Text='<%# Eval("cod_problema") %>'></asp:Label>
                        )
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("assunto") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Causa Provável" SortExpression="descricao">
                    <ItemTemplate>
                        <asp:Label ID="Label17" runat="server" Text='<%# Bind("descricao") %>'></asp:Label>
                        (<asp:Label ID="Label18" runat="server" Text='<%# Eval("cod_causa") %>'></asp:Label>
                        )
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("descricao") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Efeito" SortExpression="descricao1">
                    <ItemTemplate>
                        <asp:Label ID="Label19" runat="server" Text='<%# Bind("descricao1") %>'></asp:Label>
                        (<asp:Label ID="Label20" runat="server" Text='<%# Eval("cod_efeito") %>'></asp:Label>
                        )
                        <br />
                        <asp:Label ID="Label31" runat="server" Text='<%# Eval("descricao_completa") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("descricao1") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton3" runat="server" 
                            
                            CommandArgument='<%# Eval("seq_problema") & ";" & Eval("cod_causa") & ";" & Eval("cod_efeito") %>' CommandName="EXCLUIR" 
                            ImageUrl="~/Imagens/BtnExcluir.png" 
                            onclientclick="return confirm('Deseja excluir o registro?')" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Right" />
                </asp:TemplateField>
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
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
            
            
            
            
            SelectCommand="select cp.seq_problema, e.cod_problema, e.assunto, ca.cod_causa, ca.descricao, ce.cod_efeito, ce.descricao, eq.numero_serie, eq.observacao, i.descricao descricao_item, ce.descricao_completa
  from chamado_problema_causa_efeito cc inner join causa ca on ca.empresa = cc.empresa and ca.cod_causa = cc.cod_causa
                                        inner join chamado_problema cp on cc.empresa = cp.empresa and cc.cod_chamado = cp.cod_chamado and cc.seq_problema = cp.seq_problema
                                        inner join problema_padrao e on e.empresa = cp.empresa and e.cod_problema = cp.cod_problema
                                        inner join efeito ce on ce.empresa = cc.empresa and ce.cod_efeito = cc.cod_efeito
                        left outer join equipamento eq      on eq.empresa      = cp.empresa
                                                      and eq.numero_serie = cp.numero_serie
                        left outer join item i         on i.cod_item = eq.cod_item
 where cc.empresa     = :empresa
   and cc.cod_chamado = :cod_chamado
 order by e.assunto, e.cod_problema, ca.descricao, ca.cod_causa, ce.cod_efeito, ce.descricao">
            <SelectParameters>
                <asp:SessionParameter ConvertEmptyStringToNull="False" DbType="String" 
                    Name=":empresa" SessionField="GlEmpresa" />
                <asp:SessionParameter ConvertEmptyStringToNull="False" DbType="String" 
                    Name=":cod_chamado" SessionField="SCodAtendimento" />
            </SelectParameters>
        </asp:SqlDataSource>
    
        <br />
        <div class="Titulo2" 
            style="font-weight: bold; text-align: left; font-size: 9pt">
            Ações 
            / Barreiras Implementadas</div>
        <br />
        <asp:Button ID="BtnIncluirAcao" runat="server" Text="Incluir Ação/Barreira Implementada" 
            Width="225px" />
        <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" 
            CellPadding="2" DataSourceID="SqlDataSource4" 
            EmptyDataText="&lt;br&gt;Nenhuma ação foi incluída até o momento." 
            ForeColor="#333333" GridLines="None" Width="100%">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:TemplateField HeaderText="Problema / Modo de Falha" 
                    SortExpression="assunto">
                    <ItemTemplate>
                        <asp:Label ID="Label21" runat="server" Text='<%# Bind("assunto") %>'></asp:Label>
                        (<asp:Label ID="Label22" runat="server" Text='<%# Eval("cod_problema") %>'></asp:Label>
                        )
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("assunto") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Causa Provável" SortExpression="descricao_causa">
                    <ItemTemplate>
                        <asp:Label ID="Label23" runat="server" Text='<%# Eval("descricao_causa") %>'></asp:Label>
                        (<asp:Label ID="Label24" runat="server" Text='<%# Eval("cod_causa") %>'></asp:Label>
                        )
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("descricao") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Efeito" SortExpression="descricao_efeito">
                    <ItemTemplate>
                        <asp:Label ID="Label25" runat="server" Text='<%# Eval("descricao_efeito") %>'></asp:Label>
                        (<asp:Label ID="Label26" runat="server" Text='<%# Eval("cod_efeito") %>'></asp:Label>
                        )
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("descricao1") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Ação / Barreira Implementada" 
                    SortExpression="descricao_acao">
                    <ItemTemplate>
                        <asp:Label ID="Label27" runat="server" Text='<%# Bind("descricao_acao") %>'></asp:Label>
                        (<asp:Label ID="Label33" runat="server" Text='<%# Eval("cod_acao") %>'></asp:Label>
                        )<br />
                        <asp:Label ID="Label32" runat="server" Text='<%# Eval("descricao_completa") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox10" runat="server" Text='<%# Bind("descricao_acao") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:BoundField DataField="descricao_situacao" HeaderText="Situação" 
                    SortExpression="descricao_situacao">
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="responsavel" HeaderText="Responsável" 
                    SortExpression="responsavel">
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="data_prevista" DataFormatString="{0:dd/MM/yyyy}" 
                    HeaderText="Previsão" SortExpression="data_prevista">
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="data_execucao" DataFormatString="{0:dd/MM/yyyy}" 
                    HeaderText="Execução" SortExpression="data_execucao">
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton4" runat="server" CommandName="ALTERAR"
                            CommandArgument='<%# Eval("seq_acao") %>' ImageUrl="~/Imagens/BtnEditar.png" 
                            style="margin-top: 0px" ToolTip="Editar dados do registro" />
                        &nbsp;<asp:ImageButton ID="ImageButton5" runat="server" 
                            CommandArgument='<%# Eval("seq_acao") %>' CommandName="EXCLUIR" 
                            ImageUrl="~/Imagens/BtnExcluir.png" 
                            onclientclick="return confirm('Deseja excluir o registro?')" 
                            ToolTip="Excluir o registro" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Right" Width="45px" />
                </asp:TemplateField>
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
        <asp:SqlDataSource ID="SqlDataSource4" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
            
            
            
            
            SelectCommand="select cc.seq_acao, cc.cod_acao, cp.seq_problema, e.cod_problema, e.assunto, ca.cod_causa, ca.descricao descricao_causa, ce.cod_efeito, ce.descricao descricao_efeito, a.cod_acao, a.descricao descricao_acao,
       (case cc.situacao when 1 then 'Não iniciada' when 2 then 'Iniciada' when 3 then 'Concluída' when 4 then 'Pausada' when 5 then 'Cancelada' end) descricao_situacao,
       cc.responsavel,
       cc.data_prevista,
       cc.data_execucao,
       a.descricao_completa
  from chamado_acao cc inner join causa ca on ca.empresa = cc.empresa and ca.cod_causa = cc.cod_causa
                       inner join chamado_problema cp on cc.empresa = cp.empresa and cc.cod_chamado = cp.cod_chamado and cc.seq_problema = cp.seq_problema
                       inner join problema_padrao e on e.empresa = cp.empresa and e.cod_problema = cp.cod_problema
                       inner join efeito ce on ce.empresa = cc.empresa and ce.cod_efeito = cc.cod_efeito
                       inner join acao a on a.empresa = cc.empresa and a.cod_acao = cc.cod_acao
 where cc.empresa     = :empresa
   and cc.cod_chamado = :cod_chamado
 order by e.assunto, e.cod_problema, ca.descricao, ca.cod_causa, ce.cod_efeito, ce.descricao, a.descricao, a.cod_acao">
            <SelectParameters>
                <asp:SessionParameter ConvertEmptyStringToNull="False" DbType="String" 
                    Name=":empresa" SessionField="GlEmpresa" />
                <asp:SessionParameter ConvertEmptyStringToNull="False" DbType="String" 
                    Name=":cod_chamado" SessionField="SCodAtendimento" />
            </SelectParameters>
        </asp:SqlDataSource>
    
        <br />
    
    </div>
    <%--este é o html para pesquisa de itens--%><%--botões padrão que ficam ocultos, são necessários, não remover--%>
    <div class="popup_Buttons" style="display: none">
        <input id="ButtonEditDone" value="Done" type="button" />
        <input id="ButtonEditCancel" value="Cancel" type="button" />
    </div>
    <%--frame onde é mostrado o popup--%>
    <div id="DivEditWindow" style="display: none;" class="popupConfirmation">
        <iframe id="IframeEdit" frameborder="0" width="370" height="350" scrolling="no">
        </iframe>
    </div>
    </form>
</body>
</html>