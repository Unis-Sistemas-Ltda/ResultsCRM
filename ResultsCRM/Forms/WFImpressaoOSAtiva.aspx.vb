Public Partial Class WFImpressaoOSAtiva
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
            Dim objContato As New UCLContato
            Dim objAgenteTecnico As New UCLAgenteTecnico
            Dim objPedidoAgenteTecnico As New UCLPedidoVendaAgenteTecnico(StrConexaoUsuario(Session("GlUsuario")))
            Dim objPedidoVendaItem As New UCLPedidoVendaItem(StrConexaoUsuario(Session("GlUsuario")))
            Dim objPontoAtendimento As New UCLPontoAtendimento(StrConexaoUsuario(Session("GlUsuario")))
            Dim agentes As List(Of UCLAgenteTecnico)
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
            LblTelefoneEmpresa2.Text = objEstabelecimento.Fax
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

            LblDataAgendamento.Text = objPedido.DataChegadaPrevista
            If Not String.IsNullOrEmpty(objPedido.hHoraChegadaPrevista) Then
                LblDataAgendamento.Text += " " + objPedido.hHoraChegadaPrevista
            End If
            LblCodOSCliente.Text = objChamado.OSCliente + " "

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

            LblBancoEmpresa.Text = objEmitenteAtendimento.Nome

            objPontoAtendimento.CodEmitente = objChamado.CodEmitenteAtendimento
            objPontoAtendimento.NumeroPontoAtendimento = objChamado.NumeroPontoAtendimento
            If Not String.IsNullOrEmpty(objPontoAtendimento.CodEmitente) And Not String.IsNullOrEmpty(objPontoAtendimento.NumeroPontoAtendimento) Then
                objPontoAtendimento.Buscar()
            End If

            LblPontoDeAtendimento.Text = objPontoAtendimento.NumeroPontoAtendimento + " - " + objPontoAtendimento.Descricao
            LblEnderecoCliente.Text = objPontoAtendimento.Logradouro + ", " + objPontoAtendimento.Numero

            objCidade.CodPais = objPontoAtendimento.CodPais
            objCidade.CodEstado = objPontoAtendimento.CodEstado
            objCidade.CodCidade = objPontoAtendimento.CodCidade
            If Not String.IsNullOrEmpty(objCidade.CodPais) And Not String.IsNullOrEmpty(objCidade.CodEstado) And Not String.IsNullOrEmpty(objCidade.CodCidade) Then
                objCidade.Buscar()
            End If
            LblCidade.Text = objCidade.NomeCidade

            objEstado.CodPais = objPontoAtendimento.CodPais
            objEstado.CodEstado = objPontoAtendimento.CodEstado
            If Not String.IsNullOrEmpty(objEstado.CodPais) And Not String.IsNullOrEmpty(objEstado.CodEstado) Then
                objEstado.Buscar()
            End If

            LblUF.Text = objEstado.Sigla

            LblBairroCliente.Text = objPontoAtendimento.Bairro
            LblCEP.Text = objPontoAtendimento.CEP
            LblTelefone.Text = objPontoAtendimento.Fone1
            If Not String.IsNullOrEmpty(objPontoAtendimento.Fone2) Then
                LblTelefone.Text += " / " + objPontoAtendimento.Fone2
            End If
            LblCNPJ.Text = objPontoAtendimento.CNPJ.MascaraCNPJ
            LblInscEst.Text = objPontoAtendimento.IE

            objContato.CodEmitente = objChamado.CodEmitenteAtendimento
            objContato.Codigo = objChamado.CodContatoAtendimento
            If Not String.IsNullOrEmpty(objContato.CodEmitente) And Not String.IsNullOrEmpty(objContato.Codigo) Then
                objContato.Buscar()
                LblSolicitante.Text = objContato.Nome
            End If

            objPedidoAgenteTecnico.Empresa = Empresa
            objPedidoAgenteTecnico.Estabelecimento = Estabelecimento
            objPedidoAgenteTecnico.CodPedidoVenda = CodPedidoVenda
            agentes = objPedidoAgenteTecnico.AgentesTecnicos()

            LblTecnico.Text = ""
            For Each objAgenteTecnico In agentes
                LblTecnico.Text += objAgenteTecnico.Nome + ", "
            Next
            If LblTecnico.Text.Length >= 2 Then
                LblTecnico.Text = Left(LblTecnico.Text, LblTecnico.Text.Length - 2)
            End If

            LblObsEquipamento.Text = objChamado.Observacao
            If Not String.IsNullOrEmpty(objChamado.Observacao) Then
                LblObsEquipamento.Text += "<br/>"
            End If
            If Not String.IsNullOrEmpty(objPedido.observacao) Then
                LblObsEquipamento.Text += objPedido.observacao
            End If

            GridView1.DataSource = objEquipamento.DtGridServicosSolicitadosOS(Empresa, Estabelecimento, CodPedidoVenda, 4, "")
            GridView1.DataBind()

            GridView2.DataSource = objPedidoVendaItem.dtGridItens(Empresa, Estabelecimento, CodPedidoVenda, 9)
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