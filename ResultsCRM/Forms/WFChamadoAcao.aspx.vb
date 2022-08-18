Public Class WFChamadoAcao
    Inherits System.Web.UI.Page

    Private Const NAO_SELECIONADO As String = "0"

    Private Property Acao As String
        Get
            Return Session("SAcaoChamadoAcao")
        End Get
        Set(value As String)
            Session("SAcaoChamadoAcao") = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                If Acao = "INCLUIR" Then
                    Dim objChamadoAcao As New UCLChamadoAcao
                    Dim objChamadoProblema As New UCLChamadoProblema

                    LblSeqAcao.Text = objChamadoAcao.GetProximoCodigo(Session("GlEmpresa"), Session("SCodAtendimento"))

                    objChamadoProblema.FillDropDown(DdlProblema, Session("GlEmpresa"), Session("SCodAtendimento"))
                    If DdlProblema.Items.Count = 0 Then
                        LblErro.Text = "Nenhum problema foi adicionado ao chamado até o momento."
                    Else
                        Call CarregaCausas()
                    End If
                ElseIf Acao = "ALTERAR" Then
                    LblSeqAcao.Text = Session("SChamadoSeqAcao")
                    Call CarregaFormulario()
                End If
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

    Protected Sub DdlCausa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DdlCausa.SelectedIndexChanged
        Try
            Call CarregaEfeitos()
            Call CarregaAcoes()
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Private Sub CarregaFormulario()
        Try
            Dim objChamadoAcao As New UCLChamadoAcao
            Dim objChamadoProblema As New UCLChamadoProblema
            Dim dataPrevista As String
            Dim dataExecucao As String

            objChamadoProblema.FillDropDown(DdlProblema, Session("GlEmpresa"), Session("SCodAtendimento"))
            Call CarregaCausas()

            objChamadoAcao.Buscar(Session("GlEmpresa"), Session("SCodAtendimento"), LblSeqAcao.Text)
            DdlProblema.SelectedValue = objChamadoAcao.GetConteudo("seq_problema")
            DdlCausa.SelectedValue = objChamadoAcao.GetConteudo("cod_causa")
            DdlEfeito.SelectedValue = objChamadoAcao.GetConteudo("cod_efeito")
            DdlAcao.SelectedValue = objChamadoAcao.GetConteudo("cod_acao")
            TxtResponsavel.Text = objChamadoAcao.GetConteudo("responsavel")

            dataPrevista = objChamadoAcao.GetConteudo("data_prevista")
            dataExecucao = objChamadoAcao.GetConteudo("data_execucao")

            If dataPrevista <> "" Then
                dataPrevista = dataPrevista.Substring(8, 2) + "/" + dataPrevista.Substring(5, 2) + "/" + dataPrevista.Substring(0, 4)
            End If

            If dataExecucao <> "" Then
                dataExecucao = dataExecucao.Substring(8, 2) + "/" + dataExecucao.Substring(5, 2) + "/" + dataExecucao.Substring(0, 4)
            End If

            TxtDataPrevista.Text = dataPrevista
            TxtDataExecucao.Text = dataExecucao

            DdlSituacao.SelectedValue = objChamadoAcao.GetConteudo("situacao")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub BtnGravar_Click(sender As Object, e As EventArgs) Handles BtnGravar.Click
        Try
            Dim objChamadoAcao As New UCLChamadoAcao

            If DdlProblema.Items.Count = 0 OrElse DdlProblema.SelectedValue = NAO_SELECIONADO Then
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

            If DdlAcao.Items.Count = 0 OrElse DdlAcao.SelectedValue = NAO_SELECIONADO Then
                LblErro.Text = "Selecione uma ação."
                Return
            End If

            If Not String.IsNullOrEmpty(TxtDataPrevista.Text) AndAlso Not IsDate(TxtDataPrevista.Text) Then
                LblErro.Text = "Preencha corretamente o campo data prevista."
                Return
            End If

            If Not String.IsNullOrEmpty(TxtDataExecucao.Text) AndAlso Not IsDate(TxtDataExecucao.Text) Then
                LblErro.Text = "Preencha corretamente o campo data execução."
                Return
            End If

            objChamadoAcao.SetConteudo("empresa", Session("GlEmpresa"))
            objChamadoAcao.SetConteudo("cod_chamado", Session("SCodAtendimento"))

            If Acao = "INCLUIR" Then
                objChamadoAcao.SetConteudo("seq_acao", objChamadoAcao.GetProximoCodigo(Session("GlEmpresa"), Session("SCodAtendimento")))
            ElseIf Acao = "ALTERAR" Then
                objChamadoAcao.SetConteudo("seq_acao", LblSeqAcao.Text)
                objChamadoAcao.Buscar(Session("GlEmpresa"), Session("SCodAtendimento"), LblSeqAcao.Text)
            End If

            objChamadoAcao.SetConteudo("seq_problema", DdlProblema.SelectedValue)
            objChamadoAcao.SetConteudo("cod_causa", DdlCausa.SelectedValue)
            objChamadoAcao.SetConteudo("cod_efeito", DdlEfeito.SelectedValue)
            objChamadoAcao.SetConteudo("cod_acao", DdlAcao.SelectedValue)
            objChamadoAcao.SetConteudo("responsavel", TxtResponsavel.Text.GetValidInputContent)
            objChamadoAcao.SetConteudo("situacao", DdlSituacao.SelectedValue)
            objChamadoAcao.SetConteudo("data_prevista", TxtDataPrevista.Text)
            objChamadoAcao.SetConteudo("data_execucao", TxtDataExecucao.Text)

            If Acao = "INCLUIR" Then
                objChamadoAcao.Incluir()
            ElseIf Acao = "ALTERAR" Then
                objChamadoAcao.Alterar()
            End If

            Response.Redirect("WGAtendimentoProblema.aspx")

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
            If DdlCausa.Items.Count = 0 Then
                LblErro.Text = "Nenhuma causa foi vinculada ao problema selecionado neste chamado chamado até o momento."
                Return
            Else
                Call CarregaEfeitos()
                Call CarregaAcoes()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaEfeitos()
        Try
            Dim objChamadoProblemaCausa As New UCLChamadoProblemaCausa
            Dim objChamadoProblemaCausaEfeito As New UCLChamadoProblemaCausaEfeito
            If DdlProblema.Items.Count = 0 Then
                Return
            End If
            If DdlProblema.SelectedValue = "" Then
                Return
            End If
            If DdlCausa.Items.Count = 0 Then
                LblErro.Text = "Nenhuma causa foi vinculada ao problema selecionado neste chamado chamado até o momento."
                DdlEfeito.Items.Clear()
                Return
            Else
                objChamadoProblemaCausaEfeito.FillDropDown(DdlEfeito, Session("GlEmpresa"), Session("SCodAtendimento"), DdlProblema.SelectedValue, DdlCausa.SelectedValue)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaAcoes()
        Try
            Dim objCausaAcao As New UClCausaAcao
            Dim objChamadoProblemaCausa As New UCLChamadoProblemaCausa
            Dim objChamadoProblemaCausaEfeito As New UCLChamadoProblemaCausaEfeito
            If DdlProblema.Items.Count = 0 Then
                Return
            End If
            If DdlProblema.SelectedValue = "" Then
                Return
            End If
            If DdlCausa.Items.Count = 0 Then
                LblErro.Text = "Nenhuma causa foi vinculada ao problema selecionado neste chamado chamado até o momento."
                DdlCausa.Items.Clear()
                Return
            Else
                objCausaAcao.FillDropDown(Session("GlEmpresa"), DdlCausa.SelectedValue, DdlAcao, True, "(selecione)", NAO_SELECIONADO)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Response.Redirect("WGAtendimentoProblema.aspx")
    End Sub
End Class