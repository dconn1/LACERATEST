using Microsoft.VisualBasic.FileIO;
using Ninject.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CSVParserLib
{
    public static class Parser
    {
        public static IEnumerable<EmployeeModel> ParseEmployeesFromFile(string file)
        {
            List<EmployeeModel> employees = new List<EmployeeModel>();
            try
            {
                using (var memoryStream = new MemoryStream())
                {
                    var lines = File.ReadAllLines(file);
                    foreach (string ln in lines)
                    {
                        string newline = ln.Replace("“", "\"").Replace("”", "\"");
                        if (newline.Trim() != "")
                        {
                            newline += "\r\n";
                            var bts = Encoding.Default.GetBytes(newline);
                            memoryStream.Write(bts, 0, bts.Length);
                        }
                    }
                    memoryStream.Seek(0, SeekOrigin.Begin);

                    using (TextFieldParser parser = new TextFieldParser(memoryStream))
                    {
                        parser.TextFieldType = FieldType.Delimited;
                        parser.SetDelimiters(",");

                        bool isfirst = true;
                        int rowid = 1;

                        while (!parser.EndOfData)
                        {
                            string[] fields = parser.ReadFields();

                            if (!isfirst)
                            {
                                bool hasError = fields.Length < 4;

                                string employeeName = "";
                                DateTime dateHired = DateTime.MinValue;
                                DateTime birthDate = DateTime.MinValue;
                                int salary = 1;

                                if (!hasError) employeeName = fields[0];
                                if (employeeName == "") hasError = true;
                                if (!hasError && !DateTime.TryParse(fields[1], out birthDate)) hasError = true;
                                if (!hasError && !int.TryParse(fields[2], out salary)) hasError = true;
                                if (!hasError && salary <= 0) hasError = true;
                                if (!hasError && !DateTime.TryParse(fields[3], out dateHired)) hasError = true;

                                var model = new EmployeeModel()
                                {
                                    Birthdate = birthDate,
                                    DateHired = dateHired,
                                    EmployeeName = employeeName,
                                    Status = hasError ? "invalid" : "valid",
                                    Salary = salary,
                                    Id = rowid
                                };
                                employees.Add(model);
                                rowid++;
                            }
                            else
                            {
                                isfirst = false;
                            }
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
            return employees.AsEnumerable();
        }
    }
}
