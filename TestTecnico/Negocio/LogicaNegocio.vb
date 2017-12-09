Imports System
Imports System.Text.RegularExpressions
Imports Microsoft.VisualBasic

Public Class LogicaNegocio

    Public Function calculoEdad(fecha As String) As Integer

        Dim nac As Date = CDate(fecha)
        Dim edad As Integer

        edad = CInt(DateAndTime.DateDiff(DateInterval.Year, nac, Date.Today))

        Return edad
    End Function

    Public Function validarPersona(nombre As String, nacimiento As String, sexo As String) As Boolean

        If (sexo.ToUpper = "MASCULINO" Or sexo.ToUpper = "FEMENINO") Then
            If (validarNacimiento(nacimiento)) Then
                If (validarNombre(nombre)) Then
                    Return True
                End If
            End If
        End If
        Return False
    End Function

    Public Function validarNacimiento(nacimiento As String) As Boolean
        Try
            Dim fecha As Date = CDate(nacimiento)

            If (fecha < Date.Today) Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function validarNombre(nombre As String) As Boolean
        Dim pattern As String = "(([aA-zZ]+)((\s[aA-zZ]+)*)){1}"
        Dim regex As New Regex(pattern)

        If (regex.IsMatch(nombre) And nombre <> "") Then
            Return True
        End If
        Return False
    End Function
End Class
