Public Class WFListagemChamadosFiltro
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                TxtDataAbertura1.Text = New Date(Year(Now), Month(Now), 1).ToString("dd/MM/yyyy")
                TxtDataAbertura2.Text = New Date(Year(Now), Month(Now), Date.DaysInMonth(Year(Now), Month(Now))).ToString("dd/MM/yyyy")
                Call CarregaTipoChamado()
                Call CarregaTipoCobrancaOS()
            End If
            Call ChecaAlteracaoCliente()
        Catch ex As Exception
            lblErro.Text = ex.Message
        End Try
    End Sub

    Protected Sub BtnOk_Click(sender As Object, e As EventArgs) Handles BtnOk.Click
        If DdlModelo.SelectedValue = "1" Then
            Response.Redirect("WFRelListagemChamadosResumido.aspx?da1=" & TxtDataAbertura1.Text & "&da2=" & TxtDataAbertura2.Text + "&de1=" + TxtDataEncerramento1.Text + "&de2=" + TxtDataEncerramento2.Text + "&tch=" + DdlTipoChamado.SelectedValue + "&tco=" + DdlTipoCobranca.SelectedValue + "&cl=" + TxtCliente.Text + "&eq=" + DdlEquipamento.SelectedValue)
        ElseIf DdlModelo.SelectedValue = "2" Then
            Response.Redirect("WFRelListagemChamadosDetalhado.aspx?da1=" & TxtDataAbertura1.Text & "&da2=" & TxtDataAbertura2.Text + "&de1=" + TxtDataEncerramento1.Text + "&de2=" + TxtDataEncerramento2.Text + "&tch=" + DdlTipoChamado.SelectedValue + "&tco=" + DdlTipoCobranca.SelectedValue + "&cl=" + TxtCliente.Text + "&eq=" + DdlEquipamento.SelectedValue)
        End If
    End Sub

    Private Sub CarregaTipoChamado()
        Try
            Dim objTipoChamado As New UCLTipoChamado
            objTipoChamado.FillDropDown(Session("GlEmpresa"), DdlTipoChamado, True, "(selecione)", "0")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub CarregaTipoCobrancaOS()
        Try
            Dim ObjTipoCobrancaOS As New UCLTipoCobrancaOS
            ObjTipoCobrancaOS.FillDropDown(DdlTipoCobranca, True, "(selecione)", "0")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub ChecaAlteracaoCliente()
        Try
            Dim alterouCodCliente As Integer = 0
            Dim codClientePesquisado As String = "0"

            If Not String.IsNullOrEmpty(Session("SAlterouCodCliente")) Then
                alterouCodCliente = Session("SAlterouCodCliente")
            Else
                alterouCodCliente = 0
            End If

            codClientePesquisado = Session("SCodClientePesquisado")

            If Not String.IsNullOrEmpty(codClientePesquisado) Then
                If alterouCodCliente > 0 Then
                    If TxtCliente.Text <> codClientePesquisado Then
                        TxtCliente.Text = codClientePesquisado
                        Call CodigoClienteMudou()
                        Call CarregaEquipamentoCliente()
                    End If
                    Session("SAlterouCodCliente") = alterouCodCliente - 1
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub CodigoClienteMudou()
        Try
            Dim objEmitente As New UCLEmitente(StrConexaoUsuario(Session("GlUsuario")))

            If Not String.IsNullOrWhiteSpace(TxtCliente.Text) Then
                objEmitente.CodEmitente = TxtCliente.Text
                objEmitente.Buscar()
                LblNomeCliente.Text = objEmitente.Nome
            Else
                LblNomeCliente.Text = ""
            End If

            Session("SCodEmitenteNegociacao") = TxtCliente.Text
            Session("SCodClientePesquisado") = TxtCliente.Text

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub TxtCliente_TextChanged(sender As Object, e As EventArgs) Handles TxtCliente.TextChanged
        Try
            Call CodigoClienteMudou()
            Call CarregaEquipamentoCliente()
        Catch ex As Exception
            lblErro.Text = ex.Message
        End Try
    End Sub

    Private Sub CarregaEquipamentoCliente()
        Try
            Dim objEquipamentoCliente As New UCLEquipamentoCliente(StrConexaoUsuario(Session("GlUsuario")))
            objEquipamentoCliente.Empresa = Session("GlEmpresa")

            objEquipamentoCliente.CodCliente = IIf(TxtCliente.Text.Trim = "", "0", TxtCliente.Text.Trim)
            objEquipamentoCliente.NumeroPontoAtendimento = ""
            Session("SPAEquipamento") = ""
            Session("SCliEquipamento") = IIf(TxtCliente.Text.Trim = "", "0", TxtCliente.Text.Trim)

            If Session("GlTipoFaturamento").ToString = "G" Then
                objEquipamentoCliente.FillDropDown(DdlEquipamento, True, "", "", UCLEquipamentoCliente.TipoDescricaoEquipamento.DescricaoItem, "-1")
            Else
                objEquipamentoCliente.FillDropDown(DdlEquipamento, True, "", "", UCLEquipamentoCliente.TipoDescricaoEquipamento.Observacao, "-1")
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class