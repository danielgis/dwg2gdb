<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_plano_topografico_25k
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
        Me.tlp_plano_topografico = New System.Windows.Forms.TableLayoutPanel()
        Me.cbx_fila = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbx_cuadrante = New System.Windows.Forms.Label()
        Me.cbx_orientacion = New System.Windows.Forms.Label()
        Me.cbx_columna = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbx_cuad = New System.Windows.Forms.ComboBox()
        Me.cbx_orien = New System.Windows.Forms.ComboBox()
        Me.btn_generar_mapa = New System.Windows.Forms.Button()
        Me.btn_export = New System.Windows.Forms.Button()
        Me.tlp_plano_topografico.SuspendLayout()
        Me.SuspendLayout()
        '
        'tlp_plano_topografico
        '
        Me.tlp_plano_topografico.ColumnCount = 7
        Me.tlp_plano_topografico.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlp_plano_topografico.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlp_plano_topografico.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlp_plano_topografico.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlp_plano_topografico.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlp_plano_topografico.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlp_plano_topografico.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlp_plano_topografico.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlp_plano_topografico.Controls.Add(Me.cbx_fila, 0, 2)
        Me.tlp_plano_topografico.Controls.Add(Me.Label1, 0, 1)
        Me.tlp_plano_topografico.Controls.Add(Me.Label2, 2, 1)
        Me.tlp_plano_topografico.Controls.Add(Me.cbx_cuadrante, 4, 1)
        Me.tlp_plano_topografico.Controls.Add(Me.cbx_orientacion, 6, 1)
        Me.tlp_plano_topografico.Controls.Add(Me.cbx_columna, 2, 2)
        Me.tlp_plano_topografico.Controls.Add(Me.Label5, 1, 2)
        Me.tlp_plano_topografico.Controls.Add(Me.Label6, 3, 2)
        Me.tlp_plano_topografico.Controls.Add(Me.cbx_cuad, 4, 2)
        Me.tlp_plano_topografico.Controls.Add(Me.cbx_orien, 6, 2)
        Me.tlp_plano_topografico.Controls.Add(Me.btn_generar_mapa, 4, 4)
        Me.tlp_plano_topografico.Controls.Add(Me.btn_export, 0, 4)
        Me.tlp_plano_topografico.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlp_plano_topografico.Location = New System.Drawing.Point(0, 0)
        Me.tlp_plano_topografico.Name = "tlp_plano_topografico"
        Me.tlp_plano_topografico.RowCount = 7
        Me.tlp_plano_topografico.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10.0!))
        Me.tlp_plano_topografico.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlp_plano_topografico.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlp_plano_topografico.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10.0!))
        Me.tlp_plano_topografico.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.tlp_plano_topografico.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_plano_topografico.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlp_plano_topografico.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlp_plano_topografico.Size = New System.Drawing.Size(470, 677)
        Me.tlp_plano_topografico.TabIndex = 0
        '
        'cbx_fila
        '
        Me.cbx_fila.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbx_fila.FormattingEnabled = True
        Me.cbx_fila.Location = New System.Drawing.Point(3, 33)
        Me.cbx_fila.Name = "cbx_fila"
        Me.cbx_fila.Size = New System.Drawing.Size(96, 24)
        Me.cbx_fila.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label1.Location = New System.Drawing.Point(3, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 17)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Fila"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label2.Location = New System.Drawing.Point(125, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 17)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Columna"
        '
        'cbx_cuadrante
        '
        Me.cbx_cuadrante.AutoSize = True
        Me.cbx_cuadrante.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.cbx_cuadrante.Location = New System.Drawing.Point(247, 13)
        Me.cbx_cuadrante.Name = "cbx_cuadrante"
        Me.cbx_cuadrante.Size = New System.Drawing.Size(96, 17)
        Me.cbx_cuadrante.TabIndex = 1
        Me.cbx_cuadrante.Text = "Cuadrante"
        '
        'cbx_orientacion
        '
        Me.cbx_orientacion.AutoSize = True
        Me.cbx_orientacion.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.cbx_orientacion.Location = New System.Drawing.Point(369, 13)
        Me.cbx_orientacion.Name = "cbx_orientacion"
        Me.cbx_orientacion.Size = New System.Drawing.Size(98, 17)
        Me.cbx_orientacion.TabIndex = 0
        Me.cbx_orientacion.Text = "Orientación"
        '
        'cbx_columna
        '
        Me.cbx_columna.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbx_columna.FormattingEnabled = True
        Me.cbx_columna.Location = New System.Drawing.Point(125, 33)
        Me.cbx_columna.Name = "cbx_columna"
        Me.cbx_columna.Size = New System.Drawing.Size(96, 24)
        Me.cbx_columna.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(105, 36)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(14, 17)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "-"
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(227, 36)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(14, 17)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "-"
        '
        'cbx_cuad
        '
        Me.cbx_cuad.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbx_cuad.FormattingEnabled = True
        Me.cbx_cuad.Location = New System.Drawing.Point(247, 33)
        Me.cbx_cuad.Name = "cbx_cuad"
        Me.cbx_cuad.Size = New System.Drawing.Size(96, 24)
        Me.cbx_cuad.TabIndex = 9
        '
        'cbx_orien
        '
        Me.cbx_orien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbx_orien.FormattingEnabled = True
        Me.cbx_orien.Location = New System.Drawing.Point(369, 33)
        Me.cbx_orien.Name = "cbx_orien"
        Me.cbx_orien.Size = New System.Drawing.Size(98, 24)
        Me.cbx_orien.TabIndex = 10
        '
        'btn_generar_mapa
        '
        Me.btn_generar_mapa.BackColor = System.Drawing.Color.FromArgb(CType(CType(144, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.tlp_plano_topografico.SetColumnSpan(Me.btn_generar_mapa, 3)
        Me.btn_generar_mapa.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Me.btn_generar_mapa.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btn_generar_mapa.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.btn_generar_mapa.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_generar_mapa.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btn_generar_mapa.Location = New System.Drawing.Point(247, 73)
        Me.btn_generar_mapa.Name = "btn_generar_mapa"
        Me.btn_generar_mapa.Size = New System.Drawing.Size(220, 29)
        Me.btn_generar_mapa.TabIndex = 11
        Me.btn_generar_mapa.Text = "Generar mapa"
        Me.btn_generar_mapa.UseVisualStyleBackColor = False
        Me.btn_generar_mapa.UseWaitCursor = True
        '
        'btn_export
        '
        Me.tlp_plano_topografico.SetColumnSpan(Me.btn_export, 3)
        Me.btn_export.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_export.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btn_export.Enabled = False
        Me.btn_export.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_export.Location = New System.Drawing.Point(3, 73)
        Me.btn_export.Name = "btn_export"
        Me.btn_export.Size = New System.Drawing.Size(218, 29)
        Me.btn_export.TabIndex = 12
        Me.btn_export.Text = "Exportar Datos"
        Me.btn_export.UseVisualStyleBackColor = True
        '
        'Form_plano_topografico_25k
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.AutoScrollMinSize = New System.Drawing.Size(0, 500)
        Me.ClientSize = New System.Drawing.Size(470, 677)
        Me.Controls.Add(Me.tlp_plano_topografico)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Form_plano_topografico_25k"
        Me.Text = "Plano topográfico 25000"
        Me.tlp_plano_topografico.ResumeLayout(False)
        Me.tlp_plano_topografico.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tlp_plano_topografico As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents cbx_fila As System.Windows.Forms.ComboBox
    Friend WithEvents cbx_columna As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbx_orientacion As System.Windows.Forms.Label
    Friend WithEvents cbx_cuadrante As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cbx_cuad As System.Windows.Forms.ComboBox
    Friend WithEvents cbx_orien As System.Windows.Forms.ComboBox
    Friend WithEvents btn_generar_mapa As System.Windows.Forms.Button
    Friend WithEvents btn_export As System.Windows.Forms.Button
End Class
