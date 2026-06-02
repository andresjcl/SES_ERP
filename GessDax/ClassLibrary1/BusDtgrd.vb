Imports System.Windows.Forms
Public Class BusDtgrd
    Public Function Buscar(ByVal TextoABuscar As String, ByVal Columna As String, ByRef grid As DataGridView, ByVal tipo As Integer, ByRef ultimaLineaVista As Integer, Optional ByVal primero As Boolean = False) As Boolean
        Dim encontrado As Boolean = False
        Dim cell As DataGridViewCell
        Dim row As DataGridViewRow
        'Static ultimaLineaVista As Integer
        Dim ultimaColumnaVista As Integer
        Dim Buscador As String = ""
        If (TextoABuscar = String.Empty) Then Return False
        If (grid.RowCount = 0) Then Return False
        grid.ClearSelection()
        If tipo = 0 Then ultimaLineaVista = 0 : ultimaColumnaVista = 0 Else ultimaLineaVista = ultimaLineaVista + 1
        If (Columna = String.Empty) Then
            For Each row In grid.Rows
                If (row.Index >= ultimaLineaVista Or ultimaLineaVista = 0) Then
                    For Each cell In row.Cells
                        If primero Then
                            Buscador = UCase(TextoABuscar) & "*"
                        Else
                            Buscador = "*" & UCase(TextoABuscar) & "*"
                        End If
                        If (UCase(cell.Value.ToString()) Like Buscador) = True Then
                            ultimaLineaVista = cell.RowIndex
                            ultimaColumnaVista = cell.ColumnIndex
                            If (cell.Displayed <> True) Then
                                grid.FirstDisplayedScrollingRowIndex = ultimaLineaVista
                                grid.FirstDisplayedScrollingColumnIndex = ultimaColumnaVista
                            End If
                            cell.Selected = True
                            grid.Focus()
                            Return True
                        End If
                    Next
                End If
            Next
        Else
            If ultimaLineaVista >= grid.RowCount - 1 Then ultimaLineaVista = 0
            For Each row In grid.Rows
                If (row.Index >= ultimaLineaVista) Then
                    If primero Then
                        Buscador = UCase(TextoABuscar) & "*"
                    Else
                        Buscador = "*" & UCase(TextoABuscar) & "*"
                    End If
                    If (UCase(row.Cells(Columna).Value.ToString()) Like Buscador) Then
                        ultimaLineaVista = row.Cells(Columna).RowIndex
                        ultimaColumnaVista = row.Cells(Columna).ColumnIndex
                        If row.Cells(Columna).Displayed <> True Then
                            grid.FirstDisplayedScrollingRowIndex = ultimaLineaVista
                            grid.FirstDisplayedScrollingColumnIndex = ultimaColumnaVista
                        End If
                        row.Cells(Columna).Selected = True
                        grid.Focus()
                        Return True
                    End If
                End If
            Next
        End If
        Return encontrado
    End Function

End Class
