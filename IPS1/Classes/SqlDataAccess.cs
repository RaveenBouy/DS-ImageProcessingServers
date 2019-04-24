using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ImageProcessingServer.Classes
{
    public class SqlDataAccess
    {
        private static string GetConnectionString()
        {
            return "Server=localhost; Port=3306; Database=dsproject; Uid=root";
        }

        public static List<T> LoadData<T>(string sql)
        {
            try
            {
                using (IDbConnection con = new MySqlConnection(GetConnectionString()))
                {
                    return con.Query<T>(sql).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static int SaveData<T>(string sql, T data)
        {
            try
            {
                using (IDbConnection con = new MySqlConnection(GetConnectionString()))
                {
                    return con.Execute(sql, data);
                }
            }
            catch (Exception)
            {
                return 3;
            }
        }
    }
}
