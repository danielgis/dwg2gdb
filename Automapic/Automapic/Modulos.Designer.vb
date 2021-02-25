<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Modulos
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.tlp_modulos = New System.Windows.Forms.TableLayoutPanel()
        Me.tlp_modulos_controles = New System.Windows.Forms.TableLayoutPanel()
        Me.cbx_modulos = New System.Windows.Forms.ComboBox()
        Me.lbl_modulos = New System.Windows.Forms.Label()
        Me.pbx_modulo_buscar = New System.Windows.Forms.PictureBox()
        Me.pbx_modulo_nuevo = New System.Windows.Forms.PictureBox()
        Me.btn_cerrar_sesion = New System.Windows.Forms.Button()
        Me.pnl_modulos_form = New System.Windows.Forms.Panel()
        Me.tlp_modulos.SuspendLayout()
        Me.tlp_modulos_controles.SuspendLayout()
        CType(Me.pbx_modulo_buscar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbx_modulo_nuevo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tlp_modulos
        '
        Me.tlp_modulos.ColumnCount = 3
        Me.tlp_modulos.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10.0!))
        Me.tlp_modulos.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_modulos.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10.0!))
        Me.tlp_modulos.Controls.Add(Me.tlp_modulos_controles, 1, 1)
        Me.tlp_modulos.Controls.Add(Me.btn_cerrar_sesion, 1, 3)
        Me.tlp_modulos.Controls.Add(Me.pnl_modulos_form, 1, 2)
        Me.tlp_modulos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlp_modulos.Location = New System.Drawing.Point(0, 0)
        Me.tlp_modulos.Name = "tlp_modulos"
        Me.tlp_modulos.RowCount = 5
        Me.tlp_modulos.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10.0!))
        Me.tlp_modulos.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55.0!))
        Me.tlp_modulos.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_modulos.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlp_modulos.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10.0!))
        Me.tlp_modulos.Size = New System.Drawing.Size(474, 618)
        Me.tlp_modulos.TabIndex = 0
        '
        'tlp_modulos_controles
        '
        Me.tlp_modulos_controles.ColumnCount = 3
        Me.tlp_modulos_controles.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_modulos_controles.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.tlp_modulos_controles.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.tlp_modulos_controles.Controls.Add(Me.cbx_modulos, 0, 1)
        Me.tlp_modulos_controles.Controls.Add(Me.lbl_modulos, 0, 0)
        Me.tlp_modulos_controles.Controls.Add(Me.pbx_modulo_buscar, 1, 1)
        Me.tlp_modulos_controles.Controls.Add(Me.pbx_modulo_nuevo, 2, 1)
        Me.tlp_modulos_controles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlp_modulos_controles.Location = New System.Drawing.Point(13, 13)
        Me.tlp_modulos_controles.Name = "tlp_modulos_controles"
        Me.tlp_modulos_controles.RowCount = 2
        Me.tlp_modulos_controles.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlp_modulos_controles.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_modulos_controles.Size = New System.Drawing.Size(448, 49)
        Me.tlp_modulos_controles.TabIndex = 0
        '
        'cbx_modulos
        '
        Me.cbx_modulos.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbx_modulos.FormattingEnabled = True
        Me.cbx_modulos.Location = New System.Drawing.Point(3, 23)
        Me.cbx_modulos.Name = "cbx_modulos"
        Me.cbx_modulos.Size = New System.Drawing.Size(372, 24)
        Me.cbx_modulos.TabIndex = 0
        '
        'lbl_modulos
        '
        Me.lbl_modulos.AutoSize = True
        Me.lbl_modulos.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lbl_modulos.Location = New System.Drawing.Point(3, 3)
        Me.lbl_modulos.Name = "lbl_modulos"
        Me.lbl_modulos.Size = New System.Drawing.Size(372, 17)
        Me.lbl_modulos.TabIndex = 1
        Me.lbl_modulos.Text = "Seleccionar módulo"
        '
        'pbx_modulo_buscar
        '
        Me.pbx_modulo_buscar.BackgroundImage = Global.Automapic.My.Resources.Resources.search
        Me.pbx_modulo_buscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbx_modulo_buscar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbx_modulo_buscar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pbx_modulo_buscar.Enabled = False
        Me.pbx_modulo_buscar.Location = New System.Drawing.Point(381, 23)
        Me.pbx_modulo_buscar.Name = "pbx_modulo_buscar"
        Me.pbx_modulo_buscar.Size = New System.Drawing.Size(29, 23)
        Me.pbx_modulo_buscar.TabIndex = 2
        Me.pbx_modulo_buscar.TabStop = False
        '
        'pbx_modulo_nuevo
        '
        Me.pbx_modulo_nuevo.BackgroundImage = Global.Automapic.My.Resources.Resources.add
        Me.pbx_modulo_nuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbx_modulo_nuevo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbx_modulo_nuevo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pbx_modulo_nuevo.Enabled = False
        Me.pbx_modulo_nuevo.Location = New System.Drawing.Point(416, 23)
        Me.pbx_modulo_nuevo.Name = "pbx_modulo_nuevo"
        Me.pbx_modulo_nuevo.Size = New System.Drawing.Size(29, 23)
        Me.pbx_modulo_nuevo.TabIndex = 3
        Me.pbx_modulo_nuevo.TabStop = False
        '
        'btn_cerrar_sesion
        '
        Me.btn_cerrar_sesion.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_cerrar_sesion.Location = New System.Drawing.Point(386, 581)
        Me.btn_cerrar_sesion.Name = "btn_cerrar_sesion"
        Me.btn_cerrar_sesion.Size = New System.Drawing.Size(75, 24)
        Me.btn_cerrar_sesion.TabIndex = 1
        Me.btn_cerrar_sesion.Text = "Salir"
        Me.btn_cerrar_sesion.UseVisualStyleBackColor = True
        '
        'pnl_modulos_form
        '
        Me.pnl_modulos_form.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_modulos_form.Location = New System.Drawing.Point(13, 68)
        Me.pnl_modulos_form.Name = "pnl_modulos_form"
        Me.pnl_modulos_form.Size = New System.Drawing.Size(448, 507)
        Me.pnl_modulos_form.TabIndex = 2
        '
        'Modulos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(474, 618)
        Me.Controls.Add(Me.tlp_modulos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Modulos"
        Me.Text = "Modulos"
        Me.tlp_modulos.ResumeLayout(False)
        Me.tlp_modulos_controles.ResumeLayout(False)
        Me.tlp_modulos_controles.PerformLayout()
        CType(Me.pbx_modulo_buscar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbx_modulo_nuevo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tlp_modulos As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tlp_modulos_controles As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents cbx_modulos As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_modulos As System.Windows.Forms.Label
    Friend WithEvents pbx_modulo_buscar As System.Windows.Forms.PictureBox
    Friend WithEvents pbx_modulo_nuevo As System.Windows.Forms.PictureBox
    Friend WithEvents btn_cerrar_sesion As System.Windows.Forms.Button
    Friend WithEvents pnl_modulos_form As System.Windows.Forms.Panel
End Class
