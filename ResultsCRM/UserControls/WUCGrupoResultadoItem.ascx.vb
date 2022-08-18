Public Class WUCGrupoResultadoItem
    Inherits System.Web.UI.UserControl

    Private Property Acao As String
        Get
            Return Session("SResultadoAcao")
        End Get
        Set(value As String)
            Session("SResultadoAcao") = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                If Acao = "INCLUIR" Then
                    Dim objResultado As New UCLResultadoItemAvaliado
                    LblSeqResultado.Text = objResultado.GetProximoCodigo(Session("GlEmpresa"), Session("SCodGrupoResultado"))
                ElseIf Acao = "ALTERAR" Then
                    LblSeqResultado.Text = Session("SSeqResultado")
                    Call CarregaFormulario()
                End If
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Private Sub CarregaFormulario()
        Try
            Dim objResultado As New UCLResultadoItemAvaliado
            objResultado.Buscar(Session("GlEmpresa"), Session("SCodGrupoResultado"), LblSeqResultado.Text)
            TxtDescricao.Text = objResultado.GetConteudo("descricao")
            TxtNota.Text = objResultado.GetConteudo("nota")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub BtnGravar_Click(sender As Object, e As EventArgs) Handles BtnGravar.Click
        Try
            Dim objResultado As New UCLResultadoItemAvaliado

            If String.IsNullOrEmpty(TxtDescricao.Text) Then
                LblErro.Text = "Preencha o campo Descrição."
                Return
            End If

            If String.IsNullOrEmpty(TxtNota.Text) Then
                LblErro.Text = "Preencha o campo Nota."
                Return
            ElseIf Not IsNumeric(TxtNota.Text) Then
                LblErro.Text = "Preencha corretamente o campo Nota."
                Return
            End If

            objResultado.SetConteudo("empresa", Session("GlEmpresa"))
            objResultado.SetConteudo("cod_grupo_resultado", Session("SCodGrupoResultado"))

            If Acao = "INCLUIR" Then
                objResultado.SetConteudo("seq_resultado", objResultado.GetProximoCodigo(Session("GlEmpresa"), Session("SCodGrupoResultado")))
            ElseIf Acao = "ALTERAR" Then
                objResultado.SetConteudo("seq_resultado", LblSeqResultado.Text)
                objResultado.Buscar(Session("GlEmpresa"), Session("SCodGrupoResultado"), LblSeqResultado.Text)
            End If

            objResultado.SetConteudo("descricao", TxtDescricao.Text.GetValidInputContent)
            objResultado.SetConteudo("nota", TxtNota.Text)

            If Acao = "INCLUIR" Then
                objResultado.Incluir()
            ElseIf Acao = "ALTERAR" Then
                objResultado.Alterar()
            End If

            Response.Redirect("WGGrupoResultadoItem.aspx")

        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Response.Redirect("WGGrupoResultadoItem.aspx")
    End Sub
End Class