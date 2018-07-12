using System;
using System.Linq;

namespace CSVParser
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                try
                {
                    var resultList = CSVParserLib.Parser.ParseEmployeesFromFile(args[0].Replace("\"", "")).ToList();
                    resultList.ForEach(rs =>
                    {
                        Console.WriteLine("Name: " + rs.EmployeeName);
                        Console.WriteLine("Birthdate: " + rs.Birthdate.ToShortDateString());
                        Console.WriteLine("Salary: " + rs.Salary.ToString());
                        Console.WriteLine("Hired On: " + rs.DateHired.ToShortDateString());
                        Console.WriteLine("Status: " + rs.Status);
                        Console.WriteLine("");
                    });
                }
                catch
                {
                    Console.WriteLine("An error occurred while attempting to load the specified file.");
                    return;
                }
            }
            else
            {
                Console.WriteLine("Usage:  CSVParser [filename]");
                Console.WriteLine("");
            }
        }
    }
}
