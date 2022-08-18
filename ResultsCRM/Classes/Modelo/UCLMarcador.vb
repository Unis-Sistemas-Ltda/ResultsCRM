Public Class UCLMarcador
    Inherits UCLClasseGenerica

    Public Sub New()
        ObjTabelaGenerica = New UCLTabelaGenerica("marcador", StrConexaoEmail)
    End Sub

    Public Function Buscar(ByVal pEmpresa As String, ByVal pCodMarcador As String) As Boolean
        Try
            Me.SetConteudo("empresa", pEmpresa)
            Me.SetConteudo("cod_marcador", pCodMarcador)
            Return ObjTabelaGenerica.Buscar()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Excluir(ByVal pEmpresa As String, ByVal pCodMarcador As String)
        Try
            Me.SetConteudo("empresa", pEmpresa)
            Me.SetConteudo("cod_marcador", pCodMarcador)
            ObjTabelaGenerica.Excluir()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetProximoCodigo(ByVal pEmpresa As String) As Long
        Try
            Dim StrSql As String = " select isnull(max(cod_marcador),0) + 1 seq from marcador where empresa = " + pEmpresa
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

    Private Function GetDataTableSubnivel(ByVal pEmpresa As String, ByVal pCodMarcador As String) As DataTable
        Try
            Return ObjAcessoDados.BuscarDados("select cod_marcador, descricao from marcador where empresa = " + pEmpresa + " and cod_marcador_pai = " + pCodMarcador + " order by descricao")
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function GetDataTableMarcadores(ByVal pEmpresa As String, ByVal AdicionarRegistroEmBranco As Boolean, ByVal DescricaoRegistroEmBranco As String, ByVal CodRegistroEmBranco As String, ByVal CodMarcadorSelecionado As String, ByVal somenteNivel1 As Boolean)
        Try
            Dim codMarcador As String
            Dim descricaoMarcador As String
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim posI As Long
            Dim posF As Long
            Dim existe As Boolean = True

            strSql += " select cod_marcador, if cod_marcador_pai is not null then '{{' || cod_marcador_pai || '}}/' else '' endif || descricao descricao "
            strSql += "   from marcador "
            strSql += "  where empresa = " + pEmpresa
            If CodMarcadorSelecionado <> "" Then
                strSql += "  and cod_marcador <> " + CodMarcadorSelecionado
            End If
            If somenteNivel1 Then
                strSql += "  and cod_marcador_pai is null"
            End If
            dt = ObjAcessoDados.BuscarDados(strSql)

            If AdicionarRegistroEmBranco Then
                Dim NovaLinha As DataRow = dt.NewRow
                NovaLinha("cod_marcador") = CodRegistroEmBranco
                If String.IsNullOrEmpty(DescricaoRegistroEmBranco) Then
                    DescricaoRegistroEmBranco = " "
                End If
                NovaLinha("descricao") = DescricaoRegistroEmBranco
                dt.Rows.InsertAt(NovaLinha, 0)
            End If

            While existe
                existe = False
                For Each row As DataRow In dt.Rows
                    If row.Item("descricao").ToString.Contains("{{") Then
                        posI = row.Item("descricao").ToString.IndexOf("{{") + 2
                        posF = row.Item("descricao").ToString.IndexOf("}}") - 1
                        codMarcador = row.Item("descricao").ToString.Substring(posI, posF - posI + 1)
                        descricaoMarcador = GetDescricaoParaDataTable(pEmpresa, codMarcador)
                        row.Item("descricao") = row.Item("descricao").ToString.Replace("{{" + codMarcador + "}}", descricaoMarcador)
                        If Not existe Then
                            existe = row.Item("descricao").ToString.Contains("{{")
                        End If
                    End If
                Next
            End While

            dt.DefaultView.Sort = "descricao"

            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub ProcessaSubniveis(ByVal pEmpresa As String, ByVal pCodMarcador As String, ByRef menuItem As MenuItem)
        Try
            Dim dtSub As DataTable
            dtSub = GetDataTableSubnivel(pEmpresa, pCodMarcador)
            For Each rowsub As DataRow In dtSub.Rows
                Dim menuItemSub As New MenuItem
                menuItemSub.Text = rowsub.Item("descricao")
                menuItemSub.Value = rowsub.Item("cod_marcador")
                Call ProcessaSubniveis(pEmpresa, rowsub.Item("cod_marcador"), menuItemSub)
                menuItem.ChildItems.Add(menuItemSub)
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub FillMenu(ByRef menu As Menu, ByVal pEmpresa As String, ByVal AdicionarRegistroEmBranco As Boolean, ByVal DescricaoRegistroEmBranco As String, ByVal CodRegistroEmBranco As String, ByVal CodMarcadorSelecionado As String)
        Try
            Dim menuItem As MenuItem
            Dim dt As DataTable = GetDataTableMarcadores(pEmpresa, AdicionarRegistroEmBranco, DescricaoRegistroEmBranco, CodRegistroEmBranco, CodMarcadorSelecionado, True)

            For Each row As DataRow In dt.Rows
                menuItem = New MenuItem
                menuItem.Text = row.Item("descricao")
                menuItem.Value = row.Item("cod_marcador")
                Call ProcessaSubniveis(pEmpresa, row.Item("cod_marcador"), menuItem)
                menu.Items.Add(menuItem)
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub FillDropDown(ByRef DDL As DropDownList, ByVal pEmpresa As String, ByVal AdicionarRegistroEmBranco As Boolean, ByVal DescricaoRegistroEmBranco As String, ByVal CodRegistroEmBranco As String, ByVal CodMarcadorSelecionado As String)
        Try
            Dim dt As DataTable = GetDataTableMarcadores(pEmpresa, AdicionarRegistroEmBranco, DescricaoRegistroEmBranco, CodRegistroEmBranco, CodMarcadorSelecionado, False)

            DDL.DataSource = dt
            DDL.DataTextField = "descricao"
            DDL.DataValueField = "cod_marcador"
            DDL.DataBind()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function GetDescricaoParaDataTable(ByVal pEmpresa As String, ByVal pCodMarcador As String)
        Try
            Dim StrSql As String = "select if cod_marcador_pai is not null then '{{' || cod_marcador_pai || '}}/' else '' endif || descricao descricao from marcador where empresa = " + pEmpresa + " and cod_marcador = " + pCodMarcador
            Dim dt As DataTable = ObjAcessoDados.BuscarDados(StrSql)
            If dt.Rows.Count > 0 Then
                Return dt.Rows.Item(0).Item("descricao").ToString()
            Else
                Return ""
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
