using Ninject.Interface;
using Ninject.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace Ninject.Concrete
{
    public class Employee : IEmployee
    {
        public IEnumerable<EmployeeModel> GetAll()
        {
            List<EmployeeModel> employees = new List<EmployeeModel>();

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                con.Open();
                var cmd = con.CreateCommand();
                cmd.CommandText = "Select * from [Employees];";

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var model = new EmployeeModel()
                        {
                            Id = (int)reader["Id"],
                            EmployeeName = (string)reader["EmployeeName"],
                            Birthdate = (DateTime)reader["Birthdate"],
                            DateHired = (DateTime)reader["DateHired"],
                            Salary = (int)reader["Salary"],
                            Status = (string)reader["Status"]
                        };
                        employees.Add(model);
                    }
                }
            }
            return employees.AsEnumerable();
        }
        
        public void Add(EmployeeModel model)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                con.Open();
                var cmd = con.CreateCommand();
                cmd.CommandText = $@"INSERT INTO Employees
VALUES('{model.EmployeeName}', '{model.Birthdate.ToShortDateString()}', '{model.DateHired.ToShortDateString()}',{model.Salary},'{model.Status}');";
                using (SqlTransaction sqltrans = con.BeginTransaction())
                {
                    cmd.Transaction = sqltrans;
                    var result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        sqltrans.Commit();
                    }
                    else
                    {
                        sqltrans.Rollback();
                    }
                }
            }
        }
        public void DeleteAll()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                con.Open();
                var cmd = con.CreateCommand();
                cmd.CommandText = "DELETE from Employees";

                using (SqlTransaction sqltrans = con.BeginTransaction())
                {
                    cmd.Transaction = sqltrans;

                    var result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        sqltrans.Commit();
                    }
                    else
                    {
                        sqltrans.Rollback();
                    }
                }
            }
        }
    }
}
