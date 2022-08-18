Imports Sybase.DataWindow
Imports Sybase.DataWindow.Web

Partial Public Class WFRelNegociacaoProdutoRel
    Inherits System.Web.UI.Page

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

    Private ReadOnly Property pCanalVenda() As String
        Get
            Return Request.QueryString.Item("canal")
        End Get
    End Property

    Private ReadOnly Property pCodItem() As String
        Get
            Return Request.QueryString.Item("item")
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
        Dim CodItem As String
        Dim sqlca = New Sybase.DataWindow.Transaction

        strFilePath = HttpContext.Current.Server.MapPath("/")
        strFilePath = strFilePath & DirVirtual & "reports/resultsCRM.pbl"
        strFilePath = Replace(strFilePath, "/", "\")
        WDWRelatorio.LibraryList = strFilePath

        WDWRelatorio.DataWindowObject = "dw_rel_negociacao_produto"

        sqlca.Dbms = Sybase.DataWindow.DbmsType.Odbc
        sqlca.DbParameter = "ConnectString='" + StrConexao + "'"
        sqlca.Connect()
        WDWRelatorio.SetTransaction(sqlca)

        Data1 = pData1
        Data2 = pData2
        Empresa = Session("GlEmpresa")
        CodAgenteVendas = pAgente
        CodCanalVendas = pCanalVenda
        CodItem = pCodItem

        Resultado = WDWRelatorio.Retrieve(Empresa, CodAgenteVendas, CodCanalVendas, Data1, Data2, CodItem)
        If Resultado = 0 Then
            LblErro.Text = "Não foram localizadas informações."
        End If
        sqlca.Disconnect()
    End Sub

End Class