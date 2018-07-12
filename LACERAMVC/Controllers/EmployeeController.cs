using Ninject.Concrete;
using Ninject.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LACERAMVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployee _employee;

        public EmployeeController()
        {
            _employee = new Employee();
        }

        public ActionResult Index()
        {
            var data = _employee.GetAll();
            return View(data);
        }
    }
}