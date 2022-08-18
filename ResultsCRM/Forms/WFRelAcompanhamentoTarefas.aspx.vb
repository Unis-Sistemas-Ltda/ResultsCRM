Partial Public Class WFRelAcompanhamentoTarefas
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim alterouCodCliente As Long
        Dim CodClientePesquisado As String
        If Not String.IsNullOrEmpty(Session("SAlterouCodCliente")) Then
            alterouCodCliente = Session("SAlterouCodCliente")
        Else
            alterouCodCliente = 0
        End If

        CodClientePesquisado = Session("SCodClientePesquisado")

        If Not String.IsNullOrEmpty(CodClientePesquisado) Then
            If alterouCodCliente > 0 Then
                If TxtCodEmitente.Text <> CodClientePesquisado Then
                    TxtCodEmitente.Text = CodClientePesquisado
                    Call CarregaNomeCliente()
                End If
                Session("SAlterouCodCliente") = alterouCodCliente - 1
            End If
        End If
        If Not IsPostBack Then

            Call CarregaAgentesVenda(0)
        End If
    End Sub

    Private Sub CarregaAgentesVenda(ByVal codAgenteVenda As String)
        Dim objAgente As New UCLAgenteVendas
        If Session("GlAgenteVendaMaster") = "S" OrElse Session("GlRestricaoAcessoAgenteVenda") = 0 Then
            objAgente.FillDropDown(ddlAgente, True, "(Todos)", 0, UCLAgenteVendas.TipoRestricaoAcesso.SemRestricao)
        Else
            objAgente.FillDropDown(ddlAgente, True, "(Todos)", Session("GlCodUsuario"), UCLAgenteVendas.TipoRestricaoAcesso.SomenteOProprioAgenteDeVendasNoCRMeNoResults)
        End If
    End Sub

    Protected Sub BtnOk_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnOk.Click
        Response.Redirect("WFRelAcompanhamentoTarefasRel.aspx?emp=1&resp=" + ddlAgente.SelectedValue + "&cli=" + TxtCodEmitente.Text + "&sts=" + RblTipo.SelectedValue)
    End Sub

    Protected Sub TxtCodEmitente_TextChanged(sender As Object, e As EventArgs) Handles TxtCodEmitente.TextChanged
        Try
            Call CarregaNomeCliente()
        Catch ex As Exception
            lblErro.Text = ex.Message
        End Try
    End Sub

    Private Sub CarregaNomeCliente()
        Try
            Dim objEmitente As New UCLEmitente(StrConexao)
            If Not String.IsNullOrWhiteSpace(TxtCodEmitente.Text) AndAlso IsNumeric(TxtCodEmitente.Text) Then
                objEmitente.CodEmitente = TxtCodEmitente.Text
                objEmitente.Buscar()
                LblNomeCliente.Text = objEmitente.Nome
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class