using Ninject.Concrete;
using Ninject.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LACERAMVC.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            try
            {
                string filepath = Path.GetTempFileName();
                if (file.ContentLength > 0)
                {
                    file.SaveAs(filepath);
                    var employees = CSVParserLib.Parser.ParseEmployeesFromFile(filepath);
                    System.IO.File.Delete(filepath);

                    if (employees.Count() == 0)
                    {
                        ViewBag.Message = "Invalid file.  File contains no data.";
                        return View();
                    }
                    IEmployee employee = new Employee();
                    employee.DeleteAll();
                    var elist = employees.ToList();
                    elist.ForEach(e => employee.Add(e));
                    return Redirect("/Employee/Index");
                }
                ViewBag.Message = "Invalid file.  File contains no data.";
                return View();
            }
            catch
            {
                ViewBag.Message = "Invalid file.  Please select a csv file.";
                return View();
            }
        }
    }
}