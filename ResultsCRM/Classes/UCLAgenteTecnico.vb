Public Class UCLAgenteTecnico

    Private ObjAcessoDados As UCLAcessoDados
    Private _CodAgenteTecnico As String
    Private _CodUsuario As String
    Private _Email As String
    Private _Telefone As String
    Private _Ramal As String
    Private _Nome As String

    Public Property CodAgenteTecnico() As String
        Get
            Return _CodAgenteTecnico
        End Get
        Set(ByVal value As String)
            _CodAgenteTecnico = value
        End Set
    End Property

    Public Property Email() As String
        Get
            Return _Email
        End Get
        Set(ByVal value As String)
            _Email = value
        End Set
    End Property

    Public Property Telefone() As String
        Get
            Return _Telefone
        End Get
        Set(ByVal value As String)
            _Telefone = value
        End Set
    End Property

    Public Property Ramal() As String
        Get
            Return _Ramal
        End Get
        Set(ByVal value As String)
            _Ramal = value
        End Set
    End Property

    Public Property CodUsuario() As String
        Get
            Return _CodUsuario
        End Get
        Set(ByVal value As String)
            _CodUsuario = value
        End Set
    End Property

    Public Property Nome() As String
        Get
            Return _Nome
        End Get
        Set(ByVal value As String)
            _Nome = value
        End Set
    End Property

    Public Sub New()
        ObjAcessoDados = New UCLAcessoDados(StrConexao)
    End Sub

    Public Function Buscar() As Boolean
        Try
            Dim StrSql As String = ""
            Dim dt As DataTable

            StrSql += " select email, telefone, ramal, cod_usuario, nome "
            StrSql += "   from agente_tecnico "
            StrSql += "  where cod_agente_tecnico = " + CodAgenteTecnico
            dt = ObjAcessoDados.BuscarDados(StrSql)
            If dt.Rows.Count > 0 Then
                Email = dt.Rows.Item(0).Item("email").ToString
                Telefone = dt.Rows.Item(0).Item("telefone").ToString
                Ramal = dt.Rows.Item(0).Item("ramal").ToString
                CodUsuario = dt.Rows.Item(0).Item("cod_usuario").ToString
                Nome = dt.Rows.Item(0).Item("nome").ToString
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
            StrSql = "insert into agente_tecnico(cod_agente_tecnico, email, telefone, ramal, cod_usuario, nome)"
            StrSql += "  values ( " + CodAgenteTecnico + ", '" + Email + "', '" + Telefone + "', '" + Ramal + "', " + IIf(String.IsNullOrEmpty(CodUsuario), "null", CodUsuario) + ",'" + Nome + "');"
            ObjAcessoDados.ExecutarSql(StrSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Alterar()
        Try
            Dim StrSql As String
            StrSql = " update agente_tecnico "
            StrSql += "   set email       = '" + Email + "', "
            StrSql += "       telefone    = '" + Telefone + "', "
            StrSql += "       ramal       = '" + Ramal + "',"
            StrSql += "       cod_usuario = " + IIf(String.IsNullOrEmpty(CodUsuario), "null", CodUsuario) + ","
            StrSql += "       nome        = '" + Nome + "'"
            StrSql += " where cod_agente_tecnico = " + CodAgenteTecnico
            ObjAcessoDados.ExecutarSql(StrSql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub FillDropDown(ByRef DDL As DropDownList, ByVal AdicionarRegistroEmBranco As Boolean, ByVal DescricaoRegistroEmBranco As String, ByVal CodRegistroEmBranco As String, Optional ByVal AdicionaSemAgenteTecnicoInformadoAListagem As Boolean = False)
        Dim strSql As String = ""
        Dim dt As DataTable
        Dim sequencia As Integer = 0

        strSql += " select convert(text,a.cod_agente_tecnico) cod, a.nome nome"
        strSql += "   from agente_tecnico a"
        strSql += "  order by nome "
        dt = ObjAcessoDados.BuscarDados(strSql)

        If AdicionarRegistroEmBranco Then
            Dim NovaLinha As DataRow = dt.NewRow
            NovaLinha("cod") = CodRegistroEmBranco
            If String.IsNullOrEmpty(DescricaoRegistroEmBranco) Then
                DescricaoRegistroEmBranco = " "
            End If
            NovaLinha("nome") = DescricaoRegistroEmBranco
            dt.Rows.InsertAt(NovaLinha, sequencia)
            sequencia += 1
        End If

        If AdicionaSemAgenteTecnicoInformadoAListagem Then
            Dim NovaLinha As DataRow = dt.NewRow
            NovaLinha("cod") = "0"
            NovaLinha("nome") = "(Sem agente técnico informado)"
            dt.Rows.InsertAt(NovaLinha, sequencia)
        End If

        DDL.DataSource = dt
        DDL.DataTextField = "nome"
        DDL.DataValueField = "cod"
        DDL.DataBind()
    End Sub

    Public Sub FillDropDown(ByRef DDL As DropDownList, ByVal AdicionarRegistroEmBranco As Boolean, ByVal DescricaoRegistroEmBranco As String, ByVal CodRegistroEmBranco As String, ByVal Empresa As String, ByVal Estabelecimento As String, ByVal CodPedidoVenda As String)
        Dim strSql As String = ""
        Dim dt As DataTable

        strSql += " select a.cod_agente_tecnico cod, a.nome nome"
        strSql += "   from agente_tecnico a"
        strSql += "  where exists(select 1 from pedido_venda_agente_tecnico p where p.cod_agente_tecnico = a.cod_agente_tecnico and p.empresa = " + Empresa + " and p.estabelecimento = " + Estabelecimento + " and p.cod_pedido_venda = " + CodPedidoVenda + ")"
        strSql += "  order by nome "
        dt = ObjAcessoDados.BuscarDados(strSql)

        If AdicionarRegistroEmBranco Then
            Dim NovaLinha As DataRow = dt.NewRow
            NovaLinha("cod") = CodRegistroEmBranco
            If String.IsNullOrEmpty(DescricaoRegistroEmBranco) Then
                DescricaoRegistroEmBranco = " "
            End If
            NovaLinha("nome") = DescricaoRegistroEmBranco
            dt.Rows.InsertAt(NovaLinha, 0)
        End If

        DDL.DataSource = dt
        DDL.DataTextField = "nome"
        DDL.DataValueField = "cod"
        DDL.DataBind()
    End Sub

    Public Function GetProximoCodigo() As Long
        Dim ret As Long = 1
        Dim strSql = " select isnull(max(cod_agente_tecnico),0) + 1 max from agente_tecnico "
        Dim dt As DataTable = objAcessoDados.BuscarDados(strSql)
        If dt.Rows.Count > 0 Then
            ret = dt.Rows.Item(0).Item("max").ToString
        End If
        Return ret
    End Function

    Public Function GetCodAgenteTecnico(ByVal pCodUsuario As String) As String
        Try
            Dim StrSql As String = " select cod_agente_tecnico from agente_tecnico where cod_usuario = " + pCodUsuario
            Dim dt As DataTable = ObjAcessoDados.BuscarDados(StrSql)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt.Rows.Item(0).Item("cod_agente_tecnico")) Then
                    Return 0
                Else
                    Return dt.Rows.Item(0).Item("cod_agente_tecnico").ToString
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
