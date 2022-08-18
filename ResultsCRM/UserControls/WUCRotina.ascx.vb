Partial Public Class WUCRotina
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
            Call CarregaDDL()
            If Acao = "ALTERAR" Then
                BtnGravar.Text = "Gravar alterações"
                Call CarregaFormulario()
            ElseIf Acao = "INCLUIR" Then
                BtnGravar.Text = "Incluir"
                Call CarregaNovaPK()
            End If
        End If
    End Sub

    Private Sub CarregaFormulario()
        Dim ObjRotina As New UCLRotina
        LblCodigo.Text = Codigo

        If ObjRotina.Buscar(Codigo) Then
            TxtNome.Text = ObjRotina.GetConteudo("nome")
            TxtDescricao.Text = ObjRotina.GetConteudo("descricao")
        End If

    End Sub

    Private Sub CarregaNovaPK()
        Dim ObjRotina As New UCLRotina
        LblCodigo.Text = ObjRotina.GetProximoCodigo()
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
        Dim ObjRotina As New UCLRotina
        Try
            If IsDigitacaoOk() Then
                If Acao = "ALTERAR" Then
                    ObjRotina.SetConteudo("cod_rotina", LblCodigo.Text)
                    ObjRotina = CarregaObjeto(ObjRotina)
                    ObjRotina.Alterar()
                    Response.Redirect("WFRotina.aspx?d=" + Now.ToString("yyyyMMddHHmmssfff"))
                ElseIf Acao = "INCLUIR" Then
                    Call CarregaNovaPK()
                    ObjRotina.SetConteudo("cod_rotina", LblCodigo.Text)
                    ObjRotina = CarregaObjeto(ObjRotina)
                    ObjRotina.Incluir()
                    Session("SAcao") = "ALTERAR"
                    Session("SCodRotina") = LblCodigo.Text
                    Response.Redirect("WFRotina.aspx?d=" + Now.ToString("yyyyMMddHHmmssfff"))
                End If
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Protected Function IsDigitacaoOk() As Boolean
        LblErro.Text = ""

        If String.IsNullOrEmpty(TxtNome.Text) Then
            LblErro.Text += "Preencha o campo Nome.<br/>"
        End If

        Return LblErro.Text.Trim = ""
    End Function

    Protected Function CarregaObjeto(ByRef ObjRotina As UCLRotina) As UCLRotina
        ObjRotina.SetConteudo("nome", TxtNome.Text.GetValidInputContent)
        ObjRotina.SetConteudo("descricao", TxtDescricao.Text.GetValidInputContent)
        Return ObjRotina
    End Function

    Protected Sub BtnVoltar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnVoltar.Click
        Response.Redirect("WGRotina.aspx")
    End Sub

    Protected Sub BtnVincular_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnVincular.Click
        Try
            If Acao = "INCLUIR" Then
                Throw New Exception("Antes de vincular a rotina a um sistema/módulo é necessário salvar o cadastro.")
            End If

            If DdlModulo.Items.Count = 0 Then
                Throw New Exception("Selecione o módulo.")
            End If

            Dim objRotinaModulo As New UCLRotinaModulo

            If objRotinaModulo.Buscar(LblCodigo.Text, DdlModulo.SelectedValue) Then
                Throw New Exception("O sistema/módulo selecionado já está vinculado a esta rotina.")
            End If

            objRotinaModulo.SetConteudo("cod_rotina", LblCodigo.Text)
            objRotinaModulo.SetConteudo("cod_modulo", DdlModulo.SelectedValue)
            objRotinaModulo.Incluir()

            SqlDataSource1.Select(DataSourceSelectArguments.Empty)
            SqlDataSource1.DataBind()
            GridView1.DataBind()
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        Try
            If e.CommandName = "EXCLUIR" Then
                Dim objRotinaModulo As New UCLRotinaModulo
                objRotinaModulo.Excluir(LblCodigo.Text, e.CommandArgument)

                SqlDataSource1.Select(DataSourceSelectArguments.Empty)
                SqlDataSource1.DataBind()
                GridView1.DataBind()
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Private Sub CarregaDDL()
        Try
            Dim ObjSistema As New UCLSistema
            Dim ObjModulo As New UCLModulo
            Dim codSistema As String = "0"

            ObjSistema.FillDropDown(DdlSistema, False, "")
            If DdlSistema.Items.Count > 0 Then
                codSistema = DdlSistema.Items.Item(0).Value
            End If
            ObjModulo.FillDropDown(DdlModulo, False, "", codSistema)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub DdlSistema_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DdlSistema.SelectedIndexChanged
        Try
            Dim ObjModulo As New UCLModulo
            ObjModulo.FillDropDown(DdlModulo, False, "", DdlSistema.SelectedValue)
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub
End Class