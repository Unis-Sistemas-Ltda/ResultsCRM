Public Class WGAtendimentoEfeito
    Inherits System.Web.UI.Page

    Private Const NAO_SELECIONADO As String = "0"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                Dim objChamadoProblema As New UCLChamadoProblema
                objChamadoProblema.FillDropDown(DdlProblemaEfeito, Session("GlEmpresa"), Session("SCodAtendimento"))
                If DdlProblemaEfeito.Items.Count = 0 Then
                    LblErro.Text = "Nenhum problema foi adicionado ao chamado até o momento."
                Else
                    Call CarregaCausasEfeito()
                End If
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Private Sub CarregaCausasEfeito()
        Try
            Dim objChamadoProblemaCausa As New UCLChamadoProblemaCausa
            If DdlProblemaEfeito.Items.Count = 0 Then
                Return
            End If
            If DdlProblemaEfeito.SelectedValue = "" Then
                Return
            End If
            objChamadoProblemaCausa.FillDropDown(DdlCausa, Session("GlEmpresa"), Session("SCodAtendimento"), DdlProblemaEfeito.SelectedValue, True)
            If DdlCausa.Items.Count = 0 Then
                LblErro.Text = "Nenhuma causa foi vinculada ao problema selecionado neste chamado chamado até o momento."
                Return
            Else
                Call CarregaEfeitos()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaEfeitos()
        Try
            Dim objChamadoProblemaCausa As New UCLChamadoProblemaCausa
            Dim objChamadoProblemaCausaEfeito As New UCLChamadoProblemaCausaEfeito
            If DdlProblemaEfeito.Items.Count = 0 Then
                Return
            End If
            If DdlProblemaEfeito.SelectedValue = "" Then
                Return
            End If
            If DdlCausa.Items.Count = 0 Then
                LblErro.Text = "Nenhuma causa foi vinculada ao problema selecionado neste chamado chamado até o momento."
                DdlEfeito.Items.Clear()
                Return
            Else
                objChamadoProblemaCausaEfeito.FillDropDown(DdlEfeito, Session("GlEmpresa"), Session("SCodAtendimento"), DdlProblemaEfeito.SelectedValue, DdlCausa.SelectedValue)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub BtnIncluir_Click(sender As Object, e As EventArgs) Handles BtnIncluir.Click
        Try
            Dim objChamadoProblemaCausaEfeito As New UCLChamadoProblemaCausaEfeito

            If DdlProblemaEfeito.Items.Count = 0 OrElse DdlProblemaEfeito.SelectedValue = NAO_SELECIONADO Then
                LblErro.Text = "Selecione um problema."
                Return
            End If

            If DdlCausa.Items.Count = 0 OrElse DdlCausa.SelectedValue = NAO_SELECIONADO Then
                LblErro.Text = "Selecione uma causa."
                Return
            End If

            If DdlEfeito.Items.Count = 0 OrElse DdlEfeito.SelectedValue = NAO_SELECIONADO Then
                LblErro.Text = "Selecione um efeito."
                Return
            End If

            If Not objChamadoProblemaCausaEfeito.Buscar(Session("GlEmpresa"), Session("SCodAtendimento"), DdlProblemaEfeito.SelectedValue, DdlCausa.SelectedValue, DdlEfeito.SelectedValue) Then
                objChamadoProblemaCausaEfeito.SetConteudo("empresa", Session("GlEmpresa"))
                objChamadoProblemaCausaEfeito.SetConteudo("cod_chamado", Session("SCodAtendimento"))
                objChamadoProblemaCausaEfeito.SetConteudo("seq_problema", DdlProblemaEfeito.SelectedValue)
                objChamadoProblemaCausaEfeito.SetConteudo("cod_causa", DdlCausa.SelectedValue)
                objChamadoProblemaCausaEfeito.SetConteudo("cod_efeito", DdlEfeito.SelectedValue)
                objChamadoProblemaCausaEfeito.Incluir()
                LblErro.Text = "Efeito incluído com sucesso."
                GridView1.DataBind()
            Else
                LblErro.Text = "Efeito selecionado já incluído."
            End If

        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Private Sub GridView1_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        Try
            If e.CommandName = "EXCLUIR" Then
                Dim objChamadoProblemaCausaEfeito As New UCLChamadoProblemaCausaEfeito
                Dim args As String() = e.CommandArgument.ToString.Split(";")
                objChamadoProblemaCausaEfeito.Excluir(Session("GlEmpresa"), Session("SCodAtendimento"), args(0), args(1), args(2))
                GridView1.DataBind()
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Protected Sub DdlProblema_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DdlProblemaEfeito.SelectedIndexChanged
        Try
            Call CarregaCausasEfeito()
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Protected Sub DdlCausa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DdlCausa.SelectedIndexChanged
        Try
            Call CarregaEfeitos()
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub
End Class