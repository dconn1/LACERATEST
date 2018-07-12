using System;
using System.ComponentModel.DataAnnotations;

namespace Ninject.Model
{
    public class EmployeeModel
    {
        [Key]
        public int Id; 
        public string EmployeeName;
        public DateTime Birthdate;
        public int Salary;
        public DateTime DateHired;
        public string Status;
    }

}
