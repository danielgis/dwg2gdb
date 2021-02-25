<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Login
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
        Me.tlp_login = New System.Windows.Forms.TableLayoutPanel()
        Me.tbx_user = New System.Windows.Forms.TextBox()
        Me.tbx_pass = New System.Windows.Forms.TextBox()
        Me.lbl_user = New System.Windows.Forms.Label()
        Me.lbl_pass = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btn_login = New System.Windows.Forms.Button()
        Me.tlp_login.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tlp_login
        '
        Me.tlp_login.ColumnCount = 5
        Me.tlp_login.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10.0!))
        Me.tlp_login.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlp_login.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250.0!))
        Me.tlp_login.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlp_login.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10.0!))
        Me.tlp_login.Controls.Add(Me.tbx_user, 2, 3)
        Me.tlp_login.Controls.Add(Me.tbx_pass, 2, 5)
        Me.tlp_login.Controls.Add(Me.lbl_user, 2, 2)
        Me.tlp_login.Controls.Add(Me.lbl_pass, 2, 4)
        Me.tlp_login.Controls.Add(Me.PictureBox1, 2, 1)
        Me.tlp_login.Controls.Add(Me.btn_login, 2, 6)
        Me.tlp_login.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlp_login.Location = New System.Drawing.Point(0, 0)
        Me.tlp_login.Name = "tlp_login"
        Me.tlp_login.RowCount = 9
        Me.tlp_login.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.tlp_login.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.tlp_login.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlp_login.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlp_login.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlp_login.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlp_login.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.tlp_login.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_login.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10.0!))
        Me.tlp_login.Size = New System.Drawing.Size(530, 493)
        Me.tlp_login.TabIndex = 0
        '
        'tbx_user
        '
        Me.tbx_user.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbx_user.Location = New System.Drawing.Point(143, 223)
        Me.tbx_user.Name = "tbx_user"
        Me.tbx_user.Size = New System.Drawing.Size(244, 22)
        Me.tbx_user.TabIndex = 0
        '
        'tbx_pass
        '
        Me.tbx_pass.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbx_pass.Location = New System.Drawing.Point(143, 273)
        Me.tbx_pass.Name = "tbx_pass"
        Me.tbx_pass.Size = New System.Drawing.Size(244, 22)
        Me.tbx_pass.TabIndex = 1
        Me.tbx_pass.UseSystemPasswordChar = True
        '
        'lbl_user
        '
        Me.lbl_user.AutoSize = True
        Me.lbl_user.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lbl_user.Location = New System.Drawing.Point(143, 203)
        Me.lbl_user.Name = "lbl_user"
        Me.lbl_user.Size = New System.Drawing.Size(244, 17)
        Me.lbl_user.TabIndex = 2
        Me.lbl_user.Text = "Usuario"
        '
        'lbl_pass
        '
        Me.lbl_pass.AutoSize = True
        Me.lbl_pass.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lbl_pass.Location = New System.Drawing.Point(143, 253)
        Me.lbl_pass.Name = "lbl_pass"
        Me.lbl_pass.Size = New System.Drawing.Size(244, 17)
        Me.lbl_pass.TabIndex = 3
        Me.lbl_pass.Text = "Contraseña"
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Image = Global.Automapic.My.Resources.Resources.user
        Me.PictureBox1.Location = New System.Drawing.Point(143, 53)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(244, 144)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'btn_login
        '
        Me.btn_login.BackColor = System.Drawing.Color.FromArgb(CType(CType(144, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.btn_login.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_login.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btn_login.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(144, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.btn_login.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_login.ForeColor = System.Drawing.Color.Black
        Me.btn_login.Location = New System.Drawing.Point(143, 303)
        Me.btn_login.Name = "btn_login"
        Me.btn_login.Size = New System.Drawing.Size(244, 29)
        Me.btn_login.TabIndex = 5
        Me.btn_login.Text = "Ingresar"
        Me.btn_login.UseVisualStyleBackColor = False
        '
        'Login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(530, 493)
        Me.Controls.Add(Me.tlp_login)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Login"
        Me.Text = "Login"
        Me.tlp_login.ResumeLayout(False)
        Me.tlp_login.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tlp_login As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tbx_user As System.Windows.Forms.TextBox
    Friend WithEvents tbx_pass As System.Windows.Forms.TextBox
    Friend WithEvents lbl_user As System.Windows.Forms.Label
    Friend WithEvents lbl_pass As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btn_login As System.Windows.Forms.Button
End Class
