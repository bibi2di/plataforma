Imports System.Data.OleDb

Public Class _Default
    Inherits System.Web.UI.Page
    'Asigna a Usuario el LoginName actual pasado a min�sculas (para las comparaciones)
    Dim usuario As String = StrConv(System.Web.HttpContext.Current.User.Identity.Name, VbStrConv.Lowercase)
    'Indicamos la cadena de conexion (tipo OLEDB)
    Dim cadenaConexion As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\TEMP\Plataforma_Larrazabal_Leon.mdb"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Crea una VARIABLE DE SESI�N llamada usuarioLogin y le asigna el LoginName actual pasado a min�sculas
        Session("usuarioLogin") = StrConv(System.Web.HttpContext.Current.User.Identity.Name, VbStrConv.Lowercase)
        If Page.IsPostBack = False And usuario <> "" Then 'Solamente se hace cuando vaya a esta p�gina
            '*****************************************************************************************
            ' CUANDO SE REGISTRA UN NUEVO USUARIO SE LE DA AUTOM�TICAMENTE DE ALTA COMO USUARIO EN LA BD
            '*****************************************************************************************
            'PASO 1. ABRIR LA CONEXION VERIFICANDO QUE SEA CORRECTA.
            'Declarar y crear una nueva conexi�n
            Dim conexion As OleDb.OleDbConnection
            conexion = New OleDb.OleDbConnection(cadenaConexion)
            'Intentar abrirla
            Try
                If conexion.State = ConnectionState.Closed Then
                    conexion.Open()
                End If
            Catch ex As Exception
                'No se ha podido abrir la conexi�n: Se debe repasar la cadena de conexi�n
                MsgBox("Error al conectar con la base de datos")
                Response.Write(ex.Message)
                Response.Write(". Esta es tu cadena de conexion: " & cadenaConexion)
                Response.End()
            End Try

            'PASO 2. PREPARAR LA INSTRUCCION SQL A EJECUTAR
            'Insertamos el usuario en la tabla USUARIOREG si no existe --> EJEMPLO DE INSTRUCCI�N CON UN PAR�METRO
            Dim strSQL As String = "INSERT INTO USUARIOREG(usuarioLogin) VALUES (?)"
            Dim dbComm As New OleDbCommand(strSQL, conexion)
            dbComm.Parameters.Add("usuario", OleDbType.VarChar, 50)
            dbComm.Parameters("usuario").Value = usuario

            'PASO 3. EJECUTAR LA INSTRUCCION VERIFICANDO QUE SEA CORRECTA (depende de si es una SELECT o no)
            Try
                'Ejecutamos el INSERT
                dbComm.ExecuteNonQuery()   'Ejecuta cualquier instrucci�n que no sea SELECT 
                MsgBox("Se ha dado de alta a un nuevo usuario registrado")
            Catch exSql As Exception
                'Si da error es que el usuario ya existe. En realidad no es un error para nosotros.
                'No hacemos nada
            Finally
                'PASO 4. CERRAR conexion Y LIBERAR MEMORIA
                'Cerramos la conexi�n y liberamos la memoria que hayamos podido utilizar
                If conexion.State = ConnectionState.Open Then
                    conexion.Close()
                    conexion.Dispose()
                End If
            End Try
        End If
    End Sub

End Class