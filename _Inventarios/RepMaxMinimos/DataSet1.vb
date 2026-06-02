Partial Class DataSet1
    Partial Class DataTable1DataTable

        Private Sub DataTable1DataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.OtrosEgresosColumn.ColumnName) Then

                'Agregar código de usuario aquí
            End If

        End Sub

    End Class

End Class
