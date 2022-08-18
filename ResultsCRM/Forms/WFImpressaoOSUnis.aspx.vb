Public Class WFImpressaoOSUnis
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim objEmpresa As New UCLEmpresa
            Dim objEstabelecimento As New UCLEstabelecimento
            Dim objCidade As New UCLCidade
            Dim objEstado As New UCLEstado
            Dim objPedido As New UCLPedidoVenda(StrConexaoUsuario(Session("GlUsuario")))
            Dim objChamado As New UCLAtendimento(StrConexaoUsuario(Session("GlUsuario")))
            Dim objEmitente As New UCLEmitente(StrConexaoUsuario(Session("GlUsuario")))
            Dim objEnderecoEmitente As New UCLEnderecoEmitente(StrConexaoUsuario(Session("GlUsuario")))
            Dim objEmitenteAtendimento As New UCLEmitente(StrConexaoUsuario(Session("GlUsuario")))
            Dim objAgenteTecnico As New UCLAgenteTecnico
            Dim objPedidoVendaItem As New UCLPedidoVendaItem(StrConexaoUsuario(Session("GlUsuario")))
            Dim objEquipamento As New UCLEquipamentoCliente(StrConexaoUsuario(Session("GlUsuario")))

            objEmpresa.CodEmpresa = Empresa
            objEmpresa.Buscar()
            LblRazaoSocialEmpresa.Text = objEmpresa.RazaoSocial

            objEstabelecimento.CodEmpresa = Empresa
            objEstabelecimento.Estabelecimento = Estabelecimento
            objEstabelecimento.Buscar()
            LblEnderecoEmpresa.Text = objEstabelecimento.Rua + ", " + objEstabelecimento.Numero
            LblBairroEmpresa.Text = objEstabelecimento.Bairro

            objCidade.CodPais = objEstabelecimento.CodPais
            objCidade.CodEstado = objEstabelecimento.CodEstado
            objCidade.CodCidade = objEstabelecimento.CodCidade
            objCidade.Buscar()
            LblMunicipioEmpresa.Text = objCidade.NomeCidade

            objEstado.CodPais = objEstabelecimento.CodPais
            objEstado.CodEstado = objEstabelecimento.CodEstado
            objEstado.Buscar()
            LblUFEmpresa.Text = objEstado.Sigla

            LblTelefoneEmpresa1.Text = objEstabelecimento.Telefones
            LblCNPJEmpresa.Text = objEstabelecimento.CNPJ.MascaraCNPJ
            LblInscEstEmpresa.Text = objEstabelecimento.InscEst

            LblCodOS.Text = CodPedidoVenda

            objPedido.empresa = Empresa
            objPedido.estabelecimento = Estabelecimento
            objPedido.codPedidoVenda = CodPedidoVenda
            objPedido.Buscar()

            LblCodChamado.Text = objPedido.codChamado

            objChamado.Empresa = Empresa
            objChamado.CodChamado = objPedido.codChamado
            objChamado.Buscar()

            objEmitente.CodEmitente = objPedido.codEmitente
            objEmitente.Buscar()

            objEnderecoEmitente.CodEmitente = objPedido.codEmitente
            objEnderecoEmitente.CNPJ = objPedido.cnpjFaturamento
            objEnderecoEmitente.Buscar()

            LblNomeCliente.Text = objEnderecoEmitente.NomeAbreviado
            LblCNPJCliente.Text = objPedido.cnpjFaturamento.MascaraCNPJ

            objEmitenteAtendimento.CodEmitente = objChamado.CodEmitenteAtendimento
            If Not String.IsNullOrEmpty(objEmitenteAtendimento.CodEmitente) Then
                objEmitenteAtendimento.Buscar()
            End If

            LblEnderecoCliente.Text = objEnderecoEmitente.Logradouro + ", " + objEnderecoEmitente.Numero

            objCidade.CodPais = objEnderecoEmitente.CodPais
            objCidade.CodEstado = objEnderecoEmitente.CodEstado
            objCidade.CodCidade = objEnderecoEmitente.CodCidade
            If Not String.IsNullOrEmpty(objCidade.CodPais) And Not String.IsNullOrEmpty(objCidade.CodEstado) And Not String.IsNullOrEmpty(objCidade.CodCidade) Then
                objCidade.Buscar()
            End If
            LblCidade.Text = objCidade.NomeCidade

            objEstado.CodPais = objEnderecoEmitente.CodPais
            objEstado.CodEstado = objEnderecoEmitente.CodEstado
            If Not String.IsNullOrEmpty(objEstado.CodPais) And Not String.IsNullOrEmpty(objEstado.CodEstado) Then
                objEstado.Buscar()
            End If

            LblUF.Text = objEstado.Sigla

            LblBairroCliente.Text = objEnderecoEmitente.Bairro
            LblCEP.Text = objEnderecoEmitente.CEP
            LblTelefone.Text = objEnderecoEmitente.Fone1
            If Not String.IsNullOrEmpty(objEnderecoEmitente.Fone2) Then
                LblTelefone.Text += " / " + objEnderecoEmitente.Fone2
            End If
            
            GridView1.DataBind()
            GridView2.DataBind()

        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub

    Private ReadOnly Property Empresa() As String
        Get
            Return Request.QueryString.Item("eid")
        End Get
    End Property

    Private ReadOnly Property Estabelecimento() As String
        Get
            Return Request.QueryString.Item("sid")
        End Get
    End Property

    Private ReadOnly Property CodPedidoVenda() As String
        Get
            Return Request.QueryString.Item("pid")
        End Get
    End Property
End Class