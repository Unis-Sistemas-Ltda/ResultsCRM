Imports Sybase.DataWindow
Imports Sybase.DataWindow.Web
Imports System.Linq

Partial Public Class WFRelAcoesColaborador
    Inherits System.Web.UI.Page
    Dim objAcessoDados As New UCLAcessoDados

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Call CarregaFunil()
            Call CarregaEtapa()
            Call CarregaUsuario()
            Call CarregaCanalVenda()
            Call CarregaGrid()
        End If

    End Sub

    Private Sub CarregaFunil()
        Dim objFunil As New UCLFunilVenda
        objFunil.FillDropDown(ddlFunil, True, "(Todos)", Session("GlEmpresa"), Session("GlCodUsuario"))
    End Sub

    Private Sub CarregaEtapa()
        Dim objEtapaNegociacao As New UCLEtapaNegociacao
        objEtapaNegociacao.Empresa = Session("GlEmpresa")
        objEtapaNegociacao.FillDropDown(ddlEtapa, True, "(Todas)")
    End Sub

    Private Sub CarregaUsuario()
        Dim objUsuario As New UCLUsuario
        objUsuario.FillControl(LbxUsuario, True, "(Todos)")
        LbxUsuario.SelectedValue = "0"
    End Sub

    Private Sub CarregaCanalVenda()
        Dim objCanalVenda As New UCLCanalVenda
        objCanalVenda.Empresa = Session("GlEmpresa")
        objCanalVenda.FillControl(LbxCanalVenda, True, "(Todos)")
        LbxCanalVenda.SelectedValue = "0"
    End Sub

    Protected Sub BtnOk_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnOk.Click
        CarregaGrid()
    End Sub

    Protected Sub CarregaGrid()
        Dim strSql As String = ""
        Dim dt As DataTable
        Dim dataIni As String = ValidaCampo("TxtData1", TxtData1.Text)
        Dim dataFim As String = ValidaCampo("TxtData2", TxtData2.Text)
        Dim canais As String = ValidaCampo("LbxCanalVenda", LbxCanalVenda.SelectedValue)
        Dim usuarios As String = ValidaCampo("LbxUsuario", LbxUsuario.SelectedValue)

        strSql += "select tt.nome_usuario usuario, tt.descricao descricao,count(tt.cod_acao) qtd_acao, count(distinct(tt.cod_emitente)) qtd_empresa FROM ( "

        strSql += "select s.nome_usuario, a.descricao,f.cod_acao, f.cod_emitente, n.cod_negociacao_cliente, f.seq_follow_up, f.cod_usuario "

        strSql += "from follow_up_emitente f "
        strSql += "inner join acao_follow_up a on a.cod_acao = f.cod_acao "
        strSql += "inner join negociacao_cliente n on f.empresa = n.empresa "
        strSql += "                               and f.cod_negociacao_cliente = n.cod_negociacao_cliente "
        strSql += "                               and f.cod_negociacao_cliente = n.cod_negociacao_cliente "
        strSql += "inner join emitente e on n.cod_emitente = e.cod_emitente "
        strSql += "inner join sysusuario s on f.cod_usuario = s.cod_usuario "
        strSql += "where n.empresa = " + Session("GlEmpresa")
        strSql += " and f.data_follow_up between '" + dataIni + "' and '" + dataFim + "'"
        If Not String.IsNullOrEmpty(TxtEmitente.Text) Then
            strSql += " and e.nome like '%" + TxtEmitente.Text + "%'"
        End If
        If ddlEtapa.SelectedValue <> 0 Then
            strSql += " and n.cod_etapa = " + ddlEtapa.SelectedValue
        End If
        If ddlFunil.SelectedValue <> 0 Then
            strSql += " and n.cod_funil = " + ddlFunil.SelectedValue
        End If
        If LbxUsuario.SelectedValue <> 0 Then
            strSql += " and f.cod_usuario in (" + usuarios + ")"
        End If
        If LbxCanalVenda.SelectedValue <> 0 Then
            strSql += " and n.cod_canal_venda in (" + canais + ")"
        End If
        strSql += " UNION ALL "

        strSql += "select s.nome_usuario, a.descricao,f.cod_acao, e.cod_emitente, f.cod_chamado, f.seq_follow_up, f.cod_usuario  "

        strSql += "from follow_up_chamado f "
        strSql += "inner join acao_follow_up a on a.cod_acao = f.cod_acao "
        strSql += "inner join sysusuario s on f.cod_usuario = s.cod_usuario "
        strSql += "inner Join chamado c on c.empresa = f.empresa "
        strSql += "                    And c.cod_chamado = f.cod_chamado "
        strSql += "inner Join emitente e On e.cod_emitente = c.cod_emitente "
        strSql += "left outer join negociacao_cliente n On f.empresa = n.empresa "
        strSql += "                               And f.cod_chamado = n.cod_chamado "
        strSql += "where f.empresa = " + Session("GlEmpresa")

        strSql += " and f.data_follow_up between '" + dataIni + "' and '" + dataFim + "'"
        If Not String.IsNullOrEmpty(TxtEmitente.Text) Then
            strSql += " and e.nome like '%" + TxtEmitente.Text + "%'"
        End If
        If ddlEtapa.SelectedValue <> 0 Then
            strSql += " and n.cod_etapa = " + ddlEtapa.SelectedValue
        End If
        If ddlFunil.SelectedValue <> 0 Then
            strSql += " and n.cod_funil = " + ddlFunil.SelectedValue
        End If
        If LbxUsuario.SelectedValue <> 0 Then
            strSql += " and f.cod_usuario in (" + usuarios + ")"
        End If
        If LbxCanalVenda.SelectedValue <> 0 Then
            strSql += " and n.cod_canal_venda in (" + canais + ")"
        End If
        strSql += " ) as tt"
        strSql += " group by tt.nome_usuario, tt.cod_acao, tt.descricao, tt.nome_usuario"
        strSql += " order by tt.nome_usuario, tt.descricao"

        dt = objAcessoDados.BuscarDados(strSql)

        Dim user As String
        Dim sum As Integer = 0

        For Each item As DataRow In dt.Rows
            If user = item("usuario").ToString Then
                item("usuario") = ""
            Else
                user = item("usuario")
                sum = 0
                For Each x As DataRow In dt.Rows
                    If user = x("usuario") Then
                        sum += x("qtd_acao")
                    End If
                Next
                item("usuario") = user + " - Total de Ações: " + sum.ToString()
            End If
        Next

        GridView1.DataSource = dt
        GridView1.DataBind()
    End Sub

    Private Function ValidaCampo(ByVal nomeCampo As String, conteudo As String) As String
        Try
            Dim retorno As String = ""
            Dim controle As New ListBox
            Dim hoje As New Date
            Dim dataIni As New Date
            Dim dataFim As New Date
            Dim nextDataMonth As New Date
            hoje = DateTime.Now.ToString("yyyy-MM-dd")
            dataIni = New DateTime(hoje.Year, hoje.Month, 1)
            nextDataMonth = dataIni.AddMonths(1)
            dataFim = nextDataMonth.AddDays(-1)

            Select Case nomeCampo
                Case "TxtData1"
                    If String.IsNullOrWhiteSpace(conteudo) Then
                        Return dataIni.ToString("yyyy-MM-dd")
                    Else
                        Return CDate(conteudo).ToString("yyyy-MM-dd")
                    End If
                Case "TxtData2"
                    If String.IsNullOrWhiteSpace(conteudo) Then
                        Return dataFim.ToString("yyyy-MM-dd")
                    Else
                        Return CDate(conteudo).ToString("yyyy-MM-dd")
                    End If
                Case "LbxCanalVenda", "LbxUsuario"
                    If nomeCampo = "LbxCanalVenda" Then
                        controle = LbxCanalVenda
                    ElseIf nomeCampo = "LbxUsuario" Then
                        controle = LbxUsuario
                    End If
                    For Each item As ListItem In controle.Items
                        If item.Selected Then
                            retorno += item.Value + ","
                        End If
                    Next
                    If retorno.EndsWith(",") Then
                        retorno = Left(retorno, retorno.Length - 1)
                    End If
                    If retorno = "" Then
                        retorno = "0"
                    End If
                    Return retorno
            End Select
            Return conteudo
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class