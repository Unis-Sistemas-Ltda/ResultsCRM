Public Partial Class WUCClienteFinanceiro
    Inherits System.Web.UI.UserControl

    Private _CodEmitente As String
    Private _Embeeded As String
    Private _VarCodEmitente As String
    Private _VarCodEmitentePesquisado As String
    Private _VarAlterouCodCliente As String
    Private _VarRecarregaDdlContatos As String
    Private _VarCodContatoNegociacao As String
    Private _VarCNPJEmitente As String
    Private _VarCodEmitenteNegociacao As String

    Public Property VarCodEmitente() As String
        Get
            Return _VarCodEmitente
        End Get
        Set(ByVal value As String)
            _VarCodEmitente = value
        End Set
    End Property

    Public Property VarCodEmitentePesquisado() As String
        Get
            Return _VarCodEmitentePesquisado
        End Get
        Set(ByVal value As String)
            _VarCodEmitentePesquisado = value
        End Set
    End Property

    Public Property VarAlterouCodCliente() As String
        Get
            Return _VarAlterouCodCliente
        End Get
        Set(ByVal value As String)
            _VarAlterouCodCliente = value
        End Set
    End Property

    Public Property VarRecarregaDdlContatos() As String
        Get
            Return _VarRecarregaDdlContatos
        End Get
        Set(ByVal value As String)
            _VarRecarregaDdlContatos = value
        End Set
    End Property

    Public Property VarCodContatoNegociacao() As String
        Get
            Return _VarCodContatoNegociacao
        End Get
        Set(ByVal value As String)
            _VarCodContatoNegociacao = value
        End Set
    End Property

    Public Property VarCNPJEmitente() As String
        Get
            Return _VarCNPJEmitente
        End Get
        Set(ByVal value As String)
            _VarCNPJEmitente = value
        End Set
    End Property

    Public Property VarCodEmitenteNegociacao() As String
        Get
            Return _VarCodEmitenteNegociacao
        End Get
        Set(ByVal value As String)
            _VarCodEmitenteNegociacao = value
        End Set
    End Property

    Public Property Embeeded() As Boolean
        Get
            Return _Embeeded
        End Get
        Set(ByVal value As Boolean)
            _Embeeded = value
        End Set
    End Property

    Public Property CodEmitente() As String
        Get
            Return _CodEmitente
        End Get
        Set(ByVal value As String)
            _CodEmitente = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Call CarregaDropDowns()
            Call CarregaFormulario()
        Else
            Call ChecaPesquisaClienteAtendimento()
            Call ChecaPesquisaPontoAtendimento()
        End If
        If Embeeded Then
            BtnConcluir.Visible = True
            BtnVoltar.Visible = True
            BtnGravar.Visible = False
        Else
            BtnConcluir.Visible = False
            BtnVoltar.Visible = False
            BtnGravar.Visible = True
        End If

        If Session("GlBloquearCadastroEmitenteRepresentante") = "S" Then
            BtnConcluir.Visible = False
            BtnGravar.Visible = False
        End If
        Call MostraNomeClienteAtendimento()
    End Sub

    Private Sub CarregaFormulario()
        Dim ObjClienteFinanceiro As New UCLClienteFinanceiro

        ObjClienteFinanceiro.Empresa = Session("GlEmpresa")
        ObjClienteFinanceiro.CodEmitente = CodEmitente
        ObjClienteFinanceiro.Buscar()

        DdlGrupo.SelectedValue = ObjClienteFinanceiro.CodGrupo
        DdlRepresentante.SelectedValue = ObjClienteFinanceiro.CodRepresentante
        DdlCanalVenda.SelectedValue = ObjClienteFinanceiro.CodCanalVenda
        DdlCondicaoPagamento.SelectedValue = ObjClienteFinanceiro.CodCondPagto
        DdlFormaPagamento.SelectedValue = ObjClienteFinanceiro.CodFormaPagto
        DdlNatureza.SelectedValue = ObjClienteFinanceiro.CodNaturOper
        DdlNaturezaServicos.SelectedValue = ObjClienteFinanceiro.CodNaturOperServico
        DdlTipoFrete.SelectedValue = ObjClienteFinanceiro.TipoFrete
        DdlCarteiraBancaria.SelectedValue = ObjClienteFinanceiro.CodCarteira
        DdlPortador.SelectedValue = ObjClienteFinanceiro.CodPortador
        DdlBanco.SelectedValue = ObjClienteFinanceiro.CodBanco
        If Not String.IsNullOrEmpty(ObjClienteFinanceiro.CodParceiro) Then
            DdlParceiro.SelectedValue = ObjClienteFinanceiro.CodParceiro
        End If
        If Not String.IsNullOrEmpty(ObjClienteFinanceiro.CodProvedorTef) Then
            DdlProvedorTEF.SelectedValue = ObjClienteFinanceiro.CodProvedorTef
        End If
        If Not String.IsNullOrEmpty(ObjClienteFinanceiro.CodAdquirenteTef) Then
            DdlAdquirentePrincipal.SelectedValue = ObjClienteFinanceiro.CodAdquirenteTef
        End If
        If Not String.IsNullOrEmpty(ObjClienteFinanceiro.CodDistribuidor) Then
            DdlDistribuidor.SelectedValue = ObjClienteFinanceiro.CodDistribuidor
        End If
        TxtRepasse.Text = ObjClienteFinanceiro.ValorRepasseParceiro
        TxtAdesao.Text = ObjClienteFinanceiro.ValorRepasseParceiroAdesao
        If Session("GlTipoAcesso") = UCLUsuario.TipoAcesso.Representante Then
            If DdlRepresentante.SelectedValue Is Nothing OrElse String.IsNullOrWhiteSpace(DdlRepresentante.SelectedValue) OrElse DdlRepresentante.SelectedValue <= 0 Then
                DdlRepresentante.SelectedValue = Session("GlCodEmitenteExterno")
            End If
            DdlRepresentante.Enabled = False
        End If
        If Session("GlBloquearCadastroEmitenteRepresentante") = "S" Then
            BtnConcluir.Visible = False
            BtnGravar.Visible = False
        End If
        TxtClienteAtendimento.Text = ObjClienteFinanceiro.CodEmitenteAtendimentoPadrao
        TxtNrPontoAtendimento.Text = ObjClienteFinanceiro.NumeroPontoAtendimentoPadrao

        If Session("GlTipoAcesso") = UCLUsuario.TipoAcesso.Regional Then
            DdlGrupo.Enabled = False
            DdlRepresentante.Enabled = False
            DdlCanalVenda.Enabled = False
            DdlCondicaoPagamento.Enabled = False
            DdlFormaPagamento.Enabled = False
            DdlNatureza.Enabled = False
            DdlNaturezaServicos.Enabled = False
            DdlTipoFrete.Enabled = False
            DdlCarteiraBancaria.Enabled = False
            DdlPortador.Enabled = False
            DdlBanco.Enabled = False
            DdlParceiro.Enabled = False
            DdlProvedorTEF.Enabled = False
            DdlAdquirentePrincipal.Enabled = False
            TxtRepasse.Enabled = False
            TxtAdesao.Enabled = False
            DdlRepresentante.Enabled = False
        End If
    End Sub

    Private Sub CarregaDropDowns()
        Call CarregaGruposClienteFinanceiro()
        Call CarregaRepresentantes()
        Call CarregaCanaisVenda()
        Call CarregaCondicoesPagto()
        Call CarregaFormasPagto()
        Call CarregaNaturezasOperacao()
        Call CarregaCarteirasBancarias()
        Call CarregaPortadores()
        Call CarregaBancos()
        Call CarregaAdquirentesTEF()
        Call CarregaParceiros()
        Call CarregaProvedoresTEF()
        Call CarregaDistribuidores()
    End Sub

    Private Sub CarregaRepresentantes()
        Dim objEmitente As New UCLEmitente(StrConexaoUsuario(Session("GlUsuario")))
        objEmitente.FillDropDown(DdlRepresentante, True, "", UCLEmitente.TipoEmitenteDDL.Representante, 0, True, UCLEmitente.TipoExibicaoDDL.Nome, Session("GlCodGestor"))
    End Sub

    Private Sub CarregaParceiros()
        Dim objEmitente As New UCLEmitente(StrConexaoUsuario(Session("GlUsuario")))
        objEmitente.FillDropDown(DdlParceiro, True, "", UCLEmitente.TipoEmitenteDDL.Parceiro, 0, True, UCLEmitente.TipoExibicaoDDL.NomeAbreviado, "")
    End Sub

    Private Sub CarregaDistribuidores()
        Dim objEmitente As New UCLEmitente(StrConexaoUsuario(Session("GlUsuario")))
        objEmitente.FillDropDown(DdlDistribuidor, True, "", UCLEmitente.TipoEmitenteDDL.Distribuidor, 0, True, UCLEmitente.TipoExibicaoDDL.NomeAbreviado, "")
    End Sub


    Private Sub CarregaAdquirentesTEF()
        Dim objEmitente As New UCLEmitente(StrConexaoUsuario(Session("GlUsuario")))
        objEmitente.FillDropDown(DdlAdquirentePrincipal, True, "", UCLEmitente.TipoEmitenteDDL.AdquirenteTEF, 0, True, UCLEmitente.TipoExibicaoDDL.NomeAbreviado, "")
    End Sub

    Private Sub CarregaProvedoresTEF()
        Dim objEmitente As New UCLEmitente(StrConexaoUsuario(Session("GlUsuario")))
        objEmitente.FillDropDown(DdlProvedorTEF, True, "", UCLEmitente.TipoEmitenteDDL.ProvedorTEF, 0, True, UCLEmitente.TipoExibicaoDDL.NomeAbreviado, "")
    End Sub

    Private Sub CarregaGruposClienteFinanceiro()
        Dim objGrupoClienteFinanceiro As New UCLGrupoClienteFinanceiro
        objGrupoClienteFinanceiro.Empresa = Session("GlEmpresa")
        objGrupoClienteFinanceiro.FillDropDown(DdlGrupo, True, "")
    End Sub

    Private Sub CarregaCanaisVenda()
        Dim objCanalVenda As New UCLCanalVenda
        objCanalVenda.Empresa = Session("GlEmpresa")
        objCanalVenda.FillControl(DdlCanalVenda, True, "")
    End Sub

    Private Sub CarregaCondicoesPagto()
        Dim objCondicaoPagto As New UCLCondicaoPagamento
        objCondicaoPagto.FillDropDown(DdlCondicaoPagamento, True, "")
    End Sub

    Private Sub CarregaFormasPagto()
        Dim objFormasPagto As New UCLFormaPagto
        objFormasPagto.FillDropDown(DdlFormaPagamento, True, "")
    End Sub

    Private Sub CarregaNaturezasOperacao()
        Dim objNaturezaOperacao As New UCLNaturezaOperacao
        objNaturezaOperacao.FillDropDown(DdlNatureza, True, "")
        objNaturezaOperacao.FillDropDown(DdlNaturezaServicos, True, "")
    End Sub

    Private Sub CarregaCarteirasBancarias()
        Dim objCarteiraBancaria As New UCLCarteiraBancaria
        objCarteiraBancaria.Empresa = Session("GlEmpresa")
        objCarteiraBancaria.FillDropDown(DdlCarteiraBancaria, True, "")
    End Sub

    Private Sub CarregaPortadores()
        Dim objPortador As New UCLPortador
        objPortador.Empresa = Session("GlEmpresa")
        objPortador.FillDropDown(DdlPortador, True, "")
    End Sub

    Private Sub CarregaBancos()
        Dim objBanco As New UCLBanco
        objBanco.FillDropDown(DdlBanco, True, "")
    End Sub

    Private Function Gravar() As Boolean
        Dim ObjClienteFinanceiro As New UCLClienteFinanceiro
        Try
            ObjClienteFinanceiro.CodEmitente = CodEmitente
            ObjClienteFinanceiro.Empresa = Session("GlEmpresa")
            ObjClienteFinanceiro.Buscar()
            ObjClienteFinanceiro = CarregaObjeto(ObjClienteFinanceiro)
            ObjClienteFinanceiro.Gravar()
            LblErro.Text = "Os dados foram salvos com sucesso."
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
        Try
            Call Gravar()
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Protected Function CarregaObjeto(ByRef ObjClienteFinanceiro As UCLClienteFinanceiro) As UCLClienteFinanceiro
        ObjClienteFinanceiro.CodGrupo = DdlGrupo.SelectedValue
        ObjClienteFinanceiro.CodRepresentante = DdlRepresentante.SelectedValue
        ObjClienteFinanceiro.CodCanalVenda = DdlCanalVenda.SelectedValue
        ObjClienteFinanceiro.CodCondPagto = DdlCondicaoPagamento.SelectedValue
        ObjClienteFinanceiro.CodFormaPagto = DdlFormaPagamento.SelectedValue
        ObjClienteFinanceiro.CodNaturOper = DdlNatureza.SelectedValue
        ObjClienteFinanceiro.CodNaturOperServico = DdlNaturezaServicos.SelectedValue
        ObjClienteFinanceiro.TipoFrete = DdlTipoFrete.SelectedValue
        ObjClienteFinanceiro.CodCarteira = DdlCarteiraBancaria.SelectedValue
        ObjClienteFinanceiro.CodPortador = DdlPortador.SelectedValue
        ObjClienteFinanceiro.CodBanco = DdlBanco.SelectedValue
        ObjClienteFinanceiro.CodParceiro = DdlParceiro.SelectedValue
        ObjClienteFinanceiro.CodDistribuidor = DdlDistribuidor.SelectedValue
        ObjClienteFinanceiro.CodProvedorTef = DdlProvedorTEF.SelectedValue
        ObjClienteFinanceiro.CodAdquirenteTef = DdlAdquirentePrincipal.SelectedValue
        ObjClienteFinanceiro.ValorRepasseParceiro = TxtRepasse.Text
        ObjClienteFinanceiro.ValorRepasseParceiroAdesao = TxtAdesao.Text
        ObjClienteFinanceiro.CodEmitenteAtendimentoPadrao = TxtClienteAtendimento.Text
        ObjClienteFinanceiro.NumeroPontoAtendimentoPadrao = TxtNrPontoAtendimento.Text
        Return ObjClienteFinanceiro
    End Function

    Protected Sub BtnConcluir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnConcluir.Click
        Try
            If Session("GlTipoAcesso") = UCLUsuario.TipoAcesso.Regional Then
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "onload", "onSuccess();", True)
            Else
                If Gravar() Then
                    Page.ClientScript.RegisterStartupScript(Me.GetType(), "onload", "onSuccess();", True)
                End If
            End If

        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Protected Sub BtnVoltar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnVoltar.Click
        If Session("SPulaCNPJCadastro") = "S" Then
            Response.Redirect("WFClienteEmbeeded.aspx?vcodemi=" + VarCodEmitente + "&vcodemp=" + VarCodEmitentePesquisado + "&valtecc=" + VarAlterouCodCliente + "&vrecdc=" + VarRecarregaDdlContatos + "&ccodcon=" + VarCodContatoNegociacao + "&cnpjemi=" + VarCNPJEmitente + "&vcodemin=" + VarCodEmitenteNegociacao)
        Else
            Response.Redirect("WFClienteCNPJ.aspx?embeeded=" & Embeeded & "&vcodemi=" + VarCodEmitente + "&vcodemp=" + VarCodEmitentePesquisado + "&valtecc=" + VarAlterouCodCliente + "&vrecdc=" + VarRecarregaDdlContatos + "&ccodcon=" + VarCodContatoNegociacao + "&cnpjemi=" + VarCNPJEmitente + "&vcodemin=" + VarCodEmitenteNegociacao)
        End If
    End Sub

    Protected Sub btnOkay_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnOkay.Click
        Try
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "onload", "onSuccess();", True)
        Catch ex As Exception
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "onload", "onError();", True)
        End Try
    End Sub

    Private Sub ChecaPesquisaPontoAtendimento()
        Try
            Dim PontoPesquisado As String
            Dim alterouPontoAtendimento As Long

            If Not String.IsNullOrEmpty(Session("SAlterouNumeroPontoAtendimento")) Then
                alterouPontoAtendimento = Session("SAlterouNumeroPontoAtendimento")
            Else
                alterouPontoAtendimento = 0
            End If

            PontoPesquisado = Session("SPontoPesquisado")

            If Not String.IsNullOrEmpty(PontoPesquisado) Then
                If alterouPontoAtendimento > 0 Then
                    If TxtNrPontoAtendimento.Text <> PontoPesquisado Then
                        TxtNrPontoAtendimento.Text = PontoPesquisado
                        Call NrPontoAtendimentoMudou()
                    End If
                    Session("SAlterouNumeroPontoAtendimento") = alterouPontoAtendimento - 2
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ChecaPesquisaClienteAtendimento()
        Try
            Dim CodClientePesquisado As String
            Dim cnpjPesquisado As String
            Dim alterouCliente As Long

            If Not String.IsNullOrEmpty(Session("SAlterouCodClienteAt")) Then
                alterouCliente = Session("SAlterouCodClienteAt")
            Else
                alterouCliente = 0
            End If

            CodClientePesquisado = Session("SCodClienteAtPesquisado")
            cnpjPesquisado = Session("SCNPJAtPesquisado")

            If Not String.IsNullOrEmpty(CodClientePesquisado) Then
                If alterouCliente > 0 Then
                    If TxtClienteAtendimento.Text <> CodClientePesquisado Then
                        TxtClienteAtendimento.Text = CodClientePesquisado
                        Call CodigoClienteAtendimentoMudou()
                    End If
                    Session("SAlterouCodClienteAt") = alterouCliente - 2
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub CodigoClienteAtendimentoMudou()
        Dim objEmitente As New UCLEmitente(StrConexaoUsuario(Session("GlUsuario")))

        Session("SCodEmitenteAtNegociacao") = TxtClienteAtendimento.Text
        Session("SCodClienteAtPesquisado") = TxtClienteAtendimento.Text

        Call NrPontoAtendimentoMudou()

    End Sub

    Private Sub NrPontoAtendimentoMudou()
        Try
            'Necessário para que a alteração de emitente funcione via tela da negociação, não retirar
            Session("SPontoAtendimento") = TxtNrPontoAtendimento.Text
            Session("SPontoPesquisado") = TxtNrPontoAtendimento.Text
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub TxtClienteAtendimento_TextChanged(sender As Object, e As EventArgs) Handles TxtClienteAtendimento.TextChanged
        Call CodigoClienteAtendimentoMudou()
    End Sub

    Protected Sub TxtNrPontoAtendimento_TextChanged(sender As Object, e As EventArgs) Handles TxtNrPontoAtendimento.TextChanged
        Call NrPontoAtendimentoMudou()
    End Sub

    Private Sub MostraNomeClienteAtendimento()
        Try
            Dim objPontoAtendimento As New UCLPontoAtendimento(StrConexaoUsuario(Session("GlUsuario")))
            Dim objEmitente As New UCLEmitente(StrConexaoUsuario(Session("GlUsuario")))
            Dim objTipoPontoAtendimento As New UCLTipoPontoAtendimento
            If Not String.IsNullOrEmpty(TxtClienteAtendimento.Text) Then
                objPontoAtendimento.CodEmitente = TxtClienteAtendimento.Text
                objPontoAtendimento.NumeroPontoAtendimento = TxtNrPontoAtendimento.Text

                If Not String.IsNullOrEmpty(objPontoAtendimento.CodEmitente) Then
                    objEmitente.CodEmitente = objPontoAtendimento.CodEmitente
                    objEmitente.Buscar()
                    LblRazaoSocialPontoAtendimento.Text = objEmitente.Nome
                End If

                If Not String.IsNullOrEmpty(objPontoAtendimento.CodEmitente) AndAlso Not String.IsNullOrEmpty(objPontoAtendimento.NumeroPontoAtendimento) Then
                    objPontoAtendimento.Buscar()

                    objTipoPontoAtendimento.CodTipoPontoAtendimento = objPontoAtendimento.CodTipoPontoAtendimento
                    If Not String.IsNullOrEmpty(objTipoPontoAtendimento.CodTipoPontoAtendimento) Then
                        objTipoPontoAtendimento.Buscar()
                    End If

                    LblNomePontoAtendimento.Text = objTipoPontoAtendimento.Descricao + "  " + objPontoAtendimento.NumeroPontoAtendimento + " ─ " + objPontoAtendimento.Descricao
                End If
            Else
                LblNomePontoAtendimento.Text = ""
                LblRazaoSocialPontoAtendimento.Text = ""
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class