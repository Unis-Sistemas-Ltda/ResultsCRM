Partial Public Class WUCFunilVenda
    Inherits System.Web.UI.UserControl
    Private _Acao As String
    Private _CodFunil As String
    Public Property Acao() As String
        Get
            Return _Acao
        End Get
        Set(ByVal value As String)
            _Acao = value
        End Set
    End Property
    Public Property CodFunil() As String
        Get
            Return _CodFunil
        End Get
        Set(ByVal value As String)
            _CodFunil = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                Call CarregaEtapa()
                If Acao = "ALTERAR" Then
                    Call CarregaFormulario()
                ElseIf Acao = "INCLUIR" Then
                    Call CarregaNovaPK()
                End If
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Private Sub CarregaFormulario()
        Dim ObjFunil As New UCLFunilVenda
        ObjFunil.Empresa = Session("GLEmpresa")
        ObjFunil.Codigo = CodFunil
        LblCodigo.Text = CodFunil
        ObjFunil.Buscar()
        TxtDescricao.Text = ObjFunil.Descricao
        DdlEtapaFinalSucesso.SelectedValue = ObjFunil.CodEtapaFinalSucesso
        DdlEtapaFinalInsucesso.SelectedValue = ObjFunil.CodEtapaFinalInsucesso
        CbxOcultarEquipamento.Checked = (ObjFunil.OcultarEquipamento = "S")
    End Sub

    Protected Sub BtnGravar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
        Dim ObjFunil As New UCLFunilVenda
        Try
            If IsDigitacaoOk() Then
                If Acao = "ALTERAR" Then
                    ObjFunil.Empresa = Session("GLEmpresa")
                    ObjFunil.Codigo = LblCodigo.Text
                    ObjFunil = CarregaObjeto(ObjFunil)
                    ObjFunil.Alterar()
                    Response.Redirect("WGFunilVenda.aspx")
                ElseIf Acao = "INCLUIR" Then
                    Call CarregaNovaPK()
                    ObjFunil.Empresa = Session("GLEmpresa")
                    ObjFunil.Codigo = LblCodigo.Text
                    ObjFunil = CarregaObjeto(ObjFunil)
                    ObjFunil.Incluir()
                    Response.Redirect("WGFunilVenda.aspx")
                End If
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Protected Function CarregaObjeto(ByRef ObjFunil As UCLFunilVenda) As UCLFunilVenda
        ObjFunil.Descricao = TxtDescricao.Text.GetValidInputContent
        If DdlEtapaFinalSucesso.SelectedValue <> "0" Then
            ObjFunil.CodEtapaFinalSucesso = DdlEtapaFinalSucesso.SelectedValue
        Else
            ObjFunil.CodEtapaFinalSucesso = ""
        End If
        If DdlEtapaFinalInsucesso.SelectedValue <> "0" Then
            ObjFunil.CodEtapaFinalInsucesso = DdlEtapaFinalInsucesso.SelectedValue
        Else
            ObjFunil.CodEtapaFinalInsucesso = ""
        End If
        ObjFunil.OcultarEquipamento = IIf(CbxOcultarEquipamento.Checked, "S", "N")
        Return ObjFunil
    End Function

    Private Sub CarregaNovaPK()
        Dim ObjFunil As New UCLFunilVenda
        ObjFunil.Empresa = Session("GLEmpresa")
        LblCodigo.Text = ObjFunil.GetProximoCodigo
    End Sub

    Protected Function IsDigitacaoOk() As Boolean
        LblErro.Text = ""
        If String.IsNullOrEmpty(TxtDescricao.Text) Then
            LblErro.Text += "Preencha o campo Descrição.<br/>"
        End If
        Return LblErro.Text.Trim = ""
    End Function

    Protected Sub BtnVoltar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnVoltar.Click
        Response.Redirect("WGFunilVenda.aspx")
    End Sub

    Private Sub CarregaEtapa()
        Try
            Dim objEtapaNegociacao As New UCLEtapaNegociacao
            objEtapaNegociacao.Empresa = Session("GlEmpresa")
            objEtapaNegociacao.FillDropDown(DdlEtapaFinalSucesso, True, "(selecione)", "", "")
            objEtapaNegociacao.FillDropDown(DdlEtapaFinalInsucesso, True, "(selecione)", "", "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class