Imports System.Windows.Forms

Public Class Modulos
    Private Sub btn_modulo_nuevo_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btn_cerrar_sesion_Click(sender As Object, e As EventArgs) Handles btn_cerrar_sesion.Click
        Dim LoginForm = New Login()
        openFormByName(LoginForm, Me.Parent)

    End Sub

    Private Sub Modulos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Carga opciones al combo box de modulos
        Dim dictionary As New Dictionary(Of Integer, String)
        dictionary.Add(1, "Peligros geologicos")
        dictionary.Add(2, "Plano Topográfico 25000")
        cbx_modulos.DataSource = New BindingSource(dictionary, Nothing)
        cbx_modulos.DisplayMember = "Value"
        cbx_modulos.ValueMember = "Key"
    End Sub

    Private Sub Modulos_resizeEnd(sender As Object, e As EventArgs) Handles MyBase.Resize
        'Permite cambiar el size del formulario en funcion del DockableWindow
        Dim numberControls As Integer = pnl_modulos_form.Controls.Count()
        If (numberControls) Then
            Dim control = pnl_modulos_form.Controls.Item(0)
            Try
                control.Size = pnl_modulos_form.Size
                control.Update()
            Catch ex As Exception
                MessageBox.Show(ex.Message())
            End Try
        End If
    End Sub

    Private Sub cbx_modulos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbx_modulos.SelectedIndexChanged
        Dim modulo As Integer = (CType(cbx_modulos.SelectedItem, KeyValuePair(Of Integer, String))).Key
        If (modulo = 1) Then
        ElseIf (modulo = 2) Then
            Dim plano_topografico_form = New Form_plano_topografico_25k()
            openFormByName(plano_topografico_form, pnl_modulos_form)
        End If
    End Sub
End Class