Partial Public Class WUCClienteCSLAEstado
    Inherits System.Web.UI.UserControl
    Private _Acao As String
    Private _CodSLA As String
    Private _CodCliente As String
    Private _CodPais As String
    Private _CodEstado As String
    Public Property Acao() As String
        Get
            Return _Acao
        End Get
        Set(ByVal value As String)
            _Acao = value
        End Set
    End Property
    Public Property CodSLA() As String
        Get
            Return _CodSLA
        End Get
        Set(ByVal value As String)
            _CodSLA = value
        End Set
    End Property
    Public Property CodCliente As String
        Get
            Return _CodCliente
        End Get
        Set(ByVal value As String)
            _CodCliente = value
        End Set
    End Property
    Public Property CodPais As String
        Get
            Return _CodPais
        End Get
        Set(ByVal value As String)
            _CodPais = value
        End Set
    End Property
    Public Property CodEstado As String
        Get
            Return _CodEstado
        End Get
        Set(ByVal value As String)
            _CodEstado = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Acao = "EDITAR" Then
                Call CarregaFormulario()
            ElseIf Acao = "INCLUIR" Then
                Call CarregaEstado()
                Try
                    Dim objSLAEmitente As New UCLSLAEmitente
                    objSLAEmitente.CodEmitente = CodCliente
                    objSLAEmitente.CodSLA = CodSLA
                    objSLAEmitente.Buscar()
                    TxtPrazoChegada.Text = objSLAEmitente.PrazoChegada
                    TxtPrazoEncerramento.Text = objSLAEmitente.PrazoEncerramento
                Catch ex As Exception
                    Throw ex
                End Try
            End If
            Dim objSLA As New UCLSLA
            objSLA.CodSLA = CodSLA
            objSLA.Buscar()
            LblDescricaoSLA.Text = objSLA.Descricao
            LblCodSLA.Text = objSLA.CodSLA
        End If
    End Sub

    Private Sub CarregaFormulario()
        Try
            Call CarregaEstado()
            Dim objSLAEstado As New UCLSLAEmitenteEstado
            objSLAEstado.CodSLA = CodSLA
            objSLAEstado.CodEmitente = CodCliente
            objSLAEstado.CodPais = CodPais
            objSLAEstado.CodEstado = CodEstado
            If objSLAEstado.Buscar() Then
                TxtPrazoEncerramento.Text = objSLAEstado.PrazoEncerramento
                TxtPrazoChegada.Text = objSLAEstado.PrazoChegada
                DdlEstado.SelectedValue = CodEstado
            End If
            DdlEstado.Enabled = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub BtnGravar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
        Try
            Dim objSlaEmitenteEstado As New UCLSLAEmitenteEstado
            If IsDigitacaoOk() Then
                If Acao = "EDITAR" Then
                    objSlaEmitenteEstado.CodSLA = CodSLA
                    objSlaEmitenteEstado.CodEmitente = CodCliente
                    objSlaEmitenteEstado.CodPais = CodPais
                    objSlaEmitenteEstado.CodEstado = CodEstado
                    objSlaEmitenteEstado = CarregaObjeto(objSlaEmitenteEstado)
                    objSlaEmitenteEstado.Alterar()
                    LblErro.Text = "Registro alterado com sucesso."
                    'Response.Redirect("WGClienteSLAEstadoCidade.aspx")
                ElseIf Acao = "INCLUIR" Then
                    objSlaEmitenteEstado.CodSLA = CodSLA
                    objSlaEmitenteEstado.CodEmitente = CodCliente
                    objSlaEmitenteEstado.CodPais = CodPais
                    objSlaEmitenteEstado.CodEstado = DdlEstado.SelectedValue
                    If objSlaEmitenteEstado.Buscar() Then
                        LblErro.Text = "Erro: Registro já vinculado."
                    Else
                        objSlaEmitenteEstado = CarregaObjeto(objSlaEmitenteEstado)
                        objSlaEmitenteEstado.Incluir()
                    End If
                    Session("SAcaoSLAUF") = "EDITAR"
                    Session("SCodPaisSLA") = CodPais
                    Session("SCodEstadoSLA") = DdlEstado.SelectedValue
                    DdlEstado.Enabled = False
                    'Response.Redirect("WGClienteSLAEstadoCidade.aspx")
                    LblErro.Text = "Registro incluído com sucesso."
                End If
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub
    Protected Function CarregaObjeto(ByRef objSLAEmitenteCidade As UCLSLAEmitenteCidade) As UCLSLAEmitenteCidade
        objSLAEmitenteCidade.PrazoEncerramento = TxtPrazoEncerramento.Text.GetValidInputContent
        objSLAEmitenteCidade.PrazoChegada = TxtPrazoChegada.Text.GetValidInputContent
        Return objSLAEmitenteCidade
    End Function
    Protected Function CarregaObjeto(ByRef objSLAEmitenteEstado As UCLSLAEmitenteEstado) As UCLSLAEmitenteEstado
        objSLAEmitenteEstado.PrazoEncerramento = TxtPrazoEncerramento.Text.GetValidInputContent
        objSLAEmitenteEstado.PrazoChegada = TxtPrazoChegada.Text.GetValidInputContent
        Return objSLAEmitenteEstado
    End Function

    Protected Function IsDigitacaoOk() As Boolean
        LblErro.Text = ""
        If String.IsNullOrEmpty(TxtPrazoEncerramento.Text) Then
            LblErro.Text += "Preencha o campo Prazo Encerramento.<br/>"
        End If
        If String.IsNullOrEmpty(TxtPrazoChegada.Text) Then
            LblErro.Text += "Preencha o campo Prazo Chegada.<br/>"
        End If
        Return LblErro.Text.Trim = ""
    End Function

    Private Sub CarregaEstado()
        Try
            Dim objEstado As New UCLEstado
            objEstado.CodPais = CodPais
            objEstado.FillDropDown(DdlEstado, False, "", UCLEstado.Tipo.NomeEstado)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class