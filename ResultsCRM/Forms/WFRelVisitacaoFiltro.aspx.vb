Partial Public Class WFRelVisitacaoFiltro
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            TxtDataI.Attributes.Add("OnKeyPress", "formatacampo(this,'##/##/####');")
            TxtDataF.Attributes.Add("OnKeyPress", "formatacampo(this,'##/##/####');")

            If Not IsPostBack Then
                Call CarregaRepresentante()
            End If

        Catch ex As Exception
            LblErro.Text = ex.ToString
        End Try
    End Sub

    Private Sub CarregaRepresentante()
        Dim ObjEmitente As New UCLEmitente(StrConexao)
        ObjEmitente.FillDropDown(ddlRepresentante, True, "(Todos)", UCLEmitente.TipoEmitenteDDL.Representante, 0, False, UCLEmitente.TipoExibicaoDDL.Nome, Session("GlCodGestor"))

        If Session("GlTipoAcesso") = UCLUsuario.TipoAcesso.Representante Then
            ddlRepresentante.SelectedValue = Session("GlCodEmitenteExterno")
            ddlRepresentante.Enabled = False
        End If
    End Sub

    Protected Sub BtnOk_Click(sender As Object, e As EventArgs) Handles BtnOk.Click
        If String.IsNullOrEmpty(TxtDataI.Text) Or String.IsNullOrEmpty(TxtDataF.Text) Then
            LblErro.Text = "Preencha o período."
            Return
        End If

        If RblModelo.SelectedValue = "1" Then
            Response.Redirect("WFRelVisitacaoRel.aspx?" & _
                              "emid=" & Session("GlEmpresa").ToString & _
                              "&esid=" & Session("GlEstabelecimento").ToString & _
                              "&svid=" & ValidaCampo("TxtSeqVisita", TxtSeqVisita.Text) & _
                              "&clid=" & ValidaCampo("TxtCodEmitente", TxtCodEmitente.Text) & _
                              "&ncid=" & ValidaCampo("TxtNomeEmitente", TxtNomeEmitente.Text) & _
                              "&diid=" & ValidaCampo("TxtDataI", TxtDataI.Text) & _
                              "&dfid=" & ValidaCampo("TxtDataF", TxtDataF.Text) & _
                              "&siid=" & ValidaCampo("DdlSituacao", DdlSituacao.SelectedValue) & _
                              "&reid=" & ValidaCampo("ddlRepresentante", ddlRepresentante.SelectedValue))
        ElseIf RblModelo.SelectedValue = "2" Then
            Response.Redirect("WFRelVisitacaoRel2.aspx?" & _
                              "emid=" & Session("GlEmpresa").ToString & _
                              "&esid=" & Session("GlEstabelecimento").ToString & _
                              "&svid=" & ValidaCampo("TxtSeqVisita", TxtSeqVisita.Text) & _
                              "&clid=" & ValidaCampo("TxtCodEmitente", TxtCodEmitente.Text) & _
                              "&ncid=" & ValidaCampo("TxtNomeEmitente", TxtNomeEmitente.Text) & _
                              "&diid=" & ValidaCampo("TxtDataI", TxtDataI.Text) & _
                              "&dfid=" & ValidaCampo("TxtDataF", TxtDataF.Text) & _
                              "&siid=" & ValidaCampo("DdlSituacao", DdlSituacao.SelectedValue) & _
                              "&reid=" & ValidaCampo("ddlRepresentante", ddlRepresentante.SelectedValue))
        End If
        
        
    End Sub

    Private Function ValidaCampo(ByVal nomeCampo As String, conteudo As String) As String
        Try
            Select Case nomeCampo
                Case "TxtDataI"
                    If String.IsNullOrWhiteSpace(conteudo) Then
                        Return "01/01/1900"
                    End If
                Case "TxtDataF"
                    If String.IsNullOrWhiteSpace(conteudo) Then
                        Return "31/12/2999"
                    End If
                Case "DdlSituacao"
                    If conteudo = "-1" Then
                        Return ""
                    End If
                Case "ddlRepresentante"
                    If conteudo = "0" Then
                        Return ""
                    End If
            End Select
            Return conteudo
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class