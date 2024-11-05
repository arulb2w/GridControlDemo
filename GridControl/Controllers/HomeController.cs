using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GridControl.Models;

namespace GridControl.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Grid()
        {
            ViewBag.Message = "Your Gird control page.";

            return View();
        }

        public ActionResult GridControl()
        {
            ViewBag.Message = "Your Gird control page.";

            return View();
        }

        private static List<FakeEmployee> _employees = new List<FakeEmployee>
        {
            new FakeEmployee { Id = 1, Name = "Tiger Nixon", Position = "System Architect", Office = "Edinburgh", Age = 61, StartDate = DateTime.Parse("2011-04-25"), Salary = 320800 },
            new FakeEmployee { Id = 2, Name = "Garrett Winters", Position = "Accountant", Office = "Tokyo", Age = 63, StartDate = DateTime.Parse("2011-07-25"), Salary = 170750 },
            // Add more fake data as needed
        };   



        [HttpGet]
        public JsonResult GetEmployees()
        {
            return Json(new { data = _employees }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult CreateEmployee(FakeEmployee employee)
        {
            employee.Id = _employees.Max(e => e.Id) + 1;
            _employees.Add(employee);
            return Json(employee);
        }

        [HttpPost]
        public JsonResult UpdateEmployee(FakeEmployee employee)
        {
            var existing = _employees.FirstOrDefault(e => e.Id == employee.Id);
            if (existing != null)
            {
                existing.Name = employee.Name;
                existing.Position = employee.Position;
                existing.Office = employee.Office;
                existing.Age = employee.Age;
                existing.StartDate = employee.StartDate;
                existing.Salary = employee.Salary;
            }
            return Json(existing);
        }

        [HttpPost]
        public JsonResult DeleteEmployee(int id)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                _employees.Remove(employee);
            }
            return Json(employee);
        }
    }
}