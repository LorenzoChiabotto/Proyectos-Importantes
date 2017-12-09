Imports System.Data
Imports System.Data.SqlClient
Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols

' Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente.
' <System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class Service
    Inherits System.Web.Services.WebService

    Dim conexion As New SqlConnection("Data Source=.\SQLEXPRESS;Initial Catalog=DBTestTecnico;Integrated Security=True")
    Dim consulta As SqlCommand
    Dim transaction As SqlTransaction

    Dim logicaNegocio As New Negocio.LogicaNegocio


    <WebMethod()> _
    Public Function GetDatos() As DataTable
        Try
            Dim dTable As New DataTable("tablaUsuarios")

            consulta = New SqlCommand("Select id_Persona, nombre_Persona, nacimiento_Persona, edad_Persona, sexo_Persona From Personas where baja_Persona=0", conexion)

            conexion.Open()

            Dim dAdapter As New SqlDataAdapter(consulta)

            dAdapter.Fill(dTable)

            conexion.Close()
            Return dTable
        Catch
            Return Nothing
        End Try

    End Function
    <WebMethod()> _
    Public Sub NuevaPersonna(nombre As String, nacimiento As String, sexo As String)
        If (logicaNegocio.validarPersona(nombre, nacimiento, sexo)) Then
            Try
                consulta = New SqlCommand("Insert into Personas(nombre_Persona, nacimiento_Persona, edad_Persona, sexo_Persona, baja_Persona) Values  (@nombre, @nacimiento, @edad, @sexo,0)", conexion)

                consulta.Parameters.Add("@nombre", SqlDbType.VarChar)
                consulta.Parameters("@nombre").Value = nombre

                consulta.Parameters.Add("@nacimiento", SqlDbType.VarChar)
                consulta.Parameters("@nacimiento").Value = nacimiento

                consulta.Parameters.Add("@sexo", SqlDbType.VarChar)
                consulta.Parameters("@sexo").Value = sexo

                consulta.Parameters.Add("@edad", SqlDbType.Int)
                consulta.Parameters("@edad").Value = logicaNegocio.calculoEdad(nacimiento)

                conexion.Open()

                transaction = conexion.BeginTransaction("insert")
                consulta.Transaction = transaction



                consulta.ExecuteNonQuery()
                transaction.Commit()

                conexion.Close()
            Catch ex As Exception
                transaction.Rollback()
                conexion.Close()
            End Try
            consulta.Parameters.Clear()

        End If

    End Sub
    <WebMethod()> _
    Public Sub ModificarPersona(id As Integer, nombre As String, nacimiento As String, sexo As String)

        If (logicaNegocio.validarPersona(nombre, nacimiento, sexo)) Then
            Try
                consulta = New SqlCommand("UPDATE Personas SET nombre_Persona = @nombre, nacimiento_Persona = @nacimiento, edad_Persona = @edad, sexo_Persona = @sexo where id_Persona=@id", conexion)


                consulta.Parameters.Add("@id", SqlDbType.Int)
                consulta.Parameters("@id").Value = id

                consulta.Parameters.Add("@nombre", SqlDbType.VarChar)
                consulta.Parameters("@nombre").Value = nombre

                consulta.Parameters.Add("@nacimiento", SqlDbType.VarChar)
                consulta.Parameters("@nacimiento").Value = nacimiento

                consulta.Parameters.Add("@edad", SqlDbType.Int)
                consulta.Parameters("@edad").Value = logicaNegocio.calculoEdad(nacimiento)

                consulta.Parameters.Add("@sexo", SqlDbType.VarChar)
                consulta.Parameters("@sexo").Value = sexo


                conexion.Open()

                transaction = conexion.BeginTransaction("update")
                consulta.Transaction = transaction

                consulta.ExecuteNonQuery()
                transaction.Commit()

                conexion.Close()
            Catch ex As Exception
                transaction.Rollback()
                conexion.Close()

                Console.WriteLine(ex)
            End Try
            consulta.Parameters.Clear()

        End If

    End Sub
    <WebMethod()> _
    Public Sub BajaPersona(id As Integer)

        Try
            consulta = New SqlCommand("UPDATE Personas SET baja_Persona = 1 where id_Persona=@id", conexion)

            consulta.Parameters.Add("@id", SqlDbType.Int)
            consulta.Parameters("@id").Value = id

            conexion.Open()

            transaction = conexion.BeginTransaction("delete")
            consulta.Transaction = transaction


            consulta.ExecuteNonQuery()
            transaction.Commit()

            conexion.Close()
        Catch ex As Exception
            transaction.Rollback()
            conexion.Close()

            Console.WriteLine(ex)
        End Try
        consulta.Parameters.Clear()

    End Sub

End Class