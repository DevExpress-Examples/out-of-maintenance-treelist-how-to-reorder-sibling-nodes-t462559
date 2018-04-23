Imports System.Data.OleDb

Public Class ConnectionRepository
    Public Shared Function GetConnection() As OleDbConnection
        Dim connection As New OleDbConnection()
        connection.ConnectionString = String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}", HttpContext.Current.Server.MapPath("~/App_Data/Departments.mdb"))
        Return connection
    End Function
End Class

Public Class DepartmentsProvider
    Public Shared Function GetDeparments() As DataTable
        Dim table As New DataTable()

        Using connection As OleDbConnection = ConnectionRepository.GetConnection()
            Dim adapter As New OleDbDataAdapter(String.Empty, connection)
            adapter.SelectCommand.CommandText = "SELECT [ID], [PARENTID], [DEPARTMENT], [BUDGET], [LOCATION] FROM [Departments]"
            adapter.Fill(table)
        End Using

        Return table
    End Function
End Class
