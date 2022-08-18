Public Class WGAtendimentoCausa
    Inherits System.Web.UI.Page

    Private Const NAO_SELECIONADO As String = "0"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                Dim objChamadoProblema As New UCLChamadoProblema
                objChamadoProblema.FillDropDown(DdlProblema, Session("GlEmpresa"), Session("SCodAtendimento"))
                If DdlProblema.Items.Count = 0 Then
                    LblErro.Text = "Nenhum problema foi adicionado ao chamado até o momento."
                Else
                    Call CarregaCausas()
                End If
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Private Sub CarregaCausas()
        Try
            Dim objChamadoProblemaCausa As New UCLChamadoProblemaCausa
            If DdlProblema.Items.Count = 0 Then
                Return
            End If
            If DdlProblema.SelectedValue = "" Then
                Return
            End If
            objChamadoProblemaCausa.FillDropDown(DdlCausa, Session("GlEmpresa"), Session("SCodAtendimento"), DdlProblema.SelectedValue, False)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub BtnIncluir_Click(sender As Object, e As EventArgs) Handles BtnIncluir.Click
        Try
            Dim objChamadoProblemaCausa As New UCLChamadoProblemaCausa

            If DdlCausa.Items.Count = 0 OrElse DdlCausa.SelectedValue = NAO_SELECIONADO Then
                LblErro.Text = "Selecione uma causa."
                Return
            End If

            If Not objChamadoProblemaCausa.Buscar(Session("GlEmpresa"), Session("SCodAtendimento"), DdlProblema.SelectedValue, DdlCausa.SelectedValue) Then
                objChamadoProblemaCausa.SetConteudo("empresa", Session("GlEmpresa"))
                objChamadoProblemaCausa.SetConteudo("cod_chamado", Session("SCodAtendimento"))
                objChamadoProblemaCausa.SetConteudo("seq_problema", DdlProblema.SelectedValue)
                objChamadoProblemaCausa.SetConteudo("cod_causa", DdlCausa.SelectedValue)
                objChamadoProblemaCausa.Incluir()
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
        Try
            If e.CommandName = "EXCLUIR" Then
                Dim objChamadoProblemaCausa As New UCLChamadoProblemaCausa
                Dim args As String() = e.CommandArgument.ToString.Split(";")
                objChamadoProblemaCausa.Excluir(Session("GlEmpresa"), Session("SCodAtendimento"), args(0), args(1))
                GridView1.DataBind()
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Protected Sub DdlProblema_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DdlProblema.SelectedIndexChanged
        Try
            Call CarregaCausas()
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub
End Class