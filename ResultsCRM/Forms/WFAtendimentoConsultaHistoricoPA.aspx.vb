Partial Public Class WFAtendimentoConsultaHistoricoPA
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim objEmitente As New UCLEmitente(StrConexaoUsuario(Session("GlUsuario")))
            Dim objPontoAtendimento As New UCLPontoAtendimento(StrConexaoUsuario(Session("GlUsuario")))

            objEmitente.CodEmitente = CodEmitente
            If Not String.IsNullOrEmpty(objEmitente.CodEmitente) Then
                If objEmitente.Buscar().Rows.Count > 0 Then
                    LblCodCliente.Text = objEmitente.CodEmitente
                    LblNomeCliente.Text = objEmitente.Nome
                End If
            End If
            
            objPontoAtendimento.CodEmitente = CodEmitente
            objPontoAtendimento.NumeroPontoAtendimento = NumeroPontoAtendimento
            If Not String.IsNullOrEmpty(objPontoAtendimento.CodEmitente) AndAlso Not String.IsNullOrEmpty(objPontoAtendimento.NumeroPontoAtendimento) Then
                If objPontoAtendimento.Buscar() Then
                    LblNumeroPontoAtendimento.Text = objPontoAtendimento.NumeroPontoAtendimento
                    LblNomePontoAtendimento.Text = objPontoAtendimento.Descricao
                End If
            Else
                Mensagem("Ponto de atendimento não foi informado para este chamado.")
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Private Sub Mensagem(ByVal texto As String)
        If Not String.IsNullOrEmpty(texto) Then
            Page.ClientScript.RegisterStartupScript(Me.GetType, "onLoad", "alert('" + texto + "');", True)
        Else
            Page.ClientScript.RegisterStartupScript(Me.GetType, "onLoad", "", True)
        End If
    End Sub

    Private ReadOnly Property CodAtendimento As String
        Get
            Return Session("SCodAtendimento")
        End Get
    End Property

    Private ReadOnly Property CodEmitente() As String
        Get
            Dim objChamado As New UCLAtendimento(StrConexao)
            objChamado.Empresa = Session("GlEmpresa")
            objChamado.Estabelecimento = Session("GlEstabelecimento")
            objChamado.CodChamado = CodAtendimento
            objChamado.Buscar()
            Return objChamado.CodEmitenteAtendimento
        End Get
    End Property

    Private ReadOnly Property NumeroPontoAtendimento() As String
        Get
            Dim objChamado As New UCLAtendimento(StrConexao)
            objChamado.Empresa = Session("GlEmpresa")
            objChamado.Estabelecimento = Session("GlEstabelecimento")
            objChamado.CodChamado = CodAtendimento
            objChamado.Buscar()
            Return objChamado.NumeroPontoAtendimento
        End Get
    End Property

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SqlDataSource1.Select(DataSourceSelectArguments.Empty)
        SqlDataSource1.DataBind()
        GridView1.DataBind()
    End Sub
End Class