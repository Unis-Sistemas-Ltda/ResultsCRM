Partial Public Class WUCManual
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
        Dim ObjManual As New UCLManual
        LblCodigo.Text = Codigo

        If ObjManual.Buscar(Codigo) Then
            TxtNome.Text = ObjManual.GetConteudo("nome_manual")
        End If

    End Sub

    Private Sub CarregaNovaPK()
        Dim ObjManual As New UCLManual
        LblCodigo.Text = ObjManual.GetProximoCodigo()
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
        Dim ObjManual As New UCLManual
        Try
            If IsDigitacaoOk() Then
                If Acao = "ALTERAR" Then
                    ObjManual.Buscar(LblCodigo.Text)
                    ObjManual.SetConteudo("cod_manual", LblCodigo.Text)
                    ObjManual = CarregaObjeto(ObjManual)
                    ObjManual.Alterar()

                    If FU_Arquivo.FileName <> "" Then
                        FU_Arquivo.SaveAs(Server.MapPath("~") + "\\Manual\\" + ObjManual.GetConteudo("arquivo"))
                    End If

                    Response.Redirect("WFManual.aspx?d=" + Now.ToString("yyyyMMddHHmmssfff"))
                ElseIf Acao = "INCLUIR" Then
                    Call CarregaNovaPK()
                    ObjManual.SetConteudo("cod_manual", LblCodigo.Text)
                    ObjManual = CarregaObjeto(ObjManual)
                    ObjManual.Incluir()

                    If FU_Arquivo.FileName <> "" Then
                        FU_Arquivo.SaveAs(Server.MapPath("~") + "\\Manual\\" + ObjManual.GetConteudo("arquivo"))
                    End If

                    Session("SAcao") = "ALTERAR"
                    Session("SCodManual") = LblCodigo.Text

                    Response.Redirect("WFManual.aspx?d=" + Now.ToString("yyyyMMddHHmmssfff"))
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

        If Acao = "INCLUIR" Then
            If String.IsNullOrWhiteSpace(FU_Arquivo.FileName) Then
                LblErro.Text += "Preencha o campo Arquivo.<br/>"
            End If
        End If

        Return LblErro.Text.Trim = ""
    End Function

    Protected Function CarregaObjeto(ByRef objManual As UCLManual) As UCLManual
        Dim nomearq As String
        objManual.SetConteudo("nome_manual", TxtNome.Text.GetValidInputContent)
        nomearq = FU_Arquivo.FileName
        If Not String.IsNullOrWhiteSpace(nomearq) Then
            If nomearq.Contains("\") Then
                nomearq = nomearq.Substring(FU_Arquivo.FileName.LastIndexOf("\"))
            End If
            If nomearq.Contains("/") Then
                nomearq = nomearq.Substring(FU_Arquivo.FileName.LastIndexOf("/"))
            End If
            objManual.SetConteudo("arquivo", LblCodigo.Text + "_" + nomearq)
        End If

        Return objManual
    End Function

    Protected Sub BtnVoltar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnVoltar.Click
        Response.Redirect("WGManual.aspx")
    End Sub

    Protected Sub BtnVincular_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnVincular.Click
        Try
            If Acao = "INCLUIR" Then
                Throw New Exception("Antes de vincular o manual a um sistema, módulo e rotina, é necessário salvar o cadastro.")
            End If

            If DdlModulo.Items.Count = 0 Then
                Throw New Exception("Selecione o módulo.")
            End If

            If DdlRotina.Items.Count = 0 Then
                Throw New Exception("Selecione a rotina.")
            End If

            Dim objManualRotina As New UCLManualRotina

            If objManualRotina.Buscar(LblCodigo.Text, DdlSistema.SelectedValue, DdlModulo.SelectedValue, DdlRotina.SelectedValue) Then
                Throw New Exception("Sistema, módulo e rotina selecionados já estão vinculados a este manual.")
            End If

            objManualRotina.SetConteudo("cod_manual", LblCodigo.Text)
            objManualRotina.SetConteudo("cod_sistema", DdlSistema.SelectedValue)
            objManualRotina.SetConteudo("cod_modulo", DdlModulo.SelectedValue)
            objManualRotina.SetConteudo("cod_rotina", DdlRotina.SelectedValue)
            objManualRotina.Incluir()

            SqlDataSource1.Select(DataSourceSelectArguments.Empty)
            SqlDataSource1.DataBind()
            GridView1.DataBind()
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        Dim chave As String
        Dim codSistema, codModulo, codRotina As String
        Try
            If e.CommandName = "EXCLUIR" Then
                Dim objManualRotina As New UCLManualRotina

                chave = e.CommandArgument
                codSistema = chave.Substring(chave.IndexOf("cod_sistema=[") + 13)
                codModulo = chave.Substring(chave.IndexOf("cod_modulo=[") + 12)
                codRotina = chave.Substring(chave.IndexOf("cod_rotina=[") + 12)

                codSistema = codSistema.Substring(0, codSistema.IndexOf("]"))
                codModulo = codModulo.Substring(0, codModulo.IndexOf("]"))
                codRotina = codRotina.Substring(0, codRotina.IndexOf("]"))

                objManualRotina.Excluir(LblCodigo.Text, codSistema, codModulo, codRotina)

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
            Dim ObjRotina As New UCLRotina
            Dim codSistema As String = "0"
            Dim codModulo As String = "0"

            ObjSistema.FillDropDown(DdlSistema, False, "")
            If DdlSistema.Items.Count > 0 Then
                codSistema = DdlSistema.Items.Item(0).Value
            End If
            ObjModulo.FillDropDown(DdlModulo, False, "", codSistema)
            If DdlModulo.Items.Count > 0 Then
                codModulo = DdlModulo.Items.Item(0).Value
            End If
            ObjRotina.FillDropDown(DdlRotina, False, "", codSistema, codModulo)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub DdlSistema_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DdlSistema.SelectedIndexChanged
        Try
            Dim ObjModulo As New UCLModulo
            Dim codModulo As String = "0"
            Dim codSistema As String = "0"
            Dim ObjRotina As New UCLRotina

            codSistema = DdlSistema.SelectedValue
            ObjModulo.FillDropDown(DdlModulo, False, "", DdlSistema.SelectedValue)
            If DdlModulo.Items.Count > 0 Then
                codModulo = DdlModulo.Items.Item(0).Value
            End If
            ObjRotina.FillDropDown(DdlRotina, False, "", codSistema, codModulo)
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Protected Sub DdlModulo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DdlModulo.SelectedIndexChanged
        Try
            Dim ObjModulo As New UCLModulo
            Dim codModulo As String = "0"
            Dim codSistema As String = "0"
            Dim ObjRotina As New UCLRotina

            codSistema = DdlSistema.SelectedValue
            codModulo = DdlModulo.SelectedValue
            ObjRotina.FillDropDown(DdlRotina, False, "", codSistema, codModulo)
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub
End Class