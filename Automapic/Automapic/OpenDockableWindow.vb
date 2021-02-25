Imports ESRI.ArcGIS.esriSystem
Imports ESRI.ArcGIS.Framework

Public Class OpenDockableWindow
    Inherits ESRI.ArcGIS.Desktop.AddIns.Button

    Public Sub New()

    End Sub

    Protected Overrides Sub OnClick()
        '
        '  TODO: Sample code showing how to access button host
        '
        Dim dockWinID As UID = New UIDClass()
        dockWinID.Value = My.ThisAddIn.IDs.AutomapicDock
        Dim dockWindow As IDockableWindow = My.ArcMap.DockableWindowManager.GetDockableWindow(dockWinID)
        dockWindow.Show(True)
        My.ArcMap.Application.CurrentTool = Nothing
    End Sub

    Protected Overrides Sub OnUpdate()
        Enabled = My.ArcMap.Application IsNot Nothing
    End Sub
End Class
