

Imports System.Data.SqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox

Public Class Consulta


    Dim conexion As New SqlConnection("Server=DESKTOP-EG6N7VP\SQLEXPRESS; Database=BDEmpresa; Integrated Security=true")
    Dim conexion2 As New SqlConnection("Server=DESKTOP-EG6N7VP\SQLEXPRESS; Database=BDEmpresa; user Id=sa ; Password=Anthony-2379")


    Private Sub Consulta_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        cargarSeleccion()

    End Sub

    Sub cargarSeleccion()

        Dim Consulta = "Select *from Empleado Order By Idcodigo"
        Dim da As New SqlDataAdapter(Consulta, conexion2)
        Dim dt = New DataTable
        da.Fill(dt)
        With cbSeleccionar
            .DataSource = dt
            .DisplayMember = "Nombre"
            .ValueMember = "Idcodigo"

        End With
    End Sub

    Private Sub cbSeleccionar_TextChanged(sender As Object, e As EventArgs) Handles cbSeleccionar.TextChanged
        Try
            If cbSeleccionar.ValueMember.ToString <> "" Then

                ' Dim consulta = "select *from empleado 
                'where idcodigo= " + cbSeleccionar.SelectedValue.ToString + ""
                Dim consulta = "select E.idcodigo,E.Nombre, E.Apellido, S.Genero, C.Cargo from 
                Empleado E join Sexo S on s.IdSexo = E.Sexo join Cargo C on C.IdCargo = E.Cargo
                where idcodigo= " + cbSeleccionar.SelectedValue.ToString + ""

                Dim da = New SqlDataAdapter(consulta, conexion2)
                Dim dt = New DataTable
                da.Fill(dt)
                For Each fila As DataRow In dt.Rows
                    tbNombre.Text = fila("Nombre").ToString
                    tbApellido.Text = fila("Apellido").ToString
                    tbSexo.Text = fila("Genero").ToString
                    tbCargo.Text = fila("cargo").ToString

                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub


End Class