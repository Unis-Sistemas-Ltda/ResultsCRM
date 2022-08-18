Imports System.Data
Imports System.Configuration
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Web
Imports System.IO.File
Imports System.IO.FileNotFoundException
Imports System.IO
Imports System.Net
Imports System.Collections
Imports System.Security.Cryptography.X509Certificates
Imports System.Security.Cryptography
Imports System.Security
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Text
Imports System

Partial Public Class WFPreimpressaoProposta
    Inherits System.Web.UI.Page

    Public ReadOnly Property Empresa() As String
        Get
            Return Request.QueryString.Item("eid")
        End Get
    End Property

    Public ReadOnly Property Estabelecimento() As String
        Get
            Return Request.QueryString.Item("sid")
        End Get
    End Property

    Public ReadOnly Property CodNegociacao() As String
        Get
            Return Request.QueryString.Item("nid")
        End Get
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Call GeraPDF()
            If Exists(CaminhoPDF(CodNegociacao)) Then
                Response.Redirect("~/" + DirVirtual + "Tmp/PC-" & CodNegociacao & ".pdf")
            End If
        Catch ex As Exception
        End Try

    End Sub

    Protected Sub GeraPDF()
        Try
            Dim strURL As String
            Dim pdf As New SautinSoft.PdfMetamorphosis()
            Dim htmlString As String

            If File.Exists(CaminhoPDF(codNegociacao)) Then
                File.Delete(CaminhoPDF(codNegociacao))
            End If

            strURL = Publicacao & DirVirtual & "Forms/WFImpressaoProposta.aspx?eid=" + Empresa + "&sid=" + Estabelecimento + "&nid=" + CodNegociacao

            pdf.Serial = "10042729429"
            pdf.PageStyle.PageNumFormat = "Pág. {page} de {numpages}"
            pdf.PageStyle.PageSize.A4()
            pdf.PageStyle.PageOrientation.Portrait()
            htmlString = GetHtmlFromAspx(strURL)

            pdf.HtmlOptions.BaseUrl = Server.MapPath("")
            pdf.HtmlToPdfConvertStringToFile(htmlString, CaminhoPDF(codNegociacao))
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Function CaminhoPDF(ByVal codNegociacao As String) As String
        CaminhoPDF = Server.MapPath("/") & DirVirtual & "Tmp/PC-" & codNegociacao & ".pdf"
    End Function

    Private ReadOnly Property Publicacao() As String
        Get
            Return "http://localhost:53212/"
        End Get
    End Property


End Class