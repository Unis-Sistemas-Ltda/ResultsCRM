Partial Public Class WFRelEspectativaNegocio
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Call CarregaAgentesVenda(0)
            Call CarregaCanalVenda()
            Call CarregaStatus()
        End If
    End Sub

    Private Sub CarregaCanalVenda()
        Dim objCanalVenda As New UCLCanalVenda
        objCanalVenda.Empresa = Session("GlEmpresa")
        objCanalVenda.FillControl(ddlCanal, True, "")
    End Sub

    Private Sub CarregaAgentesVenda(ByVal codAgenteVenda As String)
        Dim objAgente As New UCLAgenteVendas
        If Session("GlAgenteVendaMaster") = "S" OrElse Session("GlRestricaoAcessoAgenteVenda") = 0 Then
            objAgente.FillDropDown(ddlAgente, True, "(Todos)", 0, UCLAgenteVendas.TipoRestricaoAcesso.SemRestricao)
        Else
            objAgente.FillDropDown(ddlAgente, True, "(Todos)", Session("GlCodUsuario"), UCLAgenteVendas.TipoRestricaoAcesso.SomenteOProprioAgenteDeVendasNoCRMeNoResults)
        End If
    End Sub

    Private Sub CarregaStatus()
        Dim objStatus As New UCLStatusNegociacao
        objStatus.FillDropDown(ddlSituacao, True, "")
    End Sub

    Protected Sub BtnOk_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnOk.Click
        If String.IsNullOrEmpty(TxtData1.Text) Or String.IsNullOrEmpty(TxtData2.Text) Then
            lblErro.Text = "Preencha o período."
            Return
        End If
        Response.Redirect("WFRelExpectativaNegocioRel.aspx?modelo=" & rblModelo.SelectedValue & "&data1=" & TxtData1.Text & "&data2=" & TxtData2.Text & "&agente=" & ddlAgente.SelectedValue & "&canal=" & ddlCanal.SelectedValue & "&situacao=" & ddlSituacao.SelectedValue & "&cidade=" & TxtCidade.Text)
    End Sub

End Class