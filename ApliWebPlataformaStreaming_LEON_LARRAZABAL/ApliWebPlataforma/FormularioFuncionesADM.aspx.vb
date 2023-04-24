Imports System.Data.OleDb
Public Class FormularioFuncionesADM
    Inherits System.Web.UI.Page
    'Asigna a Usuario el LoginName actual pasado a minúsculas (para las comparaciones)
    Dim usuario As String = StrConv(System.Web.HttpContext.Current.User.Identity.Name, VbStrConv.Lowercase)
    Dim cadenaConexion As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\TEMP\Plataforma_Larrazabal_Leon.mdb"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Asegurarse de que ha iniciado sesión como administrador
        If usuario = "" Then
            MsgBox("Debes Iniciar Sesión como administrador para poder operar aqui")
            Response.Redirect("default.aspx")
        Else
            If usuario <> "administrador" Then
                MsgBox("No eres el administrador. Solo puedes realizar las funciones del Usuario")
                Response.Redirect("default.aspx")
            End If
        End If
    End Sub

    Protected Sub VolverPrincipal_Click(sender As Object, e As EventArgs) Handles VolverPrincipal.Click
        Response.Redirect("default.aspx")
    End Sub

    Protected Sub cambiarEstadoSocio_Click(sender As Object, e As EventArgs) Handles cambiarEstadoSocio.Click
        'PASO 0. DECLARAR LAS VARIABLES NECESARIAS para las instrucciones de BD
        Dim conexion As OleDb.OleDbConnection
        Dim instruccionSQL As String
        Dim strSQL As String
        Dim dbComm As OleDbCommand
        Dim dbComm2 As OleDbCommand
        Dim resultado As String
        'PASO 1. CREAR UNA CONEXION CON LA BASE DE DATOS Y ABRIRLA
        conexion = New OleDb.OleDbConnection(cadenaConexion)
        conexion.Open()
        'PASO 2. PREPARAR LA INSTRUCCION SQL A EJECUTAR
        'Ponemos la instrucción SQL en un string, con un ? en cada sitio en el que vaya un parámetro
        strSQL = "SELECT ESTADO FROM USUARIOREG WHERE USUARIOLOGIN=?"
        dbComm2 = New OleDbCommand(strSQL, conexion)
        dbComm2.Parameters.Add("param1", OleDbType.VarChar)
        dbComm2.Parameters("param1").Value = nombreLogin.SelectedValue
        resultado = dbComm2.ExecuteScalar()
        If resultado = "A" Then
            instruccionSQL = "UPDATE USUARIOREG SET ESTADO = ? WHERE USUARIOLOGIN=?"
            dbComm = New OleDbCommand(instruccionSQL, conexion)
            dbComm.Parameters.Add("param2", OleDbType.VarChar)
            dbComm.Parameters("param2").Value = "B"
            dbComm.Parameters.Add("param3", OleDbType.VarChar)
            dbComm.Parameters("param3").Value = nombreLogin.SelectedValue
            dbComm.ExecuteNonQuery()
        Else
            instruccionSQL = "UPDATE USUARIOREG SET ESTADO = ? WHERE USUARIOLOGIN=?"
            dbComm = New OleDbCommand(instruccionSQL, conexion)
            dbComm.Parameters.Add("param4", OleDbType.VarChar)
            dbComm.Parameters("param4").Value = "A"
            dbComm.Parameters.Add("param5", OleDbType.VarChar)
            dbComm.Parameters("param5").Value = nombreLogin.SelectedValue
            dbComm.ExecuteNonQuery()
        End If

        conexion.Close()
        conexion.Dispose()
    End Sub

    Protected Sub mostrarDatosSocio_Click(sender As Object, e As EventArgs) Handles mostrarDatosSocio.Click

    End Sub

    Protected Sub DarDeAltaPeli_Click(sender As Object, e As EventArgs) Handles DarDeAltaPeli.Click
        'PASO 0. DECLARAR LAS VARIABLES NECESARIAS para las instrucciones de BD
        Dim conexion As OleDb.OleDbConnection
        Dim instruccionSQL As String
        Dim dbComm As OleDbCommand

        'PASO 1. CREAR UNA CONEXION CON LA BASE DE DATOS Y ABRIRLA
        conexion = New OleDb.OleDbConnection(cadenaConexion)
        conexion.Open()
        'PASO 2. PREPARAR LA INSTRUCCION SQL A EJECUTAR
        'Ponemos la instrucción SQL en un string, con un ? en cada sitio en el que vaya un parámetro
        instruccionSQL = "INSERT INTO PELICULA(CODIGO, TITULO, PRECIO) VALUES (?,?,?)"
        dbComm = New OleDbCommand(instruccionSQL, conexion)
        dbComm.Parameters.Add("param1", OleDbType.Integer)
        dbComm.Parameters("param1").Value = CInt(codPeliculaAlta.Text)
        dbComm.Parameters.Add("param2", OleDbType.VarChar)
        dbComm.Parameters("param2").Value = tituloPelicula.Text
        dbComm.Parameters.Add("param4", OleDbType.Double)
        dbComm.Parameters("param4").Value = CDbl(precioPelicula.Text)
        dbComm.ExecuteNonQuery()
        MsgBox("Pelicula introducida")
        Response.Redirect("default.aspx")
        conexion.Close()
        conexion.Dispose()
    End Sub

    Protected Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles precioPelicula.TextChanged

    End Sub


    Protected Sub DarDeBajaPeli_Click(sender As Object, e As EventArgs) Handles DarDeBajaPeli.Click
        'PASO 0. DECLARAR LAS VARIABLES NECESARIAS para las instrucciones de BD
        Dim conexion As OleDb.OleDbConnection
        Dim instruccionSQL As String
        Dim dbComm As OleDbCommand

        'PASO 1. CREAR UNA CONEXION CON LA BASE DE DATOS Y ABRIRLA
        conexion = New OleDb.OleDbConnection(cadenaConexion)
        conexion.Open()
        'PASO 2. PREPARAR LA INSTRUCCION SQL A EJECUTAR
        'Ponemos la instrucción SQL en un string, con un ? en cada sitio en el que vaya un parámetro
        instruccionSQL = "UPDATE PELICULA SET ESTADO=? WHERE CODIGO=?"
        dbComm = New OleDbCommand(instruccionSQL, conexion)
        dbComm.Parameters.Add("param1", OleDbType.VarChar)
        dbComm.Parameters("param1").Value = "Descatalogada"
        dbComm.Parameters.Add("param3", OleDbType.Integer)
        dbComm.Parameters("param3").Value = CInt(codigoB.SelectedValue)
        dbComm.ExecuteNonQuery()
        MsgBox("Pelicula lista para dar de baja")
        Response.Redirect("default.aspx")
        conexion.Close()
        conexion.Dispose()
    End Sub

    Protected Sub logins_Selecting(sender As Object, e As SqlDataSourceSelectingEventArgs) Handles logins.Selecting

    End Sub
End Class