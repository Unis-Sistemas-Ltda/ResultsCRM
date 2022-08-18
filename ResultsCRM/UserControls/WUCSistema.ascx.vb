Partial Public Class WUCSistema
    Inherits System.Web.UI.UserControl

    Private _Acao As String
    Private _Codigo As String

    Public Property Acao() As String
        Get
            Return _Acao
        End Get
        Set(ByVal value As String)
            _Acao = value
        End Set
    End Property

    Public Property Codigo() As String
        Get
            Return _Codigo
        End Get
        Set(ByVal value As String)
            _Codigo = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Acao = "ALTERAR" Then
                Call CarregaFormulario()
            ElseIf Acao = "INCLUIR" Then
                Call CarregaNovaPK()
            End If
        End If
    End Sub

    Private Sub CarregaFormulario()
        Dim ObjSistema As New UCLSistema
        LblCodigo.Text = Codigo

        ObjSistema.CodSistema = Codigo
        ObjSistema.Buscar()

        TxtDescricao.Text = ObjSistema.Descricao
    End Sub

    Private Sub CarregaNovaPK()
        Dim ObjSistema As New UCLSistema
        LblCodigo.Text = ObjSistema.GetProximoCodigo
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
        Dim ObjSistema As New UCLSistema
        Try
            If IsDigitacaoOk() Then
                If Acao = "ALTERAR" Then
                    ObjSistema.CodSistema = LblCodigo.Text
                    ObjSistema = CarregaObjeto(ObjSistema)
                    ObjSistema.Alterar()
                    'Call GravaBancoDados()
                    Response.Redirect("WGSistema.aspx")
                ElseIf Acao = "INCLUIR" Then
                    Call CarregaNovaPK()
                    ObjSistema.CodSistema = LblCodigo.Text
                    ObjSistema = CarregaObjeto(ObjSistema)
                    ObjSistema.Incluir()
                    'Call GravaBancoDados()
                    Response.Redirect("WGSistema.aspx")
                End If
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    'Protected Sub GravaBancoDados()
    '    Try
    '        Dim ObjSistemaBancoDados As New UCLSistemaBancoDados
    '        Dim CodBancoDados As String

    '        For i As Long = 0 To CbxBancoDados.Items.Count - 1
    '            CodBancoDados = CbxBancoDados.Items.Item(i).Value

    '            ObjSistemaBancoDados.CodSistema = LblCodigo.Text
    '            ObjSistemaBancoDados.CodBancoDados = CodBancoDados
    '            If CbxBancoDados.Items.Item(i).Selected Then
    '                If Not ObjSistemaBancoDados.Existe() Then
    '                    ObjSistemaBancoDados.Incluir()
    '                End If
    '            Else
    '                If ObjSistemaBancoDados.Existe() Then
    '                    ObjSistemaBancoDados.Excluir()
    '                End If
    '            End If
    '        Next

    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    'Protected Sub CarregaBancoDados()
    '    Try
    '        Dim ObjSistemaBancoDados As New UCLSistemaBancoDados
    '        Dim CodBancoDados As String

    '        For i As Long = 0 To CbxBancoDados.Items.Count - 1
    '            CodBancoDados = CbxBancoDados.Items.Item(i).Value

    '            ObjSistemaBancoDados.CodSistema = LblCodigo.Text
    '            ObjSistemaBancoDados.CodBancoDados = CodBancoDados
    '            If ObjSistemaBancoDados.Existe() Then
    '                CbxBancoDados.Items.Item(i).Selected = True
    '            Else
    '                CbxBancoDados.Items.Item(i).Selected = False
    '            End If
    '        Next

    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    Protected Function IsDigitacaoOk() As Boolean
        LblErro.Text = ""

        If String.IsNullOrEmpty(TxtDescricao.Text) Then
            LblErro.Text += "Preencha o campo Descrição.<br/>"
        End If

        Return LblErro.Text.Trim = ""
    End Function

    Protected Function CarregaObjeto(ByRef ObjSistema As UCLSistema) As UCLSistema
        ObjSistema.Descricao = TxtDescricao.Text.GetValidInputContent
        Return ObjSistema
    End Function

    Protected Sub BtnVoltar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnVoltar.Click
        Response.Redirect("WGSistema.aspx")
    End Sub

    'Private Sub CbxBancoDados_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles CbxBancoDados.DataBound
    '    Try
    '        Call CarregaBancoDados()
    '    Catch ex As Exception
    '        LblErro.Text = ex.Message
    '    End Try
    'End Sub

    
End Class