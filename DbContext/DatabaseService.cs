using System.Collections.Generic;
using System.Linq;
using Dapper;
using HomeworkLesson20.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace HomeworkLesson20.DbContext
{
    public class DatabaseService: IDatabaseService
    {
        private string _conString;
        
        public DatabaseService(IConfiguration configuration)
        {
            _conString = configuration.GetConnectionString("DefaultConnection");
        }

        public List<T> GetList<T>()
        {
            using (var con = new SqlConnection (_conString))
            {
                var tableName = typeof(T).Name;
                return con.Query<T>($"SELECT * FROM {tableName}").ToList();
            }
        }
    }
}