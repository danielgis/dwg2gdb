Imports System.Windows.Forms
Imports ESRI.ArcGIS.ArcMapUI
Imports ESRI.ArcGIS.Carto
Imports ESRI.ArcGIS.Catalog
Imports ESRI.ArcGIS.Framework
'Imports ESRI.ArcGIS.ArcMapUI
'Imports ESRI.ArcGIS.Carto
'Imports System.Linq

Public Class Form_plano_topografico_25k
    Dim RuntimeError As AutomapicExceptions = New AutomapicExceptions()
    Dim params As New List(Of Object)
    'Public m_application As IApplication
    Private Sub Form_plano_topografico_25k_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        params.Clear()
        Dim response = ExecuteGP(_tool_getComponentCodeSheet, params, _toolboxPath_plano_topografico, True)
        response = Split(response, ";")
        'Si ocurrio un error durante el proceso este devuelve el primer valor como 0
        'Se imprime el error como PythonError
        If response(0) = 0 Then
            RuntimeError.PythonError = response(2)
            Throw RuntimeError
        End If

        Dim filas = response(2).ToString()
        filas = filas.Replace(" ", "")
        Dim filas_arr = filas.Split(",")

        For Each i In filas_arr
            cbx_fila.Items.Add(i)
        Next

        'Carga opciones al combo box de modulos
        'Dim dictionary As New Dictionary(Of Integer, String)
        'Dictionary.Add(1, "Peligros geologicos")
        'Dictionary.Add(2, "Plano Topográfico 25000")
        'cbx_modulos.DataSource = New BindingSource(dictionary, Nothing)
        'cbx_modulos.DisplayMember = "Value"
        'cbx_modulos.ValueMember = "Key"
    End Sub
    Private Sub cbx_fila_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbx_fila.SelectedIndexChanged
        params.Clear()
        cbx_columna.Items.Clear()
        cbx_cuad.Items.Clear()
        cbx_orien.Items.Clear()
        Dim fila As String = cbx_fila.SelectedItem.ToString()
        params.Add(fila)
        Dim response = ExecuteGP(_tool_getComponentCodeSheet, params, _toolboxPath_plano_topografico)
        response = Split(response, ";")
        'Si ocurrio un error durante el proceso este devuelve el primer valor como 0
        'Se imprime el error como PythonError
        If response(0) = 0 Then
            RuntimeError.PythonError = response(2)
            Throw RuntimeError
        End If

        Dim columnas = response(2).ToString()
        columnas = columnas.Replace(" ", "")
        Dim columnas_arr = columnas.Split(",")

        For Each i In columnas_arr
            cbx_columna.Items.Add(i)
        Next

    End Sub
    Private Sub cbx_columna_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbx_columna.SelectedIndexChanged
        params.Clear()
        cbx_cuad.Items.Clear()
        cbx_orien.Items.Clear()
        Dim fila As String = cbx_fila.SelectedItem.ToString()
        Dim columna As String = cbx_columna.SelectedItem.ToString()
        params.Add(fila)
        params.Add(columna)
        Dim response = ExecuteGP(_tool_getComponentCodeSheet, params, _toolboxPath_plano_topografico)
        response = Split(response, ";")
        'Si ocurrio un error durante el proceso este devuelve el primer valor como 0
        'Se imprime el error como PythonError
        If response(0) = 0 Then
            RuntimeError.PythonError = response(2)
            Throw RuntimeError
        End If

        Dim cuadriculas = response(2).ToString()
        cuadriculas = cuadriculas.Replace(" ", "")
        Dim cuadriculas_arr = cuadriculas.Split(",")

        For Each i In cuadriculas_arr
            cbx_cuad.Items.Add(i)
        Next
    End Sub

    Private Sub cbx_cuad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbx_cuad.SelectedIndexChanged
        params.Clear()
        cbx_orien.Items.Clear()
        Dim fila As String = cbx_fila.SelectedItem.ToString()
        Dim columna As String = cbx_columna.SelectedItem.ToString()
        Dim cuadrante As String = cbx_cuad.SelectedItem.ToString()
        params.Add(fila)
        params.Add(columna)
        params.Add(cuadrante)
        Dim response = ExecuteGP(_tool_getComponentCodeSheet, params, _toolboxPath_plano_topografico)
        response = Split(response, ";")
        'Si ocurrio un error durante el proceso este devuelve el primer valor como 0
        'Se imprime el error como PythonError
        If response(0) = 0 Then
            RuntimeError.PythonError = response(2)
            Throw RuntimeError
        End If

        Dim orientacion = response(2).ToString()
        orientacion = orientacion.Replace(" ", "")
        Dim orientacion_arr = orientacion.Split(",")

        For Each i In orientacion_arr
            cbx_orien.Items.Add(i)
        Next
    End Sub

    Private Sub btn_generar_mapa_Click(sender As Object, e As EventArgs) Handles btn_generar_mapa.Click
        Dim pMxDoc As IMxDocument
        'Dim pMxApp As IMxApplication
        Dim pMap As IMap


        pMxDoc = My.ArcMap.Application.Document
        pMap = pMxDoc.FocusMap
        pMap.MapScale = 25000
        Dim rutaPlantilla As String = "C:\daniel\proyectos\ingemmet\OS13012021\mapa_topografico_25k\dev\mxd\T0218.mxd"
        Dim rutaLayout As IGxFile = New GxMap
        rutaLayout.Path = rutaPlantilla
        Dim pGxPageLayout As IGxMapPageLayout
        pGxPageLayout = rutaLayout
        Dim pPageLayout As IPageLayout
        pPageLayout = pGxPageLayout.PageLayout
        pPageLayout.ReplaceMaps(pMxDoc.Maps)
        pMxDoc.PageLayout = pPageLayout
        pMxDoc.ActiveView = pMxDoc.PageLayout
        Dim pGC As IGraphicsContainer = pMxDoc.PageLayout
        Dim pMapFrame1 As IMapFrame = pGC.FindFrame(pMap)
        pMapFrame1.MapScale = 25000
        pMapFrame1.ExtentType = esriExtentTypeEnum.esriExtentScale
        Dim pagina As IPageLayout
        pagina = pMxDoc.PageLayout
        pMxDoc.UpdateContents()
        'Dim pMapDoc As IMapDocument = New MapDocument()

        'Dim pGxFile As IGxFile
        'Set pGxFile = New GxMap
        'pGxFile.Path = "C:\daniel\proyectos\ingemmet\OS13012021\mapa_topografico_25k\dev\mxd\T0218.mxd"

        ' Dim pGxPageLayout As IGxMapPageLayout
        'Set pGxPageLayout = pGxFile

        'Dim pPageLayout As IPageLayout
        'Set pPageLayout = pGxPageLayout.PageLayout

        'Dim pMxDoc As IMxDocument
        'Set pMxDoc = ThisDocument
        'pPageLayout.ReplaceMaps pMxDoc.Maps

        'Set pMxDoc.PageLayout = pPageLayout
    End Sub
End Class