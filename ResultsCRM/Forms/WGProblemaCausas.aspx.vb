Public Class WGProblemaCausas
    Inherits System.Web.UI.Page

    Private Const NAO_SELECIONADO As String = "0"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                Dim objCausa As New UCLCausa
                objCausa.FillDropDown(Session("GlEmpresa"), DdlCausa, True, "(selecione)", NAO_SELECIONADO)
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Protected Sub BtnIncluir_Click(sender As Object, e As EventArgs) Handles BtnIncluir.Click
        Try
            Dim objProblemaCausa As New UCLProblemaCausa

            If DdlCausa.Items.Count = 0 OrElse DdlCausa.SelectedValue = NAO_SELECIONADO Then
                LblErro.Text = "Selecione uma causa."
                Return
            End If

            If Not objProblemaCausa.Buscar(Session("GlEmpresa"), Session("SCodProblema"), DdlCausa.SelectedValue) Then
                objProblemaCausa.SetConteudo("empresa", Session("GlEmpresa"))
                objProblemaCausa.SetConteudo("cod_problema", Session("SCodProblema"))
                objProblemaCausa.SetConteudo("cod_causa", DdlCausa.SelectedValue)
                objProblemaCausa.Incluir()
                LblErro.Text = "Causa incluída com sucesso."
                GridView1.DataBind()
            Else
                LblErro.Text = "Causa selecionada já incluída."
            End If

        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Private Sub GridView1_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "EXCLUIR" Then
            Dim objProblemaCausa As New UCLProblemaCausa
            objProblemaCausa.Excluir(Session("GlEmpresa"), Session("SCodProblema"), e.CommandArgument)
            GridView1.DataBind()
        End If
    End Sub



End Class