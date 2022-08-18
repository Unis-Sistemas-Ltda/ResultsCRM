Public Class WUCPosVendaCabecalho
    Inherits System.Web.UI.UserControl

    Private _Acao As String

    Public Property Acao As String
        Get
            Return _Acao
        End Get
        Set(ByVal value As String)
            _Acao = value
        End Set
    End Property

    Public Property CodEmitente As String
        Get
            Return LblCodigo.Text
        End Get
        Set(ByVal value As String)
            LblCodigo.Text = value
        End Set
    End Property

    Public Property CNPJEmitente As String
        Get
            Return LblCNPJ.Text.Replace("/", "").Replace("-", "").Replace(".", "").Replace(" ", "")
        End Get
        Set(ByVal value As String)
            LblCNPJ.Text = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Call CarregaFormulario()
        Catch ex As Exception
            LblErro.Text = ex.Message
        End Try
    End Sub

    Private Sub CarregaFormulario()
        Try
            Dim objEmitente As New UCLEmitente(StrConexaoUsuario(Session("GlUsuario")))
            Dim objEnderecoEmitente As New UCLEnderecoEmitente(StrConexaoUsuario(Session("GlUsuario")))
            Dim objContato As New UCLContato
            Dim objPais As New UCLPais
            Dim objEstado As New UCLEstado
            Dim objCidade As New UCLCidade
            Dim objEmitentePF As New UCLEmitente(StrConexaoUsuario(Session("GlUsuario")))
            Dim qtdDiasInadimplente As Long
            Dim qtdTitulosAberto As Long

            objEmitente.CodEmitente = CodEmitente
            objEmitente.Buscar()

            objEnderecoEmitente.CodEmitente = CodEmitente
            objEnderecoEmitente.CNPJ = CNPJEmitente
            objEnderecoEmitente.Buscar()

            objPais.CodPais = objEnderecoEmitente.CodPais
            objPais.Buscar()

            objEstado.CodPais = objEnderecoEmitente.CodPais
            objEstado.CodEstado = objEnderecoEmitente.CodEstado
            objEstado.Buscar()

            objCidade.CodPais = objEnderecoEmitente.CodPais
            objCidade.CodEstado = objEnderecoEmitente.CodEstado
            objCidade.CodCidade = objEnderecoEmitente.CodCidade
            objCidade.Buscar()

            LblNome.Text = objEmitente.Nome
            LblNomeFantasia.Text = objEnderecoEmitente.NomeAbreviado

            If objEmitente.TpPessoa = "PF" Then
                LblCNPJLbl.Text = "CPF"
                LblCNPJ.Text = LblCNPJ.Text.MascaraCPF
            Else
                LblCNPJLbl.Text = "CNPJ"
                LblCNPJ.Text = LblCNPJ.Text.MascaraCNPJ
            End If

            Select Case objEmitente.Situacao
                Case 1
                    LblSituacao.Text = "POTENCIAL"
                Case 2
                    LblSituacao.Text = "ATIVO"
                Case 3
                    LblSituacao.Text = "INATIVO"
                Case 4
                    LblSituacao.Text = "EM ATIVAÇÃO"
                Case 5
                    LblSituacao.Text = "ATIVO PEND DOCUMENTAL"
                Case 6
                    LblSituacao.Text = "ENCERROU AS ATIVIDADES"
            End Select

            LblLogradouro.Text = objEnderecoEmitente.Logradouro

            If Not String.IsNullOrEmpty(objEnderecoEmitente.Numero) Then
                If IsNumeric(objEnderecoEmitente.Numero) Then
                    If objEnderecoEmitente.Numero > 0 Then
                        LblLogradouro.Text += ", Nº " + objEnderecoEmitente.Numero
                    End If
                End If
            End If

            LblBairro.Text = objEnderecoEmitente.Bairro
            LblCEP.Text = objEnderecoEmitente.CEP
            LblCidade.Text = objCidade.NomeCidade
            LblUF.Text = objEstado.Sigla
            LblPais.Text = objPais.Nome

            LblTelefones.Text = objEnderecoEmitente.Fone1

            If Not String.IsNullOrEmpty(objEnderecoEmitente.Fone2) Then
                LblTelefones.Text += "   e   " + objEnderecoEmitente.Fone2
            End If

            LblFax.Text = objEnderecoEmitente.Fax
            LblEmail.Text = objEnderecoEmitente.Email
            LblSenha.Text = objEnderecoEmitente.Senha

            If objEnderecoEmitente.Preferencial = "S" Then
                LblPreferencial.Text = "SIM"
            Else
                LblPreferencial.Text = "NÃO"
            End If

            If objEmitente.Associado = "S" Then
                LblAssociado.Text = "SIM"
                If objEmitente.TpPessoa = "PF" Then
                    LblAssociado.Text += ", Pessoa Física"
                Else
                    LblAssociado.Text += ", Pessoa Jurídica"
                End If
            Else
                LblAssociado.Text = "NÃO"
            End If

            If Not String.IsNullOrEmpty(objEmitente.DataAlteracao) Then
                LblDataAlteracao.Text = objEmitente.DataAlteracao
            End If

            If Not String.IsNullOrEmpty(objEmitente.DataCadastramento) Then
                LblDataCadastro.Text = objEmitente.DataCadastramento
            End If

            If Not String.IsNullOrEmpty(objEmitente.DataRecadastramento) Then
                LblDataRecadastro.Text = objEmitente.DataRecadastramento
            End If

            If Not String.IsNullOrEmpty(objEmitente.DataReativacao) Then
                LblDataReativacao.Text = objEmitente.DataReativacao
            End If

            If Not String.IsNullOrEmpty(objEmitente.DataPendDoc) Then
                LblDataPendDoc.Text = objEmitente.DataPendDoc
            End If

            If objEmitente.TpPessoa = "PJ" Then
                If Not String.IsNullOrEmpty(objEmitente.CodEmitentePF) Then
                    objEmitentePF.CodEmitente = objEmitente.CodEmitentePF
                    objEmitentePF.Buscar()
                    BtnEmitentePF.Text = objEmitentePF.Nome + " (" + objEmitentePF.CodEmitente + ")"
                End If
            Else
                objEmitentePF.CodEmitente = objEmitente.CodEmitente
                objEmitentePF.CodEmitente = objEmitentePF.GetPessoaJuridica()
                objEmitentePF.Buscar()
                BtnEmitentePF.Text = objEmitentePF.Nome + " (" + objEmitentePF.CodEmitente + ")"
                LblEmitentePFLbl.Text = "PJ:"
            End If

            If String.IsNullOrEmpty(BtnEmitentePF.Text) Then
                LblEmitentePFLbl.Visible = False
            End If

            qtdTitulosAberto = objEmitente.TitulosEmAbertoVencidos(Session("GlEmpresa"))
            qtdDiasInadimplente = objEmitente.DiasInadimplente(Session("GlEmpresa"))
            If qtdTitulosAberto > 0 AndAlso qtdDiasInadimplente > 0 Then
                LblInadimplente.Text = "Cliente possui " + qtdTitulosAberto.ToString + " título(s) em aberto e está inadimplente há " + qtdDiasInadimplente.ToString + " dias"
                If qtdDiasInadimplente <= 31 Then
                    LblInadimplente.ForeColor = Drawing.Color.Black
                End If
            End If

            objContato.CodEmitente = objEmitente.CodEmitente
            objContato.Codigo = objContato.GetCodContatoPreferencial()
            objContato.Buscar()

            LblContatoPreferencial.Text = objContato.Nome + " [" + objContato.Email + "]"

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub BtnEmitentePF_Click(sender As Object, e As EventArgs) Handles BtnEmitentePF.Click
        Try
            Dim codEmitente As String
            Dim objEmitente As New UCLEmitente(StrConexaoUsuario(Session("GlUsuario")))

            codEmitente = BtnEmitentePF.Text.Substring(BtnEmitentePF.Text.IndexOf("("))
            codEmitente = codEmitente.Replace("(", "").Replace(")", "")

            objEmitente.CodEmitente = codEmitente
            If Not String.IsNullOrEmpty(objEmitente.CodEmitente) Then
                objEmitente.Buscar()
                Session("SCodEmitente") = codEmitente
                Session("SCNPJEmitente") = objEmitente.CNPJPreferencial
                Session("SAcao") = "ALTERAR"

                Page.ClientScript.RegisterStartupScript(Me.GetType, "onload", "carregaParent()", True)
            End If

            
        Catch ex As Exception

        End Try
    End Sub
End Class