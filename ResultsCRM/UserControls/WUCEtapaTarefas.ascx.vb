Partial Public Class WUCETapaTarefas
    Inherits System.Web.UI.UserControl
    Private _Acao As String
    Private _CodEtapa As String
    Public Property Acao() As String
        Get
            Return _Acao
        End Get
        Set(ByVal value As String)
            _Acao = value
        End Set
    End Property
    Public Property CodEtapa() As String
        Get
            Return _CodEtapa
        End Get
        Set(ByVal value As String)
            _CodEtapa = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Call CarregaFormulario()
        End If

    End Sub

    Private Sub CarregaFormulario()
        Dim objTarefa As New UCLTarefaPadrao
        Dim objEtapaTarefas As New UCLEtapaTarefaPadrao
        Dim objEtapa As New UCLEtapaNegociacao
        Dim tarefas As New List(Of String)

        LblCodigo.Text = CodEtapa

        objEtapa.Empresa = Session("GlEmpresa")
        objEtapa.Codigo = CodEtapa
        objEtapa.Buscar()

        LblDescricao.Text = objEtapa.Descricao

        SqlDataSource1.Select(DataSourceSelectArguments.Empty)
        SqlDataSource1.DataBind()
        GridView1.DataBind()

    End Sub

    Protected Sub BtnGravar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGravar.Click
        Dim objEtapaTarefas As New UCLEtapaTarefaPadrao
        Try
            objEtapaTarefas.Empresa = Session("GlEmpresa")
            objEtapaTarefas.CodEtapa = CodEtapa
            Call CarregaObjeto(objEtapaTarefas)
            objEtapaTarefas.GravarTarefas()
            Response.Redirect("WGEtapaNegociacao.aspx")
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try
    End Sub
    Protected Function CarregaObjeto(ByRef objEtapaTarefas As UCLEtapaTarefaPadrao) As UCLEtapaTarefaPadrao
        Try
            Dim tarefas As New List(Of String)
            Dim sequencias As New List(Of String)
            Dim chk As CheckBox
            Dim txt As TextBox
            Dim sequenciasdistintas As New List(Of String)

            For Each row As GridViewRow In GridView1.Rows
                If row.RowType = DataControlRowType.DataRow Then
                    chk = CType(row.FindControl("ChkSelecionado1"), CheckBox)
                    txt = CType(row.FindControl("TxtSequencia1"), TextBox)
                    If chk.Checked Then
                        tarefas.Add(chk.ToolTip)
                        sequencias.Add(txt.Text)
                    End If

                    chk = CType(row.FindControl("ChkSelecionado2"), CheckBox)
                    txt = CType(row.FindControl("TxtSequencia2"), TextBox)
                    If chk.Checked Then
                        tarefas.Add(chk.ToolTip)
                        sequencias.Add(txt.Text.Trim)
                    End If
                End If
            Next

            If sequencias.Contains("") Then
                Throw New Exception("Preencha a sequência de todas as tarefas selecionadas")
            End If

            For Each seq As String In sequencias
                If Not IsNumeric(seq) Then
                    Throw New Exception("Preencha corretamente o campo sequência. O conteúdo " + Chr(34) + seq + Chr(34) + " não é válido")
                Else
                    If Not sequenciasdistintas.Contains(seq) Then
                        sequenciasdistintas.Add(seq)
                    Else
                        Throw New Exception("Você informou a sequência " + Chr(34) + seq + Chr(34) + " mais de uma vez.")
                    End If
                End If
            Next

            objEtapaTarefas.Tarefas = tarefas
            objEtapaTarefas.Sequencias = sequencias

            Return objEtapaTarefas
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    
    Protected Sub BtnVoltar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnVoltar.Click
        Try
            Response.Redirect("WGEtapaNegociacao.aspx")
        Catch ex As Exception
            LblErro.Text = ex.Message.ToString
        End Try

    End Sub
End Class