Imports System.Data.OleDb 'Para las conexiones tipo OleDb -- ACCESS
Public Class FormularioFuncionesUSUARIO
    Inherits System.Web.UI.Page
    'Asigna a Usuario el LoginName actual pasado a minúsculas (para las comparaciones)
    Dim usuario As String = StrConv(System.Web.HttpContext.Current.User.Identity.Name, VbStrConv.Lowercase)
    'Indicamos la cadena de conexion (tipo OLEDB)
    Dim cadenaConexion As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\TEMP\Plataforma_Larrazabal_Leon.mdb"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Comprobamos que se haya iniciado sesión
        If usuario = "" Then
            MsgBox("Debes Iniciar Sesión como usuario registrado para poder operar aquí")
            Response.Redirect("default.aspx")
        End If
        If Page.IsPostBack = False Then 'Solamente se hace cuando vaya a esta página
            'DECLARAR LAS VARIABLES NECESARIAS para las instrucciones de BD
            Dim conexion As OleDb.OleDbConnection
            Dim strSQL As String
            Dim dbComm As OleDbCommand
            'PASO 1. CREAR UNA CONEXION Y ABRIRLA
            conexion = New OleDb.OleDbConnection(cadenaConexion)
            conexion.Open()
            '*******************************************************************************************
            ' SE RECUPERA EL ESTADO DEL USUARIO QUE HA INICIADO LA SESIÓN
            '*******************************************************************************************
            'PASOS 2 Y 3. PREPARAR LA INSTRUCCION SQL Y EJECUTARLA
            strSQL = "SELECT estado FROM USUARIOREG WHERE usuarioLogin=?"
            dbComm = New OleDbCommand(strSQL, conexion)
            dbComm.Parameters.Add(New OleDbParameter("usuario", OleDbType.VarChar)).Value = usuario
            Dim estado As String  'Para guardar el estado del usuario en la aplicación
            estado = dbComm.ExecuteScalar()    ' Ejecuta una SELECT en la que solo se obtiene un dato

            '*******************************************************************************************
            ' SI ES UN USUARIO REGISTRADO ACTIVO (su estado es A), SE MUESTRAN SUS DATOS PERSONALES
            '*******************************************************************************************
            If estado <> "A" Then
                'Si su estado no es activo visualizar un mensaje
                MsgBox("Has sido dado de baja por el administrador de la plataforma. No puedes operar.")
                Response.Redirect("default.aspx")
            Else
                'Recuperar los demás datos del usuario desde la BD y mostrarlos -- EJEMPLO DE SELECT
                'PASO 2. Preparar la instrucción SQL a ejecutar
                strSQL = "SELECT nombre_apellido,direccion,credito FROM USUARIOREG WHERE usuarioLogin='" & usuario & "'"
                dbComm = New OleDbCommand(strSQL, conexion)
                'PASO 3. Ejecutarla
                Dim datosUsuarioReader As OleDbDataReader
                datosUsuarioReader = dbComm.ExecuteReader()  'Ejecuta una SELECT que obtiene varios datos
                'Tratar el resultado, es decir, los datos obtenidos por la select
                While datosUsuarioReader.Read() 'Si hay varias filas las va leyendo una por una
                    'Se asignan los datos recuperados a los distintos TextBox de la página Web
                    Me.Nombre.Text = datosUsuarioReader(0) 'Primer dato de la fila
                    Me.Direccion.Text = datosUsuarioReader(1) 'Segundo dato de la fila
                End While
            End If
            'PASO 4. CERRAR LA CONEXIÓN Y LIBERAR MEMORIA
            conexion.Close()
            conexion.Dispose()
        End If
    End Sub


    Protected Sub VolverPrincipal_Click(ByVal sender As Object, ByVal e As EventArgs) Handles VolverPrincipal.Click
        Response.Redirect("default.aspx")
    End Sub

    Protected Sub Aumentar_Click(sender As Object, e As EventArgs) Handles Aumentar.Click
        'PASO 0. DECLARAR LAS VARIABLES NECESARIAS para las instrucciones de BD
        Dim conexion As OleDb.OleDbConnection
        Dim instruccionSQL As String
        Dim dbComm As OleDbCommand
        'PASO 1. CREAR UNA CONEXION CON LA BASE DE DATOS Y ABRIRLA
        conexion = New OleDb.OleDbConnection(cadenaConexion)
        conexion.Open()
        'PASO 2. PREPARAR LA INSTRUCCION SQL A EJECUTAR
        'Ponemos la instrucción SQL en un string, con un ? en cada sitio en el que vaya un parámetro
        instruccionSQL = "UPDATE USUARIOREG SET CREDITO=CREDITO + ? WHERE usuarioLogin=?"
        'La convertimos en un comando para poder añadirle los valores de los parámetros
        dbComm = New OleDbCommand(instruccionSQL, conexion)
        'Añadimos los parámetros y especificamos sus valores
        'en el mismo orden en que aparecen en la instrucción SQL
        'Valor correspondiente a la primera ? de instruccionSQL
        dbComm.Parameters.Add("param1", OleDbType.Double)
        dbComm.Parameters("param1").Value = CDbl(cantidadEuros.Text)
        'Valor correspondiente a la segunda ? de instruccionSQL
        dbComm.Parameters.Add("param2", OleDbType.VarChar)
        dbComm.Parameters("param2").Value = usuario
        'PASO 3. EJECUTAR LA INSTRUCCION SQL (hay 3 casos distintos, se elige el adecuado)
        dbComm.ExecuteNonQuery() 'Ejecuta cualquier instrucción que no sea SELECT
        'Sacamos un mensaje por pantalla (opcional)
        MsgBox("Se ha aumentado el crédito del socio")
        'PASO 4. CERRAR LA CONEXIÓN CON LA BASE DE DATOS Y LIBERAR MEMORIA
        conexion.Close()
        conexion.Dispose()
    End Sub

    Protected Sub Nombre_TextChanged(sender As Object, e As EventArgs) Handles Nombre.TextChanged

    End Sub

    Protected Sub Modificar_Click(sender As Object, e As EventArgs) Handles Modificar.Click
        'PASO 0. DECLARAR LAS VARIABLES NECESARIAS para las instrucciones de BD
        Dim conexion As OleDb.OleDbConnection
        Dim instruccionSQL As String
        Dim dbComm As OleDbCommand
        'PASO 1. CREAR UNA CONEXION CON LA BASE DE DATOS Y ABRIRLA
        conexion = New OleDb.OleDbConnection(cadenaConexion)
        conexion.Open()
        'PASO 2. PREPARAR LA INSTRUCCION SQL A EJECUTAR
        'Ponemos la instrucción SQL en un string, con un ? en cada sitio en el que vaya un parámetro
        instruccionSQL = "UPDATE USUARIOREG SET NOMBRE=?, DIRECCION=? WHERE USUARIOLOGIN=?"
        'La convertimos en un comando para poder añadirle los valores de los parámetros
        dbComm = New OleDbCommand(instruccionSQL, conexion)
        'Añadimos los parámetros y especificamos sus valores
        'en el mismo orden en que aparecen en la instrucción SQL
        'Valor correspondiente a la primera ? de instruccionSQL
        dbComm.Parameters.Add("param1", OleDbType.VarChar)
        dbComm.Parameters("param1").Value = Nombre.Text
        dbComm.Parameters.Add("param2", OleDbType.VarChar)
        dbComm.Parameters("param2").Value = Direccion.Text
        'Valor correspondiente a la segunda ? de instruccionSQL
        dbComm.Parameters.Add("param3", OleDbType.VarChar)
        dbComm.Parameters("param3").Value = usuario
        'PASO 3. EJECUTAR LA INSTRUCCION SQL (hay 3 casos distintos, se elige el adecuado)
        dbComm.ExecuteNonQuery() 'Ejecuta cualquier instrucción que no sea SELECT
        'Sacamos un mensaje por pantalla (opcional)
        MsgBox("Se han actualizado los datos del usuario")
        'PASO 4. CERRAR LA CONEXIÓN CON LA BASE DE DATOS Y LIBERAR MEMORIA
        conexion.Close()
        conexion.Dispose()
    End Sub

    Protected Sub Alquilar_Click(sender As Object, e As EventArgs) Handles Alquilar.Click

    End Sub
End Class