Partial Public Class WUCClienteCSLAEstadoCidade
    Inherits System.Web.UI.UserControl
    Private _Acao As String
    Private _CodSLA As String
    Private _CodCliente As String
    Private _CodPais As String
    Private _CodEstado As String
    Private _CodCidade As String
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
    Public Property CodCidade As String
        Get
            Return _CodCidade
        End Get
        Set(ByVal value As String)
            _CodCidade = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objSLAEmitenteEstado As New UCLSLAEmitenteEstado
        If Not IsPostBack Then
            If Acao = "EDITAR" Then
                Call CarregaFormulario()
            ElseIf Acao = "INCLUIR" Then
                Call CarregaEstado()
                DdlEstado.SelectedValue = CodEstado
                Call CarregaCidade()
                Try
                    objSLAEmitenteEstado.CodEmitente = CodCliente
                    objSLAEmitenteEstado.CodSLA = CodSLA
                    objSLAEmitenteEstado.CodPais = CodPais
                    objSLAEmitenteEstado.CodEstado = CodEstado
                    objSLAEmitenteEstado.Buscar()
                    TxtPrazoChegada.Text = objSLAEmitenteEstado.PrazoChegada
                    TxtPrazoEncerramento.Text = objSLAEmitenteEstado.PrazoEncerramento
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
            Dim objSLACidade As New UCLSLAEmitenteCidade
            objSLACidade.CodSLA = CodSLA
            objSLACidade.CodEmitente = CodCliente
            objSLACidade.CodPais = CodPais
            objSLACidade.CodEstado = CodEstado
            objSLACidade.CodCidade = CodCidade
            If objSLACidade.Buscar() Then
                TxtPrazoEncerramento.Text = objSLACidade.PrazoEncerramento
                TxtPrazoChegada.Text = objSLACidade.PrazoChegada
                Call CarregaEstado()
                DdlEstado.SelectedValue = CodEstado
                Call CarregaCidade()
                DdlCidade.SelectedValue = CodCidade
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub BtnGravar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
        Try
            Dim objSLAEmitenteCidade As New UCLSLAEmitenteCidade
            If IsDigitacaoOk() Then
                If Acao = "EDITAR" Then
                    objSLAEmitenteCidade.CodSLA = CodSLA
                    objSLAEmitenteCidade.CodEmitente = CodCliente
                    objSLAEmitenteCidade.CodPais = CodPais
                    objSLAEmitenteCidade.CodEstado = CodEstado
                    objSLAEmitenteCidade.CodCidade = CodCidade
                    objSLAEmitenteCidade = CarregaObjeto(objSLAEmitenteCidade)
                    objSLAEmitenteCidade.Alterar()

                    Response.Redirect("WGClienteSLAEstadoCidade.aspx")
                ElseIf Acao = "INCLUIR" Then

                    objSLAEmitenteCidade.CodSLA = CodSLA
                    objSLAEmitenteCidade.CodEmitente = CodCliente
                    objSLAEmitenteCidade.CodPais = CodPais
                    objSLAEmitenteCidade.CodEstado = DdlEstado.SelectedValue
                    objSLAEmitenteCidade.CodCidade = DdlCidade.SelectedValue
                    If objSLAEmitenteCidade.Buscar() Then
                        LblErro.Text = "Erro: Registro já vinculado."
                    Else
                        objSLAEmitenteCidade = CarregaObjeto(objSLAEmitenteCidade)
                        objSLAEmitenteCidade.Incluir()
                    End If
                    Response.Redirect("WGClienteSLAEstadoCidade.aspx")
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

    Protected Sub DdlEstado_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DdlEstado.SelectedIndexChanged
        Call CarregaCidade()
    End Sub

    Private Sub CarregaEstado()
        Try
            Dim objEstado As New UCLEstado
            objEstado.CodPais = CodPais
            objEstado.FillDropDown(DdlEstado, False, "", UCLEstado.Tipo.NomeEstado)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaCidade()
        Try
            Dim objCidade As New UCLCidade
            objCidade.CodPais = CodPais
            objCidade.CodEstado = DdlEstado.SelectedValue
            objCidade.FillDropDown(DdlCidade, True, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub BtnVoltar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnVoltar.Click
        Response.Redirect("WGClienteSLAEstadoCidade.aspx")
    End Sub
End Class