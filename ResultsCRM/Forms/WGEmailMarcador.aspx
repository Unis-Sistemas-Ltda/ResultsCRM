<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WGEmailMarcador.aspx.vb" Inherits="ResultsCRM.WGEmailMarcador" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="Erro"><asp:Label ID="LblErro" runat="server"></asp:Label></div>
    <div class="TextoCadastro_BGBranco" style="line-height: 21px;">
    
            <asp:Label ID="Label1" runat="server" Height="22px" 
                Text="Selecione o marcador:&nbsp;"></asp:Label>
    
            <asp:DropDownList ID="DdlMarcador" runat="server" CssClass="CampoCadastro" 
                Width="330px">
            </asp:DropDownList>
    
        &nbsp;<asp:Button ID="Button1" runat="server" Text="Vincular" />
        &nbsp;<asp:Button ID="Button2" runat="server" Text="Incluir" 
                
                onclientclick="ShowEditModal('../Forms/WFMarcador.aspx?a=I&amp;embeeded=True','EditModalPopupIncluirCliente','IframeEdit'); return false;" 
                ToolTip="Cadatrar um novo marcador" />
    <cc1:ModalPopupExtender ID="ModalPopupExtender1" BackgroundCssClass="ModalPopupBG"
        runat="server" CancelControlID="ButtonEditCancel" OkControlID="ButtonEditDone" 
        TargetControlID="Button2" PopupControlID="DivEditWindow" 
        OnCancelScript="EditCancelScript('IframeEdit');" OnOkScript="EditOkayScript('IframeEdit');"
        BehaviorID="EditModalPopupIncluirCliente">
    </cc1:ModalPopupExtender>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" CssClass="TextoCadastro_BGBranco" DataSourceID="SqlDataSource1" 
            EmptyDataText="Nenhum histórico a exibir." 
            Font-Bold="False" ForeColor="#333333" 
            GridLines="None" Width="100%">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="descri" HeaderText="Marcador" 
                    SortExpression="descri">
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="BtnExcluir" runat="server" 
                            CommandArgument='<%# Eval("cod_marcador") %>' CommandName="EXCLUIR" 
                            ImageUrl="~/Imagens/BtnExcluir.png" 
                            onclientclick="return confirm('Deseja desvincular do e-mail este marcador?');" 
                            ToolTip="Excluir" />
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:TemplateField>
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                HorizontalAlign="Left" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>"
            SelectCommand="select m.cod_marcador, f_nome_marcador_email(m.empresa, m.cod_marcador) descri
  from email_marcador em inner join marcador m on em.empresa = m.empresa and em.cod_marcador = m.cod_marcador
 where em.empresa = :empresa
   and em.seq_email = :seq_email
 order by descri">
            <SelectParameters>
                <asp:SessionParameter ConvertEmptyStringToNull="False" DbType="String" 
                    Name=":empresa" SessionField="GlEmpresa" />
                <asp:QueryStringParameter ConvertEmptyStringToNull="False" DbType="String" 
                    Name=":seq_email" QueryStringField="e" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
     <%--este é o html para pesquisa de emitentes--%><%--este é o html para incluir emitente via negociação--%><%--este é o html para alterar cadastro de emitente via negociação--%><%--este é o html para funcionar o botão de incluir contatos--%><%--este é o html para funcionar o botão de incluir contatos--%><%--botões padrão que ficam ocultos, são necessários, não remover--%>
    <div class="popup_Buttons" style="display: none">
        <input id="ButtonEditDone" value="Done" type="button" />
        <input id="ButtonEditCancel" value="Cancel" type="button" />
    </div>
    <%--frame onde é mostrado o popup--%>
    <div id="DivEditWindow" style="display: none;" class="popupConfirmation">
        <iframe id="IframeEdit" frameborder="0" width="420" height="435" scrolling="no">
        </iframe>
    </div>
    </form>
</body>
</html>