Partial Public Class WUCNegociacaoItem_Farmacos2FD
    Inherits System.Web.UI.UserControl

    Private _Acao As String
    Private _CodNegociacao As String
    Private _SeqItem As String

    Public Property Acao() As String
        Get
            Return _Acao
        End Get
        Set(ByVal value As String)
            _Acao = value
        End Set
    End Property

    Public Property CodNegociacao() As String
        Get
            Return _CodNegociacao
        End Get
        Set(ByVal value As String)
            _CodNegociacao = value
        End Set
    End Property

    Public Property SeqItem() As String
        Get
            Return _SeqItem
        End Get
        Set(ByVal value As String)
            _SeqItem = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then

                If Acao = "ALTERAR" Then
                    Call CarregaFormulario()
                Else
                    Call NovoRegistro()
                End If
            End If

            If Not String.IsNullOrEmpty(Session("SCodItemPesquisado")) Then
                If Session("SAlterouCodItem") = "S" Then
                    If TxtCodItem.Text <> Session("SCodItemPesquisado") Then
                        TxtCodItem.Text = Session("SCodItemPesquisado")
                        CodItemMudou()
                    End If
                    Session("SAlterouCodItem") = "N"
                End If
            End If

            Call CarregaDescricaoItem()

        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Private Sub NovoRegistro()
        Try
            Call CarregaNovaPK()
            Dim objNegociacao As New UCLNegociacao(StrConexaoUsuario(Session("GlUsuario")))
            Dim objCond As New UCLCondicaoPagamento
            objNegociacao.Empresa = Session("GlEmpresa")
            objNegociacao.Estabelecimento = Session("SEstabelecimentoNegociacao")
            objNegociacao.CodNegociacao = CodNegociacao
            objNegociacao.Buscar()
            objCond.Codigo = objNegociacao.CodCondPagto
            objCond.Buscar()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaNovaPK()
        Dim objNegociacao As New UCLNegociacao(StrConexaoUsuario(Session("GlUsuario")))
        Dim objNegociacaoItem As New UCLNegociacaoItem(StrConexaoUsuario(Session("GlUsuario")))
        objNegociacaoItem.Empresa = Session("GlEmpresa")
        objNegociacaoItem.Estabelecimento = Session("SEstabelecimentoNegociacao")
        objNegociacaoItem.CodNegociacao = CodNegociacao
        LblSeqItem.Text = objNegociacaoItem.GetProximoCodigo

        objNegociacao.Empresa = Session("GlEmpresa")
        objNegociacao.Estabelecimento = Session("SEstabelecimentoNegociacao")
        objNegociacao.CodNegociacao = CodNegociacao
        objNegociacao.Buscar()
    End Sub


    Private Sub CodItemMudou()
        Try
            Dim objItem As New UCLItem

            Dim CodUD As String
            Call CarregaDescricaoItem()

            If Not String.IsNullOrEmpty(TxtCodItem.Text) Then
                Session("SCodItemPesquisado") = TxtCodItem.Text
                objItem.CodItem = TxtCodItem.Text
                objItem.Buscar()
                CodUD = objItem.CodUd
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub TxtCodItem_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TxtCodItem.TextChanged
        Try
            Call CodItemMudou()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaDescricaoItem()
        Try
            Dim objItem As New UCLItem
            If Not String.IsNullOrEmpty(TxtCodItem.Text) Then
                objItem.CodItem = TxtCodItem.Text
                objItem.Buscar()
                LblDescricaoItem.Text = objItem.Descricao
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function IsDigitacaoOK()
        If String.IsNullOrEmpty(TxtCodItem.Text) Then
            LblErro.Text += "Preencha o campo Item.<br/>"
        End If

        Return LblErro.Text = ""
    End Function

    Private Function CarregaObjeto(ByRef objNegociacaoItem As UCLNegociacaoItem) As UCLNegociacaoItem

        objNegociacaoItem.CodItem = TxtCodItem.Text.GetValidInputContent

        objNegociacaoItem.FdAcaoDesejadaFuncao = TxtFdAcaoDesejadaProduto.Text
        If DdlFdColoracao.SelectedValue > 0 Then
            objNegociacaoItem.FdColoracao = DdlFdColoracao.SelectedValue
        End If
        If DdlFdOdor.SelectedValue > 0 Then
            objNegociacaoItem.FdOdor = DdlFdOdor.SelectedValue
        End If
        If DdlFdOdorDirecionamento.SelectedValue > 0 Then
            objNegociacaoItem.FdOdorDirecionamento = DdlFdOdorDirecionamento.SelectedValue
        End If
        objNegociacaoItem.FdCorReferencia = TxtFdCorReferencia.Text
        objNegociacaoItem.FdDescricaoProduto = TxtFdDescricaoProduto.Text
        objNegociacaoItem.FdNomeProduto = TxtFdNomeProduto.Text
        objNegociacaoItem.FdOdorReferencia = TxtFdOdorReferencia.Text

        '------
        objNegociacaoItem.FdProdutoReferencia = TxtFdProdutoReferencia.Text
        objNegociacaoItem.FdVolumeEmbalagem = TxtFdVolumeEmbalagem.Text
        objNegociacaoItem.FdCorEmbalagem = DdlFdCorEmbalagem.SelectedValue
        objNegociacaoItem.FdMpEmbalagem = DdlFdMpEmbalagem.SelectedValue
        objNegociacaoItem.FdTipoEmbalagem = DdlFdTipoEmbalagem.SelectedValue
        objNegociacaoItem.FdQtdProduzir = DdlFdQtdProduzir.SelectedValue
        '------

        Return objNegociacaoItem
    End Function

    Protected Sub BtnGravar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
        Dim objNegociacaoItem As New UCLNegociacaoItem(StrConexaoUsuario(Session("GlUsuario")))
        Try
            If IsDigitacaoOK() Then
                If Acao = "ALTERAR" Then
                    objNegociacaoItem.CodNegociacao = CodNegociacao
                    objNegociacaoItem.SeqItem = SeqItem
                    objNegociacaoItem.Empresa = Session("GlEmpresa")
                    objNegociacaoItem.Estabelecimento = Session("SEstabelecimentoNegociacao")
                    objNegociacaoItem.Buscar()
                    objNegociacaoItem = CarregaObjeto(objNegociacaoItem)
                    objNegociacaoItem.Alterar()
                ElseIf Acao = "INCLUIR" Then
                    Call CarregaNovaPK()
                    objNegociacaoItem.CodNegociacao = CodNegociacao
                    objNegociacaoItem.SeqItem = LblSeqItem.Text
                    objNegociacaoItem.Empresa = Session("GlEmpresa")
                    objNegociacaoItem.Estabelecimento = Session("SEstabelecimentoNegociacao")
                    objNegociacaoItem.Buscar()
                    objNegociacaoItem = CarregaObjeto(objNegociacaoItem)
                    objNegociacaoItem.Incluir()
                End If

                Response.Redirect("WGNegociacaoItem.aspx")
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub


    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Response.Redirect("WGNegociacaoItem.aspx")
    End Sub

    Protected Sub CarregaFormulario()
        Dim objNegociacaoItem As New UCLNegociacaoItem(StrConexaoUsuario(Session("GlUsuario")))
        Dim objItem As New UCLItem
        Dim CodUD As String
        objNegociacaoItem.Empresa = Session("GlEmpresa")
        objNegociacaoItem.Estabelecimento = Session("SEstabelecimentoNegociacao")
        objNegociacaoItem.CodNegociacao = CodNegociacao
        objNegociacaoItem.SeqItem = SeqItem
        objNegociacaoItem.Buscar()
        LblSeqItem.Text = objNegociacaoItem.SeqItem
        TxtCodItem.Text = objNegociacaoItem.CodItem

        objItem.CodItem = TxtCodItem.Text
        objItem.Buscar()
        CodUD = objItem.CodUd

        DdlFdColoracao.SelectedValue = objNegociacaoItem.FdColoracao
        DdlFdOdor.SelectedValue = objNegociacaoItem.FdOdor
        DdlFdOdorDirecionamento.SelectedValue = objNegociacaoItem.FdOdorDirecionamento
        TxtFdAcaoDesejadaProduto.Text = objNegociacaoItem.FdAcaoDesejadaFuncao
        TxtFdCorReferencia.Text = objNegociacaoItem.FdCorReferencia
        TxtFdDescricaoProduto.Text = objNegociacaoItem.FdDescricaoProduto
        TxtFdNomeProduto.Text = objNegociacaoItem.FdNomeProduto
        TxtFdOdorReferencia.Text = objNegociacaoItem.FdOdorReferencia

        TxtFdProdutoReferencia.Text = objNegociacaoItem.FdProdutoReferencia
        TxtFdVolumeEmbalagem.Text = objNegociacaoItem.FdVolumeEmbalagem
        DdlFdCorEmbalagem.SelectedValue = objNegociacaoItem.FdCorEmbalagem
        DdlFdMpEmbalagem.SelectedValue = objNegociacaoItem.FdMpEmbalagem
        DdlFdTipoEmbalagem.SelectedValue = objNegociacaoItem.FdTipoEmbalagem
        DdlFdQtdProduzir.SelectedValue = objNegociacaoItem.FdQtdProduzir


    End Sub






End Class