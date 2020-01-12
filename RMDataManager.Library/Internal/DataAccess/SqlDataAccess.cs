using Dapper;

using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace RMDataManager.Library.Internal.DataAccess
{
    internal class SqlDataAccess
    {
        public string GetConnectionString(string name) => ConfigurationManager.ConnectionStrings[name].ConnectionString;

        public List<T> LoadData<T, U>(string storedProcedure, U parameters, string connectionStringName)
        {
            using (IDbConnection conn = new SqlConnection(GetConnectionString(connectionStringName)))
            {
                var rows = conn.Query<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure).ToList();

                return rows;
            }
        }

        public int SaveData<T>(string storedProcedure, T parameters, string connectionStringName)
        {
            using (IDbConnection conn = new SqlConnection(GetConnectionString(connectionStringName)))
            {
                return conn.Execute(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}