Public Class UCLSysUsuario
    Inherits UCLClasseGenerica

    Public Sub New()
        ObjTabelaGenerica = New UCLTabelaGenerica("sysusuario")
    End Sub

    Public Function Buscar(ByVal pCodUsuario As String) As Boolean
        Try
            Me.SetConteudo("cod_usuario", pCodUsuario)
            Return ObjTabelaGenerica.Buscar()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Excluir(ByVal pCodUsuario As String)
        Try
            Me.SetConteudo("cod_usuario", pCodUsuario)
            ObjTabelaGenerica.Excluir()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetProximoCodigo() As Long
        Try
            Dim StrSql As String = " select isnull(max(cod_usuario),0) + 1 seq from sysusuario"
            Dim dt As DataTable = ObjAcessoDados.BuscarDados(StrSql)
            If dt.Rows.Count > 0 Then
                Return dt.Rows.Item(0).Item("seq")
            Else
                Return 1
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub FillDropDown(ByRef DDL As DropDownList, ByVal AdicionarRegistroEmBranco As Boolean, ByVal DescricaoRegistroEmBranco As String, ByVal CodRegistroEmBranco As String, ByVal IncluirPendentes As Boolean, ByVal CodAnalista As String, ByVal CodAnalistaMaster As String)
        Dim strSql As String = ""
        Dim dt, dt2 As DataTable

        strSql += " select convert(text,a.cod_usuario) cod_usuario, a.nome_usuario nome "
        strSql += "   from sysusuario a "
        strSql += "  where 1 = 1 "
        If Not String.IsNullOrEmpty(CodAnalistaMaster) Then
            strSql += "  and ( exists( select 1 from sysusuario where email_master = 'S' and cod_usuario = " + CodAnalistaMaster + " ) or a.cod_usuario = " + CodAnalistaMaster + ")"
        End If
        strSql += "  order by nome "
        dt = ObjAcessoDados.BuscarDados(strSql)

        If AdicionarRegistroEmBranco Then
            If Not String.IsNullOrEmpty(CodAnalistaMaster) Then
                dt2 = ObjAcessoDados.BuscarDados("select if exists( select 1 from sysusuario where email_master = 'S' and cod_usuario = " + CodAnalistaMaster + " ) then  1 else 0 endif valor from dummy")
                If dt2.Rows.Count > 0 Then
                    If dt2.Rows.Item(0).Item("valor") = 1 Then
                        Dim NovaLinha As DataRow = dt.NewRow
                        NovaLinha("cod_usuario") = CodRegistroEmBranco
                        If String.IsNullOrEmpty(DescricaoRegistroEmBranco) Then
                            DescricaoRegistroEmBranco = " "
                        End If
                        NovaLinha("nome") = DescricaoRegistroEmBranco
                        dt.Rows.InsertAt(NovaLinha, 0)
                    End If
                End If
            Else
                Dim NovaLinha As DataRow = dt.NewRow
                NovaLinha("cod_usuario") = CodRegistroEmBranco
                If String.IsNullOrEmpty(DescricaoRegistroEmBranco) Then
                    DescricaoRegistroEmBranco = " "
                End If
                NovaLinha("nome") = DescricaoRegistroEmBranco
                dt.Rows.InsertAt(NovaLinha, 0)
            End If
        End If

        If IncluirPendentes Then
            Dim NovaLinha As DataRow = dt.NewRow
            NovaLinha("cod_usuario") = "-9"
            NovaLinha("nome") = "(Pendentes)"
            dt.Rows.InsertAt(NovaLinha, 0)
        End If

        DDL.DataSource = dt
        DDL.DataTextField = "nome"
        DDL.DataValueField = "cod_usuario"
        DDL.DataBind()
    End Sub

End Class
