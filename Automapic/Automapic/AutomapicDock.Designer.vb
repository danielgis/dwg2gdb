<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AutomapicDock
    Inherits System.Windows.Forms.UserControl

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.pnl_main = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        'pnl_main
        '
        Me.pnl_main.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_main.Location = New System.Drawing.Point(0, 0)
        Me.pnl_main.Name = "pnl_main"
        Me.pnl_main.Size = New System.Drawing.Size(400, 700)
        Me.pnl_main.TabIndex = 0
        '
        'AutomapicDock
        '
        Me.Controls.Add(Me.pnl_main)
        Me.Name = "AutomapicDock"
        Me.Size = New System.Drawing.Size(400, 700)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnl_main As System.Windows.Forms.Panel
End Class
