Public Class WUCMarcador
    Inherits System.Web.UI.UserControl
    Private _Acao As String
    Private _CodMarcador As String

    Public ReadOnly Property Embeeded As Boolean
        Get
            Return Request.QueryString.Item("embeeded")
        End Get
    End Property

    Public Property Acao() As String
        Get
            Return _Acao
        End Get
        Set(ByVal value As String)
            _Acao = value
        End Set
    End Property

    Public Property CodMarcador() As String
        Get
            Return _CodMarcador
        End Get
        Set(ByVal value As String)
            _CodMarcador = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Session("SRecarregaDDLMarcador") = "False"
            Session("SMarcadorSelecionado") = ""
            If Acao = "ALTERAR" Then
                Call CarregaFormulario()
            ElseIf Acao = "INCLUIR" Then
                Call CarregaNovaPK()
                Call CarregaMarcadorPai()
            End If
        End If
    End Sub

    Private Sub CarregaFormulario()
        Try
            Dim ObjMarcador As New UCLMarcador
            LblCodMarcador.Text = CodMarcador
            ObjMarcador.Buscar(Session("GlEmpresa"), CodMarcador)
            TxtDescricao.Text = ObjMarcador.GetConteudo("descricao")
            Call CarregaMarcadorPai()
            If Not ObjMarcador.IsNull("cod_marcador_pai") Then
                DdlMarcadorPai.SelectedValue = ObjMarcador.GetConteudo("cod_marcador_pai")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaNovaPK()
        Try
            Dim ObjMarcador As New UCLMarcador
            LblCodMarcador.Text = ObjMarcador.GetProximoCodigo(Session("GlEmpresa"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
        Dim ObjMarcador As New UCLMarcador
        Try
            If IsDigitacaoOk() Then
                If Acao = "ALTERAR" Then
                    ObjMarcador.SetConteudo("empresa", Session("GlEmpresa"))
                    ObjMarcador.SetConteudo("cod_marcador", LblCodMarcador.Text)
                    ObjMarcador = CarregaObjeto(ObjMarcador)
                    ObjMarcador.Alterar()
                    If Embeeded Then
                        Page.ClientScript.RegisterStartupScript(Me.GetType(), "onload", "onSuccess();", True)
                    Else
                        Response.Redirect("WGMarcador.aspx")
                    End If
                ElseIf Acao = "INCLUIR" Then
                    Call CarregaNovaPK()
                    ObjMarcador.SetConteudo("empresa", Session("GlEmpresa"))
                    ObjMarcador.SetConteudo("cod_marcador", LblCodMarcador.Text)
                    ObjMarcador = CarregaObjeto(ObjMarcador)
                    ObjMarcador.Incluir()
                    If Embeeded Then
                        Session("SRecarregaDDLMarcador") = True
                        Session("SMarcadorSelecionado") = LblCodMarcador.Text
                        Page.ClientScript.RegisterStartupScript(Me.GetType(), "onload", "onSuccess();", True)
                    Else
                        Response.Redirect("WGMarcador.aspx")
                    End If
                End If
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Protected Function IsDigitacaoOk() As Boolean
        LblErro.Text = ""

        If String.IsNullOrEmpty(TxtDescricao.Text) Then
            LblErro.Text += "Preencha o campo Descrição.<br/>"
        End If

        Return LblErro.Text.Trim = ""
    End Function

    Protected Function CarregaObjeto(ByRef ObjMarcador As UCLMarcador) As UCLMarcador
        ObjMarcador.SetConteudo("descricao", TxtDescricao.Text.GetValidInputContent)
        If DdlMarcadorPai.SelectedValue = "0" Then
            ObjMarcador.SetConteudo("cod_marcador_pai", "")
        Else
            ObjMarcador.SetConteudo("cod_marcador_pai", DdlMarcadorPai.SelectedValue)
        End If
        Return ObjMarcador
    End Function

    Protected Sub BtnVoltar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnVoltar.Click
        If Embeeded Then
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "onload", "cancel();", True)
        Else
            Response.Redirect("WGMarcador.aspx")
        End If
    End Sub

    Private Sub CarregaMarcadorPai()
        Try
            Dim objMarcador As New UCLMarcador
            objMarcador.FillDropDown(DdlMarcadorPai, Session("GlEmpresa"), True, " ", "0", LblCodMarcador.Text)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub btnOkay_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnOkay.Click
        Try
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "onload", "onSuccess();", True)
        Catch ex As Exception
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "onload", "onError();", True)
        End Try
    End Sub
End Class