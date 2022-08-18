Imports Sybase.DataWindow
Imports Sybase.DataWindow.Web

Partial Public Class WFRelNegociacaoProduto
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not String.IsNullOrEmpty(Session("SCodItemPesquisado")) Then
            If Session("SAlterouCodItem") = "S" Then
                If TxtCodItem.Text <> Session("SCodItemPesquisado") Then
                    TxtCodItem.Text = Session("SCodItemPesquisado")
                End If
                Session("SAlterouCodItem") = "N"
            End If
        End If

        If Not IsPostBack Then
            Call CarregaAgentesVenda(0)
            Call CarregaCanalVenda()
        End If

        Call MostraDescricaoItem()
    End Sub

    Private Sub MostraDescricaoItem()
        Dim ObjItem As New UCLItem
        ObjItem.CodItem = TxtCodItem.Text
        ObjItem.Buscar()
        LblDescricaoItem.Text = ObjItem.Descricao
        LblDescricaoItem.DataBind()
    End Sub

    Private Sub CarregaAgentesVenda(ByVal codAgenteVenda As String)
        Dim objAgente As New UCLAgenteVendas
        If Session("GlAgenteVendaMaster") = "S" OrElse Session("GlRestricaoAcessoAgenteVenda") = 0 Then
            objAgente.FillDropDown(ddlAgenteVenda, True, "(Todos)", 0, UCLAgenteVendas.TipoRestricaoAcesso.SemRestricao)
        Else
            objAgente.FillDropDown(ddlAgenteVenda, True, "(Todos)", Session("GlCodUsuario"), UCLAgenteVendas.TipoRestricaoAcesso.SomenteOProprioAgenteDeVendasNoCRMeNoResults)
        End If
    End Sub

    Private Sub CarregaCanalVenda()
        Dim objCanalVenda As New UCLCanalVenda
        objCanalVenda.Empresa = Session("GlEmpresa")
        objCanalVenda.FillControl(DdlCanalVenda, True, "")
    End Sub

    Protected Sub BtnOk_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnOk.Click
        If String.IsNullOrEmpty(TxtData1.Text) Or String.IsNullOrEmpty(TxtData2.Text) Then
            lblErro.Text = "Preencha o período."
            Return
        End If

        Response.Redirect("WFRelNegociacaoProdutoRel.aspx?data1=" & TxtData1.Text & "&data2=" & TxtData2.Text & "&agente=" & ddlAgenteVenda.SelectedValue & "&canal=" & ddlCanalVenda.SelectedValue & "&item=" & TxtCodItem.Text)

    End Sub

End Class