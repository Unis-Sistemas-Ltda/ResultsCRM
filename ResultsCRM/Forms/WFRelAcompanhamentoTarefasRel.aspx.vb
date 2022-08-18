Imports Sybase.DataWindow
Imports Sybase.DataWindow.Web

Partial Public Class WFRelAcompanhamentoTarefasRel
    Inherits System.Web.UI.Page

    Private ReadOnly Property pEmpresa() As String
        Get
            Return Request.QueryString.Item("emp")
        End Get
    End Property

    Private ReadOnly Property pResponsavel() As String
        Get
            Return Request.QueryString.Item("resp")
        End Get
    End Property

    Private ReadOnly Property pCliente() As String
        Get
            Return Request.QueryString.Item("cli")
        End Get
    End Property

    Private ReadOnly Property pStatusTarefa() As String
        Get
            Return Request.QueryString.Item("sts")
        End Get
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Empresa As Integer
        Dim Resultado As Integer
        Dim strFilePath As String
        Dim CodResponsavel As Integer
        Dim CodCliente As Integer
        Dim StatusTarefa As String
        
        Dim sqlca = New Sybase.DataWindow.Transaction

        strFilePath = HttpContext.Current.Server.MapPath("/")
        strFilePath = strFilePath & DirVirtual & "reports/resultsCRM.pbl"
        strFilePath = Replace(strFilePath, "/", "\")
        WDWRelatorio.LibraryList = strFilePath

        WDWRelatorio.DataWindowObject = "dw_rel_acompanhamento_tarefa"

        sqlca.Dbms = Sybase.DataWindow.DbmsType.Odbc
        sqlca.DbParameter = "ConnectString='" + StrConexao + "'"
        sqlca.Connect()
        WDWRelatorio.SetTransaction(sqlca)

        If String.IsNullOrWhiteSpace(pEmpresa) Then
            Empresa = Session("GlEmpresa")
        Else
            Empresa = pEmpresa
        End If

        If String.IsNullOrWhiteSpace(pResponsavel) OrElse Not IsNumeric(pResponsavel) Then
            CodResponsavel = 0
        Else
            CodResponsavel = pResponsavel
        End If

        If String.IsNullOrWhiteSpace(pCliente) OrElse Not IsNumeric(pCliente) Then
            CodCliente = 0
        Else
            CodCliente = pCliente
        End If

        If String.IsNullOrWhiteSpace(pStatusTarefa) Then
            StatusTarefa = "T"
        Else
            StatusTarefa = pStatusTarefa
        End If

        Resultado = WDWRelatorio.Retrieve(Empresa, CodCliente, CodResponsavel, StatusTarefa)

        If Resultado = 0 Then
            LblErro.Text = "Não foram localizadas informações."
        End If
        sqlca.Disconnect()
    End Sub

    Protected Sub BtnImprimir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnImprimir.Click

    End Sub
End Class