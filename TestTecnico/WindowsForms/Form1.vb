Public Class Form1

    Dim edit As Boolean
    Dim sexo As String

    Dim editPersona As Integer

    Dim webService As New ServiceReference1.ServiceSoapClient

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgvPersonas.DataSource = webService.GetDatos()
        dgvPersonas.Columns("id_Persona").Visible = False

        lbAccion.Text = ""
    End Sub

    Private Sub btNuevo_Click(sender As Object, e As EventArgs) Handles btNuevo.Click
        btGuardar.Enabled = True
        btNuevo.Enabled = False
        btCancelar.Enabled = True
        btEditar.Enabled = False


        txtNacimiento.Enabled = True
        txtNombre.Enabled = True
        rbFemenino.Enabled = True
        rbMasculino.Enabled = True

        lbAccion.Text = ""
        edit = False
    End Sub

    Private Sub btEditar_Click(sender As Object, e As EventArgs) Handles btEditar.Click
        If (dgvPersonas.Rows.GetRowCount(DataGridViewElementStates.Selected) > 0) Then

            txtNombre.Text = dgvPersonas.CurrentRow.Cells("nombre_Persona").Value.ToString
            txtNacimiento.Text = dgvPersonas.CurrentRow.Cells("nacimiento_Persona").Value.ToString


            btGuardar.Enabled = True
            btNuevo.Enabled = False
            btCancelar.Enabled = True
            btEditar.Enabled = False

            txtNacimiento.Enabled = True
            txtNombre.Enabled = True
            rbFemenino.Enabled = True
            rbMasculino.Enabled = True


            lbAccion.Text = "editando"
            edit = True
            editPersona = CType(dgvPersonas.CurrentRow.Cells("id_Persona").Value, Integer)
        End If

    End Sub

    Private Sub btGuardar_Click(sender As Object, e As EventArgs) Handles btGuardar.Click
        If (Not edit) Then
            webService.NuevaPersonna(txtNombre.Text, txtNacimiento.Text, sexo)
        Else
            If (dgvPersonas.Rows.GetRowCount(DataGridViewElementStates.Selected) > 0) Then

                webService.ModificarPersona(editPersona, txtNombre.Text, txtNacimiento.Text, sexo)
            End If
        End If

        btGuardar.Enabled = False
        btNuevo.Enabled = True
        btCancelar.Enabled = False
        btEditar.Enabled = True

        txtNacimiento.Text = ""
        txtNombre.Text = ""
        lbAccion.Text = ""


        txtNacimiento.Enabled = False
        txtNombre.Enabled = False
        rbFemenino.Enabled = False
        rbMasculino.Enabled = False

        dgvPersonas.DataSource = webService.GetDatos()
    End Sub

    Private Sub btCancelar_Click(sender As Object, e As EventArgs) Handles btCancelar.Click
        btGuardar.Enabled = False
        btNuevo.Enabled = True
        btCancelar.Enabled = False
        btEditar.Enabled = True

        txtNacimiento.Text = ""
        txtNombre.Text = ""


        txtNacimiento.Enabled = False
        txtNombre.Enabled = False
        rbFemenino.Enabled = False
        rbMasculino.Enabled = False

        lbAccion.Text = ""
    End Sub

    Private Sub btEliminar_Click(sender As Object, e As EventArgs) Handles btEliminar.Click
        Dim result As DialogResult

        result = MessageBox.Show("Seguro que desea eliminar esta Persona?", "CUIDADO", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If (result = DialogResult.Yes) Then
            If (dgvPersonas.Rows.GetRowCount(DataGridViewElementStates.Selected) > 0) Then

                Dim persona As Integer = CInt(dgvPersonas.CurrentRow.Cells("id_Persona").Value)
                webService.BajaPersona(persona)

                dgvPersonas.DataSource = webService.GetDatos()
            End If
        End If
    End Sub

    Private Sub rbMasculino_CheckedChanged(sender As Object, e As EventArgs) Handles rbMasculino.CheckedChanged
        If (rbMasculino.Checked) Then
            sexo = "MASCULINO"
        End If
    End Sub

    Private Sub rbFemenino_CheckedChanged(sender As Object, e As EventArgs) Handles rbFemenino.CheckedChanged
        If (rbFemenino.Checked) Then
            sexo = "FEMENINO"
        End If
    End Sub
End Class
