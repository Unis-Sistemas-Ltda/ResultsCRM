Imports System.Web.Mail
Public Class UCLEmail
    Public Sub envia_email(ByVal pEmpresa As String, ByVal asSMTP As String, ByVal AsFrom As String, ByVal AsTo As String, ByVal AsSubject As String, ByVal AsCorpo As String, ByVal AsPassword As String, ByVal AsPorta As String, ByVal AsSSL As String, ByVal asAnexo As String)
        Dim ObjMailMessage As New System.Net.Mail.MailMessage
        Dim anexos As String()

        GravaLog("UCLEmail - envia_email 1")

        ObjMailMessage.From = New System.Net.Mail.MailAddress(AsFrom.ToString())
        ObjMailMessage.To.Add(AsTo)
        ObjMailMessage.Subject = AsSubject
        ObjMailMessage.Body = AsCorpo
        ObjMailMessage.Priority = System.Net.Mail.MailPriority.Normal
        ObjMailMessage.IsBodyHtml = True
        '//Para evitar problemas de caracteres "estranhos", configuramos o charset para "ISO-8859-1" 
        ObjMailMessage.SubjectEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1")
        ObjMailMessage.BodyEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1")

        If Not String.IsNullOrEmpty(asAnexo) Then
            asAnexo = asAnexo.Replace(";", ",")
            If asAnexo.Contains(",") Then
                anexos = asAnexo.Split(",")
                For i As Integer = 0 To anexos.Length - 1
                    ObjMailMessage.Attachments.Add(New System.Net.Mail.Attachment(anexos(i)))
                Next
            Else
                ObjMailMessage.Attachments.Add(New System.Net.Mail.Attachment(asAnexo))
            End If
        End If


        'cria objeto com os dados do SMTP 
        Dim objSmtp As New System.Net.Mail.SmtpClient

        'Definimos o host -- Endereço do smtp
        objSmtp.Host = asSMTP

        If Not String.IsNullOrEmpty(AsPorta) Then
            objSmtp.Port = AsPorta
        End If

        If Not String.IsNullOrEmpty(AsSSL) Then
            objSmtp.EnableSsl = IIf(AsSSL = "S", "True", "False")
        End If

        objSmtp.UseDefaultCredentials = UseDefaultCredentials(pEmpresa)

        '//Definimos a credenciais a serem utilizados
        objSmtp.Credentials = New System.Net.NetworkCredential(AsFrom, AsPassword)

        '//enviamos o e-mail através do método .send() 
        GravaLog("UCLEmail - envia_email 2")
        objSmtp.Send(ObjMailMessage)
        GravaLog("UCLEmail - envia_email 3")
    End Sub

End Class
