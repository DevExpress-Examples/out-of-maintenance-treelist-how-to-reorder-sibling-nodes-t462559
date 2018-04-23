using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace TreeList_ReorderNodes.Models {
    public class ConnectionRepository {
        public static OleDbConnection GetConnection() {
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}", HttpContext.Current.Server.MapPath("~/App_Data/Departments.mdb"));
            return connection;
        }
    }

    public class DepartmentsProvider {
        public static DataTable GetDeparments() {
            DataTable table = new DataTable();

            using (OleDbConnection connection = ConnectionRepository.GetConnection()) {
                OleDbDataAdapter adapter = new OleDbDataAdapter(string.Empty, connection);
                adapter.SelectCommand.CommandText = "SELECT [ID], [PARENTID], [DEPARTMENT], [BUDGET], [LOCATION] FROM [Departments]";
                adapter.Fill(table);
            }

            return table;
        }
    }
}