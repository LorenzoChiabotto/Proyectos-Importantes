Imports System.Data.SqlClient

Public Class Eliminacion
    Inherits System.Web.UI.Page

    Dim conexion As SqlConnection = New SqlConnection(ConfigurationManager.AppSettings("strconexion"))
    Dim consulta As SqlCommand
    Dim reader As SqlDataReader

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim tabla As String
            tabla = Request.QueryString("tabla")

            Select Case tabla

                Case "Personas"
                    consulta = New SqlCommand("Select * from Personas where id_Persona=@id", conexion)

            End Select

            consulta.Parameters.Add("@id", SqlDbType.Int)
            consulta.Parameters("@id").Value = Request.QueryString("id")
            conexion.Open()

            reader = consulta.ExecuteReader
            reader.Read()

            lblRegistro.Text = reader("nombre_Persona").ToString
            lblTabla.Text = Request.QueryString("tabla")
            conexion.Close()

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btAceptar_Click(sender As Object, e As EventArgs) Handles btAceptar.Click
        Try

            consulta = New SqlCommand("update Personas set baja_Persona=1 where id_Persona=@id", conexion)

            consulta.Parameters.Add("@id", SqlDbType.VarChar)
            consulta.Parameters("@id").Value = Request.QueryString("id")
            conexion.Open()

            consulta.ExecuteNonQuery()

            conexion.Close()
            Response.Redirect("ListadoPersonas.aspx?")
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btCancelar_Click(sender As Object, e As EventArgs) Handles btCancelar.Click
        Response.Redirect("ListadoPersonas.aspx?")
    End Sub
End Class