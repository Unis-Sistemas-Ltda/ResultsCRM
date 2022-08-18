Public Class UCLPedidoVendaAgenteTecnico
    Inherits System.Web.UI.Page

    Private ObjAcessoDados As UCLAcessoDados

    Private _Empresa As String
    Private _Estabelecimento As String
    Private _CodPedidoVenda As String
    Private _CodAgenteTecnico As String
    Private _AgentesTecnicos As List(Of UCLAgenteTecnico)
    Private _IgnoraValidacoes As Boolean

    Public Property IgnoraValidacoes() As Boolean
        Get
            Return _IgnoraValidacoes
        End Get
        Set(ByVal value As Boolean)
            _IgnoraValidacoes = value
        End Set
    End Property

    Public Property Empresa() As String
        Get
            Return _Empresa
        End Get
        Set(ByVal value As String)
            _Empresa = value
        End Set
    End Property

    Public Property Estabelecimento() As String
        Get
            Return _Estabelecimento
        End Get
        Set(ByVal value As String)
            _Estabelecimento = value
        End Set
    End Property

    Public Property CodPedidoVenda() As String
        Get
            Return _CodPedidoVenda
        End Get
        Set(ByVal value As String)
            _CodPedidoVenda = value
        End Set
    End Property

    Public Property CodAgenteTecnico() As String
        Get
            Return _CodAgenteTecnico
        End Get
        Set(ByVal value As String)
            _CodAgenteTecnico = value
        End Set
    End Property

    Public Function AgentesTecnicos() As List(Of UCLAgenteTecnico)
        Try
            Dim agentes As New List(Of UCLAgenteTecnico)
            Dim agente As UCLAgenteTecnico
            Dim strSql As String
            Dim dt As DataTable

            strSql = " select cod_agente_tecnico "
            strSql += "  from pedido_venda_agente_tecnico"
            strSql += " where empresa = " + Empresa
            strSql += "   and estabelecimento = " + Estabelecimento
            strSql += "   and cod_pedido_venda = " + CodPedidoVenda
            dt = ObjAcessoDados.BuscarDados(strSql)

            For Each row As DataRow In dt.Rows
                agente = New UCLAgenteTecnico
                agente.CodAgenteTecnico = row.Item("cod_agente_tecnico").ToString
                agente.Buscar()
                agentes.Add(agente)
            Next

            Return agentes
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub New(ByVal StrConn As String)
        ObjAcessoDados = New UCLAcessoDados(StrConn)
        IgnoraValidacoes = False
    End Sub

    Public Function Existe() As Boolean
        Try
            Dim StrSql As String = ""
            Dim dt As DataTable
            StrSql += " select empresa "
            StrSql += "   from pedido_venda_agente_tecnico"
            StrSql += "  where empresa            = " + Empresa
            StrSql += "    and estabelecimento    = " + Estabelecimento
            StrSql += "    and cod_pedido_venda   = " + CodPedidoVenda
            StrSql += "    and cod_agente_tecnico = " + CodAgenteTecnico
            dt = ObjAcessoDados.BuscarDados(StrSql)
            Return dt.Rows.Count > 0
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Incluir()
        Try
            Dim StrSql As String = ""

            If Not IgnoraValidacoes Then
                If PedidoEncerrado() Then
                    Throw New Exception("Não é permitido vincular agente técnico após o encerramento da OS.")
                End If
            End If

            StrSql += " insert into pedido_venda_agente_tecnico( empresa, estabelecimento, cod_pedido_venda, cod_agente_tecnico ) "
            StrSql += "   values ( " + Empresa + ", " + Estabelecimento + ", " + CodPedidoVenda + ", " + CodAgenteTecnico + ")"
            ObjAcessoDados.ExecutarSql(StrSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Excluir()
        Try
            Dim StrSql As String = ""

            If Not IgnoraValidacoes Then
                If PedidoEncerrado() Then
                    Throw New Exception("Não é permitido desvincular agente técnico após o encerramento da OS.")
                End If
            End If

            StrSql += "  delete "
            StrSql += "    from pedido_venda_agente_tecnico "
            StrSql += "   where empresa            = " + Empresa
            StrSql += "     and estabelecimento    = " + Estabelecimento
            StrSql += "     and cod_pedido_venda   = " + CodPedidoVenda
            If Not String.IsNullOrEmpty(CodAgenteTecnico) Then
                StrSql += " and cod_agente_tecnico = " + CodAgenteTecnico
            End If
            ObjAcessoDados.ExecutarSql(StrSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function PedidoEncerrado() As Boolean
        Try
            Dim objPedido As New UCLPedidoVenda(StrConexaoUsuario(Session("GlUsuario")))
            objPedido.empresa = Me.empresa
            objPedido.estabelecimento = Me.estabelecimento
            objPedido.codPedidoVenda = Me.codPedidoVenda
            objPedido.Buscar()

            If objPedido.statusDigitacao = "2" Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
