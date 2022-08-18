Public Class WUCAvaliacaoItem
    Inherits System.Web.UI.UserControl

    Private Property Acao As String
        Get
            Return Session("SAcaoItemAvaliado")
        End Get
        Set(value As String)
            Session("SAcaoItemAvaliado") = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                If Acao = "ALTERAR" Then
                    LblSeqItemAvaliado.Text = Session("SSeqItemAvaliado")
                    Call CarregaFormulario()
                End If
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Private Sub CarregaFormulario()
        Try
            Call CarregaResultados()

            Dim objAvaliacaoItem As New UCLAvaliacaoClienteItem
            objAvaliacaoItem.Buscar(Session("GlEmpresa"), Session("SCodAvaliacao"), Session("SCodTipoAvaliacao"), LblSeqItemAvaliado.Text)

            DdlResultado.SelectedValue = objAvaliacaoItem.GetConteudo("seq_resultado")

            Dim objItemAvaliado As New UCLItemAvaliado
            objItemAvaliado.Buscar(Session("GlEmpresa"), Session("SCodTipoAvaliacao"), LblSeqItemAvaliado.Text)
            LblDescricaoItem.Text = objItemAvaliado.GetConteudo("descricao")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub BtnGravar_Click(sender As Object, e As EventArgs) Handles BtnGravar.Click
        Try
            Dim objAvaliacaoItem As New UCLAvaliacaoClienteItem

            If String.IsNullOrEmpty(DdlResultado.SelectedValue) OrElse DdlResultado.SelectedValue = "0" Then
                LblErro.Text = "Preencha o campo Resultado."
                Return
            End If

            Dim objItemAvaliado As New UCLItemAvaliado
            objItemAvaliado.Buscar(Session("GlEmpresa"), Session("SCodTipoAvaliacao"), LblSeqItemAvaliado.Text)

            objAvaliacaoItem.SetConteudo("empresa", Session("GlEmpresa"))
            objAvaliacaoItem.SetConteudo("cod_avaliacao", Session("SCodAvaliacao"))
            objAvaliacaoItem.SetConteudo("cod_tipo_avaliacao", Session("SCodTipoAvaliacao"))
            objAvaliacaoItem.SetConteudo("seq_item_avaliado", LblSeqItemAvaliado.Text)
            objAvaliacaoItem.SetConteudo("cod_grupo_resultado", objItemAvaliado.GetConteudo("cod_grupo_resultado"))
            objAvaliacaoItem.SetConteudo("seq_resultado", DdlResultado.SelectedValue)
            objAvaliacaoItem.Alterar()

            Response.Redirect("WGAvaliacaoItem.aspx")
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Response.Redirect("WGAvaliacaoItem.aspx")
    End Sub

    Protected Sub CarregaResultados()
        Dim objItemAvaliado As New UCLItemAvaliado
        Dim objResultadoItemAvaliado As New UCLResultadoItemAvaliado
        objItemAvaliado.Buscar(Session("GlEmpresa"), Session("SCodTipoAvaliacao"), LblSeqItemAvaliado.Text)
        objResultadoItemAvaliado.FillDropDown(Session("GlEmpresa"), objItemAvaliado.GetConteudo("cod_grupo_resultado"), DdlResultado, True, "(selecione)")
    End Sub

End Class