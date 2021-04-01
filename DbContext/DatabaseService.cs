using System.Collections.Generic;
using System.Linq;
using Dapper;
using HomeworkLesson20.Models;
using Microsoft.AspNetCore.Mvc;
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
        public void Create(Person model)
        {
            using (var con = new SqlConnection(_conString))
            {
                var sql =
                    "INSERT INTO Person (LastName, FirstName, MiddleName) VALUES (@LastName, @FirstName, @MiddleName)";
                con.Execute(sql, model);
            }
        }
        public Person SearchId(int id)
        {
            using (var con = new SqlConnection(_conString))
            {
                return con.Query<Person>($"SELECT * FROM PERSON WHERE Id = {id}").FirstOrDefault();
            }
        }

        public Person SearchName(string lastName, string firstName, string middleName)
        {
            using (var con = new SqlConnection(_conString))
            {
                return con.Query<Person>($"SELECT * FROM PERSON WHERE LastName = '{lastName}' AND FirstName = '{firstName}' AND MiddleName = '{middleName}'").FirstOrDefault();
            }
        }
    }
}