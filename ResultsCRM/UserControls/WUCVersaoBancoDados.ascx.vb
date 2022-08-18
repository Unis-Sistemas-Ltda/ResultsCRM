Partial Public Class WUCVersaoBancoDados
    Inherits System.Web.UI.UserControl

    Private _Acao As String
    Private _Versao As String
    Private _CodBancoDados As String

    Public Property Acao() As String
        Get
            Return _Acao
        End Get
        Set(ByVal value As String)
            _Acao = value
        End Set
    End Property

    Public Property Versao() As String
        Get
            Return _Versao
        End Get
        Set(ByVal value As String)
            _Versao = value
        End Set
    End Property

    Public Property CodBancoDados() As String
        Get
            Return _CodBancoDados
        End Get
        Set(ByVal value As String)
            _CodBancoDados = value
        End Set
    End Property

    Public Sub CarregaBancoDados()
        Try
            Dim ObjBancoDados As New UCLBancoDados
            ObjBancoDados.FillDropDown(DdlBancoDados, False, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub CarregaNovaPK()
        Try
            Dim objVersao As New UCLBancoDadosVersao
            objVersao.CodBancoDados = DdlBancoDados.SelectedValue
            TxtVersao.Text = objVersao.GetProximoCodigo()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                Call CarregaBancoDados()
                If Acao = "ALTERAR" Then
                    Call CarregaFormulario()
                    DdlBancoDados.Enabled = False
                Else
                    Call CarregaNovaPK()
                    TxtInicioVigencia.Text = Now.Date.ToString("dd/MM/yyyy")
                End If
            End If
            TxtInicioVigencia.Attributes.Add("OnKeyPress", "formatacampo(this,'##/##/####');")
            TxtInicioVigencia.Attributes.Add("OnFocus", "selecionaCampo(this)")
            TxtTerminoVigencia.Attributes.Add("OnKeyPress", "formatacampo(this,'##/##/####');")
            TxtTerminoVigencia.Attributes.Add("OnFocus", "selecionaCampo(this)")
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Private Sub CarregaFormulario()
        Dim ObjVersaoSistema As New UCLBancoDadosVersao

        TxtVersao.Text = Versao
        DdlBancoDados.SelectedValue = CodBancoDados

        ObjVersaoSistema.Versao = Versao
        ObjVersaoSistema.CodBancoDados = CodBancoDados
        ObjVersaoSistema.Buscar()

        TxtDescricao.Text = ObjVersaoSistema.Descricao
        TxtInicioVigencia.Text = ObjVersaoSistema.InicioVigencia
        TxtTerminoVigencia.Text = ObjVersaoSistema.TerminoVigencia
        If ObjVersaoSistema.Liberado = "S" Then
            CbxLiberada.Checked = True
        Else
            CbxLiberada.Checked = False
        End If

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
        Dim ObjVersaoSistema As New UCLBancoDadosVersao
        Try
            If IsDigitacaoOk() Then
                If Acao = "ALTERAR" Then
                    ObjVersaoSistema.Versao = TxtVersao.Text
                    ObjVersaoSistema.CodBancoDados = DdlBancoDados.SelectedValue
                    ObjVersaoSistema = CarregaObjeto(ObjVersaoSistema)
                    ObjVersaoSistema.Alterar()
                    Response.Redirect("WGVersaoBancoDados.aspx")
                ElseIf Acao = "INCLUIR" Then
                    ObjVersaoSistema.Versao = TxtVersao.Text
                    ObjVersaoSistema.CodBancoDados = DdlBancoDados.SelectedValue
                    ObjVersaoSistema = CarregaObjeto(ObjVersaoSistema)
                    ObjVersaoSistema.Incluir()
                    Response.Redirect("WGVersaoBancoDados.aspx")
                End If
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Protected Function IsDigitacaoOk() As Boolean
        LblErro.Text = ""

        Return LblErro.Text.Trim = ""
    End Function

    Protected Function CarregaObjeto(ByRef ObjVersaoSistema As UCLBancoDadosVersao) As UCLBancoDadosVersao
        ObjVersaoSistema.Descricao = TxtDescricao.Text.GetValidInputContent
        ObjVersaoSistema.InicioVigencia = TxtInicioVigencia.Text
        ObjVersaoSistema.TerminoVigencia = TxtTerminoVigencia.Text
        If CbxLiberada.Checked Then
            ObjVersaoSistema.Liberado = "S"
        Else
            ObjVersaoSistema.Liberado = "N"
        End If

        Return ObjVersaoSistema
    End Function

    Protected Sub BtnVoltar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnVoltar.Click
        Response.Redirect("WGVersaoBancoDados.aspx")
    End Sub

    Protected Sub CbxLiberada_CheckedChanged(sender As Object, e As EventArgs) Handles CbxLiberada.CheckedChanged
        If CbxLiberada.Checked Then
            TxtTerminoVigencia.Text = Now.Date.ToString("dd/MM/yyyy")
        End If
    End Sub

    Protected Sub DdlBancoDados_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DdlBancoDados.SelectedIndexChanged
        Try
            Call CarregaNovaPK()
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub
End Class