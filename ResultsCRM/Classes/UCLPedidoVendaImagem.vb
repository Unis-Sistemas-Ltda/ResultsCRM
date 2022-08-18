Public Class UCLPedidoVendaImagem

    Private ObjAcessoDados As UCLAcessoDados
    Public Property Empresa As String
    Public Property Estabelecimento As String
    Public Property CodPedidoVenda As String
    Public Property SeqImagem As String
    Public Property Descricao As String
    Public Property Arquivo As String
    Public Property Tipo As String

    Public Sub New(ByVal StrC As String)
        ObjAcessoDados = New UCLAcessoDados(StrC)
    End Sub

    Public Function Buscar(ByVal pEmpresa As String, ByVal pEstabelecimento As String, ByVal pCodPedidoVenda As String, ByVal pSeqImagem As String) As Boolean
        Try
            Dim StrSql As String
            Dim dt As DataTable

            StrSql = ""
            StrSql += " select * "
            StrSql += "   from pedido_venda_imagem"
            StrSql += " where empresa          = " + pEmpresa
            StrSql += "   and estabelecimento  = " + pEstabelecimento
            StrSql += "   and cod_pedido_venda = " + pCodPedidoVenda
            StrSql += "   and seq_imagem       = " + pSeqImagem

            dt = ObjAcessoDados.BuscarDados(StrSql)

            If dt.Rows.Count > 0 Then
                Descricao = dt.Rows.Item(0).Item("descricao").ToString
                Arquivo = dt.Rows.Item(0).Item("arquivo").ToString
                Tipo = dt.Rows.Item(0).Item("tipo").ToString
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Incluir()
        Try
            Dim StrSql As String
            StrSql = " insert into pedido_venda_imagem(empresa, estabelecimento, cod_pedido_venda, seq_imagem, descricao, arquivo, tipo)"
            StrSql += " values ( " + Empresa + ", " + Estabelecimento + ", " + CodPedidoVenda + ", " + SeqImagem + ", '" + Descricao + "', f_nome_arquivo('" + Arquivo + "'), " + Tipo + ")"
            ObjAcessoDados.ExecutarSql(StrSql)

            Dim objPedidoVenda As New UCLPedidoVenda(StrConexao)
            objPedidoVenda.empresa = Empresa
            objPedidoVenda.estabelecimento = Estabelecimento
            objPedidoVenda.codPedidoVenda = CodPedidoVenda
            objPedidoVenda.SetAlteradoTecnico("S")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Alterar()
        Try
            Dim StrSql As String
            StrSql = " update pedido_venda_imagem "
            StrSql += "   set descricao = '" + Descricao + "', "
            StrSql += "       arquivo = f_nome_arquivo('" + Arquivo + "'), "
            StrSql += "       tipo = " + Tipo
            StrSql += " where empresa          = " + Empresa
            StrSql += "   and estabelecimento  = " + Estabelecimento
            StrSql += "   and cod_pedido_venda = " + CodPedidoVenda
            StrSql += "   and seq_imagem       = " + SeqImagem
            ObjAcessoDados.ExecutarSql(StrSql)

            Dim objPedidoVenda As New UCLPedidoVenda(StrConexao)
            objPedidoVenda.empresa = Empresa
            objPedidoVenda.estabelecimento = Estabelecimento
            objPedidoVenda.codPedidoVenda = CodPedidoVenda
            objPedidoVenda.SetAlteradoTecnico("S")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Excluir()
        Try
            Dim StrSql As String
            StrSql = " delete from pedido_venda_imagem "
            StrSql += " where empresa          = " + Empresa
            StrSql += "   and estabelecimento  = " + Estabelecimento
            StrSql += "   and cod_pedido_venda = " + CodPedidoVenda
            StrSql += "   and seq_imagem       = " + SeqImagem
            ObjAcessoDados.ExecutarSql(StrSql)

            Dim objPedidoVenda As New UCLPedidoVenda(StrConexao)
            objPedidoVenda.empresa = Empresa
            objPedidoVenda.estabelecimento = Estabelecimento
            objPedidoVenda.codPedidoVenda = CodPedidoVenda
            objPedidoVenda.SetAlteradoTecnico("S")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetProximoCodigo() As Long
        Dim ret As Long = 1
        Dim strSql As String = "select (max(seq_imagem) + 1) as max from pedido_venda_imagem where empresa = " + Empresa + " and estabelecimento = " + Estabelecimento + " and cod_pedido_venda = " + CodPedidoVenda
        Dim dt As DataTable = objAcessoDados.BuscarDados(strSql)
        If dt.Rows.Count > 0 Then
            If Not IsDBNull(dt.Rows.Item(0).Item("max")) Then
                ret = dt.Rows.Item(0).Item("max").ToString
            End If
            If ret = 0 Then
                ret = 1
            End If
        End If
        Return ret
    End Function

End Class
