Imports System.Windows.Forms
Module settings
    '1. Metadata
    '   - Variables que obtienen informacion sobre desarrollo, fecha, etc.

    Public __title__ As String = "Automapic 2021"
    Public __author__ As String = "Daniel Fernando Aguado Huaccharaqui"
    Public __copyright__ As String = "INGEMMET 2021"
    Public __credits__ As String = "Daniel Aguado H."
    Public __version__ As String = "1.0.1"
    Public __maintainer__ As String = __credits__
    Public __mail__ As String = "daguado@ingemmet.gob.pe"
    Public __status__ As String = "Development"

    '2. Variables globales estaticas
    '   - Estas variables no deben ser modificadas durante el proceso
    '   - Su nombre inicia con un guin bajo

    '* _path: Obtiene la ruta actual en donde se almacena la instalacion del addin
    Public _path As String = __file__()

    '3. Variables dinamicas alterables segun fin
    '   - Estas variables solo podran ser alteradas manejandolas dentro del contexto que fueron creados

    '* controller_sesion: Variable que toma valores de {0: "Sin incio de sesion, 1: "Usuario logeado"}
    Public controller_sesion As Integer = 0
    Public python_path As String = ""

    '4. Variables globales dinamicas
    ' - Su valor puede alterarse en todo los procesos

    Public d_contador As Integer = 0
    Public d_standar_output As String

    '5. Funciones globales
    '   - Funciones que devuelven resultados y que puedes ser usados en cualquier parte del proceso

    '* __file__: Obtiene la ruta actual en donde se almacena la instalacion del addin
    '* parametros: No recibe parametros

    Public Function __file__()
        Dim codeBase As String = Reflection.Assembly.GetExecutingAssembly.CodeBase
        Dim uriBuilder As UriBuilder = New UriBuilder(codeBase)
        Dim path As String = Uri.UnescapeDataString(uriBuilder.Path)
        Return IO.Path.GetDirectoryName(path)
    End Function

    Public Function openFormByName(myForm As Form, container As Control)
        Dim existForm As Boolean = container.Controls.Contains(myForm)
        If (existForm) Then
            Return Nothing
        Else
            container.Controls.Clear()
        End If
        myForm.TopLevel = False
        myForm.AutoScroll = True
        myForm.Size = container.Size
        container.Controls.Add(myForm)
        myForm.Show()
        Return Nothing
    End Function

End Module
