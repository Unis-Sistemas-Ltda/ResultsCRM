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

Imports iTextSharp.text.DocumentException
Imports iTextSharp.text.Rectangle
Imports iTextSharp.text.pdf.AcroFields
Imports iTextSharp.text.pdf.PdfPKCS7
Imports iTextSharp.text.pdf.PdfReader
Imports iTextSharp.text.pdf.PdfDocument
Imports iTextSharp.text.pdf.PdfSignatureAppearance
Imports iTextSharp.text.pdf.PdfStamper
Imports iTextSharp.text.pdf
Imports iTextSharp.text

Partial Public Class WFImpressaoPropostaPDF
    Inherits System.Web.UI.Page

    Private ReadOnly pubTeste As String = ""
    Private ReadOnly pubProducao As String = "dehon/"
    Private ReadOnly pubUrl As String = "http://localhost:51735/"
    'Private ReadOnly pubUrl As String = "http://sinamm.no-ip.info/"
    Private ReadOnly ambiente As String = pubTeste

    Private ReadOnly Property Empresa() As String
        Get
            Return Session("GlEmpresa")
        End Get
    End Property

    Private ReadOnly Property Estabelecimento() As String
        Get
            Return Session("SEstabelecimentoNegociacao")
        End Get
    End Property

    Private ReadOnly Property CodNegociacao() As String
        Get
            Return Request.QueryString.Item("nid")
        End Get
    End Property

    Private ReadOnly Property CodClienteUnis() As String
        Get
            Return Request.QueryString.Item("ucid")
        End Get
    End Property

    Private ReadOnly Property ImagemLogo() As String
        Get
            Return Request.QueryString.Item("li")
        End Get
    End Property

    Private ReadOnly Property Pagina() As String
        Get
            Select Case CodClienteUnis
                Case 381
                    Return "WFImpressaoPropostaDehon.aspx?eid=" & Empresa & "&sid=" & Estabelecimento & "&nid=" & CodNegociacao + "&li=" + ImagemLogo
                Case 1, 45, 93, 130, 175, 407
                    Return "WFImpressaoProposta" + CodClienteUnis + ".aspx?eid=" + Empresa + "&sid=" + Estabelecimento + "&nid=" + CodNegociacao + "&li=" + ImagemLogo
                Case Else
                    If Empresa = 1 And Estabelecimento = 3 Then
                        Session("logo_cliente") = "../Imagens/logo_proposta_2.jpg"
                    Else
                        Session("logo_cliente") = "../Imagens/logo_proposta.jpg"
                    End If

                    Return "WFImpressaoProposta130.aspx?eid=" + Empresa + "&sid=" + Estabelecimento + "&nid=" + CodNegociacao + "&li=" + ImagemLogo
            End Select
        End Get
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Call GeraPDF()
        'Response.Redirect(CaminhoPDF())
        Response.Redirect(Pagina)
    End Sub

    Protected Sub GeraPDF()
        Try
            Dim strURL As String
            Dim pdf As New SautinSoft.PdfMetamorphosis()
            Dim htmlString As String

            If File.Exists(CaminhoPDF(CodNegociacao)) Then
                File.Delete(CaminhoPDF(CodNegociacao))
            End If

            strURL = pubUrl & ambiente & "forms/" & Pagina

            pdf.Serial = "10042729429"
            pdf.PageStyle.PageNumFormat = "Página {page} de {numpages}"
            pdf.PageStyle.PageSize.A4()
            pdf.PageStyle.PageOrientation.Portrait()
            htmlString = GetHtmlFromAspx(strURL)

            pdf.HtmlOptions.BaseUrl = Server.MapPath("")
            pdf.HtmlToPdfConvertStringToFile(htmlString, CaminhoPDF())
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Function CaminhoPDF()
        Dim _caminhoPdf As String

        _caminhoPdf = Server.MapPath("/")
        _caminhoPdf += ambiente
        _caminhoPdf += "tmp\nc" & CodNegociacao & ".pdf"

        Return _caminhoPdf
    End Function

End Class