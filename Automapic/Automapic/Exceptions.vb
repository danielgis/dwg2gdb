Imports System
Imports System.Reflection.MethodBase

Public Class AutomapicExceptions
    Inherits Exception

    Public Sub New()
    End Sub

    Public Sub New(ByVal message As String)
        MyBase.New(message)
    End Sub

    Public Sub New(ByVal message As String, ByVal inner As Exception)
        MyBase.New(message, inner)
    End Sub

    Dim strExtracrInfo As String

    Public Property PythonError() As String
        Get
            Return strExtracrInfo
        End Get
        Set(value As String)
            strExtracrInfo = "PythonError:" + vbCrLf + value
        End Set
    End Property
    Public Property VisualError() As String
        Get
            Return strExtracrInfo
        End Get
        Set(value As String)
            strExtracrInfo = "VisualError:" + vbCrLf + value
        End Set
    End Property
    Public Property ValidationError() As String
        Get
            Return strExtracrInfo
        End Get
        Set(value As String)
            strExtracrInfo = "ValidationError:" + vbCrLf + value
        End Set
    End Property
    Public ReadOnly Property SigcatminError() As String
        Get
            Return strExtracrInfo
        End Get
    End Property
End Class
