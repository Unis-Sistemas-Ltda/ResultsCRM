Imports Sybase.DataWindow
Imports Sybase.DataWindow.Web

Partial Public Class WFRelNegociacaoFunilRel
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

    Private ReadOnly Property pEtapaInicial() As String
        Get
            Return Request.QueryString.Item("etapai")
        End Get
    End Property

    Private ReadOnly Property pEtapaFinal() As String
        Get
            Return Request.QueryString.Item("etapaf")
        End Get
    End Property

    Private ReadOnly Property pAgenteVenda() As String
        Get
            Return Request.QueryString.Item("agente")
        End Get
    End Property

    Private ReadOnly Property pCodCanalVenda() As String
        Get
            Return Request.QueryString.Item("canal")
        End Get
    End Property

    Private ReadOnly Property pCodStatus() As String
        Get
            Return Request.QueryString.Item("status")
        End Get
    End Property

    Private ReadOnly Property pCodRepresentante() As String
        Get
            Return Request.QueryString.Item("representante")
        End Get
    End Property

    Private ReadOnly Property pCodItem() As String
        Get
            Return Request.QueryString.Item("item")
        End Get
    End Property

    Private ReadOnly Property Modelo() As String
        Get
            Return Request.QueryString.Item("mod")
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
        Dim CodEtapaI As Integer
        Dim CodEtapaF As Integer
        Dim CodItem As String
        Dim CodStatus As Integer
        Dim CodRepresentante As Integer
        Dim sqlca = New Sybase.DataWindow.Transaction

        strFilePath = HttpContext.Current.Server.MapPath("/")
        strFilePath = strFilePath & DirVirtual & "reports/resultsCRM.pbl"
        strFilePath = Replace(strFilePath, "/", "\")

        WDWRelatorio.LibraryList = strFilePath
        If Modelo = "1" Then
            WDWRelatorio.DataWindowObject = "dw_rel_negociacoes_por_etapa"
        ElseIf Modelo = "2" Then
            WDWRelatorio.DataWindowObject = "dw_rel_historico_negociacao"
        End If


        sqlca.Dbms = Sybase.DataWindow.DbmsType.Odbc
        sqlca.DbParameter = "ConnectString='" + StrConexao + "'"
        sqlca.Connect()
        WDWRelatorio.SetTransaction(sqlca)

        Data1 = pData1
        Data2 = pData2
        Empresa = Session("GlEmpresa")
        CodEtapaI = pEtapaInicial
        CodEtapaF = pEtapaFinal
        CodAgenteVendas = pAgenteVenda
        CodCanalVendas = pCodCanalVenda
        CodStatus = pCodStatus
        CodRepresentante = pCodRepresentante
        CodItem = pCodItem

        Resultado = WDWRelatorio.Retrieve(Empresa, Data1, Data2, CodEtapaI, CodEtapaF, CodStatus, CodAgenteVendas, CodRepresentante, CodCanalVendas, CodItem)
        If Resultado = 0 Then
            lblErro.Text = "Não foram localizadas informações."
        End If
        sqlca.Disconnect()
    End Sub

End Class