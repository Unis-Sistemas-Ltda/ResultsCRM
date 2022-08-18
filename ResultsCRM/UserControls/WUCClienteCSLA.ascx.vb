Partial Public Class WUClienteCSLA
    Inherits System.Web.UI.UserControl
    Private _Acao As String
    Private _CodSLA As String
    Private _CodCliente As String
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
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Call CarregaSLA()
            If Acao = "ALTERAR" Then
                Call CarregaFormulario()
            ElseIf Acao = "INCLUIR" Then
                Dim objSla As New UCLSLA
                objSla.CodSLA = DDLSLA.SelectedValue
                objSla.Buscar()
                TxtPrazoChegada.Text = objSla.PrazoChegada
                TxtPrazoEncerramento.Text = objSla.PrazoEncerramento
            End If
        End If
    End Sub

    Private Sub CarregaFormulario()
        Try
            Dim objSLAEmitente As New UCLSLAEmitente

            objSLAEmitente.CodEmitente = CodCliente
            objSLAEmitente.CodSLA = CodSLA
            objSLAEmitente.Buscar()

            If DDLSLA.Items.FindByValue(CodSLA) IsNot Nothing Then
                DDLSLA.SelectedValue = CodSLA
                DDLSLA.Enabled = False
            End If

            TxtPrazoEncerramento.Text = objSLAEmitente.PrazoEncerramento
            TxtPrazoChegada.Text = objSLAEmitente.PrazoChegada
            TxtQtdChamadosDia.Text = objSLAEmitente.QtdChamadoDia
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaSLA()
        Try
            Dim objSLA As New UCLSLA
            objSLA.FillDropDown(DDLSLA, False, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub BtnGravar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
        Try
            Dim objSLAEmitente As New UCLSLAEmitente
            If IsDigitacaoOk() Then
                If Acao = "ALTERAR" Then
                    objSLAEmitente.CodSLA = DDLSLA.SelectedValue
                    objSLAEmitente.CodEmitente = CodCliente
                    objSLAEmitente = CarregaObjeto(objSLAEmitente)
                    objSLAEmitente.Alterar()
                    'Response.Redirect("WGClienteSLA.aspx")
                    LblErro.Text = "Registro alterado com sucesso."
                ElseIf Acao = "INCLUIR" Then
                    objSLAEmitente.CodSLA = DDLSLA.SelectedValue
                    objSLAEmitente.CodEmitente = CodCliente
                    If objSLAEmitente.Buscar() Then
                        LblErro.Text = "SLA já vinculado."
                        Return
                    End If
                    objSLAEmitente = CarregaObjeto(objSLAEmitente)
                    objSLAEmitente.Incluir()
                    'Response.Redirect("WGClienteSLA.aspx")
                    LblErro.Text = "Registro incluído com sucesso."
                End If
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub
    Protected Function CarregaObjeto(ByRef objSLAEmitente As UCLSLAEmitente) As UCLSLAEmitente
        objSLAEmitente.PrazoEncerramento = TxtPrazoEncerramento.Text.GetValidInputContent
        objSLAEmitente.PrazoChegada = TxtPrazoChegada.Text.GetValidInputContent
        objSLAEmitente.QtdChamadoDia = TxtQtdChamadosDia.Text.GetValidInputContent
        Return objSLAEmitente
    End Function
    
    Protected Function IsDigitacaoOk() As Boolean
        LblErro.Text = ""
        Return LblErro.Text.Trim = ""
    End Function

    Protected Sub DDLSLA_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DDLSLA.SelectedIndexChanged
        Try
            Dim objSla As New UCLSLA
            objSla.CodSLA = DDLSLA.SelectedValue
            objSla.Buscar()
            TxtPrazoChegada.Text = objSla.PrazoChegada
            TxtPrazoEncerramento.Text = objSla.PrazoEncerramento
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class