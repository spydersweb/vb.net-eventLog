Imports System.Diagnostics

<CLSCompliant(True)>
Public Class EventLogger

    Private _message As String

    Public Property message()
        Get
            Return _message
        End Get
        Set(value)
            _message &= value & vbCrLf
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Function WriteToEventLog(ByVal entry As String, _
                                    Optional ByVal appName As String = "PHM", _
                                    Optional ByVal eventType As EventLogEntryType = EventLogEntryType.Information, _
                                    Optional ByVal logName As String = "Product name") As Boolean

        Dim objectEventLog As New EventLog
        Try
            'Register the Application as an Event Source
            If Not EventLog.SourceExists(appName) Then
                EventLog.CreateEventSource(appName, logName)
            End If

            ' log the entry
            objectEventLog.Source = appName
            objectEventLog.WriteEntry(entry, eventType)
            Return True

        Catch ex As Exception
            Return False

        End Try
    End Function
End Class
