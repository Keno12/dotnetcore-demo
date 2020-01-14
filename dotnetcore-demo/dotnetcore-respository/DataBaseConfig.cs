using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace dotnetcore_respository
{
    public class DataBaseConfig
    {
        #region SqlServer链接配置

        private static string DefaultSqlConnectionString = @"Data Source=localhost;Initial Catalog=Dinner;User ID=sa;Password=123456;";

        public static IDbConnection GetSqlConnection(string sqlConnectionString = null)
        {
            if (string.IsNullOrWhiteSpace(sqlConnectionString))
            {
                sqlConnectionString = DefaultSqlConnectionString;
            }
            IDbConnection conn = new SqlConnection(sqlConnectionString);
            conn.Open();
            return conn;
        }

        #endregion

        
    }
}
