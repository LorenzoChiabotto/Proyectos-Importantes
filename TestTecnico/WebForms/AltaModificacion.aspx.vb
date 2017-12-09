Imports System.Data.SqlClient

Public Class AltaModificacion
    Inherits System.Web.UI.Page

    Dim conexion As SqlConnection = New SqlConnection(ConfigurationManager.AppSettings("strconexion"))
    Dim consulta As SqlCommand
    Dim reader As SqlDataReader

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not IsPostBack()) Then
            If (Request.QueryString("accion") = "EDIT") Then
                Try
                    consulta = New SqlCommand("Select * from Personas WHERE id_Persona =@id", conexion)
                    consulta.Parameters.Add("@id", SqlDbType.Int)
                    consulta.Parameters("@id").Value = Request.QueryString("id")

                    conexion.Open()
                    reader = consulta.ExecuteReader()
                    reader.Read()

                    tbNombre.Text = reader("nombre_Persona").ToString
                    tbNacimiento.Text = reader("nacimiento_Persona").ToString
                    tbEdad.Text = reader("edad_Persona").ToString


                    ddSexo.SelectedValue = reader("sexo_Persona").ToString


                    reader.Close()

                    conexion.Close()
                Catch ex As Exception

                End Try

            End If
        End If
    End Sub

    Protected Sub btGuardar_Click(sender As Object, e As EventArgs) Handles btGuardar.Click
        If (Request.QueryString("accion") = "EDIT") Then
            Try
                consulta = New SqlCommand("UPDATE Personas SET nombre_Persona = @nombre, nacimiento_Persona = @nacimiento, edad_Persona = @edad, sexo_Persona = @sexo where id_Persona=@id", conexion)


                consulta.Parameters.Add("@id", SqlDbType.Int)
                consulta.Parameters("@id").Value = Request.QueryString("id")

                consulta.Parameters.Add("@nombre", SqlDbType.VarChar)
                consulta.Parameters("@nombre").Value = tbNombre.Text

                consulta.Parameters.Add("@nacimiento", SqlDbType.VarChar)
                consulta.Parameters("@nacimiento").Value = tbNacimiento.Text

                consulta.Parameters.Add("@edad", SqlDbType.Int)
                consulta.Parameters("@edad").Value = tbEdad.Text

                consulta.Parameters.Add("@sexo", SqlDbType.VarChar)
                consulta.Parameters("@sexo").Value = ddSexo.SelectedValue.ToString()


                conexion.Open()

                consulta.ExecuteNonQuery()

                conexion.Close()
            Catch ex As Exception

            End Try

        Else
            Try
                consulta = New SqlCommand("Insert into Personas(nombre_Persona, nacimiento_Persona, edad_Persona, sexo_Persona, baja_Persona) Values  (@nombre, @nacimiento, @edad, @sexo,0)", conexion)

                consulta.Parameters.Add("@nombre", SqlDbType.VarChar)
                consulta.Parameters("@nombre").Value = tbNombre.Text

                consulta.Parameters.Add("@nacimiento", SqlDbType.VarChar)
                consulta.Parameters("@nacimiento").Value = tbNacimiento.Text

                consulta.Parameters.Add("@sexo", SqlDbType.VarChar)
                consulta.Parameters("@sexo").Value = ddSexo.SelectedValue.ToString()

                consulta.Parameters.Add("@edad", SqlDbType.Int)
                consulta.Parameters("@edad").Value = tbEdad.Text

                conexion.Open()

                consulta.ExecuteNonQuery()

                conexion.Close()
            Catch ex As Exception

            End Try


        End If

        Response.Redirect("ListadoPersonas.aspx?")
    End Sub
End Class