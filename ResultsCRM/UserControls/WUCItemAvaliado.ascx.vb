Public Class WUCItemAvaliado
    Inherits System.Web.UI.UserControl

    Private Property Acao As String
        Get
            Return Session("SItemAvaliadoAcao")
        End Get
        Set(value As String)
            Session("SItemAvaliadoAcao") = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                Call CarregaDropDowns()
                If Acao = "INCLUIR" Then
                    Dim objItemAvaliado As New UCLItemAvaliado
                    LblSeqItemAvaliado.Text = objItemAvaliado.GetProximoCodigo(Session("GlEmpresa"), Session("SCodTipoAvaliacao"))
                ElseIf Acao = "ALTERAR" Then
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
            Dim objItemAvaliado As New UCLItemAvaliado
            objItemAvaliado.Buscar(Session("GlEmpresa"), Session("SCodTipoAvaliacao"), LblSeqItemAvaliado.Text)
            TxtDescricao.Text = objItemAvaliado.GetConteudo("descricao")
            DdlGrupoItem.SelectedValue = objItemAvaliado.GetConteudo("cod_grupo_item")
            DdlGrupoResultado.SelectedValue = objItemAvaliado.GetConteudo("cod_grupo_resultado")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub BtnGravar_Click(sender As Object, e As EventArgs) Handles BtnGravar.Click
        Try
            Dim objItemAvaliado As New UCLItemAvaliado

            If String.IsNullOrEmpty(TxtDescricao.Text) Then
                LblErro.Text = "Preencha o campo Descrição."
                Return
            End If

            If DdlGrupoResultado.SelectedValue = "" OrElse DdlGrupoResultado.SelectedValue = "0" Then
                LblErro.Text = "Preencha o campo Grupo Resultado."
                Return
            End If

            If DdlGrupoItem.SelectedValue = "" OrElse DdlGrupoItem.SelectedValue = "0" Then
                LblErro.Text = "Preencha o campo Grupo Item."
                Return
            End If

            objItemAvaliado.SetConteudo("empresa", Session("GlEmpresa"))
            objItemAvaliado.SetConteudo("cod_tipo_avaliacao", Session("SCodTipoAvaliacao"))

            If Acao = "INCLUIR" Then
                objItemAvaliado.SetConteudo("seq_item_avaliado", objItemAvaliado.GetProximoCodigo(Session("GlEmpresa"), Session("SCodTipoAvaliacao")))
            ElseIf Acao = "ALTERAR" Then
                objItemAvaliado.SetConteudo("seq_item_avaliado", LblSeqItemAvaliado.Text)
                objItemAvaliado.Buscar(Session("GlEmpresa"), Session("SCodTipoAvaliacao"), LblSeqItemAvaliado.Text)
            End If

            objItemAvaliado.SetConteudo("descricao", TxtDescricao.Text.GetValidInputContent)
            objItemAvaliado.SetConteudo("cod_grupo_item", DdlGrupoItem.SelectedValue)
            objItemAvaliado.SetConteudo("cod_grupo_resultado", DdlGrupoResultado.SelectedValue)

            If Acao = "INCLUIR" Then
                objItemAvaliado.Incluir()
            ElseIf Acao = "ALTERAR" Then
                objItemAvaliado.Alterar()
            End If

            Response.Redirect("WGItemAvaliado.aspx")

        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Response.Redirect("WGItemAvaliado.aspx")
    End Sub

    Protected Sub CarregaDropDowns()
        Dim objGrupoItemAvaliado As New UCLGrupoItemAvaliado
        Dim objGrupoResultado As New UCLGrupoResultadoItemAvaliado

        objGrupoItemAvaliado.FillDropDown(DdlGrupoItem, Session("GlEmpresa"), True, "(selecione)", "0")
        objGrupoResultado.FillDropDown(DdlGrupoResultado, Session("GlEmpresa"), True, "(selecione)", "0")
    End Sub

End Class