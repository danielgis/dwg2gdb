Public Class Login
    Private Sub LoginValidate(user As String, password As String)

    End Sub
    Private Sub btn_login_Click(sender As Object, e As EventArgs) Handles btn_login.Click
        'Incluir proceso de validacion
        'LoginValidate(user, password)
        '------------------------------
        Dim ModulosForm = New Modulos()
        openFormByName(ModulosForm, Me.Parent)
    End Sub
End Class