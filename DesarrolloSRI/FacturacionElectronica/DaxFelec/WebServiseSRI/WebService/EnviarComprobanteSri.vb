Imports System.Xml
Imports System.Text

Public Class EnviarComprobanteSri
    Dim pathError As String

    Public Function sendComprobanteSRI(ByVal fileName As String, ByVal clave As String, ByVal pathAutorizado As String, ByVal pathNoAutorizados As String) As Boolean
        Dim ws As New WebService.WebServicesSRI
        Dim autorizado As Boolean = False
        Dim errores As New List(Of String)
        Dim eror As String
        '--------------------------------------------------------------------------------------------
        pathError = pathNoAutorizados.Replace("XML", "err")
        pathError = pathError.Replace("xml", "err")
        Try
            If ws.sendComprobante(fileName) = True Then
                If ws.AutorizacionComprobante.IsAutorizado = True Then
                    autorizado = True
                    Dim aut As WebService.Autorizacion = ws.AutorizacionComprobante.Autorizacion
                    '--------------------------------------------------------------------------------
                    Dim util As New adcFeutil.Feutilidad()
                    util.ActualizarDocumentoAdcom("Autorizado", "", "", 0, clave, aut.NumeroAutorizacion, 0, aut.FechaAutorizacion)
                    'System.IO.File.Copy(fileName, pathAutorizado, True)
                    GuardarArchivoAutorizado(aut, pathAutorizado)
                    'MsgBox(String.Format("Clave de Acceso:{1}{0}Tipo Emision:{2}{0}Numero Autorizacion:{3}{0}Fecha Autorizacion:{4}{0}", vbCrLf, ws.ClaveAcceso, ws.TipoEmision, aut.NumeroAutorizacion, aut.FechaAutorizacion))
                    '--------------------------------------------------------------------------------                    
                    aut = Nothing
                ElseIf ws.AutorizacionComprobante.NumeroComprobantes > 0 Then
                    System.IO.File.Copy(fileName, pathNoAutorizados, True)
                    For Each mensaje As WebService.Mensaje In ws.AutorizacionComprobante.Autorizacion.Mensajes
                        eror = mensaje.Mensaje + vbCr + mensaje.InformacionAdicional
                        errores.Add(eror)
                    Next
                End If
            ElseIf ws.RecepcionComprobante.NumeroComprobantes > 0 Then
                System.IO.File.Copy(fileName, pathNoAutorizados, True)
                For Each mensaje As WebService.Mensaje In ws.RecepcionComprobante.Comprobante.Mensajes
                    eror = mensaje.Mensaje + vbCr + mensaje.InformacionAdicional
                    errores.Add(eror)
                Next
            ElseIf ws.IsOnLine = False Then
                System.IO.File.Copy(fileName, pathNoAutorizados, True)
                '                grabarMensajes("No existe conexión con los servicios Web del SRI " + Now.ToLongDateString)
                eror = "ERROR: No existe conexión con los servicios Web del SRI " + Now.ToLongDateString
                errores.Add(eror)
            End If
            '----------------------------------------------------------------------------------------
        Catch ex As Exception
            'MsgBox(ex.Message, MsgBoxStyle.Critical)
            eror = ex.Message + " " + Now.ToLongDateString
            errores.Add(eror)
        End Try

        '--------------------------------------------------------------------------------------------

        If autorizado = False Then
            If errores.Count > 0 Then grabarMensajes(errores)
        Else
            Try
                'System.IO.File.Delete(fileName)
            Catch ee As Exception
                errores.Add("Excepcion eliminando firmado: " & ee.Message)
                grabarMensajes(errores)
            End Try
        End If
        ws = Nothing
        Return autorizado
    End Function

    Private Sub grabarMensajes(mensajes As List(Of String))
        Dim file As New System.IO.StreamWriter(pathError)

        For Each Mensaje As String In mensajes
            file.WriteLine(Mensaje)
        Next

        file.Flush()
        file.Close()
        file = Nothing

    End Sub

    Private Sub GuardarArchivoAutorizado(ByVal comprobante As Autorizacion, ByVal outpahFile As String)
        Dim info As New System.IO.FileInfo(outpahFile)
        '---------------------------------------------------------------------------------------------
        'verifico si existe el directorio
        '---------------------------------------------------------------------------------------------
        If info.Directory.Exists = True Then
            Dim writer As New XmlTextWriter(outpahFile, New UTF8Encoding(True))
            '-----------------------------------------------------------------------------------------
            writer.WriteProcessingInstruction("xml", "version=""1.0"" encoding=""utf-8""")
            '-----------------------------------------------------------------------------------------
            writer.WriteStartElement("autorizacion")
            '-----------------------------------------------------------------------------------------
            writer.WriteElementString("estado", comprobante.Estado)
            '-----------------------------------------------------------------------------------------
            writer.WriteElementString("numeroAutorizacion", comprobante.NumeroAutorizacion)
            '-----------------------------------------------------------------------------------------
            writer.WriteStartElement("fechaAutorizacion")
            writer.WriteAttributeString("class", "fechaAutorizacion")
            writer.WriteString(comprobante.FechaAutorizacion)
            writer.WriteEndElement()
            '-----------------------------------------------------------------------------------------
            writer.WriteStartElement("comprobante")
            writer.WriteCData(comprobante.Comprobante)
            writer.WriteEndElement()
            '-----------------------------------------------------------------------------------------
            writer.WriteEndElement()
            '-----------------------------------------------------------------------------------------
            writer.Flush()
            writer.Close()
            '-----------------------------------------------------------------------------------------
            writer = Nothing
        End If
        '---------------------------------------------------------------------------------------------
        info = Nothing
    End Sub
End Class
