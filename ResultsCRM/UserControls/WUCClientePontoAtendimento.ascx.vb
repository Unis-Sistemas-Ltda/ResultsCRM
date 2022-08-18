Partial Public Class WUCClientePontoAtendimento
    Inherits System.Web.UI.UserControl

    Private _CodEmitente As String
    Private _Embeeded As String
    Private _NumeroPontoAtendimento As String
    Private _Acao As String
    Private _VarCodEmitente As String
    Private _VarCodEmitentePesquisado As String
    Private _VarAlterouPontoAtendimento As String
    Private _VarRecarregaDdlContatos As String
    Private _VarCodContatoNegociacao As String
    Private _VarPtoAtEmitentePesquisado As String
    Private _VarCodEmitenteNegociacao As String

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

    Public Property NumeroPontoAtendimento() As String
        Get
            Return _NumeroPontoAtendimento
        End Get
        Set(ByVal value As String)
            _NumeroPontoAtendimento = value
        End Set
    End Property

    Public Property Acao() As String
        Get
            Return _Acao
        End Get
        Set(ByVal value As String)
            _Acao = value
        End Set
    End Property

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

    Public Property VarCodEmitenteNegociacao() As String
        Get
            Return _VarCodEmitenteNegociacao
        End Get
        Set(ByVal value As String)
            _VarCodEmitenteNegociacao = value
        End Set
    End Property

    Public Property VarAlterouPontoAtendimento() As String
        Get
            Return _VarAlterouPontoAtendimento
        End Get
        Set(ByVal value As String)
            _VarAlterouPontoAtendimento = value
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

    Public Property VarPtoAtEmitentePesquisado() As String
        Get
            Return _VarPtoAtEmitentePesquisado
        End Get
        Set(ByVal value As String)
            _VarPtoAtEmitentePesquisado = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Call CarregaTipoPontoAtendimento()
            If Acao = "ALTERAR" Then
                Call CarregaFormulario()
            ElseIf Acao = "INCLUIR" Then
                Call CarregaPais()
            End If
        End If

        If Not Embeeded Then
            BtnVoltar.Visible = False
        End If

        If Session("GlBloquearCadastroEmitenteRepresentante") = "S" Then
            BtnGravar.Visible = False
        End If

    End Sub

    Private Sub CarregaFormulario()
        Dim ObjPontoAtendimento As New UCLPontoAtendimento(StrConexaoUsuario(Session("GlUsuario")))
        Dim ObjUsuario As New UCLUsuario

        ObjPontoAtendimento.CodEmitente = CodEmitente
        ObjPontoAtendimento.NumeroPontoAtendimento = NumeroPontoAtendimento
        ObjPontoAtendimento.Buscar()

        TxtCNPJ.Text = ObjPontoAtendimento.CNPJ
        TxtDescricao.Text = ObjPontoAtendimento.Descricao
        ChkPreferencial.Checked = ObjPontoAtendimento.Preferencial.ToString.Replace("S", "True").Replace("N", "False")
        ChkAtivo.Checked = ObjPontoAtendimento.Ativo.ToString.Replace("S", "True").Replace("N", "False")
        TxtLogradouro.Text = ObjPontoAtendimento.Logradouro
        TxtNumero.Text = ObjPontoAtendimento.Numero
        TxtCEP.Text = ObjPontoAtendimento.CEP
        TxtFone1.Text = ObjPontoAtendimento.Fone1
        TxtFone2.Text = ObjPontoAtendimento.Fone2
        TxtFax.Text = ObjPontoAtendimento.Fax
        TxtBairro.Text = ObjPontoAtendimento.Bairro
        TxtEmail.Text = ObjPontoAtendimento.Email
        TxtObservacao.Text = ObjPontoAtendimento.Observacao
        TxtHorarioFuncionamentoInicio.Text = ObjPontoAtendimento.HorarioFuncionamentoInicio
        TxtHorarioFuncionamentoFim.Text = ObjPontoAtendimento.HorarioFuncionamentoFim

        If ObjPontoAtendimento.ExigeIntegracao = "S" Then
            CbxExigeIntegracao.Checked = True
        Else
            CbxExigeIntegracao.Checked = False
        End If

        If Not String.IsNullOrEmpty(ObjPontoAtendimento.CodTipoPontoAtendimento) Then
            DdlTipoPontoAtendimento.SelectedValue = ObjPontoAtendimento.CodTipoPontoAtendimento
        Else
            DdlTipoPontoAtendimento.SelectedValue = "0"
        End If

        TxtNrPontoAtendimento.Text = ObjPontoAtendimento.NumeroPontoAtendimento
        TxtNrPontoAtendimento.Enabled = False
        TxtNrUniorg.Text = ObjPontoAtendimento.NumeroUniorg

        Call CarregaPais()
        If DdlPais.Items.FindByValue(ObjPontoAtendimento.CodPais) IsNot Nothing Then
            DdlPais.SelectedValue = ObjPontoAtendimento.CodPais

            Call CarregaEstado()
            If DdlEstado.Items.FindByValue(ObjPontoAtendimento.CodEstado) IsNot Nothing Then
                DdlEstado.SelectedValue = ObjPontoAtendimento.CodEstado

                Call CarregaCidade()
                If DdlCidade.Items.FindByValue(ObjPontoAtendimento.CodCidade) IsNot Nothing Then
                    DdlCidade.SelectedValue = ObjPontoAtendimento.CodCidade
                Else
                    DdlCidade.SelectedValue = "0"
                End If
            Else
                DdlEstado.SelectedValue = "0"
            End If
        End If

        If Session("GlBloquearCadastroEmitenteRepresentante") = "S" Then
            BtnGravar.Visible = False
        End If

    End Sub

    Public Sub CarregaCidade()
        Dim objCidade As New UCLCidade

        objCidade.CodPais = DdlPais.SelectedValue
        objCidade.CodEstado = DdlEstado.SelectedValue
        objCidade.FillDropDown(DdlCidade, True, "")

    End Sub

    Public Sub CarregaEstado()
        Dim ObjEstado As New UCLEstado

        ObjEstado.CodPais = DdlPais.SelectedValue
        ObjEstado.FillDropDown(DdlEstado, True, "", UCLEstado.Tipo.Sigla)

    End Sub

    Public Sub CarregaPais()
        Dim ObjPais As New UCLPais

        ObjPais.FillDropDown(DdlPais, True, "")
    End Sub

    Protected Sub DdlPais_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DdlPais.SelectedIndexChanged
        Call CarregaEstado()
        DdlEstado.SelectedValue = "0"
        Call CarregaCidade()
        DdlEstado.SelectedValue = "0"
    End Sub

    Protected Sub DdlEstado_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DdlEstado.SelectedIndexChanged
        Call CarregaCidade()
        DdlCidade.SelectedValue = "0"
    End Sub

    Private Function Gravar() As Boolean
        Dim ObjPontoAtendimento As New UCLPontoAtendimento(StrConexaoUsuario(Session("GlUsuario")))
        Try
            If IsDigitacaoOk() Then
                If Acao = "ALTERAR" Then
                    ObjPontoAtendimento.CodEmitente = CodEmitente
                    ObjPontoAtendimento.NumeroPontoAtendimento = NumeroPontoAtendimento
                    ObjPontoAtendimento.Buscar()
                    ObjPontoAtendimento = CarregaObjeto(ObjPontoAtendimento)
                    ObjPontoAtendimento.Alterar()
                    LblErro.Text = "Cadastro alterado com sucesso."
                ElseIf Acao = "INCLUIR" Then
                    ObjPontoAtendimento.CodEmitente = CodEmitente
                    ObjPontoAtendimento.NumeroPontoAtendimento = TxtNrPontoAtendimento.Text
                    ObjPontoAtendimento.Buscar()
                    ObjPontoAtendimento = CarregaObjeto(ObjPontoAtendimento)
                    ObjPontoAtendimento.Incluir()
                    Session("SAcaoCNPJ") = "ALTERAR"
                    Session("SNumeroPontoAtendimento") = TxtNrPontoAtendimento.Text
                    LblErro.Text = "Cadastro incluído com sucesso."
                End If
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Protected Sub BtnGravar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
        Try
            If Gravar() Then
                If Embeeded Then
                    If Acao = "INCLUIR" Then
                        Session(VarPtoAtEmitentePesquisado) = TxtNrPontoAtendimento.Text
                        Session(VarAlterouPontoAtendimento) = 1
                    End If
                    Page.ClientScript.RegisterStartupScript(Me.GetType(), "onload", "onSuccess();", True)
                End If
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Protected Function IsDigitacaoOk() As Boolean
        LblErro.Text = ""

        If String.IsNullOrEmpty(TxtNrPontoAtendimento.Text) Then
            LblErro.Text += "Preencha o campo Número do Ponto de Atendimento.<br/>"
        End If

        If String.IsNullOrEmpty(TxtDescricao.Text) Then
            LblErro.Text += "Preencha o campo Descrição.<br/>"
        End If

        If String.IsNullOrEmpty(TxtLogradouro.Text) Then
            LblErro.Text += "Preencha o campo Logradouro.<br/>"
        End If

        If DdlPais.Items.Count = 0 OrElse DdlPais.SelectedValue = "0" Then
            LblErro.Text += "Preencha o campo País.<br/>"
        End If

        If DdlEstado.Items.Count = 0 OrElse DdlEstado.SelectedValue = "0" Then
            LblErro.Text += "Preencha o campo Estado.<br/>"
        End If

        If DdlCidade.Items.Count = 0 OrElse DdlCidade.SelectedValue = "0" Then
            LblErro.Text += "Preencha o campo Cidade.<br/>"
        End If

        If Not String.IsNullOrEmpty(TxtEmail.Text) Then
            If Not TxtEmail.Text.Trim.IsValidEmail Then
                LblErro.Text += "Preencha corretamente o campo e-mail ou deixe-o em branco.<br/>"
            End If
        End If

        Return LblErro.Text.Trim = ""
    End Function

    Protected Function CarregaObjeto(ByRef ObjPontoAtendimento As UCLPontoAtendimento) As UCLPontoAtendimento

        ObjPontoAtendimento.Descricao = TxtDescricao.Text.GetValidInputContent
        ObjPontoAtendimento.Preferencial = ChkPreferencial.Checked.ToString.Replace("False", "N").Replace("True", "S")
        ObjPontoAtendimento.Ativo = ChkAtivo.Checked.ToString.Replace("False", "N").Replace("True", "S")
        ObjPontoAtendimento.Logradouro = TxtLogradouro.Text.GetValidInputContent
        ObjPontoAtendimento.Numero = TxtNumero.Text
        ObjPontoAtendimento.CEP = TxtCEP.Text.Replace("-", "").Replace(".", "")
        ObjPontoAtendimento.CNPJ = TxtCNPJ.Text.Replace("/", "").Replace("-", "").Replace(".", "")
        ObjPontoAtendimento.Fone1 = TxtFone1.Text
        ObjPontoAtendimento.Fone2 = TxtFone2.Text
        ObjPontoAtendimento.Fax = TxtFax.Text
        ObjPontoAtendimento.CodPais = DdlPais.SelectedValue
        ObjPontoAtendimento.CodEstado = DdlEstado.SelectedValue
        ObjPontoAtendimento.CodCidade = DdlCidade.SelectedValue
        ObjPontoAtendimento.Bairro = TxtBairro.Text.GetValidInputContent
        ObjPontoAtendimento.Email = TxtEmail.Text
        ObjPontoAtendimento.NumeroUniorg = TxtNrUniorg.Text
        ObjPontoAtendimento.Observacao = TxtObservacao.Text.GetValidInputContent
        If DdlTipoPontoAtendimento.SelectedValue = "0" Then
            ObjPontoAtendimento.CodTipoPontoAtendimento = ""
        Else
            ObjPontoAtendimento.CodTipoPontoAtendimento = DdlTipoPontoAtendimento.SelectedValue
        End If
        ObjPontoAtendimento.HorarioFuncionamentoInicio = TxtHorarioFuncionamentoInicio.Text
        ObjPontoAtendimento.HorarioFuncionamentoFim = TxtHorarioFuncionamentoFim.Text

        If CbxExigeIntegracao.Checked Then
            ObjPontoAtendimento.ExigeIntegracao = "S"
        Else
            ObjPontoAtendimento.ExigeIntegracao = "N"
        End If

        Return ObjPontoAtendimento
    End Function

    Protected Sub BtnVoltar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnVoltar.Click
        If Embeeded Then
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "onload", "onSuccess();", True)
        End If
    End Sub

    Private Sub CarregaTipoPontoAtendimento()
        Try
            Dim objTipoPontoAtendimento As New UCLTipoPontoAtendimento
            objTipoPontoAtendimento.FillDropDown(DdlTipoPontoAtendimento, True, " ")
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