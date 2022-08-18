Public Class WFClienteTEF
    Inherits System.Web.UI.Page

    Public ReadOnly Property Prop_CodEmitente As String
        Get
            Return Request.QueryString.Item("e")
        End Get
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim objEmitente As New UCLEmitente(StrConexao)
            Dim cnpjPrincipal As String = objEmitente.GetCNPJ(Prop_CodEmitente, UCLEmitente.TipoCNPJ.Preferencial)
            If Not IsPostBack Then
                Call IniciaAdesao()
                Call CarregaTela()
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Private Sub IniciaAdesao()
        Try
            Dim objEmitenteTEF As New UCLEmitenteTEF
            Dim ObjContato As New UCLContato
            Dim ObjEmitente As New UCLEmitente(StrConexao)
            Dim nome_contato As String = ""
            Dim telefone1_contato As String = ""
            Dim telefone2_contato As String = ""
            Dim email_contato As String = ""

            If Not objEmitenteTEF.Buscar(Prop_CodEmitente) Then
                ObjContato.CodEmitente = Prop_CodEmitente
                ObjContato.Codigo = ObjContato.GetCodContatoPreferencial()
                If Not String.IsNullOrWhiteSpace(ObjContato.Codigo) AndAlso IsNumeric(ObjContato.Codigo) AndAlso ObjContato.Codigo > 0 AndAlso Not String.IsNullOrWhiteSpace(ObjContato.CodEmitente) Then
                    If ObjContato.Buscar() Then
                        nome_contato = ObjContato.Nome
                        email_contato = ObjContato.Email
                    End If
                    telefone1_contato = ObjEmitente.GetTelefone(Prop_CodEmitente)
                    telefone2_contato = ObjEmitente.GetTelefone2(Prop_CodEmitente)
                End If

                objEmitenteTEF.SetConteudo("cod_emitente", Prop_CodEmitente)
                objEmitenteTEF.SetConteudo("nome_contato", nome_contato)
                objEmitenteTEF.SetConteudo("telefone1_contato", telefone1_contato)
                objEmitenteTEF.SetConteudo("telefone2_contato", telefone2_contato)
                objEmitenteTEF.SetConteudo("email_contato", email_contato)
                objEmitenteTEF.SetConteudo("nome_responsavel", nome_contato)
                objEmitenteTEF.Incluir()

                GridView1.DataBind()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregaTela()
        Try
            CarregaDadosContato(True)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub CarregaDadosContato(ByVal pEnabled As Boolean)
        Try
            Dim ObjEmitenteTEF As New UCLEmitenteTEF
            Dim ObjEmitente As New UCLEmitente(StrConexao)
            LblNomeFarmacia.Text = ObjEmitente.GetRazaoSocial(Prop_CodEmitente)

            If ObjEmitenteTEF.Buscar(Prop_CodEmitente) Then
                TxtNomeResponsavel.Text = ObjEmitenteTEF.GetConteudo("nome_responsavel")
                TxtNomeResponsavel.Enabled = pEnabled
                TxtCPF.Text = ObjEmitenteTEF.GetConteudo("cpf_responsavel")
                TxtCPF.Enabled = pEnabled
                If Not ObjEmitenteTEF.IsNull("data_nascimento_responsavel") Then
                    TxtDataNascimento.Text = ObjEmitenteTEF.GetConteudo("data_nascimento_responsavel").Substring(8, 2) + "/" + ObjEmitenteTEF.GetConteudo("data_nascimento_responsavel").Substring(5, 2) + "/" + ObjEmitenteTEF.GetConteudo("data_nascimento_responsavel").Substring(0, 4)
                Else
                    TxtDataNascimento.Text = ""
                End If
                TxtRG.Text = ObjEmitenteTEF.GetConteudo("rg_responsavel")
                TxtRG.Enabled = pEnabled
                TxtDataNascimento.Enabled = pEnabled
                TxtNomeContato.Text = ObjEmitenteTEF.GetConteudo("nome_contato")
                TxtNomeContato.Enabled = pEnabled
                TxtFone1Contato.Text = ObjEmitenteTEF.GetConteudo("telefone1_contato")
                TxtFone1Contato.Enabled = pEnabled
                TxtFone2Contato.Text = ObjEmitenteTEF.GetConteudo("telefone2_contato")
                TxtFone2Contato.Enabled = pEnabled
                TxtEmailContato.Text = ObjEmitenteTEF.GetConteudo("email_contato")
                TxtEmailContato.Enabled = pEnabled
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub BtnConfirmarDadosContato_Click(sender As Object, e As EventArgs) Handles BtnConfirmarDadosContato.Click
        Try
            If GravaDadosContato() Then
                Call CarregaTela()
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Private Function GravaDadosContato() As Boolean
        Try
            Dim erros As String = ""
            LblErro.Text = ""

            If String.IsNullOrWhiteSpace(TxtNomeResponsavel.Text) Then
                erros += "Informe o nome da pessoa responsável pela empresa.<br/>"
            End If

            If String.IsNullOrWhiteSpace(TxtDataNascimento.Text) Then
                erros += "Informe a data de nascimento da pessoa responsável pela empresa.<br/>"
            ElseIf Not isValidDate(TxtDataNascimento.Text) Then
                erros += "Informe corretamente data de nascimento da pessoa responsável pela empresa.<br/>"
            End If

            If String.IsNullOrWhiteSpace(TxtCPF.Text) Then
                erros += "Informe o CPF da pessoa responsável pela empresa.<br/>"
            ElseIf Not IsValidCPF(TxtCPF.Text.Replace("-", "").Replace(".", "").Replace("/", "").Replace("\", "")) Then
                erros += "Informe corretamente o CPF da pessoa responsável pela empresa.<br/>"
            End If

            If String.IsNullOrWhiteSpace(TxtRG.Text) Then
                erros += "Informe o RG da pessoa responsável pela empresa.<br/>"
            End If

            If String.IsNullOrWhiteSpace(TxtNomeContato.Text) Then
                erros += "Informe o nome da pessoa de contato na empresa.<br/>"
            End If

            If String.IsNullOrWhiteSpace(TxtFone1Contato.Text) Then
                erros += "Informe o telefone para contato.<br/>"
            End If

            If String.IsNullOrWhiteSpace(TxtEmailContato.Text) Then
                erros += "Informe pelo menos um e-mail para contato.<br/>"
            ElseIf Not IsValidEmail(TxtEmailContato.Text) Then
                erros += "Informe corretamente o(s) e-mail(s) para contato (Se desejar informar mais de um e-mail, separe-os com vírgula).<br/>"
            End If

            If Not String.IsNullOrWhiteSpace(erros) Then
                LblErro.Text = erros
                Return False
            End If

            Dim ObjEmitenteTEF As New UCLEmitenteTEF
            If ObjEmitenteTEF.Buscar(Prop_CodEmitente) Then
                ObjEmitenteTEF.SetConteudo("nome_responsavel", TxtNomeResponsavel.Text.GetValidInputContent)
                ObjEmitenteTEF.SetConteudo("data_nascimento_responsavel", TxtDataNascimento.Text.GetValidInputContent)
                ObjEmitenteTEF.SetConteudo("cpf_responsavel", TxtCPF.Text.GetValidInputContent.RemoveMascaraCNPJ_CPF_CEP)
                ObjEmitenteTEF.SetConteudo("rg_responsavel", TxtRG.Text.GetValidInputContent)
                ObjEmitenteTEF.SetConteudo("nome_contato", TxtNomeContato.Text.GetValidInputContent)
                ObjEmitenteTEF.SetConteudo("telefone1_contato", TxtFone1Contato.Text.GetValidInputContent)
                ObjEmitenteTEF.SetConteudo("telefone2_contato", TxtFone2Contato.Text.GetValidInputContent)
                ObjEmitenteTEF.SetConteudo("email_contato", TxtEmailContato.Text.GetValidInputContent)
                ObjEmitenteTEF.Alterar()

                Dim objContato As New UCLContato
                objContato.CodEmitente = Prop_CodEmitente
                objContato.Codigo = objContato.GetCodContatoPreferencial()
                If objContato.Buscar() Then
                    objContato.Nome = TxtNomeContato.Text
                    objContato.Telefone = TxtFone1Contato.Text
                    objContato.Telefone2 = TxtFone2Contato.Text
                    objContato.Email = TxtEmailContato.Text
                    objContato.Alterar()
                End If
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub GridView1_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        Dim link As HyperLink
        Dim cnpj As String

        If e.Row.RowType = DataControlRowType.DataRow Then
            cnpj = CType(e.Row.FindControl("LblCNPJ"), Label).Text
            link = e.Row.FindControl("LnkContratar")
            link.NavigateUrl = "WFAtualizacaoCadastralUnidade.aspx?emitente=" + Prop_CodEmitente + "&cnpj=" + cnpj
        End If
    End Sub

    Private Sub BtnIncluir_Click(sender As Object, e As System.EventArgs) Handles BtnIncluir.Click
        Response.Redirect("WFAtualizacaoCadastralUnidade.aspx?emitente=" + Prop_CodEmitente + "&cnpj=-1")
    End Sub

End Class