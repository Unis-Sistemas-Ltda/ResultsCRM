Public Class UCLPedidoVendaSolicitacaoCausa
    Inherits System.Web.UI.Page

    Private ObjAcessoDados As UCLAcessoDados

    Private _Empresa As String
    Private _Estabelecimento As String
    Private _CodPedidoVenda As String
    Private _SeqSolicitacao As String
    Private _CodCausa As String
    Private _Causas As List(Of UCLCausa)
    Private _IgnoraValidacoes As Boolean

    Public Property IgnoraValidacoes() As Boolean
        Get
            Return _IgnoraValidacoes
        End Get
        Set(ByVal value As Boolean)
            _IgnoraValidacoes = value
        End Set
    End Property
    Public Property SeqSolicitacao As String
        Get
            Return _SeqSolicitacao
        End Get
        Set(value As String)
            _SeqSolicitacao = value
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

    Public Property CodCausa() As String
        Get
            Return _CodCausa
        End Get
        Set(ByVal value As String)
            _CodCausa = value
        End Set
    End Property

    Public Function Causas() As List(Of UCLCausa)
        Try
            Dim lCausas As New List(Of UCLCausa)
            Dim causa As UCLCausa
            Dim strSql As String
            Dim dt As DataTable

            strSql = " select cod_causa "
            strSql += "  from pedido_venda_solicitacao_causa"
            strSql += " where empresa = " + Empresa
            strSql += "   and estabelecimento = " + Estabelecimento
            strSql += "   and cod_pedido_venda = " + CodPedidoVenda
            strSql += "   and seq_solicitacao  = " + SeqSolicitacao
            dt = ObjAcessoDados.BuscarDados(strSql)

            For Each row As DataRow In dt.Rows
                causa = New UCLCausa
                causa.Codigo = row.Item("cod_causa").ToString
                causa.Buscar()
                lCausas.Add(causa)
            Next

            Return lCausas
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
            StrSql += "   from pedido_venda_solicitacao_causa"
            StrSql += "  where empresa            = " + Empresa
            StrSql += "    and estabelecimento    = " + Estabelecimento
            StrSql += "    and cod_pedido_venda   = " + CodPedidoVenda
            StrSql += "    and seq_solicitacao    = " + SeqSolicitacao
            StrSql += "    and cod_causa          = " + CodCausa
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
                    Throw New Exception("Não é permitido vincular causa após o encerramento da OS.")
                End If
            End If

            StrSql += " insert into pedido_venda_solicitacao_causa( empresa, estabelecimento, cod_pedido_venda, seq_solicitacao, cod_causa ) "
            StrSql += "   values ( " + Empresa + ", " + Estabelecimento + ", " + CodPedidoVenda + ", " + SeqSolicitacao + ", " + CodCausa + ")"
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
                    Throw New Exception("Não é permitido desvincular causa após o encerramento da OS.")
                End If
            End If

            StrSql += "  delete "
            StrSql += "    from pedido_venda_solicitacao_causa "
            StrSql += "   where empresa            = " + Empresa
            StrSql += "     and estabelecimento    = " + Estabelecimento
            StrSql += "     and cod_pedido_venda   = " + CodPedidoVenda
            If Not String.IsNullOrEmpty(CodCausa) Then
                StrSql += " and cod_causa = " + CodCausa
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
