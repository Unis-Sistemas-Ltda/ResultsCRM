Partial Public Class WUCFAQ
    Inherits System.Web.UI.UserControl

    Private _Modo As Int16
    Private _CodFAQ As String

    Public Property Modo() As Int16
        Get
            Return _Modo
        End Get
        Set(ByVal value As Int16)
            _Modo = value
            Dim sAcao As String = Session("SAcao")
            Select Case _Modo
                Case ModoFormulario.ConsultaAlteracaoExclusao
                    If sAcao = "ALTERAR" Then
                        LblAcao.Text = "Alteração"
                        AddHandler BtnGravar.Click, AddressOf GravarDados
                    End If
                    BtnGravar.Text = "Gravar"
                Case ModoFormulario.Inclusao
                    LblAcao.Text = "Inclusão"
                    BtnGravar.Text = "Incluir"
                    AddHandler BtnGravar.Click, AddressOf IncluirDados
            End Select
        End Set
    End Property

    Public Property CodFAQ() As String
        Get
            Return _CodFAQ
        End Get
        Set(ByVal value As String)
            _CodFAQ = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                Call CarregaDDL()
                Dim ObjFAQ As New UCLFAQ(StrConexao)
                If Me.Modo = ModoFormulario.ConsultaAlteracaoExclusao Then
                    Call CarregaFormulario()
                    LblCodFAQ.Text = CodFAQ
                ElseIf Me.Modo = ModoFormulario.Inclusao Then
                    LblCodFAQ.Text = ObjFAQ.GetProximoCodigo().ToString
                    LblCodFAQ.DataBind()
                End If
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Private Sub CarregaDDL()
        Try
            Dim ObjSistema As New UCLSistema
            Dim ObjRotina As New UCLRotina
            Dim ObjModulo As New UCLModulo

            ObjSistema.FillDropDown(DdlSistema, True, " (selecionar) ")
            ObjModulo.FillDropDown(DdlModulo, True, " (selecionar) ", 0)
            ObjRotina.FillDropDown(DdlRotina, True, " (selecionar) ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub CarregaFormulario()
        Try
            Dim ObjFAQ As New UCLFAQ(StrConexao)

            ObjFAQ.CodFAQ = CodFAQ
            ObjFAQ.Buscar()

            LblCodFAQ.Text = CodFAQ
            TxtPergunta.Content = ObjFAQ.Pergunta
            TxtResposta.Content = ObjFAQ.Resposta
            If ObjFAQ.Ativo = "S" Then
                CbxAtivo.Checked = True
            Else
                CbxAtivo.Checked = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Function CarregaObjeto(ByVal ObjFAQ As UCLFAQ) As UCLFAQ
        Try
            ObjFAQ.Pergunta = Server.HtmlDecode(TxtPergunta.Content)
            ObjFAQ.Resposta = Server.HtmlDecode(TxtResposta.Content)
            If Not String.IsNullOrWhiteSpace(FUAnexo.FileName) Then
                ObjFAQ.Anexo = Arquivo(ObjFAQ.CodFAQ)
            Else
                ObjFAQ.Anexo = ""
            End If
            If CbxAtivo.Checked Then
                ObjFAQ.Ativo = "S"
            Else
                ObjFAQ.Ativo = "N"
            End If
            Return ObjFAQ
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Protected Function Arquivo(ByVal CodFAQ As String) As String
        Try
            Dim arq As String = ""

            If Not String.IsNullOrWhiteSpace(FUAnexo.FileName) Then
                arq = Page.MapPath("~\FAQ\Arquivos")
                arq += "\" + CodFAQ + "_" + FUAnexo.FileName
            End If

            Return arq
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Protected Sub IncluirDados(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim ObjFAQ As New UCLFAQ(StrConexao)
            If isDigitacaoOK() Then
                ObjFAQ.CodFAQ = ObjFAQ.GetProximoCodigo()
                ObjFAQ = CarregaObjeto(ObjFAQ)
                ObjFAQ.Incluir()
                If Not String.IsNullOrWhiteSpace(Arquivo(ObjFAQ.CodFAQ)) Then
                    If System.IO.File.Exists(Arquivo(ObjFAQ.CodFAQ)) Then
                        System.IO.File.Delete(Arquivo(ObjFAQ.CodFAQ))
                    End If
                    FUAnexo.SaveAs(Arquivo(ObjFAQ.CodFAQ))
                End If
                Session("SAcao") = "ALTERAR"
                Session("SCodFAQ") = ObjFAQ.CodFAQ
                Response.Redirect("WFFAQ.aspx")
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Protected Sub GravarDados(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim ObjFAQ As New UCLFAQ(StrConexao)
            If isDigitacaoOK() Then
                ObjFAQ.CodFAQ = LblCodFAQ.Text
                ObjFAQ = CarregaObjeto(ObjFAQ)
                ObjFAQ.Alterar()
                If Not String.IsNullOrWhiteSpace(Arquivo(ObjFAQ.CodFAQ)) Then
                    If System.IO.File.Exists(Arquivo(ObjFAQ.CodFAQ)) Then
                        System.IO.File.Delete(Arquivo(ObjFAQ.CodFAQ))
                    End If
                    FUAnexo.SaveAs(Arquivo(ObjFAQ.CodFAQ))
                End If
                Response.Redirect("WGFAQ.aspx")
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Protected Function isDigitacaoOK() As Boolean
        Try
            LblErro.Text = ""
            If String.IsNullOrWhiteSpace(TxtPergunta.Content) Then
                LblErro.Text += "Preencha o campo Pergunta.<br>"
            End If
            If String.IsNullOrWhiteSpace(TxtResposta.Content) Then
                LblErro.Text += "Preencha o campo Resposta.<br>"
            End If
            Return LblErro.Text = ""
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Protected Sub BtnVoltar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnVoltar.Click
        Response.Redirect("WGFAQ.aspx")
    End Sub

    Protected Sub BtnAddSistema_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnAddSistema.Click
        Try
            If Session("SAcao") = "INCLUIR" Then
                LblErro.Text = "Não é possível vincular sistema antes de incluir a FAQ."
                Return
            End If
            Dim ObjFAQSistema As New UCLFAQSistema
            Dim codigo As String = DdlSistema.SelectedValue
            If codigo > "0" Then
                If Not ObjFAQSistema.Buscar(LblCodFAQ.Text, codigo) Then
                    ObjFAQSistema.SetConteudo("cod_faq", LblCodFAQ.Text)
                    ObjFAQSistema.SetConteudo("cod_sistema", codigo)
                    ObjFAQSistema.Incluir()
                    SqlDataSource1.Select(DataSourceSelectArguments.Empty)
                    SqlDataSource1.DataBind()
                    GridView1.DataBind()
                Else
                    LblErro.Text = "Sistema selecionado já foi vinculado."
                End If
            Else
                LblErro.Text = "Selecione o sistema a ser vinculado."
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Protected Sub BtnAddModulo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnAddModulo.Click
        Try
            If Session("SAcao") = "INCLUIR" Then
                LblErro.Text = "Não é possível vincular módulo antes de incluir a FAQ."
                Return
            End If
            Dim ObjFAQModulo As New UCLFAQModulo
            Dim codigo As String = DdlModulo.SelectedValue
            If codigo > "0" Then
                If Not ObjFAQModulo.Buscar(LblCodFAQ.Text, codigo) Then
                    ObjFAQModulo.SetConteudo("cod_faq", LblCodFAQ.Text)
                    ObjFAQModulo.SetConteudo("cod_modulo", codigo)
                    ObjFAQModulo.Incluir()
                    SqlDataSource2.Select(DataSourceSelectArguments.Empty)
                    SqlDataSource2.DataBind()
                    GridView2.DataBind()
                Else
                    LblErro.Text = "Módulo selecionado já foi vinculado."
                End If
            Else
                LblErro.Text = "Selecione o módulo a ser vinculado."
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Protected Sub BtnAddRotina_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnAddRotina.Click
        Try
            If Session("SAcao") = "INCLUIR" Then
                LblErro.Text = "Não é possível vincular rotina antes de incluir a FAQ."
                Return
            End If
            Dim ObjFAQRotina As New UCLFAQRotina
            Dim codigo As String = DdlRotina.SelectedValue
            If codigo > "0" Then
                If Not ObjFAQRotina.Buscar(LblCodFAQ.Text, codigo) Then
                    ObjFAQRotina.SetConteudo("cod_faq", LblCodFAQ.Text)
                    ObjFAQRotina.SetConteudo("cod_rotina", codigo)
                    ObjFAQRotina.Incluir()
                    SqlDataSource3.Select(DataSourceSelectArguments.Empty)
                    SqlDataSource3.DataBind()
                    GridView3.DataBind()
                Else
                    LblErro.Text = "Rotina selecionada já foi vinculada."
                End If
            Else
                LblErro.Text = "Selecione a rotina a ser vinculada."
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "EXCLUIR" Then
            Dim ObjFAQSistema As New UCLFAQSistema
            Dim codigo As String = e.CommandArgument
            ObjFAQSistema.Excluir(LblCodFAQ.Text, codigo)
            SqlDataSource1.Select(DataSourceSelectArguments.Empty)
            SqlDataSource1.DataBind()
            GridView1.DataBind()
        End If
    End Sub

    Private Sub GridView2_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView2.RowCommand
        If e.CommandName = "EXCLUIR" Then
            Dim ObjFAQModulo As New UCLFAQModulo
            Dim codigo As String = e.CommandArgument
            ObjFAQModulo.Excluir(LblCodFAQ.Text, codigo)
            SqlDataSource2.Select(DataSourceSelectArguments.Empty)
            SqlDataSource2.DataBind()
            GridView2.DataBind()
        End If
    End Sub

    Private Sub GridView3_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView3.RowCommand
        If e.CommandName = "EXCLUIR" Then
            Dim ObjFAQRotina As New UCLFAQRotina
            Dim codigo As String = e.CommandArgument
            ObjFAQRotina.Excluir(LblCodFAQ.Text, codigo)
            SqlDataSource3.Select(DataSourceSelectArguments.Empty)
            SqlDataSource3.DataBind()
            GridView3.DataBind()
        End If
    End Sub

    Protected Sub DdlSistema_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DdlSistema.SelectedIndexChanged
        Try
            Dim ObjModulo As New UCLModulo
            ObjModulo.FillDropDown(DdlModulo, True, " (selecionar) ", DdlSistema.SelectedValue)
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub
End Class