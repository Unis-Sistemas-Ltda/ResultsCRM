Imports Sybase.DataWindow
Imports Sybase.DataWindow.Web

Partial Public Class WFRelNegociacaoFunilReport
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
        Dim CodAgenteVendas As Integer
        Dim CodCanalVendas As Integer
        Dim CodEtapaI As Integer
        Dim CodEtapaF As Integer
        Dim CodItem As String
        Dim CodStatus As Integer
        Dim CodRepresentante As Integer
        
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

        ReportViewer1.DataBind()
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Response.Redirect("WFRelNegociacaoFunil.aspx")
    End Sub
End Class