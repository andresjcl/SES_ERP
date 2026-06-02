Option Explicit On

Imports System
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.Drawing.Printing

Namespace RichTextBoxPrintCtrl
    Public Class RichTextBoxPrintCtrl
        Inherits RichTextBox ' Convertir la unidad que usa .NET framework (1/100 de pulgada) ' y la unidad que usan las llamadas a la API Win32 (twips 1/1440 de pulgada) 
        Private Const AnInch As Double = 14.4

        <StructLayout(LayoutKind.Sequential)>
        Private Structure RECT
            Public Left As Integer
            Public Top As Integer
            Public Right As Integer
            Public Bottom As Integer
        End Structure

        <StructLayout(LayoutKind.Sequential)> _
        Private Structure CHARRANGE
            Public cpMin As Integer          ' Primer caracter del intervalo (0 para el principio del documento ) 
            Public cpMax As Integer          ' Último carácter del intervalo (-1 para el final del documento) 
        End Structure

        <StructLayout(LayoutKind.Sequential)> _
        Private Structure FORMATRANGE
            Public hdc As IntPtr             ' DC real en el que dibujar 
            Public hdcTarget As IntPtr       ' DC de destino para determinar el formato de texto 
            Public rc As RECT                ' Región del DC para dibujar (en twips)
            Public rcPage As RECT            ' Zona de todo el DC (tamaño de la página) (en twips) 
            Public chrg As CHARRANGE         ' Intervalo del texto para dibujar (vea la declaración anterior) 
        End Structure

        Private Const WM_USER As Integer = &H400
        Private Const EM_FORMATRANGE As Integer = WM_USER + 57

        Private Declare Function SendMessage Lib "USER32" Alias "SendMessageA" (ByVal hWnd As IntPtr, ByVal msg As Integer, ByVal wp As IntPtr, ByVal lp As IntPtr) As IntPtr

        ' Procesar el contenido del RichTextBox para imprimir '	Devolver el último carácter impreso + 1 (la impresión empieza desde este punto para la siguiente página)
        Public Function Print(ByVal charFrom As Integer, ByVal charTo As Integer, ByVal e As PrintPageEventArgs) As Integer

            ' Marcar el carácter inicial y final 
            Dim cRange As CHARRANGE
            cRange.cpMin = charFrom
            cRange.cpMax = charTo

            ' Calcular el área que procesar e imprimir 
            Dim rectToPrint As RECT
            rectToPrint.Top = e.MarginBounds.Top * AnInch
            rectToPrint.Bottom = e.MarginBounds.Bottom * AnInch
            rectToPrint.Left = e.MarginBounds.Left * AnInch
            rectToPrint.Right = e.MarginBounds.Right * AnInch

            ' Calcular el tamaño de la página 
            Dim rectPage As RECT
            rectPage.Top = e.PageBounds.Top * AnInch
            rectPage.Bottom = e.PageBounds.Bottom * AnInch
            rectPage.Left = e.PageBounds.Left * AnInch
            rectPage.Right = e.PageBounds.Right * AnInch

            Dim hdc As IntPtr = e.Graphics.GetHdc()

            Dim fmtRange As FORMATRANGE
            fmtRange.chrg = cRange                 ' Indicar carácter desde y hasta 
            fmtRange.hdc = hdc                     ' Usar el mismo DC para medir y procesar 
            fmtRange.hdcTarget = hdc               ' Señalar a la impresora hDC 
            fmtRange.rc = rectToPrint              ' Indicar el área de la página que imprimir 
            fmtRange.rcPage = rectPage             ' Indicar todo el tamaño de la página

            Dim res As IntPtr = IntPtr.Zero

            Dim wparam As IntPtr = IntPtr.Zero
            wparam = New IntPtr(1)

            ' Mover el puntero a la estructura FORMATRANGE en la memoria
            Dim lparam As IntPtr = IntPtr.Zero
            lparam = Marshal.AllocCoTaskMem(Marshal.SizeOf(fmtRange))
            Marshal.StructureToPtr(fmtRange, lparam, False)

            ' Enviar los datos procesados para imprimir 
            res = SendMessage(Handle, EM_FORMATRANGE, wparam, lparam)

            ' Liberar el bloque de memoria asignada  
            Marshal.FreeCoTaskMem(lparam)

            ' Liberar el identificador del contexto de dispositivo obtenido en una llamada anterior 
            e.Graphics.ReleaseHdc(hdc)

            ' Devolver la impresora con el último carácter + 1
            Return res.ToInt32()
        End Function

    End Class
End Namespace
