Partial Public Class WFPItemReferenciaLote
    Inherits System.Web.UI.Page
    Dim Controle As String
    Dim Comando As String
    Dim Sequencia As Long


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Controle = Request.QueryString("textbox").ToString

         If Not IsPostBack
            SqlDataSource1.Select(DataSourceSelectArguments.Empty)
            SqlDataSource1.DataBind()
            GridView1.DataBind()
        End If

        MultiViewExpanse.ActiveViewIndex = 0
    End Sub

    'Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
    '    Dim argumentos As String()
    '    If e.CommandName = "SELECIONAR" Then
    '        argumentos = Split(e.CommandArgument, ";")
    '        Session("SAlterouCodItem") = "S"
    '        Session("SCodItemPesquisado") = argumentos(0)
    '        Session("SReferenciaPesquisada") = argumentos(1)
    '        ClientScript.RegisterStartupScript(Me.GetType(), "onload", "onSuccess();", True)
    '    End If
    'End Sub


    Protected Sub btnOkay_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnOkay.Click
        Try
            If Gravar() Then
                'Response.Redirect("WGNegociacaoItem.aspx")
                MultiViewExpanse.ActiveViewIndex = 0
                ClientScript.RegisterStartupScript(Me.GetType(), "onload", "onSuccess();", True)
            End If
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
        'Try
        '    MultiViewExpanse.ActiveViewIndex = 0
        '    'ClientScript.RegisterStartupScript(Me.GetType(), "onload", "onSuccess();", True)

        'Catch ex As Exception

        '    ClientScript.RegisterStartupScript(Me.GetType(), "onload", "onError();", True)
        '    MultiViewExpanse.ActiveViewIndex = 0
        'End Try
    End Sub

    Private Function Gravar() As Boolean
        Try
            Dim objNegociacaoItem As New UCLNegociacaoItem(StrConexaoUsuario(Session("GlUsuario")))
            If IsDigitacaoOK() Then

                For Each row As GridViewRow In GridView1.Rows
                    Dim cb As CheckBox = row.FindControl("CheckBox1")
                   
                    If cb IsNot Nothing AndAlso cb.Checked Then
                        Call CarregaNovaPK()
                        objNegociacaoItem.CodNegociacao = Session("SCodNegociacao")
                        objNegociacaoItem.Empresa = Session("GlEmpresa")
                        objNegociacaoItem.Estabelecimento = Session("GlEstabelecimento")
                        objNegociacaoItem.SeqItem = Sequencia
                        objNegociacaoItem.Buscar()
                        objNegociacaoItem.CodItem = Session("ItemLote")
                        objNegociacaoItem.Lote = row.Cells(1).Text
                        objNegociacaoItem.Quantidade = row.Cells(3).Text.Replace(".", ",")
                        objNegociacaoItem.QuantidadeUD = objNegociacaoItem.Quantidade
                        objNegociacaoItem.PrecoUnitario = CDbl(TxtPrecoUnitario.Text)
                        objNegociacaoItem.PrecoUnitarioUD = CDbl(objNegociacaoItem.PrecoUnitario)
                        'objNegociacaoItem.CodUnidade = DdlUD.SelectedValue
                        'objNegociacaoItem.Narrativa = TxtNarrativa.Text.GetValidInputContent
                        objNegociacaoItem.AliquotaIPI = 0
                        objNegociacaoItem.AliquotaICMS = 0
                        objNegociacaoItem.BaseICMSSubstituicao = 0
                        objNegociacaoItem.ICMSST = 0
                        objNegociacaoItem.IPI = 0
                        objNegociacaoItem.ValorTotal = CDbl(TxtPrecoUnitario.Text.Replace(".", ",")) * CDbl(objNegociacaoItem.Quantidade)
                        objNegociacaoItem.CodNaturOper = Session("CodNatOp")
                        objNegociacaoItem.ICMS = 0
                        objNegociacaoItem.ValorDesconto = 0
                        objNegociacaoItem.ValorMercadoria = objNegociacaoItem.ValorTotal
                        'objNegociacaoItem = CarregaObjeto(objNegociacaoItem)
                        objNegociacaoItem.Incluir()
                    End If
                   
                Next
               

                Return True
            End If
            Return False
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Function

    Private Sub CarregaNovaPK()
        Dim objNegociacao As New UCLNegociacao(StrConexaoUsuario(Session("GlUsuario")))
        Dim objNegociacaoItem As New UCLNegociacaoItem(StrConexaoUsuario(Session("GlUsuario")))
        objNegociacaoItem.Empresa = Session("GlEmpresa")
        objNegociacaoItem.Estabelecimento = Session("GlEstabelecimento")
        objNegociacaoItem.CodNegociacao = Session("SCodNegociacao")
        Sequencia = objNegociacaoItem.GetProximoCodigo

        objNegociacao.Empresa = Session("GlEmpresa")
        objNegociacao.Estabelecimento = Session("GlEstabelecimento")
        objNegociacao.CodNegociacao = Session("SCodNegociacao")
        objNegociacao.Buscar()
       
    End Sub

   
    Private Function GetTotalOpcionais() As Double
        Try
            Dim StrSql As String = "select isnull(sum(n.preco_total),0) tot_opc" + _
                                    " from negociacao_cliente_item_estrutura n" + _
                                   " where n.empresa                = " + Session("GlEmpresa") + _
                                     " and n.estabelecimento        = " + Session("GlEstabelecimento") + _
                                     " and n.cod_negociacao_cliente = " + Session("SCodNegociacao") + _
                                     " and n.seq_item               = " + Sequencia
            Dim ObjAcessoDados As New UCLAcessoDados(StrConexao)
            Dim dt As DataTable = ObjAcessoDados.BuscarDados(StrSql)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt.Rows.Item(0).Item("tot_opc")) Then
                    Return 0
                Else
                    Return CDbl(dt.Rows.Item(0).Item("tot_opc"))
                End If
            Else
                Return 0
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function IsDigitacaoOK()
        If String.IsNullOrEmpty(TxtPrecoUnitario.Text) Then
            LblErro.Text += "Preencha o campo Valor do lote.<br/>"
        End If

        If TxtPrecoUnitario.Text <= 0 Then
            LblErro.Text += "O total do item deve ser maior que R$ 0,00.<br/>"
        End If


        Return LblErro.Text = ""
    End Function

    Protected Sub OnRowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim cell As String = e.Row.Cells(2).Text

            If cell IsNot Nothing Then
                If cell <> "&nbsp;" Then
                    Dim cb As CheckBox = e.Row.FindControl("CheckBox1")
                    cb.Enabled = False
                End If
            End If

        End If
    End Sub
End Class