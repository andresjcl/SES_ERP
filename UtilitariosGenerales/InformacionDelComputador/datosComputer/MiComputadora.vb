Public Class MiComputadora            
    Public Function estaEnRed() As Boolean
        Return My.Computer.Network.IsAvailable
    End Function
End Class
