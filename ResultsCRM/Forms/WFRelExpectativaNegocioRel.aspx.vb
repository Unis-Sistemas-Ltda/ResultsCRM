Imports Sybase.DataWindow
Imports Sybase.DataWindow.Web

Partial Public Class WFRelExpectativaNegocioRel
    Inherits System.Web.UI.Page

    Private ReadOnly Property pModelo() As String
        Get
            Return Request.QueryString.Item("modelo")
        End Get
    End Property

    Private ReadOnly Property pData1() As String
        Get
            Return Request.QueryString.Item("data1")
        End Get
    End Property

    Private ReadOnly Property pData2() As String
        Get
            Return Request.QueryString.Item("data2")
        End Get
    End Property

    Private ReadOnly Property pAgente() As String
        Get
            Return Request.QueryString.Item("agente")
        End Get
    End Property

    Private ReadOnly Property pCanal() As String
        Get
            Return Request.QueryString.Item("canal")
        End Get
    End Property

    Private ReadOnly Property pSituacao() As String
        Get
            Return Request.QueryString.Item("situacao")
        End Get
    End Property

    Private ReadOnly Property pCidade() As String
        Get
            Return Request.QueryString.Item("cidade")
        End Get
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Data1 As Date
        Dim Data2 As Date
        Dim Empresa As Integer
        Dim Resultado As Integer
        Dim strFilePath As String
        Dim CodAgenteVendas As Integer
        Dim CodCanalVendas As Integer
        Dim CodStatus As Integer
        Dim Modelo As String
        Dim Cidade As String
        Dim sqlca = New Sybase.DataWindow.Transaction

        strFilePath = HttpContext.Current.Server.MapPath("/")
        strFilePath = strFilePath & DirVirtual & "reports/resultsCRM.pbl"
        strFilePath = Replace(strFilePath, "/", "\")
        WDWRelatorio.LibraryList = strFilePath

        Modelo = pModelo

        If Modelo = "A" Then
            WDWRelatorio.DataWindowObject = "dw_rel_espectativa_negocio_analitico"
        Else
            WDWRelatorio.DataWindowObject = "dw_rel_espectativa_negocio_sintetico"
        End If

        sqlca.Dbms = Sybase.DataWindow.DbmsType.Odbc
        sqlca.DbParameter = "ConnectString='" + StrConexao + "'"
        sqlca.Connect()
        WDWRelatorio.SetTransaction(sqlca)

        Data1 = pData1
        Data2 = pData2
        Empresa = Session("GlEmpresa")
        CodAgenteVendas = pAgente
        CodCanalVendas = pCanal
        CodStatus = pSituacao
        Cidade = pCidade

        If String.IsNullOrEmpty(Cidade) Then
            Cidade = ""
        End If

        Resultado = WDWRelatorio.Retrieve(Empresa, CodAgenteVendas, CodCanalVendas, CodStatus, Cidade, Data1, Data2)

        If Resultado = 0 Then
            lblErro.Text = "Não foram localizadas informações."
        End If
        sqlca.Disconnect()
    End Sub

    Protected Sub BtnImprimir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnImprimir.Click

    End Sub
End Class