Imports System.Data.SqlClient

Public Class ListadoPersonas
    Inherits System.Web.UI.Page

    Dim conexion As SqlConnection
    Dim consulta As SqlCommand
    Dim reader As SqlDataReader

    Protected Function FuncionFormatear(fecha As Date) As String
        Return FormatDateTime(fecha, DateFormat.GeneralDate)
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not IsPostBack) Then
            Try
                conexion = New SqlConnection(ConfigurationManager.AppSettings("strconexion"))
                consulta = New SqlCommand("Select * from Personas where baja_Persona=0", conexion)

                conexion.Open()
                reader = consulta.ExecuteReader
                Repeater1.DataSource = reader
                Repeater1.DataBind()
                reader.Close()


                conexion.Close()
            Catch ex As Exception

            End Try

        End If
    End Sub

    Protected Sub btEliminar_Click(sender As Object, e As EventArgs)

        Dim button As Button = CType(sender, Button)
        Dim id As String = button.CommandName

        Response.Redirect("Eliminacion.aspx?id=" + id + "&tabla=Personas")

    End Sub

    Protected Sub btModificar_Click(sender As Object, e As EventArgs)

        Dim button As Button = CType(sender, Button)
        Dim id As String = button.CommandName

        Response.Redirect("AltaModificacion.aspx?id=" + id + "&accion=EDIT")

    End Sub

    Protected Sub btCrear_Click(sender As Object, e As EventArgs) Handles btCrear.Click
        Response.Redirect("AltaModificacion.aspx?")
    End Sub
End Class