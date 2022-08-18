Public Class WFImpressaoOSCIMTEL
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim objEmpresa As New UCLEmpresa
            Dim objEstabelecimento As New UCLEstabelecimento
            Dim objCidade As New UCLCidade
            Dim objEstado As New UCLEstado
            Dim objPedido As New UCLPedidoVenda(StrConexaoUsuario(Session("GlUsuario")))
            Dim objChamado As New UCLAtendimento(StrConexaoUsuario(Session("GlUsuario")))
            Dim objTipoChamado As New UCLTipoChamado
            Dim objEmitente As New UCLEmitente(StrConexaoUsuario(Session("GlUsuario")))
            Dim objEnderecoEmitente As New UCLEnderecoEmitente(StrConexaoUsuario(Session("GlUsuario")))
            Dim objContato As New UCLContato
            Dim objAgenteTecnico As New UCLAgenteTecnico
            Dim objPedidoAgenteTecnico As New UCLPedidoVendaAgenteTecnico(StrConexaoUsuario(Session("GlUsuario")))
            Dim objPedidoVendaItem As New UCLPedidoVendaItem(StrConexaoUsuario(Session("GlUsuario")))
            Dim agentes As List(Of UCLAgenteTecnico)
            Dim objEquipamento As New UCLEquipamentoCliente(StrConexaoUsuario(Session("GlUsuario")))

            objEmpresa.CodEmpresa = Empresa
            objEmpresa.Buscar()
            LblEmpresaRazaoSocial.Text = objEmpresa.RazaoSocial

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

            LblInformacaoEmpresa.Text = objEstabelecimento.Informacao

            LblSiteEmpresa.Text = objEstabelecimento.HomePage
            LblEmailEmpresa.Text = objEstabelecimento.Email
            LblTelefoneEmpresa1.Text = objEstabelecimento.Telefones
            LblTelefoneEmpresa2.Text = objEstabelecimento.Fax

            LblCodOS.Text = CodPedidoVenda

            objPedido.empresa = Empresa
            objPedido.estabelecimento = Estabelecimento
            objPedido.codPedidoVenda = CodPedidoVenda
            objPedido.Buscar()

            objChamado.Empresa = Empresa
            objChamado.CodChamado = objPedido.codChamado
            objChamado.Buscar()

            If Not String.IsNullOrWhiteSpace(objChamado.TipoChamado) Then
                If objTipoChamado.Buscar(Empresa, objChamado.TipoChamado) Then
                    LblTipoChamado.Text = objTipoChamado.GetConteudo("nome")
                End If
            End If

            objEmitente.CodEmitente = objPedido.codEmitente
            objEmitente.Buscar()

            objEnderecoEmitente.CodEmitente = objPedido.codEmitente
            objEnderecoEmitente.CNPJ = objPedido.cnpjFaturamento
            objEnderecoEmitente.Buscar()

            objEstado.CodPais = objEnderecoEmitente.CodPais
            objEstado.CodEstado = objEnderecoEmitente.CodEstado
            If Not String.IsNullOrEmpty(objEstado.CodPais) And Not String.IsNullOrEmpty(objEstado.CodEstado) Then
                objEstado.Buscar()
            End If

            objCidade.CodPais = objEnderecoEmitente.CodPais
            objCidade.CodEstado = objEnderecoEmitente.CodEstado
            objCidade.CodCidade = objEnderecoEmitente.CodCidade
            If Not String.IsNullOrEmpty(objCidade.CodPais) And Not String.IsNullOrEmpty(objCidade.CodEstado) And Not String.IsNullOrEmpty(objCidade.CodCidade) Then
                objCidade.Buscar()
            End If

            LblCodChamado.Text = objPedido.codChamado
            LblDataChamado.Text = objChamado.DataChamado

            LblCodCliente.Text = objPedido.codEmitente
            LblNomeCliente.Text = objEmitente.Nome
            LblEnderecoCliente.Text = objEnderecoEmitente.Logradouro + ", " + objEnderecoEmitente.Numero
            LblBairroCliente.Text = objEnderecoEmitente.Bairro
            LblCidade.Text = objCidade.NomeCidade
            LblUF.Text = objEstado.Sigla
            LblCEP.Text = objEnderecoEmitente.CEP.MascaraCEP
            LblCNPJ_CPF.Text = IIf(objEmitente.TpPessoa = "PF", "CPF:", "CNPJ:")
            LblCNPJCliente.Text = IIf(objEmitente.TpPessoa = "PF", objPedido.cnpjFaturamento.MascaraCPF, objPedido.cnpjFaturamento.MascaraCNPJ)
            LblTelefone1Cliente.Text = objEnderecoEmitente.Fone1
            LblTelefone2Cliente.Text = objEnderecoEmitente.Fone2
            LblReferencia.Text = objEnderecoEmitente.Referencia

            objContato.CodEmitente = objChamado.CodEmitente
            objContato.Codigo = objChamado.CodContato
            If Not String.IsNullOrEmpty(objContato.CodEmitente) And Not String.IsNullOrEmpty(objContato.Codigo) Then
                objContato.Buscar()
                LblContatoNome.Text = objContato.Nome
            End If

            LblAssunto.Text = objChamado.Assunto

            objPedidoAgenteTecnico.Empresa = Empresa
            objPedidoAgenteTecnico.Estabelecimento = Estabelecimento
            objPedidoAgenteTecnico.CodPedidoVenda = CodPedidoVenda
            agentes = objPedidoAgenteTecnico.AgentesTecnicos()

            LblTecnicos.Text = ""
            For Each objAgenteTecnico In agentes
                LblTecnicos.Text += objAgenteTecnico.Nome + ", "
            Next
            If LblTecnicos.Text.Length >= 2 Then
                LblTecnicos.Text = Left(LblTecnicos.Text, LblTecnicos.Text.Length - 2)
            End If

            If Not String.IsNullOrEmpty(objChamado.Observacao) Then
                LblObservacao.Text += objChamado.Observacao
            End If

            GridView2.DataSource = objPedidoVendaItem.dtGridItens(Empresa, Estabelecimento, CodPedidoVenda, 7)
            GridView2.DataBind()

            GridView3.DataSource = objEquipamento.DtGridEquipamentosServicosSolicitadosOS(Empresa, Estabelecimento, CodPedidoVenda)
            GridView3.DataBind()

            LblEmpresaRazaoSocial.Text = objEmpresa.RazaoSocial
            LblNomeClienteRodape.Text = objEmitente.Nome

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

    Private Sub GridView3_DataBound(sender As Object, e As System.EventArgs) Handles GridView3.DataBound
        Dim objEquipamento As New UCLEquipamentoCliente(StrConexaoUsuario(Session("GlUsuario")))
        Dim LblNumeroSerieEquipamentoOS As Label
        Dim GridView1 As GridView
        For Each row As GridViewRow In GridView3.Rows
            If row.RowType = DataControlRowType.DataRow Then
                GridView1 = row.FindControl("GridView1")
                LblNumeroSerieEquipamentoOS = row.FindControl("LblNumeroSerieEquipamentoOS")
                GridView1.DataSource = objEquipamento.DtGridServicosSolicitadosOS(Empresa, Estabelecimento, CodPedidoVenda, 1, LblNumeroSerieEquipamentoOS.Text)
                GridView1.DataBind()
            End If
        Next
    End Sub
End Class