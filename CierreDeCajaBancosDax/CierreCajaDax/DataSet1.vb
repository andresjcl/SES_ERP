

Partial Public Class DataSet1
    Partial Public Class DataTable2DataTable
        Private Sub DataTable2DataTable_ColumnChanging(sender As Object, e As DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.UsuarioColumn.ColumnName) Then
                'Agregar código de usuario aquí
            End If

        End Sub

    End Class

    Partial Class DataTable1DataTable

    End Class

End Class
