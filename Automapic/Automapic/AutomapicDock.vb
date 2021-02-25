Imports System.Windows.Forms

''' <summary>
''' Designer class of the dockable window add-in. It contains user interfaces that
''' make up the dockable window.
''' </summary>}
Public Class AutomapicDock

    Public Sub New(ByVal hook As Object)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.Hook = hook
    End Sub


    Private m_hook As Object
    ''' <summary>
    ''' Host object of the dockable window
    ''' </summary> 
    Public Property Hook() As Object
        Get
            Return m_hook
        End Get
        Set(ByVal value As Object)
            m_hook = value
        End Set
    End Property

    ''' <summary>
    ''' Implementation class of the dockable window add-in. It is responsible for
    ''' creating and disposing the user interface class for the dockable window.
    ''' </summary>
    Public Class AddinImpl
        Inherits ESRI.ArcGIS.Desktop.AddIns.DockableWindow

        Private m_windowUI As AutomapicDock

        Protected Overrides Function OnCreateChild() As System.IntPtr
            m_windowUI = New AutomapicDock(Me.Hook)
            Return m_windowUI.Handle
        End Function

        Protected Overrides Sub Dispose(ByVal Param As Boolean)
            If m_windowUI IsNot Nothing Then
                m_windowUI.Dispose(Param)
            End If

            MyBase.Dispose(Param)
        End Sub

    End Class



    Private Sub AutomapicDock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim loginForm As Form = New Login()
        openFormByName(loginForm, pnl_main)
        'Carga opciones al combo box de modulos
        'Dim dictionary As New Dictionary(Of Integer, String)
        'Dictionary.Add(1, "Peligros geologicos")
        'Dictionary.Add(2, "Plano Topográfico 25000")
        'cb_modulos.DataSource = New BindingSource(dictionary, Nothing)
        'cb_modulos.DisplayMember = "Value"
        'cb_modulos.ValueMember = "Key"
    End Sub

    Private Sub AutomapicDock_resizeEnd(sender As Object, e As EventArgs) Handles MyBase.Resize
        'Permite cambiar el size del formulario en funcion del DockableWindow
        Dim numberControls As Integer = pnl_main.Controls.Count()
        If (numberControls) Then
            Dim control = pnl_main.Controls.Item(0)
            Try
                control.Size = pnl_main.Size
                control.Update()
            Catch ex As Exception
                MessageBox.Show(ex.Message())
            End Try
        End If
    End Sub


End Class