Public Class WUCChamadoHoras
    Inherits System.Web.UI.UserControl

    Private _Acao As String
    Private _SeqHora As String

    Public Property CodChamado As String

    Public Property Acao() As String
        Get
            Return _Acao
        End Get
        Set(ByVal value As String)
            _Acao = value
        End Set
    End Property

    Public Property SeqHora() As String
        Get
            Return _SeqHora
        End Get
        Set(ByVal value As String)
            _SeqHora = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Call CarregaAnalista()
            If Acao = "ALTERAR" Then
                Call CarregaFormulario()
            ElseIf Acao = "INCLUIR" Then
                Call CarregaNovaPK()
            End If
        End If
    End Sub

    Private Sub CarregaFormulario()
        Dim ObjChamadoHora As New UCLChamadoHoraTrabalhada
        Dim aux As Date
        LblSeq.Text = SeqHora

        ObjChamadoHora.Buscar(Session("GlEmpresa"), CodChamado, SeqHora)

        DdlAnalista.SelectedValue = ObjChamadoHora.GetConteudo("cod_analista")
        aux = ObjChamadoHora.GetConteudoData("data_inicial")
        If aux = Nothing Then
            TxtDataInicio.Text = ""
            TxtHoraInicial.Text = ""
        Else
            TxtDataInicio.Text = ObjChamadoHora.GetConteudoData("data_inicial").ToString("dd/MM/yyyy")
            TxtHoraInicial.Text = ObjChamadoHora.GetConteudoData("data_inicial").ToString("HH:mm:ss")
        End If
        aux = ObjChamadoHora.GetConteudoData("data_final")
        If aux = Nothing Then
            TxtDataTermino.Text = ""
            TxtHoraFinal.Text = ""
        Else
            TxtDataTermino.Text = ObjChamadoHora.GetConteudoData("data_final").ToString("dd/MM/yyyy")
            TxtHoraFinal.Text = ObjChamadoHora.GetConteudoData("data_final").ToString("HH:mm:ss")
        End If
        TxtQtdHoras.Text = ObjChamadoHora.GetConteudo("total_horas")
        TxtDescricao.Text = ObjChamadoHora.GetConteudo("descricao")
    End Sub

    Private Sub CarregaNovaPK()
        Dim ObjChamadoHora As New UCLChamadoHoraTrabalhada
        LblSeq.Text = ObjChamadoHora.GetProximoCodigo(Session("GlEmpresa"), CodChamado)
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
        Dim ObjChamadoHora As New UCLChamadoHoraTrabalhada
        Try
            Call CarregaQtdHoras()
            If IsDigitacaoOk() Then
                If Acao = "ALTERAR" Then
                    ObjChamadoHora.SetConteudo("empresa", Session("GlEmpresa"))
                    ObjChamadoHora.SetConteudo("cod_chamado", CodChamado)
                    ObjChamadoHora.SetConteudo("seq_hora", LblSeq.Text)
                    ObjChamadoHora = CarregaObjeto(ObjChamadoHora)
                    ObjChamadoHora.Alterar()
                    Response.Redirect("WGAtendimentoHoras.aspx?")
                ElseIf Acao = "INCLUIR" Then
                    Call CarregaNovaPK()
                    ObjChamadoHora.SetConteudo("empresa", Session("GlEmpresa"))
                    ObjChamadoHora.SetConteudo("cod_chamado", CodChamado)
                    ObjChamadoHora.SetConteudo("seq_hora", LblSeq.Text)
                    ObjChamadoHora = CarregaObjeto(ObjChamadoHora)
                    ObjChamadoHora.Incluir()
                    Response.Redirect("WGAtendimentoHoras.aspx?")
                End If
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Protected Function IsDigitacaoOk() As Boolean
        LblErro.Text = ""

        If DdlAnalista.SelectedValue = "0" Then
            LblErro.Text += "Preencha o campo Analista.<br/>"
        End If

        If TxtDataInicio.Text = "" Then
            LblErro.Text += "Preencha o campo Data Inicial.<br/>"
        ElseIf Not isValidDate(TxtDataInicio.Text) Then
            LblErro.Text += "Preencha corretamente o campo Data Inicial.<br/>"
        End If

        If TxtHoraInicial.Text = "" Then
            LblErro.Text += "Preencha o campo Hora Inicial.<br/>"
        End If

        If TxtDataTermino.Text = "" Then
            LblErro.Text += "Preencha o campo Data Final.<br/>"
        ElseIf Not isValidDate(TxtDataTermino.Text) Then
            LblErro.Text += "Preencha corretamente o campo Data Final.<br/>"
        End If

        If TxtHoraFinal.Text = "" Then
            LblErro.Text += "Preencha o campo Hora Final.<br/>"
        End If

        Return LblErro.Text.Trim = ""
    End Function

    Protected Function CarregaObjeto(ByRef ObjChamadoHoraTrabalhada As UCLChamadoHoraTrabalhada) As UCLChamadoHoraTrabalhada
        Try
            Dim dataInicio As DateTime = New DateTime(TxtDataInicio.Text.Substring(6, 4), TxtDataInicio.Text.Substring(3, 2), TxtDataInicio.Text.Substring(0, 2), TxtHoraInicial.Text.Substring(0, 2), TxtHoraInicial.Text.Substring(3, 2), TxtHoraInicial.Text.Substring(6, 2))
            Dim dataTermino As DateTime = New DateTime(TxtDataTermino.Text.Substring(6, 4), TxtDataTermino.Text.Substring(3, 2), TxtDataTermino.Text.Substring(0, 2), TxtHoraFinal.Text.Substring(0, 2), TxtHoraFinal.Text.Substring(3, 2), TxtHoraFinal.Text.Substring(6, 2))
            ObjChamadoHoraTrabalhada.SetConteudo("cod_analista", DdlAnalista.SelectedValue)
            ObjChamadoHoraTrabalhada.SetConteudoData("data_inicial", dataInicio)
            ObjChamadoHoraTrabalhada.SetConteudoData("data_final", dataTermino)
            ObjChamadoHoraTrabalhada.SetConteudo("total_horas", TxtQtdHoras.Text)
            ObjChamadoHoraTrabalhada.SetConteudo("descricao", TxtDescricao.Text.GetValidInputContent)
            Return ObjChamadoHoraTrabalhada
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub CarregaAnalista()
        Try
            Dim objAnalista As New UCLAnalista
            objAnalista.FillDropDown(DdlAnalista, True, "(selecione)", "0", True, False, "", "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaQtdHoras()
        Try
            If isValidDate(TxtDataInicio.Text) AndAlso Not String.IsNullOrWhiteSpace(TxtHoraInicial.Text) AndAlso isValidDate(TxtDataTermino.Text) AndAlso Not String.IsNullOrWhiteSpace(TxtHoraFinal.Text) Then
                Dim dataInicio As DateTime = New DateTime(TxtDataInicio.Text.Substring(6, 4), TxtDataInicio.Text.Substring(3, 2), TxtDataInicio.Text.Substring(0, 2), TxtHoraInicial.Text.Substring(0, 2), TxtHoraInicial.Text.Substring(3, 2), TxtHoraInicial.Text.Substring(6, 2))
                Dim dataTermino As DateTime = New DateTime(TxtDataTermino.Text.Substring(6, 4), TxtDataTermino.Text.Substring(3, 2), TxtDataTermino.Text.Substring(0, 2), TxtHoraFinal.Text.Substring(0, 2), TxtHoraFinal.Text.Substring(3, 2), TxtHoraFinal.Text.Substring(6, 2))
                Dim diferenca As Double = DateDiff(DateInterval.Second, dataInicio, dataTermino) / 3600.0
                TxtQtdHoras.Text = diferenca.ToString("F4")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub BtnVoltar_Click(sender As Object, e As EventArgs) Handles BtnVoltar.Click
        Response.Redirect("WGAtendimentoHoras.aspx?")
    End Sub
End Class