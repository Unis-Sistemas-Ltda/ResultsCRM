Partial Public Class WUCFalta
    Inherits System.Web.UI.UserControl

    Private _Acao As String
    Private _CodFalta As String

    Public Property Acao() As String
        Get
            Return _Acao
        End Get
        Set(ByVal value As String)
            _Acao = value
        End Set
    End Property

    Public Property CodFalta() As String
        Get
            Return _CodFalta
        End Get
        Set(ByVal value As String)
            _CodFalta = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Call CarregaEstabelecimentos()
            Call CarregaTecnicos()
            If Acao = "ALTERAR" Then
                Call CarregaFormulario()
            ElseIf Acao = "INCLUIR" Then
                Call CarregaNovaPK()
            End If
        End If
    End Sub

    Private Sub CarregaFormulario()
        Try
            Dim objFaltaTecnico As New UCLFaltaTecnico
            objFaltaTecnico.Buscar(Session("GlEmpresa"), CodFalta)
            LblCodigo.Text = CodFalta
            DdlEstabelecimento.SelectedValue = objFaltaTecnico.GetConteudo("estabelecimento")
            DdlAgenteTecnico.SelectedValue = objFaltaTecnico.GetConteudo("cod_agente_tecnico")
            TxtDataFalta.Text = objFaltaTecnico.GetConteudo("data_falta").Substring(8, 2) + "/" + objFaltaTecnico.GetConteudo("data_falta").Substring(5, 2) + "/" + objFaltaTecnico.GetConteudo("data_falta").Substring(0, 4)
            TxtHoraInicio.Text = objFaltaTecnico.GetConteudo("hora_inicio")
            TxtHoraTermino.Text = objFaltaTecnico.GetConteudo("hora_termino")
            TxtMotivo.Text = objFaltaTecnico.GetConteudo("motivo")
            If objFaltaTecnico.GetConteudo("justificada") = "S" Then
                CbxFaltaJustificada.Checked = True
            Else
                CbxFaltaJustificada.Checked = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub BtnGravar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
        Dim objFaltaTecnico As New UCLFaltaTecnico
        Try
            If IsDigitacaoOk() Then
                If Acao = "ALTERAR" Then
                    objFaltaTecnico.SetConteudo("empresa", Session("GlEmpresa"))
                    objFaltaTecnico.SetConteudo("cod_falta", CodFalta)
                    objFaltaTecnico = CarregaObjeto(objFaltaTecnico)
                    objFaltaTecnico.Alterar()
                    Response.Redirect("WGFalta.aspx")
                ElseIf Acao = "INCLUIR" Then
                    Call CarregaNovaPK()
                    objFaltaTecnico.SetConteudo("empresa", Session("GlEmpresa"))
                    objFaltaTecnico.SetConteudo("cod_falta", LblCodigo.Text)
                    objFaltaTecnico = CarregaObjeto(objFaltaTecnico)
                    objFaltaTecnico.Incluir()
                    Response.Redirect("WGFalta.aspx")
                End If
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub
    Protected Function CarregaObjeto(ByVal objFaltaTecnico As UCLFaltaTecnico) As UCLFaltaTecnico
        objFaltaTecnico.SetConteudo("estabelecimento", DdlEstabelecimento.SelectedValue)
        objFaltaTecnico.SetConteudo("cod_agente_tecnico", DdlAgenteTecnico.SelectedValue)
        objFaltaTecnico.SetConteudo("data_falta", TxtDataFalta.Text)
        objFaltaTecnico.SetConteudo("hora_inicio", TxtHoraInicio.Text.GetValidInputContent)
        objFaltaTecnico.SetConteudo("hora_termino", TxtHoraTermino.Text.GetValidInputContent)
        objFaltaTecnico.SetConteudo("motivo", TxtMotivo.Text.GetValidInputContent)
        If CbxFaltaJustificada.Checked Then
            objFaltaTecnico.SetConteudo("justificada", "S")
        Else
            objFaltaTecnico.SetConteudo("justificada", "N")
        End If
        Return objFaltaTecnico
    End Function
    Private Sub CarregaNovaPK()
        Dim objFaltaTecnico As New UCLFaltaTecnico
        LblCodigo.Text = objFaltaTecnico.GetProximoCodigo(Session("GlEmpresa"))
    End Sub
    Protected Function IsDigitacaoOk() As Boolean
        LblErro.Text = ""
        If DdlEstabelecimento.SelectedValue = "0" Then
            LblErro.Text += "Selecione o estabelecimento.<br>"
        End If
        If DdlAgenteTecnico.SelectedValue = "0" Then
            LblErro.Text += "Selecione o agente técnico.<br>"
        End If
        If String.IsNullOrWhiteSpace(TxtDataFalta.Text) Then
            LblErro.Text += "Informe a data da falta.<br>"
        ElseIf Not isValidDate(TxtDataFalta.Text) Then
            LblErro.Text += "Informe corretamente a data da falta.<br>"
        End If
        If String.IsNullOrWhiteSpace(TxtHoraInicio.Text) Then
            LblErro.Text += "Informe a hora de início.<br>"
        ElseIf TxtHoraInicio.Text.Length < 5 OrElse Not TxtHoraInicio.Text.Contains(":") Then
            LblErro.Text += "Informe corretamente a hora de início.<br>"
        End If
        If String.IsNullOrWhiteSpace(TxtHoraTermino.Text) Then
            LblErro.Text += "Informe a hora de término.<br>"
        ElseIf TxtHoraTermino.Text.Length < 5 OrElse Not TxtHoraTermino.Text.Contains(":") Then
            LblErro.Text += "Informe corretamente a hora de término.<br>"
        End If
        Return LblErro.Text.Trim = ""
    End Function

    Protected Sub BtnVoltar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnVoltar.Click
        Try
            Response.Redirect("WGFalta.aspx")
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Private Sub CarregaEstabelecimentos()
        Try
            Dim objEstabelecimento As New UCLEstabelecimento
            objEstabelecimento.CodEmpresa = Session("GlEmpresa")
            objEstabelecimento.FillDropDown(DdlEstabelecimento, False, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaTecnicos()
        Try
            Dim objAgenteTecnico As New UCLAgenteTecnico
            objAgenteTecnico.FillDropDown(DdlAgenteTecnico, False, "", "0", False)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class