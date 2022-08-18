Public Class UCLTefAdquirente
    Inherits UCLClasseGenerica

    Public Sub New()
        ObjTabelaGenerica = New UCLTabelaGenerica("tef_adquirente")
    End Sub

    Public Function Buscar(ByVal pCodAdquirente As String) As Boolean
        Try
            Me.SetConteudo("cod_adquirente", pCodAdquirente)
            Return ObjTabelaGenerica.Buscar()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Excluir(ByVal pCodAdquirente As String)
        Try
            Me.SetConteudo("cod_adquirente", pCodAdquirente)
            ObjTabelaGenerica.Excluir()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetProximoCodigo() As Long
        Try
            Dim StrSql As String = " select isnull(max(cod_adquirente),0) + 1 seq from tef_adquirente "
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

    Public Sub FillDropDown(ByRef DDL As DropDownList, ByVal AdicionarRegistroEmBranco As Boolean, ByVal DescricaoRegistroEmBranco As String, ByVal pCodRegistroEmBranco As String, ByVal pCodBandeira As String)
        Dim strSql As String = ""
        Dim dt As DataTable

        strSql += " select cod_adquirente codigo, nome_autorizadora nome"
        strSql += "   from tef_adquirente a"
        If Not String.IsNullOrEmpty(pCodBandeira) Then
            strSql += "  where exists(select 1 from tef_adquirente_bandeira tab where tab.cod_adquirente = a.cod_adquirente and tab.cod_bandeira = " + pCodBandeira + ")"
        End If
        strSql += "  order by nome "
        dt = ObjAcessoDados.BuscarDados(strSql)

        If AdicionarRegistroEmBranco Then
            Dim NovaLinha As DataRow = dt.NewRow
            NovaLinha("codigo") = pCodRegistroEmBranco
            If String.IsNullOrEmpty(DescricaoRegistroEmBranco) Then
                DescricaoRegistroEmBranco = " "
            End If
            NovaLinha("nome") = DescricaoRegistroEmBranco
            dt.Rows.InsertAt(NovaLinha, 0)
        End If

        DDL.DataSource = dt
        DDL.DataTextField = "nome"
        DDL.DataValueField = "codigo"
        DDL.DataBind()
    End Sub
End Class
